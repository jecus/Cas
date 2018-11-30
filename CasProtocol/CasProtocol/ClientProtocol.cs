namespace CasProtocol
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading;

    public class ClientProtocol
    {
        private BinaryReader _Reader;
        private TcpClient _server;
        private BinaryWriter _Writer;

        public event CasProtocol.LogEntryEventHandler LogEntryAdded;

        public event ResponseReceivedEventHandler ResponseReceived;

        public event ServerConnectedEventHandler ServerConnected;

        private void CloseConnection()
        {
            try
            {
                this._server.Close();
                this._server = null;
                this._Reader = null;
                this._Writer = null;
            }
            catch (Exception exception)
            {
                this.Log(exception);
            }
            this._server = null;
        }

        private void ConnectedAsyncCallback(IAsyncResult ar)
        {
            TcpClient asyncState = null;
            try
            {
                asyncState = (TcpClient) ar.AsyncState;
                asyncState.EndConnect(ar);
            }
            catch (Exception exception)
            {
                if (this.ServerConnected != null)
                {
                    this.ServerConnected(ServerConnectedResult.Failed, exception.ToString(), null);
                }
                this.Log(exception);
            }
            try
            {
                this._Reader = new BinaryReader(asyncState.GetStream());
                this._Writer = new BinaryWriter(asyncState.GetStream());
                string welcomeMessage = Encoding.Unicode.GetString(ProtocolCommon.ReadFromStream(this._Reader));
                ClientRequest firstRequest = new ClientRequest();
                if (this.ServerConnected != null)
                {
                    this.ServerConnected(ServerConnectedResult.Connected, welcomeMessage, firstRequest);
                }
                else
                {
                    firstRequest.AbortConnection = true;
                }
                this.SendRequestAsync(firstRequest);
            }
            catch (Exception exception2)
            {
                this.Log(exception2);
            }
        }

        public void InitializeConnect(IPAddress ipAddress, int port)
        {
            try
            {
                _server = new TcpClient();
                _server.BeginConnect(ipAddress, port, new AsyncCallback(this.ConnectedAsyncCallback), this._server);
            }
            catch (Exception exception)
            {
                this.Log(exception);
            }
        }

        private void Log(object LogEntry)
        {
            if (this.LogEntryAdded != null)
            {
                this.LogEntryAdded(LogEntry);
            }
        }

        protected string ReceiveData()
        {
            return null;
        }

        private void SendRequestAsync(ClientRequest request)
        {
            ParameterizedThreadStart start = new ParameterizedThreadStart(this.SendRequestSync);
            new Thread(start).Start(request);
        }

        protected void SendRequestSync(object o)
        {
            ClientRequest lastRequest = o as ClientRequest;
            try
            {
                if (((lastRequest != null) && (lastRequest.BinaryRequest != null)) && (lastRequest.BinaryRequest.Length > 0))
                {
                    ProtocolCommon.WriteToStream(this._Writer, lastRequest.BinaryRequest);
                }
                if ((lastRequest == null) || lastRequest.AbortConnection)
                {
                    this.CloseConnection();
                }
                else
                {
                    lastRequest.BinaryResponse = ProtocolCommon.ReadFromStream(this._Reader);
                    ClientRequest nextRequest = new ClientRequest();
                    if (this.ResponseReceived != null)
                    {
                        this.ResponseReceived(lastRequest, nextRequest);
                    }
                    else
                    {
                        nextRequest.AbortConnection = true;
                    }
                    this.SendRequestAsync(nextRequest);
                }
            }
            catch (Exception exception)
            {
                this.Log(exception);
            }
        }

        public delegate void ResponseReceivedEventHandler(ClientRequest LastRequest, ClientRequest NextRequest);

        public delegate void ServerConnectedEventHandler(ServerConnectedResult ConnectionResult, string WelcomeMessage, ClientRequest FirstRequest);
    }
}

