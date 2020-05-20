using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace SRSWebApi
{
    public class Program
    {
        public static Common common= new Common();
        public static void Main(string[] args)
        {
            common.CommonInit();
            Console.WriteLine(common.GetTimeStampMilliseconds());
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>().UseUrls(common.BaseUrl); });
    }
}