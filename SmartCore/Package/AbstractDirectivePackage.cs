using System;
using System.Reflection;
using SmartCore.Auxiliary;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Packages
{
	/// <summary>
	/// Класс, Описывающий объект содержащий в себе задачи
	/// </summary>
	[Serializable]
	public abstract class AbstractDirectivePackage<T> : BaseEntityObject, IDirectivePackage where T : BaseDirectivePackageRecord
    {
        private static Type _thisType;

        #region public String Number { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("Number")]
        [FormControl("Number:")]
        [ListViewData(100f, "Number", 2)]
        public String Number { get; set; }
        #endregion

        #region public String Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("Title")]
        [FormControl("Title:")]
        [ListViewData(150f, "Title", 3)]
        public String Title { get; set; }

        #endregion

        #region public String Description { get; set; }
        /// <summary>
        /// Описание рабочей карты
        /// </summary>
        [TableColumn("Description")]
        [FormControl("Description:")]
        [ListViewData(100, "Description", 4)]
        public String Description { get; set; }
        #endregion

        #region public Int32 ParentId { get; set; }

        private Int32 _parentId;
        /// <summary>
        /// Идентификатор детали, к которой пренадлежит запись
        /// </summary>
        [TableColumn("ParentId")]
        public Int32 ParentId
        {
            get { return _parentId; }
            set
            {
                if (_parentId != value)
                {
                    _parentId = value;
                    OnPropertyChanged("PatenrId");
                }
            }
        }

        public static PropertyInfo ParentIdProperty
        {
            get { return GetCurrentType().GetProperty("ParentId"); }
        }

        #endregion

        #region public SmartCoreType ParentType

        private SmartCoreType _parentType;

        /// <summary>
        /// Тип родительской задачи
        /// </summary>
        //[TableColumnAttribute("ParentTypeId")]
        public SmartCoreType ParentType
        {
            get { return _parentType ?? SmartCoreType.Unknown; }
            internal set { _parentType = value; }
        }

        public static PropertyInfo ParentTypeIdProperty
        {
            get { return GetCurrentType().GetProperty("ParentType"); }
        }

        #endregion

        #region public BaseEntityObject Parent

        private BaseEntityObject _parent;
        public BaseEntityObject Parent
        {
            get { return _parent; }
            set
            {
                if (!Object.Equals(_parent, value))
                {
                    _parent = value;
                    OnPropertyChanged("Parent");
                }

                if (_parent != null)
                {
                    ParentId = _parent.ItemId;
                    ParentType = _parent.SmartCoreObjectType;
                }
                else
                {
                    ParentId = -1;
                    ParentType = SmartCoreType.Unknown;
                }
            }
        }
        #endregion

        #region public String Station { get; set; }
        /// <summary>
        /// 
        /// </summary>
        //[ListViewData(0.08f, "Station", 12)]
        public String Station { get; set; }
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
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged("Status");
                }
            }
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
                if (_createDate < min || _createDate != value)
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
                if (_createDate < (new DateTime(1950, 01, 01))) return null;
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
                if (_openingDate < (DateTimeExtend.GetCASMinDateTime())) return null;
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
                if (_status != WorkPackageStatus.Opened && _publishingDate >= (DateTimeExtend.GetCASMinDateTime())) return _publishingDate;
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

        #region public AttachedFile AttachedFile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [FormControl("File:")]
        [TableColumn("FileId")]
        [Child]
        public AttachedFile AttachedFile { get; set; }
        #endregion

        #region public Boolean PackageItemsLoaded { get; set; }

        /// <summary>
        /// Были ли загружены элементы рабочего пакета - по умолчанию - false
        /// </summary>
        public Boolean PackageItemsLoaded { get; set; }

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

        #region ICommonCollection IDirectivePackage.PakageRecords { get; }
        /// <summary>
        /// Взвращает массив элементов для привязки директив к рабочему пакету
        /// </summary>
        ICommonCollection IDirectivePackage.PackageRecords { get { return PackageRecords; } }

        #endregion

        #region public abstract CommonCollection<T> PackageRecords { get; internal set; }
        /// <summary>
        /// Взвращает массив элементов для привязки директив к рабочему пакету
        /// </summary>
        public abstract CommonCollection<T> PackageRecords { get; internal set; }

        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(AbstractDirectivePackage<T>));
        }
        #endregion
    }
}
