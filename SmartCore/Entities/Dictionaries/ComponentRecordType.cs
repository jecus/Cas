using System;
using System.Linq;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
    public class ComponentRecordType : StaticDictionary
    {
		#region public static CommonDictionaryCollection<ComponentRecordType> _Items = new CommonDictionaryCollection<ComponentRecordType>();
		/// <summary>
		/// Содержит все элементы
		/// </summary>
		private static CommonDictionaryCollection<ComponentRecordType> _Items = new CommonDictionaryCollection<ComponentRecordType>();
		#endregion
		/*
         * Предопределенные типы
         */

		#region public static ComponentRecordType Overhaul = new ComponentRecordType(1, "OH", "Overhaul", "");
		/// <summary>
		/// 
		/// </summary>
		public static ComponentRecordType Overhaul = new ComponentRecordType(1, "OH", "Overhaul", "");
		#endregion

		#region public static ComponentRecordType DetailInspection = new ComponentRecordType(5, "INSP", "Detail Inspection", "");
		/// <summary>
		/// 
		/// </summary>
		public static ComponentRecordType DetailInspection = new ComponentRecordType(5, "INSP", "Detail Inspection", "");
		#endregion

		#region public static ComponentRecordType ShopVisit = new ComponentRecordType(6, "SV", "Shop Visit", "");
		/// <summary>
		/// 
		/// </summary>
		public static ComponentRecordType ShopVisit = new ComponentRecordType(6, "SV", "Shop Visit", "");
		#endregion

		#region public static ComponentRecordType Remove = new ComponentRecordType(13, "RMV", "Remove", "");
		/// <summary>
		/// 
		/// </summary>
		public static ComponentRecordType Remove = new ComponentRecordType(13, "RMV", "Remove", "");
		#endregion

		#region public static ComponentRecordType LifeProlongation = new ComponentRecordType(17, "LP", "Life Proplongation", "");
		/// <summary>
		/// 
		/// </summary>
		public static ComponentRecordType LifeProlongation = new ComponentRecordType(17, "LP", "Life Proplongation", "");
		#endregion

		#region  public static ComponentRecordType Calibration = new ComponentRecordType(18, "Cb", "Calibration", "");
		/// <summary>
		/// Калибровка
		/// </summary>
		public static ComponentRecordType Calibration = new ComponentRecordType(18, "Cb", "Calibration", "");
		#endregion

		#region public static ComponentRecordType Conservation = new ComponentRecordType(19, "Preservation", "Preservation", "");
		/// <summary>
		/// Консервация
		/// </summary>
		public static ComponentRecordType Preservation = new ComponentRecordType(19, "Preservation", "Preservation", "");
		#endregion

		#region public static ComponentRecordType Replace = new ComponentRecordType(20, "Rplc", "Replace", "");
		/// <summary>
		/// Перемещение
		/// </summary>
		public static ComponentRecordType Replace = new ComponentRecordType(20, "Rplc", "Replace", "");
		#endregion

		#region public static ComponentRecordType WorkshopCheck = new ComponentRecordType(21, "WSC", "Workshop Check", "");
		/// <summary>
		/// проверка в мастерской
		/// </summary>
		public static ComponentRecordType WorkshopCheck = new ComponentRecordType(21, "WSC", "Workshop Check", "");
		#endregion

		#region public static ComponentRecordType Scrap = new ComponentRecordType(23, "Scrap", "Scrap", "");
		/// <summary>
		/// Отдать на слом
		/// </summary>
		public static ComponentRecordType Scrap = new ComponentRecordType(23, "Scrap", "Scrap", "");
		#endregion

		#region public static ComponentRecordType FunctionalCheck = new ComponentRecordType(24, "FC", "Functional Check", "");
		/// <summary>
		/// Проверка работоспособности
		/// </summary>
		public static ComponentRecordType FunctionalCheck = new ComponentRecordType(24, "FC", "Functional  Check", "");
		#endregion

		#region public static ComponentRecordType BatteryChange = new ComponentRecordType(25, "Battery Change", "Battery Change", "");
		/// <summary>
		/// Замена батарей
		/// </summary>
		public static ComponentRecordType BatteryChange = new ComponentRecordType(25, "Battery Change", "Battery Change", "");
		#endregion

		#region public static ComponentRecordType Test = new ComponentRecordType(26, "Test", "Test", "");
		/// <summary>
		/// Тест
		/// </summary>
		public static ComponentRecordType Test = new ComponentRecordType(26, "Test", "Test", "");
		#endregion

		#region public static ComponentRecordType WeightCheck = new ComponentRecordType(27, "Weight Check", "Weight Check", "");
		/// <summary>
		/// Проверка Веса
		/// </summary>
		public static ComponentRecordType WeightCheck = new ComponentRecordType(27, "Weight Check", "Weight Check", "");
		#endregion

		#region  public static ComponentRecordType Discard = new ComponentRecordType(28, "Discard", "Discard", "");
		/// <summary>
		/// 
		/// </summary>
		public static ComponentRecordType Discard = new ComponentRecordType(28, "Discard", "Discard", "");
		#endregion

		#region public static ComponentRecordType Borescope = new ComponentRecordType(29, "BI", "Borescope", "");
		/// <summary>
		/// 
		/// </summary>
		public static ComponentRecordType Borescope = new ComponentRecordType(29, "BI", "Borescope", "");
		#endregion

		#region public static ComponentRecordType Repair = new ComponentRecordType(30, "Repair", "Repair", "");
		/// <summary>
		/// 
		/// </summary>
		public static ComponentRecordType Repair = new ComponentRecordType(30, "Repair", "Repair", "");
		#endregion

		#region public static ComponentRecordType BenchCheck = new ComponentRecordType(31, "BC", "Bench Check", "");
		/// <summary>
		/// 
		/// </summary>
		public static ComponentRecordType BenchCheck = new ComponentRecordType(31, "BC", "Bench Check", "");
		#endregion

		#region public static ComponentRecordType Weighing = new ComponentRecordType(32, "Weighing", "Weighing", "");
		/// <summary>
		/// 
		/// </summary>
		public static ComponentRecordType Weighing = new ComponentRecordType(32, "Weighing", "Weighing", "");
		#endregion

		#region public static ComponentRecordType Restore = new ComponentRecordType(33, "Restore", "Restore", "");
		/// <summary>
		/// 
		/// </summary>
		public static ComponentRecordType Restore = new ComponentRecordType(33, "Restore", "Restore", "");
		#endregion

		#region public static ComponentRecordType NDT = new ComponentRecordType(35, "NDT", "NDT", "");

		public static ComponentRecordType NDT = new ComponentRecordType(35, "NDT", "NDT", "");

		#endregion

		#region public static ComponentRecordType LeakTest = new ComponentRecordType(36, "Leak Test", "Leak Test", "");

		public static ComponentRecordType LeakTest = new ComponentRecordType(36, "Leak Test", "Leak Test", "");

		#endregion

		#region public static ComponentRecordType Check = new ComponentRecordType(37, "Check", "Check", "");

		public static ComponentRecordType Check = new ComponentRecordType(37, "Check", "Check", "");

		#endregion

		#region public static ComponentRecordType Inspection = new ComponentRecordType(38, "Revision", "Revision", "");

		public static ComponentRecordType Inspection = new ComponentRecordType(38, "Inspection", "Inspection", "");

		#endregion

		#region public static ComponentRecordType BatteryCharge = new ComponentRecordType(39, "Battery Charge", "Battery Charge", "");

		public static ComponentRecordType BatteryCharge = new ComponentRecordType(39, "Battery Charge", "Battery Charge", "");


		#endregion

		#region public static ComponentRecordType Clean = new ComponentRecordType(40, "Clean", "Clean", "");

		public static ComponentRecordType Clean = new ComponentRecordType(40, "Clean", "Clean", "");

		#endregion

		#region public static ComponentRecordType Service = new ComponentRecordType(41, "Service", "Service", "");

		public static ComponentRecordType Service = new ComponentRecordType(41, "Service", "Service", "");

		#endregion

		#region public static ComponentRecordType Lubricate = new ComponentRecordType(42, "Lubricate", "Lubricate", "");

		public static ComponentRecordType Lubricate = new ComponentRecordType(42, "Lubricate", "Lubricate", "");

		#endregion

		#region public static ComponentRecordType Verification = new ComponentRecordType(43, "Verification", "Verification", "");

		public static ComponentRecordType Verification = new ComponentRecordType(43, "Verification", "Verification", "");


		#endregion

		#region public static ComponentRecordType DocumentRevision = new ComponentRecordType(44, "Document Revision", "Document Revision", "");

		public static ComponentRecordType DocumentRevision = new ComponentRecordType(44, "Document Revision", "Document Revision", "");


		#endregion

		#region public static ComponentRecordType HydrostaticTest = new ComponentRecordType(45, "Hydrostatic Test", "Hydrostatic Test", "");

		public static ComponentRecordType HydrostaticTest = new ComponentRecordType(45, "Hydrostatic Test", "Hydrostatic Test", "");


		#endregion

		#region public static ComponentRecordType Store = new ComponentRecordType(46, "Store", "Store", "");

		public static ComponentRecordType Store = new ComponentRecordType(46, "Store", "Store", "");

		#endregion

		#region public static ComponentRecordType Modification = new ComponentRecordType(47, "Modification", "Modification", "");

		public static ComponentRecordType Modification = new ComponentRecordType(47, "Modification", "Modification", "");


		#endregion

		#region public static ComponentRecordType Depreservation = new ComponentRecordType(48, "Depreservation", "Depreservation", "");

		public static ComponentRecordType Depreservation = new ComponentRecordType(48, "Depreservation", "Depreservation", "");


		#endregion

		#region public static ComponentRecordType Revision = new ComponentRecordType(49, "Revision", "Revision", "");

		public static ComponentRecordType Revision = new ComponentRecordType(49, "Revision", "Revision", "");

		#endregion

		#region public static ComponentRecordType Adjust = new ComponentRecordType(50, "Adjust", "Adjust", "");

		public static ComponentRecordType Adjust = new ComponentRecordType(50, "Adjust", "Adjust", "");

		#endregion

		#region public static ComponentRecordType Examine = new ComponentRecordType(51, "Examine", "Examine", "");

		public static ComponentRecordType Examine = new ComponentRecordType(51, "Examine", "Examine", "");

		#endregion

		#region public static ComponentRecordType Measure = new ComponentRecordType(52, "Measure", "Measure", "");

		public static ComponentRecordType Measure = new ComponentRecordType(52, "Measure", "Measure", "");

		#endregion

		#region public static ComponentRecordType Monitor = new ComponentRecordType(53, "Monitor", "Monitor", "");

		public static ComponentRecordType Monitor = new ComponentRecordType(53, "Monitor", "Monitor", "");

		#endregion

		#region public static ComponentRecordType Record = new ComponentRecordType(54, "Record", "Record", "");

		public static ComponentRecordType Record = new ComponentRecordType(54, "Record", "Record", "");

		#endregion

		#region public static ComponentRecordType Set = new ComponentRecordType(55, "Set", "Set", "");

		public static ComponentRecordType Set = new ComponentRecordType(55, "Set", "Set", "");

		#endregion

		#region public static ComponentRecordType Task = new ComponentRecordType(56, "Task", "Task", "");

		public static ComponentRecordType Task = new ComponentRecordType(56, "Task", "Task", "");

        #endregion

        #region public static ComponentRecordType InspectionTest = new ComponentRecordType(57, "Inspection Test", "Inspection Test", "");

        public static ComponentRecordType InspectionTest = new ComponentRecordType(57, "Inspection Test", "Inspection Test", "");

        #endregion

        #region public static ComponentRecordType OperationalCheck = new ComponentRecordType(58, "Operational Check", "Operational Check", "");

        public static ComponentRecordType OperationalCheck = new ComponentRecordType(58, "Operational Check", "Operational Check", "");

        #endregion

        #region public static ComponentRecordType Unknown = new ComponentRecordType(-1, "Unknown", "Unknown", "Unknown");
        /// <summary> 
        /// Неизвестный объект
        /// </summary>
        public static ComponentRecordType Unknown = new ComponentRecordType(-1, "Unknown", "Unknown", "Unknown");
		#endregion

		/*
         * Методы
         */

		#region public static ComponentRecordType GetItemById(Int32 DirectiveTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="directiveTypeId"></param>
		/// <returns></returns>
		public static ComponentRecordType GetItemById(int directiveTypeId)
        {
            foreach (ComponentRecordType t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

		#endregion

		#region static public CommonDictionaryCollection<ComponentRecordType> Items
		/// <summary>
		/// Возвращает список  элементов коллекции
		/// </summary>
		public static CommonDictionaryCollection<ComponentRecordType> Items
        {
            get
            {
                return _Items;
            }
        }
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
        * Свойства
        */

		/*
         * Реализация
         */
		#region public ComponentRecordType()
		/// <summary>
		/// Конструктор создает объект типа директивы
		/// </summary>
		public ComponentRecordType()
        {
        }
		#endregion

		#region public ComponentRecordType(Int32 ItemId, String shortName, String fullName, String commonName)
		/// <summary>
		/// Конструктор создает объект типа директивы
		/// </summary>
		/// <param name="itemID"></param>
		/// <param name="shortName"></param>
		/// <param name="fullName"></param>
		/// <param name="commonName"></param>
		public ComponentRecordType(Int32 itemID, String shortName, String fullName, String commonName)
        {
            ItemId = itemID;
            ShortName = shortName;
            FullName = fullName;
            CommonName = commonName;

            //if (_Items == null) _Items = new List<DetailType>();
            _Items.Add(this);
        }
        #endregion
    }
}
