using System.Collections.Generic;
using SrsConfFile.SRSConfClass;

namespace SrsConfFile.Renders
{
    public static class RenderKafka
    {
        public static void Render(SectionBody scbin, SrsSystemConfClass sccout, string instanceName = "")
        {
            if (sccout.Kafka == null) sccout.Kafka = new SrsKafkaConfClass();
            sccout.Kafka.SectionsName = "kafka";
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
                            sccout.Kafka.Enabled = Common.str2bool(tmpkv.Value);
                            break;
                        case "brokers":
                            sccout.Kafka.Brokers = tmpkv.Value;
                            break;
                        case "topic":
                            sccout.Kafka.Topic = tmpkv.Value;
                            break;
                    }
                }
        }
    }
}