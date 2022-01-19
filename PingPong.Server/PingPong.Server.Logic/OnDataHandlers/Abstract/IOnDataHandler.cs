namespace PingPong.Server.Logic.OnDataHandlers.Abstract
{
    public interface IOnDataHandler<TData>
    {
        byte[] HandleData(TData data);
    }
}
