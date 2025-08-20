using FlatOutOnlineMP.Logger;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FlatOutOnlineMP
{
    internal partial class ServerForm : Form
    {
        private static ILogger Logger => Program.Logger;

        public ServerForm()
        {
            InitializeComponent();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            Program.Logger = new FormLogger(LogsTextBox);
            Cleanup();
            ListenPortNUPD.Value = MainForm.DEFAULT_PORT;
            InfoTree.ExpandAll();
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isListening && e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Closing the application will stop the listener and end all connections, " +
                    "are you sure you want to continue?", "Listening warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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

        private void ListenButton_Click(object sender, EventArgs e)
        {
            if (isListening)
            {
                Logger.LogInfo("Stopping listener");
                Cleanup();
                return;
            }
            Logger.LogInfo("Starting listener");
            Listen(Math.Min(Math.Max(0, (int)ListenPortNUPD.Value), 65535));
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e) => LogsTextBox.ResetText();

        private void copySelectedToolStripMenuItem_Click(object sender, EventArgs e) => LogsTextBox.Copy();

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e) => LogsTextBox.SelectAll();

        private void SendMsgButton_Click(object sender, EventArgs e)
        {
            if (!isListening)
                return;
            string msg = Regex.Replace(ChatMsgBox.Text.Trim(), @"[^\x20-\x7F]", "");
            if (string.IsNullOrEmpty(msg))
            {
                Logger.LogShowError("Invalid or empty message");
                return;
            }
            ChatMsgBox.Text = "";
            SendHostMessage(msg);
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

        private void StreamButton_Click(object sender, EventArgs e)
        {
            if (isStreaming)
            {
                Logger.LogInfo("Stop streaming game data");
                StopStream();
                return;
            }
            int port = Math.Min(Math.Max(0, (int)ListenPortNUPD.Value), 65535);
            Logger.LogInfo($"Start streaming game data (port: {port})");
            StartStream(port);
        }
    }
}
