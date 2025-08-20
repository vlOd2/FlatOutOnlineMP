using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace FlatOutOnlineMP.Network
{
    internal class Connection : IDisposable
    {
        private bool disposed;
        private Socket socket;
        private NetworkStream stream;
        public BinaryReader Reader;
        public BinaryWriter Writer;
        private Thread readThread;
        public IPEndPoint RemoteAddress;
        public IConnectionHandler Handler;

        public Connection(Socket socket) 
        {
            this.socket = socket;
            stream = new NetworkStream(socket, true);
            Reader = new BinaryReader(stream, Encoding.UTF8);
            Writer = new BinaryWriter(new BufferedStream(stream, 512), Encoding.UTF8);
            readThread = new Thread(ReadLoop);
            RemoteAddress = (IPEndPoint)socket.RemoteEndPoint;
        }

        public void Start() => readThread.Start();

        private void ReadLoop()
        {
            try
            {
                while (!disposed)
                {
                    byte id = Reader.ReadByte();
                    if (!PacketUtils.IsDefined(id))
                        throw new IOException("Invalid packet ID");
                    Handler.HandlePacket((Packet)id);
                }
            }
            catch (EndOfStreamException)
            {
                if (disposed)
                    return;
                Dispose();
                Handler.OnDisconnect();
            }
            catch (Exception ex)
            {
                if (disposed)
                    return;
                Dispose();
                Handler.OnConnectionError(ex);
            }
        }

        public void Dispose()
        {
            if (disposed)
                return;
            disposed = true;

            readThread?.Interrupt();
            stream?.Dispose();
            socket?.Close();

            readThread = null;
            Reader = null;
            Writer = null;
            stream = null;
            socket = null;
        }
    }
}
