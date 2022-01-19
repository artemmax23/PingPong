using PingPong.Client.Logic.DataParsers.Abstract;
using System.Text;

namespace PingPong.Client.Logic.DataParsers
{
    public class StringToByteArrayDataParser : IDataParser<string, byte[]>
    {
        public byte[] Parse(string data)
        {
            return Encoding.ASCII.GetBytes(data);
        }
    }
}
