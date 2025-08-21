using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FlatOutOnlineMP
{
    internal partial class MainForm : Form
    {
        public const int DEFAULT_PORT = 35762;
        public const uint PROTOCOL_VERSION = 1;
        public const uint CLIENT_MAGIC = 0x12478145u;
        public const uint SERVER_MAGIC = 0x34568925u;
        public const string APP_NAME = "FlatOutOnlineMP";
        public static readonly string APP_VERSION = $"{Application.ProductVersion}/PV_{PROTOCOL_VERSION}";

        public MainForm()
        {
            InitializeComponent();
            Text = APP_NAME;
        }

        private void ChangeForm(Form form)
        {
            Hide();
            form.ShowDialog();
            Close();
        }

        private void ClientButton_Click(object sender, EventArgs e) => ChangeForm(new ClientForm());

        private void ServerButton_Click(object sender, EventArgs e) => ChangeForm(new ServerForm());

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
