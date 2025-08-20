using System;

namespace FlatOutOnlineMP.Network
{
    internal interface IConnectionHandler : IDisposable
    {
        void HandlePacket(Packet packet);

        void OnConnectionError(Exception ex);

        void OnDisconnect();
    }
}
