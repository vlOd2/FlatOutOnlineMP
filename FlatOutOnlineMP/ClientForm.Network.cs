using FlatOutOnlineMP.Network;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace FlatOutOnlineMP
{
    internal partial class ClientForm : IClientEvents
    {
        private bool isConnected;
        private Socket socket;
        private ClientHandler client;
        private bool isStreamingAvailable;
        private bool isStreaming;
        private GameSocket streamSocket;
        private int streamPort;

        private void Connect(string ip, int port, string username)
        {
            isConnected = true;
            SetStatus("Connecting", Color.Orange);

            RemoteHostBox.Enabled = false;
            UsernameBox.Enabled = false;
            ConnectButton.Text = "Disconnect";

            Logger.LogInfo($"Connecting to {ip}:{port}"); 
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.BeginConnect(ip, port, ConnectCallback, username);
        }

        private void ConnectCallback(IAsyncResult result)
        {
            try
            {
                socket.EndConnect(result);
            }
            catch (Exception ex) 
            {
                if (!isConnected)
                    return;
                Cleanup();
                Logger.LogShowError($"Failed to connect: {ex}");
                return;
            }

            Connection connection = new Connection(socket);
            try
            {
                SetStatus("Handshaking", Color.Orange);
                Logger.LogInfo("Handshaking");
                connection.Writer.Write(MainForm.CLIENT_MAGIC);
                connection.Writer.Flush();
                if (connection.Reader.ReadUInt32() != MainForm.SERVER_MAGIC)
                    throw new IOException("Invalid server magic");
                socket = null;
                client = new ClientHandler(this, connection);
                client.SendLoginPacket((string)result.AsyncState);
            }
            catch (Exception ex)
            {
                connection.Dispose();
                if (!isConnected)
                    return;
                Logger.LogShowError($"Handshaking failed: {ex}");
            }
        }

        private void SendMessage(string msg)
        {
            if (!isConnected)
                return;
            if (msg.Length > 255)
                msg = msg.Substring(0, 255);
            client.SendMessagePacket(msg);
        }

        private void Cleanup()
        {
            this.InvokeIfRequired(() =>
            {
                isConnected = isStreamingAvailable = false;
                SetStatus("Not connected", Color.Red);

                StopStreaming();
                socket?.Close();
                client?.Dispose();
                socket = null;
                client = null;

                RemoteHostBox.Enabled = true;
                UsernameBox.Enabled = true;
                ChatMsgBox.Enabled = false;
                SendMsgButton.Enabled = false;
                StreamButton.Enabled = false;
                StartGameButton.Enabled = false;
                CanStreamCB.Checked = false;
                ConnectButton.Text = "Connect";
                ChatMsgBox.Text = "";
            });
        }

        private void StartStreaming()
        {
            if (!isStreamingAvailable)
                return;
            isStreaming = true;
            streamSocket = new GameSocket()
            {
                OnData = (_, data) =>
                {
                    if (!isStreaming || !isConnected)
                        return;
                    Logger.LogInfo($"Stream <<< {data.Length} bytes");
                    client.SendStreamData(data);
                },
                OnError = (ex) =>
                {
                    if (!isStreaming)
                        return;
                    Logger.LogWarn($"Stream error: {ex}");
                    StopStreaming();
                }
            };
            streamPort = streamSocket.JoinMode();
        }

        private void StopStreaming()
        {
            isStreaming = false;
            streamSocket?.Dispose();
            streamPort = 0;
            streamSocket = null;
        }

        void IClientEvents.OnLogin()
        {
            SetStatus("Connected", Color.Green);
            ChatMsgBox.Enabled = true;
            Logger.LogInfo("Connected successfully");
        }

        void IClientEvents.OnStreamState(bool state)
        {
            Logger.LogInfo($"Stream availability changed: {state}");
            isStreamingAvailable = state;
            StreamButton.Enabled = state;
            StartGameButton.Enabled = state;
            CanStreamCB.Checked = state;

            if (!state)
            {
                Logger.LogWarn($"Stopping stream as it is no longer available");
                StopStreaming();
            }
        }

        void IClientEvents.OnStreamData(byte[] data)
        {
            if (!isStreaming)
            {
                Logger.LogWarn("Not streaming, but received stream data");
                return;
            }
            Logger.LogInfo($"Stream >>> {data.Length} bytes");
            try
            {
                streamSocket?.Send(data);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex);
            }
        }

        void IClientEvents.OnDisconnect() => Cleanup();
    }
}
