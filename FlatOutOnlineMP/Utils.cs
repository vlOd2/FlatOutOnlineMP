using System;
using System.IO;
using System.Net;

namespace FlatOutOnlineMP
{
    internal static class Utils
    {
        public static int IndexOfBytes(byte[] input, byte[] value)
        {
            int index = -1;
            int matchIdx = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == value[matchIdx])
                {
                    if (matchIdx == value.Length - 1)
                    {
                        index = i - matchIdx;
                        break;
                    }
                    matchIdx++;
                }
                else if (input[i] == value[0])
                    matchIdx = 1;
                else
                    matchIdx = 0;
            }

            return index;
        }

        public static byte[] ReplaceBytes(byte[] input, byte[] oldBytes, byte[] newBytes)
        {
            int index = IndexOfBytes(input, oldBytes);
            if (index < 0)
                return null;
            byte[] repl = new byte[input.Length - oldBytes.Length + newBytes.Length];
            Buffer.BlockCopy(input, 0, repl, 0, index);
            Buffer.BlockCopy(newBytes, 0, repl, index, newBytes.Length);
            Buffer.BlockCopy(input, index + oldBytes.Length, repl, index + newBytes.Length, input.Length - (index + oldBytes.Length));
            return repl;
        }

        private static bool IsPathFullyQualified(string path)
        {
            if (string.IsNullOrEmpty(path))
                return false;
            string root = Path.GetPathRoot(path);
            return root.StartsWith(@"\\") || root.EndsWith(@"\") && root != @"\";
        }

        public static void PerformPathChecks(string exePath, bool checkExists = true)
        {
            if (!IsPathFullyQualified(exePath))
                throw new ArgumentException("Path must be fully qualified");
            if (Path.GetExtension(exePath) != ".exe")
                throw new ArgumentException("File must be an executable");
            if (checkExists && !File.Exists(exePath))
                throw new ArgumentException("File does not exist");
        }

        public static bool ValidateRemoteAddress(string address)
        {
            try
            {
                if (IPAddress.TryParse(address, out _))
                    return true;
                if (Dns.GetHostEntry(address).AddressList.Length > 0)
                    return true;
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
