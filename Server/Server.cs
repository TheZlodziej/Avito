using System.Net;
using System.Net.Sockets;

namespace Avito.Server
{
    public class Server : TcpListener
    {
        public Server() : this(Settings.Server.Host, Settings.Server.Port) { }
        public Server(IPAddress hostname, int port) : base(hostname, port)
        {

        }

        public void Run()
        {
            Start();
            // TODO: ...
        }
    }
}
