using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mictlanix.DotNet.Onvif;
using Mictlanix.DotNet.Onvif.Common;
using Mictlanix.DotNet.Onvif.Device;
using Mictlanix.DotNet.Onvif.Media;
using Mictlanix.DotNet.Onvif.Ptz;

namespace SRSManageCommon.ManageStructs
{
    [Serializable]
    public class OnvifMonitor
    {
        private DeviceClient _device = null!;
        private string _host;
        private bool _isInited = false;
        private MediaClient _media = null!;
        private List<MediaSourceInfo> _mediaSourceInfoList = null!;
        private List<OnvifProfile> _onvifProfileList = null!;
        private string _password;
        private PTZClient _ptz = null!;
        private string _username;

        /// <summary>
        /// 构造函数，初始化对象以外同时做监视器检测
        /// </summary>
        /// <param name="host"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <exception cref="Exception"></exception>
        public OnvifMonitor(string host, string username, string password)
        {
            this._host = host;
            this._username = username;
            this._password = password;
            if (!CheckOnvifMonitor().Result)
            {
                throw new Exception("此host非onvif设备");
            }
        }

        public List<MediaSourceInfo> MediaSourceInfoList
        {
            get => _mediaSourceInfoList;
            set => _mediaSourceInfoList = value;
        }

        public List<OnvifProfile> OnvifProfileList
        {
            get => _onvifProfileList;
            set => _onvifProfileList = value;
        }

        public string Host
        {
            get => _host;
            set => _host = value;
        }

        public string Username
        {
            get => _username;
            set => _username = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public DeviceClient Device
        {
            get => _device;
            set => _device = value;
        }

        public MediaClient Media
        {
            get => _media;
            set => _media = value;
        }

        public PTZClient Ptz
        {
            get => _ptz;
            set => _ptz = value;
        }


        public bool IsInited
        {
            get => _isInited;
            set => _isInited = value;
        }

        /// <summary>
        /// 检测ip是否为onvif设备
        /// </summary>
        /// <returns></returns>
#pragma warning disable 1998
        public async Task<bool> CheckOnvifMonitor()
#pragma warning restore 1998
        {
            DeviceClient tmp = null!;
            try
            {
                tmp = OnvifClientFactory.CreateDeviceClientAsync(this.Host, this.Username, this.Password).Result;
            }
            catch
            {
                return false;
            }

            if (tmp == null) return false;
            return true;
        }

        /// <summary>
        /// 获取监视器的媒体属性
        /// </summary>
        /// <returns></returns>
        public async Task<bool> GetMediaInfo()
        {
            GetVideoSourcesResponse video_sources = await Media.GetVideoSourcesAsync();
            if (video_sources != null)
            {
                MediaSourceInfoList = new List<MediaSourceInfo>();
                foreach (VideoSource vs in video_sources.VideoSources)
                {
                    MediaSourceInfoList.Add(new MediaSourceInfo()
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

        /// <summary>
        /// 获取每个profile的rtspurl
        /// </summary>
        /// <param name="p">Profile</param>
        /// <returns></returns>
        private async Task<string> getMediaUrl(Profile p)
        {
            StreamSetup streamSetup = new StreamSetup()
            {
                Stream = StreamType.RTPUnicast,
                Transport = new Transport {Protocol = TransportProtocol.UDP}
            };
            MediaUri mediaUrl = null!;
            try
            {
                mediaUrl = await _media.GetStreamUriAsync(streamSetup, p.token);
            }
            catch
            {
                return null!;
            }

            if (mediaUrl == null) return null!;
            return mediaUrl.Uri;
        }

        /// <summary>
        /// 获取profileTonkenList
        /// </summary>
        /// <returns></returns>
        public List<string> GetProfileTokenList()
        {
            List<string> result = null!;
            if (OnvifProfileList != null)
            {
                result = new List<string>();
                foreach (var l in OnvifProfileList)
                {
                    result.Add(l.ProfileToken!);
                }
            }

            return result!;
        }

        /// <summary>
        /// 修改摄像头缩放
        /// </summary>
        /// <param name="profileToken"></param>
        /// <param name="zoomDir">大于等于0为正向调整，小于0为反向调整</param>
        /// <param name="zoom"> 返回当前zoom大小</param>
        /// <returns></returns>
        public bool PtzZoom(string profileToken, int zoomDir, out float zoom)
        {
            try
            {
                OnvifProfile p = OnvifProfileList.FindLast(x =>
                    x.ProfileToken!.Trim().ToUpper().Equals(profileToken.Trim().ToUpper()))!;
                if (p != null && p.PtzMoveSupport && p.RelativeMove)
                {
                    float zz = 0;
                    if (zoomDir >= 0)
                    {
                        zz = 0.05f;
                    }
                    else
                    {
                        zz = -0.05f;
                    }

                    Ptz.RelativeMoveAsync(profileToken, new PTZVector
                    {
                        PanTilt = new Vector2D
                        {
                            x = 0f,
                            y = 0f
                        },
                        Zoom = new Vector1D
                        {
                            x = zz,
                        }
                    }, new PTZSpeed
                    {
                        PanTilt = new Vector2D
                        {
                            x = 1,
                            y = 1
                        },
                        Zoom = new Vector1D
                        {
                            x = 1
                        }
                    }).Wait();
                    var ptzStatus = _ptz.GetStatusAsync(profileToken).Result;
                    zoom = ptzStatus.Position.Zoom.x;
                    return true;
                }

                zoom = -99999;
                return false;
            }
            catch
            {
                zoom = -99999;
                return false;
            }
        }

        /// <summary>
        /// 停止持续移动
        /// </summary>
        /// <param name="profileToken"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool PtzMoveKeepStop(string profileToken, out ResponsePosition pos)
        {
            try
            {
                _ptz.StopAsync(profileToken, true, true);
                var ptz_status = _ptz.GetStatusAsync(profileToken).Result;
                pos = new ResponsePosition()
                {
                    X = ptz_status.Position.PanTilt.x,
                    Y = ptz_status.Position.PanTilt.y,
                    Z = ptz_status.Position.Zoom.x,
                };
                return true;
            }
            catch
            {
                pos = null!;
                return false;
            }
        }

        /// <summary>
        /// 开始持续移动
        /// </summary>
        /// <param name="profileToken"></param>
        /// <param name="ppos"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool PtzMoveKeep(string profileToken, ResponsePosition ppos, out ResponsePosition pos)
        {
            try
            {
                pos = null!;
                OnvifProfile p = OnvifProfileList.FindLast(x =>
                    x.ProfileToken!.Trim().ToUpper().Equals(profileToken.Trim().ToUpper()))!;
                if (p != null && p.PtzMoveSupport && p.ContinuousMove)
                {
                    _ptz.ContinuousMoveAsync(profileToken, new PTZSpeed
                    {
                        PanTilt = new Vector2D
                        {
                            x = ppos.X,
                            y = ppos.Y
                        },
                        Zoom = new Vector1D
                        {
                            x = ppos.Z
                        }
                    }, null).Wait();

                    var ptz_status = _ptz.GetStatusAsync(profileToken).Result;
                    pos = new ResponsePosition()
                    {
                        X = ptz_status.Position.PanTilt.x,
                        Y = ptz_status.Position.PanTilt.y,
                        Z = ptz_status.Position.Zoom.x,
                    };
                    return true;
                }

                return false;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message + "\r\n" + exception.StackTrace);
                pos = null!;
                return false;
            }
        }

        /// <summary>
        /// 控制ptz移动
        /// </summary>
        /// <param name="profileToken"></param>
        /// <param name="ptzMoveDir"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool PtzMove(string profileToken, PtzMoveDir ptzMoveDir, out ResponsePosition pos)
        {
            try
            {
                pos = null!;
                OnvifProfile p = OnvifProfileList.FindLast(x =>
                    x.ProfileToken!.Trim().ToUpper().Equals(profileToken.Trim().ToUpper()))!;
                if (p != null && p.PtzMoveSupport && p.RelativeMove)
                {
                    float x = 0;
                    float y = 0;
                    float z = 0;
                    switch (ptzMoveDir)
                    {
                        case PtzMoveDir.UP:
                            x = 0f;
                            y = -0.05f;
                            z = 0f;
                            break;
                        case PtzMoveDir.DOWN:
                            x = 0f;
                            y = 0.05f;
                            z = 0f;
                            break;
                        case PtzMoveDir.LEFT:
                            x = -0.05f;
                            y = 0f;
                            z = 0f;
                            break;
                        case PtzMoveDir.RIGHT:
                            x = 0.05f;
                            y = 0f;
                            z = 0f;
                            break;
                        case PtzMoveDir.DOWNLEFT:
                            x = -0.05f;
                            y = 0.05f;
                            z = 0f;
                            break;
                        case PtzMoveDir.DOWNRIGHT:
                            x = 0.05f;
                            y = 0.05f;
                            z = 0f;
                            break;
                        case PtzMoveDir.UPLEFT:
                            x = -0.05f;
                            y = -0.05f;
                            z = 0f;
                            break;
                        case PtzMoveDir.UPRIGHT:
                            x = 0.05f;
                            y = -0.05f;
                            z = 0f;
                            break;
                    }

                    Ptz.RelativeMoveAsync(profileToken, new PTZVector
                    {
                        PanTilt = new Vector2D
                        {
                            x = x,
                            y = y
                        },
                        Zoom = new Vector1D
                        {
                            x = z
                        }
                    }, new PTZSpeed
                    {
                        PanTilt = new Vector2D
                        {
                            x = 1,
                            y = 1
                        },
                        Zoom = new Vector1D
                        {
                            x = 1
                        }
                    }).Wait();

                    var ptz_status = _ptz.GetStatusAsync(profileToken).Result;
                    pos = new ResponsePosition()
                    {
                        X = ptz_status.Position.PanTilt.x,
                        Y = ptz_status.Position.PanTilt.y,
                        Z = ptz_status.Position.Zoom.x,
                    };
                    return true;
                }

                return false;
            }
            catch
            {
                pos = null!;
                return false;
            }
        }

        /// <summary>
        /// 获取摄像头当前位置信息
        /// </summary>
        /// <param name="profileToken"></param>
        /// <returns></returns>
        public ResponsePosition GetPtzPositionStatus(string profileToken)
        {
            try
            {
                var ptz_status = _ptz.GetStatusAsync(profileToken).Result;
                ResponsePosition pos = new ResponsePosition()
                {
                    X = ptz_status.Position.PanTilt.x,
                    Y = ptz_status.Position.PanTilt.y,
                    Z = ptz_status.Position.Zoom.x,
                };
                return pos;
            }
            catch
            {
                return null!;
            }
        }

        /// <summary>
        /// 获取ptz支持情况
        /// </summary>
        /// <param name="p">Profile</param>
        /// <returns></returns>
        private bool getPtzMoveSupport(Profile p, out bool absoluteMove, out bool relativeMove, out bool continuousMove)
        {
            try
            {
                absoluteMove = !string.IsNullOrWhiteSpace(p.PTZConfiguration.DefaultAbsolutePantTiltPositionSpace);
                relativeMove = !string.IsNullOrWhiteSpace(p.PTZConfiguration.DefaultRelativePanTiltTranslationSpace);
                continuousMove = !string.IsNullOrWhiteSpace(p.PTZConfiguration.DefaultContinuousPanTiltVelocitySpace);
                if (absoluteMove || relativeMove || continuousMove) return true;
                return false;
            }
            catch
            {
                absoluteMove = false;
                relativeMove = false;
                continuousMove = false;
                return false;
            }
        }

        /// <summary>
        /// 初始化监视器
        /// </summary>
        /// <returns></returns>
#pragma warning disable 1998
        public async Task InitMonitor()
#pragma warning restore 1998
        {
            try
            {
                Device = OnvifClientFactory.CreateDeviceClientAsync(this.Host, this.Username, this.Password).Result;
                Media = OnvifClientFactory.CreateMediaClientAsync(this.Host, this.Username, this.Password).Result;
                try
                {
                    Ptz = OnvifClientFactory.CreatePTZClientAsync(this.Host, this.Username, this.Password).Result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Ptz = null!;
                }

                var profiles = Media.GetProfilesAsync().Result;
                if (profiles != null && profiles.Profiles != null && profiles.Profiles.Length > 0)
                {
                    if (OnvifProfileList == null) OnvifProfileList = new List<OnvifProfile>();
                    foreach (var profile in profiles.Profiles)
                    {
                        if (profile == null) continue;
                        OnvifProfile p = new OnvifProfile();
                        p.Profile = profile;
                        p.ProfileToken = profile.token;
                        OnvifProfileList.Add(p);
                    }
                }

                if (OnvifProfileList != null)
                {
                    for (int i = 0; i <= OnvifProfileList.Count - 1; i++)
                    {
                        if (OnvifProfileList[i] != null)
                        {
                            OnvifProfileList[i].MediaUrl = getMediaUrl(OnvifProfileList[i].Profile!).Result;
                            bool a;
                            bool b;
                            bool c;
                            if (Ptz != null)
                            {
                                OnvifProfileList[i].PtzMoveSupport = getPtzMoveSupport(OnvifProfileList[i].Profile!,
                                    out a,
                                    out b, out c);
                                OnvifProfileList[i].AbsoluteMove = a;
                                OnvifProfileList[i].RelativeMove = b;
                                OnvifProfileList[i].ContinuousMove = c;
                            }
                        }
                    }
                }

                if (GetMediaInfo().Result)
                {
                    //none to print
                }

                _isInited = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Device = null!;
                Media = null!;
                _ptz = null!;
                OnvifProfileList = null!;
            }
        }
    }
}