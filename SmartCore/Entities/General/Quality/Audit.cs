using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EFCore.DTO.General;
using SmartCore.Auxiliary;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Files;
using SmartCore.Packages;
using Convert = System.Convert;

namespace SmartCore.Entities.General.Quality
{
    /// <summary>
    /// Класс описывает рабочий пакет - набор заданий 
    /// </summary>
    [Table("Audits", "dbo", "ItemId")]
    [Dto(typeof(AuditDTO))]
	[Condition("IsDeleted", "0")]
    public class Audit : BaseEntityObject, IDirectivePackage, IFileContainer
	{

		private static Type _thisType;

		/*
		*  Свойства взятые из базы данных
		*/

		#region public Int32 ParentId { get; set; }
		/// <summary>
		/// Id воздушного судна, для которого составлен рабочий пакет
		/// </summary>
		[TableColumn("ParentId")]
        public Int32 ParentId { get; set; }

		public static PropertyInfo ParentTypeIdProperty
		{
			get { return GetCurrentType().GetProperty("ParentId"); }
		}

		#endregion

		#region public String Number { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Number")]
        [FormControl("Audit No:")]
        [ListViewData(100f, "Audit No:", 2)]
        public String Number { get; set; }
        #endregion

		#region public String Title { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumn("Title")]
        [FormControl("Title:")]
        [ListViewData(150f,"Title",3)]
        [NotNull]
        public String Title { get; set; }
		#endregion

		#region public String Description { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumn("Description")]
        [FormControl("Description:")]
        [ListViewData(100, "Description",4)]
        public String Description { get; set; }
		#endregion

        #region public double ManHours { get; set; }

        /// <summary>
        /// Трудозатраты пакета работ
        /// </summary>
        [SubQuery("ManHours",
			@"(select sum(manhours) 
            from (SELECT manhours 
                  FROM Procedures 
                  where Procedures.itemId in (select DirectivesId 
                                              from AuditRecords
                                              where AuditRecords.IsDeleted = 0 and 
                                                    AuditRecords.AuditItemTypeId = 1 and 
                                                    AuditRecords.AuditId = Audits.ItemId)
                  UNION ALL
                  SELECT manhours 
                  FROM Components 
                  where Components.itemId in (select DirectivesId 
                                              from AuditRecords
                                              where AuditRecords.IsDeleted = 0 and 
                                                    AuditRecords.AuditItemTypeId = 5 and 
                                                    AuditRecords.AuditId = Audits.ItemId)) WPMH)"
			)]
        [ListViewData(85, "MH",10)]
        public double ManHours { get; set; }
        #endregion

        #region public double Persent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ListViewData(0.08f, "Persent", 14)]
        public double Persent { get; set; }
        #endregion

        #region public WorkPackageStatus Status { get; set; }

        private WorkPackageStatus _status;
        /// <summary>
        /// Статус (состояние) рабочего пакета
        /// </summary>
        [TableColumn("Status")]
        [FormControl("Status:", Enabled = false)]
        public WorkPackageStatus Status
        {
            get { return _status; } 
            set { _status = value; }
        }

		public static PropertyInfo StatusProperty
		{
			get { return GetCurrentType().GetProperty("Status"); }
		}

		#endregion

		#region public DateTime CreateDate { get; set; }

		private DateTime _createDate;
        /// <summary>
        /// Дата открытия Рабочего Пакета 
        /// </summary>
        [TableColumn("CreateDate")]
        [FormControl("Create Date:", Enabled = false)]
        public DateTime CreateDate
        {
            get { return _createDate; }
            set
            {
                DateTime min = DateTimeExtend.GetCASMinDateTime();
                if(_createDate < min || _createDate != value)
                {
                    _createDate = value < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : value;
                }
            }
        }

        /// <summary>
        /// Представление даты создания рабочего пакета для списка
        /// </summary>
        [ListViewData(0.1f, "Create Date", 5)]
        public DateTime? ListViewCreateDate
        {
            get
            {
                if (_createDate < (DateTimeExtend.GetCASMinDateTime())) return null;
                return _createDate;
            }
        }
        #endregion

		#region public DateTime OpeningDate { get; set; }

        private DateTime _openingDate;
        /// <summary>
        /// Дата открытия Рабочего Пакета 
        /// </summary>
        [TableColumn("OpeningDate")]
        [FormControl("Opening Date:")]
        public DateTime OpeningDate
        {
            get { return _openingDate; }
            set { _openingDate = value; }
        }

        /// <summary>
        /// Представление даты открытия рабочего пакета для списка
        /// </summary>
        [ListViewData(0.1f, "Opening date", 6)] 
        public DateTime? ListViewOpeningDate
        {
            get
            {
                if (_openingDate < (new DateTime(1950, 01, 01)) ) return null;
                return _openingDate;
            }
        }
		#endregion

		#region public DateTime PublishingDate { get; set; }

        private DateTime _publishingDate;
		/// <summary>
		/// Дата публикации рабочего пакета 
		/// </summary>
        [TableColumn("PublishingDate")]
        [FormControl("Publishing Date:")]
        public DateTime PublishingDate
        {
            get { return _publishingDate; }
            set { _publishingDate = value; }
        }

        /// <summary>
        /// Представление даты публикации рабочего пакета для списка
        /// </summary>
        [ListViewData(0.1f, "Publishing date", 7)]
        public DateTime? ListViewPublishingDate
        {
            get
            {
                if (_status != WorkPackageStatus.Opened && _publishingDate >= (new DateTime(1950, 01, 01))) return _publishingDate;
                return null;
            }
        }

		#endregion

		#region public DateTime ClosingDate { get; set; }

        private DateTime _closingDate;
        /// <summary>
        /// Дата закрытия рабочего пакета
        /// </summary>
        [TableColumn("ClosingDate")]
        [FormControl("Closing Date:")]
        public DateTime ClosingDate
        {
            get { return _closingDate; }
            set { _closingDate = value; }
        }

        /// <summary>
        /// Представление даты закрытия рабочего пакета для списка
        /// </summary>
        [ListViewData(0.1f, "Closing date", 8)]
        public DateTime? ListViewClosingDate
        {
            get
            {
                if (_status == WorkPackageStatus.Closed && _closingDate >= (DateTimeExtend.GetCASMinDateTime())) return _closingDate;
                return null;
            }
        }

		#endregion

        #region public String WorkTimeString { get; set; }
        /// <summary>
        /// Для закрытого рабочего пакета, возвращает временной интервал, затраченный на исполнение задач в виде строки
        /// </summary>
        [ListViewData(100,"Work time", 11)]
        public String WorkTimeString
        {
            get
            {
                string workTime = "";
                if (_status == WorkPackageStatus.Closed)
                {
                    TimeSpan time = _closingDate - _publishingDate;
                    if (time.TotalDays - time.TotalDays % 1 > 0) workTime += Convert.ToInt32(time.TotalDays - time.TotalDays % 1) + "d ";
                    if (time.Hours > 0) workTime += Convert.ToInt32(time.Hours) + "h ";
                    if (time.Minutes > 0) workTime += Convert.ToInt32(time.Minutes) + "m ";
                }

                return workTime;
            }
        }
        #endregion

        #region public String Author { get; set; }
        /// <summary>
        /// Автор рабочего пакета 
        /// </summary>
        [TableColumn("Author")]
        [FormControl("Author:", Enabled = false)]
        [ListViewData(0.08f,"Author")]
        public String Author { get; set; }
        #endregion

        #region public String PublishedBy { get; set; }
        /// <summary>
        /// Имя пользователя опубликовавшего рабочий пакет
        /// </summary>
        [TableColumn("PublishedBy")]
        [FormControl("Published By:", Enabled = false)]
        [ListViewData(0.08f, "Published By")]
        public String PublishedBy { get; set; }
        #endregion

        #region public String ClosedBy { get; set; }
        /// <summary>
        /// Имя пользователя закрывшего рабочий пакет
        /// </summary>
        [TableColumn("ClosedBy")]
        [FormControl("Closed By:", Enabled = false)]
        [ListViewData(0.08f, "Closed By")]
        public String ClosedBy { get; set; }
        #endregion

		#region public String Remarks { get; set; }
		/// <summary>
		/// Примечания рабочего пакета 
		/// </summary>
        [TableColumn("Remarks")]
        [FormControl("Remarks:")]
        [ListViewData(0.08f, "Remarks")]
        public String Remarks { get; set; }
		#endregion

		#region public String PublishingRemarks { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumn("PublishingRemarks")]
        [FormControl("Publishing Remarks:")]
        public String PublishingRemarks { get; set; }
		#endregion

		#region public String ClosingRemarks { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumn("ClosingRemarks")]
        [FormControl("Closing Remarks:")]
        public String ClosingRemarks { get; set; }
		#endregion

		#region public Boolean OnceClosed { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumn("OnceClosed")]
        public Boolean OnceClosed { get; set; }
		#endregion

		#region public String ReleaseCertificateNo { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumn("ReleaseCertificateNo")]
        [FormControl("Release Certificate No:")]
        public String ReleaseCertificateNo { get; set; }
		#endregion

        #region public String Revision { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("Revision")]
        [FormControl("Revision:")]
        public String Revision { get; set; }
        #endregion

		#region public String CheckType { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumn("CheckType")]
        [FormControl("Check Type:")]
        public String CheckType { get; set; }
		#endregion

		#region public String Station { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumn("Station")]
        [FormControl("Station:")]
        [ListViewData(0.08f, "Station", 12)]
        public String Station { get; set; }
		#endregion

        #region public String MaintenanceRepairOrzanization { get; set; }
        /// <summary>
		/// 
		/// </summary>
        [TableColumn("MaintenanceReportNo")]
        [ListViewData(0.05f, "MRO", 13)]
        [FormControl("MRO:")]
        public String MaintenanceRepairOrzanization { get; set; }
		#endregion

		#region public AttachedFile AttachedFile { get; set; }

		private AttachedFile _attachedFile;
		/// <summary>
		/// 
		/// </summary>
		[FormControl("WP File:")]
	    public AttachedFile AttachedFile
	    {
			get
			{
				return _attachedFile ?? (Files.GetFileByFileLinkType(FileLinkType.AuditAttachedFile));
			}
			set
			{
				_attachedFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.AuditAttachedFile);
			}
		}

	    #endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1080)]
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

		/*
         * Дополнительные свойства
         */

		#region public Operator Operator { get; set; }

		/// <summary>
		/// Обратная ссылка на оператора, для которого составлен рабочий пакет. 
		/// </summary>
		public Operator Operator { get; set; }

        #endregion

        #region ICommonCollection IDirectivePackage.PackageRecords { get; }
        /// <summary>
        /// Взвращает массив элементов для привязки директив к рабочему пакету
        /// </summary>
        ICommonCollection IDirectivePackage.PackageRecords { get { return _auditRecords; } }

        #endregion

        #region public CommonCollection<AuditRecord> AuditRecords { get; }

        private CommonCollection<AuditRecord> _auditRecords;
	    /// <summary>
        /// Взвращает массив элементов для привязки директив к аудиту
        /// </summary>
        [Child(RelationType.OneToMany, "AuditId", "Audit", false)]
        public CommonCollection<AuditRecord> AuditRecords
        {
            get { return _auditRecords ?? (_auditRecords = new CommonCollection<AuditRecord>()); }
	        set
	        {
				if (_auditRecords != value)
				{
					if (_auditRecords != null)
						_auditRecords.Clear();
					if (value != null)
						_auditRecords = value;
				}
			}
        }

        #endregion

        #region Boolean Boolean AuditItemsLoaded { get; internal set; }

        /// <summary>
        /// Были ли загружены элементы рабочего пакета - по умолчанию - false
        /// </summary>
        public Boolean AuditItemsLoaded { get; internal set; }

        #endregion

        #region public DateTime MinClosingDate { get; set; }

        /// <summary>
        /// Минимальная дата закрытия рабочего пакета
        /// </summary>
        public DateTime? MinClosingDate { get; set; }

        #endregion

        #region public DateTime MaxClosingDate { get; set; }

        /// <summary>
        /// Максимальная дата закрытия рабочего пакета
        /// </summary>
        public DateTime? MaxClosingDate { get; set; }

        #endregion

        #region public bool CanPublish { get; set; }
        /// <summary>
        /// Можно ли опубликовать пакет
        /// </summary>
        public bool CanPublish { get; set; }
        #endregion

        #region public string BlockPublishReason { get; set; }
        /// <summary>
        /// ПРичина невозможности публикации рабочего пакета
        /// </summary>
        public string BlockPublishReason { get; set; }
        #endregion

        #region bool bool CanClose { get; set; }
        /// <summary>
        /// Можно ли закрыть пакет
        /// </summary>
        public bool CanClose { get; set; }
        #endregion

        /*
         * Элементы рабочего пакета, Work Package содержит все виды работ из Forecast + Job Cards + Non Routine Jobs + Maintenance Cheks + Maintenance Workscope Items
         */

        #region public IEnumerable<Procedure> Procedures{ get; }
        /// <summary>
        /// Процедуры
        /// </summary>
        public IEnumerable<Procedure> Procedures
        {
            get
            {
                IEnumerable<Procedure> res =
                    _auditRecords.Where(record => record.Task != null &&
                                                  record.Task.SmartCoreObjectType == SmartCoreType.Procedure)
                                 .Select(record => record.Task as Procedure);
                return res;
            }
        }
		#endregion

		/*
		*  Методы 
		*/

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(Audit));
		}
		#endregion

		#region public Audit()
		/// <summary>
		/// Создает воздушное судно без дополнительной информации
		/// </summary>
		public Audit()
        {
            ItemId = -1;
			SmartCoreObjectType = SmartCoreType.Audit;
            CanClose = true;
            CanPublish = true;
            AuditItemsLoaded = false;
            Title = "";

            CreateDate = OpeningDate = PublishingDate = ClosingDate = DateTime.Today;
            _status = WorkPackageStatus.Opened;
            // создаем все коллекции
        }
        #endregion
     
        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Title;
        }
		#endregion
	}

}
