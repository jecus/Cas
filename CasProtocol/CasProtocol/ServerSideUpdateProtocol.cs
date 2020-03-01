namespace CasProtocol
{
    using System;
    using System.IO;
    using System.Net.Sockets;

    public class ServerSideUpdateProtocol
    {
        private ServerProtocol _ActiveConnection;
        private TcpClient _ActiveTcpClient;
        private int _FilesTransferred;
        private DirectoryInfo _UpdatesDirectory;
        private string _UpdatingProduct = "";
        private DirectoryInfo _UpdatingProductDirectory;

        public event UpdateCompletedEventHandler UpdateComplete;

        private void AbortUpdate()
        {
            if (this.UpdateComplete != null)
            {
                this.UpdateComplete(this._ActiveConnection, this._ActiveTcpClient, this._UpdatingProduct, this._FilesTransferred);
            }
            this._ActiveConnection.RequestReceived -= new ServerProtocol.RequestReceivedEventHandler(this.Update_RequestReceived);
            this._ActiveConnection = null;
            this._UpdatingProduct = "";
            this._UpdatesDirectory = null;
            this._UpdatingProductDirectory = null;
            this._FilesTransferred = 0;
        }

        private string GetFileList(DirectoryInfo directory, string Prefix)
        {
            string str = "";
            FileInfo[] files = directory.GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                object obj2 = str;
                str = string.Concat(new object[] { obj2, (Prefix != "") ? (Prefix + @"\") : "", files[i].Name, "\t", CasProtocol.Convert.DateTimeToString(files[i].LastWriteTimeUtc), "\t", files[i].Length, "\r\n" });
            }
            DirectoryInfo[] directories = directory.GetDirectories();
            for (int j = 0; j < directories.Length; j++)
            {
                str = str + this.GetFileList(directories[j], Prefix + directories[j].Name + @"\");
            }
            if (str == "")
            {
                str = ":empty:";
            }
            return str;
        }

        private string GetProductName(string Request)
        {
            if (Request.Length > 7)
            {
                return Request.Substring(6).Trim();
            }
            return "";
        }

        private void SelectProduct(ClientRequest Request)
        {
            this._UpdatingProduct = this.GetProductName(Request.Request);
            if (this._UpdatingProduct == "")
            {
                Request.Response = "FAILED: PRODUCT CAN NOT BE NULL";
            }
            else if (!this._UpdatesDirectory.Exists)
            {
                Request.Response = "FAILED: UPDATE DIRECTORY NOT FOUND";
            }
            else
            {
                this._UpdatingProductDirectory = new DirectoryInfo(Path.Combine(this._UpdatesDirectory.FullName, this._UpdatingProduct));
                if (!this._UpdatingProductDirectory.Exists)
                {
                    Request.Response = "FAILED: NO SUCH PRODUCT FOUND";
                }
                else
                {
                    this._FilesTransferred = 0;
                    Request.Response = this.GetFileList(this._UpdatingProductDirectory, "");
                }
            }
        }

        public void Start(ServerProtocol ActiveConnection, TcpClient Client, ClientRequest Request, string UpdatesDirectory)
        {
            this._ActiveConnection = ActiveConnection;
            this._ActiveTcpClient = Client;
            this._ActiveConnection.RequestReceived += new ServerProtocol.RequestReceivedEventHandler(this.Update_RequestReceived);
            this._UpdatesDirectory = new DirectoryInfo(UpdatesDirectory);
            this.Update_RequestReceived(Client, Request);
        }

        private void TransferFile(ClientRequest Request)
        {
            FileInfo info = null;
            try
            {
                info = new FileInfo(Path.Combine(this._UpdatingProductDirectory.FullName, Request.Request));
                if (info.Exists)
                {
                    byte[] buffer = new byte[info.Length];
                    FileStream stream = info.OpenRead();
                    stream.Read(buffer, 0, System.Convert.ToInt32(info.Length));
                    stream.Close();
                    this._FilesTransferred++;
                    Request.BinaryResponse = buffer;
                }
                else
                {
                    Request.Response = "FAILED";
                }
            }
            catch (Exception exception)
            {
                Request.Response = "EXCEPTION";
                Auxiliary.WriteLog(
	                $"Exception while transfering file:\r\nRequested file: {Request.Request}\r\nSource: {((info != null) ? info.FullName : "FileInfo is null")}\r\nException: {exception.ToString()}");
            }
        }

        private void Update_RequestReceived(TcpClient Client, ClientRequest Request)
        {
            if ((this._ActiveTcpClient == Client) && !Request.Handled)
            {
                if (Request.Request.StartsWith("UPDATE "))
                {
                    this.SelectProduct(Request);
                    Request.Handled = true;
                }
                else if (Request.Request == "THANKS")
                {
                    Request.Handled = true;
                    Request.Response = "WELCOME";
                    this.AbortUpdate();
                }
                else
                {
                    this.TransferFile(Request);
                    Request.Handled = true;
                }
            }
        }

        public delegate void UpdateCompletedEventHandler(ServerProtocol ActiveConnection, TcpClient Client, string Product, int FilesTransferred);
    }
}

