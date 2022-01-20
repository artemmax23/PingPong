using PingPong.Client.Presentation.Abstract;
using System;

namespace PingPong.Client
{
    public class ConsoleOutput<TOut> : IOutput<TOut>
    {
        public void Output(TOut output)
        {
            Console.WriteLine(output);
        }
    }
}
