using System.Runtime.Serialization;
using System;

namespace Avito.Lib.Networking
{
    [DataContract]
    public struct Message
    {
        public enum Type { Disconnect, Join };
        [DataMember] public Type Header { get; set; }
        [DataMember] public object? Body { get; set; }

        public override string ToString()
        {
            return $"[Message] Header: {Header} | Body: {Body}";
        }
    }
}
