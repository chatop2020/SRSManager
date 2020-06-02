using System;
using System.Collections.Generic;
using SrsManageCommon;
using SrsApis.SrsManager;
using SrsApis.SrsManager.Apis;
using SrsApis.SrsManager.Apis.ApiModules;
using SrsConfFile;
using SrsConfFile.SRSConfClass;
using SrsManageCommon.ApisStructs;
using Dvr = SrsConfFile.SRSConfClass.Dvr;
using JsonHelper = SrsManageCommon.JsonHelper;

namespace Test_SRSApis
{
    class Program
    {
        static void Main(string[] args)
        {
            string stream =
                "{\"code\":0,\"server\":87846,\"data\":{\"ok\":true,\"now_ms\":1591068638439,\"self\":{\"version\":\"4.0.23\",\"pid\":29282,\"ppid\":1,\"argv\":\"/root/StreamNode/srs -c /root/StreamNode/22364bc4-5134-494d-8249-51d06777fb7f.conf\",\"cwd\":\"/root/StreamNode\",\"mem_kbyte\":71448,\"mem_percent\":0.00,\"cpu_percent\":0.09,\"srs_uptime\":214},\"system\":{\"cpu_percent\":0.02,\"disk_read_KBps\":0,\"disk_write_KBps\":0,\"disk_busy_percent\":0.00,\"mem_ram_kbyte\":16266040,\"mem_ram_percent\":0.06,\"mem_swap_kbyte\":8257532,\"mem_swap_percent\":0.00,\"cpus\":8,\"cpus_online\":8,\"uptime\":162062.71,\"ilde_time\":1275660.46,\"load_1m\":0.12,\"load_5m\":0.22,\"load_15m\":0.19,\"net_sample_time\":1591068632439,\"net_recv_bytes\":0,\"net_send_bytes\":0,\"net_recvi_bytes\":458866896997,\"net_sendi_bytes\":218579639053,\"srs_sample_time\":1591068638439,\"srs_recv_bytes\":447805521,\"srs_send_bytes\":33944,\"conn_sys\":55,\"conn_sys_et\":29,\"conn_sys_tw\":10,\"conn_sys_udp\":4,\"conn_srs\":10}}}";
            var a = JsonHelper.FromJson<SrsSystemInfo>(stream);
            Console.WriteLine(a.ToString());
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