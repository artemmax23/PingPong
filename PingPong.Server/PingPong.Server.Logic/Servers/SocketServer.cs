using PingPong.Server.Logic.OnDataHandlers.Abstract;
using PingPong.Server.Logic.Servers.Abstract;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Server.Logic.Servers
{
    public class SocketServer : IServer
    {
        private readonly Socket _socket;

        private readonly IOnDataHandler<string> _onDataHandler;

        public SocketServer(IOnDataHandler<string> onDataHandler, Socket socket)
        {
            _socket = socket;
            _onDataHandler = onDataHandler;
        }

        ~SocketServer()
        {
            if (!(_socket is null))
            {
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Close();
            }
        }

        private void Reply(byte[] message, Socket handlerSocket)
        {
            handlerSocket.Send(message);
        }

        private string ListenLoop(Socket handlerSocket)
        {
            var data = string.Empty;

            while (true)
            {
                var bytes = new byte[1024];
                var bytesReceived = handlerSocket.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesReceived);

                if (data.IndexOf("<EOF>") > -1)
                {
                    break;
                }
            }

            return data;
        }

        private void Listen(Task<Socket> socketTask)
        {
            var handlerSocket = socketTask.Result;

            while (handlerSocket.Connected)
            {
                var data = ListenLoop(handlerSocket);

                Reply(_onDataHandler.HandleData(data), handlerSocket);
            }

            handlerSocket.Shutdown(SocketShutdown.Both);
            handlerSocket.Close();
        }

        public async Task RunOn(EndPoint endPoint)
        {
            _socket.Bind(endPoint);

            _socket.Listen(100);

            while (true)
            {
                await _socket.AcceptAsync().ContinueWith(Listen);
            }
        }
    }
}
