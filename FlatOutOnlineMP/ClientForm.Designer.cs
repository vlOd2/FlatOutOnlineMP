namespace FlatOutOnlineMP
{
    internal partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.RemoteHostBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.StatusValueLabel = new System.Windows.Forms.Label();
            this.BrowseOFD = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.LogsTextBox = new System.Windows.Forms.RichTextBox();
            this.LogsCTX = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copySelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.ChatMsgBox = new System.Windows.Forms.TextBox();
            this.SendMsgButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.CanStreamCB = new System.Windows.Forms.CheckBox();
            this.StreamButton = new System.Windows.Forms.Button();
            this.LogsCTX.SuspendLayout();
            this.SuspendLayout();
            // 
            // RemoteHostBox
            // 
            this.RemoteHostBox.Location = new System.Drawing.Point(11, 28);
            this.RemoteHostBox.Name = "RemoteHostBox";
            this.RemoteHostBox.Size = new System.Drawing.Size(137, 20);
            this.RemoteHostBox.TabIndex = 1;
            this.RemoteHostBox.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Host address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Status:";
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(11, 54);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 23);
            this.ConnectButton.TabIndex = 4;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // StatusValueLabel
            // 
            this.StatusValueLabel.AutoSize = true;
            this.StatusValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StatusValueLabel.ForeColor = System.Drawing.Color.Red;
            this.StatusValueLabel.Location = new System.Drawing.Point(48, 95);
            this.StatusValueLabel.Name = "StatusValueLabel";
            this.StatusValueLabel.Size = new System.Drawing.Size(30, 13);
            this.StatusValueLabel.TabIndex = 7;
            this.StatusValueLabel.Text = "N/A";
            // 
            // BrowseOFD
            // 
            this.BrowseOFD.DefaultExt = "exe";
            this.BrowseOFD.FileName = "flatout.exe";
            this.BrowseOFD.Filter = "Executable files|*.exe";
            this.BrowseOFD.InitialDirectory = "C:\\Program Files (x86)\\Empire Interactive\\FlatOut";
            this.BrowseOFD.Title = "Select game executable";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Logs:";
            // 
            // LogsTextBox
            // 
            this.LogsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogsTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.LogsTextBox.ContextMenuStrip = this.LogsCTX;
            this.LogsTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LogsTextBox.Location = new System.Drawing.Point(11, 135);
            this.LogsTextBox.Name = "LogsTextBox";
            this.LogsTextBox.ReadOnly = true;
            this.LogsTextBox.Size = new System.Drawing.Size(356, 148);
            this.LogsTextBox.TabIndex = 5;
            this.LogsTextBox.Text = "";
            // 
            // LogsCTX
            // 
            this.LogsCTX.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copySelectedToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.LogsCTX.Name = "LogsCTX";
            this.LogsCTX.Size = new System.Drawing.Size(149, 70);
            // 
            // copySelectedToolStripMenuItem
            // 
            this.copySelectedToolStripMenuItem.Name = "copySelectedToolStripMenuItem";
            this.copySelectedToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.copySelectedToolStripMenuItem.Text = "Copy selected";
            this.copySelectedToolStripMenuItem.Click += new System.EventHandler(this.copySelectedToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.selectAllToolStripMenuItem.Text = "Select all";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Username:";
            // 
            // UsernameBox
            // 
            this.UsernameBox.Location = new System.Drawing.Point(152, 28);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(137, 20);
            this.UsernameBox.TabIndex = 11;
            this.UsernameBox.Text = "Player";
            // 
            // ChatMsgBox
            // 
            this.ChatMsgBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatMsgBox.Enabled = false;
            this.ChatMsgBox.Location = new System.Drawing.Point(11, 302);
            this.ChatMsgBox.MaxLength = 255;
            this.ChatMsgBox.Name = "ChatMsgBox";
            this.ChatMsgBox.Size = new System.Drawing.Size(277, 20);
            this.ChatMsgBox.TabIndex = 0;
            this.ChatMsgBox.TextChanged += new System.EventHandler(this.ChatMsgBox_TextChanged);
            this.ChatMsgBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChatMsgBox_KeyDown);
            // 
            // SendMsgButton
            // 
            this.SendMsgButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendMsgButton.Enabled = false;
            this.SendMsgButton.Location = new System.Drawing.Point(294, 301);
            this.SendMsgButton.Name = "SendMsgButton";
            this.SendMsgButton.Size = new System.Drawing.Size(75, 23);
            this.SendMsgButton.TabIndex = 1;
            this.SendMsgButton.Text = "Send";
            this.SendMsgButton.UseVisualStyleBackColor = true;
            this.SendMsgButton.Click += new System.EventHandler(this.SendMsgButton_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Chat:";
            // 
            // StartGameButton
            // 
            this.StartGameButton.Enabled = false;
            this.StartGameButton.Location = new System.Drawing.Point(173, 54);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(75, 23);
            this.StartGameButton.TabIndex = 13;
            this.StartGameButton.Text = "Start game";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // CanStreamCB
            // 
            this.CanStreamCB.AutoCheck = false;
            this.CanStreamCB.AutoSize = true;
            this.CanStreamCB.Enabled = false;
            this.CanStreamCB.Location = new System.Drawing.Point(254, 57);
            this.CanStreamCB.Name = "CanStreamCB";
            this.CanStreamCB.Size = new System.Drawing.Size(79, 17);
            this.CanStreamCB.TabIndex = 14;
            this.CanStreamCB.Text = "Can stream";
            this.CanStreamCB.UseVisualStyleBackColor = true;
            // 
            // StreamButton
            // 
            this.StreamButton.Enabled = false;
            this.StreamButton.Location = new System.Drawing.Point(92, 54);
            this.StreamButton.Name = "StreamButton";
            this.StreamButton.Size = new System.Drawing.Size(75, 23);
            this.StreamButton.TabIndex = 15;
            this.StreamButton.Text = "Start stream";
            this.StreamButton.UseVisualStyleBackColor = true;
            this.StreamButton.Click += new System.EventHandler(this.StreamButton_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 334);
            this.Controls.Add(this.LogsTextBox);
            this.Controls.Add(this.StreamButton);
            this.Controls.Add(this.CanStreamCB);
            this.Controls.Add(this.StartGameButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SendMsgButton);
            this.Controls.Add(this.ChatMsgBox);
            this.Controls.Add(this.UsernameBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StatusValueLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RemoteHostBox);
            this.MinimumSize = new System.Drawing.Size(369, 271);
            this.Name = "ClientForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "FlatOutOnlineMP - Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.LogsCTX.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox RemoteHostBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Label StatusValueLabel;
        private System.Windows.Forms.OpenFileDialog BrowseOFD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox LogsTextBox;
        private System.Windows.Forms.ContextMenuStrip LogsCTX;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copySelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.Button SendMsgButton;
        private System.Windows.Forms.TextBox ChatMsgBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.CheckBox CanStreamCB;
        private System.Windows.Forms.Button StreamButton;
    }
}

