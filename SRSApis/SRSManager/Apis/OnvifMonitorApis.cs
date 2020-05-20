using System.Collections.Generic;
using System.Linq;
using Mictlanix.DotNet.Onvif.Common;
using OnvifManager;
using SRSApis.SRSManager.Apis.ApiModules;
using PtzMoveDir = SRSApis.SRSManager.Apis.ApiModules.PtzMoveDir;

namespace SRSApis.SRSManager.Apis
{
    public static class OnvifMonitorApis
    {
        /// <summary>
        /// 获取ptz坐标
        /// </summary>
        /// <param name="instanceIpaddr"></param>
        /// <param name="profileToken"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static ResponsePosition GetPtzPosition(string instanceIpaddr, string profileToken, out ResponseStruct rs)
        {
            if (Common.OnvifManagers == null || Common.OnvifManagers.Count <= 0)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.OnvifMonitorNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.OnvifMonitorNotInit],
                };
                return null!;
            }

            var onvif = Common.OnvifManagers.FindLast(x => x.Host.Trim().Equals(instanceIpaddr.Trim()));
            if (onvif == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return null!;
            }

            if (onvif.OnvifProfileList == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return null!;
            }

            OnvifProfile pf = onvif.OnvifProfileList.FindLast(x =>
                x.ProfileToken.Trim().ToUpper().Equals(profileToken.Trim().ToUpper()));

            if (pf == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return null!;
            }

            ResponsePosition pos = onvif.GetPtzPositionStatus(pf.ProfileToken);
            if(pos!=null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None] + "\r\n" + JsonHelper.ToJson(pos),
                };
                return pos!;
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.Other,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.Other],
                };
                return null!;
            }
        }
        /// <summary>
        /// 停止持续移动
        /// </summary>
        /// <param name="instanceIpaddr"></param>
        /// <param name="profileToken"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool PtzKeepMoveStop(string instanceIpaddr, string profileToken, out ResponseStruct rs)
        {
            if (Common.OnvifManagers == null || Common.OnvifManagers.Count <= 0)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.OnvifMonitorNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.OnvifMonitorNotInit],
                };
                return false!;
            }

            var onvif = Common.OnvifManagers.FindLast(x => x.Host.Trim().Equals(instanceIpaddr.Trim()));
            if (onvif == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return false!;
            }

            if (onvif.OnvifProfileList == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return false!;
            }

            OnvifProfile pf = onvif.OnvifProfileList.FindLast(x =>
                x.ProfileToken.Trim().ToUpper().Equals(profileToken.Trim().ToUpper()));

            if (pf == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return false!;
            }

            ResponsePosition pos;
            if (onvif.PtzMoveKeepStop(pf.ProfileToken, out pos))
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None] + "\r\n" + JsonHelper.ToJson(pos),
                };
                return true!;
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.OnvifPtzMoveExcept,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.OnvifPtzMoveExcept],
                };
                return false!;
            }
        }

        /// <summary>
        /// ptz移动控制
        /// </summary>
        /// <param name="instanceIpaddr"></param>
        /// <param name="profileToken"></param>
        /// <param name="moveType"></param>
        /// <param name="moveDir"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static ResponsePosition PtzMove(string instanceIpaddr, string profileToken, PtzMoveType moveType,
            OnvifManager.PtzMoveDir moveDir, out ResponseStruct rs)
        {
            if (Common.OnvifManagers == null || Common.OnvifManagers.Count <= 0)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.OnvifMonitorNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.OnvifMonitorNotInit],
                };
                return null!;
            }

            var onvif = Common.OnvifManagers.FindLast(x => x.Host.Trim().Equals(instanceIpaddr.Trim()));
            if (onvif == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return null!;
            }

            if (onvif.OnvifProfileList == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return null!;
            }

            OnvifProfile pf = onvif.OnvifProfileList.FindLast(x =>
                x.ProfileToken.Trim().ToUpper().Equals(profileToken.Trim().ToUpper()));

            if (pf == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return null!;
            }

            ResponsePosition ppos = new ResponsePosition();
            ppos.X = 0f;
            ppos.Y = 0f;
            ppos.Z = 0f;
            switch (moveType)
            {
                case PtzMoveType.KEEP:
                    switch (moveDir)
                    {
                        case OnvifManager.PtzMoveDir.UP:
                            ppos.X = 0f;
                            ppos.Y = -0.05f;
                            break;
                        case OnvifManager.PtzMoveDir.DOWN:
                            ppos.X = 0f;
                            ppos.Y = 0.05f;
                            break;
                        case OnvifManager.PtzMoveDir.LEFT:
                            ppos.X = -0.05f;
                            ppos.Y = 0f;
                            break;
                        case OnvifManager.PtzMoveDir.RIGHT:
                            ppos.X = 0.05f;
                            ppos.Y = 0f;
                            break;
                        default:
                            rs = new ResponseStruct()
                            {
                                Code = ErrorNumber.OnvifPtzKeepMoveOnlyUPDOWNLEFTRIGHT,
                                Message = ErrorMessage.ErrorDic![ErrorNumber.OnvifPtzKeepMoveOnlyUPDOWNLEFTRIGHT],
                            };
                            return null!;
                    }

                    ResponsePosition pos;
                    if (onvif.PtzMoveKeep(pf.ProfileToken, ppos, out pos))
                    {
                        rs = new ResponseStruct()
                        {
                            Code = ErrorNumber.None,
                            Message = ErrorMessage.ErrorDic![ErrorNumber.None] + "\r\n" + JsonHelper.ToJson(pos),
                        };
                        return pos!;
                    }
                    else
                    {
                        rs = new ResponseStruct()
                        {
                            Code = ErrorNumber.OnvifPtzMoveExcept,
                            Message = ErrorMessage.ErrorDic![ErrorNumber.OnvifPtzMoveExcept],
                        };
                        return null!;
                    }

                case PtzMoveType.RELATIVE:

                    if (onvif.PtzMove(pf.ProfileToken, (OnvifManager.PtzMoveDir) moveDir, out pos))
                    {
                        rs = new ResponseStruct()
                        {
                            Code = ErrorNumber.None,
                            Message = ErrorMessage.ErrorDic![ErrorNumber.None] + "\r\n" + JsonHelper.ToJson(pos),
                        };
                        return pos!;
                    }
                    else
                    {
                        rs = new ResponseStruct()
                        {
                            Code = ErrorNumber.OnvifPtzMoveExcept,
                            Message = ErrorMessage.ErrorDic![ErrorNumber.OnvifPtzMoveExcept],
                        };
                        return null!;
                    }
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.Other,
                Message = ErrorMessage.ErrorDic![ErrorNumber.Other],
            };
            return null!;
        }

        /// <summary>
        /// 利用ip地址/实例名称获取onvif设备实例
        /// </summary>
        /// <param name="instanceIpaddr"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static OnvifMonitor GetOnvifMonitor(string instanceIpaddr, out ResponseStruct rs)
        {
            if (Common.OnvifManagers == null || Common.OnvifManagers.Count <= 0)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.OnvifMonitorNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.OnvifMonitorNotInit],
                };
                return null!;
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            return Common.OnvifManagers.FindLast(x => x.Host.Trim().Equals(instanceIpaddr.Trim()))!;
        }

        /// <summary>
        /// 获取所有onvif摄像头的ip地址/实例名称
        /// </summary>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static List<string> GetOnvifMonitorsIpAddress(out ResponseStruct rs)
        {
            if (Common.OnvifManagers == null || Common.OnvifManagers.Count <= 0)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.OnvifMonitorNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.OnvifMonitorNotInit],
                };
                return null!;
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            return Common.OnvifManagers.Select(x => x.Host).ToList();
        }

        /// <summary>
        /// 初始化onvif设备列表
        /// </summary>
        /// <param name="onvif"></param>
        /// <param name="rs"></param>
        /// <param name="autoAdd"></param>
        /// <returns></returns>
        public static List<string> InitMonitors(DiscoveryOnvifMonitors onvif, out ResponseStruct rs,
            bool autoAdd = true)
        {
            if (autoAdd && Common.OnvifManagers == null)
            {
                Common.OnvifManagers = new List<OnvifMonitor>();
            }

            if (onvif != null)
            {
                onvif.GetIpArray();
                if (onvif.IpAddrArray == null || onvif.IpAddrArray.Count <= 0)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.FunctionInputParamsError,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                    };
                    return null!;
                }

                foreach (var ip in onvif.IpAddrArray)
                {
                    if (Common.OnvifManagers.FindLast(x => x.Host.Trim().Equals(ip.Trim())) != null) continue;

                    OnvifMonitor ovf = discoveryMonitor(ip, onvif.Username!, onvif.Password!, out rs);
                    try
                    {
                        ovf.InitMonitor().Wait();
                    }
                    catch
                    {
                        continue;
                    }

                    if (ovf != null && autoAdd)
                    {
                        Common.OnvifManagers.Add(ovf);
                    }
                }

                if (Common.OnvifManagers != null && Common.OnvifManagers.Count > 0)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.None,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                    };
                    return Common.OnvifManagers.Select(x => x.Host).ToList();
                }
                else
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.OnvifMonitorNotInit,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.OnvifMonitorNotInit],
                    };
                    return null!;
                }
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return null!;
            }
        }

        private static OnvifMonitor discoveryMonitor(string host, string username, string password,
            out ResponseStruct rs)
        {
            try
            {
                OnvifMonitor onvif = new OnvifMonitor(host, username, password);
                if (onvif != null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.None,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                    };
                    return onvif;
                }
            }
            catch
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.OnvifMonitorNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.OnvifMonitorNotInit],
                };
                return null!;
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.Other,
                Message = ErrorMessage.ErrorDic![ErrorNumber.Other],
            };
            return null!;
        }
    }
}