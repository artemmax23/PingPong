﻿namespace PingPong.Client.Logic.OnDataHandlers.Abstract
{
    public interface IOnDataHandler<TData>
    {
        void OnDataEventHandler(TData data);
    }
}
