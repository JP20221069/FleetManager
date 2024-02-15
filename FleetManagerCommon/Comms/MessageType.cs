using System;

namespace FleetManagerCommon.Comms
{
    [Serializable]
    public enum MessageType
    {
        Text,
        Error,
        Success
    }
}