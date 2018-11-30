using System;

namespace SmartCore.Management
{

    /// <summary>
    /// Описывает текущего пользователя 
    /// </summary>
    public class CasUser
    {

        /// <summary>
        /// Логин пользователя
        /// </summary>
        public String Login { get; set; }

        /// <summary>
        /// Пустой конструктор
        /// </summary>
        public CasUser()
        {
        }

        /// <summary>
        /// Представляет пользователя в виде строки 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Login;
        }


    }
}
