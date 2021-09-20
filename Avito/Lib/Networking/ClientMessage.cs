using Newtonsoft.Json;

namespace Avito.Lib.Networking
{
    public class ClientMessage
    {
        public MessageType Header { get; set; }
        public string Body { get; set; }

        public ClientMessage(MessageType header, string body)
            => (Header, Body) = (header, body);

        public override string ToString()
        {
            return $"[Message] Header: {Header} | Body: {Body}";
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static ClientMessage Deserialize(string messageString)
        {
            return JsonConvert.DeserializeObject<ClientMessage>(messageString)!;
        }

        public enum MessageType
        {
            Connect,
            Disconnect,
            SendMessage,
            Move
        };
    }
}
