using SRSApis.SRSManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SRSWebApi.RequestModules
{
    public class VhostCommonRequest
    {
        public string srsManager { get; set; }
        public string vhostDomain { get; set; }
    }
}
