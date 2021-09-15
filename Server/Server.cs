using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Avito.Server
{
    public class Server : TcpListener
    {
        private readonly Thread _clientConnectionListener;
        private readonly List<(Thread, TcpClient)> _clients = new();
        public Server() : this(Settings.Server.Host, Settings.Server.Port) { }
        public Server(IPAddress hostname, int port) : base(hostname, port)
        {
            _clientConnectionListener = new Thread(new ThreadStart(ClientConnectionListener));
        }

        private void ClientDataListener(object obj)
        {
            TcpClient client = obj as TcpClient;
            NetworkStream stream = client.GetStream();
        }

        private void ClientConnectionListener()
        {
            Console.WriteLine("[SERVER] Waiting for connections...");
            
            while (true)
            {
                TcpClient client = AcceptTcpClient();
                Thread thread = new(new ParameterizedThreadStart(ClientDataListener));
                _clients.Add((thread, client));
                thread.Start(client);
                Console.WriteLine($"[SERVER] New connection from {client.Client.RemoteEndPoint}.");
            }
        }

        public void Run()
        {
            Start();
            _clientConnectionListener.Start();
            // TODO: ...
        }
    }
}
