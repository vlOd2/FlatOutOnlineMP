using System;
using System.Linq;

namespace FlatOutOnlineMP
{
    internal enum Packet
    {
        LOGIN = 0,
        MESSAGE = 1,
        KICK = 2,
    }

    internal static class PacketUtils
    {
        public static bool IsDefined(int id) => Enum.GetValues(typeof(Packet)).Cast<int>().OrderBy(x => x).Contains(id);
    }
}
