using System;
using System.Text;

namespace EntityCore.Interfaces.ExecutorServices.Arcitecture
{
	public class DbQuery
	{
		#region public String Branch

		/// <summary>
		/// ветвь запроса
		/// </summary>
		public string Branch { get; set; }
		#endregion

		#region public String QueryString

		/// <summary>
		/// Возвращает строку запроса
		/// </summary>
		public string QueryString { get; set; }
		#endregion

		//#region public Type ElementType

		//private Type _elementType;
		///// <summary>
		///// Возвращает Тип объектов, чьи элементы должны быть получены в результате запроса
		///// </summary>
		//public Type ElementType
		//{
		//	get { return _elementType; }
		//}
		//#endregion

		#region private DbQuery()

		private DbQuery()
		{

		}
		#endregion

	}
}