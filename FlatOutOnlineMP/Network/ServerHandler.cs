using FlatOutOnlineMP.Logger;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace FlatOutOnlineMP.Network
{
    internal class ServerHandler : IConnectionHandler
    {
        private static ILogger Logger => Program.Logger;
        private IServer server;
        private Connection connection;
        public bool Disposed;
        public int GUIRowID;
        public string Username;
        private BinaryReader Reader => connection.Reader;
        private BinaryWriter Writer => connection.Writer;

        public ServerHandler(IServer server, Connection connection) 
        {
            this.server = server;
            this.connection = connection;
            connection.Handler = this;
            connection.Start();
            Logger.LogInfo($"{connection.RemoteAddress} has connected");
        }

        public void HandlePacket(Packet packet)
        {
            if (Username == null)
            {
                if (packet != Packet.LOGIN)
                {
                    Kick("Illegal packet");
                    return;
                }
                string name = Regex.Replace(Reader.ReadASCIIStr(32), @"[^a-zA-Z0-9_]", "");
                if (server.IsUsernameTaken(name))
                {
                    Kick("Username already taken");
                    return;
                }
                Username = name;
                server.SetHandlerState(this, "WAITING");
                Writer.Write((byte)Packet.LOGIN);
                Writer.Flush();
                return;
            }

            switch (packet)
            {
                case Packet.MESSAGE:
                    {
                        string msg = Reader.ReadASCIIStr();
                        string formatted = $"{Username}: {msg}";
                        if (formatted.Length > 255)
                            formatted = formatted.Substring(0, 255);
                        server.BroadcastMessage(formatted);
                        Logger.LogInfo(formatted);
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

        public void Kick(string reason)
        {
            Writer.Write((byte)Packet.KICK);
            Writer.WriteASCIIStr(reason);
            Writer.Flush();
            Logger.LogInfo($"Kicked {connection.RemoteAddress}: {reason}");
            Dispose();
        }

        public void OnConnectionError(Exception ex)
        {
            Logger.LogError($"Connection error with {connection.RemoteAddress}: {ex}");
            Dispose();
        }

        public void OnDisconnect()
        {
            Logger.LogInfo($"{connection.RemoteAddress} has disconnected");
            Dispose();
        }

        public void Dispose()
        {
            if (Disposed)
                return;
            Disposed = true;
            connection?.Dispose();
            connection = null;
        }
    }
}
