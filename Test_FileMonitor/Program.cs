using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using SRSApis.SystemAutonomy;

namespace Test_FileMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0;
            /*
            Console.WriteLine("Hello World!");
            IngestMonitor a= new IngestMonitor("/root/StreamNode/22364bc4-5134-494d-8249-51d06777fb7f/ffmpegLog",".log","22364bc4-5134-494d-8249-51d06777fb7f");
            */
            //(string ffmpegLogPath, string logExt, string? deviceId
            List<int> aaaList= new List<int>();
            aaaList.Add(1);
            aaaList.Add(1);
            aaaList.Add(1);
            aaaList.Add(1);
            aaaList.Add(1);
            aaaList.Add(1);
            aaaList.Add(1);
            aaaList.Add(1);
            aaaList.Add(1);
            aaaList.Add(1);
            List<int> bbbList= new List<int>();
            bbbList.Add(1);
            bbbList.Add(1);
            bbbList.Add(1);
            bbbList.Add(1);
            bbbList.Add(1);
            bbbList.Add(1);
            bbbList.Add(1);
            bbbList.Add(1);
            bbbList.Add(1);
            bbbList.Add(1);
            for (int i = 0; i <= aaaList.Count-1; i++)
            {
                a += ((double) 1 / (double) aaaList.Count * 100f) * 0.5f;
              //  a+= ((((double)(1) / (double)aaaList.Count) *100*0.5) );
                Console.WriteLine("aaalist:"+a);
            }
            for (int i = 0; i <= bbbList.Count-1; i++)
            {
                a += ((double) 1 / (double) aaaList.Count * 100f) * 0.5f;
                Console.WriteLine("bbblist:"+a);
            }

            return;
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