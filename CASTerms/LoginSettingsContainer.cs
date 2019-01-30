namespace CASTerms
{
    /// <summary>
    /// Объект содежащий настройки подключения
    /// </summary>
    public class LoginSettingsContainer
    {
        private string _password;
        private string _username;
        private string _lastConnectedServer;
        private string[] _servers;
        private bool _isSimpleAuthentication;
        private bool _saveUsernamePassword;

        /// <summary>
        /// Создается объект содержащий настройки подключения
        /// </summary>
        internal LoginSettingsContainer()
        {
            _password = "";
            _username = "";
            _lastConnectedServer = "";
            _servers = new string[0];
            _isSimpleAuthentication = false;
            _saveUsernamePassword = false;
        }

        /// <summary>
        /// Создается объект содержащий настройки подключения
        /// </summary>
        /// <param name="servers">Список серверов к которым происходило подключение</param>
        /// <param name="lastConnectedServer">Сервер к которому было последнее успешное подключение</param>
        /// <param name="isSimpleAuthentication">Определяет тип аутентификации</param>
        /// <param name="saveUsernamePassword">Сохранять ли логин и пароль</param>
        /// <param name="password">Пароль</param>
        /// <param name="username">Логин</param>
        public LoginSettingsContainer(string[] servers, string lastConnectedServer, bool isSimpleAuthentication, bool saveUsernamePassword, string username, string password)
        {
            _servers = servers;
            _lastConnectedServer = lastConnectedServer;
            _isSimpleAuthentication = isSimpleAuthentication;
            _saveUsernamePassword = saveUsernamePassword;
            _password = password;
            _username = username;
        }

        /// <summary>
        /// Пароль
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        /// <summary>
        /// Login 
        /// </summary>
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        /// <summary>
        /// Сервер к которому было последнее успешное подключение
        /// </summary>
        public string LastConnectedServer
        {
            get { return _lastConnectedServer; }
            set { _lastConnectedServer = value; }
        }

        /// <summary>
        /// Список серверов к которым происходило подключение
        /// </summary>
        public string[] Servers
        {
            get { return _servers; }
            set { _servers = value; }
        }

        /// <summary>
        /// Является ли подключение Simple(SqlServer)
        /// </summary>
        public bool IsSimpleAuthentication
        {
            get { return _isSimpleAuthentication; }
            set { _isSimpleAuthentication = value; }
        }

        /// <summary>
        /// Сохранять ли пароль и Login
        /// </summary>
        public bool SaveUsernamePassword
        {
            get { return _saveUsernamePassword; }
            set { _saveUsernamePassword = value; }
        }
    }
}