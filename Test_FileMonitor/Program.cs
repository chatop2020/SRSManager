using System;
using SRSApis.SystemAutonomy;

namespace Test_FileMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IngestMonitor a= new IngestMonitor("/root/StreamNode/22364bc4-5134-494d-8249-51d06777fb7f/ffmpegLog",".log","22364bc4-5134-494d-8249-51d06777fb7f");
            //(string ffmpegLogPath, string logExt, string? deviceId
            while (true)
            {
                Console.ReadLine();
            }
        }
    }
}