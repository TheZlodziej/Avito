using Avito.Lib.Networking;
using System;
using System.Net.Sockets;
using System.Runtime.Serialization;

namespace Avito.Client
{
    class Client : TcpClient
    {
        private readonly DataContractSerializer _serializer = new(typeof(Message));
        public Client() : this(Settings.Server.Host.ToString(), Settings.Server.Port) { }
        public Client(string host, int port) : base(host, port)
        {
            NetworkStream stream = GetStream();

            while (Connected)
            {
                Console.WriteLine("connected");
                Message message = new()
                {
                    Header = Message.Type.Join,
                    Body = new string("test string")
                };

                _serializer.WriteObject(stream, message);
                Console.WriteLine($"[CLIENT] Sending message: {message}");

                Message messageRecieved = (Message)_serializer.ReadObject(stream);
                Console.WriteLine($"[CLIENT] Recieved: {messageRecieved}");
            }

            Close();
        }
    }
}
