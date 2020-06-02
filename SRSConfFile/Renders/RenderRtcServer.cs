using System.Collections.Generic;
using SrsConfFile.SRSConfClass;

namespace SrsConfFile.Renders
{
    public static class RenderRtcServer
    {
        public static void Render_BlackHole(SectionBody scbin, SrsSystemConfClass sccout, string instanceName = "")
        {
            if (sccout.Rtc_server?.Black_hole == null)
                if (sccout.Rtc_server != null)
                    sccout.Rtc_server.Black_hole = new BlackHole();
            if (sccout.Rtc_server != null)
            {
                if (sccout.Rtc_server.Black_hole != null)
                {
                    sccout.Rtc_server.Black_hole.SectionsName = "black_hole";
                    if (scbin.BodyList != null)
                        foreach (string s in scbin.BodyList)
                        {
                            if (!s.Trim().EndsWith(";")) continue;
                            KeyValuePair<string, string> tmpkv = Common.GetKV(s);
                            if (string.IsNullOrEmpty(tmpkv.Key)) continue;
                            string cmd = tmpkv.Key.Trim().ToLower();
                            switch (cmd)
                            {
                                case "enabled":
                                    sccout.Rtc_server.Black_hole.Enabled = Common.str2bool(tmpkv.Value);
                                    break;
                                case "publisher":
                                    sccout.Rtc_server.Black_hole.Publisher = tmpkv.Value;
                                    break;
                            }
                        }
                }
            }
        }

        public static void Render(SectionBody scbin, SrsSystemConfClass sccout, string instanceName = "")
        {
            if (sccout.Rtc_server == null) sccout.Rtc_server = new SrsRtcServerConfClass();
            sccout.Rtc_server.SectionsName = "rtc_server";
            if (scbin.BodyList != null)
                foreach (string s in scbin.BodyList)
                {
                    if (!s.Trim().EndsWith(";")) continue;
                    KeyValuePair<string, string> tmpkv = Common.GetKV(s);
                    if (string.IsNullOrEmpty(tmpkv.Key)) continue;

                    string cmd = tmpkv.Key.Trim().ToLower();
                    switch (cmd)
                    {
                        case "enabled":
                            sccout.Rtc_server.Enabled = Common.str2bool(tmpkv.Value);
                            break;
                        case "listen":
                            sccout.Rtc_server.Listen = Common.str2ushort(tmpkv.Value);
                            break;
                        case "candidate":
                            sccout.Rtc_server.Candidate = tmpkv.Value;
                            break;
                        case "ecdsa":
                            sccout.Rtc_server.Ecdsa = Common.str2bool(tmpkv.Value);
                            break;
                        case "sendmmsg":
                            sccout.Rtc_server.Sendmmsg = Common.str2ushort(tmpkv.Value);
                            break;
                        case "encrypt":
                            sccout.Rtc_server.Encrypt = Common.str2bool(tmpkv.Value);
                            break;
                        case "reuseport":
                            sccout.Rtc_server.Reuseport = Common.str2ushort(tmpkv.Value);
                            break;
                        case "merge_nalus":
                            sccout.Rtc_server.Merge_nalus = Common.str2bool(tmpkv.Value);
                            break;
                        case "gso":
                            sccout.Rtc_server.Gso = Common.str2bool(tmpkv.Value);
                            break;
                        case "padding":
                            sccout.Rtc_server.Padding = Common.str2ushort(tmpkv.Value);
                            break;
                        case "perf_stat":
                            sccout.Rtc_server.Perf_stat = Common.str2bool(tmpkv.Value);
                            break;
                        case "queue_length":
                            sccout.Rtc_server.Queue_length = Common.str2ushort(tmpkv.Value);
                            break;
                    }
                }

            if (scbin.SubSections != null && scbin.SubSections.Count > 0)
            {
                foreach (SectionBody scb in scbin.SubSections)
                {
                    Render_BlackHole(scb, sccout);
                }
            }
        }
    }
}