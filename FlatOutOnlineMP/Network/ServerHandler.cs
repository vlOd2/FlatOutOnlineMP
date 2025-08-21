using FlatOutOnlineMP.Logger;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace FlatOutOnlineMP.Network
{
    internal class ServerHandler : IConnectionHandler
    {
        private static ILogger Logger => Program.Logger;
        private IServer server;
        private Connection connection;
        private BinaryReader Reader => connection.Reader;
        private BinaryWriter Writer => connection.Writer;
        public bool Disposed;
        public int GUIRowID;
        public string Username;
        private bool isStreaming;
        private string streamLoopback;
        private GameSocket streamSocket;

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

                int streamPort = server.GetStreamPort();
                if (streamPort > 0)
                    StartStreaming(streamPort);

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

                case Packet.STREAM_DATA:
                    {
                        if (!isStreaming)
                        {
                            Logger.LogWarn($"{connection.RemoteAddress} sent stream data, but not streaming");
                            return;
                        }

                        ushort count = Reader.ReadUInt16();
                        if (count > 256)
                        {
                            Kick("Illegal stream data size");
                            return;
                        }

                        byte[] data = Reader.ReadExactly(count);
                        //Logger.LogInfo($"Stream {connection.RemoteAddress} >>> {count} bytes");
                        try
                        {
                            streamSocket.Send(data);
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError($"Stream write error ({connection.RemoteAddress}): {ex}");
                        }

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

        public void SendStreamState(bool state)
        {
            Writer.Write((byte)Packet.STREAM_STATE);
            Writer.Write(state);
            Writer.Flush();
        }

        public void SendStreamData(byte[] data)
        {
            Writer.Write((byte)Packet.STREAM_DATA);
            Writer.Write((ushort)data.Length);
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

        public void StartStreaming(int gamePort)
        {
            if (isStreaming)
                return;
            isStreaming = true;
            SendStreamState(true);
            server.SetHandlerState(this, "STREAMING");
            streamLoopback = LoopbackPool.Allocate();
            streamSocket = new GameSocket() 
            {
                OnData = (_, data) =>
                {
                    if (!isStreaming)
                        return;
                    //Logger.LogInfo($"Stream {connection.RemoteAddress} <<< {data.Length} bytes");
                    SendStreamData(data);
                },
                OnError = (ex) =>
                {
                    if (!isStreaming)
                        return;
                    Logger.LogError($"Stream read error ({connection.RemoteAddress}): {ex}");
                }
            };
            streamSocket.HostMode(streamLoopback, gamePort);
        }

        public void StopStreaming()
        {
            if (!isStreaming)
                return;
            DisposeStream();
            SendStreamState(false);
            server.SetHandlerState(this, "WAITING");
        }

        private void DisposeStream()
        {
            isStreaming = false;
            streamSocket?.Dispose();
            if (streamLoopback != null)
                LoopbackPool.Release(streamLoopback);
            streamLoopback = null;
            streamSocket = null;
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
            DisposeStream();
            connection?.Dispose();
            connection = null;
        }
    }
}
