using System;
using System.Reflection;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Atlbs
{

	/// <summary>
	/// Уровень гидравлических жидкостей агрегата
	/// </summary>
	[Table("HydraulicConditions", "dbo", "ItemId")]
	[Serializable]
	public class HydraulicCondition : BaseEntityObject
	{
		private static Type _thisType;

		/*
		 * Свойства
		 */

		#region public string HydraulicSystem
		private String _hydraulicSystem;
		/// <summary>
		/// Гидравлическая система
		/// </summary>
		[TableColumnAttribute("HydraulicSystem")]
		public string HydraulicSystem
		{
			get { return _hydraulicSystem; }
			set
			{
				_hydraulicSystem = value;
		   //     OnDataChange();
			}
		}
		#endregion

		#region public string FlightId

		/// <summary>
		/// Полет, в рамках которого создана запись
		/// </summary>
		[TableColumnAttribute("FlightId")]
		public Int32 FlightId { get; set; }

		public static PropertyInfo FlightIdProperty
		{
			get { return GetCurrentType().GetProperty("FlightId"); }
		}
		#endregion

		#region public double Remain
		/// <summary>
		/// Количество масла после пред. полета (Qts.)
		/// </summary>
		private double _remain;
		/// <summary>
		/// Количество масла после пред. полета (Qts.)
		/// </summary>
		[TableColumnAttribute("Remain")]
		public double Remain
		{
			get { return _remain; }
			set
			{
				_remain = value;
			}
		}
		#endregion

		#region public double OilAdded
		/// <summary>
		/// Количество добавленного масла (Qts.)
		/// </summary>
		private double _oilAdded;
		/// <summary>
		/// Количество добавленного масла (Qts.)
		/// </summary>
		[TableColumnAttribute("Added")]
		public double OilAdded
		{
			get { return _oilAdded; }
			set
			{
				_oilAdded = value;
			}
		}
		#endregion

		#region public double OnBoard
		/// <summary>
		/// Количество масла перед полетом (Qts.)
		/// </summary>
		private double _onBoard;
		/// <summary>
		/// Количество масла перед полетом (Qts.)
		/// </summary>
		[TableColumnAttribute("OnBoard")]
		public double OnBoard
		{
			get { return _onBoard; }
			set
			{
				_onBoard = value;
			}
		}
		#endregion

		#region public double Spent
		/// <summary>
		/// Количество масла израсходованное в полете (Qts.)
		/// </summary>
		private double _spent;
		/// <summary>
		/// Количество масла израсходованное в полете (Qts.)
		/// </summary>
		[TableColumnAttribute("Spent")]
		public double Spent
		{
			get { return _spent; }
			set
			{
				_spent = value;
			}
		}
		#endregion

		#region public double RemainAfter
		/// <summary>
		/// Количество масла после полета (Qts.)
		/// </summary>
		private double _remainAfter;
		/// <summary>
		/// Количество масла после полета (Qts.)
		/// </summary>
		[TableColumnAttribute("RemainAfter")]
		public double RemainAfter
		{
			get { return _remainAfter; }
			set
			{
				_remainAfter = value;
			}
		}
		#endregion

		/*
		 * Конструктор
		 */
		#region public BaseComponent BaseComponent { get; set; }

		public BaseComponent BaseComponent { get; set; }
		#endregion

		#region public HydraulicCondition()
		/// <summary>
		/// Уровень масла агрегата
		/// </summary>
		public HydraulicCondition()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.HydraulicCondition;
		}
		#endregion

		#region public override string ToString()
		/// <summary>
		/// Преобразование объекта а строку. Значения объекта разделены пробелами
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return _oilAdded + " " + _onBoard + " " + _remain + " " + _spent + " " + _remainAfter;
		}
		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(HydraulicCondition));
		}
		#endregion

	}
}
