using System;
using System.Collections.Generic;
using System.Linq;

namespace FlatOutOnlineMP.Network
{
    internal static class LoopbackPool
    {
        private static readonly Random random = new Random();
        private static readonly object lockObj = new object();
        private static readonly HashSet<string> allocated = new HashSet<string>();
        private static readonly HashSet<string> released = new HashSet<string>();

        public static string Allocate()
        {
            lock (lockObj)
            {
                string ip;

                if (released.Count > 0)
                {
                    ip = released.Last();
                    released.Remove(ip);
                    allocated.Add(ip);
                    Program.Logger.LogInfo($"Allocated loopback address: {ip}");
                    return ip;
                }

                do
                {
                    ip = $"127.0.0.{random.Next(1, 255)}";
                } while (allocated.Contains(ip));

                allocated.Add(ip);
                Program.Logger.LogInfo($"Created loopback address: {ip}");

                return ip;
            }
        }

        public static void Release(string ip)
        {
            lock (lockObj)
            {
                allocated.Remove(ip);
                released.Add(ip);
                Program.Logger.LogInfo($"Released loopback address: {ip}");
            }
        }
    }
}
