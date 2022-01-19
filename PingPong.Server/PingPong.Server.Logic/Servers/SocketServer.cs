using PingPong.Server.Logic.ResponseHandlers.Abstract;
using PingPong.Server.Logic.Servers.Abstract;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Server.Logic.Servers
{
    public class SocketServer : IServer
    {
        private readonly Socket _socket;

        private readonly IResponseHandler<string> _onDataHandler;

        public SocketServer(IResponseHandler<string> onDataHandler, Socket socket)
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
            Console.WriteLine($"sending data to client. client {handlerSocket.RemoteEndPoint}");

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

                Console.WriteLine($"recived part of a message {data}");

                if (data.IndexOf("<EOF>") > -1)
                {
                    break;
                }
            }

            return data;
        }

        private void Listen(Task<Socket> socketTask)
        {
            Console.WriteLine("connection made, now listening...");
            var handlerSocket = socketTask.Result;

            while (handlerSocket.Connected)
            {
                var data = ListenLoop(handlerSocket);

                Console.WriteLine($"got data from client. client {handlerSocket.RemoteEndPoint} data {data}");
                Reply(_onDataHandler.HandleData(data), handlerSocket);
            }

            Console.WriteLine($"closing connection with client. client {handlerSocket.RemoteEndPoint}");

            handlerSocket.Shutdown(SocketShutdown.Both);
            handlerSocket.Close();
        }

        public async Task RunOn(EndPoint endPoint)
        {
            _socket.Bind(endPoint);

            _socket.Listen(100);

            while (true)
            {
                Console.WriteLine("waiting for connection...");
                await _socket.AcceptAsync().ContinueWith(Listen);
            }
        }
    }
}
