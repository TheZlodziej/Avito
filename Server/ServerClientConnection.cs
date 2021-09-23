using Avito.Lib.Networking;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Avito.Lib;

namespace Avito.Server
{
    public class ServerClientConnection : IDisposable
    {
        public string Id { get; private set; }
        public TcpClient Client { get; private set; }
        public Task Task { get; private set; }
        public NetworkStream Stream { get; private set; }
        public StreamWriter Writer { get; private set; }
        public StreamReader Reader { get; private set; }
        public CancellationToken CancellationToken { get; private set; }

        public ServerClientConnection(TcpClient client, CancellationToken cancellationToken)
        {
            Id = Guid.NewGuid().ToString();
            Client = client;
            Stream = client.GetStream();
            Writer = new StreamWriter(Stream, Encoding.UTF8, leaveOpen: true);
            Reader = new StreamReader(Stream, Encoding.UTF8, leaveOpen: true);
            CancellationToken = cancellationToken;
            Task = Task.Run(MessageListener, cancellationToken);
        }

        private void SendResponse(string body)
            => SendResponse(ServerMessage.MessageType.RegularResponse, body);

        private void SendResponse(ServerMessage.MessageType messageType, string body)
        {
            var message = new ServerMessage(messageType, body);
            Writer.WriteLine(message.Serialize());
            Writer.Flush();
        }

        private void MessageListener()
        {
            while (!CancellationToken.IsCancellationRequested && Client.Connected)
            {
                string? messageString = Reader.ReadLine();

                if (messageString != null)
                {
                    ManageIncomingMessages(
                        ClientMessage.Deserialize(
                            Utils.ToUTF8(messageString)
                        )
                    );
                }
            }

            Console.WriteLine($"{Client.Client.RemoteEndPoint} disconnected.");
        }

        private void ManageIncomingMessages(ClientMessage message)
        {
            Console.WriteLine($"New message from {Client.Client.RemoteEndPoint}: {message}");

            switch (message.Header)
            {
                case ClientMessage.MessageType.Connect:
                    SendResponse(ServerMessage.MessageType.ConnectionResponse, Id);
                    break;

                case ClientMessage.MessageType.Disconnect:
                    SendResponse("Bye");
                    Client.Close();
                    break;

                default:
                    SendResponse(ServerMessage.MessageType.UnknownMessage, "I don't recongnize this type of message");
                    break;
            }
        }

        public void Dispose()
        {
            //Stream?.Dispoe();
            //Stream = null;

            Writer?.Dispose();
            Writer = null!;

            Reader?.Dispose();
            Reader = null!;
        }
    }
}
