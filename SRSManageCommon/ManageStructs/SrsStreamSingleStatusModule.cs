using System;

namespace SRSManageCommon.ManageStructs
{
    [Serializable]
    public class SrsStreamSingleStatusModule
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
        public StreamsItem? Stream { get; set; }
    }
}