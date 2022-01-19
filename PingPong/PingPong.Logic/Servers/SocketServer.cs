﻿using PingPong.Logic.OnDataHandlers.Abstract;
using PingPong.Logic.Servers.Abstract;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.Logic.Servers
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
