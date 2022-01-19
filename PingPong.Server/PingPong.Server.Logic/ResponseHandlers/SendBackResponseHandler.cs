using PingPong.Server.Logic.DataParsers.Abstract;
using PingPong.Server.Logic.ResponseHandlers.Abstract;

namespace PingPong.Server.Logic.ResponseHandlers
{
    public class SendBackResponseHandler<TData> : IResponseHandler<TData>
    {
        private readonly IDataParser<TData, byte[]> _dataParser;

        public SendBackResponseHandler(IDataParser<TData, byte[]> dataParser)
        {
            _dataParser = dataParser;
        }

        public byte[] HandleData(TData data)
        {
            return _dataParser.Parse(data);
        }
    }
}
