using System;
using System.Collections.Generic;
using SRSManageCommon.ManageStructs;

namespace SRSManageCommon.ControllerStructs.ResponseModules
{
    /// <summary>
    /// allowkeylist返回结构
    /// </summary>
    [Serializable]
    public class AllowListModule
    {
        private List<AllowKey> _allowKeys = new List<AllowKey>();

        /// <summary>
        /// AllowKey列表
        /// </summary>
        public List<AllowKey> AllowKeys
        {
            get => _allowKeys;
            set => _allowKeys = value;
        }
    }
}