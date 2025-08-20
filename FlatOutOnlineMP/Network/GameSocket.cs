using System;
using System.Net;
using System.Net.Sockets;

namespace FlatOutOnlineMP
{
    internal class GameSocket : IDisposable
    {
        private Socket gameSocket;
        public Action<IPEndPoint, byte[]> OnGameData;
        public Action<Exception> OnError;
        private IPEndPoint gameEndpoint;
        public bool HasGame => gameSocket != null;

        private static void ReceiveUDPLoop(Socket socket, Action<IPEndPoint, byte[]> onData, Action<Exception> onError)
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

        public void HostMode(int port)
        {
            gameSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            gameEndpoint = new IPEndPoint(IPAddress.Loopback, port);
            Program.Logger.LogInfo($"Game: host mode {port}");
            ReceiveUDPLoop(gameSocket, OnGameData, OnError);
        }

        public int JoinMode()
        {
            gameSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            gameSocket.Bind(new IPEndPoint(IPAddress.Loopback, 0));
            int port = ((IPEndPoint)gameSocket.LocalEndPoint).Port;
            Program.Logger.LogInfo($"Game: join mode {port}");
            ReceiveUDPLoop(gameSocket, (remote, data) =>
            {
                if (gameEndpoint == null)
                    gameEndpoint = remote;
                OnGameData(remote, data);
            }, OnError);
            return port;
        }

        public void Send(byte[] data)
        {
            if (gameEndpoint == null)
                throw new InvalidOperationException("Game has not connected, cannot send");
            gameSocket.SendTo(data, gameEndpoint);
        }

        public void Close()
        {
            gameSocket?.Close();
            gameSocket = null;
        }

        public void Dispose()
        {
            gameSocket?.Close();
            gameEndpoint = null;
            gameSocket = null;
        }
    }
}
