using System;
using CAA.Entity.Models;
using CAA.Entity.Models.DTO;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.Event
{
	[CAADto(typeof(CAAEventCategorieDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class CAAEventCategory : BaseEntityObject,IOperatable
	{
		private int _weight;
		private LogicOperation _minCompareOp;
		private LogicOperation _maxCompareOp;
		private int _eventCountInMinPeriod;
		private int _eventCountInMaxPeriod;
		private Lifelength _minReportPeriod;
		private Lifelength _maxReportPeriod;

		/*
		 * Свойства 
		 */

		#region public int Weight
		/// <summary>
		/// Степень ущерба
		/// </summary>
		[TableColumn("Weight")]
		[FormControl(250, "Weight")]
		[ListViewData(0.05f, "Weight")]
		[MinMaxValue(1,5)]
		[NotNull]
		public int Weight
		{
			get { return _weight; }
			set { _weight = value; }
		}
		#endregion


		#region public LogicOperation MinCompareOperation
		/// <summary>
		/// Знак при минимальном количестве событий
		/// </summary>
		[TableColumn("MinCompareOp")]
		[ListViewData(0.05f, "")]
		[NotNull]
		public LogicOperation MinCompareOperation
		{
			get { return _minCompareOp; }
			set { _minCompareOp = value; }
		}
		#endregion

		#region public int EventCountMinPeriod
		/// <summary>
		/// Кол-во событий в минимальном отчетном периоде
		/// </summary>
		[TableColumn("EventCountMinPeriod")]
		[FormControl(250, "Num. of event in min. period", 1, "MinCompareOperation", 45, true)]
		[ListViewData(0.15f, "Num. of event in min. period")]
		[MinMaxValue(1, 1000)]
		[NotNull]
		public int EventCountMinPeriod
		{
			get { return _eventCountInMinPeriod; }
			set { _eventCountInMinPeriod = value; }
		}
		#endregion

		#region public Lifelength MinReportPeriod
		/// <summary>
		/// минимальный отчетный период
		/// </summary>
		[TableColumn("MinReportPeriod")]
		[FormControl(250, "min. report period")]
		[ListViewData(0.2f, "min. report period")]
		[NotNull]
		public Lifelength MinReportPeriod
		{
			get { return _minReportPeriod; }
			set { _minReportPeriod = value; }
		}
		#endregion

		#region public LogicOperation MaxCompareOperation
		/// <summary>
		/// Знак при максимальном количестве событий
		/// </summary>
		[TableColumn("MaxCompareOp")]
		[ListViewData(0.05f, "")]
		public LogicOperation MaxCompareOperation
		{
			get { return _maxCompareOp; }
			set { _maxCompareOp = value; }
		}
		#endregion

		#region public int EventCountMaxPeriod
		/// <summary>
		/// Кол-во событий в минимальном отчетном периоде
		/// </summary>
		[TableColumn("EventCountMaxPeriod")]
		[FormControl(250, "Num. of event in MAX. period", 1, "MaxCompareOperation", 45, true)]
		[ListViewData(0.15f, "Num. of event in MAX. period")]
		[MinMaxValue(1, 1000)]
		public int EventCountMaxPeriod
		{
			get { return _eventCountInMaxPeriod; }
			set { _eventCountInMaxPeriod = value; }
		}
		#endregion

		#region public Lifelength MinReportPeriod
		/// <summary>
		/// максимальный отчетный период
		/// </summary>
		[TableColumn("MaxReportPeriod")]
		[FormControl(250, "MAX. report period")]
		[ListViewData(0.2f, "MAX. report period")]
		public Lifelength MaxReportPeriod
		{
			get { return _maxReportPeriod; }
			set { _maxReportPeriod = value; }
		}
		#endregion

		/*
		 * Методы
		 */


		

		public int OperatorId { get; set; }
		
		[FormControl(250, "FullName", Order = 1)]
		[ListViewData(0.2f, "FullName", 1)]
		public string FullName { get; set; }


		/*
		 * Реализация
		 */
		#region public CAAEventCategory()
		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		public CAAEventCategory()
		{
			_weight = 1;
			_eventCountInMinPeriod = 1;
			_eventCountInMaxPeriod = 1;
			_minReportPeriod = Lifelength.Null;
			_maxReportPeriod = Lifelength.Null;
			MinCompareOperation = LogicOperation.Unknown;
			MaxCompareOperation = LogicOperation.Unknown;
			SmartCoreObjectType = SmartCoreType.EventCategory;
		}
		#endregion


	}
}