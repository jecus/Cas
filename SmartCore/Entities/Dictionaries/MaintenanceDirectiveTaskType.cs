using System;
using SmartCore.Entities.Collections;

namespace SmartCore.Entities.Dictionaries
{
    [Serializable]
    public class MaintenanceDirectiveTaskType : StaticDictionary
    {

        #region private static CommonDictionaryCollection<MaintenanceDirectiveTaskType> _Items = new CommonDictionaryCollection<MaintenanceDirectiveTaskType>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<MaintenanceDirectiveTaskType> _Items = new CommonDictionaryCollection<MaintenanceDirectiveTaskType>();
        #endregion

        /*
         * Предопределенные типы
         */

        #region public static MaintenanceDirectiveTaskType Restore = new MaintenanceDirectiveTaskType(1, "RST", "Restore", "");
        /// <summary>
        /// 
        /// </summary>
        public static MaintenanceDirectiveTaskType Restore = new MaintenanceDirectiveTaskType(1, "RST", "Restore", "");
        #endregion

        #region public static MaintenanceDirectiveTaskType DetailedInspection = new MaintenanceDirectiveTaskType(2, "DET", "Detailed Inspection", "");
        /// <summary>
        /// 
        /// </summary>
        public static MaintenanceDirectiveTaskType DetailedInspection = new MaintenanceDirectiveTaskType(2, "DET", "Detailed Inspection", "");
        #endregion

        #region public static MaintenanceDirectiveTaskType GeneralVisualInspection = new MaintenanceDirectiveTaskType(3, "GVI", "General Visual Inspection", "");
        /// <summary>
        /// 
        /// </summary>
        public static MaintenanceDirectiveTaskType GeneralVisualInspection = new MaintenanceDirectiveTaskType(3, "GVI", "General Visual Inspection", "");
        #endregion

        #region public static MaintenanceDirectiveTaskType Discard = new MaintenanceDirectiveTaskType(4, "DIS", "Discard", "");
        /// <summary>
        /// 
        /// </summary>
        public static MaintenanceDirectiveTaskType Discard = new MaintenanceDirectiveTaskType(4, "DIS", "Discard", "");
        #endregion

        #region public static MaintenanceDirectiveTaskType OperationalCheck = new MaintenanceDirectiveTaskType(5, "OPC", "Operationally Check", "");
        /// <summary>
        /// 
        /// </summary>
        public static MaintenanceDirectiveTaskType OperationalCheck = new MaintenanceDirectiveTaskType(5, "OPC", "Operational Check", "");
        #endregion

        #region public static MaintenanceDirectiveTaskType FunctionallyCheck = new MaintenanceDirectiveTaskType(6, "FNC", "Functionally Check", "");
        /// <summary>
        /// 
        /// </summary>
        public static MaintenanceDirectiveTaskType FunctionallyCheck = new MaintenanceDirectiveTaskType(6, "FNC", "Functional Check", "");
		#endregion

		#region public static MaintenanceDirectiveTaskType Servicing = new MaintenanceDirectiveTaskType(7, "SVC", "Servicing", "");
		/// <summary>
		/// 
		/// </summary>
		public static MaintenanceDirectiveTaskType Servicing = new MaintenanceDirectiveTaskType(7, "SVC", "Servicing", "");
		#endregion

		#region public static MaintenanceDirectiveTaskType Lubrication = new MaintenanceDirectiveTaskType(8, "LUB", "Lubrication", "");
		/// <summary>
		/// 
		/// </summary>
		public static MaintenanceDirectiveTaskType Lubrication = new MaintenanceDirectiveTaskType(8, "LUB", "Lubrication", "");
		#endregion

		#region public static MaintenanceDirectiveTaskType VisualCheck = new MaintenanceDirectiveTaskType(9, "VCK", "Visual Check", "");
		/// <summary>
		/// 
		/// </summary>
		public static MaintenanceDirectiveTaskType VisualCheck = new MaintenanceDirectiveTaskType(9, "VCK", "Visual Check", "");
        #endregion

        #region public static MaintenanceDirectiveTaskType SpecialDetailedInspection = new MaintenanceDirectiveTaskType(10, "SDI", "Special Detailed Inspection", "");
        /// <summary>
        /// 
        /// </summary>
        public static MaintenanceDirectiveTaskType SpecialDetailedInspection = new MaintenanceDirectiveTaskType(10, "SDI", "Special Detailed Inspection", "");
        #endregion

        #region public static MaintenanceDirectiveTaskType Check = new MaintenanceDirectiveTaskType(11, "Check", "Check", "");
        /// <summary>
        /// 
        /// </summary>
        public static MaintenanceDirectiveTaskType Check = new MaintenanceDirectiveTaskType(11, "Check", "Check", "");
        #endregion

        #region public static MaintenanceDirectiveTaskType Inspection = new MaintenanceDirectiveTaskType(12, "INSP", "Inspection", "");
        /// <summary>
        /// 
        /// </summary>
        public static MaintenanceDirectiveTaskType Inspection = new MaintenanceDirectiveTaskType(12, "INSP", "Inspection", "");
        #endregion

        #region public static MaintenanceDirectiveTaskType CDCCL = new MaintenanceDirectiveTaskType(13, "CDCCL", "CDCCL", "");
        /// <summary>
        /// 
        /// </summary>
        public static MaintenanceDirectiveTaskType CDCCL = new MaintenanceDirectiveTaskType(13, "CDCCL", "CDCCL", "");
		#endregion

		#region public static MaintenanceDirectiveTaskType AWL = new MaintenanceDirectiveTaskType(14, "AWL", "AWL", "");
		/// <summary>
		/// 
		/// </summary>
		public static MaintenanceDirectiveTaskType AWL = new MaintenanceDirectiveTaskType(14, "ALI", "ALI", "");
		#endregion

		#region public static MaintenanceDirectiveTaskType Clean = new MaintenanceDirectiveTaskType(15, "Clean", "Clean", "");
		/// <summary>
		/// 
		/// </summary>
		public static MaintenanceDirectiveTaskType Clean = new MaintenanceDirectiveTaskType(15, "Clean", "Clean", "");

		#endregion

		#region public static MaintenanceDirectiveTaskType CorrosionPrevention = new MaintenanceDirectiveTaskType(16, "CP", "Corrosion Prevention", "");

		public static MaintenanceDirectiveTaskType CorrosionPrevention = new MaintenanceDirectiveTaskType(16, "CP", "Corrosion Prevention", "");

		#endregion

		#region public static MaintenanceDirectiveTaskType Remove = new MaintenanceDirectiveTaskType(17, "Remove", "Remove", "");

		public static MaintenanceDirectiveTaskType Remove = new MaintenanceDirectiveTaskType(17, "Remove", "Remove", "");

		#endregion

		#region public static MaintenanceDirectiveTaskType BenchCheck = new MaintenanceDirectiveTaskType(18, "BC", "Bench Check", "");

		public static MaintenanceDirectiveTaskType BenchCheck = new MaintenanceDirectiveTaskType(18, "BC", "Bench Check","");

		#endregion

		#region public static MaintenanceDirectiveTaskType InternalStructuralInspection = new MaintenanceDirectiveTaskType(19, "Internal SI", "Internal Structural Inspection", "");

		public static MaintenanceDirectiveTaskType InternalStructuralInspection = new MaintenanceDirectiveTaskType(19, "Internal SI", "Internal Structural Inspection", "");

		#endregion

		#region public static MaintenanceDirectiveTaskType ExternalStructuralInspection = new MaintenanceDirectiveTaskType(20, "External SI", "External Structural Inspection", "");

		public static MaintenanceDirectiveTaskType ExternalStructuralInspection = new MaintenanceDirectiveTaskType(20, "External SI", "External Structural Inspection", "");

		#endregion

		#region public static MaintenanceDirectiveTaskType Drain = new MaintenanceDirectiveTaskType(21, "Drain", "Drain", "");

		public static MaintenanceDirectiveTaskType Drain = new MaintenanceDirectiveTaskType(21, "Drain", "Drain", "");

		#endregion

		#region public static MaintenanceDirectiveTaskType CorrosionControl = new MaintenanceDirectiveTaskType(22, "Corrosion control", "Corrosion control", "");

		public static MaintenanceDirectiveTaskType CorrosionControl = new MaintenanceDirectiveTaskType(22, "Corrosion control", "Corrosion control", "");

		#endregion

		#region public static MaintenanceDirectiveTaskType LeakTest = new MaintenanceDirectiveTaskType(23, "Leak test", "Leak test", "");

		public static MaintenanceDirectiveTaskType LeakTest = new MaintenanceDirectiveTaskType(23, "Leak test", "Leak test","");

		#endregion

		#region public static MaintenanceDirectiveTaskType Borescope = new MaintenanceDirectiveTaskType(24, "Borescope", "Borescope", "");

		public static MaintenanceDirectiveTaskType Borescope = new MaintenanceDirectiveTaskType(24, "Borescope", "Borescope", "");

		#endregion

		#region public static MaintenanceDirectiveTaskType CMR = new MaintenanceDirectiveTaskType(25, "CMR", "CMR", "");

		public static MaintenanceDirectiveTaskType CMR = new MaintenanceDirectiveTaskType(25, "CMR", "CMR", "");

		#endregion

		#region public static MaintenanceDirectiveTaskType NDT = new MaintenanceDirectiveTaskType(26, "NDT", "NDT", "");

		public static MaintenanceDirectiveTaskType NDT = new MaintenanceDirectiveTaskType(26, "NDT", "NDT", "");

		#endregion

		#region public static MaintenanceDirectiveTaskType WeighCheck = new MaintenanceDirectiveTaskType(27, "Weigh Check", "Weigh Check", "");

		public static MaintenanceDirectiveTaskType WeighCheck = new MaintenanceDirectiveTaskType(27, "Weigh Check", "Weigh Check", "");


		#endregion

		#region public static MaintenanceDirectiveTaskType Overhaul = new MaintenanceDirectiveTaskType(28, "Overhaul", "Overhaul", "");

		public static MaintenanceDirectiveTaskType Overhaul = new MaintenanceDirectiveTaskType(28, "Overhaul", "Overhaul", "");


		#endregion

		#region public static MaintenanceDirectiveTaskType Repair = new MaintenanceDirectiveTaskType(29, "Repair", "Repair", "");

		public static MaintenanceDirectiveTaskType Repair = new MaintenanceDirectiveTaskType(29, "Repair", "Repair", "");


		#endregion

		#region public static MaintenanceDirectiveTaskType DocumentRevision = new MaintenanceDirectiveTaskType(30, "Document Revision", "Document Revision", "");

		public static MaintenanceDirectiveTaskType DocumentRevision = new MaintenanceDirectiveTaskType(30, "Document Revision", "Document Revision", "");


		#endregion

		#region public static MaintenanceDirectiveTaskType Test = new MaintenanceDirectiveTaskType(31, "Test", "Test", "");

		public static MaintenanceDirectiveTaskType Test = new MaintenanceDirectiveTaskType(31, "Test", "Test", "");

		#endregion

		#region public static MaintenanceDirectiveTaskType Revision = new MaintenanceDirectiveTaskType(32, "Revision", "Revision", "");

		public static MaintenanceDirectiveTaskType Revision = new MaintenanceDirectiveTaskType(32, "Revision", "Revision", "");


		#endregion

		#region public static MaintenanceDirectiveTaskType Scrab = new MaintenanceDirectiveTaskType(32, "Scrab", "Scrab", "");

		public static MaintenanceDirectiveTaskType Scrab = new MaintenanceDirectiveTaskType(32, "Scrab", "Scrab", "");

		#endregion

		#region public static MaintenanceDirectiveTaskType HydrostaticTest = new MaintenanceDirectiveTaskType(33, "Hydrostatic Test", "Hydrostatic Test", "");

		public static MaintenanceDirectiveTaskType HydrostaticTest = new MaintenanceDirectiveTaskType(33, "Hydrostatic Test", "Hydrostatic Test", "");


		#endregion

		#region public static MaintenanceDirectiveTaskType Preservation = new MaintenanceDirectiveTaskType(34, "Preservation", "Preservation", "");

		public static MaintenanceDirectiveTaskType Preservation = new MaintenanceDirectiveTaskType(34, "Preservation", "Preservation", "");


		#endregion

		#region public static MaintenanceDirectiveTaskType Depreservation = new MaintenanceDirectiveTaskType(35, "Depreservation", "Depreservation", "");

		public static MaintenanceDirectiveTaskType Depreservation = new MaintenanceDirectiveTaskType(35, "Depreservation", "Depreservation", "");


		#endregion

		#region public static MaintenanceDirectiveTaskType Store = new MaintenanceDirectiveTaskType(36, "Store", "Store", "");

		public static MaintenanceDirectiveTaskType Store = new MaintenanceDirectiveTaskType(36, "Store", "Store", "");

		#endregion

		#region public static MaintenanceDirectiveTaskType Modification = new MaintenanceDirectiveTaskType(37, "Modification", "Modification", "");

		public static MaintenanceDirectiveTaskType Modification = new MaintenanceDirectiveTaskType(37, "Modification", "Modification", "");


		#endregion

		#region public static MaintenanceDirectiveTaskType Parking = new MaintenanceDirectiveTaskType(38, "Parking", "Parking", "");

		public static MaintenanceDirectiveTaskType Parking = new MaintenanceDirectiveTaskType(38, "Parking", "Parking", "");


		#endregion

		#region public static MaintenanceDirectiveTaskType Mooring = new MaintenanceDirectiveTaskType(39, "Mooring", "Mooring", "");

		public static MaintenanceDirectiveTaskType Mooring = new MaintenanceDirectiveTaskType(39, "Mooring", "Mooring", "");


		#endregion

		#region public static MaintenanceDirectiveTaskType Storage = new MaintenanceDirectiveTaskType(40, "Storage", "Storage", "");

		public static MaintenanceDirectiveTaskType Storage = new MaintenanceDirectiveTaskType(40, "Storage", "Storage", "");


		#endregion

		#region public static MaintenanceDirectiveTaskType ReturntoService = new MaintenanceDirectiveTaskType(41, "Return to Service", "Return to Service", "");

		public static MaintenanceDirectiveTaskType ReturntoService = new MaintenanceDirectiveTaskType(41, "Return to Service", "Return to Service", "");


		#endregion

		#region public static MaintenanceDirectiveTaskType Lifting = new MaintenanceDirectiveTaskType(42, "Lifting", "Lifting", "");

		public static MaintenanceDirectiveTaskType Lifting = new MaintenanceDirectiveTaskType(42, "Lifting", "Lifting", "");


		#endregion

		#region public static MaintenanceDirectiveTaskType Lowering = new MaintenanceDirectiveTaskType(43, "Lowering", "Lowering", "");

		public static MaintenanceDirectiveTaskType Lowering = new MaintenanceDirectiveTaskType(43, "Lowering", "Lowering", "");


		#endregion

		#region public static MaintenanceDirectiveTaskType Holsting = new MaintenanceDirectiveTaskType(44, "Holsting", "Holsting", "");

		public static MaintenanceDirectiveTaskType Holsting = new MaintenanceDirectiveTaskType(44, "Holsting", "Holsting", "");


	    #endregion

		#region public static MaintenanceDirectiveTaskType Adjust = new MaintenanceDirectiveTaskType(45, "Adjust", "Adjust", "");

		public static MaintenanceDirectiveTaskType Adjust = new MaintenanceDirectiveTaskType(45, "Adjust", "Adjust", "");

		#endregion

		#region public static MaintenanceDirectiveTaskType Examine = new MaintenanceDirectiveTaskType(46, "Examine", "Examine", "");

		public static MaintenanceDirectiveTaskType Examine = new MaintenanceDirectiveTaskType(46, "Examine", "Examine", "");

		#endregion

		#region public static MaintenanceDirectiveTaskType Measure = new MaintenanceDirectiveTaskType(47, "Measure", "Measure", "");

		public static MaintenanceDirectiveTaskType Measure = new MaintenanceDirectiveTaskType(47, "Measure", "Measure", "");

		#endregion

		#region public static MaintenanceDirectiveTaskType Monitor = new MaintenanceDirectiveTaskType(48, "Monitor", "Monitor", "");

		public static MaintenanceDirectiveTaskType Monitor = new MaintenanceDirectiveTaskType(48, "Monitor", "Monitor", "");

		#endregion

		#region public static MaintenanceDirectiveTaskType Record = new MaintenanceDirectiveTaskType(49, "Record", "Record", "");

		public static MaintenanceDirectiveTaskType Record = new MaintenanceDirectiveTaskType(49, "Record", "Record", "");

		#endregion

		#region public static MaintenanceDirectiveTaskType Set = new MaintenanceDirectiveTaskType(50, "Set", "Set", "");

		public static MaintenanceDirectiveTaskType Set = new MaintenanceDirectiveTaskType(50, "Set", "Set", "");

		#endregion

		#region public static MaintenanceDirectiveTaskType Task = new MaintenanceDirectiveTaskType(51, "Task", "Task", "");

		public static MaintenanceDirectiveTaskType Task = new MaintenanceDirectiveTaskType(51, "Task", "Task", "");

		#endregion

		#region public static MaintenanceDirectiveTaskType Calibration = new MaintenanceDirectiveTaskType(52, "Calibration", "Calibration", "");

		public static MaintenanceDirectiveTaskType Calibration = new MaintenanceDirectiveTaskType(52, "Calibration", "Calibration", "");


		#endregion

		#region public static MaintenanceDirectiveTaskType Verification = new MaintenanceDirectiveTaskType(53, "Verification", "Verification", "");

		public static MaintenanceDirectiveTaskType Verification = new MaintenanceDirectiveTaskType(53, "Verification", "Verification", "");


		#endregion

		#region public static MaintenanceDirectiveTaskType Restoration = new MaintenanceDirectiveTaskType(54, "Restoration ", "Restoration ", "");

		public static MaintenanceDirectiveTaskType Restoration = new MaintenanceDirectiveTaskType(54, "Restoration ", "Restoration ", "");

		#endregion

		#region public static MaintenanceDirectiveTaskType LubricationServicing = new MaintenanceDirectiveTaskType(55, "Lubrication and Servicing ", "Lubrication and Servicing ", "");

		public static MaintenanceDirectiveTaskType LubricationServicing = new MaintenanceDirectiveTaskType(55, "Lubrication and Servicing ", "Lubrication and Servicing ", "");

        #endregion

        #region public static MaintenanceDirectiveTaskType InspectionTest = new MaintenanceDirectiveTaskType(56, "Inspection Test", "Inspection Test", "");

        public static MaintenanceDirectiveTaskType InspectionTest = new MaintenanceDirectiveTaskType(56, "Inspection Test", "Inspection Test", "");

        #endregion

        #region public static MaintenanceDirectiveTaskType MaintenancePractices = new MaintenanceDirectiveTaskType(57, "Maintenance Practices", "Maintenance Practices", "");

        public static MaintenanceDirectiveTaskType MaintenancePractices = new MaintenanceDirectiveTaskType(57, "Maintenance Practices", "Maintenance Practices", "");

        #endregion

        #region public static MaintenanceDirectiveTaskType Unscheduled = new MaintenanceDirectiveTaskType(58, "Unscheduled", "Unscheduled", "");

        public static MaintenanceDirectiveTaskType Unscheduled = new MaintenanceDirectiveTaskType(58, "Unscheduled", "Unscheduled", "");

        #endregion

        #region public static MaintenanceDirectiveTaskType Replace = new MaintenanceDirectiveTaskType(100, "RL", "Replace", "");
        /// <summary>
        /// 
        /// </summary>
        public static MaintenanceDirectiveTaskType Replace = new MaintenanceDirectiveTaskType(100, "RL", "Replace", "");
        #endregion

        #region public static MaintenanceDirectiveTaskType Unknown = new MaintenanceDirectiveTaskType(-1, "Unknown", "Unknown", "Unknown");
        /// <summary> 
        /// Неизвестный объект
        /// </summary>
        public static MaintenanceDirectiveTaskType Unknown = new MaintenanceDirectiveTaskType(-1, "Unknown", "Unknown", "Unknown");
        #endregion

        /*
         * Методы
         */

        #region public static MaintenanceDirectiveTaskType GetItemById(Int32 directiveTypeId)
        /// <summary>
        /// Возвращает тип диерктивы по его Id
        /// </summary>
        /// <param name="directiveTypeId"></param>
        /// <returns></returns>
        public static MaintenanceDirectiveTaskType GetItemById(Int32 directiveTypeId)
        {
            foreach (MaintenanceDirectiveTaskType t in _Items)
                if (t.ItemId == directiveTypeId)
                    return t;
            //
            return Unknown;
        }

        #endregion

        #region static public CommonDictionaryCollection<MaintenanceDirectiveTaskType> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<MaintenanceDirectiveTaskType> Items
        {
            get { return _Items; }
        }
        #endregion

        #region public virtual override CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is MaintenanceDirectiveTaskType)
                return FullName.CompareTo(((MaintenanceDirectiveTaskType)y).FullName);
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
        #region public MaintenanceDirectiveTaskType()
        public MaintenanceDirectiveTaskType()
        {
            
        }
        #endregion

        #region public MaintenanceDirectiveTaskType(Int32 itemId, String shortName, String fullName, String commonName)
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="commonName"></param>
        public MaintenanceDirectiveTaskType(Int32 itemId, String shortName, String fullName, String commonName)
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
