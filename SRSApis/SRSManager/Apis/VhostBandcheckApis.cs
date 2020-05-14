using SRSConfFile.SRSConfClass;

namespace SRSApis.SRSManager.Apis
{
    public static class VhostBandcheckApis
    {
        /// <summary>
        /// 删除Bandcheck配置
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool DeleteVhostBandcheck(SrsManager sm, string vhostDomain, out ResponseStruct rs)
        {
            if (sm == null || sm.Srs == null || sm.Srs.Vhosts == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SRSObjectNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SRSObjectNotInit],
                };
                return false;
            }

            int i = 0;

            bool ret = false;
            for (i = 0; i <= sm.Srs.Vhosts.Count - 1; i++)
            {
                if (sm.Srs.Vhosts[i].VhostDomain!.Trim().ToLower().Equals(vhostDomain.Trim().ToLower()))
                {
                    sm.Srs.Vhosts[i].Vbandcheck = null;
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
                    Code = ErrorNumber.SRSSubInstanceNotFound,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SRSSubInstanceNotFound],
                };
                return false;
            }
        }

        /// <summary>
        /// 获取Vhost中的Bandcheck
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static Bandcheck GetVhostBandcheck(SrsManager sm, string vhostDomain, out ResponseStruct rs)
        {
            if (sm == null || sm.Srs == null || sm.Srs.Vhosts == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SRSObjectNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SRSObjectNotInit],
                };
                return null!;
            }

            Bandcheck result = null!;
            foreach (var vhost in sm.Srs.Vhosts)
            {
                if (vhost.VhostDomain!.Trim().ToLower().Equals(vhostDomain.Trim().ToLower()))
                {
                    result = vhost.Vbandcheck!;
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
        /// 设置Bandcheck
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="vhostDomian"></param>
        /// <param name="bandcheck"></param>
        /// <param name="rs"></param>
        /// <param name="createIfNotFound"></param>
        /// <returns></returns>
        public static bool SetVhostBandcheck(SrsManager sm, string vhostDomian, Bandcheck bandcheck,
            out ResponseStruct rs, bool createIfNotFound = false)
        {
            bool ret = false;
            if (sm == null || sm.Srs == null || sm.Srs.Vhosts == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SRSObjectNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SRSObjectNotInit],
                };
                return false;
            }

            if (bandcheck == null)
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
                    Message = rs.Message += "\r\n" + "bandcheck更新成功" +
                                            JsonHelper.ToJson(bandcheck),
                };
                //找到了
                sm.Srs.Vhosts[i].Vbandcheck = Common.ObjectClone(bandcheck);
                return true;
            }
            else
            {
                //没找到
                if (!found && createIfNotFound) //要新增
                {
                    ret = CreateVhostBandcheck(sm, vhostDomian, bandcheck, out rs);
                    if (ret)
                    {
                        rs = new ResponseStruct()
                        {
                            Code = ErrorNumber.None,
                            Message = rs.Message += "\r\n" + "SRS实例中未有指定bandcheck内容，系统已经将传入bandcheck创建到SRS实例中" +
                                                    JsonHelper.ToJson(bandcheck),
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
                        Code = ErrorNumber.SRSSubInstanceNotFound,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SRSSubInstanceNotFound] + "\r\n" +
                                  JsonHelper.ToJson(bandcheck),
                    };
                    return false;
                }
            }
        }

        /// <summary>
        /// 创建Bandcheck
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="bandcheck"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool CreateVhostBandcheck(SrsManager sm, string vhostDomain, Bandcheck bandcheck,
            out ResponseStruct rs)
        {
            if (sm == null || sm.Srs == null || sm.Srs.Vhosts == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SRSObjectNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SRSObjectNotInit],
                };
                return false;
            }

            SrsvHostConfClass vhost = VhostApis.GetVhostByDomain(sm, vhostDomain, out rs);
            if (vhost != null && rs.Code == ErrorNumber.None) //找到
            {
                if (vhost.Vbandcheck != null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SRSSubInstanceAlreadyExists,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SRSSubInstanceAlreadyExists],
                    };
                    return false;
                }
                else // is null
                {
                    vhost.Vbandcheck = bandcheck;
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
                    Code = ErrorNumber.SRSSubInstanceNotFound,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SRSSubInstanceNotFound] + "\r\n" +
                              JsonHelper.ToJson(bandcheck),
                };
                return false;
            }
        }
    }
}