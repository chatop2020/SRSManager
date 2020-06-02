using System;
using System.Collections.Generic;

namespace SrsApis.SrsManager.Apis.ApiModules
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