using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mictlanix.DotNet.Onvif;
using Mictlanix.DotNet.Onvif.Common;
using Mictlanix.DotNet.Onvif.Device;
using Mictlanix.DotNet.Onvif.Media;
using Mictlanix.DotNet.Onvif.Ptz;

namespace Test_Onvif_Discovery
{
[Serializable]
    public class MediaSourceInfo
    {
        private string source_token;
        private float framerate;
        private int width;
        private int height;

        public string SourceToken
        {
            get => source_token;
            set => source_token = value;
        }

        public float Framerate
        {
            get => framerate;
            set => framerate = value;
        }

        public int Width
        {
            get => width;
            set => width = value;
        }

        public int Height
        {
            get => height;
            set => height = value;
        }

        public override string ToString()
        {
            return "VideoSourceToken:" + this.source_token + "\tVideoSourceFrameRate:"+this.framerate.ToString()+"\tVideoSourceResolution.Width:"+this.Width+"\tVideoSourceResolution.Height:"+this.Height;
        }
    }
    [Serializable]
    public class OnvifMonitor
    {
        private string host;
        private string username;
        private string password;
        private DeviceClient device;
        private MediaClient media;
        private PTZClient ptz;
        private GetProfilesResponse profiles;
        private List<string> streamUrls;
        private bool isInited=false;
        private List<MediaSourceInfo> mediaSourceInfos;

        public List<MediaSourceInfo> MediaSourceInfos
        {
            get => mediaSourceInfos;
            set => mediaSourceInfos = value;
        }

        public string Host
        {
            get => host;
            set => host = value;
        }

        public string Username
        {
            get => username;
            set => username = value;
        }

        public string Password
        {
            get => password;
            set => password = value;
        }

        public DeviceClient Device
        {
            get => device;
            set => device = value;
        }

        public MediaClient Media
        {
            get => media;
            set => media = value;
        }

        public PTZClient Ptz
        {
            get => ptz;
            set => ptz = value;
        }

        public List<string> StreamUrls
        {
            get => streamUrls;
            set => streamUrls = value;
        }

        public GetProfilesResponse Profiles
        {
            get => profiles;
            set => profiles = value;
        }

        public bool IsInited
        {
            get => isInited;
            set => isInited = value;
        }


        public async Task<bool> checkOnvifMonitor()
        {
            DeviceClient tmp = null;
            try
            {
                 tmp = await OnvifClientFactory.CreateDeviceClientAsync(this.Host, this.Username, this.Password);
            }
            catch
            {
                return false;
            }

            if (tmp == null) return false;
            return true;
        }
        public OnvifMonitor(string host, string username, string password)
        {
            this.host = host;
            this.username = username;
            this.password = password;
            if(StreamUrls==null) StreamUrls=new List<string>();
            if (!checkOnvifMonitor().Result)
            {
                throw new Exception("此host非onvif设置"); 
            }
            
        }

        public async Task<bool> GetMediaInfo()
        {
            GetVideoSourcesResponse video_sources = await Media.GetVideoSourcesAsync();
            if (video_sources != null)
            {
                mediaSourceInfos= new List<MediaSourceInfo>();
                foreach (VideoSource vs in video_sources.VideoSources)
                {
                    mediaSourceInfos.Add(new MediaSourceInfo()
                    {
                         Framerate = vs.Framerate,
                         Width = vs.Resolution.Width,
                         Height = vs.Resolution.Height,
                         SourceToken = vs.token,
                    });
                }

                return true;
            }

            return false;
        }

        public async Task InitMonitor()
        {
            try
            {
                Device = await OnvifClientFactory.CreateDeviceClientAsync(this.Host, this.Username, this.Password);
                Media = await OnvifClientFactory.CreateMediaClientAsync(this.Host, this.Username, this.Password);
                Ptz = await OnvifClientFactory.CreatePTZClientAsync(this.Host, this.Username, this.Password);
                StreamSetup streamSetup = new StreamSetup()
                {
                    Stream = StreamType.RTPUnicast,
                    Transport = new Transport {Protocol = TransportProtocol.UDP}
                };
                Profiles = await Media.GetProfilesAsync();
                if (profiles != null && profiles.Profiles != null && profiles.Profiles.Length > 0)
                {
                    foreach (var profile in profiles.Profiles)
                    {
                        if (profile == null) continue;
                        var mediaUrl = await media.GetStreamUriAsync(streamSetup, profile.token);
                        Console.WriteLine(profile.token);
                        if (mediaUrl == null) continue;
                        StreamUrls.Add(mediaUrl.Uri);
                    }
                }
            }
            catch
            {
                Device = null;
                Media = null;
                ptz = null;
                Profiles = null;
            }
        }
    }
}