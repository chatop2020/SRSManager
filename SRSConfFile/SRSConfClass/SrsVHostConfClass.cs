using System;
using System.Collections.Generic;

namespace SRSConfFile.SRSConfClass
{
    [Serializable]
    public class Cluster : SrsConfBase
    {
        private string? _instanceName;
        private string? mode; //local or remote
        private string? origin; //use for mode remote
        private bool? token_traverse; //use for mode remote
        private string? vhost; //use for mode remote
        private bool? debug_srs_upnode; //use for mode remote
        private bool? origin_cluster; //
        private string? coworkers;

        public Cluster()
        {
            SectionsName = "cluster";
        }

        public string? Mode
        {
            get => mode;
            set => mode = value;
        }

        public string? Origin
        {
            get => origin;
            set => origin = value;
        }

        public bool? Token_traverse
        {
            get => token_traverse;
            set => token_traverse = value;
        }

        public string? Vhost
        {
            get => vhost;
            set => vhost = value;
        }

        public bool? Debug_srs_upnode
        {
            get => debug_srs_upnode;
            set => debug_srs_upnode = value;
        }

        public bool? Origin_cluster
        {
            get => origin_cluster;
            set => origin_cluster = value;
        }

        public string? Coworkers
        {
            get => coworkers;
            set => coworkers = value;
        }

        public string? InstanceName
        {
            get => _instanceName;
            set => _instanceName = value;
        }
    }

    [Serializable]
    public class Forward : SrsConfBase
    {
        private bool? enabled;
        private string? destination;

        public Forward()
        {
            SectionsName = "forward";
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public string? Destination
        {
            get => destination;
            set => destination = value;
        }
    }

    [Serializable]
    public enum PlayTimeJitter
    {
        full, // to ensure stream start at zero, and ensure stream monotonically increasing.
        zero, //only ensure stream start at zero, ignore timestamp jitter
        off //disable the time jitter algorithm, like atc.
    }

    [Serializable]
    public class Play : SrsConfBase
    {
        private bool? gop_cache;
        private byte? queue_length; //the max live queue length in seconds.
        private PlayTimeJitter? time_jitter;
        private bool? atc;
        private bool? mix_correct;
        private bool? atc_auto;

        /*
         *  # set the MW(merged-write) latency in ms.
        # @remark For WebRTC, we enable pass-timestamp mode, so we ignore this config.
        # default: 0 (For WebRTC)
         */
        private int? mw_latency; //merged-write delay in ms
        private float? send_min_interval;

        private bool? reduce_sequence_header;

        /*
         * # Set the MW(merged-write) min messages.
        # default: 0 (For Real-Time, min_latency on)
        # default: 1 (For WebRTC, min_latency off)
         */
        private ushort? mw_msgs;

        public Play()
        {
            SectionsName = "play";
        }

        public ushort? Mw_msgs
        {
            get => mw_msgs;
            set => mw_msgs = value;
        }

        public bool? Gop_cache
        {
            get => gop_cache;
            set => gop_cache = value;
        }

        public byte? Queue_length
        {
            get => queue_length;
            set => queue_length = value;
        }

        public PlayTimeJitter? Time_jitter
        {
            get => time_jitter;
            set => time_jitter = value;
        }

        public bool? Atc
        {
            get => atc;
            set => atc = value;
        }

        public bool? Mix_correct
        {
            get => mix_correct;
            set => mix_correct = value;
        }

        public bool? Atc_auto
        {
            get => atc_auto;
            set => atc_auto = value;
        }

        public int? Mw_latency
        {
            get => mw_latency;
            set => mw_latency = value;
        }

        public float? Send_min_interval
        {
            get => send_min_interval;
            set => send_min_interval = value;
        }

        public bool? Reduce_sequence_header
        {
            get => reduce_sequence_header;
            set => reduce_sequence_header = value;
        }
    }

    [Serializable]
    public class Publish : SrsConfBase
    {
        private string? _instanceName;
        private bool? mr;
        private int? mr_latency;
        private int? firstpkt_timeout;
        private int? normal_timeout;
        private bool? parse_sps;

        public Publish()
        {
            SectionsName = "publish";
        }

        public bool? Mr
        {
            get => mr;
            set => mr = value;
        }

        public int? Mr_latency
        {
            get => mr_latency;
            set => mr_latency = value;
        }

        public int? Firstpkt_timeout
        {
            get => firstpkt_timeout;
            set => firstpkt_timeout = value;
        }

        public int? Normal_timeout
        {
            get => normal_timeout;
            set => normal_timeout = value;
        }

        public bool? Parse_sps
        {
            get => parse_sps;
            set => parse_sps = value;
        }

        public string? InstanceName
        {
            get => _instanceName;
            set => _instanceName = value;
        }
    }

    [Serializable]
    public class Refer : SrsConfBase
    {
        private string? _instanceName;
        private bool? enabled;
        private string? all;
        private string? publish;
        private string? play;

        public Refer()
        {
            SectionsName = "refer";
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public string? All
        {
            get => all;
            set => all = value;
        }

        public string? Publish
        {
            get => publish;
            set => publish = value;
        }

        public string? Play
        {
            get => play;
            set => play = value;
        }

        public string? InstanceName
        {
            get => _instanceName;
            set => _instanceName = value;
        }
    }

    [Serializable]
    public class Bandcheck : SrsConfBase
    {
        private bool? enabled;
        private string? key;
        private ushort? interval;
        private int? limit_kbps;

        public Bandcheck()
        {
            SectionsName = "bandcheck";
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public string? Key
        {
            get => key;
            set => key = value;
        }

        public ushort? Interval
        {
            get => interval;
            set => interval = value;
        }

        public int? Limit_kbps
        {
            get => limit_kbps;
            set => limit_kbps = value;
        }
    }

    [Serializable]
    public enum SecurityMethod
    {
        allow,
        deny
    }

    [Serializable]
    public enum SecurityTarget
    {
        publish,
        play
    }

    [Serializable]
    public class SecurityObj
    {
        private SecurityMethod? sem;
        private SecurityTarget? set;
        private string? rule; //all or ipaddr

        public SecurityMethod? Sem
        {
            get => sem;
            set => sem = value;
        }

        public SecurityTarget? Set
        {
            get => set;
            set => set = value;
        }

        public string? Rule
        {
            get => rule;
            set => rule = value;
        }
    }

    [Serializable]
    public class Security : SrsConfBase
    {
        private bool? enabled;
        private List<SecurityObj>? seo;

        public Security()
        {
            SectionsName = "security";
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public List<SecurityObj>? Seo
        {
            get => seo;
            set => seo = value;
        }
    }

    [Serializable]
    public class HttpStatic : SrsConfBase
    {
        private bool? enabled;
        private string? mount;
        private string? dir;

        public HttpStatic()
        {
            SectionsName = "http_static";
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public string? Mount
        {
            get => mount;
            set => mount = value;
        }

        public string? Dir
        {
            get => dir;
            set => dir = value;
        }
    }

    [Serializable]
    public class HttpRemux : SrsConfBase
    {
        private bool? enabled;
        private ushort? fast_cache;
        private string? mount;
        private bool? hstrs;

        public HttpRemux()
        {
            SectionsName = "http_remux";
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public ushort? Fast_cache
        {
            get => fast_cache;
            set => fast_cache = value;
        }

        public string? Mount
        {
            get => mount;
            set => mount = value;
        }

        public bool? Hstrs
        {
            get => hstrs;
            set => hstrs = value;
        }
    }

    [Serializable]
    public class HttpHooks : SrsConfBase
    {
        private bool? enabled;
        private string? on_connect;
        private string? on_close;
        private string? on_publish;
        private string? on_unpublish;
        private string? on_play;
        private string? on_stop;
        private string? on_dvr;
        private string? on_hls;
        private string? on_hls_notify;

        public HttpHooks()
        {
            SectionsName = "http_hooks";
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public string? On_connect
        {
            get => on_connect;
            set => on_connect = value;
        }

        public string? On_close
        {
            get => on_close;
            set => on_close = value;
        }

        public string? On_publish
        {
            get => on_publish;
            set => on_publish = value;
        }

        public string? On_unpublish
        {
            get => on_unpublish;
            set => on_unpublish = value;
        }

        public string? On_play
        {
            get => on_play;
            set => on_play = value;
        }

        public string? On_stop
        {
            get => on_stop;
            set => on_stop = value;
        }

        public string? On_dvr
        {
            get => on_dvr;
            set => on_dvr = value;
        }

        public string? On_hls
        {
            get => on_hls;
            set => on_hls = value;
        }

        public string? On_hls_notify
        {
            get => on_hls_notify;
            set => on_hls_notify = value;
        }
    }

    [Serializable]
    public class Exec : SrsConfBase
    {
        private bool? enabled;
        private string? publish;

        public Exec()
        {
            SectionsName = "exec";
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public string? Publish
        {
            get => publish;
            set => publish = value;
        }
    }

    [Serializable]
    public class Dash : SrsConfBase
    {
        private bool? enabled;
        private ushort? dash_fragment;
        private ushort? dash_update_period;
        private ushort? dash_timeshift;
        private string? dash_path;
        private string? dash_mpd_file;

        public Dash()
        {
            SectionsName = "dash";
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public ushort? Dash_fragment
        {
            get => dash_fragment;
            set => dash_fragment = value;
        }

        public ushort? Dash_update_period
        {
            get => dash_update_period;
            set => dash_update_period = value;
        }

        public ushort? Dash_timeshift
        {
            get => dash_timeshift;
            set => dash_timeshift = value;
        }

        public string? Dash_path
        {
            get => dash_path;
            set => dash_path = value;
        }

        public string? Dash_mpd_file
        {
            get => dash_mpd_file;
            set => dash_mpd_file = value;
        }
    }

    [Serializable]
    public class Hls : SrsConfBase
    {
        private bool? enabled;
        private ushort? hls_fragment;
        private float? hls_td_ratio;
        private float? hls_aof_ratio;
        private ushort? hls_window;
        private string? hls_on_error;
        private string? hls_path;
        private string? hls_m3u8_file;
        private string? hls_ts_file;
        private bool? hls_ts_floor;
        private string? hls_entry_prefix;
        private string? hls_acodec;
        private string? hls_vcodec;
        private bool? hls_cleanup;
        private int? hls_dispose;
        private int? hls_nb_notify;
        private bool? hls_wait_keyframe;
        private bool? hls_keys;
        private int? hls_fragments_per_key;
        private string? hls_key_file;
        private string? hls_key_file_path;
        private string? hls_key_url;
        private bool? hls_dts_directly;

        public Hls()
        {
            SectionsName = "hls";
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public ushort? Hls_fragment
        {
            get => hls_fragment;
            set => hls_fragment = value;
        }

        public float? Hls_td_ratio
        {
            get => hls_td_ratio;
            set => hls_td_ratio = value;
        }

        public float? Hls_aof_ratio
        {
            get => hls_aof_ratio;
            set => hls_aof_ratio = value;
        }

        public ushort? Hls_window
        {
            get => hls_window;
            set => hls_window = value;
        }

        public string? Hls_on_error
        {
            get => hls_on_error;
            set => hls_on_error = value;
        }

        public string? Hls_path
        {
            get => hls_path;
            set => hls_path = value;
        }

        public string? Hls_m3u8_file
        {
            get => hls_m3u8_file;
            set => hls_m3u8_file = value;
        }

        public string? Hls_ts_file
        {
            get => hls_ts_file;
            set => hls_ts_file = value;
        }

        public bool? Hls_ts_floor
        {
            get => hls_ts_floor;
            set => hls_ts_floor = value;
        }

        public string? Hls_entry_prefix
        {
            get => hls_entry_prefix;
            set => hls_entry_prefix = value;
        }

        public string? Hls_acodec
        {
            get => hls_acodec;
            set => hls_acodec = value;
        }

        public string? Hls_vcodec
        {
            get => hls_vcodec;
            set => hls_vcodec = value;
        }

        public bool? Hls_cleanup
        {
            get => hls_cleanup;
            set => hls_cleanup = value;
        }

        public int? Hls_dispose
        {
            get => hls_dispose;
            set => hls_dispose = value;
        }

        public int? Hls_nb_notify
        {
            get => hls_nb_notify;
            set => hls_nb_notify = value;
        }

        public bool? Hls_wait_keyframe
        {
            get => hls_wait_keyframe;
            set => hls_wait_keyframe = value;
        }

        public bool? Hls_keys
        {
            get => hls_keys;
            set => hls_keys = value;
        }

        public int? Hls_fragments_per_key
        {
            get => hls_fragments_per_key;
            set => hls_fragments_per_key = value;
        }

        public string? Hls_key_file
        {
            get => hls_key_file;
            set => hls_key_file = value;
        }

        public string? Hls_key_file_path
        {
            get => hls_key_file_path;
            set => hls_key_file_path = value;
        }

        public string? Hls_key_url
        {
            get => hls_key_url;
            set => hls_key_url = value;
        }

        public bool? Hls_dts_directly
        {
            get => hls_dts_directly;
            set => hls_dts_directly = value;
        }
    }

    [Serializable]
    public class Hds : SrsConfBase
    {
        private bool? enabled;
        private int? hds_fragment;
        private int? hds_window;
        private string? hds_path;

        public Hds()
        {
            SectionsName = "hds";
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public int? Hds_fragment
        {
            get => hds_fragment;
            set => hds_fragment = value;
        }

        public int? Hds_window
        {
            get => hds_window;
            set => hds_window = value;
        }

        public string? Hds_path
        {
            get => hds_path;
            set => hds_path = value;
        }
    }

    [Serializable]
    public class Dvr : SrsConfBase
    {
        private bool? enabled;
        private string? dvr_apply;
        private string? dvr_plan;
        private string? dvr_path;
        private ushort? dvr_duration;
        private bool? dvr_wait_keyframe;
        private PlayTimeJitter? time_Jitter;

        public Dvr()
        {
            SectionsName = "dvr";
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public string? Dvr_apply
        {
            get => dvr_apply;
            set => dvr_apply = value;
        }

        public string? Dvr_plan
        {
            get => dvr_plan;
            set => dvr_plan = value;
        }

        public string? Dvr_path
        {
            get => dvr_path;
            set => dvr_path = value;
        }

        public ushort? Dvr_duration
        {
            get => dvr_duration;
            set => dvr_duration = value;
        }

        public bool? Dvr_wait_keyframe
        {
            get => dvr_wait_keyframe;
            set => dvr_wait_keyframe = value;
        }

        public PlayTimeJitter? Time_Jitter
        {
            get => time_Jitter;
            set => time_Jitter = value;
        }
    }

    [Serializable]
    public class Ingest : SrsConfBase
    {
        private string? _instanceName;
        private string? _ingestName;
        private bool? enabled;
        private IngestInput? input;
        private string? ffmpeg; //ffmpeg bin path
        private List<IngestTranscodeEngine>? engines;

        public Ingest()
        {
            SectionsName = "ingest";
        }

        public string? IngestName
        {
            get => _ingestName;
            set
            {
                _ingestName = value;
                _instanceName = value;
            }
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public IngestInput? Input
        {
            get => input;
            set => input = value;
        }

        public string? Ffmpeg
        {
            get => ffmpeg;
            set => ffmpeg = value;
        }

        public List<IngestTranscodeEngine>? Engines
        {
            get => engines;
            set => engines = value;
        }

        public string? InstanceName
        {
            get => _instanceName;
            set
            {
                _instanceName = value;
                _ingestName = value;
            }
        }
    }

    [Serializable]
    public enum IngestInputType
    {
        file,
        stream,
        device //not support yet
    }

    [Serializable]
    public class IngestInput : SrsConfBase
    {
        private IngestInputType? type;
        private string? url;

        public IngestInput()
        {
            SectionsName = "input";
        }

        public IngestInputType? Type
        {
            get => type;
            set => type = value;
        }

        public string? Url
        {
            get => url;
            set => url = value;
        }
    }

    [Serializable]
    public enum IngestEngineIoformat
    {
        off, //do not set the format,ffmpeg will be guess it

        flv //for flv or RTMP Stream
        //and other format,for example,mp4/acc so on
    }

    [Serializable]
    public enum IngestEngineVprofile
    {
        high,
        main,
        baseline
    }

    [Serializable]
    public enum IngestEngineVpreset
    {
        medium,
        slow,
        slower,
        veryslow,
        placebo,
        superfast,
        fast
    }

    [Serializable]
    public class IngestTranscodeEngine : SrsConfBase
    {
        private string? _instanceName;
        private bool? enabled;
        private string? _engineName;
        private IngestEnginePerfile? perfile;
        private IngestEngineIoformat? iformat;
        private IngestEngineVfilter? vfilter;
        private string? vcodec;
        private int? vbitrate;
        private int? vfps;
        private int? vwidth;
        private int? vheight;
        private int? vthreads;
        private IngestEngineVprofile? vprofile;
        private IngestEngineVpreset? vpreset;
        private IngestEngineVparams? vparams;
        private string? acodec;
        private int? abitrate;
        private int? asample_rate;
        private int? achannels;
        private IngestEngineAparams? aparams;
        private IngestEngineIoformat? oformat;
        private string? output;

        public IngestTranscodeEngine()
        {
            SectionsName = "engine";
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public IngestEnginePerfile? Perfile
        {
            get => perfile;
            set => perfile = value;
        }

        public IngestEngineIoformat? Iformat
        {
            get => iformat;
            set => iformat = value;
        }

        public IngestEngineVfilter? Vfilter
        {
            get => vfilter;
            set => vfilter = value;
        }

        public string? Vcodec
        {
            get => vcodec;
            set => vcodec = value;
        }

        public int? Vbitrate
        {
            get => vbitrate;
            set => vbitrate = value;
        }

        public int? Vfps
        {
            get => vfps;
            set => vfps = value;
        }

        public int? Vwidth
        {
            get => vwidth;
            set => vwidth = value;
        }

        public int? Vheight
        {
            get => vheight;
            set => vheight = value;
        }

        public int? Vthreads
        {
            get => vthreads;
            set => vthreads = value;
        }

        public IngestEngineVprofile? Vprofile
        {
            get => vprofile;
            set => vprofile = value;
        }

        public IngestEngineVpreset? Vpreset
        {
            get => vpreset;
            set => vpreset = value;
        }

        public IngestEngineVparams? Vparams
        {
            get => vparams;
            set => vparams = value;
        }

        public string? Acodec
        {
            get => acodec;
            set => acodec = value;
        }

        public int? Abitrate
        {
            get => abitrate;
            set => abitrate = value;
        }

        public int? Asample_rate
        {
            get => asample_rate;
            set => asample_rate = value;
        }

        public int? Achannels
        {
            get => achannels;
            set => achannels = value;
        }

        public IngestEngineAparams? Aparams
        {
            get => aparams;
            set => aparams = value;
        }

        public IngestEngineIoformat? Oformat
        {
            get => oformat;
            set => oformat = value;
        }

        public string? Output
        {
            get => output;
            set => output = value;
        }

        public string? EngineName
        {
            get => _engineName;
            set
            {
                _instanceName = value;
                _engineName = value;
            }
        }

        public string? InstanceName
        {
            get => _instanceName;
            set
            {
                _instanceName = value;
                _engineName = value;
            }
        }
    }

    [Serializable]
    public class IngestEnginePerfile : SrsConfBase
    {
        private string? re; //unknow,,conf show perfile{re;}
        private string? rtsp_transport;

        public IngestEnginePerfile()
        {
            SectionsName = "perfile";
        }

        public string? Re
        {
            get => re;
            set => re = value;
        }

        public string? Rtsp_transport
        {
            get => rtsp_transport;
            set => rtsp_transport = value;
        }
    }

    [Serializable]
    public class IngestEngineVfilter : SrsConfBase
    {
        public IngestEngineVfilter()
        {
            SectionsName = "vfilter";
        }

        public string? I
        {
            get => i;
            set => i = value;
        }

        public string? Vf
        {
            get => vf;
            set => vf = value;
        }

        public string? Filter_Complex
        {
            get => filter_complex;
            set => filter_complex = value;
        }

        private string? i; //logo path with jpg/png...
        private string? vf;
        private string? filter_complex;
    }

    [Serializable]
    public class IngestEngineVparams : SrsConfBase
    {
        private int? t;
        private int? coder;
        private int? b_strategy;
        private int? bf;
        private int? refs;

        public IngestEngineVparams()
        {
            SectionsName = "vparams";
        }

        public int? T
        {
            get => t;
            set => t = value;
        }

        public int? Coder
        {
            get => coder;
            set => coder = value;
        }

        public int? B_strategy
        {
            get => b_strategy;
            set => b_strategy = value;
        }

        public int? Bf
        {
            get => bf;
            set => bf = value;
        }

        public int? Refs
        {
            get => refs;
            set => refs = value;
        }
    }

    [Serializable]
    public class IngestEngineAparams : SrsConfBase
    {
        private string? profile_a;
        private string? bsf_a;

        public IngestEngineAparams()
        {
            SectionsName = "aparams";
        }

        public string? Profile_a
        {
            get => profile_a;
            set => profile_a = value;
        }

        public string? Bsf_a
        {
            get => bsf_a;
            set => bsf_a = value;
        }
    }


    [Serializable]
    public class Transcode : SrsConfBase
    {
        private string? _instanceName;
        private bool? enabled;
        private string? ffmpeg; //ffmpeg bin path
        private List<IngestTranscodeEngine>? _engines;

        public Transcode()
        {
            SectionsName = "transcode";
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public string? Ffmpeg
        {
            get => ffmpeg;
            set => ffmpeg = value;
        }

        public List<IngestTranscodeEngine>? Engines
        {
            get => _engines;
            set => _engines = value;
        }

        public string? InstanceName
        {
            get => _instanceName;
            set => _instanceName = value;
        }
    }


    [Serializable]
    public class Rtc : SrsConfBase
    {
        private bool? enabled;
        private string? bframe;
        private string? acc;
        private ushort? stun_timeout;
        private bool? stun_strict_check;

        public Rtc()
        {
            SectionsName = "rtc";
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public string? Bframe
        {
            get => bframe;
            set => bframe = value;
        }

        public string? Acc
        {
            get => acc;
            set => acc = value;
        }

        public ushort? Stun_timeout
        {
            get => stun_timeout;
            set => stun_timeout = value;
        }

        public bool? Stun_strict_check
        {
            get => stun_strict_check;
            set => stun_strict_check = value;
        }
    }


    [Serializable]
    public class SrsvHostConfClass : SrsConfBase
    {
        private string? _instanceName;
        private string? _vhostDomain;
        private bool? enabled;
        private bool? min_latency; //for min delay mode
        private bool? tcp_nodelay; //for system socket min delay mode
        private ushort? chunk_size; //128-65536 vhost chunk size will override the global value
        private int? in_ack_size;
        private int? out_ack_size;
        private Rtc? rtc;
        private Cluster? vcluster;
        private Forward? vforward;
        private Play? vplay;
        private Publish? vpublish;
        private Refer? vrefer;
        private Bandcheck? vbandcheck;
        private Security? vsecurity;
        private HttpStatic? vhttp_static;
        private HttpRemux? vhttp_remux;
        private HttpHooks? vhttp_hooks;
        private Exec? vexec;
        private Dash? vdash;
        private Hls? vhls;
        private Hds? vhds;
        private Dvr? vdvr;
        private List<Ingest>? _vingests;
        private List<Transcode>? _vtranscodeses;


        public SrsvHostConfClass()
        {
            SectionsName = "vhost";
        }


        public string? InstanceName
        {
            get => _instanceName;
            set
            {
                _instanceName = value;
                _vhostDomain = value;
            }
        }

        public string? VhostDomain
        {
            get => _vhostDomain;
            set
            {
                _vhostDomain = value;
                _instanceName = value;
            }
        }

        public bool? Enabled
        {
            get => enabled;
            set => enabled = value;
        }

        public bool? Min_latency
        {
            get => min_latency;
            set => min_latency = value;
        }

        public bool? Tcp_nodelay
        {
            get => tcp_nodelay;
            set => tcp_nodelay = value;
        }

        public ushort? Chunk_size
        {
            get => chunk_size;
            set => chunk_size = value;
        }

        public int? In_ack_size
        {
            get => in_ack_size;
            set => in_ack_size = value;
        }

        public int? Out_ack_size
        {
            get => out_ack_size;
            set => out_ack_size = value;
        }

        public Rtc? Rtc
        {
            get => rtc;
            set => rtc = value;
        }

        public Cluster? Vcluster
        {
            get => vcluster;
            set => vcluster = value;
        }

        public Forward? Vforward
        {
            get => vforward;
            set => vforward = value;
        }

        public Play? Vplay
        {
            get => vplay;
            set => vplay = value;
        }

        public Publish? Vpublish
        {
            get => vpublish;
            set => vpublish = value;
        }

        public Refer? Vrefer
        {
            get => vrefer;
            set => vrefer = value;
        }

        public Bandcheck? Vbandcheck
        {
            get => vbandcheck;
            set => vbandcheck = value;
        }

        public Security? Vsecurity
        {
            get => vsecurity;
            set => vsecurity = value;
        }

        public HttpStatic? Vhttp_static
        {
            get => vhttp_static;
            set => vhttp_static = value;
        }

        public HttpRemux? Vhttp_remux
        {
            get => vhttp_remux;
            set => vhttp_remux = value;
        }

        public HttpHooks? Vhttp_hooks
        {
            get => vhttp_hooks;
            set => vhttp_hooks = value;
        }

        public Exec? Vexec
        {
            get => vexec;
            set => vexec = value;
        }

        public Dash? Vdash
        {
            get => vdash;
            set => vdash = value;
        }

        public Hls? Vhls
        {
            get => vhls;
            set => vhls = value;
        }

        public Hds? Vhds
        {
            get => vhds;
            set => vhds = value;
        }

        public Dvr? Vdvr
        {
            get => vdvr;
            set => vdvr = value;
        }

        public List<Ingest>? Vingests
        {
            get => _vingests;
            set => _vingests = value;
        }

        public List<Transcode>? Vtranscodes
        {
            get => _vtranscodeses;
            set => _vtranscodeses = value;
        }
    }
}