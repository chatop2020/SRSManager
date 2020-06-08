using System;

namespace SRSManageCommon.ControllerStructs.RequestModules
{
    /// <summary>
    /// 获取授权访问列表的请求结构
    /// </summary>
    [Serializable]
    public class ReqGetAllows
    {
        private string password = null!;

        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get => password;
            set => password = value;
        }
    }
}