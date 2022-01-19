using PingPong.Client.Logic.DataConverters.Abstract;

namespace PingPong.Client.Logic.DataConverters.Stringifies.Abstract
{
    public interface IStringify<TData> : IDataConverter<string, TData>
    {
        string Stringify(TData data);
    }
}