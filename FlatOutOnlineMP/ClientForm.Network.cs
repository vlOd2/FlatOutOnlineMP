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
    internal partial class ClientForm
    {
        private bool isConnected;
        private Socket socket;
        private ClientHandler client;

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
                client = new ClientHandler(connection)
                {
                    OnLoggedin = () => this.InvokeIfRequired(() =>
                    {
                        SetStatus("Connected", Color.Green);
                        ChatMsgBox.Enabled = true;
                        Logger.LogInfo("Connected successfully");
                    }),
                    OnDisposed = () => Cleanup()
                };
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
                isConnected = false;
                SetStatus("Not connected", Color.Red);

                socket?.Close();
                client?.Dispose();
                socket = null;
                client = null;

                RemoteHostBox.Enabled = true;
                UsernameBox.Enabled = true;
                ChatMsgBox.Enabled = false;
                SendMsgButton.Enabled = false;
                ConnectButton.Text = "Connect";
                ChatMsgBox.Text = "";
            });
        }
    }
}
