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
    /// <summary>
    /// 入口类
    /// </summary>
    public class Program
    {
        /// <summary>
        /// webapi的通用类
        /// </summary>
        public static CommonFunctions CommonFunctions = new CommonFunctions();

        /// <summary>
        /// 程序入口
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CommonFunctions.CommonInit();
            Console.WriteLine(CommonFunctions.GetTimeStampMilliseconds());
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// 创建httpwebserver
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseUrls(CommonFunctions.BaseUrl);
                });
    }
}