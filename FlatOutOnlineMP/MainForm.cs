using System;
using System.Windows.Forms;

namespace FlatOutOnlineMP
{
    internal partial class MainForm : Form
    {
        public const int DEFAULT_PORT = 35762;
        public const uint CLIENT_MAGIC = 0x12478145u;
        public const uint SERVER_MAGIC = 0x34568925u;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ClientButton_Click(object sender, EventArgs e)
        {
            Hide();
            new ClientForm().ShowDialog();
            Close();
        }

        private void ServerButton_Click(object sender, EventArgs e)
        {
            Hide();
            new ServerForm().ShowDialog();
            Close();
        }
    }
}
