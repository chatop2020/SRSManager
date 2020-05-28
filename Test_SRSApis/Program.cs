using System;
using System.Collections.Generic;
using SRSManageCommon;
using SRSApis;
using SRSApis.SRSManager;
using SRSApis.SRSManager.Apis;
using SRSApis.SRSManager.Apis.ApiModules;
using SRSConfFile;
using SRSConfFile.SRSConfClass;
using Common = SRSApis.Common;
using JsonHelper = SRSManageCommon.JsonHelper;

namespace Test_SRSApis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine(JsonHelper.ToJson(SystemApis.GetSystemInfo()));
            SRSApis.Common.init_SrsServer();
            SRSApis.Common.startServers();
            List<string> srsdevidlist = SystemApis.GetAllSrsManagerDeviceId();
            Console.WriteLine(JsonHelper.ToJson(srsdevidlist));
            foreach (var s in srsdevidlist)
            {
                Console.WriteLine(JsonHelper.ToJson(SystemApis.GetSrsManagerInstanceByDeviceId(s)));
            }

            if (srsdevidlist.Count > 0)
            {
                SrsManager srsm = SystemApis.GetSrsManagerInstanceByDeviceId(srsdevidlist[0]);

                string d = "www.test1cn.tyz";

                Console.WriteLine("pid:" + srsm.IsRunning);
                ResponseStruct rs;
                SrsvHostConfClass vhost = VhostApis.GetVhostTemplate(VhostIngestInputType.Stream, out rs);
                vhost.VhostDomain = d;
                VhostApis.SetVhost(srsm.SrsDeviceId, vhost, out rs);
                Rtc rtc = new Rtc();
                rtc.Bframe = "known";
                rtc.Enabled = true;
                VhostRtcApis.SetVhostRtc(srsm.SrsDeviceId, d, rtc, out rs);
                Dvr dvr = new Dvr();
                dvr.Enabled = true;
                dvr.Dvr_path = "/dvr/path/";
                VhostDvrApis.SetVhostDvr(srsm.SrsDeviceId, d, dvr, out rs);
                Hds hds = new Hds();
                hds.Enabled = true;
                hds.Hds_window = 50;

                VhostHdsApis.SetVhostHds(srsm.SrsDeviceId, d, hds, out rs);
                SrtServerApis.DeleteSrtServer(srsm.SrsDeviceId, out rs);
                SrsSrtServerConfClass srt = new SrsSrtServerConfClass();
                srt = SrtServerApis.GetSrtServerTemplate(out rs);

                srt.Enabled = true;
                SrtServerApis.SetSrtServer(srsm.SrsDeviceId, srt, out rs);

                VhostApis.DeleteVhostByDomain(srsm.SrsDeviceId, "__defaultvhost__", out rs);
                VhostRtcApis.DeleteVhostRtc(srsm.SrsDeviceId, d, out rs);
                VhostHdsApis.DeleteVhostHds(srsm.SrsDeviceId, d, out rs);

                SrsConfigBuild.Build(srsm.Srs, srsm.SrsConfigPath);
                if (srsm.IsRunning)
                {
                    bool ret = srsm.Reload(out rs);
                }
            }
        }
    }
}