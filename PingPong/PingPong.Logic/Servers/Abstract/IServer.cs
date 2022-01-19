using System.Net;
using System.Threading.Tasks;

namespace PingPong.Logic.Servers.Abstract
{
    public interface IServer
    {
        Task RunOn(EndPoint endPoint);
    }
}
