using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlatOutOnlineMP.Network
{
    internal interface IServer
    {
        bool IsUsernameTaken(string name);

        void BroadcastPacket(Packet packet, byte[] data, params ServerHandler[] exclusions);

        void BroadcastMessage(string msg, params ServerHandler[] exclusions);

        void SetHandlerState(ServerHandler handler, string state);
    }
}
