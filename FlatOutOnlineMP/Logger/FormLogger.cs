using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace FlatOutOnlineMP.Logger
{
    internal class FormLogger : ILogger
    {
        private const int LOG_BATCH_SIZE = 5;
        private RichTextBox richTextBox;
        private readonly Thread logsThread;
        private readonly SynchronizedQueue<LogEntry> logs = new SynchronizedQueue<LogEntry>();

        public FormLogger(RichTextBox richTextBox)
        {
            this.richTextBox = richTextBox;
            logsThread = new Thread(LogsThread_Func) { IsBackground = true, Priority = ThreadPriority.BelowNormal };
            logsThread.Start();
        }

        private void LogsThread_Func()
        {
            while (!richTextBox.IsDisposed)
            {
                if (logs.Count == 0)
                {
                    Thread.Sleep(1);
                    continue;
                }

                List<LogEntry> batch = new List<LogEntry>();
                while (logs.Count > 0 && batch.Count < LOG_BATCH_SIZE)
                    batch.Add(logs.Dequeue());

                if (richTextBox.IsDisposed)
                    return;

                richTextBox.Invoke(new Action(() =>
                {
                    foreach (LogEntry log in batch)
                    {
                        if (richTextBox.IsDisposed)
                            return;
                        richTextBox.SelectionColor = log.Color ?? Color.Black;
                        richTextBox.AppendText(log.Message);
                    }

                    richTextBox.SelectionStart = richTextBox.Text.Length;
                    richTextBox.ScrollToCaret();
                }));
            }
        }

        public void LogMessage(string msg, Color? color = null) => logs.Enqueue(new LogEntry() { Message = msg, Color = color });

        public void LogInfo(string msg) => LogMessage($"[INFO] {msg}{Environment.NewLine}", Color.CornflowerBlue);

        public void LogWarn(string msg) => LogMessage($"[WARN] {msg}{Environment.NewLine}", Color.DarkOrange);

        public void LogError(string msg) => LogMessage($"[ERROR] {msg}{Environment.NewLine}", Color.Red);

        public void LogError(Exception exception) => LogError("" + exception);

        public void LogShowError(string msg, string title = "Error")
        {
            LogError(msg);
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
