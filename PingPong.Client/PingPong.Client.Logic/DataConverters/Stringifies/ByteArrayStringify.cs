using PingPong.Client.Logic.DataConverters.Stringifies.Abstract;
using System.Text;

namespace PingPong.Client.Logic.DataConverters.Stringifies
{
    public class ByteArrayStringify : IStringify<byte[]>
    {
        public string Stringify(byte[] data)
        {
            return Encoding.ASCII.GetString(data);
        }

        public byte[] Parse(string data)
        {
            return Encoding.ASCII.GetBytes(data);
        }
    }
}