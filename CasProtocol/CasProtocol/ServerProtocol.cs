namespace CasProtocol
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class ServerProtocol
    {
        private TcpListener _Listener;

        public event ClientConnectedEventHandler ClientConnected;

        public event CasProtocol.LogEntryEventHandler LogEntryAdded;

        public event RequestReceivedEventHandler RequestReceived;

        private void AcceptTcpClientCallback(IAsyncResult ar)
        {
            TcpListener asyncState = ar.AsyncState as TcpListener;
            TcpClient client = null;
            try
            {
                client = asyncState.EndAcceptTcpClient(ar);
            }
            catch (Exception exception)
            {
                this.Log(exception);
            }
            try
            {
                if (asyncState != null)
                {
                    asyncState.BeginAcceptTcpClient(new AsyncCallback(this.AcceptTcpClientCallback), asyncState);
                }
            }
            catch (Exception exception2)
            {
                this.Log(exception2);
            }
            try
            {
                ClientRequest response = new ClientRequest();
                if (this.ClientConnected != null)
                {
                    string welcomeMessage = "";
                    this.ClientConnected(client, ref welcomeMessage);
                    response.Response = welcomeMessage;
                }
                else
                {
                    response.Response = "";
                    response.AbortConnection = true;
                }
                this.SendResponseAsync(client, response);
            }
            catch (Exception exception3)
            {
                this.Log(exception3);
            }
        }

        public void Close()
        {
            try
            {
                this._Listener.Stop();
                this._Listener = null;
            }
            catch (Exception exception)
            {
                this.Log(exception);
            }
        }

        private void CloseConnection(TcpClient client)
        {
            try
            {
                client.Close();
            }
            catch (Exception exception)
            {
                this.Log(exception);
            }
        }

        public void Listen(int Port)
        {
            try
            {
                this._Listener = new TcpListener(IPAddress.Any, Port);
                this._Listener.Start();
                this._Listener.BeginAcceptTcpClient(new AsyncCallback(this.AcceptTcpClientCallback), this._Listener);
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

        private void SendResponseAsync(TcpClient Client, ClientRequest Response)
        {
            ParameterizedThreadStart start = new ParameterizedThreadStart(this.SendResponseSync);
            new Thread(start).Start(new object[] { Client, Response });
        }

        private void SendResponseSync(object o)
        {
            object[] objArray = (object[]) o;
            TcpClient client = objArray[0] as TcpClient;
            ClientRequest request = objArray[1] as ClientRequest;
            try
            {
                if (((request != null) && (request.BinaryResponse != null)) && (request.BinaryResponse.Length > 0))
                {
                    ProtocolCommon.WriteToStream(new BinaryWriter(client.GetStream()), request.BinaryResponse);
                }
                if ((request == null) || request.AbortConnection)
                {
                    this.CloseConnection(client);
                }
                else
                {
                    ClientRequest request2 = new ClientRequest {
                        BinaryRequest = ProtocolCommon.ReadFromStream(new BinaryReader(client.GetStream()))
                    };
                    if (this.RequestReceived != null)
                    {
                        this.RequestReceived(client, request2);
                    }
                    else
                    {
                        request2.AbortConnection = true;
                    }
                    this.SendResponseAsync(client, request2);
                }
            }
            catch (Exception exception)
            {
                this.Log(exception);
            }
        }

        public delegate void ClientConnectedEventHandler(TcpClient Client, ref string WelcomeMessage);

        public delegate void RequestReceivedEventHandler(TcpClient Client, ClientRequest Request);
    }
}

