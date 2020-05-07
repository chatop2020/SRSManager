using SRSConfFile.SRSConfClass;

namespace SRSApis.SRSManager.Apis
{
    public static class StatsApis
    {
        /// <summary>
        /// 删除Stats段
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool DeleteStats(SrsManager sm, out ResponseStruct rs)
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

            sm.Srs.Stats = null;
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            return true;
        }

        /// <summary>
        /// 设置stats参数
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="stats"></param>
        /// <param name="rs"></param>
        /// <param name="createIfNotFound"></param>
        /// <returns></returns>
        public static bool SetStatsServer(SrsManager sm, SrsStatsConfClass stats, out ResponseStruct rs,
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

            if (stats == null)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.FunctionInputParamsError,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.FunctionInputParamsError],
                };
                return false;
            }

            if (sm.Srs.Stats == null && createIfNotFound)
            {
                if (CreateStatsServer(sm, stats, out rs))
                {
                    rs.Message += "\r\n" + "SRS实例中未有Stats内容，系统已经将传入Stats创建到SRS实例中";
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (sm.Srs.Stats == null && !createIfNotFound)
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SRSSubInstanceNotFound,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SRSSubInstanceNotFound] + "\r\n" +
                              JsonHelper.ToJson(stats),
                };
                return false;
            }
            else if (sm.Srs.Stats != null)
            {
                if (stats.Disk != null) sm.Srs.Stats.Disk = stats.Disk;
                if (stats.Network != null) sm.Srs.Stats.Network = stats.Network;

                stats.SectionsName = "stats";
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None] + "\r\n" + "Stats配置更新成功\r\n" +
                              JsonHelper.ToJson(stats),
                };

                return true;
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.Other,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.Other] + "\r\n" + "Stats配置更新失败，未知异常\r\n" +
                              JsonHelper.ToJson(stats),
                };
                return false;
            }
        }

        /// <summary>
        /// 创建一个Stats
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="stats"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool CreateStatsServer(SrsManager sm, SrsStatsConfClass stats,
            out ResponseStruct rs)
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

            if (sm.Srs.Stats == null)
            {
                sm.Srs.Stats = new SrsStatsConfClass();
                sm.Srs.Stats = Common.ObjectClone(stats);
                sm.Srs.Stats.SectionsName = "stats";
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.None,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.None] + "\r\n" + "Stats创建到SRS实例中\r\n" +
                              JsonHelper.ToJson(stats),
                };
                return true;
            }
            else
            {
                rs = new ResponseStruct()
                {
                    Code = ErrorNumber.SRSSubInstanceAlreadyExists,
                    Message = ErrorMessage.ErrorDic![ErrorNumber.SRSSubInstanceAlreadyExists],
                };
                return false;
            }
        }

        /// <summary>
        /// 获取Stats
        /// </summary>
        /// <param name="sm"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static SrsStatsConfClass GetStats(SrsManager sm, out ResponseStruct rs)
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
            if (sm.Srs.Rtc_server != null)
            {
                SrsStatsConfClass? result = Common.ObjectClone(sm.Srs.Stats);
                return result!;
            }
            else
            {
                return null!;
            }
        }
    }
}