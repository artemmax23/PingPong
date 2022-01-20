using PingPong.Server.Logic.DataParsers.Abstract;
using PingPong.Server.Logic.ResponseHandlers.Abstract;
using PingPong.Server.Presentation.Abstract;

namespace PingPong.Server.Presentation.ResponseHandlers
{
    public class OutputAndSendBackResponseHandler<TData, TOut> : IResponseHandler<TData>
    {
        private readonly IOutput<TOut> _output;

        private readonly IDataParser<TData, TOut> _dataToOutDataParser;

        private readonly IDataParser<TData, byte[]> _dataToByteArrayDataParser;

        public OutputAndSendBackResponseHandler(IOutput<TOut> output,
                                                IDataParser<TData, TOut> dataToOutDataParser,
                                                IDataParser<TData, byte[]> dataToByteArrayDataParser)
        {
            _output = output;
            _dataToOutDataParser = dataToOutDataParser;
            _dataToByteArrayDataParser = dataToByteArrayDataParser;
        }

        public byte[] HandleData(TData data)
        {
            var outData = _dataToOutDataParser.Parse(data);

            _output.Output(outData);

            var dataBytes = _dataToByteArrayDataParser.Parse(data);

            return dataBytes;
        }
    }
}
