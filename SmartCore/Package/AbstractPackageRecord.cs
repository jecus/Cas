using System;
using System.Reflection;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Packages
{
    /// <summary>
    /// Класс, Описывающий запись в пакете задач
    /// </summary>
    public class BasePackageRecord : BaseEntityObject, IPackageRecord
    {
        private static Type _thisType;

        /*
         *  Свойства
         */

        #region public Int32 ParentPackageId { get; set; }
        
        private Int32 _parentPackageId;
        /// <summary>
        /// ID пакета, которому пренадлежит запись
        /// </summary>
        [TableColumn("ParentPackageId")]
        public Int32 ParentPackageId
        {
            get { return _parentPackageId; }
            set
            {
                if (_parentPackageId != value)
                {
                    _parentPackageId = value;
                    OnPropertyChanged("ParentPackageId");
                }
            }
        }

        public static PropertyInfo ParentPackageIdProperty
        {
            get { return GetCurrentType().GetProperty("ParentPackageId"); }
        }

		#endregion

        #region public IPackage ParentPackage { get; set; }
        /// <summary>
        /// Родительский рабочий пакет
        /// </summary>
        public IPackage ParentPackage { get; set; }
        #endregion

        #region public Int32 PackageItemId { get; set; }

        private int _packageItemId;
        /// <summary>
        /// ID директивы хранящейся в пакете
        /// </summary>
        [TableColumn("PackageItemId")]
        public Int32 PackageItemId
        {
            get { return _packageItemId; }
            set
            {
                if (_packageItemId != value)
                {
                    _packageItemId = value;
                    OnPropertyChanged("PackageItemId");
                }
            }
        }

        public static PropertyInfo PackageItemIdProperty
        {
            get { return GetCurrentType().GetProperty("PackageItemId"); }
        }

		#endregion

        #region public SmartCoreType PackageItemType { get; set; }

        private SmartCoreType _packageItemType;

        /// <summary>
        /// Тип задачи, которой пренадлежит данная запись
        /// </summary>
        [TableColumn("PackageItemTypeId")]
        public SmartCoreType PackageItemType
        {
            get { return _packageItemType; }
            set
            {
                if (_packageItemType != value)
                {
                    _packageItemType = value;
                    OnPropertyChanged("PackageItemType");
                }
            }
        }

        public static PropertyInfo PackageItemTypeProperty
        {
            get { return GetCurrentType().GetProperty("PackageItemType"); }
        }

		#endregion

        #region public IBaseEntityObject PackageItem { get; set; }

        private IBaseEntityObject _packageItem;

        /// <summary>
        /// Задача, привязанная к данной записи
        /// </summary>
        public IBaseEntityObject PackageItem
        {
            get { return _packageItem; }
            set
            {
                if (_packageItem != value)
                {
                    _packageItem = value;
                    if (_packageItem != null)
                    {
                        _packageItemId = _packageItem.ItemId;
                        _packageItemType = _packageItem.SmartCoreObjectType;
                    }
                    else
                    {
                        _packageItemId = -1;
                        _packageItemType = SmartCoreType.Unknown;
                    }

                    OnPropertyChanged("PackageItem");
                }
            }
        }
        #endregion

        /*
		*  Методы 
		*/

        #region public AbstractPackageRecord()
        public BasePackageRecord()
        {
        }
        #endregion

        #region public override string ToString()
        public override string ToString()
        {
            return string.Format("Dir:id {0} desc:{1} ", PackageItemId, PackageItem != null ? PackageItem.ToString() : "");
        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(BasePackageRecord));
        }
        #endregion

    }
}
