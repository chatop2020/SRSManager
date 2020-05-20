using System.Collections.Generic;
using System.Linq;
using Common;
using OnvifManager;
using SRSApis.SRSManager.Apis.ApiModules;
using PtzMoveDir = OnvifManager.PtzMoveDir;

namespace SRSApis.SRSManager.Apis
{
    
    
    public static class OnvifMonitorApis
    {
        /// <summary>
        /// 设置焦距
        /// </summary>
        /// <param name="instanceIpaddr"></param>
        /// <param name="profileToken"></param>
        /// <param name="zoomDir">大于0为放大，小于0为缩小</param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static float SetPtzZoom(string instanceIpaddr, string profileToken, int zoomDir, out ResponseStruct rs)
        {
            if (Common.OnvifManagers == null || Common.OnvifManagers.Count <= 0)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.OnvifMonitorNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.OnvifMonitorNotInit],
                };
                return -999999;
            }

            var onvif = Common.OnvifManagers.FindLast(x => x.IpAddr.Trim().Equals(instanceIpaddr.Trim()));
            if (onvif == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return -999999;
            }

            if (onvif.OnvifMonitor.OnvifProfileList == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return -999999;
            }

            OnvifProfile pf = onvif.OnvifMonitor.OnvifProfileList.FindLast(x =>
                x.ProfileToken.Trim().ToUpper().Equals(profileToken.Trim().ToUpper()))!;

            if (pf == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return -999999;
            }

            float result;
            if (onvif.OnvifMonitor.PtzZoom(profileToken, zoomDir, out result))
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                };
                return result!;
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.Other,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.Other],
                };
                return -999999;
            }
        }

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

            var onvif = Common.OnvifManagers.FindLast(x => x.IpAddr.Trim().Equals(instanceIpaddr.Trim()));
            if (onvif == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return null!;
            }

            if (onvif.OnvifMonitor.OnvifProfileList == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return null!;
            }

            OnvifProfile pf = onvif.OnvifMonitor.OnvifProfileList.FindLast(x =>
                x.ProfileToken.Trim().ToUpper().Equals(profileToken.Trim().ToUpper()))!;

            if (pf == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return null!;
            }

            ResponsePosition pos = onvif.OnvifMonitor.GetPtzPositionStatus(pf.ProfileToken);
            if (pos != null)
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

            var onvif = Common.OnvifManagers.FindLast(x => x.IpAddr.Trim().Equals(instanceIpaddr.Trim()));
            if (onvif == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return false!;
            }

            if (onvif.OnvifMonitor.OnvifProfileList == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return false!;
            }

            OnvifProfile pf = onvif.OnvifMonitor.OnvifProfileList.FindLast(x =>
                x.ProfileToken.Trim().ToUpper().Equals(profileToken.Trim().ToUpper()))!;

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
            if (onvif.OnvifMonitor.PtzMoveKeepStop(pf.ProfileToken, out pos))
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
            PtzMoveDir moveDir, out ResponseStruct rs)
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

            var onvif = Common.OnvifManagers.FindLast(x => x.IpAddr.Trim().Equals(instanceIpaddr.Trim()));
            if (onvif == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return null!;
            }

            if (onvif.OnvifMonitor.OnvifProfileList == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return null!;
            }

            OnvifProfile pf = onvif.OnvifMonitor.OnvifProfileList.FindLast(x =>
                x.ProfileToken.Trim().ToUpper().Equals(profileToken.Trim().ToUpper()))!;

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
                        case PtzMoveDir.UP:
                            ppos.X = 0f;
                            ppos.Y = -0.05f;
                            break;
                        case PtzMoveDir.DOWN:
                            ppos.X = 0f;
                            ppos.Y = 0.05f;
                            break;
                        case PtzMoveDir.LEFT:
                            ppos.X = -0.05f;
                            ppos.Y = 0f;
                            break;
                        case PtzMoveDir.RIGHT:
                            ppos.X = 0.05f;
                            ppos.Y = 0f;
                            break;
                        default:
                            rs = new ResponseStruct()
                            {
                                Code = ErrorNumber.OnvifPtzKeepMoveOnlyUpdownleftright,
                                Message = ErrorMessage.ErrorDic![ErrorNumber.OnvifPtzKeepMoveOnlyUpdownleftright],
                            };
                            return null!;
                    }

                    ResponsePosition pos;
                    if (onvif.OnvifMonitor.PtzMoveKeep(pf.ProfileToken, ppos, out pos))
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

                    if (onvif.OnvifMonitor.PtzMove(pf.ProfileToken, moveDir, out pos))
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
            return Common.OnvifManagers.FindLast(x => x.IpAddr.Trim().Equals(instanceIpaddr.Trim()))!.OnvifMonitor!;
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
            return Common.OnvifManagers.Select(x => x.IpAddr).ToList();
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
                Common.OnvifManagers = new List<OnvifInstance>();
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

                List<OnvifInstance> tmpList = new List<OnvifInstance>();

                foreach (var ip in onvif.IpAddrArray)
                {
                    if (Common.OnvifManagers.FindLast(x => x.IpAddr.Trim().Equals(ip.Trim())) != null) continue;

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
                        OnvifInstance oi = new OnvifInstance();
                        oi.Password = onvif.Password!;
                        oi.Username = onvif.Username!;
                        oi.IpAddr = onvif.IpAddrs;
                        oi.OnvifMonitor = ovf;
                        oi.ConfigPath = Common.WorkPath + "system.oconf";
                        Common.OnvifManagers.Add(oi);
                        tmpList.Add(oi);
                    }
                }

                if (autoAdd)
                {
                    if (Common.OnvifManagers != null && Common.OnvifManagers.Count > 0)
                    {
                        rs = new ResponseStruct()
                        {
                            Code = ErrorNumber.None,
                            Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                        };
                        return Common.OnvifManagers.Select(x => x.IpAddr).ToList();
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
                    if (tmpList != null && tmpList.Count > 0)
                    {
                        rs = new ResponseStruct()
                        {
                            Code = ErrorNumber.None,
                            Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                        };
                        return tmpList.Select(x => x.IpAddr).ToList();
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