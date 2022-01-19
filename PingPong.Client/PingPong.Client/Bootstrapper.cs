using PingPong.Client.Logic.Clients;
using PingPong.Client.Logic.Clients.Abstract;
using PingPong.Client.Logic.DataParsers;
using PingPong.Client.Logic.DataParsers.Abstract;
using PingPong.Client.Presentation.OnDataHandlers;
using System.Net.Sockets;

namespace PingPong.Client
{
    public class Bootstrapper
    {
        public IClient<string> BootstrapStringSocketClient()
        {
            var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);

            IDataParser<string, byte[]> dataToByteArrayDataParser = new StringToByteArrayDataParser();

            IDataParser<string, string> stringToDataDataParser = new StringToStringDataParser();

            var output = new ConsoleOutput();

            IDataParser<string, string> stringToOutputDataParser = stringToDataDataParser;

            var onDataHandler = new OutputOnDataHandler<string, string>(stringToDataDataParser, output);
            
            var socketClient = new SocketClient<string>(socket, stringToDataDataParser, dataToByteArrayDataParser);

            socketClient.OnReciveDataEvent += onDataHandler.OnDataEventHandler;

            return socketClient;
        }
    }
}
