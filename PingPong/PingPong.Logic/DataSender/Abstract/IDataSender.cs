using System.Net;

namespace PingPong.Logic.DataSender.Abstract
{
    public interface IDataSender
    {
        void SendDataToEndPoint(byte[] data, IPEndPoint ipEndPointToSendTo);
    }
}
