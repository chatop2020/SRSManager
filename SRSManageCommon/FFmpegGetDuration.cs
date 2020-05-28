using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace SRSManageCommon
{
    public static class FFmpegGetDuration
    {
        /// <summary>
        /// 正则获取内容
        /// </summary>
        /// <param name="str"></param>
        /// <param name="s"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static string GetValue(string str, string s, string e)
        {
            Regex rg = new Regex("(?<=(" + s + "))[.\\s\\S]*?(?=(" + e + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            return rg.Match(str).Value;
        }
        /// <summary>
        /// 输出视频的时长（毫秒）
        /// </summary>
        /// <param name="ffmpegBinPath"></param>
        /// <param name="videoFilePath"></param>
        /// <param name="duartion"></param>
        /// <returns></returns>
        public static bool GetDuration(string ffmpegBinPath, string videoFilePath,out long duartion)
        {
            duartion = -1;
            if (File.Exists(ffmpegBinPath) && File.Exists(videoFilePath))
            {
                string cmd = ffmpegBinPath + " -i " + videoFilePath;
                if (LinuxShell.Run(cmd, 1000, out string std, out string err))
                {
                    if (!string.IsNullOrEmpty(std) || !string.IsNullOrEmpty(err))
                    {
                        string tmp = "";
                        if (!string.IsNullOrEmpty(std))
                        {
                             tmp = GetValue(std, "Duration:", ",");
                        }

                        if (string.IsNullOrEmpty(tmp))
                        {
                            tmp = GetValue(err, "Duration:", ",");  
                        }
                        if (!string.IsNullOrEmpty(tmp))
                        {
                            string[] tmpArr = tmp.Split(':', StringSplitOptions.RemoveEmptyEntries);
                            if (tmpArr.Length == 3)
                            {
                                int hour = int.Parse(tmpArr[0]);
                                int min = int.Parse(tmpArr[1]);
                                int sec = 0;
                                int msec = 0;
                                if (tmpArr[2].Contains('.'))
                                {
                                    string[] tmpArr2 = tmpArr[2].Split('.', StringSplitOptions.RemoveEmptyEntries);
                                    sec = int.Parse(tmpArr2[0]);
                                    msec = int.Parse(tmpArr2[1]);
                                }
                                else
                                {
                                    sec = int.Parse(tmpArr[2]);
                                }
                                hour = hour * 3600;//换成秒数
                                min = min * 60;
                                sec = sec + hour + min; //合计秒数
                                duartion = sec * 1000 + (msec*10);//算计成毫秒
                                return true; 
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}