using System;
using System.Collections.Generic;
using System.Reflection;
using SrsConfFile.SRSConfClass;

namespace SrsConfFile
{
    public static class Common
    {
        public static string? WorkDir = Environment.CurrentDirectory + "/";
        public static List<SrsSystemConfClass> StreamNodes = new List<SrsSystemConfClass>();

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
            string[] tmpSarr = System.Text.RegularExpressions.Regex.Split(s,@"[\s]+");
            //string[] tmp_sarr = s.Split('\t', StringSplitOptions.RemoveEmptyEntries);

            if (tmpSarr.Length == 2)
            {
                return new KeyValuePair<string, string>(tmpSarr[0].Trim(),
                    tmpSarr[1].Remove(tmpSarr[1].Length - 1).Trim());
            }
            else
            {
                if (tmpSarr.Length > 2)
                {
                    string ss = "";
                    for (int i = 1; i <= tmpSarr.Length - 1; i++)
                    {
                        if (tmpSarr[i].Contains(';'))
                        {
                            tmpSarr[i] = tmpSarr[i].Replace(';', ' ');
                            ss += tmpSarr[i];
                        }
                        else
                        {
                            ss += tmpSarr[i] + " ";
                        }
                    }

                    return new KeyValuePair<string, string>(tmpSarr[0].Trim(), ss.Trim());
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
            string[] sArr;
            if (s != null && s.Contains(' '))
            {
                sArr = System.Text.RegularExpressions.Regex.Split(s,@"[\s]+");
               // s_arr = s.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
               if (sArr.Length > 1)
                {
                    if (sArr[1].Trim() != "{")
                    {
                        return new KeyValuePair<string, string>(sArr[0].Trim(), sArr[1].Trim());
                    }
                    else
                    {
                        return new KeyValuePair<string, string>(sArr[0].Trim(), "");
                    }
                }
            }

            return new KeyValuePair<string, string>(s?.Trim()!, "");
        }
    }
}