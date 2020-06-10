using System;
using System.Collections.Generic;
using Org.BouncyCastle.Ocsp;
using SRSManageCommon.ControllerStructs.RequestModules;
using SRSManageCommon.DBMoudle;

namespace SRSManageCommon.ControllerStructs.ResponseModules
{
    [Serializable]
    public class DvrVideoResponseList
    {
        private List<DvrVideo>? _dvrVideoList;
        private ReqGetDvrVideo? _request;
        private long? _total;

        public List<DvrVideo>? DvrVideoList
        {
            get => _dvrVideoList;
            set => _dvrVideoList = value;
        }

        public ReqGetDvrVideo? Request
        {
            get => _request;
            set => _request = value;
        }

        public long? Total
        {
            get => _total;
            set => _total = value;
        }
    }
}