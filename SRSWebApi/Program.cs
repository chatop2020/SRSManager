using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SRSWebApi.RequestModules;

namespace SRSWebApi
{
    public class Program
    {
        public static Common common = new Common();

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