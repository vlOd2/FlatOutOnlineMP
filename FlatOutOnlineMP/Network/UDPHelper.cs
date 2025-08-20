using System;
using System.Net;
using System.Net.Sockets;

namespace FlatOutOnlineMP.Network
{
    internal static class UDPHelper
    {
        public static void ReceiveUDPLoop(Socket socket, Action<IPEndPoint, byte[]> onData, Action<Exception> onError)
            => ReceiveUDPLoop(socket, onData, onError, new byte[256]);

        private static void ReceiveUDPLoop(Socket socket, Action<IPEndPoint, byte[]> onData, Action<Exception> onError, byte[] buffer)
        {
            IPEndPoint remoteEndpoint = new IPEndPoint(IPAddress.Any, 0);
            EndPoint endPoint = remoteEndpoint;
            socket.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref endPoint, (result) =>
            {
                int count;
                try
                {
                    count = socket.EndReceive(result);
                }
                catch (Exception ex)
                {
                    onError(ex);
                    return;
                }
                byte[] data = new byte[count];
                Buffer.BlockCopy(buffer, 0, data, 0, count);
                onData(remoteEndpoint, data);
                ReceiveUDPLoop(socket, onData, onError, buffer);
            }, null);
        }
    }
}
