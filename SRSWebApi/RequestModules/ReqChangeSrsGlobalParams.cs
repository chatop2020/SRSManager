using System;
using SRSApis.SRSManager;
using SRSApis.SRSManager.Apis.ApiModules;

namespace SRSWebApi.RequestModules
{
    /// <summary>
    /// 请求修改srs实例全局参数的结构
    /// </summary>
    [Serializable]
    public class ReqChangeSrsGlobalParams
    {
        private string _deviceId = null!;
        private GlobalModule _gm = null!;

        /// <summary>
        /// srsmanager
        /// </summary>
        public string DeviceId
        {
            get => _deviceId;
            set => _deviceId = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// globalmodule
        /// </summary>
        public GlobalModule Gm
        {
            get => _gm;
            set => _gm = value ?? throw new ArgumentNullException(nameof(value));
        }
    }
}