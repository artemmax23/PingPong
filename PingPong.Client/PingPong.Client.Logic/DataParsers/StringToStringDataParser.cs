using PingPong.Client.Logic.DataParsers.Abstract;

namespace PingPong.Client.Logic.DataParsers
{
    public class StringToStringDataParser : IDataParser<string, string>
    {
        public string Parse(string data)
        {
            return data;
        }
    }
}
