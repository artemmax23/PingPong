using PingPong.Server.Logic.DataParsers.Abstract;
using System.Text.Json;

namespace PingPong.Server.Logic.DataParsers
{
    public class JsonStringToGenericDataParser<TParseTo> : IDataParser<string, TParseTo>
    {
        public TParseTo Parse(string data)
        {
            return JsonSerializer.Deserialize<TParseTo>(data);
        }
    }
}
