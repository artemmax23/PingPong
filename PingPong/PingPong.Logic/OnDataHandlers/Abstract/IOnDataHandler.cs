using System.Net;

namespace PingPong.Logic.OnDataHandlers.Abstract
{
    public interface IOnDataHandler<TData>
    {
        byte[] HandleData(string data);
    }
}
