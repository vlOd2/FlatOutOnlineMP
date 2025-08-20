using FlatOutOnlineMP.Logger;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FlatOutOnlineMP
{
    internal partial class ClientForm : Form
    {
        private static ILogger Logger => Program.Logger;

        public ClientForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Program.Logger = new FormLogger(LogsTextBox);
            Cleanup();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isConnected && e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Closing the application will end the current connection, " +
                    "are you sure you want to continue?", "Connected warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
            }
            Cleanup();
        }

        private void SetStatus(string status, Color color)
        {
            this.InvokeIfRequired(() =>
            {
                StatusValueLabel.Text = status;
                StatusValueLabel.ForeColor = color;
            });
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (isConnected)
            {
                Logger.LogInfo("Disconnecting");
                Cleanup();
                return;
            }

            string[] remote = RemoteHostBox.Text.Trim().Split(new char[] { ':' }, 2);
            string ip = remote.Length > 0 ? remote[0] : null;
            int port = MainForm.DEFAULT_PORT;

            if (string.IsNullOrEmpty(ip) || !IPAddress.TryParse(ip, out _))
            {
                Logger.LogShowError("Invalid remote host");
                return;
            }

            if ((remote.Length > 1 && !int.TryParse(remote[1], out port)) || port < 0 || port > 65535)
            {
                Logger.LogShowError("Invalid remote port");
                return;
            }

            string username = Regex.Replace(UsernameBox.Text.Trim(), @"[^a-zA-Z0-9_]", "");
            if (username.Length > 16)
                username = username.Substring(0, 16);
            UsernameBox.Text = username;
            if (string.IsNullOrEmpty(username) || username.Length < 3 || username.Length > 16)
            {
                Logger.LogShowError($"Username too short or is invalid!{Environment.NewLine}" +
                    $"Must be between 3 and 16 characters long and be made up of a-z, A-Z, 0-9 or _");
                return;
            }

            Connect(ip, port, username);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e) => LogsTextBox.ResetText();

        private void copySelectedToolStripMenuItem_Click(object sender, EventArgs e) => LogsTextBox.Copy();

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e) => LogsTextBox.SelectAll();

        private void SendMsgButton_Click(object sender, EventArgs e)
        {
            if (!isConnected)
                return;
            string msg = Regex.Replace(ChatMsgBox.Text.Trim(), @"[^\x20-\x7F]", "");
            if (string.IsNullOrEmpty(msg))
            {
                Logger.LogShowError("Invalid or empty message");
                return;
            }
            ChatMsgBox.Text = "";
            SendMessage(msg);
        }

        private void ChatMsgBox_TextChanged(object sender, EventArgs e)
        {
            // Originally also did the regex test, but this should be enough
            SendMsgButton.Enabled = !string.IsNullOrEmpty(ChatMsgBox.Text.Trim());
        }

        private void ChatMsgBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (!SendMsgButton.Enabled)
                    return;
                SendMsgButton.PerformClick();
            }
        }

        private static bool IsPathFullyQualified(string path)
        {
            if (string.IsNullOrEmpty(path))
                return false;
            string root = Path.GetPathRoot(path);
            return root.StartsWith(@"\\") || root.EndsWith(@"\") && root != @"\";
        }

        public static void PerformPathChecks(string exePath, bool checkExists = true)
        {
            if (!IsPathFullyQualified(exePath))
                throw new ArgumentException("Path must be fully qualified");
            if (Path.GetExtension(exePath) != ".exe")
                throw new ArgumentException("File must be an executable");
            if (checkExists && !File.Exists(exePath))
                throw new ArgumentException("File does not exist");
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            if (!isStreamingAvailable || !isStreaming)
                return;
            DialogResult result = BrowseOFD.ShowDialog();

            if (result != DialogResult.OK)
                return;

            string exePath = BrowseOFD.FileName.Trim();
            try
            {
                PerformPathChecks(exePath);
            }
            catch (ArgumentException ex)
            {
                Logger.LogShowError(ex.Message, "Invalid file");
                return;
            }

            Process.Start(new ProcessStartInfo()
            {
                FileName = exePath,
                WorkingDirectory = Path.GetDirectoryName(exePath),
                Arguments = $"-lan -join=127.0.0.1:{streamPort}"
            });
        }

        private void StreamButton_Click(object sender, EventArgs e)
        {
            if (!isStreamingAvailable)
            {
                Logger.LogShowError("Streaming is unavailable");
                return;
            }
            if (isStreaming)
            {
                Logger.LogInfo("Stop streaming");
                StopStreaming();
                return;
            }
            Logger.LogInfo("Start streaming");
            StartStreaming();
        }
    }
}
