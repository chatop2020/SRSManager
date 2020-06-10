using System;
using System.Collections.Generic;
using System.Threading;
using SrsApis.SrsManager.Apis;
using SrsManageCommon;
using SRSManageCommon.DBMoudle;
using SRSManageCommon.ManageStructs;

namespace SRSApis.SystemAutonomy
{
    public class SrsClientManager
    {
        private void rewriteMonitorType()
        {
            if (Common.SrsManagers != null)
            {
                foreach (var srs in Common.SrsManagers)
                {
                    if (srs.IsInit && srs.Srs != null && srs.IsRunning)
                    {
                        var onPublishList =
                            FastUsefulApis.GetOnPublishMonitorListByDeviceId(srs.SrsDeviceId, out ResponseStruct rs);
                        if(onPublishList==null || onPublishList.Count==0) continue;
                        foreach (var client in onPublishList)
                        {
                            #region 处理28181设备
                                ushort? port = srs.Srs.Http_api!.Listen;
                                if (port == null || srs.Srs.Http_api == null || srs.Srs.Http_api.Enabled == false)
                                    continue;
                                var ret = GetGB28181Channels("http://127.0.0.1:" + port.ToString());
                                if (ret != null)
                                {
                                    foreach (var r in ret)
                                    {
                                        if (!string.IsNullOrEmpty(r.Stream) && r.Stream.Equals(client.Stream))
                                        {
 
                                            var reti = OrmService.Db.Update<OnlineClient>()
                                                .Set(x => x.MonitorType, MonitorType.GBT28181)
                                                .Where(x => x.Client_Id==client.Client_Id)
                                                .ExecuteAffrows();
                                        }
                                    }
                                }
                                #endregion
                                #region 处理onvif设备
                                var ingestList = FastUsefulApis.GetAllIngestByDeviceId(srs.SrsDeviceId, out rs);
                                if (ingestList != null && ingestList.Count > 0)
                                {
                                    foreach (var ingest in ingestList)
                                    {
                                        
                                        if (ingest != null && ingest.Input != null 
                                            && client.RtspUrl!=null &&ingest.Input!.Url!.Equals(client.RtspUrl))
                                        {
                                            var reti = OrmService.Db.Update<OnlineClient>()
                                                .Set(x => x.MonitorType, MonitorType.Onvif)
                                                .Where(x => x.Client_Id==client.Client_Id)
                                                .ExecuteAffrows(); 
                                        }
                                    }
                                }
                                #endregion
                                #region 处理直播流
                                int retj = OrmService.Db.Update<OnlineClient>()
                                    .Set(x => x.MonitorType, MonitorType.Webcast)
                                    .Where(x=>x.MonitorType==MonitorType.Unknow)
                                    .ExecuteAffrows();
                            
                                #endregion
                           // }
                        }
                       
                    }
                }
            }
        }
        private List<Channels> GetGB28181Channels(string httpUri)
        {
            string act = "/api/v1/gb28181?action=query_channel";
            string url = httpUri + act;
            try
            {
                string tmpStr = NetHelper.Get(url);
                var ret = JsonHelper.FromJson<SrsT28181QueryChannelModule>(tmpStr);
                if (ret.Code == 0 && ret.Data != null)
                {
                    return ret.Data.Channels!;
                }

                return null!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
        }

        private void completionOnvifIpAddress()
        {
            if (Common.SrsManagers != null)
            {
                foreach (var srs in Common.SrsManagers)
                {
                    if (srs.IsInit && srs.Srs != null && srs.IsRunning)
                    {
                        var ret = VhostIngestApis.GetVhostIngestNameList(srs.SrsDeviceId, out ResponseStruct rs);
                        if (ret != null)
                        {
                            foreach (var r in ret)
                            {
                                var ingest = VhostIngestApis.GetVhostIngest(srs.SrsDeviceId, r.VhostDomain!,
                                    r.IngestInstanceName!,
                                    out rs);

                                if (ingest != null)
                                {
                                    string inputIp =
                                        SrsManageCommon.Common
                                            .GetIngestRtspMonitorUrlIpAddress(ingest.Input!.Url!)!;
                                    if (SrsManageCommon.Common.IsIpAddr(inputIp!))
                                    {
                                        var reti = OrmService.Db.Update<OnlineClient>()
                                            .Set(x => x.MonitorIp, inputIp)
                                            .Set(x => x.RtspUrl, ingest.Input!.Url!)
                                            .Where(x => x.Stream!.Equals(ingest.IngestName) &&
                                                        x.Device_Id!.Equals(srs.SrsDeviceId) &&
                                                        (x.MonitorIp == null || x.MonitorIp == "" ||
                                                         x.MonitorIp == "127.0.0.1"))
                                            .ExecuteAffrows();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void completionT28181IpAddress()
        {
            if (Common.SrsManagers != null)
            {
                foreach (var srs in Common.SrsManagers)
                {
                    if (srs.IsInit && srs.Srs != null && srs.IsRunning)
                    {
                        ushort? port = srs.Srs.Http_api!.Listen;
                        if (port == null || srs.Srs.Http_api == null || srs.Srs.Http_api.Enabled == false)
                            continue;
                        var ret = GetGB28181Channels("http://127.0.0.1:" + port.ToString());
                        if (ret != null)
                        {
                            foreach (var r in ret)
                            {
                                if (!string.IsNullOrEmpty(r.Rtp_Peer_Ip) && !string.IsNullOrEmpty(r.Stream))
                                {
                                    var reti = OrmService.Db.Update<OnlineClient>()
                                        .Set(x => x.MonitorIp, r.Rtp_Peer_Ip)
                                        .Where(x => x.Stream!.Equals(r.Stream) &&
                                                    x.Device_Id!.Equals(srs.SrsDeviceId) &&
                                                    (x.MonitorIp == null || x.MonitorIp == "" ||
                                                     x.MonitorIp == "127.0.0.1"))
                                        .ExecuteAffrows();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void clearOfflinePlayerUser()
        {
            var re = OrmService.Db.Delete<OnlineClient>().Where(x => x.ClientType == ClientType.User &&
                                                               x.IsPlay == false &&
                                                               x.UpdateTime <= DateTime.Now.AddMinutes(-3))
                .ExecuteAffrows();
        }

        private void Run()
        {
            while (true)
            {
                #region 补全ingest过来的monitorip地址

                completionOnvifIpAddress();
                Thread.Sleep(500);

                #endregion

                #region 补28181 monitorip 地址

                completionT28181IpAddress();
                Thread.Sleep(500);

                #endregion

                #region 删除长期没更新的user类型的非播放的客户端

                clearOfflinePlayerUser();
                Thread.Sleep(500);

                #endregion

                #region 重写摄像头类型

                rewriteMonitorType();
                Thread.Sleep(500);

                #endregion

                Thread.Sleep(5000);
            }
        }

        public SrsClientManager()
        {
            OrmService.Db.Delete<OnlineClient>().Where("1=1").ExecuteAffrows();
            new Thread(new ThreadStart(delegate

            {
                try
                {
                    Run();
                }
                catch (Exception ex)
                {
                    // ignored
                    Console.WriteLine(ex.Message);
                }
            })).Start();
        }
    }
}