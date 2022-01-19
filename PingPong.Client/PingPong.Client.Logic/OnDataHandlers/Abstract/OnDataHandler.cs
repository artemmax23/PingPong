namespace PingPong.Client.Logic.OnDataHandlers.Abstract
{
    public interface OnDataHandler<TData>
    {
        void OnDataEventHandler(TData data); 
    }
}
