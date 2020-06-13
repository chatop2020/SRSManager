using System;
using FreeSql.DataAnnotations;
using SrsManageCommon;

namespace SRSManageCommon.DBMoudle
{
    [Serializable]
    public enum EventMethod
    {
        Connect,
        Close,
        Publish,
        UnPublish,
        Play,
        Stop
    }
    [Serializable]
    [Index("uk_CL_DeviceId", "DeviceId", false)]
    [Index("uk_CL_VhostDomain", "VhostDomain", false)]
    [Index("uk_CL_EventMethod", "EventMethod", false)]
    [Table(Name = "ClientLog")]
    public class ClientLog:OnlineClient
    {
        private EventMethod _eventMethod;

        [Column(MapType = typeof(string))]
        public EventMethod EventMethod
        {
            get => _eventMethod;
            set => _eventMethod = value;
        }
    }
}