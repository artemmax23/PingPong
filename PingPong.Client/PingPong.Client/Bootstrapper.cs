using PingPong.Client.Logic.Clients;
using PingPong.Client.Logic.Clients.Abstract;
using PingPong.Client.Logic.DataParsers;
using PingPong.Client.Logic.DataParsers.Abstract;
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

            return new SocketClient<string>(socket, stringToDataDataParser, dataToByteArrayDataParser);
        }
    }
}
