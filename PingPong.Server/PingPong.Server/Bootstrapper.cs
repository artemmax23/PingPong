using PingPong.Server.Logic.DataParsers;
using PingPong.Server.Logic.ResponseHandlers;
using PingPong.Server.Logic.Servers;
using PingPong.Server.Logic.Servers.Abstract;
using System.Net.Sockets;

namespace PingPong
{
    public class Bootstrapper
    {
        public IServer BootstrapSocketSever()
        {
            var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);

            var dataParser = new StringToByteArrayDataParser();

            var onDataHandler = new SendBackResponseHandler<string>(dataParser);

            var socketServer = new SocketServer(onDataHandler, socket);

            return socketServer;
        }

    }
}
