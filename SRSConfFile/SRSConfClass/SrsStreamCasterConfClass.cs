using System;

namespace SRSConfFile.SRSConfClass
{
    [Serializable]
    public class Sip : SrsConfBase
    {
        private ushort? ack_timeout;
        private bool? auto_play;

        private bool? enabled;
        private bool? invite_port_fixed;
        private ushort? keepalive_timeout;
        private ushort? listen;
        private ushort? query_catalog_interval;
        private string? realm;
        private string? serial;

        public Sip()
        {
            SectionsName = "sip";
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public ushort? Listen
        {
            get => listen;
            set => listen = value;
        }

        public string? Serial
        {
            get => serial;
            set => serial = value;
        }

        public string? Realm
        {
            get => realm;
            set => realm = value;
        }

        public ushort? Ack_timeout
        {
            get => ack_timeout;
            set => ack_timeout = value;
        }

        public ushort? Keepalive_timeout
        {
            get => keepalive_timeout;
            set => keepalive_timeout = value;
        }

        public bool? Auto_play
        {
            get => auto_play;
            set => auto_play = value;
        }

        public bool? Invite_port_fixed
        {
            get => invite_port_fixed;
            set => invite_port_fixed = value;
        }

        public ushort? Query_catalog_interval
        {
            get => query_catalog_interval;
            set => query_catalog_interval = value;
        }
    }

    public enum CasterEnum
    {
        mpegts_over_udp,
        rtsp,
        flv,
        gb28181
    }

    [Serializable]
    public class SrsStreamCasterConfClass : SrsConfBase
    {
        //要修正最新gb28181格式 
        private string? _instanceName;

        private bool? audio_enable;
        /*use for gb28181
          # rtp包空闲等待时间，如果指定时间没有收到任何包
          # rtp监听连接自动停止，发送BYE命令
        */

        private bool? auto_create_channel;
        private CasterEnum? caster;
        private bool? enabled;
        private string? host; //use for gb28181 ,can be domain or ip address
        private ushort? listen; //open a port for pull stream

        private string? output; //rtmp path use for player
        /*use for gb28181
         # 是否等待关键帧之后，再转发，
         # off:不需等待，直接转发
         # on:等第一个关键帧后，再转发
        */

        private ushort? rtp_idle_timeout;
        private ushort? rtp_port_max; //user for rtsp&gb28181 caster
        private ushort? rtp_port_min; //use for rtsp&gb28181 caster

        private Sip? ssip;
        /*use for gb28181
          # 是否转发音频流
          # 目前只支持aac格式，所以需要设备支持aac格式
          # on:转发音频  
          # off:不转发音频，只有视频
          #*注意*!!!:flv 只支持11025  22050  44100 三种
          # 如果设备端没有三种中任何一个，转发时为自动选择一种格式
          # 同时也会将adts的头封装在flv aac raw数据中
          # 这样的话播放器为自动通过adts头自动选择采样频率
          # 像ffplay, vlc都可以，但是flash是没有声音，
          # 因为flash,只支持11025 22050 44100
         */


        private bool? wait_keyframe;

        public SrsStreamCasterConfClass()
        {
            SectionsName = "stream_caster";
        }

        public Sip? sip
        {
            get => ssip;
            set => ssip = value;
        }

        public bool? Auto_create_channel
        {
            get => auto_create_channel;
            set => auto_create_channel = value;
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public CasterEnum? Caster
        {
            get => caster;
            set => caster = value;
        }

        public string? Output
        {
            get => output;
            set => output = value;
        }

        public ushort? Listen
        {
            get => listen;
            set => listen = value;
        }

        public ushort? Rtp_port_min
        {
            get => rtp_port_min;
            set => rtp_port_min = value;
        }

        public ushort? Rtp_port_max
        {
            get => rtp_port_max;
            set => rtp_port_max = value;
        }

        public string? Host
        {
            get => host;
            set => host = value;
        }

        public bool? Audio_enable
        {
            get => audio_enable;
            set => audio_enable = value;
        }

        public bool? Wait_keyframe
        {
            get => wait_keyframe;
            set => wait_keyframe = value;
        }

        public ushort? Rtp_idle_timeout
        {
            get => rtp_idle_timeout;
            set => rtp_idle_timeout = value;
        }

        public string? InstanceName
        {
            get => _instanceName;
            set => _instanceName = value;
        }
    }
}