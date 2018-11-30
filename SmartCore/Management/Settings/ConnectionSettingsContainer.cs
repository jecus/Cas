namespace SmartCore.Management.Settings

{
    /// <summary>
    /// Класс, содержащий настройки подключения
    /// </summary>
    public class ConnectionSettingsContainer
    {
        private string password;
        private string serverName;
        private string userName;
        private bool isSimple;

        #region Constructors
        /// <summary>
        /// Создается новый объект для хранения настроек подключения с простой(SQLServer) аутентификацией
        /// </summary>
        /// <param name="serverName">Сервер подключения</param>
        public ConnectionSettingsContainer(string serverName)
        {
            this.serverName = serverName;
            isSimple = false;
            password = "";
            userName = "";
        }

        /// <summary>
        /// Создается новый объект для хранения настроек подключения с простой(SQLServer) аутентификацией
        /// </summary>
        /// <param name="serverName">Сервер подключения</param>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        public ConnectionSettingsContainer(string serverName, string userName, string password)
        {
            this.serverName = serverName;
            isSimple = true;
            this.userName = userName;
            this.password = password;
        }

        /// <summary>
        /// Создается новый объект для хранения настроек подключения с простой(SQLServer) аутентификацией
        /// </summary>
        /// <param name="serverName">Сервер подключения</param>
        /// <param name="userName">Имя пользователя</param>
        /// <param name="password">Пароль</param>
        /// <param name="isSimple">Тип аутентификации - SQLServer, если true</param>
        public ConnectionSettingsContainer(string serverName, string userName, string password, bool isSimple)
        {
            this.serverName = serverName;
            this.userName = userName;
            this.password = password;
            this.isSimple = isSimple;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Пароль подключения
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Username
        {
            get { return userName; }
            set { userName = value; }
        }

        /// <summary>
        /// Сервер для подключения
        /// </summary>
        public string ServerName
        {
            get { return serverName; }
            set { serverName = value; }
        }

        /// <summary>
        /// Является ли аутентификация простой(SQLServer)
        /// </summary>
        public bool IsSimple
        {
            get { return isSimple; }
            set { isSimple = value; }
        }
        #endregion
    }
}
