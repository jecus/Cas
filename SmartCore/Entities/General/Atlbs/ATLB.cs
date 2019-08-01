using System;
using System.Reflection;
using EntityCore.DTO.General;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Files;

namespace SmartCore.Entities.General.Atlbs
{

    /// <summary>
    /// Класс описывает борт-журнал
    /// </summary>
    [Serializable]
    [Table("ATLBs", "dbo", "ItemId")]
    [Dto(typeof(ATLBDTO))]
	[Condition("IsDeleted", "0")]
    public class ATLB : AbstractRecord, IFileContainer
	{
        private static Type _thisType;
        /// <summary>
        /// Коллекция полетов ВС
        /// </summary>
        private AircraftFlightCollection _aircraftFlights;

        /*
        *  Свойства
        */

        #region public AircraftFlightCollection AircraftFlightsCollection
        /// <summary>
        /// 
        /// </summary>
        public AircraftFlightCollection AircraftFlightsCollection
        {
            get { return _aircraftFlights ?? (_aircraftFlights = new AircraftFlightCollection()); }
            set { _aircraftFlights = value; }
        }
        #endregion

		#region public String ATLBNo { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumnAttribute("ATLBNo")]
        [FormControl("ATLB No:", Order = 2)]
        [NotNull]
        public String ATLBNo { get; set; }
		#endregion

		#region public Int32 StartPageNo { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumnAttribute("StartPageNo")]
        [FormControl("Start Page No:", Order = 3)]
        [MinMaxValue(1,100000)]
        public Int32 StartPageNo { get; set; }
		#endregion

        #region public Int32 PageFlightCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumnAttribute("PageFlightCount")]
        [FormControl("Count flight on page:", Order = 4)]
        [MinMaxValue(1,4)]
        public Int32 PageFlightCount { get; set; }
        #endregion

        #region public DateTime OpeningDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        private DateTime _openingDate;
        [TableColumnAttribute("OpeningDate")]
        [FormControl("Opening date", Order = 5)]
        public DateTime OpeningDate
        {
            get { return _openingDate; }
            set { _openingDate = value; }
        }
        #endregion

		#region public String Revision { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumnAttribute("Revision")]
        [FormControl("Revision:", Order = 6)]
        public String Revision { get; set; }
		#endregion

		#region public AttachedFile AttachedFile { get; set; }

		private AttachedFile _attachedFile;

		/// <summary>
		/// 
		/// </summary>
		[FormControl("File", Order = 11)]
		public AttachedFile AttachedFile
		{
			get
			{
				return _attachedFile ?? (Files.GetFileByFileLinkType(FileLinkType.ATLBAttachedFile));
			}
			set
			{
				_attachedFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.ATLBAttachedFile);
			}
		}

		#endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1040)]
		public CommonCollection<ItemFileLink> Files
		{
			get { return _files ?? (_files = new CommonCollection<ItemFileLink>()); }
			set
			{
				if (_files != value)
				{
					if (_files != null)
						_files.Clear();
					if (value != null)
						_files = value;
				}
			}
		}

		#endregion

		#region public DateTime? DateFrom
		/// <summary>
		/// C какой даты ведется журнал
		/// </summary>
		public DateTime? DateFrom
        {
            get
            {
                if (_aircraftFlights == null)
                    return null;
                if (_aircraftFlights.Count == 0)
                    return null;
                return _aircraftFlights[0].FlightDate;
            }
        }
        #endregion

        #region public DateTime? DateTo
        /// <summary>
        /// До какой даты велся бортовой журнал
        /// </summary>
        public DateTime? DateTo
        {
            get
            {
                if (_aircraftFlights == null)
                    return null;
                if (_aircraftFlights.Count == 0)
                    return null;
                return _aircraftFlights[_aircraftFlights.Count-1].FlightDate;
            }
        }
        #endregion
        
        #region public Aircraft ParentAircraft { get; set; }
        /// <summary>
        /// Обратная ссылка на воздушное судно
        /// </summary>
        /// <returns></returns>
        //[FormControl("Aircraft", Enabled = false, Order = 1)]
        [TableColumnAttribute("AircraftId")]
        public int ParentAircraftId { get; set; }

        public static PropertyInfo ParentAircraftProperty
        {
            get { return GetCurrentType().GetProperty("ParentAircraftId"); }
        }

        #endregion

		[TableColumn("AtlbStatus")]
		[FormControl("AtlbStatus:", Order = 10)]
		public AtlbStatus AtlbStatus { get; set; }

        /*
		 *  Методы 
		 */

        #region public ATLB()
        /// <summary>
        /// Создает бортовой журнал без дополнительных параметров
        /// </summary>
        public ATLB()
        {
            ItemId = -1;
			SmartCoreObjectType = SmartCoreType.Atlb;
            _openingDate= DateTime.Today;

            ATLBNo = "";
            Remarks = "";
            Revision = "";
        }
        #endregion

        #region public ATLB(Aircraft parentAircraft) : this()
        /// <summary>
        /// Создает бортовой журнал и привязывает его к указанному ВС
        /// </summary>
        public ATLB(Aircraft parentAircraft) : this()
        {
            ParentAircraftId = parentAircraft.ItemId;
        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof (ATLB));
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ATLBNo;
        }
		#endregion

		/*
         * Дополнительные свойства 
         */

		#region public override DateTime RecordDate
		/// <summary>
		/// Унаследовано от AbstractRecord. Возвращает OpeningDate. Используется для сортировке по дате в BaseRecordCollection
		/// </summary>
		public override DateTime RecordDate
        {
            get { return _openingDate; }
            set { _openingDate = value; }
        }
        #endregion

        #region public override Lifelength OnLifelength { get;set; }
        /// <summary>
        /// Унаследовано от AbstractRecord не используется
        /// </summary>
        public override Lifelength OnLifelength { get;set; }
        #endregion

        #region public String Remarks { get; set; }
        /// <summary>
        /// Унаследовано от AbstractRecord. Используется для сохранения заметок 
        /// </summary>
        [TableColumnAttribute("Remarks")]
        [FormControl("Remarks:", Order = 7)]
        public override String Remarks { get; set; }
        #endregion
    }

}
