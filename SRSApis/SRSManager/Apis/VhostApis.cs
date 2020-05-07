using System.Collections.Generic;
using SRSApis.SRSManager.Apis.ApiModules;
using SRSConfFile.SRSConfClass;

namespace SRSApis.SRSManager.Apis
{
    public static class VhostApis
    {
        /// <summary>
        /// 获取Vhost列表的Instance名称列表
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static List<string> GetVhostsInstanceName(SrsManager sm, out ResponseStruct rs)
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

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            if (sm.Srs.Vhosts.Count > 0)
            {
                List<string> slist = new List<string>();
                foreach (var stream in sm.Srs.Vhosts)
                {
                    slist.Add(stream.InstanceName!);
                }

                return slist!;
            }
            else
            {
                return null!;
            }
        }

        /// <summary>
        /// 通过domain获取vhost
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static SrsvHostConfClass GetVhostByDomain(SrsManager sm, string vhostDomain, out ResponseStruct rs)
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

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            foreach (var vhost in sm.Srs.Vhosts)
            {
                if (vhost.VhostDomain!.Trim().ToLower().Equals(vhostDomain.Trim().ToLower()))
                {
                    return vhost;
                }
            }

            return null!;
        }

        /// <summary>
        /// 获取Vhost列表
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static List<SrsvHostConfClass> GetVhostList(SrsManager sm, out ResponseStruct rs)
        {
            if (sm == null || sm.Srs == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SRSObjectNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SRSObjectNotInit],
                };
                return null!;
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            if (sm.Srs.Vhosts != null && sm.Srs.Vhosts.Count > 0)
            {
                List<SrsvHostConfClass> result = Common.ObjectClone(sm.Srs.Vhosts);
                return result;
            }
            else
            {
                return null!;
            }
        }

        /// <summary>
        /// 创建一个vhost
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="vhost"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool CreateVhost(SrsManager sm, SrsvHostConfClass vhost, out ResponseStruct rs)
        {
            if (sm == null || sm.Srs == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SRSObjectNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SRSObjectNotInit],
                };
                return false;
            }

            if (sm.Srs.Vhosts == null) sm.Srs.Vhosts = new List<SrsvHostConfClass>();
            for (int i = 0; i <= sm.Srs.Vhosts.Count - 1; i++)
            {
                if (sm.Srs.Vhosts[i].VhostDomain!.Trim().ToLower()
                    .Equals(vhost.VhostDomain!.Trim().ToLower()))
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SRSSubInstanceAlreadyExists,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SRSSubInstanceAlreadyExists],
                    };
                    return false;
                }
            }

            if (string.IsNullOrEmpty(vhost.VhostDomain) &&
                sm.Srs.Vhosts.FindLast(v => v.VhostDomain!.Trim().ToLower() == "__defaultvhost__") == null)
            {
                vhost.InstanceName =
                    "__defaultVhost__"; //如果instanceName为空，以及当前Vhosts中没有__defaultVhost__的Vhost，则本Vhost为__defaultVhost__
                vhost.VhostDomain = "__defaultVhost__";
            }

            if (string.IsNullOrEmpty(vhost.SectionsName))
            {
                vhost.SectionsName = "vhost";
            }

            sm.Srs.Vhosts.Add(Common.ObjectClone(vhost));
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None] + "\r\n" + "Vhost创建到SRS实例中\r\n" +
                          JsonHelper.ToJson(vhost),
            };
            return true;
        }

        /// <summary>
        /// 获取Vhost的各类模板
        /// </summary>
        /// <param name="vtype"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static SrsvHostConfClass GetVhostTemplate(VhostIngestInputType vtype, out ResponseStruct rs)
        {
            SrsvHostConfClass vhost = new SrsvHostConfClass();
            vhost.Vingests = new List<Ingest>();
            vhost.InstanceName = "your.domain.com"; //change it 
            vhost.VhostDomain = vhost.InstanceName;
            vhost.SectionsName = "vhost";
            vhost.Enabled = true;
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None] + "\r\n" + JsonHelper.ToJson(vtype),
            };
            switch (vtype)
            {
                case VhostIngestInputType.Stream: //RTSP or other Stream
                    Ingest ing = new Ingest();
                    ing.Enabled = true;
                    ing.InstanceName = "ingest_template_rtsp";
                    ing.IngestName = ing.InstanceName;
                    ing.SectionsName = "ingest";
                    IngestInput inginput = new IngestInput();
                    IngestTranscodeEngine ingeng = new IngestTranscodeEngine();
                    ing.Engines = new List<IngestTranscodeEngine>();
                    ingeng.Perfile = new IngestEnginePerfile();
                    ingeng.Perfile.SectionsName = "perfile";
                    ingeng.Enabled = true;
                    inginput.SectionsName = "input";
                    inginput.Type = IngestInputType.stream;
                    inginput.Url =
                        "rtsp://admin:12345678@192.168.2.21:554/Streaming/Channels/501?transportmode=unicast";
                    ing.Input = inginput;
                    ing.Ffmpeg = "/bin/local/ffmpeg";
                    ingeng.SectionsName = "engine";
                    ingeng.Enabled = true;
                    ingeng.Vcodec = "copy";
                    ingeng.Acodec = "copy";
                    ingeng.Perfile.Rtsp_transport = "tcp";
                    ingeng.Perfile.SectionsName = "perfile";
                    ingeng.Output = "rtmp://127.0.0.1/[vhost]/[live]/[livestream]";
                    ing.Engines.Add(ingeng);
                    ing.Input = inginput;
                    vhost.Vingests.Add(ing);
                    return vhost!;
                case VhostIngestInputType.File: //From File
                    IngestInput inginput1 = new IngestInput();
                    IngestTranscodeEngine ingeng1 = new IngestTranscodeEngine();
                    Ingest ing1 = new Ingest();
                    ing1.Enabled = true;
                    ing1.Engines = new List<IngestTranscodeEngine>();
                    ing1.InstanceName = "ingest_template_file";
                    ing1.IngestName = ing1.InstanceName;
                    ing1.SectionsName = "ingest";
                    ingeng1.Enabled = true;
                    inginput1.SectionsName = "input";
                    inginput1.Type = IngestInputType.file;
                    inginput1.Url =
                        "./demo.mp4";
                    ing1.Input = inginput1;
                    ing1.Ffmpeg = "/bin/local/ffmpeg";
                    ingeng1.SectionsName = "engine";
                    ingeng1.Enabled = true;
                    ingeng1.Output = "rtmp://127.0.0.1/[vhost]/[live]/[livestream]";
                    ing1.Engines.Add(ingeng1);
                    ing1.Input = inginput1;
                    vhost.Vingests.Add(ing1);
                    return vhost!;
                case VhostIngestInputType.Device: //From Device
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SRSConfigFunctionUnsupported,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SRSConfigFunctionUnsupported] + "\r\n" +
                                  JsonHelper.ToJson(vtype),
                    };
                    return null!;
                default:
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.FunctionInputParamsError,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError] + "\r\n" +
                                  JsonHelper.ToJson(vtype),
                    };
                    return null!;
            }
        }

        /// <summary>
        /// 删除一个vhost,用域名
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="domain"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool DeleteVhostByDomain(SrsManager sm, string domain, out ResponseStruct rs)
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

            bool ret = false;
            for (int i = 0; i <= sm.Srs.Vhosts.Count - 1; i++)
            {
                if (sm.Srs.Vhosts[i].VhostDomain!.Trim().ToLower().Equals(domain.Trim().ToLower()))
                {
                    sm.Srs.Vhosts[i] = null!;
                    ret = true;
                    break;
                }
            }

            if (ret)
            {
                Common.RemoveNull(sm.Srs.Vhosts);
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
        /// 修改vhost的域名
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="domain"></param>
        /// <param name="newdomain"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool ChangeVhostDomain(SrsManager sm, string domain, string newdomain, out ResponseStruct rs)
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

            bool ret = false;
            foreach (var vhost in sm.Srs.Vhosts)
            {
                if (vhost.VhostDomain != null && vhost.VhostDomain.Trim().ToLower().Equals(domain.Trim().ToLower()))
                {
                    vhost.InstanceName = newdomain;
                    vhost.VhostDomain = vhost.InstanceName;
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
        /// 关闭或开始Vhost列表中某个Vhost中的某个ingest
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="vhostDomin">vhost的域名</param>
        /// <param name="ingestInstanceName">ingest的instancename</param>
        /// <param name="enabled">关闭或开启</param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool OnOrOffVhostIngest(SrsManager sm, string vhostDomin, string ingestInstanceName, bool enabled,
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

            bool ret = false;
            foreach (var vhost in sm.Srs.Vhosts)
            {
                if (vhost.VhostDomain!.Trim().ToLower().Equals(vhostDomin.Trim().ToLower()))
                {
                    if (vhost.Vingests != null)
                    {
                        foreach (var ing in vhost.Vingests)
                        {
                            if (ing != null && ing.InstanceName!.Trim().ToLower() ==
                                ingestInstanceName.Trim().ToLower())
                            {
                                ing.Enabled = enabled;
                                ret = true;
                                break;
                            }
                        }
                    }
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
        /// 设置一个Vhost的参数
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="vhost"></param>
        /// <param name="rs"></param>
        /// <param name="createIfNotFound"></param>
        /// <returns></returns>
        public static bool SetVhost(SrsManager sm, SrsvHostConfClass vhost, out ResponseStruct rs,
            bool createIfNotFound = false)
        {
            if (sm == null || sm.Srs == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SRSObjectNotInit,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SRSObjectNotInit],
                };
                return false;
            }

            if (vhost == null || string.IsNullOrEmpty(vhost.VhostDomain))
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return false;
            }

            if ((sm.Srs.Vhosts == null || sm.Srs.Vhosts.Count == 0) && createIfNotFound)
            {
                if (CreateVhost(sm, vhost, out rs))
                {
                    rs.Message += "\r\n" + "SRS实例中未有Vhost内容，系统已经将传入Vhost创建到SRS实例中";
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if ((sm.Srs.Vhosts == null || sm.Srs.Vhosts.Count == 0) && !createIfNotFound)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SRSSubInstanceNotFound,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SRSSubInstanceNotFound] + "\r\n" +
                              JsonHelper.ToJson(vhost),
                };
                return false;
            }
            else
            {
                if (sm.Srs.Vhosts != null)
                    for (int i = 0; i <= sm.Srs.Vhosts.Count - 1;)
                    {
                        if (sm.Srs.Vhosts[i].VhostDomain!.Trim().ToLower()
                            .Equals(vhost.VhostDomain!.Trim().ToLower()))
                        {
                            sm.Srs.Vhosts[i] = Common.ObjectClone(vhost);
                        }

                        rs = new ResponseStruct()
                        {
                            Code = ErrorNumber.None,
                            Message = ErrorMessage.ErrorDic![ErrorNumber.None] + "\r\n" + "Vhost配置更新成功\r\n" +
                                      JsonHelper.ToJson(vhost),
                        };

                        return true;
                    }
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.Other,
                Message = ErrorMessage.ErrorDic![ErrorNumber.Other] + "\r\n" + "Vhost配置更新失败，未知异常\r\n" +
                          JsonHelper.ToJson(vhost),
            };
            return false;
        }
    }
}