#nullable enable
using System;
using System.Collections.Generic;

namespace SRSApis.SRSManager.Apis.ApiModules
{

    [Serializable]
    public class Channels
    {
        /// <summary>
        /// 
        /// </summary>
        public string? Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? Ip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Rtmp_Port { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? App { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? Stream { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? Rtmp_Url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Ssrc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Rtp_Port { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? Port_Mode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Rtp_Peer_Port { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? Rtp_Peer_Ip { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Recv_Time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? Recv_Time_Str { get; set; }
    }
[Serializable]
    public class Data
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Channels>? Channels { get; set; }
    }
[Serializable]
    public class SrsT28181QueryChannelModule
    {
        /// <summary>
        /// 
        /// </summary>
        public int? Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Data? Data { get; set; }
    }
     
    
}