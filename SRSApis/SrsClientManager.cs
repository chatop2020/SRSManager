using System;
using System.Collections.Generic;
using System.Threading;
using SrsApis.SrsManager.Apis;
using SrsApis.SrsManager.Apis.ApiModules;
using SrsManageCommon;
using SrsManageCommon.ApisStructs;

namespace SRSApis
{
    public class SrsClientManager
    {
        private List<Channels> GetGB28181Channels(string httpUri)
        {
            string act = "/api/v1/gb28181?action=query_channel";
            string url = httpUri + act;
            try
            {
                string tmpStr = SrsManageCommon.NetHelper.Get(url);
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
                                        var reti = OrmService.Db.Update<Client>().Set(x => x.MonitorIp, inputIp)
                                            .Set(x => x.RtspUrl, ingest.Input!.Url!)
                                            .Where(x => x.Stream!.Equals(ingest.IngestName) &&
                                                        x.Device_Id!.Equals(srs.SrsDeviceId) &&
                                                        (x.MonitorIp == null || x.MonitorIp == "" ||
                                                         x.MonitorIp == "127.0.0.1"))
                                            .ExecuteAffrows();
                                        /*if (reti > 0)
                                        {
                                            Console.WriteLine("补全Onvif客户端ip地址：" + reti.ToString());
                                        }*/
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
                                    var reti = OrmService.Db.Update<Client>()
                                        .Set(x => x.MonitorIp, r.Rtp_Peer_Ip)
                                        .Where(x => x.Stream!.Equals(r.Stream) &&
                                                    x.Device_Id!.Equals(srs.SrsDeviceId) &&
                                                    (x.MonitorIp == null || x.MonitorIp == "" ||
                                                     x.MonitorIp == "127.0.0.1"))
                                        .ExecuteAffrows();
                                    /*if (reti > 0)
                                    {
                                        Console.WriteLine("补全28181客户端ip地址：" + reti.ToString());
                                    }*/
                                }
                            }
                        }
                    }
                }
            }
        }

        private void clearOfflinePlayerUser()
        {
            var re = OrmService.Db.Delete<Client>().Where(x => x.ClientType == ClientType.User &&
                                                               x.IsPlay == false &&
                                                               x.UpdateTime <= DateTime.Now.AddMinutes(-3))
                .ExecuteAffrows();
            /*if (re > 0)
            {
                Console.WriteLine("清理掉3分种以前没有更新并且不在播放状态的用户连接：" + re.ToString());
            } */
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

                Thread.Sleep(5000);
            }
        }

        public SrsClientManager()
        {
            OrmService.Db.Delete<Client>().Where("1=1").ExecuteAffrows();
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