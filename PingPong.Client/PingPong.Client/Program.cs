using System;
using System.Net;

namespace PingPong.Client
{
    class Program
    {
        static void Main()
        {
            var bootstrapper = new Bootstrapper();

            var socketClient = bootstrapper.BootstrapStringSocketClient();

            var endPoint = new DnsEndPoint(Console.ReadLine(), int.Parse(Console.ReadLine()));

            socketClient.Connect(endPoint);

            while (true)
            {
                socketClient.SendData(Console.ReadLine());
            }
        }
    }
}
