using System;
using CAA.Entity.Models.DTO;
using CAS.Entity.Models.DTO.Dictionaries;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.CAA.Event
{
	[CAADto(typeof(CAAEventCategorieDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class CAAEventCategory : StaticDictionary
	{
		private int _weight;
		private LogicOperation _minCompareOp;
		private LogicOperation _maxCompareOp;
		private int _eventCountInMinPeriod;
		private int _eventCountInMaxPeriod;
		private Lifelength _minReportPeriod;
		private Lifelength _maxReportPeriod;

		#region private static CommonDictionaryCollection<CAAEventCategory> _Items = new CommonDictionaryCollection<CAAEventCategory>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<CAAEventCategory> _Items = new CommonDictionaryCollection<CAAEventCategory>();
		#endregion

		/*
		 * Предопределенные типы
		 */

		#region public static CAAEventCategory A = new CAAEventCategory(1, "A", "A", 1);
		/// <summary>
		/// Почти невозможное
		/// </summary>
		public static CAAEventCategory A = new CAAEventCategory(1, "A", "A", 1);
		#endregion

		#region public static CAAEventCategory B = new CAAEventCategory(2, "B", "B", 2);
		/// <summary>
		/// Маловероятное
		/// </summary>
		public static CAAEventCategory B = new CAAEventCategory(2, "B", "B", 2);
		#endregion

		#region public static CAAEventCategory C = new CAAEventCategory(3, "C", "C", 3);
		/// <summary>
		/// Редкое
		/// </summary>
		public static CAAEventCategory C = new CAAEventCategory(3, "C", "C", 3);
		#endregion

		#region public static CAAEventCategory D = new CAAEventCategory(4, "D", "D", 4);
		/// <summary>
		/// Периодическое
		/// </summary>
		public static CAAEventCategory D = new CAAEventCategory(4, "D", "D", 4);
		#endregion

		#region public static CAAEventCategory E = new CAAEventCategory(5, "E", "E", 5);
		/// <summary>
		/// Частое
		/// </summary>
		public static CAAEventCategory E = new CAAEventCategory(5, "E", "E", 5);
		#endregion

		#region public static CAAEventCategory UNK = new CAAEventCategory(-1, "UNK", "Unknown", 0);
		/// <summary>
		/// неизвестный
		/// </summary>
		public static CAAEventCategory UNK = new CAAEventCategory(-1, "UNK", "Unknown", 0);
		#endregion

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

		#region public static CAAEventCategory GetItemById(Int32 maintenanceTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="maintenanceTypeId"></param>
		/// <returns></returns>
		public static CAAEventCategory GetItemById(Int32 maintenanceTypeId)
		{
			foreach (CAAEventCategory t in _Items)
				if (t.ItemId == maintenanceTypeId)
					return t;
			//
			return UNK;
		}

		#endregion

		#region static public CommonDictionaryCollection<CAAEventCategory> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<CAAEventCategory> Items
		{
			get
			{
				return _Items;
			}
		}

		public int OperatorId { get; set; }

		#endregion

		#region public override string ToString()
		/// <summary>
		/// Переводит тип директивы в строку
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return FullName;
		}
		#endregion

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
			SmartCoreObjectType = SmartCoreType.EventCategory;
		}
		#endregion

		#region public CAAEventCategory(Int32 itemId, String shortName, String fullName, int weight)

		/// <summary>
		/// Конструктор создает объект повреждения
		/// </summary>
		/// <param name="itemId"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		/// <param name="weight"></param>
		public CAAEventCategory(Int32 itemId, String shortName, String fullName, int weight)
		{
			ItemId = itemId;
			ShortName = shortName;
			FullName = fullName;
			_weight = weight;

			_Items.Add(this);
		}
		#endregion

		#region public override int CompareTo(object y)
		public override int CompareTo(object y)
		{
			if (y is CAAEventCategory)
				return FullName.CompareTo(((CAAEventCategory)y).FullName);
			return 0;
		}
		#endregion
	}
}