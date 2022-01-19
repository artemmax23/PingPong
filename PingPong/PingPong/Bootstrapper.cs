using PingPong.Logic.DataParsers;
using PingPong.Logic.OnDataHandlers;
using PingPong.Logic.Servers;
using PingPong.Logic.Servers.Abstract;
using System.Net.Sockets;

namespace PingPong
{
    public class Bootstrapper
    {
        public IServer BootstrapSocketSever()
        {
            var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);

            var dataParser = new StringToByteArrayDataParser();

            var onDataHandler = new SendBackOnDataHandler<string>(dataParser);

            var socketServer = new SocketServer(onDataHandler, socket);

            return socketServer;
        }

    }
}
