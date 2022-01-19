namespace PingPong.Client.Logic.OnDataHandlers.Abstract
{
    public interface IOnDataHandler<TData>
    {
        byte[] HandleData(TData data);
    }
}
