using PingPong.Client.Logic.DataParsers.Abstract;
using PingPong.Client.Logic.OnDataHandlers.Abstract;
using PingPong.Client.Presentation.Abstract;

namespace PingPong.Client.Presentation.OnDataHandlers
{
    public class OutputOnDataHandler<TData, TOut> : IOnDataHandler<TData>
    {
        private readonly IOutput<TOut> _output;

        private readonly IDataParser<TData, TOut> _dataParser;

        public OutputOnDataHandler(IDataParser<TData, TOut> dataParser, IOutput<TOut> output)
        {
            _dataParser = dataParser;
            _output = output;
        }

        public void OnDataEventHandler(TData data)
        {
            _output.Output(_dataParser.Parse(data));
        }
    }
}
