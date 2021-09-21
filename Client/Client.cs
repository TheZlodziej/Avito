using Avito.Lib.Networking;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Avito.Client
{
    class Client : TcpClient // IDisposable (inherits from TcpClient)
    {
        private NetworkStream _stream;
        private StreamWriter _writer;
        private StreamReader _reader;

        public Client()
            : this(Settings.Server.Host.ToString(), Settings.Server.Port)
        {

        }

        public Client(string host, int port) : base(host, port)
        {
            _stream = GetStream();
            Encoding enc = new UTF8Encoding(false);
            _writer = new StreamWriter(_stream, enc, leaveOpen: true);
            _reader = new StreamReader(_stream, enc, leaveOpen: true);
            SendHello();
        }

        private void SendHello()
        {
            ClientMessage message = new ClientMessage(ClientMessage.MessageType.Connect, "hello");
            var response = SendMessage(message);
            Console.WriteLine($"INFO: {response}");
        }

        public string SendMessage(string body)
        {
            ClientMessage message = new ClientMessage(ClientMessage.MessageType.SendMessage, body);
            var response = SendMessage(message);
            return response.Body;
        }

        private void SendGoodbye()
        {
            ClientMessage message = new ClientMessage(ClientMessage.MessageType.Disconnect, "goodbye");
            var response = SendMessage(message);
            Console.WriteLine($"INFO: {response}");
        }

        private ServerMessage SendMessage(ClientMessage message)
        {
            string messageString = message.Serialize();
            Console.WriteLine($"sending: {messageString}");
            _writer.WriteLine(messageString);
            _writer.Flush();
            string messageResponse = _reader.ReadLine();
            Console.WriteLine($"Got: {messageResponse}");
            return ServerMessage.Deserialize(messageResponse);
        }

        protected override void Dispose(bool disposing)
        {
            SendGoodbye();
            _writer?.Dispose();
            _writer = null!;

            _reader?.Dispose();
            _reader = null!;

            _stream?.Dispose();
            _stream = null!;

            base.Dispose(disposing);
        }
    }
}
