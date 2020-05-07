using System;
using System.Collections.Generic;
using SRSConfFile.SRSConfClass;

namespace SRSConfFile.Renders
{
    public static class RenderStreamCaster
    {
        public static void Render_Sip(SectionBody scbin, SrsStreamCasterConfClass sccout, string instanceName = "")
        {
            if (sccout.sip == null)
            {
                sccout.sip = new Sip();
            }
            else
            {
                return; //只能有一个
            }

            sccout.sip.SectionsName = "sip";
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
                            sccout.sip.Enabled = Common.str2bool(tmpkv.Value);
                            break;
                        case "listen":
                            sccout.sip.Listen = Common.str2ushort(tmpkv.Value);
                            break;
                        case "serial":
                            sccout.sip.Serial = tmpkv.Value;
                            break;
                        case "realm":
                            sccout.sip.Realm = tmpkv.Value;
                            break;
                        case "ack_timeout":
                            sccout.sip.Ack_timeout = Common.str2ushort(tmpkv.Value);
                            break;
                        case "keepalive_timeout":
                            sccout.sip.Keepalive_timeout = Common.str2ushort(tmpkv.Value);
                            break;
                        case "auto_play":
                            sccout.sip.Auto_play = Common.str2bool(tmpkv.Value);
                            break;
                        case "invite_port_fixed":
                            sccout.sip.Invite_port_fixed = Common.str2bool(tmpkv.Value);
                            break;
                        case "query_catalog_interval":
                            sccout.sip.Query_catalog_interval = Common.str2ushort(tmpkv.Value);
                            break;
                    }
                }
        }

        public static void Render(SectionBody scbin, SrsSystemConfClass sccout, string instanceName = "")
        {
            if (sccout.Stream_casters == null) sccout.Stream_casters = new List<SrsStreamCasterConfClass>();

            SrsStreamCasterConfClass sccc = new SrsStreamCasterConfClass();
            if (scbin.BodyList != null)
                foreach (string s in scbin.BodyList)
                {
                    if (!s.Trim().EndsWith(";")) continue;
                    KeyValuePair<string, string> tmpkv = Common.GetKV(s);
                    if (string.IsNullOrEmpty(tmpkv.Key)) continue;
                    sccc.InstanceName = instanceName;
                    sccc.SectionsName = "stream_caster";
                    string cmd = tmpkv.Key.Trim().ToLower();
                    switch (cmd)
                    {
                        case "enabled":
                            sccc.Enabled = Common.str2bool(tmpkv.Value);
                            break;
                        case "caster":
                            sccc.Caster = (CasterEnum) Enum.Parse(typeof(CasterEnum), tmpkv.Value);
                            break;
                        case "output":
                            sccc.Output = tmpkv.Value;
                            break;
                        case "listen":
                            sccc.Listen = Common.str2ushort(tmpkv.Value);
                            break;
                        case "rtp_port_min":
                            sccc.Rtp_port_min = Common.str2ushort(tmpkv.Value);
                            break;
                        case "rtp_port_max":
                            sccc.Rtp_port_max = Common.str2ushort(tmpkv.Value);
                            break;
                        case "host":
                            sccc.Host = tmpkv.Value;
                            break;
                        case "audio_enable":
                            sccc.Audio_enable = Common.str2bool(tmpkv.Value);
                            break;
                        case "wait_keyframe":
                            sccc.Wait_keyframe = Common.str2bool(tmpkv.Value);
                            break;
                        case "rtp_idle_timeout":
                            sccc.Rtp_idle_timeout = Common.str2ushort(tmpkv.Value);
                            break;
                        case "auto_create_channel":
                            sccc.Auto_create_channel = Common.str2bool(tmpkv.Value);
                            break;
                    }
                }

            if (scbin.SubSections != null)
                foreach (SectionBody scb in scbin.SubSections)
                {
                    Render_Sip(scb, sccc);
                }

            sccout.Stream_casters.Add(sccc);
        }
    }
}