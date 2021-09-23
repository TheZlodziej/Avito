using Newtonsoft.Json;

namespace Avito.Lib.Networking
{
    public class ServerMessage
    {
        public MessageType Header { get; set; }
        public string Body { get; set; }

        public ServerMessage(MessageType header, string body)
            => (Header, Body) = (header, body);

        public override string ToString()
        {
            return $"[Message] Header: {Header} | Body: {Body}";
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static ServerMessage Deserialize(string messageString)
        {
            return JsonConvert.DeserializeObject<ServerMessage>(messageString)!;
        }

        public enum MessageType
        {
            ConnectionResponse,
            RegularResponse,
            UnknownMessage
        }
    }
}
