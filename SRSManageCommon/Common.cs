#nullable enable
using System;
using System.Text.RegularExpressions;

namespace SRSManageCommon
{
    [Serializable]
    public enum ClientType
    {
        Monitor,
        User
    }
    
    public static class Common
    {
       public static string WorkPath = Environment.CurrentDirectory + "/";
        public static Object LockObj= new object();

        public static string? GetIngestRtspMonitorUrlIpAddress(string url)
        {
            try
            {
                Uri link = new Uri(url);
                return  link.Host;
                /*string p = @"(rtsp)://(?<domain>[^(:|/]*)";
                Regex reg = new Regex(p, RegexOptions.IgnoreCase);
                Match m = reg.Match(url);
                return m.Groups["domain"].Value;*/
            }
            catch
            {
                return "";
            }
        }
        
        /// <summary>
        /// 检测是否为ip 地址
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIpAddr(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        public static string? AddDoubleQuotation(string s)
        {
            return "\"" + s + "\"";
        }

        public static string? RemoveDoubleQuotation(string s)
        {
            return s.Replace("\"", "").Replace("{", "").Replace("}", "");
        }


        /// <summary>
        /// 生成guid
        /// </summary>
        /// <returns></returns>
        public static string? CreateUuid()
        {
            return Guid.NewGuid().ToString("D");
        }

        /// <summary>
        /// 是否为GUID
        /// </summary>
        /// <param name="strSrc"></param>
        /// <returns></returns>
        public static bool IsUuidByError(string strSrc)
        {
            if (String.IsNullOrEmpty(strSrc))
            {
                return false;
            }

            bool _result = false;
            try
            {
                Guid _t = new Guid(strSrc);
                _result = true;
            }
            catch
            {
            }

            return _result;
        }
    }
}