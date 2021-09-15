using System;
using System.Net.Sockets;

namespace Avito.Client
{
    class Client : TcpClient
    {
        public Client() : this(Settings.Server.Host.ToString(), Settings.Server.Port) { }
        public Client(string host, int port) : base(host, port)
        {
            while (Connected) 
            { 
                Console.WriteLine("[CLIENT] I'm connected"); 
            }
        }
    }
}
