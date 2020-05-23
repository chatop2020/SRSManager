using System.Collections.Generic;
using SRSApis.SRSManager.Apis.ApiModules;
using SRSConfFile.SRSConfClass;
using SRSManageCommon;

namespace SRSApis.SRSManager.Apis
{
    public static class VhostIngestApis
    {
        /// <summary>
        /// 创建ingest
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="ingest"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool CreateVhostIngest(SrsManager sm, string vhostDomain, Ingest ingest, out ResponseStruct rs)
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
                if (vhost.Vingests != null)
                {
                    Ingest ing = vhost.Vingests.FindLast(x =>
                        x.IngestName!.Trim().ToLower() == ingest.IngestName!.Trim().ToLower())!;
                    if (ing == null)
                    {
                        vhost.Vingests.Add(ingest);
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
                else //ingests is null
                {
                    vhost.Vingests = new List<Ingest>();
                    vhost.Vingests.Add(ingest);
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
                              JsonHelper.ToJson(ingest),
                };
                return false;
            }
        }

        /// <summary>
        /// 设置ingest
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="vhostDomian"></param>
        /// <param name="ingestInstanceName"></param>
        /// <param name="ingest"></param>
        /// <param name="rs"></param>
        /// <param name="createIfNotFound"></param>
        /// <returns></returns>
        public static bool SetVhostIngest(SrsManager sm, string vhostDomian, string ingestInstanceName, Ingest ingest,
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

            if (ingest == null || string.IsNullOrEmpty(ingest.IngestName))
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
                    for (j = 0; j <= sm.Srs.Vhosts[i].Vingests!.Count - 1; j++)
                    {
                        if (sm.Srs.Vhosts[i].Vingests![j].IngestName!.Trim().ToLower()
                            .Equals(ingestInstanceName.Trim().ToLower()))
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
                    Message = rs.Message += "\r\n" + "ingest更新成功" +
                                            JsonHelper.ToJson(ingest),
                };
                //找到了该ingest
                sm.Srs.Vhosts[i].Vingests![j] = ingest;
                return true;
            }
            else
            {
                //没找到
                if (!found && createIfNotFound) //要新增
                {
                    ret = CreateVhostIngest(sm, vhostDomian, ingest, out rs);
                    if (ret)
                    {
                        rs = new ResponseStruct()
                        {
                            Code = ErrorNumber.None,
                            Message = rs.Message += "\r\n" + "SRS实例中未有指定ingest内容，系统已经将传入ingest创建到SRS实例中" +
                                                    JsonHelper.ToJson(ingest),
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
                                  JsonHelper.ToJson(ingest),
                    };
                    return false;
                }
            }
        }

        /// <summary>
        /// 获取所有或者指定vhost中的ingest实例名称
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <param name="vhostDomain"></param>
        /// <returns></returns>
        public static List<VhostIngestNameModule> GetVhostIngestNameList(SrsManager sm, out ResponseStruct rs,
            string vhostDomain = "")
        {
            List<VhostIngestNameModule> result = null!;
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
                    if (vhost != null && vhost.Vingests != null)
                    {
                        foreach (var ing in vhost.Vingests)
                        {
                            if (ing != null)
                            {
                                if (result == null) result = new List<VhostIngestNameModule>();
                                VhostIngestNameModule vinm = new VhostIngestNameModule()
                                {
                                    VhostDomain = vhost.VhostDomain,
                                    IngestInstanceName = ing.IngestName,
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
                        vhost.Vingests != null)
                    {
                        foreach (var ing in vhost.Vingests)
                        {
                            if (ing != null)
                            {
                                if (result == null) result = new List<VhostIngestNameModule>();
                                VhostIngestNameModule vinm = new VhostIngestNameModule()
                                {
                                    VhostDomain = vhost.VhostDomain,
                                    IngestInstanceName = ing.IngestName,
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
        /// 通过VhostDomain和IngestInstanceName删除一个Ingest
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="ingestInstanceName"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool DeleteVhostIngestByIngestInstanceName(SrsManager sm, string vhostDomain,
            string ingestInstanceName,
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
                    sm.Srs.Vhosts[i].Vingests != null)
                {
                    for (j = 0; i <= sm.Srs.Vhosts[i].Vingests!.Count - 1; j++)
                    {
                        if (sm.Srs.Vhosts[i].Vingests![j].IngestName!.Trim().ToLower()
                            .Equals(ingestInstanceName.Trim().ToLower()))
                        {
                            sm.Srs.Vhosts[i].Vingests![j] = null!;
                            ret = true;
                            break;
                        }
                    }
                }

                if (ret) break;
            }

            if (ret)
            {
                Common.RemoveNull(sm.Srs.Vhosts[i].Vingests!);
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
        /// 获取一个Ingest配置
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="ingestInstanceName"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static Ingest GetVhostIngest(SrsManager sm, string vhostDomain, string ingestInstanceName,
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

            Ingest result = null!;
            bool found = false;
            foreach (var vhost in sm.Srs.Vhosts)
            {
                if (vhost.VhostDomain!.Trim().ToLower().Equals(vhostDomain.Trim().ToLower()) && vhost.Vingests != null)
                {
                    foreach (var ing in vhost.Vingests!)
                    {
                        if (ing.IngestName!.Trim().ToLower().Equals(ingestInstanceName.Trim().ToLower()))
                        {
                            result = ing;
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