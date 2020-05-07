using System;
using System.Collections.Generic;
using System.Reflection;
using SRSConfFile.SRSConfClass;

namespace SRSConfFile
{
    public static class Common
    {
        public static string? WorkDir = Environment.CurrentDirectory + "/";
        public static List<SrsSystemConfClass> StreamNodes = new List<SrsSystemConfClass>();


        public static string? CreateUUID()
        {
            return Guid.NewGuid().ToString("D");
        }

        public static string? AddDoubleQuotation(string s)
        {
            return "\"" + s + "\"";
        }

        public static string? RemoveDoubleQuotation(string s)
        {
            return s.Replace("\"", "").Replace("{", "").Replace("}", "");
        }

        public static string GetBoolStr(PropertyInfo p, object? obj)
        {
            if (p.PropertyType == typeof(bool?))
            {
                if ((bool?) p.GetValue(obj) == false || (bool?) p.GetValue(obj) == null)
                {
                    return "off";
                }
                else
                {
                    return "on";
                }
            }

            return "";
        }

        public static KeyValuePair<string, string> GetKV(string s)
        {
            string[] tmp_sarr = s.Split('\t', StringSplitOptions.RemoveEmptyEntries);

            if (tmp_sarr.Length == 2)
            {
                return new KeyValuePair<string, string>(tmp_sarr[0].Trim(),
                    tmp_sarr[1].Remove(tmp_sarr[1].Length - 1).Trim());
            }
            else
            {
                if (tmp_sarr.Length > 2)
                {
                    string ss = "";
                    for (int i = 1; i <= tmp_sarr.Length - 1; i++)
                    {
                        if (tmp_sarr[i].Contains(';'))
                        {
                            tmp_sarr[i] = tmp_sarr[i].Replace(';', ' ');
                            ss += tmp_sarr[i];
                        }
                        else
                        {
                            ss += tmp_sarr[i] + " ";
                        }
                    }

                    return new KeyValuePair<string, string>(tmp_sarr[0].Trim(), ss.Trim());
                }
                else
                {
                    return new KeyValuePair<string, string>();
                }
            }
        }

        public static bool isRoot(SectionBody scb)
        {
            bool isRootFlag = true;
            if (scb.BodyList != null)
                foreach (string s in scb.BodyList)
                {
                    if (s.Contains('{') || s.Contains('}'))
                    {
                        isRootFlag = false;
                        break;
                    }
                }

            return isRootFlag;
        }


        public static bool str2bool(string s)
        {
            if (s.Trim().ToUpper() == "ON" || s.Trim().ToUpper() == "TRUE")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static ushort str2ushort(string s)
        {
            ushort i;
            if (ushort.TryParse(s, out i))
            {
                return i;
            }
            else
            {
                return 9999;
            }
        }

        public static int str2int(string s)
        {
            int i;
            if (int.TryParse(s, out i))
            {
                return i;
            }
            else
            {
                return 9999;
            }
        }

        public static float str2float(string s)
        {
            float i;
            if (float.TryParse(s, out i))
            {
                return i;
            }
            else
            {
                return 9999f;
            }
        }

        public static byte str2byte(string s)
        {
            byte i;
            if (byte.TryParse(s, out i))
            {
                return i;
            }
            else
            {
                return 255;
            }
        }


        public static KeyValuePair<string, string> getSectionNameAndInstanceNameValue(SectionBody scb)
        {
            string? s = scb.BodyList?[0];
            string[] s_arr;
            if (s != null && s.Contains(' '))
            {
                s_arr = s.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                if (s_arr.Length > 1)
                {
                    if (s_arr[1].Trim() != "{")
                    {
                        return new KeyValuePair<string, string>(s_arr[0].Trim().ToLower(), s_arr[1].Trim().ToLower());
                    }
                    else
                    {
                        return new KeyValuePair<string, string>(s_arr[0].Trim().ToLower(), "");
                    }
                }
            }

            return new KeyValuePair<string, string>(s?.Trim().ToLower()!, "");
        }
    }
}