using System;
using System.Net;

namespace PingPong.Logic.DataListeners.Abstract
{
    public interface IDataListener
    {
        Action<byte[], IPEndPoint> OnDataFromEndPoint { get; set; }
    }

    public interface IDataSender
    {

    }
}
