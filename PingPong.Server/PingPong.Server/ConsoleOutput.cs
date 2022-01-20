using PingPong.Server.Presentation.Abstract;
using System;

namespace PingPong.Client
{
    public class ConsoleOutput : IOutput<string>
    {
        public void Output(string output)
        {
            Console.WriteLine(output);
        }
    }
}
