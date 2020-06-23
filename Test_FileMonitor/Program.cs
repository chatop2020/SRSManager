using System;
using System.IO;
using System.Threading;
using SRSApis.SystemAutonomy;

namespace Test_FileMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.WriteLine("Hello World!");
            IngestMonitor a= new IngestMonitor("/root/StreamNode/22364bc4-5134-494d-8249-51d06777fb7f/ffmpegLog",".log","22364bc4-5134-494d-8249-51d06777fb7f");
            */
            //(string ffmpegLogPath, string logExt, string? deviceId
            while (true)
            {
                using (StreamWriter sw = File.AppendText("/root/StreamNode/22364bc4-5134-494d-8249-51d06777fb7f/ffmpegLog/ffmpeg-ingest-__defaultVhost__-live-192.168.2.164_Media1.log")) 
                {
                    sw.WriteLine("This");
                    sw.WriteLine("is Extra");
                    sw.WriteLine("Text");
                    sw.Flush();
                    sw.Close();
                }	
                Thread.Sleep(10);
            }
        }
    }
}