using PingPong.Client.Logic.Clients.Abstract;
using PingPong.Client.Logic.DataParsers.Abstract;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PingPong.Client.Logic.Clients
{
    public class SocketClient<TData> : IClient<TData>
    {
        private readonly IDataParser<TData, byte[]> _dataToByteArrayDataParser;

        private readonly IDataParser<string, TData> _stringToDataDataParser;

        public SocketClient(Socket socket,
                            IDataParser<string, TData> stringToDataDataParser, 
                            IDataParser<TData, byte[]> dataToByteArrayDataParser)
        {
            _stringToDataDataParser = stringToDataDataParser;
            _dataToByteArrayDataParser = dataToByteArrayDataParser;
            _socket = socket;
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

                if (data.IndexOf("<EOF>") > -1)
                {
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

            _socket.Send(_dataToByteArrayDataParser.Parse(data));

            var recivedData = ListenLoop();

            OnReciveDataEvent?.Invoke(_stringToDataDataParser.Parse(recivedData));
        }

        public void Connect(EndPoint endPoint)
        {
            _socket.Connect(endPoint);
        }
    }
}
