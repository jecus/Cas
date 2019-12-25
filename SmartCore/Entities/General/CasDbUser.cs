using System;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General
{

	/// <summary>
	/// Класс описывает воздушное судно
	/// </summary>
	[Table("Users", "dbo", "ItemId")]
	[Serializable]
	public class CasDbUser : BaseEntityObject
	{

		/*
		*  Свойства
		*/
		

		#region public String FullName { get; set; }
		/// <summary>
		/// Полное имя пользователя
		/// </summary>
		[TableColumnAttribute("FullName")]
		public String FullName { get; set; }
		#endregion

		#region public DateTime ExpiryDate { get; set; }
		/// <summary>
		/// Дата, до которой пароль является действительным
		/// </summary>
		[TableColumnAttribute("ExpiryDate")]
		public DateTime ExpiryDate { get; set; }
		#endregion

		#region public Byte[] Photo { get; set; }
		/// <summary>
		/// Фотография пользователя
		/// </summary>
		[TableColumnAttribute("Photo")]
		public Byte[] Photo { get; set; }
		#endregion

		#region public Int32 AuthenticationTypeId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("AuthenticationTypeId")]
		public Int32 AuthenticationTypeId { get; set; }
		#endregion
		
		/*
		*  Методы 
		*/
		
		#region public CasDbUser()
		/// <summary>
		/// Создает воздушное судно без дополнительной информации
		/// </summary>
		public CasDbUser()
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
