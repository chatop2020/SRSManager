using SRSApis.SRSManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRSWebApi.RequestModules
{
    public class VhostCommonRequest
    {
        public string deviceId { get; set; }
        public string deviceName { get; set; }
        public A a { get; set; }
    }
    public class A
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
