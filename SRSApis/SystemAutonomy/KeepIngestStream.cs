using System;
using System.Threading;
using SrsApis.SrsManager.Apis;
using SrsConfFile.SRSConfClass;
using SrsManageCommon;
using SRSManageCommon.DBMoudle;
using SRSManageCommon.ManageStructs;

namespace SRSApis.SystemAutonomy
{
    public class KeepIngestStream
    {
        private int interval = SrsManageCommon.Common.SystemConfig.KeepIngestStreamServiceinterval;

        private void doThing(string deviceId, string vhostDomain, Ingest ingest)
        {
            LogWriter.WriteLog("重启设备ID" + deviceId + "下的" + vhostDomain + "下的" + ingest.IngestName + " Ingest");

            lock (SrsManageCommon.Common.LockDbObjForOnlineClient)
            {
                OrmService.Db.Delete<OnlineClient>().Where(x => x.RtspUrl == ingest.Input!.Url).ExecuteAffrows();
            }

            var retInt = foundProcess(ingest);
            if (retInt > -1)
            {
                try
                {
                    string cmd = "kill -9 " + retInt.ToString();
                    LinuxShell.Run(cmd, 1000);
                }
                catch (Exception ex)
                {
                    LogWriter.WriteLog(
                        "重启设备ID" + deviceId + "下的" + vhostDomain + "下的" + ingest.IngestName + " Ingest失败",
                        ex.Message + "\r\n" + ex.StackTrace, ConsoleColor.Yellow);
                }
            }

            ResponseStruct rs = null!;
            VhostIngestApis.OnOrOffIngest(deviceId, vhostDomain, ingest.IngestName!, false, out rs);
            SystemApis.RefreshSrsObject(deviceId, out rs);
            Thread.Sleep(1000);
            VhostIngestApis.OnOrOffIngest(deviceId, vhostDomain, ingest.IngestName!, true, out rs);
            SystemApis.RefreshSrsObject(deviceId, out rs);
        }

        private int foundProcess(Ingest ingest)
        {
            string url = ingest.Input!.Url!.Replace("&", @"\&");
            string cmd = "ps  -aux |grep " + url + "|grep -v grep |awk '{print $2}'";
            LinuxShell.Run(cmd, 1000, out string sdt, out string err);
            if (string.IsNullOrEmpty(sdt) && string.IsNullOrEmpty(err))
            {
                return -1;
            }

            if (int.TryParse(sdt, out int i))
            {
                return i;
            }

            if (int.TryParse(err, out int j))
            {
                return j;
            }

            return -1;
        }

        private bool ingestIsDead(string deviceId, Ingest ingest)
        {
            var onPublishList = FastUsefulApis.GetOnPublishMonitorListByDeviceId(deviceId, out ResponseStruct rs);
            if (onPublishList == null || onPublishList.Count == 0)
            {
                return true;
            }

            var client =
                onPublishList.FindLast(x => !string.IsNullOrEmpty(x.RtspUrl) && x.RtspUrl! == ingest.Input!.Url!);
            if (client != null)
            {
                if (client.IsOnline == false)
                {
                    return true;
                }

                return false;
            }


            return true;
        }

        private void Run()
        {
            while (true)
            {
                try
                {
                    var retDeviceList = SystemApis.GetAllSrsManagerDeviceId();
                    if (retDeviceList != null && retDeviceList.Count > 0)
                    {
                        foreach (var dev in retDeviceList)
                        {
                            if (string.IsNullOrEmpty(dev)) continue;
                            var retSrsManager = SystemApis.GetSrsManagerInstanceByDeviceId(dev);
                            if (retSrsManager == null || retSrsManager.Srs == null || !retSrsManager.IsRunning)
                                continue;
                            var retSrsVhostList =
                                VhostApis.GetVhostList(retSrsManager.SrsDeviceId, out ResponseStruct rs);
                            if (retSrsVhostList == null || retSrsVhostList.Count == 0) continue;
                            foreach (var vhost in retSrsVhostList)
                            {
                                if (vhost == null || vhost.Vingests == null || vhost.Vingests.Count == 0) continue;
                                foreach (var ingest in vhost.Vingests)
                                {
                                    if (ingest.Enabled == false) continue;
                                    if (ingestIsDead(dev, ingest))
                                    {
                                        LogWriter.WriteLog(
                                            "监控到设备ID" + dev + "下的" + vhost.VhostDomain + "下的" + ingest.IngestName +
                                            " 处于异常状态，立即重启ingest", "", ConsoleColor.Red);
                                        doThing(dev, vhost.VhostDomain!, ingest);
                                    }

                                    Thread.Sleep(30);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogWriter.WriteLog("Ingest守护异常...", ex.Message + "\r\n" + ex.StackTrace);
                }

                Thread.Sleep(interval);
            }
        }

        public KeepIngestStream()
        {
            new Thread(new ThreadStart(delegate
            {
                try
                {
                    LogWriter.WriteLog("启动Ingest守护服务...(循环间隔：" + interval + "ms)");
                    Run();
                }
                catch (Exception ex)
                {
                    LogWriter.WriteLog("启动Ingest守护服务失败...", ex.Message + "\r\n" + ex.StackTrace, ConsoleColor.Yellow);
                    Console.WriteLine(ex.Message);
                }
            })).Start();
        }
    }
}