namespace CasProtocol
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class ClientSideUpdateProtocol
    {
        private ClientProtocol _Client;
        private DirectoryInfo _DestinationDirectory;
        /// <summary>
        /// Список кратких описаний файлов
        /// </summary>
        private List<ShortFileInfo> _files;
        /// <summary>
        /// Количество обновленных файлов
        /// </summary>
        private int _filesUpdated;
        private string _Product = "";
        private DirectoryInfo _SourceDirectory;

        public event UpdateCompletedEventHandler UpdateCompleted;

        private void AbortUpdate(ClientRequest nextRequest)
        {
            _Client.ResponseReceived -= new ClientProtocol.ResponseReceivedEventHandler(this.ClientResponseReceived);
            nextRequest.Request = "THANKS";
            if (UpdateCompleted != null)
            {
                UpdateCompleted(this._filesUpdated);
            }
        }

        private void ClientResponseReceived(ClientRequest lastRequest, ClientRequest nextRequest)
        {
            if (this._files == null)
            {
                if (lastRequest.Response.StartsWith("FAILED"))
                {
                    this.AbortUpdate(nextRequest);
                }
                else
                {
                    this.ParseFileList(lastRequest.Response);
                    this.RequestNextFile(nextRequest);
                }
            }
            else
            {
                this.ReceiveFile(lastRequest);
                this.RequestNextFile(nextRequest);
            }
        }

        private ShortFileInfo GetFileInfo(string s)
        {
            if (s.Trim() != "")
            {
                string[] strArray = s.Split(new char[] { '\t' });
                if (strArray.Length >= 3)
                {
                    ShortFileInfo info = new ShortFileInfo {
                        FileName = strArray[0],
                        CreationTime = CasProtocol.Convert.StringToDateTime(strArray[1])
                    };
                    int.TryParse(strArray[2], out info.FileSize);
                    return info;
                }
            }
            return null;
        }

        private ShortFileInfo GetFromFileList(string fileName)
        {
            for (int i = 0; i < _files.Count; i++)
            {
                if (_files[i].FileName == fileName)
                {
                    return _files[i];
                }
            }
            return null;
        }

        private void ParseFileList(string files)
        {
            Auxiliary.WriteLog("Files for product " + this._Product + ":\r\n" + files);
            this._files = new List<ShortFileInfo>();
            if (files != ":empty:")
            {
                string[] strArray = files.Split(new char[] { '\n' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    ShortFileInfo fileInfo = this.GetFileInfo(strArray[i]);
                    if (fileInfo != null)
                    {
                        FileInfo info2 = new FileInfo(Path.Combine(this._SourceDirectory.FullName, fileInfo.FileName));
                        if ((!info2.Exists || (info2.LastWriteTimeUtc < fileInfo.CreationTime)) || (System.Convert.ToInt32(info2.Length) != fileInfo.FileSize))
                        {
                            this._files.Add(fileInfo);
                        }
                    }
                }
            }
        }

        private void ReceiveFile(ClientRequest request)
        {
            Auxiliary.WriteLog("Receiving the file " + request.Request);
            FileInfo info = null;
            try
            {
                ShortFileInfo fromFileList = GetFromFileList(request.Request);
                if (fromFileList != null)
                {
                    this._files.Remove(fromFileList);
                    info = new FileInfo(Path.Combine(this._DestinationDirectory.FullName, fromFileList.FileName));
                    if (!info.Directory.Exists)
                    {
                        info.Directory.Create();
                    }
                    FileStream stream = info.Create();
                    stream.Write(request.BinaryResponse, 0, request.BinaryResponse.Length);
                    stream.Close();
                }
                _filesUpdated++;
            }
            catch (Exception exception)
            {
                Auxiliary.WriteLog(
	                $"Exception while receiving file \"{request.Request}\"\r\nDestination: {((info != null) ? info.FullName : "FileInfo is null")}\r\n{exception.ToString()}");
            }
        }

        private void RequestNextFile(ClientRequest Request)
        {
            if (this._files.Count > 0)
            {
                Request.Request = this._files[0].FileName;
                Auxiliary.WriteLog("Requesting the file " + Request.Request);
            }
            else
            {
                this.AbortUpdate(Request);
            }
        }

        public void Update(ClientProtocol client, ClientRequest firstRequest, string product, string directory, string tempDirectory)
        {
            this._Client = client;
            this._Product = product;
            this._SourceDirectory = new DirectoryInfo(directory);
            this._DestinationDirectory = (tempDirectory != "") ? new DirectoryInfo(tempDirectory) : this._SourceDirectory;
            this._filesUpdated = 0;
            client.ResponseReceived += new ClientProtocol.ResponseReceivedEventHandler(this.ClientResponseReceived);
            Auxiliary.WriteLog(
	            $"ClientSideUpdateProtocol::\r\nSourceDirectory: {this._SourceDirectory.FullName}\r\nDestinationDirectory: {this._DestinationDirectory.FullName}");
            firstRequest.Request = "UPDATE " + this._Product;
        }

        public delegate void UpdateCompletedEventHandler(int FilesUpdated);
    }
}

