using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FlatOutOnlineMP
{
    internal static class Extensions
    {
        public static void InvokeIfRequired(this Control control, Action action)
        {
            if (control.InvokeRequired)
                control.Invoke(action);
            else
                action();
        }

        public static void ReadExactly(this BinaryReader reader, byte[] buffer, int offset, int count)
        {
            int remaining = count;
            while (remaining > 0)
            {
                int read = reader.Read(buffer, offset, remaining);
                if (read == 0)
                    throw new EndOfStreamException();
                offset += read;
                remaining -= read;
            }
        }

        public static byte[] ReadExactly(this BinaryReader reader, int count)
        {
            byte[] buffer = new byte[count];
            reader.ReadExactly(buffer, 0, count);
            return buffer;
        }

        public static string ReadASCIIStr(this BinaryReader reader, int maxLen = 0)
        {
            byte length = reader.ReadByte();
            if (maxLen > 0 && length > maxLen)
                throw new IOException("String too large");
            return Encoding.ASCII.GetString(reader.ReadExactly(length));
        }

        public static void WriteASCIIStr(this BinaryWriter writer, string s, int maxLen = 0)
        {
            if (maxLen > 0 && s.Length > maxLen)
                s = s.Substring(0, maxLen);
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            writer.Write((byte)bytes.Length);
            writer.Write(bytes);
        }
    }
}
