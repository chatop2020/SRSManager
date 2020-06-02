using System;
using System.IO;

namespace Test_FFmpeg_GetDurationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            FFmpegGetDuration.GetDuration("/usr/local/bin/ffmpeg",
                "/Users/qiuzhouwei/Downloads/iAETAqNtcDQDAQQABQAG2gAjhAGkC1ijNgKqjQN_hy6n5qQn_APPAAABcjCTN0AEzgAOpOcHzg4ccE0IAA.mp4",
                out long i);
            Console.WriteLine(
                Path.GetDirectoryName(
                    "/root/StreamNode/eb1d30e2-1c69-4047-a08b-0003b66f430c/wwwroot/dvr/20200528/__defaultVhost__/live/34020000001330000001@34020000001320000001/23/20200528232737___defaultVhost___live_34020000001330000001@34020000001320000001.flv")
            );
            Console.WriteLine("时长（毫秒）" + i);
        }
    }
}