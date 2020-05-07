using System.Collections.Generic;
using SRSConfFile.SRSConfClass;

namespace SRSConfFile.Renders
{
    public static class RenderStats
    {
        public static void Render(SectionBody scbin, SrsSystemConfClass sccout, string instanceName = "")
        {
            if (sccout.Stats == null) sccout.Stats = new SrsStatsConfClass();
            sccout.Stats.SectionsName = "stats";
            if (scbin.BodyList != null)
                foreach (string s in scbin.BodyList)
                {
                    if (!s.Trim().EndsWith(";")) continue;
                    KeyValuePair<string, string> tmpkv = Common.GetKV(s);
                    if (string.IsNullOrEmpty(tmpkv.Key)) continue;

                    string cmd = tmpkv.Key.Trim().ToLower();
                    switch (cmd)
                    {
                        case "network":
                            sccout.Stats.Network = Common.str2byte(tmpkv.Value);
                            break;

                        case "disk":
                            sccout.Stats.Disk = tmpkv.Value;
                            break;
                    }
                }
        }
    }
}