using System;
using System.Drawing;

namespace FlatOutOnlineMP.Logger
{
    internal class ConsoleLogger : ILogger
    {
        public void LogMessage(string msg, Color? color = null) => Console.Write(msg);

        public void LogInfo(string msg) => Console.WriteLine($"[INFO] {msg}");

        public void LogWarn(string msg) => Console.WriteLine($"[WARN] {msg}");

        public void LogError(string msg) => Console.WriteLine($"[ERROR] {msg}");

        public void LogError(Exception exception) => LogError("" + exception);

        public void LogShowError(string msg, string title = "Error") => LogError(msg);
    }
}
