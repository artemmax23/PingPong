using PingPong.Logic.DataParsers.Abstract;
using PingPong.Logic.OnDataHandlers.Abstract;

namespace PingPong.Logic.OnDataHandlers
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
