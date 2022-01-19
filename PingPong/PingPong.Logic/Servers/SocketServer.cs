using PingPong.Logic.OnDataHandlers.Abstract;
using PingPong.Logic.Servers.Abstract;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Logic.Servers
{
    public class SocketServer : IServer
    {
        private readonly IOnDataHandler<string> _onDataHandler;

        private void Reply(byte[] message, Socket handlerSocket)
        {
            handlerSocket.Send(message);
        }

        private void Listen(Task<Socket> socketTask)
        {
            var handlerSocket = socketTask.Result;

            while (handlerSocket.Connected)
            {
                var data = string.Empty;

                while (true)
                {
                    byte[] bytes = new byte[1024];
                    int bytesReceived = handlerSocket.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesReceived);

                    if (data.IndexOf("<EOF>") > -1)
                    {
                        break;
                    }
                }

                Reply(_onDataHandler.HandleData(data), handlerSocket);
            }

            handlerSocket.Shutdown(SocketShutdown.Both);
            handlerSocket.Close();
        }

        public async Task RunOn(int port)
        {
            var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            var endPoint = new DnsEndPoint("127.0.0.1", port);

            socket.Bind(endPoint);

            socket.Listen(100);

            while (true)
            {
                await socket.AcceptAsync().ContinueWith(Listen);
            }
        }
    }
}
