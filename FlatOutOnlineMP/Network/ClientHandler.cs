using FlatOutOnlineMP.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace FlatOutOnlineMP.Network
{
    internal class ClientHandler : IConnectionHandler
    {
        private static ILogger Logger => Program.Logger;
        private Connection connection;
        private bool disposed;
        public Action OnLoggedin;
        public Action OnDisposed;
        private BinaryReader Reader => connection.Reader;
        private BinaryWriter Writer => connection.Writer;

        public ClientHandler(Connection connection)
        {
            this.connection = connection;
            connection.Handler = this;
            connection.Start();
        }

        public void HandlePacket(Packet packet)
        {
            switch (packet)
            {
                case Packet.LOGIN:
                    {
                        OnLoggedin?.Invoke();
                        OnLoggedin = null;
                        break;
                    }

                case Packet.MESSAGE:
                    {
                        Logger.LogInfo(Reader.ReadASCIIStr());
                        break;
                    }

                case Packet.KICK:
                    {
                        string reason = Reader.ReadASCIIStr();
                        Dispose();
                        Logger.LogShowError($"Kicked by server: {reason}", "Kicked");
                        break;
                    }
            }
        }

        public void SendPacket(Packet packet, byte[] data)
        {
            Writer.Write((byte)packet);
            Writer.Write(data);
            Writer.Flush();
        }

        public void SendLoginPacket(string username)
        {
            Writer.Write((byte)Packet.LOGIN);
            Writer.WriteASCIIStr(username, 16);
            Writer.Flush();
        }

        public void SendMessagePacket(string content)
        {
            Writer.Write((byte)Packet.MESSAGE);
            Writer.WriteASCIIStr(content, 255);
            Writer.Flush();
        }

        public void OnConnectionError(Exception ex)
        {
            Logger.LogError($"Connection error: {ex}");
            Dispose();
        }

        public void OnDisconnect()
        {
            Logger.LogInfo("Server disconnect");
            Dispose();
        }

        public void Dispose()
        {
            if (disposed)
                return;
            disposed = true;
            OnDisposed?.Invoke();
            connection?.Dispose();
            connection = null;
        }
    }
}
