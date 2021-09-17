using Avito.Lib.Networking;
using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Threading;

namespace Avito.Server
{
    public class Server : TcpListener
    {
        //private readonly ConcurrentQueue<Message> _messages = new();
        private readonly Thread _clientConnectionListener;
        private readonly ConcurrentDictionary<TcpClient, Thread> _clients = new();
        public Server() : this(Settings.Server.Host, Settings.Server.Port) { }
        public Server(IPAddress hostname, int port) : base(hostname, port)
        {
            _clientConnectionListener = new Thread(new ThreadStart(ClientConnectionListener));
        }

        private void SendMessageToClients(Message message)
        {
            DataContractSerializer serializer = new(typeof(Message));

            foreach (var client in _clients)
            {
                NetworkStream stream = client.Key.GetStream();
                serializer.WriteObject(stream, message);
                Console.WriteLine($"[SERVER] Sending {message} to {client.Key.Client.RemoteEndPoint}");
            }
        }

        private void ClientDataListener(object obj)
        {
            TcpClient client = obj as TcpClient;
            NetworkStream stream = client.GetStream();
            DataContractSerializer serializer = new(typeof(Message));
            while (client.Connected)
            {
                try
                {
                    Message message = (Message)serializer.ReadObject(stream);
                    Console.WriteLine($"[SERVER] Recieved: {message}");

                    SendMessageToClients(message);
                }
                catch
                {
                    client.Close();
                }
            }

            _clients.TryRemove(client, out _);
            Console.WriteLine($"[SERVER] Client disconnected. Remaining clients {_clients.Count}");
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
