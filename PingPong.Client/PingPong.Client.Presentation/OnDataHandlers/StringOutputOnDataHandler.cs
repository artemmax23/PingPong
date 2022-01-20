using PingPong.Client.Logic.DataConverters.Stringifies.Abstract;
using PingPong.Client.Logic.OnDataHandlers.Abstract;
using PingPong.Client.Presentation.Abstract;

namespace PingPong.Client.Presentation.OnDataHandlers
{
    public class StringOutputOnDataHandler<TData> : IOnDataHandler<TData>
    {
        private readonly IOutput<string> _output;

        private readonly IStringify<TData> _dataStringify;

        public StringOutputOnDataHandler(IStringify<TData> dataStringify, IOutput<string> output)
        {
            _dataStringify = dataStringify;
            _output = output;
        }

        public void OnDataEventHandler(TData data)
        {
            _output.Output(_dataStringify.Stringify(data));
        }
    }
}
