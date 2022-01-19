using System.Net;

namespace PingPong.Server.Logic.Servers.Abstract
{
    public interface IServer
    {
        void RunOn(EndPoint endPoint);
    }
}
