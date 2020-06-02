using System;
using System.Collections.Generic;

namespace SrsApis.SrsManager.Apis.ApiModules
{
    [Serializable]
    public class Publish
    {
        /// <summary>
        /// 
        /// </summary>
        public string? Active { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Cid { get; set; }
    }

    [Serializable]
    public class Video
    {
        /// <summary>
        /// 
        /// </summary>
        public string? Codec { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Profile { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Level { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Width { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Height { get; set; }
    }

    [Serializable]
    public class Audio
    {
        /// <summary>
        /// 
        /// </summary>
        public string? Codec { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Sample_rate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Channel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Profile { get; set; }
    }

    [Serializable]
    public class StreamsItem
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
        public int? Vhost { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? App { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long? Live_ms { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Clients { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? Frames { get; set; }

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
        public Publish? Publish { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Video? Video { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Audio? Audio { get; set; }
    }

    [Serializable]
    public class SrsStreamsStatusModule
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
        public List<StreamsItem>? Streams { get; set; }
    }
}