using System;
using System.Collections.Generic;
using System.Text;

namespace SmartCore.Entities.Dictionaries
{
    class AuthenticationType
    {
        #region public Int32 AuthenticationTypeId { get; set; }


        /// <summary>
        /// Идентификатор Типа аутентификации
        /// </summary>
        public Int32 AuthenticationTypeId { get; set; }

        #endregion

        #region        public String AuthenticationTypeName { get; set; }


        /// <summary>
        /// Тип аутентификации
        /// </summary>
        public String AuthenticationTypeName { get; set; }

        #endregion
    }
}
