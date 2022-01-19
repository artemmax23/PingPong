using PingPong.Client.Logic.Clients.Abstract;
using PingPong.Client.Logic.DataConverters.Stringifies.Abstract;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PingPong.Client.Logic.Clients
{
    public class SocketClient<TData> : IClient<TData>
    {
        private readonly IStringify<TData> _stringify;

        private readonly IStringify<byte[]> _byteArrayStringify;

        public SocketClient(Socket socket,
                            IStringify<TData> stringify,
                            IStringify<byte[]> byteArrayStringify)
        {
            _socket = socket;
            _stringify = stringify;
            _byteArrayStringify = byteArrayStringify;
        }

        ~SocketClient()
        {
            _socket.Shutdown(SocketShutdown.Both);
            _socket.Close();
        }

        private readonly Socket _socket;

        public Action<TData> OnReciveDataEvent { get; set; }

        private string ListenLoop()
        {
            var data = string.Empty;

            while (true)
            {
                var bytes = new byte[1024];
                var bytesReceived = _socket.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesReceived);

                if (data.Contains((char)4))
                {
                    data = data.Substring(0, data.Length - 1);
                    break;
                }
            }

            return data;
        }

        public void SendData(TData data)
        {
            if (_socket is null)
            {
                return;
            }

            var stringifiedData = _stringify.Stringify(data);

            var byteData = _byteArrayStringify.Parse(stringifiedData + (char)4);

            _socket.Send(byteData);

            var recivedData = ListenLoop();

            var parsedRecivedData = _stringify.Parse(recivedData);

            OnReciveDataEvent?.Invoke(parsedRecivedData);
        }

        public void Connect(EndPoint endPoint)
        {
            _socket.Connect(endPoint);
        }
    }
}
