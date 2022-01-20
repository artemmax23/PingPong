using PingPong.Server.Presentation.Abstract;
using System;

namespace PingPong.Server
{
    public class ConsoleOutput<TOut> : IOutput<TOut>
    {
        public void Output(TOut output)
        {
            Console.WriteLine(output);
        }
    }
}
