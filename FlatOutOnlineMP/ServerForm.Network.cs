using FlatOutOnlineMP.Network;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace FlatOutOnlineMP
{
    internal partial class ServerForm : IServer
    {
        private bool isListening;
        private Socket listener;
        private List<ServerHandler> clients = new List<ServerHandler>();
        private bool isStreaming;
        private int streamPort;

        private void PopulateAddresses()
        {
            foreach (NetworkInterface interf in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (interf.IsReceiveOnly)
                    continue;
                foreach (UnicastIPAddressInformation addrInfo in interf.GetIPProperties().UnicastAddresses)
                {
                    if (addrInfo.Address.AddressFamily != AddressFamily.InterNetwork)
                        continue;
                    InfoTree.TopNode.Nodes["addresses"].Nodes.Add(addrInfo.Address.ToString());
                }
            }
        }

        private void Listen(int port)
        {
            isListening = true;
            CleanupTimer.Start();
            SetStatus("Listening", Color.Green);

            ListenPortNUPD.Enabled = false;
            ChatMsgBox.Enabled = true;
            StreamButton.Enabled = true;
            ListenButton.Text = "Stop listening";
            
            try
            {
                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(new IPEndPoint(IPAddress.Any, port));
                listener.Listen(8);
                listener.BeginAccept(ListenCallback, null);
            }
            catch (Exception ex)
            {
                Cleanup();
                Logger.LogShowError($"Failed to start listener: {ex}");
                return;
            }

            int listenPort = ((IPEndPoint)listener.LocalEndPoint).Port;
            Logger.LogInfo($"Listening on port {listenPort}");
            InfoTree.TopNode.Nodes["port"].Nodes.Add("" + listenPort);
            PopulateAddresses();
            InfoTree.ExpandAll();
        }

        private void ListenCallback(IAsyncResult result)
        {
            Socket client;
            try
            {
                client = listener.EndAccept(result);
                listener.BeginAccept(ListenCallback, null);
            }
            catch (Exception ex)
            {
                if (!isListening)
                    return;
                Cleanup();
                Logger.LogError(ex);
                return;
            }

            Connection connection = new Connection(client);
            try
            {
                if (connection.Reader.ReadUInt32() != MainForm.CLIENT_MAGIC)
                    throw new IOException("Invalid client magic");
                connection.Writer.Write(MainForm.SERVER_MAGIC);
                connection.Writer.Flush();

                ServerHandler handler = new ServerHandler(this, connection);
                lock (clients)
                    clients.Add(handler);

                this.InvokeIfRequired(() =>
                {
                    lock (PlayersDGV)
                        handler.GUIRowID = PlayersDGV.Rows.Add("LOGIN", "(none)", connection.RemoteAddress.ToString());
                });
            }
            catch (Exception ex)
            {
                Logger.LogError($"Handshaking failed ({connection.RemoteAddress}): {ex}");
                connection.Dispose();
            }
        }

        private void CleanupTimer_Tick(object sender, EventArgs e)
        {
            if (!isListening)
                return;

            lock (clients)
            {
                for (int i = clients.Count - 1; i >= 0; i--)
                {
                    ServerHandler handler = clients[i];
                    if (!handler.Disposed)
                        continue;
                    clients.RemoveAt(i);
                    this.InvokeIfRequired(() =>
                    {
                        lock (PlayersDGV)
                            PlayersDGV.Rows.RemoveAt(handler.GUIRowID);
                    });
                }
            }
        }

        private void Cleanup()
        {
            this.InvokeIfRequired(() =>
            {
                isListening = false;
                CleanupTimer.Stop();
                SetStatus("Not listening", Color.Red);

                StopStream();
                foreach (ServerHandler handler in clients)
                    handler.Dispose();
                clients.Clear();
                listener?.Close();
                listener = null;

                ListenPortNUPD.Enabled = true;
                StreamButton.Enabled = false;
                StartGameButton.Enabled = false;
                ChatMsgBox.Enabled = false;
                SendMsgButton.Enabled = false;
                ListenButton.Text = "Start listening";
                ChatMsgBox.Text = "";

                InfoTree.TopNode.Nodes["addresses"].Nodes.Clear();
                InfoTree.TopNode.Nodes["port"].Nodes.Clear();
                PlayersDGV.Rows.Clear();
            });
        }

        bool IServer.IsUsernameTaken(string name)
        {
            lock (clients)
            {
                foreach (ServerHandler handler in clients)
                {
                    if (handler.Username != null && handler.Username.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                        return true;
                }
                return false;
            }
        }

        void IServer.BroadcastPacket(Packet packet, byte[] data, params ServerHandler[] exclusions) 
        {
            lock (clients) 
            {
                foreach (ServerHandler handler in clients)
                {
                    if (handler.Username == null || exclusions.Contains(handler))
                        continue;
                    handler.SendPacket(packet, data);
                }
            }
        }

        void IServer.BroadcastMessage(string msg, params ServerHandler[] exclusions)
        {
            MemoryStream stream = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(stream);
            writer.WriteASCIIStr(msg, 255);
            writer.Close();
            ((IServer)this).BroadcastPacket(Packet.MESSAGE, stream.ToArray(), exclusions);
        }

        void IServer.SetHandlerState(ServerHandler handler, string state)
        {
            if (handler.Disposed)
                return;
            lock (PlayersDGV)
            {
                PlayersDGV.Rows[handler.GUIRowID].Cells["state"].Value = state;
                PlayersDGV.Rows[handler.GUIRowID].Cells["name"].Value = handler.Username;
            }
        }

        int IServer.GetStreamPort() => isStreaming && streamPort > 0 ? streamPort : -1;

        private void SendHostMessage(string msg)
        {
            string formatted = $"(HOST): {msg}";
            if (formatted.Length > 255)
                formatted = formatted.Substring(0, 255);
            ((IServer)this).BroadcastMessage(formatted);
            Logger.LogInfo(formatted);
        }

        private void StartStream(int port)
        {
            isStreaming = true;
            streamPort = port;

            GamePortNUPD.Enabled = false;
            StartGameButton.Enabled = true;
            StreamButton.Text = "Stop streaming";

            lock (clients)
            {
                foreach (ServerHandler handler in clients)
                {
                    if (handler.Username == null)
                        continue;
                    handler.StartStreaming(port);
                }
            }
        }

        private void StopStream()
        {
            isStreaming = false;
            streamPort = 0;

            lock (clients)
            {
                foreach (ServerHandler handler in clients)
                {
                    if (handler.Username == null)
                        continue;
                    handler.StopStreaming();
                }
            }

            GamePortNUPD.Enabled = true;
            StreamButton.Enabled = true;
            StartGameButton.Enabled = false;
            StreamButton.Text = "Start streaming";
        }
    }
}
