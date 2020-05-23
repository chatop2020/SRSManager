using System.Collections.Generic;
using SRSApis.SRSManager.Apis.ApiModules;
using SRSConfFile.SRSConfClass;
using SRSManageCommon;

namespace SRSApis.SRSManager.Apis
{
    public static class VhostTranscodeApis
    {
        /// <summary>
        /// 创建Transcode
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="transcode"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool CreateVhostTranscode(SrsManager sm, string vhostDomain, Transcode transcode,
            out ResponseStruct rs)
        {
            if (sm == null || sm.Srs == null || sm.Srs.Vhosts == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsObjectNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                };
                return false;
            }

            SrsvHostConfClass vhost = VhostApis.GetVhostByDomain(sm, vhostDomain, out rs);
            if (vhost != null && rs.Code == ErrorNumber.None) //找到
            {
                if (vhost.Vtranscodes != null)
                {
                    Transcode trc = vhost.Vtranscodes!.FindLast(x =>
                        x.InstanceName!.Trim().ToLower() == transcode.InstanceName!.Trim().ToLower())!;
                    if (trc == null)
                    {
                        vhost.Vtranscodes.Add(transcode);
                        rs = new ResponseStruct()
                        {
                            Code = ErrorNumber.None,
                            Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                        };
                        return true;
                    }
                    else
                    {
                        rs = new ResponseStruct()
                        {
                            Code = ErrorNumber.SrsSubInstanceAlreadyExists,
                            Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceAlreadyExists],
                        };
                        return false;
                        //已经存在
                    }
                }
                else //Transcode is null
                {
                    vhost.Vtranscodes = new List<Transcode>();
                    vhost.Vtranscodes.Add(transcode);
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.None,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                    };
                    return true;
                }
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsSubInstanceNotFound,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound] + "\r\n" +
                              JsonHelper.ToJson(transcode),
                };
                return false;
            }
        }

        /// <summary>
        /// 设置transcode
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="vhostDomian"></param>
        /// <param name="transcodeInstanceName"></param>
        /// <param name="transcode"></param>
        /// <param name="rs"></param>
        /// <param name="createIfNotFound"></param>
        /// <returns></returns>
        public static bool SetVhostTranscode(SrsManager sm, string vhostDomian, string transcodeInstanceName,
            Transcode transcode,
            out ResponseStruct rs, bool createIfNotFound = false)
        {
            bool ret = false;
            if (sm == null || sm.Srs == null || sm.Srs.Vhosts == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsObjectNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                };
                return false;
            }

            if (transcode == null || string.IsNullOrEmpty(transcode.InstanceName))
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return false;
            }

            SrsvHostConfClass vhost = VhostApis.GetVhostByDomain(sm, vhostDomian, out rs);
            if (rs.Code != ErrorNumber.None || vhost == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return false;
            }

            bool found = false;
            int i = 0;
            int j = 0;
            for (i = 0; i <= sm.Srs.Vhosts.Count - 1; i++)
            {
                if (sm.Srs.Vhosts[i].VhostDomain!.Trim().ToLower().Equals(vhostDomian.Trim().ToLower()))
                {
                    for (j = 0; j <= sm.Srs.Vhosts[i].Vtranscodes!.Count - 1; j++)
                    {
                        if (sm.Srs.Vhosts[i].Vtranscodes![j].InstanceName!.Trim().ToLower()
                            .Equals(transcodeInstanceName.Trim().ToLower()))
                        {
                            found = true;
                            break;
                        }
                    }
                }

                if (found) break;
            }

            if (found)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = rs.Message += "\r\n" + "Transcode更新成功" +
                                            JsonHelper.ToJson(transcode),
                };
                //找到了
                sm.Srs.Vhosts[i].Vtranscodes![j] = transcode;
                return true;
            }
            else
            {
                //没找到
                if (!found && createIfNotFound) //要新增
                {
                    ret = CreateVhostTranscode(sm, vhostDomian, transcode, out rs);
                    if (ret)
                    {
                        rs = new ResponseStruct()
                        {
                            Code = ErrorNumber.None,
                            Message = rs.Message += "\r\n" + "SRS实例中未有指定transcode内容，系统已经将传入transcode创建到SRS实例中" +
                                                    JsonHelper.ToJson(vhost),
                        };
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceNotFound,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound] + "\r\n" +
                                  JsonHelper.ToJson(transcode),
                    };
                    return false;
                }
            }
        }

        /// <summary>
        /// 获取所有或者指定vhost中的transcode实例名称
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        public static List<VhostTranscodeNameModule> GetVhostTranscodeNameList(SrsManager sm, out ResponseStruct rs,
            string vhostDomain = "")
        {
            List<VhostTranscodeNameModule> result = null!;
            if (sm == null || sm.Srs == null || sm.Srs.Vhosts == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsObjectNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                };
                return null!;
            }

            if (string.IsNullOrEmpty(vhostDomain)) //全局搜索
            {
                foreach (var vhost in sm.Srs.Vhosts)
                {
                    if (vhost != null && vhost.Vtranscodes != null)
                    {
                        foreach (var trc in vhost.Vtranscodes)
                        {
                            if (trc != null)
                            {
                                if (result == null) result = new List<VhostTranscodeNameModule>();
                                VhostTranscodeNameModule vinm = new VhostTranscodeNameModule()
                                {
                                    VhostDomain = vhost.VhostDomain,
                                    TranscodeInstanceName = trc.InstanceName,
                                };
                                result.Add(vinm);
                            }
                        }
                    }
                }
            }
            else //指定vhostDomain搜索
            {
                foreach (var vhost in sm.Srs.Vhosts)
                {
                    if (vhost != null && vhost.VhostDomain!.Trim().ToLower().Equals(vhostDomain.Trim().ToLower()) &&
                        vhost.Vtranscodes != null)
                    {
                        foreach (var trc in vhost.Vtranscodes)
                        {
                            if (trc != null)
                            {
                                if (result == null) result = new List<VhostTranscodeNameModule>();
                                VhostTranscodeNameModule vinm = new VhostTranscodeNameModule()
                                {
                                    VhostDomain = vhost.VhostDomain,
                                    TranscodeInstanceName = trc.InstanceName,
                                };
                                result.Add(vinm);
                            }
                        }
                    }
                }
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            return result!;
        }

        /// <summary>
        /// 通过VhostDomain和transcodeInstanceName删除一个Transcode
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="transcodeInstanceName"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool DeleteVhostTranscodeByTranscodeInstanceName(SrsManager sm, string vhostDomain,
            string transcodeInstanceName,
            out ResponseStruct rs)
        {
            if (sm == null || sm.Srs == null || sm.Srs.Vhosts == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsObjectNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                };
                return false;
            }

            int i = 0;
            int j = 0;
            bool ret = false;
            for (i = 0; i <= sm.Srs.Vhosts.Count - 1; i++)
            {
                if (sm.Srs.Vhosts[i].VhostDomain!.Trim().ToLower().Equals(vhostDomain.Trim().ToLower()) &&
                    sm.Srs.Vhosts[i].Vtranscodes != null)
                {
                    for (j = 0; i <= sm.Srs.Vhosts[i].Vtranscodes!.Count - 1; j++)
                    {
                        if (sm.Srs.Vhosts[i].Vtranscodes![j].InstanceName!.Trim().ToLower()
                            .Equals(transcodeInstanceName.Trim().ToLower()))
                        {
                            sm.Srs.Vhosts[i].Vtranscodes![j] = null!;
                            ret = true;
                            break;
                        }
                    }
                }

                if (ret) break;
            }

            if (ret)
            {
                Common.RemoveNull(sm.Srs.Vhosts[i].Vtranscodes!);
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None],
                };
                return true;
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsSubInstanceNotFound,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound],
                };
                return false;
            }
        }

        /// <summary>
        /// 获取一个Transcode配置
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="transcodeInstanceName"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static Transcode GetVhostTranscode(SrsManager sm, string vhostDomain, string transcodeInstanceName,
            out ResponseStruct rs)
        {
            if (sm == null || sm.Srs == null || sm.Srs.Vhosts == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SrsObjectNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                };
                return null!;
            }

            Transcode result = null!;
            bool found = false;
            foreach (var vhost in sm.Srs.Vhosts)
            {
                if (vhost.VhostDomain!.Trim().ToLower().Equals(vhostDomain.Trim().ToLower()) &&
                    vhost.Vtranscodes != null)
                {
                    foreach (var trc in vhost.Vtranscodes!)
                    {
                        if (trc.InstanceName!.Trim().ToLower().Equals(transcodeInstanceName.Trim().ToLower()))
                        {
                            result = trc;
                            found = true;
                            break;
                        }
                    }
                }

                if (found) break;
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            return result!;
        }
    }
}