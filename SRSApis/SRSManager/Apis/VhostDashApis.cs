using SRSConfFile.SRSConfClass;

namespace SRSApis.SRSManager.Apis
{
    public static class VhostDashApis
    {
        /// <summary>
        /// 删除Dash配置
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool DeleteVhostDash(SrsManager sm, string vhostDomain, out ResponseStruct rs)
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

            bool ret = false;
            for (i = 0; i <= sm.Srs.Vhosts.Count - 1; i++)
            {
                if (sm.Srs.Vhosts[i].VhostDomain!.Trim().ToLower().Equals(vhostDomain.Trim().ToLower()))
                {
                    sm.Srs.Vhosts[i].Vdash = null;
                    ret = true;
                    break;
                }
            }

            if (ret)
            {
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
        /// 获取Vhost中的Dash
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static Dash GetVhostDash(SrsManager sm, string vhostDomain, out ResponseStruct rs)
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

            Dash result = null!;
            foreach (var vhost in sm.Srs.Vhosts)
            {
                if (vhost.VhostDomain!.Trim().ToLower().Equals(vhostDomain.Trim().ToLower()))
                {
                    result = vhost.Vdash!;
                    break;
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
        /// 设置dash
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="vhostDomian"></param>
        /// <param name="dash"></param>
        /// <param name="rs"></param>
        /// <param name="createIfNotFound"></param>
        /// <returns></returns>
        public static bool SetVhostDash(SrsManager sm, string vhostDomian, Dash dash,
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

            if (dash == null)
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
            for (i = 0; i <= sm.Srs.Vhosts.Count - 1; i++)
            {
                if (sm.Srs.Vhosts[i].VhostDomain!.Trim().ToLower().Equals(vhostDomian.Trim().ToLower()))
                {
                    found = true;
                    break;
                }
            }

            if (found)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = rs.Message += "\r\n" + "dash更新成功" +
                                            JsonHelper.ToJson(dash),
                };
                //找到了
                sm.Srs.Vhosts[i].Vdash = Common.ObjectClone(dash);
                return true;
            }
            else
            {
                //没找到
                if (!found && createIfNotFound) //要新增
                {
                    ret = CreateVhostDash(sm, vhostDomian, dash, out rs);
                    if (ret)
                    {
                        rs = new ResponseStruct()
                        {
                            Code = ErrorNumber.None,
                            Message = rs.Message += "\r\n" + "SRS实例中未有指定Dash内容，系统已经将传入Dash创建到SRS实例中" +
                                                    JsonHelper.ToJson(dash),
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
                                  JsonHelper.ToJson(dash),
                    };
                    return false;
                }
            }
        }

        /// <summary>
        /// 创建Dash
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="dash"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool CreateVhostDash(SrsManager sm, string vhostDomain, Dash dash,
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
                if (vhost.Vdash != null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceAlreadyExists,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceAlreadyExists],
                    };
                    return false;
                }
                else // is null
                {
                    vhost.Vdash = dash;
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
                              JsonHelper.ToJson(dash),
                };
                return false;
            }
        }
    }
}