using System;
using System.Collections.Generic;
using System.Text;

namespace MobileApp.Data
{
    public interface INetWorkConnection
    {
        bool IsConnected { get; }
        void CheckNetworkConnection();
    }
}
