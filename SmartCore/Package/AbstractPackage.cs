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
    public abstract class AbstractPackage<T> : BaseEntityObject, IPackage where T : BasePackageRecord
    {
        private static Type _thisType;

        #region public String Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Filter("Title:")]
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

        #region public String Author { get; set; }
        [TableColumn("Author"), ListViewData(0.1f, "Author")]
        [FormControl("Author:", Enabled = false)]
        public String Author { get; set; }

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
        [TableColumn("ParentTypeId")]
        public SmartCoreType ParentType
        {
            get { return _parentType ?? SmartCoreType.Unknown; }
            set { _parentType = value; }
        }

        public static PropertyInfo ParentTypeIdProperty
        {
            get { return GetCurrentType().GetProperty("ParentType"); }
        }

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

        #region public DateTime OpeningDate { get; set; }

        private DateTime _openingDate;
        /// <summary>
        /// Дата открытия Рабочего Пакета 
        /// </summary>
        [TableColumn("OpeningDate")]
        [FormControl("Opening Date:")]
        public DateTime OpeningDate
        {
            get
            {
                DateTime min = DateTimeExtend.GetCASMinDateTime();
                return _openingDate < min ? min : _openingDate;
            }
            set
            {
                if (_openingDate != value)
                {
                    _openingDate = value;
                    OnPropertyChanged("OpeningDate");
                }
            }
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
            get
            {
                DateTime min = DateTimeExtend.GetCASMinDateTime();
                return _publishingDate < min ? min : _openingDate;
            }
            set
            {
                if (_publishingDate != value)
                {
                    _publishingDate = value;
                    OnPropertyChanged("PublishingDate");
                }
            }
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
            get
            {
                DateTime min = DateTimeExtend.GetCASMinDateTime();
                return _closingDate < min ? min : _openingDate;
            }
            set
            {
                if (_closingDate != value)
                {
                    _closingDate = value;
                    OnPropertyChanged("ClosingDate");
                }
            }
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

        #region public String Remarks { get; set; }
        /// <summary>
        /// Примечания рабочего пакета 
        /// </summary>
        [TableColumn("Remarks")]
        [FormControl(250, "Remarks:", 8)]
        [ListViewData(0.08f, "Remarks")]
        public String Remarks { get; set; }
        #endregion

        #region ICommonCollection IPackage.PackageRecords { get; }
        /// <summary>
        /// Взвращает массив элементов для привязки директив к рабочему пакету
        /// </summary>
        ICommonCollection IPackage.PackageRecords { get { return PackageRecords; } }

        #endregion

        #region public abstract CommonCollection<T> PackageRecords { get; internal set; }
        /// <summary>
        /// Взвращает массив элементов для привязки директив к рабочему пакету
        /// </summary>
        public abstract CommonCollection<T> PackageRecords { get; internal set; }

        #endregion

        #region public Boolean PackageItemsLoaded { get; set; }

        /// <summary>
        /// Были ли загружены элементы рабочего пакета - по умолчанию - false
        /// </summary>
        public Boolean PackageItemsLoaded { get; set; }

        #endregion

        private BaseEntityObject _parent;

        public BaseEntityObject Parent
        {
            get { return _parent; }
            set
            {
                if (value != null)
                {
                    if (!value.Equals(_parent))
                    {
                        _parent = value;
                        _parentId = _parent.ItemId;
                        _parentType = _parent.SmartCoreObjectType;
                        OnPropertyChanged("ParentId");
                    }
                }
                else
                {
                    if (_parent != null)
                    {
                        _parent = null;
                        _parentId = -1;
                        _parentType = SmartCoreType.Unknown;
                        OnPropertyChanged("ParentId");
                    }
                }
            }
        }

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(AbstractPackage<T>));
        }
        #endregion
    }
}
