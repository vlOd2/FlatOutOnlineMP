using FlatOutOnlineMP.Logger;
using System;
using System.Windows.Forms;

namespace FlatOutOnlineMP
{
    internal static class Program
    {
        public static ILogger Logger;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
