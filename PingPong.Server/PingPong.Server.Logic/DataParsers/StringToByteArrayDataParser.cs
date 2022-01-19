using PingPong.Server.Logic.DataParsers.Abstract;
using System.Text;

namespace PingPong.Server.Logic.DataParsers
{
    public class StringToByteArrayDataParser : IDataParser<string, byte[]>
    {
        public byte[] Parse(string data)
        {
            return Encoding.ASCII.GetBytes(data);
        }
    }
}
