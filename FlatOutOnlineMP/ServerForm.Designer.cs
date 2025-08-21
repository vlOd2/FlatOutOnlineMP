namespace FlatOutOnlineMP
{
    internal partial class ServerForm
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
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Addresses");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Port");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Connection info", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8});
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PlayersDGV = new System.Windows.Forms.DataGridView();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.StreamButton = new System.Windows.Forms.Button();
            this.GamePortNUPD = new System.Windows.Forms.NumericUpDown();
            this.StatusValueLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.InfoTree = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.ListenButton = new System.Windows.Forms.Button();
            this.ListenPortNUPD = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SendMsgButton = new System.Windows.Forms.Button();
            this.ChatMsgBox = new System.Windows.Forms.TextBox();
            this.LogsTextBox = new System.Windows.Forms.RichTextBox();
            this.LogsCTX = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copySelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CleanupTimer = new System.Windows.Forms.Timer(this.components);
            this.StartGameButton = new System.Windows.Forms.Button();
            this.BrowseOFD = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PlayersDGV)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GamePortNUPD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListenPortNUPD)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.LogsCTX.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.PlayersDGV);
            this.groupBox1.Location = new System.Drawing.Point(161, 235);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 201);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Players";
            // 
            // PlayersDGV
            // 
            this.PlayersDGV.AllowUserToAddRows = false;
            this.PlayersDGV.AllowUserToDeleteRows = false;
            this.PlayersDGV.AllowUserToResizeRows = false;
            this.PlayersDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PlayersDGV.BackgroundColor = System.Drawing.SystemColors.Window;
            this.PlayersDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PlayersDGV.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.PlayersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlayersDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.state,
            this.name,
            this.address});
            this.PlayersDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayersDGV.Location = new System.Drawing.Point(3, 16);
            this.PlayersDGV.Name = "PlayersDGV";
            this.PlayersDGV.ReadOnly = true;
            this.PlayersDGV.RowHeadersVisible = false;
            this.PlayersDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.PlayersDGV.Size = new System.Drawing.Size(350, 182);
            this.PlayersDGV.TabIndex = 2;
            // 
            // state
            // 
            this.state.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.state.HeaderText = "State";
            this.state.Name = "state";
            this.state.ReadOnly = true;
            this.state.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.state.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.state.Width = 65;
            // 
            // name
            // 
            this.name.HeaderText = "Username";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // address
            // 
            this.address.HeaderText = "IP Address";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.StartGameButton);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.StreamButton);
            this.groupBox2.Controls.Add(this.GamePortNUPD);
            this.groupBox2.Controls.Add(this.StatusValueLabel);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.InfoTree);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ListenButton);
            this.groupBox2.Controls.Add(this.ListenPortNUPD);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(144, 425);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Manage";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Game port:";
            // 
            // StreamButton
            // 
            this.StreamButton.Enabled = false;
            this.StreamButton.Location = new System.Drawing.Point(9, 126);
            this.StreamButton.Name = "StreamButton";
            this.StreamButton.Size = new System.Drawing.Size(129, 23);
            this.StreamButton.TabIndex = 11;
            this.StreamButton.Text = "Start streaming";
            this.StreamButton.UseVisualStyleBackColor = true;
            this.StreamButton.Click += new System.EventHandler(this.StreamButton_Click);
            // 
            // GamePortNUPD
            // 
            this.GamePortNUPD.Enabled = false;
            this.GamePortNUPD.Location = new System.Drawing.Point(9, 71);
            this.GamePortNUPD.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.GamePortNUPD.Name = "GamePortNUPD";
            this.GamePortNUPD.Size = new System.Drawing.Size(129, 20);
            this.GamePortNUPD.TabIndex = 10;
            this.GamePortNUPD.Value = new decimal(new int[] {
            23756,
            0,
            0,
            0});
            // 
            // StatusValueLabel
            // 
            this.StatusValueLabel.AutoSize = true;
            this.StatusValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StatusValueLabel.ForeColor = System.Drawing.Color.Red;
            this.StatusValueLabel.Location = new System.Drawing.Point(45, 179);
            this.StatusValueLabel.Name = "StatusValueLabel";
            this.StatusValueLabel.Size = new System.Drawing.Size(30, 13);
            this.StatusValueLabel.TabIndex = 9;
            this.StatusValueLabel.Text = "N/A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Status:";
            // 
            // InfoTree
            // 
            this.InfoTree.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.InfoTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InfoTree.Cursor = System.Windows.Forms.Cursors.Default;
            this.InfoTree.Location = new System.Drawing.Point(9, 195);
            this.InfoTree.Name = "InfoTree";
            treeNode7.Name = "addresses";
            treeNode7.Text = "Addresses";
            treeNode8.Name = "port";
            treeNode8.Text = "Port";
            treeNode9.Name = "root";
            treeNode9.Text = "Connection info";
            this.InfoTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.InfoTree.ShowRootLines = false;
            this.InfoTree.Size = new System.Drawing.Size(129, 224);
            this.InfoTree.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Listen port:";
            // 
            // ListenButton
            // 
            this.ListenButton.Location = new System.Drawing.Point(9, 97);
            this.ListenButton.Name = "ListenButton";
            this.ListenButton.Size = new System.Drawing.Size(129, 23);
            this.ListenButton.TabIndex = 1;
            this.ListenButton.Text = "Start listening";
            this.ListenButton.UseVisualStyleBackColor = true;
            this.ListenButton.Click += new System.EventHandler(this.ListenButton_Click);
            // 
            // ListenPortNUPD
            // 
            this.ListenPortNUPD.Location = new System.Drawing.Point(9, 32);
            this.ListenPortNUPD.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ListenPortNUPD.Name = "ListenPortNUPD";
            this.ListenPortNUPD.Size = new System.Drawing.Size(129, 20);
            this.ListenPortNUPD.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.SendMsgButton);
            this.groupBox3.Controls.Add(this.ChatMsgBox);
            this.groupBox3.Controls.Add(this.LogsTextBox);
            this.groupBox3.Location = new System.Drawing.Point(161, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(356, 221);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logs";
            // 
            // SendMsgButton
            // 
            this.SendMsgButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendMsgButton.Enabled = false;
            this.SendMsgButton.Location = new System.Drawing.Point(276, 194);
            this.SendMsgButton.Name = "SendMsgButton";
            this.SendMsgButton.Size = new System.Drawing.Size(75, 23);
            this.SendMsgButton.TabIndex = 8;
            this.SendMsgButton.Text = "Send";
            this.SendMsgButton.UseVisualStyleBackColor = true;
            this.SendMsgButton.Click += new System.EventHandler(this.SendMsgButton_Click);
            // 
            // ChatMsgBox
            // 
            this.ChatMsgBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatMsgBox.Enabled = false;
            this.ChatMsgBox.Location = new System.Drawing.Point(3, 195);
            this.ChatMsgBox.MaxLength = 255;
            this.ChatMsgBox.Name = "ChatMsgBox";
            this.ChatMsgBox.Size = new System.Drawing.Size(271, 20);
            this.ChatMsgBox.TabIndex = 7;
            this.ChatMsgBox.TextChanged += new System.EventHandler(this.ChatMsgBox_TextChanged);
            this.ChatMsgBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChatMsgBox_KeyDown);
            // 
            // LogsTextBox
            // 
            this.LogsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogsTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.LogsTextBox.ContextMenuStrip = this.LogsCTX;
            this.LogsTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LogsTextBox.Location = new System.Drawing.Point(6, 19);
            this.LogsTextBox.Name = "LogsTextBox";
            this.LogsTextBox.ReadOnly = true;
            this.LogsTextBox.Size = new System.Drawing.Size(344, 170);
            this.LogsTextBox.TabIndex = 6;
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
            // CleanupTimer
            // 
            this.CleanupTimer.Tick += new System.EventHandler(this.CleanupTimer_Tick);
            // 
            // StartGameButton
            // 
            this.StartGameButton.Enabled = false;
            this.StartGameButton.Location = new System.Drawing.Point(9, 153);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(129, 23);
            this.StartGameButton.TabIndex = 13;
            this.StartGameButton.Text = "Start game";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // BrowseOFD
            // 
            this.BrowseOFD.DefaultExt = "exe";
            this.BrowseOFD.FileName = "flatout.exe";
            this.BrowseOFD.Filter = "Executable files|*.exe";
            this.BrowseOFD.InitialDirectory = "C:\\Program Files (x86)\\Empire Interactive\\FlatOut";
            this.BrowseOFD.Title = "Select game executable";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 443);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ServerForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "FlatOutOnlineMP - Host";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerForm_FormClosing);
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PlayersDGV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GamePortNUPD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ListenPortNUPD)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.LogsCTX.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView PlayersDGV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox LogsTextBox;
        private System.Windows.Forms.Button SendMsgButton;
        private System.Windows.Forms.TextBox ChatMsgBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ListenButton;
        private System.Windows.Forms.NumericUpDown ListenPortNUPD;
        private System.Windows.Forms.TreeView InfoTree;
        private System.Windows.Forms.Label StatusValueLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip LogsCTX;
        private System.Windows.Forms.ToolStripMenuItem copySelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.Timer CleanupTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button StreamButton;
        private System.Windows.Forms.NumericUpDown GamePortNUPD;
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.OpenFileDialog BrowseOFD;
    }
}