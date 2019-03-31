using System;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Deprecated;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Hangar;
using SmartCore.Entities.General.Mail;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.MTOP;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.Quality;
using SmartCore.Entities.General.Schedule;
using SmartCore.Entities.General.SMS;
using SmartCore.Entities.General.Store;
using SmartCore.Entities.General.WorkPackage;
using SmartCore.Entities.General.WorkShop;
using SmartCore.Purchase;

namespace SmartCore.Entities.Dictionaries
{
    /// <summary>
    /// Описывает Тип объета системы
    /// </summary>
    [Serializable]
    public class SmartCoreType : StaticDictionary
    {

        #region public Type ObjectType
       
        private Type _objectType;
        /// <summary>
        /// Возвращает связанный тип
        /// </summary>
        public Type ObjectType
        {
            get { return _objectType; }
        }
        #endregion

        #region private static CommonDictionaryCollection<SmartCoreType> _Items = new CommonDictionaryCollection<SmartCoreType>();
        /// <summary>
        /// Содержит все элементы
        /// </summary>
        private static CommonDictionaryCollection<SmartCoreType> _Items = new CommonDictionaryCollection<SmartCoreType>();
        #endregion

        /*
         * Предопределенные типы
         */
        #region public static SmartCoreType Unknown = new SmartCoreType(-1, "Unk", "Unknown", null);
        /// <summary>
        /// 
        /// </summary>
        public static SmartCoreType Unknown = new SmartCoreType(-1, "Unk", "Unknown", null);
        #endregion

        #region public static SmartCoreType Directive = new SmartCoreType(1, "DR", "Directive", new Directive();
        /// <summary>
        /// 
        /// </summary>
        public static SmartCoreType Directive = new SmartCoreType(1, "DR", "AD", typeof(Directive));
		#endregion

		#region public static SmartCoreType ComponentDirective = new SmartCoreType(2, "DDR", "DetailDirective", "");
		/// <summary>
		/// 
		/// </summary>
		public static SmartCoreType ComponentDirective = new SmartCoreType(2, "DDR", "Component Task", typeof(ComponentDirective));
        #endregion

        #region public static SmartCoreType MaintenanceCheck = new SmartCoreType(3, "MC", "Maintenance Check", "");
        /// <summary>
        /// 
        /// </summary>
        public static SmartCoreType MaintenanceCheck = new SmartCoreType(3, "MC", "Maintenance Check", typeof(MaintenanceCheck));
        #endregion

        #region public static SmartCoreType NonRoutineJob = new SmartCoreType(4, "NRJ", "Non-Routine Job", typeof(NonRoutineJob));
        /// <summary>
        /// 
        /// </summary>
        public static SmartCoreType NonRoutineJob = new SmartCoreType(4, "NRJ", "Non-Routine Job", typeof(NonRoutineJob));
		#endregion

		#region public static SmartCoreType Component = new SmartCoreType(5, "D", "Component", "");
		/// <summary>
		/// 
		/// </summary>
		public static SmartCoreType Component = new SmartCoreType(5, "D", "Component", typeof(General.Accessory.Component));
		#endregion

		#region public static SmartCoreType BaseComponent = new SmartCoreType(6, "BD", "Base Component", "");
		/// <summary>
		/// 
		/// </summary>
		public static SmartCoreType BaseComponent = new SmartCoreType(6, "BD", "Base Component", typeof(BaseComponent));
        #endregion

        #region public static SmartCoreType Aircraft = new SmartCoreType(7, "AC", "Aircraft");
        /// <summary>
        /// 
        /// </summary>
        public static SmartCoreType Aircraft = new SmartCoreType(7, "AC", "Aircraft", typeof(Aircraft));
        #endregion

        #region public static SmartCoreType Operator = new SmartCoreType(8, "OP", "Operator");
        /// <summary>
        /// 
        /// </summary>
        public static SmartCoreType Operator = new SmartCoreType(8, "OP", "Operator", typeof(Operator));
        #endregion

        #region public static SmartCoreType Store = new SmartCoreType(9, "St", "Store");
        /// <summary>
        /// 
        /// </summary>
        public static SmartCoreType Store = new SmartCoreType(9, "St", "Store", typeof(Store));
        #endregion

        #region public static SmartCoreType AccessoryRequired = new SmartCoreType(10, "AR", "AccessoryRequired");
        /// <summary>
        /// 
        /// </summary>
        public static SmartCoreType AccessoryRequired = new SmartCoreType(10, "AR", "AccessoryRequired", typeof(AccessoryRequired));
        #endregion

        #region public static SmartCoreType SmsEventType = new SmartCoreType(11, "SmsET", "SmsEventType");
        /// <summary>
        /// 
        /// </summary>
        public static SmartCoreType SmsEventType = new SmartCoreType(11, "SmsET", "SmsEventType", typeof(SmsEventType));
        #endregion

        #region public static SmartCoreType SmsEvent = new SmartCoreType(12, "SmsE", "SmsEvent");
        /// <summary>
        /// 
        /// </summary>
        public static SmartCoreType SmsEvent = new SmartCoreType(12, "SmsE", "SmsEvent", typeof(Event));
        #endregion

        #region public static SmartCoreType AircraftFlight = new SmartCoreType(13, "AF", "Aircraft flight", typeof(AircraftFlight));
        /// <summary>
        /// 
        /// </summary>
        public static SmartCoreType AircraftFlight = new SmartCoreType(13, "AF", "Aircraft flight", typeof(AircraftFlight));
        #endregion

        #region public static SmartCoreType MaintenanceDirective = new SmartCoreType(14, "MPD", "AMP", typeof(MaintenanceDirective));
        /// <summary>
        /// 
        /// </summary>
        public static SmartCoreType MaintenanceDirective = new SmartCoreType(14, "MPD", "AMP", typeof(MaintenanceDirective));
        #endregion

        #region public static SmartCoreType Product = new SmartCoreType(1005, "Prod", "Product", typeof(Product));
        /// <summary>
        /// 
        /// </summary>
        public static SmartCoreType Product = new SmartCoreType(1005, "Prod", "Product", typeof(Product));
		#endregion

		#region public static SmartCoreType AircraftModel = new SmartCoreType(1010, "AiM", "Aircraft Model", typeof(AircraftModel));
		///// <summary>
		///// 
		///// </summary>
		//public static SmartCoreType AircraftModel = new SmartCoreType(1010, "AiM", "Aircraft Model", typeof(AircraftModel));
		#endregion

		#region public static SmartCoreType ApuFailureData = new SmartCoreType(1020, "ApuFailureData", "ApuFailureData", typeof(ApuFailureData));

		public static SmartCoreType ApuFailureData = new SmartCoreType(1035, "ApuFailureData", "ApuFailureData", typeof (ApuFailureData));

	    #endregion

		#region public static SmartCoreType Atlb = new SmartCoreType(1040, "ATLB", "ATLB", typeof (ATLB));

		public static SmartCoreType Atlb = new SmartCoreType(1040, "ATLB", "ATLB", typeof (ATLB));

		#endregion

		#region public static SmartCoreType Audit = new SmartCoreType(1080, "Audit", "Audit", typeof(Audit));

		public static SmartCoreType Audit = new SmartCoreType(1080, "Audit", "Audit", typeof (Audit));

		#endregion

		#region public static SmartCoreType DamageChart = new SmartCoreType(1180, "DamageChart", "DamageChart", typeof(DamageChart));

		public static SmartCoreType DamageChart = new SmartCoreType(1180, "DamageChart", "DamageChart", typeof (DamageChart));

		#endregion

		#region public static SmartCoreType DamageDocument = new SmartCoreType(1185, "DamageDocument", "DamageDocument", typeof(DamageDocument));

		public static SmartCoreType DamageDocument = new SmartCoreType(1185, "DamageDocument", "DamageDocument", typeof (DamageDocument));

		#endregion

		#region public static SmartCoreType FlightNumber = new SmartCoreType(1188, "FlightNumber", "FlightNumber", typeof(FlightNumber));

		public static SmartCoreType FlightNumber = new SmartCoreType(1188, "FlightNumber", "FlightNumber", typeof(FlightNumber));

		#endregion

		#region public static SmartCoreType FlightNumberPeriod = new SmartCoreType(1189, "FlightNumberPeriod", "FlightNumberPeriod", typeof(FlightNumberPeriod));

		public static SmartCoreType FlightNumberPeriod = new SmartCoreType(1189, "FlightNumberPeriod", "FlightNumberPeriod", typeof(FlightNumberPeriod));

	    #endregion

		#region public static SmartCoreType DetailLLPCategoryChangeRecord = new SmartCoreType(1200, "LLP", "DetailLLPCategoryChangeRecord", typeof(DetailLLPCategoryChangeRecord));

		public static SmartCoreType ComponentLLPCategoryChangeRecord = new SmartCoreType(1200, "LLP", "DetailLLPCategoryChangeRecord", typeof (ComponentLLPCategoryChangeRecord));

	    #endregion

		#region public static SmartCoreType DetectionPhase = new SmartCoreType(1250, "DF", "DetectionPhase", typeof(DetectionPhase));
		/// <summary>
		/// 
		/// </summary>
		public static SmartCoreType DetectionPhase = new SmartCoreType(1250, "DF", "DetectionPhase", typeof(DetectionPhase));
		#endregion

		#region public static SmartCoreType DirectiveRecord = new SmartCoreType(1260, "DR", "DirectiveRecord", typeof(DirectiveRecord));

		public static SmartCoreType DirectiveRecord = new SmartCoreType(1260, "DR", "DirectiveRecord", typeof(DirectiveRecord));

		#endregion

		#region public static SmartCoreType Document = new SmartCoreType(1275, "Doc", "Document", typeof(Document));

		public static SmartCoreType Document = new SmartCoreType(1275, "Doc", "Document", typeof (Document));

		#endregion

		#region public static SmartCoreType Employee = new SmartCoreType(1310, "Employee", "Employee", typeof(Specialist));
		/// <summary>
		/// 
		/// </summary>
		public static SmartCoreType Employee = new SmartCoreType(1310, "Employee", "Employee", typeof(Specialist));
		#endregion

		#region public static SmartCoreType SpecialistLicense = new SmartCoreType(1311, "SpecialistLicense", "SpecialistLicense", typeof(SpecialistLicense));
		/// <summary>
		/// 
		/// </summary>
		public static SmartCoreType SpecialistLicense = new SmartCoreType(1311, "SpecialistLicense", "SpecialistLicense", typeof(SpecialistLicense));
		#endregion

		public static SmartCoreType SpecialistCAA = new SmartCoreType(1312, "SpecialistCAA", "SpecialistCAA", typeof(SpecialistCAA));
		public static SmartCoreType SpecialistLicenseDetail = new SmartCoreType(1313, "SpecialistLicenseDetail", "SpecialistLicenseDetail", typeof(SpecialistLicenseDetail));
		public static SmartCoreType SpecialistLicenseRating = new SmartCoreType(1314, "SpecialistLicenseRating", "SpecialistLicenseRating", typeof(SpecialistLicenseRating));
		public static SmartCoreType SpecialistInstrumentRating = new SmartCoreType(1315, "SpecialistInstrumentRating", "SpecialistInstrumentRating", typeof(SpecialistInstrumentRating));
		public static SmartCoreType SpecialistLicenseRemark = new SmartCoreType(1316, "SpecialistLicenseRemark", "SpecialistLicenseRemark", typeof(SpecialistLicenseRemark));
		public static SmartCoreType SpecialistTraining = new SmartCoreType(1317, "SpecialistTraining", "SpecialistTraining", typeof(SpecialistTraining));
		public static SmartCoreType SpecialistMedicalRecord = new SmartCoreType(1318, "SpecialistMedicalRecord", "SpecialistMedicalRecord", typeof(SpecialistMedicalRecord));

		#region public static SmartCoreType FlightRegime = new SmartCoreType(1360, "FR", "FlightRegime", typeof(FlightRegime));
		/// <summary>
		/// 
		/// </summary>
		public static SmartCoreType FlightRegime = new SmartCoreType(1360, "FR", "FlightRegime", typeof(FlightRegime));
        #endregion

        #region public static SmartCoreType GoodStandart = new SmartCoreType(1440, "GdStndt", "GoodStandart", typeof(GoodStandart));
        /// <summary>
        /// 
        /// </summary>
        public static SmartCoreType GoodStandart = new SmartCoreType(1440, "GdStndt", "GoodStandart", typeof(GoodStandart));
        #endregion

        #region public static SmartCoreType JobCard = new SmartCoreType(1450, "JC", "JobCard", typeof(JobCard));
        /// <summary>
        /// 
        /// </summary>
        public static SmartCoreType JobCard = new SmartCoreType(1450, "JC", "JobCard", typeof(JobCard));
        #endregion

        #region public static SmartCoreType Hangar = new SmartCoreType(1500, "Hangar", "Hangar", typeof(Hangar));
        /// <summary>
        /// 
        /// </summary>
        public static SmartCoreType Hangar = new SmartCoreType(1500, "Hangar", "Hangar", typeof(Hangar));
		#endregion

		#region public static SmartCoreType InitialOrder = new SmartCoreType(1590, "InitialOrder", "InitialOrder", typeof(InitialOrder));

		public static SmartCoreType InitialOrder = new SmartCoreType(1560, "InitialOrder", "InitialOrder", typeof (InitialOrder));

	    #endregion

		#region public static SmartCoreType LLPLifeLimitCategoryType = new SmartCoreType(1660, "LLC", "LifeLimitCategoryType", typeof(LLPLifeLimitCategoryType));
		/// <summary>
		/// 
		/// </summary>
		public static SmartCoreType LLPLifeLimitCategoryType = new SmartCoreType(1660, "LLC", "LifeLimitCategoryType", typeof(LLPLifeLimitCategoryType));
		#endregion

		public static SmartCoreType MailRecord = new SmartCoreType(1670, "MailRecords", "MailRecords", typeof(MailRecords));
		public static SmartCoreType MailChats = new SmartCoreType(1671, "MailChats", "MailChats", typeof(MailChats));

	    public static SmartCoreType MTOPCheck = new SmartCoreType(1675, "MTOPCheck", "MTOPCheck", typeof(MTOPCheck));
	    public static SmartCoreType MTOPCheckRecord = new SmartCoreType(1676, "MTOPCheckRecord", "MTOPCheckRecord", typeof(MTOPCheckRecord));

		#region public static SmartCoreType MaintenanceCheckRecord = new SmartCoreType(1680, "MCR", "MaintenanceCheckRecord", typeof(MaintenanceCheckRecord));

		public static SmartCoreType MaintenanceCheckRecord = new SmartCoreType(1680, "MCR", "MaintenanceCheckRecord", typeof (MaintenanceCheckRecord));

	    #endregion

		#region public static SmartCoreType Procedure = new SmartCoreType(1840, "P", "Procedure", typeof(Procedure));
		/// <summary>
		/// 
		/// </summary>
		public static SmartCoreType Procedure = new SmartCoreType(1840, "P", "Procedure", typeof(Procedure));
		#endregion

	    public static SmartCoreType FlightPlanOps = new SmartCoreType(1845, "FlightPlanOps", "FlightPlanOps", typeof(FlightPlanOps));
	    public static SmartCoreType FlightPlanOpsRecords = new SmartCoreType(1846, "FlightPlanOpsRecords", "FlightPlanOpsRecords", typeof(FlightPlanOpsRecords));

		#region public static SmartCoreType PurchaseOrder = new SmartCoreType(1855, "P", "PurchaseOrder", typeof(PurchaseOrder));

		public static SmartCoreType PurchaseOrder = new SmartCoreType(1855, "PO", "PurchaseOrder", typeof(PurchaseOrder));

		#endregion

		#region public static SmartCoreType PurchaseRequestRecord = new SmartCoreType(1860, "P", "PurchaseRequestRecord", typeof(PurchaseRequestRecord));

		public static SmartCoreType PurchaseRequestRecord = new SmartCoreType(1860, "POR", "PurchaseRequestRecord", typeof (PurchaseRequestRecord));

		#endregion

		#region public static SmartCoreType RequestForQuotation = new SmartCoreType(1900, "R", "RequestForQuotation", typeof(RequestForQuotation));

		public static SmartCoreType RequestForQuotation = new SmartCoreType(1900, "RFQ", "RequestForQuotation", typeof (RequestForQuotation));

	    #endregion

		#region public static SmartCoreType SmsEventArea = new SmartCoreType(2000, "SmsEA", "SmsEventArea", typeof(SmsEventArea));
		/// <summary>
		/// 
		/// </summary>
		public static SmartCoreType SmsEventArea = new SmartCoreType(2000, "SmsEA", "SmsEventArea", typeof(SmsEventArea));
        #endregion

        #region public static SmartCoreType Supplier = new SmartCoreType(2048, "Sup", "Supplier", typeof(Supplier));
        /// <summary>
        /// 
        /// </summary>
        public static SmartCoreType Supplier = new SmartCoreType(2048, "Sup", "Supplier", typeof(Supplier));
		#endregion

		#region public static SmartCoreType SupplierDocument = new SmartCoreType(2050, "SupDoc", "SupplierDocument", typeof(SupplierDocument));

		public static SmartCoreType SupplierDocument = new SmartCoreType(2050, "SupDoc", "SupplierDocument", typeof (SupplierDocument));

	    #endregion

		#region public static SmartCoreType TransferRecord = new SmartCoreType(2060, "TR", "TransferRecord", typeof(TransferRecord));

		public static SmartCoreType TransferRecord = new SmartCoreType(2260, "TR", "TransferRecord", typeof (TransferRecord));

	    #endregion

		#region public static SmartCoreType Vehicle = new SmartCoreType(2455, "V", "Vehilce", typeof(Vehicle));
		/// <summary>
		/// 
		/// </summary>
		public static SmartCoreType Vehicle = new SmartCoreType(2455, "V", "Vehilce", typeof(Vehicle));
		#endregion

		#region public static SmartCoreType WorkPackage = new SmartCoreType(2499, "WP", "WorkPackage", typeof(WorkPackage));

		public static SmartCoreType WorkPackage = new SmartCoreType(2499, "WP", "WorkPackage", typeof (WorkPackage));

	    #endregion

		#region public static SmartCoreType WorkShop = new SmartCoreType(2500, "WorkShop", "WorkShop", typeof(WorkShop));
		/// <summary>
		/// 
		/// </summary>
		public static SmartCoreType WorkShop = new SmartCoreType(2500, "WorkShop", "WorkShop", typeof(WorkShop));
        #endregion

        #region public static SmartCoreType WorkStation = new SmartCoreType(2501, "WorkStation", "WorkStation", typeof(WorkStation));
        /// <summary>
        /// 
        /// </summary>
        public static SmartCoreType WorkStation = new SmartCoreType(2501, "WorkStation", "WorkStation", typeof(WorkStation));
		#endregion

		public static SmartCoreType User = new SmartCoreType(3000, "User", "User", typeof(User));
		public static SmartCoreType AttachedFile = new SmartCoreType(3001, "AttachedFile", "AttachedFile", typeof(AttachedFile));
		/*
         * Методы
         */

		#region public static SmartCoreType GetSmartCoreTypeById(Int32 smartCoreTypeId)
		/// <summary>
		/// Возвращает тип базового объекта по его Id
		/// </summary>
		/// <param name="smartCoreTypeId"></param>
		/// <returns></returns>
		public static SmartCoreType GetSmartCoreTypeById(Int32 smartCoreTypeId)
        {
            for (int i = 0; i < _Items.Count; i++)
                if (_Items[i].ItemId == smartCoreTypeId)
                    return _Items[i];
            //
            return Unknown;
        }
        #endregion

        #region static public CommonDictionaryCollection<SmartCoreType> Items
        /// <summary>
        /// Возвращает список  элементов коллекции
        /// </summary>
        public static CommonDictionaryCollection<SmartCoreType> Items
        {
            get { return _Items; }
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
        #region public SmartCoreType()
        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        public SmartCoreType()
        {
        }
        #endregion

        #region public SmartCoreType(Int32 ItemId, String shortName, String fullName)

        /// <summary>
        /// Конструктор создает объект типа директивы
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="shortName"></param>
        /// <param name="fullName"></param>
        /// <param name="objectType"></param>
        public SmartCoreType(Int32 itemId, String shortName, String fullName, Type objectType)
        {
            ItemId = itemId;
            ShortName = shortName;
            FullName = fullName;
            _objectType = objectType;
            //if (_Items == null) _Items = new List<DetailType>();
            _Items.Add(this);
        }
        #endregion
    
    }
}
