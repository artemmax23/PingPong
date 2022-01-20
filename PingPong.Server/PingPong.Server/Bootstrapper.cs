using PingPong.Server.Logic.DataParsers;
using PingPong.Server.Presentation.ResponseHandlers;
using PingPong.Server.Logic.Servers;
using PingPong.Server.Logic.Servers.Abstract;
using System.Net.Sockets;
using PingPong.Server.Common;

namespace PingPong.Server
{
    public class Bootstrapper
    {
        public IServer BootstrapSocketSever()
        {
            var output = new ConsoleOutput<JSONPerson>();

            var stringToByteArrayDataParser = new StringToByteArrayDataParser();

            var stringToPersonDataParser = new JsonStringToGenericDataParser<JSONPerson>();

            var onDataHandler = new OutputAndSendBackResponseHandler<string, JSONPerson>(output, stringToPersonDataParser, stringToByteArrayDataParser);

            var socketServer = new TCPServer(onDataHandler);

            return socketServer;
        }

    }
}
