using System;
using System.Drawing;

namespace FlatOutOnlineMP.Logger
{
    internal interface ILogger
    {
        void LogMessage(string msg, Color? color = null);

        void LogInfo(string content);

        void LogWarn(string content);

        void LogError(string content);

        void LogError(Exception exception);

        void LogShowError(string content, string title = "Error");
    }
}
