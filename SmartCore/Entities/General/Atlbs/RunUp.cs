using System;
using System.Reflection;
using CAS.Entity.Models.DTO.General;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.Atlbs
{
	/// <summary>
	/// Класс описывает запуск двигателя или ВСУ
	/// </summary>
	[Table("Runups", "dbo", "ItemId")]
	[Dto(typeof(RunUpDTO))]
	[Serializable]
	public class RunUp : AbstractRecord
	{
		private static Type _thisType;

		#region public Int32 FlightId { get; set; }
		/// <summary>
		/// Ид полета в рамках которого производился запуск
		/// </summary>
		[TableColumnAttribute("FlightId")]
		public Int32 FlightId { get; set; }

		public static PropertyInfo FlightIdProperty
		{
			get { return GetCurrentType().GetProperty("FlightId"); }
		}
		#endregion

		#region public Int32 BaseComponentId { get; set; }
		/// <summary>
		/// Ид базовой детали, для которой производится запуск
		/// </summary>
		[TableColumnAttribute("BaseComponentId")]
		public int BaseComponentId { get; set; }
		#endregion

		#region public TimeSpan StartTime { get; set; }
		/// <summary>
		/// время начала пуска
		/// </summary>
		[TableColumnAttribute("StartTime")]
		public TimeSpan StartTime { get; set; }
		#endregion

		#region public RunUpType RunUpType { get; set; }
		/// <summary>
		/// Id Типа запуска двигателя/ВСУ
		/// </summary>
		[TableColumnAttribute("RunUpType")]
		public RunUpType RunUpType { get; set; }

		#endregion

		#region public Int32 RunUpPhaseId { get; set; }
		/// <summary>
		/// фазы запуска двигателя/ВСУ
		/// </summary>
		[TableColumnAttribute("RunUpPhase")]
		public DetectionPhase RunUpPhase { get; set; }

		#endregion

		#region public RunUpCondition RunUpCondition { get; set; }
		/// <summary>
		/// Состояние запуска двигателя: Удачно/Неудачно/Сбой-Авария
		/// </summary>
		[TableColumnAttribute("RunUpCondition")]
		public RunUpCondition RunUpCondition { get; set; }
		#endregion

		#region public TimeSpan EndTime { get; set; }
		/// <summary>
		/// время окончания пуска
		/// </summary>
		[TableColumnAttribute("EndTime")]
		public TimeSpan EndTime { get; set; }
		#endregion

		#region public Int32 EndPhaseId { get; set; }
		/// <summary>
		/// Id фазы отключения двигателя/ВСУ
		/// </summary>
		[TableColumnAttribute("EndPhase")]
		public DetectionPhase EndPhase { get; set; }

		#endregion

		#region public Int32 ShutDownReasonId { get; set; }
		/// <summary>
		///  
		/// </summary>
		[TableColumnAttribute("ShutDownReasonId")]
		public Int32 ShutDownReasonId { get; set; }
		#endregion

		#region public ShutDownType ShutDownType { get; set; }
		/// <summary>
		/// Тип отклюяения Двигателя/ВСУ 
		/// </summary>
		[TableColumnAttribute("ShutDownType")]
		public ShutDownType ShutDownType { get; set; }
		#endregion

		#region public TimeSpan LandTime { get; set; }
		/// <summary>
		/// время работы на земле
		/// </summary>
		[TableColumnAttribute("LandTime")]
		public TimeSpan LandTime { get; set; }
		#endregion

		#region public TimeSpan AirTime { get; set; }
		/// <summary>
		/// время работы в воздухе
		/// </summary>
		[TableColumnAttribute("AirTime")]
		public TimeSpan AirTime { get; set; }
		#endregion


		#region public override DateTime RecordDate { get; set; }
		/// <summary>
		/// Дата и время произведения пуска
		/// </summary>
		[TableColumnAttribute("RecordDate")]
		public override DateTime RecordDate { get; set; }
		#endregion

		#region public override Lifelength OnLifelength { get; set; }

		private Lifelength _lifelength;
		/// <summary>
		/// наработка при которой была выполнена директива
		/// </summary>
		[TableColumnAttribute("OnLifelength")]
		public override Lifelength OnLifelength
		{
			get { return _lifelength ?? (_lifelength = Lifelength.Null); }
			set { _lifelength = value; }
		}
		#endregion

		#region override public string Remarks { get; set; }
		/// <summary>
		/// Доп информация к записи
		/// </summary>
		public override string Remarks { get; set; }
		#endregion

		/*
		 *  Дополнительные своиства
		 */
		#region public BaseComponent BaseComponent { get; set; }

		public BaseComponent BaseComponent { get; set; }
		#endregion

		#region public Int32 TotalMinutes { get; }
		/// <summary>
		/// Возвращает время работы в минутах
		/// </summary>
		public Int32 TotalMinutes
		{
			get
			{
				Int32 x = (Int32)(EndTime.TotalMinutes - StartTime.TotalMinutes);
				if (x < 0) x += 24 * 60;
				return x;
			}
		}
		#endregion

		#region public Lifelength Lifelength { get; }
		/// <summary> 
		/// Возвращает наработку за данный пуск
		/// </summary>
		public Lifelength Lifelength
		{
			get { return new Lifelength(null, 1, TotalMinutes); }
		}
		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(RunUp));
		}
		#endregion

		public RunUp()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.RunUp;
			RunUpType = RunUpType.RunUp;
			RunUpPhase = DetectionPhase.RunUpPoint;
			RunUpCondition = RunUpCondition.Satisfactory;
			EndPhase = DetectionPhase.Parked;
		}
	}
}
