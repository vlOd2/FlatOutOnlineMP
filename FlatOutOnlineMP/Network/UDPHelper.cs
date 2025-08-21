using System;
using System.Net;
using System.Net.Sockets;

namespace FlatOutOnlineMP.Network
{
    internal static class UDPHelper
    {
        public const int SIO_UDP_CONNRESET = -1744830452;

        public static void SuppressICMP(Socket socket)
        {
            if (Environment.OSVersion.Platform != PlatformID.Win32NT)
            {
                Program.Logger.LogInfo("Ignoring ICMP suppress (not on Windows)");
                return;
            }
            socket.IOControl((IOControlCode)SIO_UDP_CONNRESET, new byte[] { 0, 0, 0, 0 }, null);
        }

        public static void ReceiveUDPLoop(Socket socket, Action<IPEndPoint, byte[]> onData, Action<Exception> onError)
            => ReceiveUDPLoop(socket, onData, onError, new byte[256]);

        private static void ReceiveUDPLoop(Socket socket, Action<IPEndPoint, byte[]> onData, Action<Exception> onError, byte[] buffer)
        {
            EndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
            socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref endPoint, (result) =>
            {
                int count;
                try
                {
                    count = socket.EndReceiveFrom(result, ref endPoint);
                }
                catch (Exception ex)
                {
                    onError(ex);
                    return;
                }
                byte[] data = new byte[count];
                Buffer.BlockCopy(buffer, 0, data, 0, count);
                onData((IPEndPoint)endPoint, data);
                ReceiveUDPLoop(socket, onData, onError, buffer);
            }, null);
        }
    }
}
