using System;
using System.Diagnostics;
using System.IO;
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

        public static void StartGame(OpenFileDialog openDialog, string args)
        {
            DialogResult result = openDialog.ShowDialog();

            if (result != DialogResult.OK)
                return;

            string exePath = openDialog.FileName.Trim();
            try
            {
                Utils.PerformPathChecks(exePath);
            }
            catch (ArgumentException ex)
            {
                Program.Logger.LogShowError(ex.Message, "Invalid file");
                return;
            }

            Process.Start(new ProcessStartInfo()
            {
                FileName = exePath,
                WorkingDirectory = Path.GetDirectoryName(exePath),
                Arguments = args
            });
        }
    }
}
