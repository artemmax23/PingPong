using System.Net;

namespace PingPong
{
    class Program
    {
        static void Main(string[] args)
        {
            var endPoint = new DnsEndPoint("127.0.0.1", int.Parse(args[0]));

            var bootstrapper = new Bootstrapper();

            var socketServer = bootstrapper.BootstrapSocketSever();

            socketServer.RunOn(endPoint).GetAwaiter().GetResult();
        }
    }
}
