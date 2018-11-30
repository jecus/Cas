using System;

namespace SmartCore.Management
{
    /// <summary>
    /// Типы аутентификации при подключении к SQL Серверу
    /// </summary>
    public enum AuthenticationType : int 
    {
        /// <summary>
        /// Аутентификация средствами Windows
        /// </summary>
        Windows = 1,

        /// <summary>
        /// Аутентификация средствами SQL Server
        /// </summary>
        SqlServer
    }
}
