namespace CasProtocol
{
	using System.IO;
    using System.Net;
    using System.Net.Sockets;

    public static class ProtocolCommon
    {
        public const int CAS_CLIENT_BROADCAST_PORT = 0x2ac1;
        public const int CAS_GLOBAL_SERVER_PORT = 0x2ac4;
        public const int CAS_LOCAL_SERVER_BROADCAST_PORT = 0x2ac2;
        public const int CAS_LOCAL_SERVER_PORT = 0x2ac3;

        public static IPAddress GetIPByClient(TcpClient Client)
        {
            try
            {
                IPEndPoint remoteEndPoint = Client.Client.RemoteEndPoint as IPEndPoint;
                return remoteEndPoint.Address;
            }
            catch
            {
                return null;
            }
        }

        public static byte[] ReadFromStream(BinaryReader Reader)
        {
            int num4;
            int num = Reader.ReadInt32();
            byte[] buffer = new byte[num];
            int index = 0;
            for (int i = num; i > 0; i -= num4)
            {
                num4 = Reader.Read(buffer, index, i);
                if (num4 <= 0)
                {
                    return buffer;
                }
                index += num4;
            }
            return buffer;
        }

        public static void WriteToStream(BinaryWriter Writer, byte[] Message)
        {
            int length = Message.Length;
            Writer.Write(length);
            Writer.Write(Message);
        }
    }
}

