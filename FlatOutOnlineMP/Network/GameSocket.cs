using System;
using System.Net;
using System.Net.Sockets;

namespace FlatOutOnlineMP.Network
{
    internal class GameSocket : IDisposable
    {
        private Socket socket;
        private IPEndPoint target;
        public Action<IPEndPoint, byte[]> OnData;
        public Action<Exception> OnError;

        public void HostMode(string loopback, int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Bind(new IPEndPoint(IPAddress.Parse(loopback), 0));
            UDPHelper.SuppressICMP(socket);
            target = new IPEndPoint(IPAddress.Loopback, port);
            Program.Logger.LogInfo($"Game: host mode {port}");
            UDPHelper.ReceiveUDPLoop(socket, OnData, OnError);
        }

        public int JoinMode()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            socket.Bind(new IPEndPoint(IPAddress.Loopback, 0));
            UDPHelper.SuppressICMP(socket);
            int port = ((IPEndPoint)socket.LocalEndPoint).Port;
            Program.Logger.LogInfo($"Game: join mode {port}");
            UDPHelper.ReceiveUDPLoop(socket, (remote, data) =>
            {
                if (target == null)
                    target = remote;
                OnData(remote, data);
            }, OnError);
            return port;
        }

        public void Send(byte[] data)
        {
            if (target == null)
                throw new InvalidOperationException("Game has not connected, cannot send");
            Program.Logger.LogInfo("" + target);
            socket.SendTo(data, target);
        }

        public void Dispose()
        {
            socket?.Close();
            target = null;
            socket = null;
            OnData = null;
            OnError = null;
        }
    }
}
