using System.Collections.Generic;
using SrsConfFile.SRSConfClass;

namespace SrsConfFile.Renders
{
    public static class RenderHeartbeat
    {
        public static void Render(SectionBody scbin, SrsSystemConfClass sccout, string instanceName = "")
        {
            if (sccout.Heartbeat == null) sccout.Heartbeat = new SrsHeartbeatConfClass();
            sccout.Heartbeat.SectionsName = "heartbeat";
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
                            sccout.Heartbeat.Enabled = Common.str2bool(tmpkv.Value);
                            break;
                        case "interval":
                            sccout.Heartbeat.Interval = Common.str2float(tmpkv.Value);
                            break;
                        case "url":
                            sccout.Heartbeat.Url = tmpkv.Value;
                            break;
                        case "device_id":
                            sccout.Heartbeat.Device_id = tmpkv.Value;
                            break;
                        case "summaries":
                            sccout.Heartbeat.Summaries = Common.str2bool(tmpkv.Value);
                            break;
                    }
                }
        }
    }
}