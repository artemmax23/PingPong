using PingPong.Client.Common;
using PingPong.Client.Logic.Clients;
using PingPong.Client.Logic.Clients.Abstract;
using PingPong.Client.Logic.DataConverters.Stringifies;
using PingPong.Client.Presentation.OnDataHandlers;
using System.Net.Sockets;

namespace PingPong.Client
{
    public class Bootstrapper
    {
        public IClient<Person> BootstrapClient()
        {
            var tcpClient = new TcpClient();

            var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);

            var byteArrayStringify = new ByteArrayStringify();

            var stringStringify = new StringStringify();

            var genericJsonStringify = new GenericJsonStringify<Person>();

            var socketClient = new TCPClient<Person>(genericJsonStringify, byteArrayStringify, tcpClient);

            var output = new ConsoleOutput();

            var onDataHandler = new StringOutputOnDataHandler<Person>(genericJsonStringify, output);

            socketClient.OnReciveDataEvent += onDataHandler.OnDataEventHandler;

            return socketClient;
        }
    }
}
