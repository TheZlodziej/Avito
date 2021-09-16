using System;

namespace Avito.Lib.Networking
{
    [Serializable]
    public struct Message
    {
        public enum Type { Disconnect, Join };
        public Type Header { get; set; }
        public object Body { get; set; }

        public override string ToString()
        {
            return $"[Message] Header: {Header} | Body: {Body}";
        }
    }
}
