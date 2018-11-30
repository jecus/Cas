namespace CasNetworkObserver
{
    using CasProtocol;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Timers;

    public class CasNetworkObserver
    {
        private int _attempts;
        private BroadcastProtocol _broadcast;
        /// <summary>
        /// Начальная директирия CAS-а вида (C:\ProgrammFiles(x86)\Avalon Worldgroup Inc\Continuing Airworthiness System)
        /// </summary>
        private DirectoryInfo _casInstallationDirectory = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), @"Avalon Worldgroup Inc\Continuing Airworthiness System"));
        private ClientProtocol _client;
        private string _product = "CAS x86";
        /// <summary>
        /// IP адрес сервера
        /// </summary>
        private IPAddress _serverIP;
        private DirectoryInfo _tempDirectory;
        private Timer _timer;
        private bool _updateProtocol;

        public DirectoryInfo CasInstallationDirectory
        {
            get { return _casInstallationDirectory; }
            set { _casInstallationDirectory = value; }
        }

        public string Product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
            }
        }

        public DirectoryInfo TempDirectory
        {
            get
            {
                return _tempDirectory;
            }
        }

        private void BeginUpdate(ClientRequest firstRequest)
        {
            ClientSideUpdateProtocol protocol = new ClientSideUpdateProtocol();
            protocol.UpdateCompleted += updateProtocol_UpdateCompleted;
            string product = _product;
            string fullName = _casInstallationDirectory.FullName;
            string tempDirectory = GetTempDirectory();
            _updateProtocol = true;
            protocol.Update(_client, firstRequest, product, fullName, tempDirectory);
        }

        private void BroadcastMessageReceived(string message, IPEndPoint remoteEp)
        {
            if (message.StartsWith("WELCOME") && (CasServerFound != null))
            {
                string database = "";
                string[] strArray = message.Split(new[] { '\n' });
                if ((strArray.Length >= 2) && strArray[1].StartsWith("ACTIVE DATABASE "))
                {
                    database = strArray[1].Substring(15).Trim();
                }
                if (this._timer != null)
                {
                    this._timer.Enabled = false;
                    this._timer = null;
                    this._serverIP = remoteEp.Address;
                    this.CasServerFound(database);
                }
            }
        }

        #region public void CheckUpdates()
        /// <summary>
        /// Инициализирует проверку наличия обновлений
        /// </summary>
        public void CheckUpdates()
        {
            if (_serverIP != null)
            {
                //если IP сервеа задан, инициализируется клиентский протокол
                _client = new ClientProtocol();
                _client.ServerConnected += Client_ServerConnected;
                _client.ResponseReceived += Client_ResponseReceived;
                _client.LogEntryAdded += Network_LogEntryAdded;
                _client.InitializeConnect(_serverIP, 0x2ac3);
            }
            else if (UpdateComplete != null)
            {
                //Если IP сервера не задач и есть подписка на событие обновления
                //Возбуждение события обновления
                UpdateComplete(false);
            }
        }
        #endregion

        #region
        public void Client_ResponseReceived(ClientRequest LastRequest, ClientRequest NextRequest)
        {
            if (!this._updateProtocol && (NextRequest != null))
            {
                NextRequest.Request = "BUE";
                NextRequest.AbortConnection = true;
            }
        }
        #endregion

        private void Client_ServerConnected(ServerConnectedResult ConnectionResult, string WelcomeMessage, ClientRequest FirstRequest)
        {
            if (ConnectionResult == ServerConnectedResult.Connected)
            {
                if (WelcomeMessage.StartsWith("WELCOME"))
                {
                    Auxiliary.WriteLog("CasNetworkObserver:: Connected to server with welcome message:\r\n" + WelcomeMessage);
                    this.BeginUpdate(FirstRequest);
                }
                else if (this.UpdateComplete != null)
                {
                    this.UpdateComplete(false);
                }
            }
            else
            {
                if (this.UpdateComplete != null)
                {
                    this.UpdateComplete(false);
                }
                this.Log(WelcomeMessage);
            }
        }

        #region private FileInfo DeployCopier()
        /// <summary>
        /// Осуществляет поиск exe-файла копировщика
        /// </summary>
        /// <returns></returns>
        private FileInfo DeployCopier()
        {
            try
            {
                FileInfo existCopier = new FileInfo(Path.Combine( Directory.GetCurrentDirectory(), "Copier.exe"));
                if (existCopier.Exists)
                    return existCopier;

                byte[] resource = this.GetResource("Copier.exe");
                if (resource == null)
                {
                    return null;
                }
                FileInfo info = new FileInfo(Path.Combine(this._tempDirectory.FullName, "Copier.exe"));
                using (FileStream stream = new FileStream(info.FullName, FileMode.Create, FileAccess.Write))
                {
                    stream.Write(resource, 0, resource.Length);
                }
                return info;
            }
            catch (Exception exception)
            {
                this.Log("Exception while writing Copier.exe\r\n" + exception.Message);
                return null;
            }
        }
        #endregion

        public void FindServers()
        {
            if (_broadcast == null)
            {
                _broadcast = new BroadcastProtocol();
                _broadcast.LogEntryAdded += Network_LogEntryAdded;
                _broadcast.MessageReceived += BroadcastMessageReceived;
                _broadcast.Listen(0x2ac1);
            }
            _broadcast.SendMessage("CAS SERVER NEEDED", 0x2ac2);
            _attempts++;
            if (_timer == null)
            {
                _timer = new Timer(1000.0);
                _timer.AutoReset = true;
                _timer.Elapsed += TimeOutElapsed;
                _timer.Enabled = true;
            }
        }

        private byte[] GetResource(string resource)
        {
            try
            {
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                ManifestResourceInfo manifestResourceInfo = executingAssembly.GetManifestResourceInfo(resource);
                if (manifestResourceInfo == null)
                {
                    string[] manifestResourceNames = executingAssembly.GetManifestResourceNames();
                    for (int i = 0; i < manifestResourceNames.Length; i++)
                    {
                        if (manifestResourceNames[i].EndsWith(resource))
                        {
                            resource = manifestResourceNames[i];
                            manifestResourceInfo = executingAssembly.GetManifestResourceInfo(resource);
                            break;
                        }
                    }
                }
                if (manifestResourceInfo != null)
                {
                    Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(resource);
                    using (BinaryReader reader = new BinaryReader(manifestResourceStream))
                    {
                        return reader.ReadBytes(System.Convert.ToInt32(manifestResourceStream.Length));
                    }
                }
                return null;
            }
            catch (Exception exception)
            {
                Log("Exception while reading resource streamr\n" + exception);
                return null;
            }
        }

        private string GetTempDirectory()
        {
            string tempPath = Path.GetTempPath();
            Random random = new Random();
            string str2 = string.Concat(new object[] { random.Next(0x186a0, 0xf423f), "-", random.Next(0x186a0, 0xf423f), "-", random.Next(0x186a0, 0xf423f), "-", random.Next(0x186a0, 0xf423f) });
            _tempDirectory = new DirectoryInfo(Path.Combine(tempPath, str2));
            return _tempDirectory.FullName;
        }

        private void Log(object logEntry)
        {
            if (LogEntryAdded != null)
            {
                LogEntryAdded(logEntry);
            }
        }

        private void Network_LogEntryAdded(object logEntry)
        {
            Log(logEntry);
        }

        #region private void StartCopyProcess()
        /// <summary>
        /// Осуществляет запуск процесса копирования загруженных файлов из временного директория
        /// <br/> в основную папку CAS-а
        /// </summary>
        private void StartCopyProcess()
        {
            try
            {
                FileInfo info = DeployCopier();
                if ((info == null) || !info.Exists)
                {
                    Auxiliary.WriteLog("Failed to deploy copier...");
                }
                else
                {
                    //Запуск копировщика
                    Process copier = 
                    new Process
                        {
                            StartInfo =
                                {
                                    FileName = info.FullName, 
                                    CreateNoWindow = true, 
                                    UseShellExecute = false, 
                                    Arguments = "\"" + 
                                    _tempDirectory.FullName + "\" \"" + 
                                    _casInstallationDirectory.FullName + "\" CAS.exe"
                                }
                        };
                    copier.Start();
                    copier.WaitForExit();
                }
            }
            catch (Exception exception)
            {
                Auxiliary.WriteLog("Exception while starting copy process...\r\n" + exception);
            }
        }
        #endregion

        private void TimeOutElapsed(object sender, ElapsedEventArgs e)
        {
            if (_timer != null)
            {
                if (_attempts < 2)
                {
                    FindServers();
                }
                else
                {
                    _timer.Enabled = false;
                    _timer = null;
                    if (CasServerFound != null)
                    {
                        CasServerFound("");
                    }
                }
            }
        }

        private void updateProtocol_UpdateCompleted(int FilesUpdated)
        {
            this._updateProtocol = false;
            if (this.UpdateComplete != null)
            {
                this.UpdateComplete(FilesUpdated > 0);
            }
            if (FilesUpdated > 0)
            {
                this.StartCopyProcess();
            }
        }

        #region Events
        /// <summary>
        /// Событие нахождения сервера CAS
        /// </summary>
        public event CasServerFoundEventHandler CasServerFound;
        /// <summary>
        /// Событие занесения в журнал сообщения
        /// </summary>
        public event LogEntryEventHandler LogEntryAdded;
        /// <summary>
        /// Событие завершения обновления
        /// </summary>
        public event UpdateCompleteEventHandler UpdateComplete;
       
        #endregion

        #region Delegates
        /// <summary>
        /// Делегат, описывающий событие нахождения сервера CAS
        /// </summary>
        /// <param name="database">название найденой базы данных</param>
        public delegate void CasServerFoundEventHandler(string database);
        /// <summary>
        /// Делегат, описыващий событие завершения обновления
        /// </summary>
        /// <param name="restartTheProgram">Перезапустить программу</param>
        public delegate void UpdateCompleteEventHandler(bool restartTheProgram);

        #endregion
    }
}

