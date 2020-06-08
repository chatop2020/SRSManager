using System;
using System.Collections.Generic;

namespace SRSManageCommon.ManageStructs
{
    [Serializable]
    public class Kbps
    {
        /// <summary>
        /// 
        /// </summary>
        public long? Recv_30s { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Send_30s { get; set; }
    }

    [Serializable]
    public class Hls
    {
        /// <summary>
        /// 
        /// </summary>
        public string? Enabled { get; set; }
    }

    [Serializable]
    public class VhostsItem
    {
        /// <summary>
        /// 
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Enabled { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Clients { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Streams { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Send_bytes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Recv_bytes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Kbps? Kbps { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Hls? Hls { get; set; }
    }

    [Serializable]
    public class SrsVhostsStatusModule
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
        public List<VhostsItem>? Vhosts { get; set; }
    }
}