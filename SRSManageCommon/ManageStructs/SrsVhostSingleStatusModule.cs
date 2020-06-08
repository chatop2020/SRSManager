using System;

namespace SRSManageCommon.ManageStructs
{
    [Serializable]
    public class SrsVhostSingleStatusModule
    {
        /// <summary>
        /// 
        /// </summary>
        public int? Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Server { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public VhostsItem? Vhost { get; set; }
    }
}