using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
    [Serializable]
    public class DirectiveWorkType : StaticDictionary
    {

        #region private static CommonDictionaryCollection<DirectiveWorkType> _Items = new CommonDictionaryCollection<DirectiveWorkType>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<DirectiveWorkType> _Items = new CommonDictionaryCollection<DirectiveWorkType>();
		#endregion

		/*
         * Предопределенные типы
         */

		#region public static DirectiveWorkType Remove = new DirectiveWorkType(1,"RMV", "Remove","");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType Remove = new DirectiveWorkType(1, "RMV", "Remove", "");
		#endregion

		#region public static DirectiveWorkType Overhaul = new DirectiveWorkType(2, "OH", "Overhaul", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType Overhaul = new DirectiveWorkType(2, "OH", "Overhaul", "");
		#endregion

		#region public static DirectiveWorkType Limitation = new DirectiveWorkType(3, "Limitation", "Change Life Limit", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType ChangeLifeLimit = new DirectiveWorkType(3, "Limitation", "Change Life Limit", "");
		#endregion

		#region public static DirectiveWorkType Discard = new DirectiveWorkType(4, "DIS", "Discard", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType Discard = new DirectiveWorkType(4, "DIS", "Discard", "");
		#endregion

		#region public static DirectiveWorkType Inspection = new DirectiveWorkType(5, "INSP", "Inspection", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType Inspection = new DirectiveWorkType(5, "INSP", "Inspection", "");
		#endregion

		#region public static DirectiveWorkType ShopVisit = new DirectiveWorkType(6, "SV", "Shop Visit", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType ShopVisit = new DirectiveWorkType(6, "SV", "Shop Visit", "");
		#endregion

		#region public static DirectiveWorkType Service = new DirectiveWorkType(7, "SVC", "Service", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType Service = new DirectiveWorkType(7, "SVC", "Service", "");
		#endregion

		#region public static DirectiveWorkType Lubricate = new DirectiveWorkType(8, "LUB", "Lubricate", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType Lubricate = new DirectiveWorkType(8, "LUB", "Lubricate", "");
		#endregion

		#region public static DirectiveWorkType VisualCheck = new DirectiveWorkType(9, "VCK", "Visually Check", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType VisualCheck = new DirectiveWorkType(9, "VCK", "Visually Check", "");
		#endregion

		#region public static DirectiveWorkType SpecialDetailedInspection = new DirectiveWorkType(10, "SDI", "Special Detailed Inspection", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType SpecialDetailedInspection = new DirectiveWorkType(10, "SDI", "Special Detailed Inspection", "");
		#endregion

		#region public static DirectiveWorkType Check = new DirectiveWorkType(11, "Check", "Check", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType Check = new DirectiveWorkType(11, "Check", "Check", "");
		#endregion

		#region public static DirectiveWorkType Modification = new DirectiveWorkType(12, "Modification", "Modification status directive", "Modification Status");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType Modification = new DirectiveWorkType(12, "Modification", "Modification", "Modification Status");
		#endregion

		#region public static DirectiveWorkType Restore = new DirectiveWorkType(13, "RST", "Restore", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType Restore = new DirectiveWorkType(13, "RST", "Restore", "");
		#endregion

		#region public static DirectiveWorkType DetailedInspection = new DirectiveWorkType(14, "DET", "Detailed Inspection", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType DetailedInspection = new DirectiveWorkType(14, "DET", "Detailed Inspection", "");
		#endregion

		#region public static DirectiveWorkType GeneralVisualInspection = new DirectiveWorkType(15, "GVI", "General Visual Inspection", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType GeneralVisualInspection = new DirectiveWorkType(15, "GVI", "General Visual Inspection", "");
		#endregion

		#region public static DirectiveWorkType HSI = new DirectiveWorkType(17, "HSI", "Hot Section Inspection", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType HSI = new DirectiveWorkType(17, "HSI", "Hot Section Inspection", "");
		#endregion

		#region public static DirectiveWorkType OperationalCheck = new DirectiveWorkType(18, "OPC", "Operational Check", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType OperationalCheck = new DirectiveWorkType(18, "OPC", "Operational Check", "");
		#endregion

		#region public static DirectiveWorkType FunctionalCheck = new DirectiveWorkType(19, "FC", "Functional Check", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType FunctionalCheck = new DirectiveWorkType(19, "FC", "Functional Check", "");
		#endregion

		#region public static DirectiveWorkType HydrostaticTest = new DirectiveWorkType(20, "HS", "Hydrostatic Test", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType HydrostaticTest = new DirectiveWorkType(20, "HS", "Hydrostatic Test", "");
		#endregion

		#region public static DirectiveWorkType WeightCheck = new DirectiveWorkType(21, "WC", "Weight Check", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType WeightCheck = new DirectiveWorkType(21, "WC", "Weight Check", "");
		#endregion

		#region public static DirectiveWorkType BenchCheck = new DirectiveWorkType(22, "BC", "Bench Check", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType BenchCheck = new DirectiveWorkType(22, "BC", "Bench Check", "");
		#endregion

		#region public static DirectiveWorkType Borescope = new DirectiveWorkType(24, "BI", "Borescope", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType Borescope = new DirectiveWorkType(24, "BI", "Borescope", "");

		#endregion

		#region public static DirectiveWorkType NDT = new DirectiveWorkType(25, "NDT", "NDT", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType NDT = new DirectiveWorkType(25, "NDT", "NDT", "");

		#endregion

		#region public static DirectiveWorkType Repair = new DirectiveWorkType(26, "Repair", "Repair", "");

		public static DirectiveWorkType Repair = new DirectiveWorkType(26, "Repair", "Repair", "");

		#endregion

		#region public static DirectiveWorkType Test = new DirectiveWorkType(27, "Test", "Test", "");

		public static DirectiveWorkType Test = new DirectiveWorkType(27, "Test", "Test", "");

		#endregion

		#region public static DirectiveWorkType LeakTest = new DirectiveWorkType(28, "Leak Test", "Leak Test", "");

		public static DirectiveWorkType LeakTest = new DirectiveWorkType(28, "Leak Test", "Leak Test", "");

		#endregion

		#region public static DirectiveWorkType DocumentRevision = new DirectiveWorkType(29, "Document Revision", "Document Revision", "");

		public static DirectiveWorkType DocumentRevision = new DirectiveWorkType(29, "Document Revision", "Document Revision", "");


		#endregion

		#region public static DirectiveWorkType Clean = new DirectiveWorkType(30, "Clean", "Clean", "");

		public static DirectiveWorkType Clean = new DirectiveWorkType(30, "Clean", "Clean", "");

		#endregion

		#region public static DirectiveWorkType Revison = new DirectiveWorkType(31, "Revison", "Revison", "");

		public static DirectiveWorkType Revison = new DirectiveWorkType(31, "Revison", "Revison", "");

		#endregion

		#region public static DirectiveWorkType Scrab = new DirectiveWorkType(32, "Scrab", "Scrab", "");

		public static DirectiveWorkType Scrab = new DirectiveWorkType(32, "Scrab", "Scrab", "");

		#endregion

		#region public static DirectiveWorkType Preservation = new DirectiveWorkType(33, "Preservation", "Preservation", "");

		public static DirectiveWorkType Preservation = new DirectiveWorkType(33, "Preservation", "Preservation", "");

		#endregion

		#region public static DirectiveWorkType Depreservation = new DirectiveWorkType(34, "Depreservation", "Depreservation", "");

		public static DirectiveWorkType Depreservation = new DirectiveWorkType(34, "Depreservation", "Depreservation", "");


		#endregion

		#region public static DirectiveWorkType Adjust = new DirectiveWorkType(35, "Adjust", "Adjust", "");

		public static DirectiveWorkType Adjust = new DirectiveWorkType(35, "Adjust", "Adjust", "");

		#endregion

		#region public static DirectiveWorkType Examine = new DirectiveWorkType(36, "Examine", "Examine", "");

		public static DirectiveWorkType Examine = new DirectiveWorkType(36, "Examine", "Examine", "");

		#endregion

		#region public static DirectiveWorkType Measure = new DirectiveWorkType(37, "Measure", "Measure", "");

		public static DirectiveWorkType Measure = new DirectiveWorkType(37, "Measure", "Measure", "");

		#endregion

		#region public static DirectiveWorkType Monitor = new DirectiveWorkType(38, "Monitor", "Monitor", "");

		public static DirectiveWorkType Monitor = new DirectiveWorkType(38, "Monitor", "Monitor", "");

		#endregion

		#region public static DirectiveWorkType Record = new DirectiveWorkType(39, "Record", "Record", "");

		public static DirectiveWorkType Record = new DirectiveWorkType(39, "Record", "Record", "");

		#endregion

		#region public static DirectiveWorkType Set = new DirectiveWorkType(40, "Set", "Set", "");

		public static DirectiveWorkType Set = new DirectiveWorkType(40, "Set", "Set", "");

		#endregion

		#region public static DirectiveWorkType Task = new DirectiveWorkType(41, "Task", "Task", "");

		public static DirectiveWorkType Task = new DirectiveWorkType(41, "Task", "Task", "");

		#endregion


		#region public static DirectiveWorkType Replace = new DirectiveWorkType(100, "RL", "Replace", "");
		/// <summary>
		/// 
		/// </summary>
		public static DirectiveWorkType Replace = new DirectiveWorkType(100, "RL", "Replace", "");
		#endregion


		#region public static DirectiveWorkType Unknown = new DirectiveWorkType(-1, "Unknown", "Unknown", "Unknown");
		/// <summary> 
		/// Неизвестный объект
		/// </summary>
		public static DirectiveWorkType Unknown = new DirectiveWorkType(-1, "Unknown", "Unknown", "Unknown");
		#endregion

		/*
         * Методы
         */

		#region public static DirectiveWorkType GetItemById(Int32 DirectiveWorkTypeId)
		/// <summary>
		/// Возвращает тип диерктивы по его Id
		/// </summary>
		/// <param name="DirectiveWorkTypeId"></param>
		/// <returns></returns>
		public static DirectiveWorkType GetItemById(Int32 DirectiveWorkTypeId)
        {
            foreach (DirectiveWorkType t in _Items)
                if (t.ItemId == DirectiveWorkTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<DirectiveWorkType> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<DirectiveWorkType> Items
        {
            get { return _Items; }
        }
        #endregion

        #region public virtual override CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is DirectiveWorkType)
                return FullName.CompareTo(((DirectiveWorkType)y).FullName);
            return 0;
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
         * Реализация
         */
        #region public DirectiveWorkType()
        public DirectiveWorkType()
        {
            
        }
        #endregion

        #region public DirectiveWorkType(Int32 ItemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public DirectiveWorkType(Int32 itemId, String shortName, String fullName, String commonName)
        {
            ItemId = itemId;
            ShortName = shortName;
            FullName = fullName;
            CommonName = commonName;

            //if (_Items == null) _Items = new List<DetailType>();
            _Items.Add(this);
        }
        #endregion
    
    }
}
