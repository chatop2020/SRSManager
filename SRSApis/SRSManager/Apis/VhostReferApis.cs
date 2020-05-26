using SRSConfFile.SRSConfClass;
using SRSManageCommon;

namespace SRSApis.SRSManager.Apis
{
    public static class VhostReferApis
    {
        /// <summary>
        /// 删除refer配置
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool DeleteVhostRefer(string deviceId, string vhostDomain, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            var ret = Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(deviceId.Trim().ToUpper()));
            if (ret != null)
            {
                if (ret.Srs == null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsObjectNotInit,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                    };
                    return false;
                }

                if (ret.Srs.Vhosts == null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceNotFound,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound],
                    };
                    return false;
                }

                var retVhost = ret.Srs.Vhosts.FindLast(x =>
                    x.VhostDomain!.Trim().ToUpper().Equals(vhostDomain.Trim().ToUpper()));
                if (retVhost == null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceNotFound,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound],
                    };
                    return false;
                }

                retVhost.Vrefer = null;
                return true;
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.SrsObjectNotInit,
                Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
            };
            return false;
        }

        /// <summary>
        /// 获取Vhost中的refer
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static Refer GetVhostRefer(string deviceId, string vhostDomain, out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            var ret = Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(deviceId.Trim().ToUpper()));
            if (ret != null)
            {
                if (ret.Srs == null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsObjectNotInit,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                    };
                    return null!;
                }

                if (ret.Srs.Vhosts == null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceNotFound,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound],
                    };
                    return null!;
                }

                var retVhost = ret.Srs.Vhosts.FindLast(x =>
                    x.VhostDomain!.Trim().ToUpper().Equals(vhostDomain.Trim().ToUpper()));
                if (retVhost == null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceNotFound,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound],
                    };
                    return null!;
                }

                return retVhost.Vrefer!;
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.SrsObjectNotInit,
                Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
            };
            return null!;
        }

        /// <summary>
        /// 设置refer
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="vhostDomain"></param>
        /// <param name="refer"></param>
        /// <param name="rs"></param>
        /// <returns></returns>
        public static bool SetVhostRefer(string deviceId, string vhostDomain, Refer refer,
            out ResponseStruct rs)
        {
            rs = new ResponseStruct()
            {
                Code = ErrorNumber.None,
                Message = ErrorMessage.ErrorDic![ErrorNumber.None],
            };
            var ret = Common.SrsManagers.FindLast(x =>
                x.SrsDeviceId.Trim().ToUpper().Equals(deviceId.Trim().ToUpper()));
            if (ret != null)
            {
                if (ret.Srs == null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsObjectNotInit,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
                    };
                    return false;
                }

                if (ret.Srs.Vhosts == null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceNotFound,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound],
                    };
                    return false;
                }

                var retVhost = ret.Srs.Vhosts.FindLast(x =>
                    x.VhostDomain!.Trim().ToUpper().Equals(vhostDomain.Trim().ToUpper()));
                if (retVhost == null)
                {
                    rs = new ResponseStruct()
                    {
                        Code = ErrorNumber.SrsSubInstanceNotFound,
                        Message = ErrorMessage.ErrorDic![ErrorNumber.SrsSubInstanceNotFound],
                    };
                    return false!;
                }

                retVhost.Vrefer = refer;
                return true;
            }

            rs = new ResponseStruct()
            {
                Code = ErrorNumber.SrsObjectNotInit,
                Message = ErrorMessage.ErrorDic![ErrorNumber.SrsObjectNotInit],
            };
            return false;
        }
    }
}