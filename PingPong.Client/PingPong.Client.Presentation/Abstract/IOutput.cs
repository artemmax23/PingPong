namespace PingPong.Client.Presentation.Abstract
{
    public interface IOutput<TOut>
    {
        void Output(TOut output);
    }
}
