using System;
using System.Collections.Generic;
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
        public static void Main(string[] args)
        {
            
           ReqAddAllow a = new ReqAddAllow();
           a.Password = "password123!@#";
           a.Allowkey= new AllowKey();
           a.Allowkey.Key = "EDC35161-D561-43F2-867B-63C74A928F7A";
         a.Allowkey.IpArray= new List<string>();
           
           a.Allowkey.IpArray.Add("192.168.*.*");
           string s = JsonHelper.ToJson(a);
                
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>().UseUrls("http://*:5800"); });
    }
}