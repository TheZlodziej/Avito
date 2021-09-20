using Avito.Lib.Networking;
using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Avito.Server
{
    public class ServerClientConnection : IDisposable
    {
        public TcpClient Client { get; private set; }
        public Task Task { get; private set; }
        public NetworkStream Stream { get; private set; }
        public StreamWriter Writer { get; private set; }
        public StreamReader Reader { get; private set; }
        public CancellationToken CancellationToken { get; private set; }

        public ServerClientConnection(TcpClient client, CancellationToken cancellationToken)
        {
            Console.WriteLine($"NEW CONNECTION: {client.Client.RemoteEndPoint}");
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
                try
                {
                    var stream = Client.GetStream();
                    Console.WriteLine("reading message");

                    byte[] buff = new byte[30000];
                    int pos = 0;

                    while (pos == 0 || buff[pos - 1] != '\n')
                    {
                        int ret = stream.ReadByte();
                        if (ret == -1)
                        {
                            Console.WriteLine($"MessageListener: end of stream");
                        }

                        buff[pos++] = (byte)ret;
                    }

                    string? messageString = Encoding.UTF8.GetString(buff.AsSpan().Slice(0, pos));
                    messageString = messageString.Trim();

                    //string? messageString = Reader.ReadLine();
                    //if (messageString == null)
                    //{
                    //    Console.WriteLine("INFO: Finished client func");
                    //    break;
                    //}

                    ClientMessage message = ClientMessage.Deserialize(messageString);
                    Console.WriteLine($"GOT MESSAGE: {message}");

                    if (message.Header == ClientMessage.MessageType.Disconnect)
                    {
                        SendResponse("Bye");
                        Console.WriteLine($"{Client.Client.RemoteEndPoint} gently asked to disconnect.");
                        break;
                    }

                    SendResponse("dupa");
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: Exiting client func with:");
                    Console.WriteLine($"{e}");
                }
            }

            Console.WriteLine($"{Client.Client.RemoteEndPoint} disconnected.");
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
