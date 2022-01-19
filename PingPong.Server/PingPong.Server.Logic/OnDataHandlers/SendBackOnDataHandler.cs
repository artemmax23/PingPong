using PingPong.Server.Logic.DataParsers.Abstract;
using PingPong.Server.Logic.OnDataHandlers.Abstract;

namespace PingPong.Server.Logic.OnDataHandlers
{
    public class SendBackOnDataHandler<TData> : IOnDataHandler<TData>
    {
        private readonly IDataParser<TData, byte[]> _dataParser;

        public SendBackOnDataHandler(IDataParser<TData, byte[]> dataParser)
        {
            _dataParser = dataParser;
        }

        public byte[] HandleData(TData data)
        {
            return _dataParser.Parse(data);
        }
    }
}
