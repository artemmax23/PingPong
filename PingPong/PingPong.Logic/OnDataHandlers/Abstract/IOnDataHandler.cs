namespace PingPong.Logic.OnDataHandlers.Abstract
{
    public interface IOnDataHandler<TData>
    {
        byte[] HandleData(TData data);
    }
}
