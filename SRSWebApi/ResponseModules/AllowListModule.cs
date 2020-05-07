using System;
using System.Collections.Generic;

namespace SRSWebApi.ResponseModules
{
    [Serializable]
    public class AllowListModule
    {
        private List<AllowKey> allowKeys = new List<AllowKey>();

        public List<AllowKey> AllowKeys
        {
            get => allowKeys;
            set => allowKeys = value;
        }
    }
}