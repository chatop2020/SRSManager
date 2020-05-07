using System.Collections.Generic;
using SRSConfFile.SRSConfClass;

namespace SRSConfFile.Renders
{
    public static class RenderSrtServer
    {
        public static void Render(SectionBody scbin, SrsSystemConfClass sccout, string instanceName = "")
        {
            if (sccout.Srt_server == null) sccout.Srt_server = new SrsSrtServerConfClass();
            sccout.Srt_server.SectionsName = "srt_server";
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
                            sccout.Srt_server.Enabled = Common.str2bool(tmpkv.Value);
                            break;
                        case "listen":
                            sccout.Srt_server.Listen = Common.str2ushort(tmpkv.Value);
                            break;
                        case "maxbw":
                            sccout.Srt_server.Maxbw = Common.str2int(tmpkv.Value);
                            break;
                        case "connect_timeout":
                            sccout.Srt_server.Connect_timeout = Common.str2int(tmpkv.Value);
                            break;
                        case "peerlatency":
                            sccout.Srt_server.Peerlatency = Common.str2int(tmpkv.Value);
                            break;
                        case "recvlatency":
                            sccout.Srt_server.Recvlatency = Common.str2int(tmpkv.Value);
                            break;
                        case "default_app":
                            sccout.Srt_server.Default_app = tmpkv.Value;
                            break;
                    }
                }
        }
    }
}