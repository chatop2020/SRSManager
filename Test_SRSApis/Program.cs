using System;
using System.Collections.Generic;
using SRSApis;
using SRSApis.SRSManager;
using SRSApis.SRSManager.Apis;
using SRSApis.SRSManager.Apis.ApiModules;
using SRSConfFile;
using SRSConfFile.SRSConfClass;
using Common = SRSApis.Common;

namespace Test_SRSApis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine(JsonHelper.ToJson(SystemApis.GetSystemInfo()));
            Common.init_SrsServer();
            Common.startServers();
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
                VhostApis.CreateVhost(srsm, vhost, out rs);
                Rtc rtc = new Rtc();
                rtc.Bframe = "known";
                rtc.Enabled = true;
                VhostRtcApis.CreateVhostRtc(srsm, d, rtc, out rs);
                Dvr dvr = new Dvr();
                dvr.Enabled = true;
                dvr.Dvr_path = "/dvr/path/";
                VhostDvrApis.CreateVhostDvr(srsm, d, dvr, out rs);
                Hds hds = new Hds();
                hds.Enabled = true;
                hds.Hds_window = 50;

                VhostHdsApis.CreateVhostHds(srsm, d, hds, out rs);
                SrtServerApis.DeleteSrtServer(srsm, out rs);
                SrsSrtServerConfClass srt = new SrsSrtServerConfClass();
                srt = SrtServerApis.GetSrtServerTemplate(out rs);

                srt.Enabled = true;
                SrtServerApis.CreateSrtServer(srsm, srt, out rs);

                VhostApis.DeleteVhostByDomain(srsm, "__defaultvhost__", out rs);
                VhostRtcApis.DeleteVhostRtc(srsm, d, out rs);
                VhostHdsApis.DeleteVhostHds(srsm, d, out rs);

                SrsConfigBuild.Build(srsm.Srs, srsm.srs_ConfigPath);
                if (srsm.IsRunning)
                {
                   bool ret= srsm.Reload(out rs);
                }
            }
        }
    }
}