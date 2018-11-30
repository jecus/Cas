using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SmartCore.Management;

namespace SmartCore.Entities.General
{

    /// <summary>
    /// Класс описывает воздушное судно
    /// </summary>
    public class UsersPermission
    {

		/*
		*  Свойства
		*/
		


		#region public Int32 PermissionId { get; set; }
		/// <summary>
		/// Идентификатор записи
		/// </summary>
		public Int32 PermissionId { get; set; }
		#endregion

		#region public Int32 UserId { get; set; }
		/// <summary>
		/// Id пользователя
		/// </summary>
		public Int32 UserId { get; set; }
		#endregion

		#region public Int32 OperatorId { get; set; }
		/// <summary>
		/// Id эксплуатанта, на которого у пользователя есть права
		/// </summary>
		public Int32 OperatorId { get; set; }
		#endregion
		
		/*
		*  Методы 
		*/
		
		#region public UsersPermission()
        /// <summary>
        /// Создает воздушное судно без дополнительной информации
        /// </summary>
        public UsersPermission()
        {
        }
        #endregion


      
        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "";
        }
        #endregion   

    }

}
