using PingPong.Server.Logic.DataParsers.Abstract;
using PingPong.Server.Logic.ResponseHandlers.Abstract;
using PingPong.Server.Presentation.Abstract;

namespace PingPong.Server.Presentation.ResponseHandlers
{
    class OutputAndSendBackResponseHandler : IResponseHandler<string>
    {
        private readonly IOutput<string> _output;

        private readonly IDataParser<string, object> _stringToObjectDataParser;

        private readonly IDataParser<string, byte[]> _stringToByteArrayDataParser;

        public OutputAndSendBackResponseHandler(IOutput<string> output,
                                                IDataParser<string, object> stringToObjectDataParser, 
                                                IDataParser<string, byte[]> stringToByteArrayDataParser)
        {
            _output = output;
            _stringToObjectDataParser = stringToObjectDataParser;
            _stringToByteArrayDataParser = stringToByteArrayDataParser;
        }

        public byte[] HandleData(string data)
        {
            var objectData = _stringToObjectDataParser.Parse(data);

            _output.Output(objectData.ToString());

            var dataBytes = _stringToByteArrayDataParser.Parse(data);

            return dataBytes;
        }
    }
}
