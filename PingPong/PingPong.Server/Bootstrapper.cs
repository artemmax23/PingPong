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
            var output = new ConsoleOutput<Person>();

            var stringToByteArrayDataParser = new StringToByteArrayDataParser();

            var stringToPersonDataParser = new JsonStringToGenericDataParser<Person>();

            var onDataHandler = new OutputAndSendBackResponseHandler<string, Person>(output, stringToPersonDataParser, stringToByteArrayDataParser);

            var socketServer = new TCPServer(onDataHandler);

            return socketServer;
        }

    }
}
