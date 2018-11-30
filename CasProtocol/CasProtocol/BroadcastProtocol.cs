namespace CasProtocol
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class BroadcastProtocol
    {
        private UdpClient _listener;

        public event LogEntryEventHandler LogEntryAdded;

        public event MessageReceivedEventHandler MessageReceived;

        public void Listen(int port)
        {
            try
            {
                IPEndPoint localEp = new IPEndPoint(IPAddress.Any, port);
                _listener = new UdpClient(localEp);
                _listener.BeginReceive(MessageReceivedAsyncCallback, _listener);
            }
            catch (Exception exception)
            {
                Log(exception);
            }
        }

        private void Log(object logEntry)
        {
            if (LogEntryAdded != null)
            {
                LogEntryAdded(logEntry);
            }
        }

        private void MessageReceivedAsyncCallback(IAsyncResult ar)
        {
            try
            {
                UdpClient asyncState = (UdpClient) ar.AsyncState;
                IPEndPoint remoteEp = null;
                EndPoint localEndPoint = asyncState.Client.LocalEndPoint;
                byte[] bytes = asyncState.EndReceive(ar, ref remoteEp);
                string message = Encoding.Unicode.GetString(bytes);
                _listener.BeginReceive(MessageReceivedAsyncCallback, _listener);
                if (MessageReceived != null)
                {
                    MessageReceived(message, remoteEp);
                }
            }
            catch (Exception exception)
            {
                Log(exception);
            }
        }

        private void MessageSentAsyncCallback(IAsyncResult ar)
        {
            try
            {
                UdpClient asyncState = (UdpClient) ar.AsyncState;
                asyncState.EndSend(ar);
                asyncState.Close();
            }
            catch (Exception exception)
            {
                this.Log(exception);
            }
        }

        public void SendMessage(string message, int port)
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, port);
                UdpClient state = new UdpClient { EnableBroadcast = true };
                //IPEndPoint endPoint = new IPEndPoint(new IPAddress(new byte[] { 192, 168, 3, 7 }), port);
                //UdpClient state = new UdpClient();
                byte[] bytes = Encoding.Unicode.GetBytes(message);
                state.Connect(endPoint);
                state.BeginSend(bytes, bytes.Length, new AsyncCallback(MessageSentAsyncCallback), state);
            }
            catch (Exception exception)
            {
                Log(exception);
            }
        }

        public void StopListen()
        {
            try
            {
                if (this._listener != null)
                {
                    this._listener.Close();
                }
            }
            catch (Exception exception)
            {
                this.Log(exception);
            }
        }

        public delegate void LogEntryEventHandler(object LogEntry);

        public delegate void MessageReceivedEventHandler(string Message, IPEndPoint RemoteEP);
    }
}

