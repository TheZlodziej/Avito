using Avito.Lib.Networking;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace Avito.Server
{
    public class Server : TcpListener
    {
        private readonly ConcurrentQueue<Message> _messages = new();
        private readonly Thread _clientConnectionListener;
        private readonly ConcurrentDictionary<TcpClient, Thread> _clients = new();
        public Server() : this(Settings.Server.Host, Settings.Server.Port) { }
        public Server(IPAddress hostname, int port) : base(hostname, port)
        {
            _clientConnectionListener = new Thread(new ThreadStart(ClientConnectionListener));
        }

        private void ClientDataListener(object obj)
        {
            TcpClient client = obj as TcpClient;
            NetworkStream stream = client.GetStream();
            BinaryFormatter formatter = new();

            while (client.Connected)
            {
                Message message = (Message)formatter.Deserialize(stream);
               // Console.WriteLine($"[SERVER] Recieved: {message}");
            }

            _clients.TryRemove(client, out _); // TODO: fix error (when client disconnect it crashes)
        }

        private void ClientConnectionListener()
        {
            Console.WriteLine("[SERVER] Waiting for connections...");
            
            while (true)
            {
                TcpClient client = AcceptTcpClient();
                Thread thread = new(new ParameterizedThreadStart(ClientDataListener));
                if (!_clients.TryAdd(client, thread))
                {
                    Console.WriteLine($"[SERVER] User already exists.");
                    throw new InvalidOperationException();
                }
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
