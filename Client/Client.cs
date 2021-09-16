using Avito.Lib.Networking;
using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;

namespace Avito.Client
{
    class Client : TcpClient
    {
        private readonly BinaryFormatter _formatter = new();
        public Client() : this(Settings.Server.Host.ToString(), Settings.Server.Port) { }
        public Client(string host, int port) : base(host, port)
        {
            NetworkStream stream = GetStream();

            while (Connected) 
            {
                Message message = new()
                {
                    Header = Message.Type.Join,
                    Body = new string("test string")
                };

                _formatter.Serialize(stream, message);
                Console.WriteLine($"[CLIENT] Sending message: {message}"); 
            }
        }
    }
}
