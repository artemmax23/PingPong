using PingPong.Client.Logic.Clients.Abstract;
using System;
using System.Net;
using System.Net.Sockets;

namespace PingPong.Client.Logic.Clients
{
    public class SocketClient<TData> : IClient<TData>
    {
        private readonly Socket _socket;

        public Action<TData> OnReciveDataEvent { get; set; }

        public SocketClient(Socket socket)
        {
            _socket = socket;
        }

        public void SendData(TData data)
        {
            if (_socket is null)
            {
                return;
            }

            var bytes = new byte[1024];

            _socket.Send(bytes);

            OnReciveDataEvent?.Invoke(default);
        }

        public void Connect(EndPoint endPoint)
        {
            _socket.Connect(endPoint);
        }
    }
}
