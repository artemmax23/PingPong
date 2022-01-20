namespace PingPong.Server.Presentation.Abstract
{
    public interface IOutput<TOut>
    {
        void Output(TOut output);
    }
}
