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
        private readonly Thread _clientDisconnectionListener;
        private readonly HashSet<ServerClientConnection> _clients = new();
        public Server() : this(Settings.Server.Host, Settings.Server.Port) { }
        public Server(IPAddress hostname, int port) : base(hostname, port)
        {
            _clientConnectionListener = new Thread(new ThreadStart(ClientConnectionListener));
            _clientDisconnectionListener = new Thread(new ThreadStart(ClientDisconnectionListener));
        }

        private void ClientDisconnectionListener()
        {
            _clients.RemoveWhere(client => client.Task.IsCompleted);
        }

        private void ClientConnectionListener()
        {
            Console.WriteLine("[SERVER] Waiting for connections...");
            CancellationTokenSource cts = new();

            while (true)
            {
                TcpClient tcpClient = AcceptTcpClient();
                _clients.Add(new ServerClientConnection(tcpClient, cts.Token));
            }

            // unreachable teraz
            // cts.Cancel();
        }

        public void Run()
        {
            Start();
            _clientConnectionListener.Start();
            _clientDisconnectionListener.Start();
            // TODO: ...
        }
    }
}
