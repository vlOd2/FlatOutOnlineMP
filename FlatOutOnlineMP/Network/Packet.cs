using System;
using System.Linq;

namespace FlatOutOnlineMP.Network
{
    internal enum Packet
    {
        LOGIN = 0,
        MESSAGE = 1,
        KICK = 2,
        STREAM_STATE = 3,
        STREAM_DATA = 4,
    }

    internal static class PacketUtils
    {
        public static bool IsDefined(int id) => Enum.GetValues(typeof(Packet)).Cast<int>().OrderBy(x => x).Contains(id);
    }
}
