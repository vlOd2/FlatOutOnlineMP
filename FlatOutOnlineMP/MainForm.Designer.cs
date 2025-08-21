namespace FlatOutOnlineMP
{
    internal partial class MainForm
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
            this.ClientButton = new System.Windows.Forms.Button();
            this.ServerButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ClientButton
            // 
            this.ClientButton.Location = new System.Drawing.Point(11, 25);
            this.ClientButton.Name = "ClientButton";
            this.ClientButton.Size = new System.Drawing.Size(129, 62);
            this.ClientButton.TabIndex = 0;
            this.ClientButton.Text = "Player (Client)";
            this.ClientButton.UseVisualStyleBackColor = true;
            this.ClientButton.Click += new System.EventHandler(this.ClientButton_Click);
            // 
            // ServerButton
            // 
            this.ServerButton.Location = new System.Drawing.Point(146, 25);
            this.ServerButton.Name = "ServerButton";
            this.ServerButton.Size = new System.Drawing.Size(129, 62);
            this.ServerButton.TabIndex = 1;
            this.ServerButton.Text = "Host (Server)";
            this.ServerButton.UseVisualStyleBackColor = true;
            this.ServerButton.Click += new System.EventHandler(this.ServerButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose your role:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 98);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ServerButton);
            this.Controls.Add(this.ClientButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClientButton;
        private System.Windows.Forms.Button ServerButton;
        private System.Windows.Forms.Label label1;
    }
}