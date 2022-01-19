using System.Net;

namespace PingPong.Logic.OnDataHandlers.Abstract
{
    public interface IOnDataHandler
    {
        void OnDataFromEndPointEventHandler(byte[] data, IPEndPoint fromIPEndPoint);
    }
}
