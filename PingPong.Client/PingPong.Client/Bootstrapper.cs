using PingPong.Client.Logic.Clients;
using PingPong.Client.Logic.Clients.Abstract;
using PingPong.Client.Logic.DataConverters.Stringifies;
using PingPong.Client.Presentation.OnDataHandlers;
using System.Net.Sockets;

namespace PingPong.Client
{
    public class Bootstrapper
    {
        public IClient<string> BootstrapStringSocketClient()
        {
            var tcpClient = new TcpClient();

            var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);

            var byteArrayStringify = new ByteArrayStringify();

            var stringStringify = new StringStringify();

            var socketClient = new TCPClient<string>(stringStringify, byteArrayStringify, tcpClient);

            var output = new ConsoleOutput();

            var onDataHandler = new OutputOnDataHandler<string, string>(stringStringify, output);

            socketClient.OnReciveDataEvent += onDataHandler.OnDataEventHandler;

            return socketClient;
        }
    }
}
