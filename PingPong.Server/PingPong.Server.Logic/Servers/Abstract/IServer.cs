using System.Net;
using System.Threading.Tasks;

namespace PingPong.Server.Logic.Servers.Abstract
{
    public interface IServer
    {
        Task RunOn(EndPoint endPoint);
    }
}
