using System;
using System.Threading;
using System.Threading.Tasks;
using Mictlanix.DotNet.Onvif;
using Mictlanix.DotNet.Onvif.Common;
using Mictlanix.DotNet.Onvif.Ptz;
namespace Test_Onvif_Discovery
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = "192.168.2.164";
            var username = "admin";
            var password = "3987qzwas";
            OnvifMonitor onvif = null;
            try
            {
                onvif = new OnvifMonitor(host, username, password);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                onvif = null;
            }

            if (onvif != null)
            {
                onvif.InitMonitor().Wait();

                foreach (var st in onvif.StreamUrls)
                {
                    Console.WriteLine(st);
                }

                if (onvif.GetMediaInfo().Result)
                {
                    foreach (var ms in onvif.MediaSourceInfos)
                    {
                        Console.WriteLine(ms.ToString());
                    }
                }
            }
        }

       
    }
}