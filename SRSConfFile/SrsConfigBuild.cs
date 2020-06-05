#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SrsConfFile.SRSConfClass;

namespace SrsConfFile
{
    public static class SrsConfigBuild
    {
        private static KeyValuePair<string, string> paddingSegment(int segmentLevel)
        {
            string segmentSpace = "";
            string segmentSpace_head = "";
            for (int i = 0; i < segmentLevel; i++)
            {
                segmentSpace += "\t";
                if (i < segmentLevel - 1)
                {
                    segmentSpace_head += "\t";
                }
            }

            return new KeyValuePair<string, string>(segmentSpace_head, segmentSpace);
        }

        private static void write_HttpApi(SrsHttpApiConfClass? o, out string output, int segmentLevel,
            List<Type> types = null!)
        {
            string output_raw_api = "";
            output = "";
            string segmentSpace_head = paddingSegment(segmentLevel).Key;
            string segmentSpace = paddingSegment(segmentLevel).Value;
            output += segmentSpace_head + o?.SectionsName?.ToLower().Trim() + " { \r\n";
            foreach (PropertyInfo p in o?.GetType().GetProperties()!)
            {
                object? obj = p.GetValue(o);
                if (obj == null) continue;
                if (p.Name.ToLower().Trim() == "sectionsname" || p.Name.ToLower().Trim() == "instancename")
                {
                    continue;
                }

                if ((p.PropertyType == typeof(string) || p.PropertyType == typeof(int?) ||
                     p.PropertyType == typeof(ushort?) ||
                     p.PropertyType == typeof(byte?)
                     || p.PropertyType == typeof(float?) || p.PropertyType == typeof(bool?))
                    || ((types != null) && types.Contains(p.PropertyType)))
                {
                    if (obj != null)
                    {
                        if (p.PropertyType == typeof(bool?))
                        {
                            string s = "";
                            s = Common.GetBoolStr(p, o);
                            string sTmp = segmentSpace + p.Name.Trim().ToLower() + "\t" + s + ";";
                            output += (sTmp + "\r\n");
                        }
                        else
                        {
                            string sTmp = segmentSpace + p.Name.Trim().ToLower() + "\t" + obj + ";";
                            output += (sTmp + "\r\n");
                        }
                    }
                }
            }

            foreach (PropertyInfo p in o.GetType().GetProperties()) //循环非基础类型数据，为了保证基础类型数据在顶上
            {
                object? obj = p.GetValue(o);
                if (obj == null) continue;
                if (p.Name.ToLower().Trim() == "sectionsname" || p.Name.ToLower().Trim() == "instancename")
                {
                    continue;
                }

                if (p.PropertyType == typeof(RawApi))
                {
                    write_SubOnly(o.Raw_Api, out output_raw_api, 2);
                    output += output_raw_api;
                }
            }

            output += segmentSpace_head + "}\r\n";
        }

        private static void write_RtcServer(SrsRtcServerConfClass? o, out string output, int segmentLevel,
            List<Type> types = null!)
        {
            string output_black_hole = "";
            output = "";
            string segmentSpace_head = paddingSegment(segmentLevel).Key;
            string segmentSpace = paddingSegment(segmentLevel).Value;
            output += segmentSpace_head + o?.SectionsName?.ToLower().Trim() + " { \r\n";
            foreach (PropertyInfo p in o?.GetType().GetProperties()!)
            {
                object? obj = p.GetValue(o);
                if (obj == null) continue;
                if (p.Name.ToLower().Trim() == "sectionsname" || p.Name.ToLower().Trim() == "instancename")
                {
                    continue;
                }

                if ((p.PropertyType == typeof(string) || p.PropertyType == typeof(int?) ||
                     p.PropertyType == typeof(ushort?) ||
                     p.PropertyType == typeof(byte?)
                     || p.PropertyType == typeof(float?) || p.PropertyType == typeof(bool?))
                    || ((types != null) && types.Contains(p.PropertyType)))
                {
                    if (obj != null)
                    {
                        if (p.PropertyType == typeof(bool?))
                        {
                            string s = "";
                            s = Common.GetBoolStr(p, o);
                            string sTmp = segmentSpace + p.Name.Trim().ToLower() + "\t" + s + ";";
                            output += (sTmp + "\r\n");
                        }
                        else
                        {
                            string sTmp = segmentSpace + p.Name.Trim().ToLower() + "\t" + obj + ";";
                            output += (sTmp + "\r\n");
                        }
                    }
                }
            }

            foreach (PropertyInfo p in o.GetType().GetProperties()) //循环非基础类型数据，为了保证基础类型数据在顶上
            {
                object? obj = p.GetValue(o);
                if (obj == null) continue;
                if (p.Name.ToLower().Trim() == "sectionsname" || p.Name.ToLower().Trim() == "instancename")
                {
                    continue;
                }

                if (p.PropertyType == typeof(BlackHole))
                {
                    write_SubOnly(o.Black_hole, out output_black_hole, 2);
                    output += output_black_hole;
                }
            }

            output += segmentSpace_head + "}\r\n";
        }

        private static void write_SubOnly(SrsConfBase? o, out string output, int segmentLevel, List<Type> types = null!)
        {
            output = "";
            string segmentSpace_head = paddingSegment(segmentLevel).Key;
            string segmentSpace = paddingSegment(segmentLevel).Value;
            output += segmentSpace_head + o?.SectionsName?.ToLower().Trim() + " { \r\n";
            foreach (PropertyInfo p in o?.GetType().GetProperties()!)
            {
                object? obj = p.GetValue(o);
                if (obj == null) continue;
                if (p.Name.ToLower().Trim() == "sectionsname" || p.Name.ToLower().Trim() == "instancename")
                {
                    continue;
                }

                if ((p.PropertyType == typeof(string) || p.PropertyType == typeof(int?) ||
                     p.PropertyType == typeof(ushort?) ||
                     p.PropertyType == typeof(byte?)
                     || p.PropertyType == typeof(float?) || p.PropertyType == typeof(bool?))
                    || ((types != null) && types.Contains(p.PropertyType)))
                {
                    if (obj != null)
                    {
                        if (p.PropertyType == typeof(bool?))
                        {
                            string s = "";
                            s = Common.GetBoolStr(p, o);
                            string sTmp = segmentSpace + p.Name.Trim().ToLower() + "\t" + s + ";";
                            output += (sTmp + "\r\n");
                        }
                        else
                        {
                            string sTmp = segmentSpace + p.Name.Trim().ToLower() + "\t" + obj + ";";
                            output += (sTmp + "\r\n");
                        }
                    }
                }
            }

            output += segmentSpace_head + "}\r\n";
        }

        private static void write_StreamCaster(SrsStreamCasterConfClass o, out string output, int segmentLevel,
            List<Type> types = null!)
        {
            string output_sip = "";
            output = "";
            string segmentSpace_head = paddingSegment(segmentLevel).Key;
            string segmentSpace = paddingSegment(segmentLevel).Value;
            output += segmentSpace_head + o.SectionsName?.ToLower().Trim() + " " + o.InstanceName + " { \r\n";
            foreach (PropertyInfo p in o.GetType().GetProperties())
            {
                object? obj = p.GetValue(o);
                if (obj == null) continue;
                if (p.Name.ToLower().Trim() == "sectionsname" || p.Name.ToLower().Trim() == "instancename")
                {
                    continue;
                }

                if ((p.PropertyType == typeof(string) || p.PropertyType == typeof(int?) ||
                     p.PropertyType == typeof(ushort?) ||
                     p.PropertyType == typeof(byte?)
                     || p.PropertyType == typeof(float?) || p.PropertyType == typeof(bool?))
                    || ((types != null) && types.Contains(p.PropertyType)))
                {
                    if (obj != null)
                    {
                        if (p.PropertyType == typeof(bool?))
                        {
                            string s = "";
                            s = Common.GetBoolStr(p, o);
                            string sTmp = segmentSpace + p.Name.Trim().ToLower() + "\t" + s + ";";
                            output += (sTmp + "\r\n");
                        }
                        else
                        {
                            string sTmp = segmentSpace + p.Name.Trim().ToLower() + "\t" + obj + ";";
                            output += (sTmp + "\r\n");
                        }
                    }
                }
            }

            foreach (PropertyInfo p in o.GetType().GetProperties()) //循环非基础类型数据，为了保证基础类型数据在顶上
            {
                object? obj = p.GetValue(o);
                if (obj == null) continue;
                if (p.Name.ToLower().Trim() == "sectionsname" || p.Name.Trim() == "instancename")
                {
                    continue;
                }

                if (p.PropertyType == typeof(Sip))
                {
                    write_SubOnly(o.sip, out output_sip, 2);
                    output += output_sip;
                }
            }

            output += segmentSpace_head + "}\r\n";
        }


        private static void write_Vhost_Ingest(Ingest o, out string output, int segmentLevel, List<Type> types = null!)
        {
            output = "";
            string segmentSpace_head = paddingSegment(segmentLevel).Key;
            string segmentSpace = paddingSegment(segmentLevel).Value;
            output += segmentSpace_head + o.SectionsName?.ToLower().Trim() + " " + o.IngestName + " { \r\n";
            foreach (PropertyInfo p in o.GetType().GetProperties())
            {
                object? obj = p.GetValue(o);
                if (obj == null) continue;
                if (p.Name.ToLower().Trim() == "sectionsname" || p.Name.Trim().ToLower() == "instancename" ||
                    p.Name.ToLower().Trim() == "ingestname")                       
                {
                    continue;
                }

                if ((p.PropertyType == typeof(string) || p.PropertyType == typeof(int?) ||
                     p.PropertyType == typeof(ushort?) ||
                     p.PropertyType == typeof(byte?)
                     || p.PropertyType == typeof(float?) || p.PropertyType == typeof(bool?))
                    || ((types != null) && types.Contains(p.PropertyType)))
                {
                    if (obj != null)
                    {
                        if (p.PropertyType == typeof(bool?))
                        {
                            string s = "";
                            s = Common.GetBoolStr(p, o);
                            string sTmp = segmentSpace + p.Name.Trim().ToLower() + "\t" + s + ";";
                            output += (sTmp + "\r\n");
                        }
                        else
                        {
                            string sTmp = segmentSpace + p.Name.Trim().ToLower() + "\t" + obj + ";";
                            output += (sTmp + "\r\n");
                        }
                    }
                }
            }

            foreach (PropertyInfo p in o.GetType().GetProperties()) //循环非基础类型数据，为了保证基础类型数据在顶上
            {
                object? obj = p.GetValue(o);
                if (obj == null) continue;
                if (p.Name.ToLower().Trim() == "sectionsname" || p.Name.ToLower().Trim() == "instancename")
                {
                    continue;
                }

                if (p.PropertyType == typeof(IngestInput))
                {
                    string s = "";
                    List<Type> types2 = new List<Type>();
                    types2.Add(typeof(IngestInputType?));
                    write_SubOnly(o.Input, out s, 3, types2);
                    output += s;
                }

                if (p.PropertyType == typeof(List<IngestTranscodeEngine>))
                {
                    List<Type> types1 = new List<Type>();
                    types1.Add(typeof(IngestEngineIoformat?));
                    types1.Add(typeof(IngestEngineVprofile?));
                    types1.Add(typeof(IngestEngineVpreset?));
                    if (o.Engines != null)
                        foreach (IngestTranscodeEngine i in o.Engines)
                        {
                            string s = "";
                            write_Vhost_Ingest_Engine(i, out s, 3, types1);
                            output += s;
                        }
                }
            }

            output += segmentSpace_head + "}\r\n";
        }

        private static void write_Vhost_Transcode(Transcode o, out string output, int segmentLevel,
            List<Type> types = null!)
        {
            output = "";
            string segmentSpace_head = paddingSegment(segmentLevel).Key;
            string segmentSpace = paddingSegment(segmentLevel).Value;
            output += segmentSpace_head + o.SectionsName?.ToLower().Trim() + " " + o.InstanceName + " { \r\n";
            foreach (PropertyInfo p in o.GetType().GetProperties())
            {
                object? obj = p.GetValue(o);
                if (obj == null) continue;
                if (p.Name.ToLower().Trim() == "sectionsname" || p.Name.ToLower().Trim() == "instancename" ||
                    p.Name.ToLower().Trim() == "ingestname")
                {
                    continue;
                }

                if ((p.PropertyType == typeof(string) || p.PropertyType == typeof(int?) ||
                     p.PropertyType == typeof(ushort?) ||
                     p.PropertyType == typeof(byte?)
                     || p.PropertyType == typeof(float?) || p.PropertyType == typeof(bool?))
                    || ((types != null) && types.Contains(p.PropertyType)))
                {
                    if (obj != null)
                    {
                        if (p.PropertyType == typeof(bool?))
                        {
                            string s = "";
                            s = Common.GetBoolStr(p, o);
                            string sTmp = segmentSpace + p.Name.Trim().ToLower() + "\t" + s + ";";
                            output += (sTmp + "\r\n");
                        }
                        else
                        {
                            string sTmp = segmentSpace + p.Name.Trim().ToLower() + "\t" + obj + ";";
                            output += (sTmp + "\r\n");
                        }
                    }
                }
            }

            foreach (PropertyInfo p in o.GetType().GetProperties()) //循环非基础类型数据，为了保证基础类型数据在顶上
            {
                object? obj = p.GetValue(o);
                if (obj == null) continue;
                if (p.Name.ToLower().Trim() == "sectionsname" || p.Name.ToLower().Trim() == "instancename")
                {
                    continue;
                }

                if (p.PropertyType == typeof(List<IngestTranscodeEngine>))
                {
                    List<Type> types1 = new List<Type>();
                    types1.Add(typeof(IngestEngineIoformat?));
                    types1.Add(typeof(IngestEngineVprofile?));
                    types1.Add(typeof(IngestEngineVpreset?));
                    if (o.Engines != null)
                        foreach (IngestTranscodeEngine i in o.Engines)
                        {
                            string s = "";
                            write_Vhost_Ingest_Engine(i, out s, 3, types1);
                            output += s;
                        }
                }
            }

            output += segmentSpace_head + "}\r\n";
        }

        private static void write_Vhost_Ingest_Engine(IngestTranscodeEngine o, out string output, int segmentLevel,
            List<Type> types = null!)
        {
            output = "";
            string segmentSpace_head = paddingSegment(segmentLevel).Key;
            string segmentSpace = paddingSegment(segmentLevel).Value;
            output += segmentSpace_head + o.SectionsName?.ToLower().Trim() + " " + o.EngineName + " { \r\n";
            foreach (PropertyInfo p in o.GetType().GetProperties())
            {
                object? obj = p.GetValue(o);
                if (obj == null) continue;
                if (p.Name.ToLower().Trim() == "sectionsname" || p.Name.ToLower().Trim() == "instancename" ||
                    p.Name.ToLower().Trim() == "enginename")
                {
                    continue;
                }

                if ((p.PropertyType == typeof(string) || p.PropertyType == typeof(int?) ||
                     p.PropertyType == typeof(ushort?) ||
                     p.PropertyType == typeof(byte?)
                     || p.PropertyType == typeof(float?) || p.PropertyType == typeof(bool?))
                    || ((types != null) && types.Contains(p.PropertyType)))
                {
                    if (obj != null)
                    {
                        if (p.PropertyType == typeof(bool?))
                        {
                            string s = "";
                            s = Common.GetBoolStr(p, o);
                            string sTmp = segmentSpace + p.Name.Trim().ToLower() + "\t" + s + ";";
                            output += (sTmp + "\r\n");
                        }
                        else
                        {
                            string sTmp = segmentSpace + p.Name.Trim().ToLower() + "\t" + obj + ";";
                            output += (sTmp + "\r\n");
                        }
                    }
                }
            }

            foreach (PropertyInfo p in o.GetType().GetProperties()) //循环非基础类型数据，为了保证基础类型数据在顶上
            {
                object? obj = p.GetValue(o);
                if (obj == null) continue;
                if (p.Name.ToLower().Trim() == "sectionsname" || p.Name.ToLower().Trim() == "instancename")
                {
                    continue;
                }

                if (p.PropertyType == typeof(IngestEnginePerfile))
                {
                    string s = "";
                    write_SubOnly(o.Perfile, out s, 4);
                    string[] sArr = s.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
                    string sss = "";
                    foreach (string ss in sArr)
                    {
                        if (ss.ToLower().Contains("re;"))
                        {
                            int i = 0;
                            foreach (char c in ss)
                            {
                                if (c == '\t' && i < 4) sss += c;
                                i++;
                            }

                            sss += "re;\r\n";
                        }
                        else
                        {
                            sss += ss + "\r\n";
                        }
                    }

                    output += sss;
                }

                if (p.PropertyType == typeof(IngestEngineVfilter))
                {
                    string s = "";
                    write_SubOnly(o.Vfilter, out s, 4);
                    output += s;
                }

                if (p.PropertyType == typeof(IngestEngineVparams))
                {
                    string s = "";
                    write_SubOnly(o.Vparams, out s, 4);
                    output += s;
                }

                if (p.PropertyType == typeof(IngestEngineAparams))
                {
                    string s = "";
                    write_SubOnly(o.Aparams, out s, 4);
                    output += s;
                }
            }

            output += segmentSpace_head + "}\r\n";
        }

        private static void write_Vhost(SrsvHostConfClass o, out string output, int segmentLevel,
            List<Type> types = null!)
        {
            output = "";
            string segmentSpace_head = paddingSegment(segmentLevel).Key;
            string segmentSpace = paddingSegment(segmentLevel).Value;
            output += segmentSpace_head + o.SectionsName?.ToLower().Trim() + " " + o.VhostDomain + " { \r\n";
            foreach (PropertyInfo p in o.GetType().GetProperties())
            {
                object? obj = p.GetValue(o);
                if (obj == null) continue;
                if (p.Name.ToLower().Trim() == "sectionsname" || p.Name.ToLower().Trim() == "instancename" ||
                    p.Name.ToLower().Trim() == "vhostdomain")
                {
                    continue;
                }

                if ((p.PropertyType == typeof(string) || p.PropertyType == typeof(int?) ||
                     p.PropertyType == typeof(ushort?) ||
                     p.PropertyType == typeof(byte?)
                     || p.PropertyType == typeof(float?) || p.PropertyType == typeof(bool?))
                    || ((types != null) && types.Contains(p.PropertyType)))
                {
                    if (obj != null)
                    {
                        if (p.PropertyType == typeof(bool?))
                        {
                            string s = "";
                            s = Common.GetBoolStr(p, o);
                            string sTmp = segmentSpace + p.Name.Trim().ToLower() + "\t" + s + ";";
                            output += (sTmp + "\r\n");
                        }
                        else
                        {
                            string sTmp = segmentSpace + p.Name.Trim().ToLower() + "\t" + obj + ";";
                            output += (sTmp + "\r\n");
                        }
                    }
                }
            }

            foreach (PropertyInfo p in o.GetType().GetProperties()) //循环非基础类型数据，为了保证基础类型数据在顶上
            {
                object? obj = p.GetValue(o);
                if (obj == null) continue;
                if (p.Name.ToLower().Trim() == "sectionsname" || p.Name.ToLower().Trim() == "instancename")
                {
                    continue;
                }

                if (p.PropertyType == typeof(Rtc))
                {
                    string output_rtc = "";
                    write_SubOnly(o.Rtc, out output_rtc, 2);
                    output += output_rtc;
                }

                if (p.PropertyType == typeof(Cluster))
                {
                    string output_cluster = "";
                    write_SubOnly(o.Vcluster, out output_cluster, 2);
                    output += output_cluster;
                }

                if (p.PropertyType == typeof(Forward))
                {
                    string output_forward = "";
                    write_SubOnly(o.Vforward, out output_forward, 2);
                    output += output_forward;
                }

                if (p.PropertyType == typeof(Play))
                {
                    string output_play = "";
                    List<Type> types1 = new List<Type>();
                    types1.Add(typeof(PlayTimeJitter?));
                    write_SubOnly(o.Vplay, out output_play, 2, types1);
                    output += output_play;
                }

                if (p.PropertyType == typeof(Publish))
                {
                    string output_publish = "";
                    write_SubOnly(o.Vpublish, out output_publish, 2);
                    output += output_publish;
                }

                if (p.PropertyType == typeof(Refer))
                {
                    string output_refer = "";
                    write_SubOnly(o.Vrefer, out output_refer, 2);
                    output += output_refer;
                }

                if (p.PropertyType == typeof(Bandcheck))
                {
                    string output_bandcheck = "";
                    write_SubOnly(o.Vbandcheck, out output_bandcheck, 2);
                    output += output_bandcheck;
                }

                if (p.PropertyType == typeof(Security))
                {
                    string segmentSpace_head1 = paddingSegment(2).Key;
                    string segmentSpace1 = paddingSegment(2).Value;
                    output += segmentSpace_head1 + "security" + " { \r\n";
                    if (o.Vsecurity?.Enabled != null)
                    {
                        if (o.Vsecurity.Enabled == true)
                        {
                            output += segmentSpace1 + "enabled\t" + "on;\r\n";
                        }
                        else
                        {
                            output += segmentSpace1 + "enabled\t" + "off;\r\n";
                        }
                    }

                    if (o.Vsecurity?.Seo != null)
                    {
                        foreach (SecurityObj s in o.Vsecurity.Seo)
                        {
                            output += segmentSpace1 + s.Sem.ToString() + "\t" + s.Set.ToString() + "\t" + s.Rule +
                                      ";\r\n";
                        }
                    }

                    output += segmentSpace_head1 + "}\r\n";
                }

                if (p.PropertyType == typeof(HttpStatic))
                {
                    string output_http_static = "";
                    write_SubOnly(o.Vhttp_static, out output_http_static, 2);
                    output += output_http_static;
                }

                if (p.PropertyType == typeof(HttpRemux))
                {
                    string output_http_remux = "";
                    write_SubOnly(o.Vhttp_remux, out output_http_remux, 2);
                    output += output_http_remux;
                }

                if (p.PropertyType == typeof(HttpHooks))
                {
                    string output_http_hooks = "";
                    write_SubOnly(o.Vhttp_hooks, out output_http_hooks, 2);
                    output += output_http_hooks;
                }

                if (p.PropertyType == typeof(Exec))
                {
                    string output_exec = "";
                    write_SubOnly(o.Vexec, out output_exec, 2);
                    output += output_exec;
                }

                if (p.PropertyType == typeof(Dash))
                {
                    string output_dash = "";
                    write_SubOnly(o.Vdash, out output_dash, 2);
                    output += output_dash;
                }

                if (p.PropertyType == typeof(Hls))
                {
                    string output_hls = "";
                    write_SubOnly(o.Vhls, out output_hls, 2);
                    output += output_hls;
                }

                if (p.PropertyType == typeof(Hds))
                {
                    string output_hds = "";
                    write_SubOnly(o.Vhds, out output_hds, 2);
                    output += output_hds;
                }

                if (p.PropertyType == typeof(Dvr))
                {
                    string output_dvr = "";
                    List<Type> types2 = new List<Type>();
                    types2.Add(typeof(PlayTimeJitter?));
                    write_SubOnly(o.Vdvr, out output_dvr, 2, types2);
                    output += output_dvr;
                }

                if (p.PropertyType == typeof(Nack))
                {
                    string output_nack = "";
                    write_SubOnly(o.Vnack, out output_nack, 2);
                    output += output_nack;
                }


                if (p.PropertyType == typeof(List<Ingest>))
                {
                    if (o.Vingests != null)
                        foreach (Ingest i in o.Vingests)
                        {
                            string s = "";
                            List<Type> types3 = new List<Type>();
                            types3.Add(typeof(IngestInputType?));
                            write_Vhost_Ingest(i, out s, 2, types3);
                            output = output + s;
                        }
                }

                if (p.PropertyType == typeof(List<Transcode>))
                {
                    if (o.Vtranscodes != null)
                        foreach (Transcode i in o.Vtranscodes)
                        {
                            string s = "";

                            write_Vhost_Transcode(i, out s, 2);
                            output = output + s;
                        }
                }
            }

            output += segmentSpace_head + "}\r\n";
        }

        public static string Build(SrsSystemConfClass sccout, string filepath = "")
        {
            string output_heartbeat = "";
            string output_httpserver = "";
            string output_httpapi = "";
            string output_kafka = "";
            string output_rtcserver = "";
            string output_srtserver = "";
            string output_stats = "";
            string output_streamcaster = "";
            string output_vhost = "";
            string output = "";
            string segmentSpace = paddingSegment(0).Value;
            foreach (PropertyInfo p in sccout.GetType().GetProperties())
            {
                object? obj = p.GetValue(sccout);
                if (obj == null) continue;
                if (p.Name.ToLower().Trim() == "sectionsname" || p.Name.ToLower().Trim() == "instancename")
                {
                    continue;
                }

                if (p.PropertyType == typeof(string) || p.PropertyType == typeof(int?) ||
                    p.PropertyType == typeof(ushort?) ||
                    p.PropertyType == typeof(byte?)
                    || p.PropertyType == typeof(float?) || p.PropertyType == typeof(bool?))
                {
                    if (obj != null)
                    {
                        if (p.PropertyType == typeof(bool?))
                        {
                            string s = "";
                            s = Common.GetBoolStr(p, sccout);
                            string sTmp = segmentSpace + p.Name.ToLower().Trim() + "\t" + s + ";";
                            output += (sTmp + "\r\n");
                        }
                        else
                        {
                            string sTmp = segmentSpace + p.Name.ToLower().Trim() + "\t" + obj + ";";
                            output += (sTmp + "\r\n");
                        }
                    }
                }
            }

            foreach (PropertyInfo p in sccout.GetType().GetProperties()) //循环非基础类型数据，为了保证基础类型数据在顶上
            {
                object? obj = p.GetValue(sccout);
                if (obj == null) continue;
                if (p.Name.ToLower().Trim() == "sectionsname" || p.Name.ToLower().Trim() == "instancename")
                {
                    continue;
                }

                if (p.PropertyType == typeof(SrsHeartbeatConfClass))
                {
                    write_SubOnly(sccout.Heartbeat, out output_heartbeat, 1);
                    output = output + output_heartbeat;
                }

                if (p.PropertyType == typeof(SrsHttpApiConfClass))
                {
                    write_HttpApi(sccout.Http_api, out output_httpapi, 1);
                    output = output + output_httpapi;
                }

                if (p.PropertyType == typeof(SrsHttpServerConfClass))
                {
                    write_SubOnly(sccout.Http_server, out output_httpserver, 1);
                    output = output + output_httpserver;
                }

                if (p.PropertyType == typeof(SrsKafkaConfClass))
                {
                    write_SubOnly(sccout.Kafka, out output_kafka, 1);
                    output = output + output_kafka;
                }

                if (p.PropertyType == typeof(SrsRtcServerConfClass))
                {
                    write_RtcServer(sccout.Rtc_server, out output_rtcserver, 1);
                    output = output + output_rtcserver;
                }

                if (p.PropertyType == typeof(SrsSrtServerConfClass))
                {
                    write_SubOnly(sccout.Srt_server, out output_srtserver, 1);
                    output = output + output_srtserver;
                }

                if (p.PropertyType == typeof(SrsStatsConfClass))
                {
                    write_SubOnly(sccout.Stats, out output_stats, 1);
                    output = output + output_stats;
                }

                if (p.PropertyType == typeof(List<SrsStreamCasterConfClass>))
                {
                    if (sccout.Stream_casters != null)
                        foreach (SrsStreamCasterConfClass s in sccout.Stream_casters)
                        {
                            List<Type> types = new List<Type>();
                            types.Add(typeof(CasterEnum?));
                            write_StreamCaster(s, out output_streamcaster, 1, types);
                            output = output + output_streamcaster;
                        }
                }

                if (p.PropertyType == typeof(List<SrsvHostConfClass>))
                {
                    if (sccout.Vhosts != null)
                        foreach (SrsvHostConfClass s in sccout.Vhosts)
                        {
                            write_Vhost(s, out output_vhost, 1);
                            output = output + output_vhost;
                        }
                }
            }

            if (!string.IsNullOrEmpty(filepath))
            {
                File.WriteAllText(filepath, output);
            }

            return output;
        }
    }
}