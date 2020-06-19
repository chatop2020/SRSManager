using System;
using System.IO;
using System.Net.Mime;
using System.Threading;
using SRSApis.SystemAutonomy;

namespace Test_MonitorFileSize
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists("/tmp/22364bc4-5134-494d-8249-51d06777fb7f/ffmpegLog"))
            {
                Directory.CreateDirectory("/tmp/22364bc4-5134-494d-8249-51d06777fb7f/ffmpegLog");
            }
            if (!Directory.Exists("/tmp/22364bc4-5134-494d-8249-51d06777fb7a/ffmpegLog"))
            {
                Directory.CreateDirectory("/tmp/22364bc4-5134-494d-8249-51d06777fb7a/ffmpegLog");
            }
            Console.WriteLine("Hello World!");
            var a = new IngestMonitor("/tmp/22364bc4-5134-494d-8249-51d06777fb7a/ffmpegLog",".log","1");
            var b = new IngestMonitor("/tmp/22364bc4-5134-494d-8249-51d06777fb7f/ffmpegLog",".log","2");
           
            while (true)
            {
                var sw = File.AppendText(
                    "/tmp/22364bc4-5134-494d-8249-51d06777fb7a/ffmpegLog/ffmpeg-ingest-__defaultVhost__-live-192.168.2.163_profile_101.log");
                sw.WriteLine("This");
                sw.WriteLine("is Extra");
                sw.WriteLine("Text");
                sw.Flush();
                sw.Close();
                var sw2 = File.AppendText(
                    "/tmp/22364bc4-5134-494d-8249-51d06777fb7a/ffmpegLog/ffmpeg-ingest-__defaultVhost__-live-192.168.2.163_profile_10b.log");
                sw2.WriteLine("This");
                sw2.WriteLine("is Extra");
                sw2.WriteLine("Text");
                sw2.Flush();
                sw2.Close();
        
                /*
                File.WriteAllText("/tmp/22364bc4-5134-494d-8249-51d06777fb7a/ffmpegLog/ffmpeg-ingest-__defaultVhost__-live-192.168.2.163_profile_101.log","aaaaa");
              File.WriteAllText("/tmp/22364bc4-5134-494d-8249-51d06777fb7f/ffmpegLog/fmpeg-ingest-__defaultVhost__-live-192.168.2.163_profile_10b.log","bbbbb");
              */
              Thread.Sleep(30);
            }
        }
    }
}