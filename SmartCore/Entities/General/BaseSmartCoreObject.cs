using System;
using System.Reflection;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Entities.General
{
    /// <summary>
    /// Класс, описывающий объект, который может сохранятся в БД
    /// </summary>
    [Serializable]
    public class BaseEntityObject : BaseCoreObject, IBaseEntityObject
    {
        private static Type _thisType;

        #region Implement of IBaseEntityObject

        #region public SmartCoreType ObjectType { get; protected set; }
        /// <summary>
        /// Тип объекта - директива, деталь, чек и т.д.
        /// </summary>
        public SmartCoreType SmartCoreObjectType { get; protected set; }
        #endregion

        #region public Boolean IsDeleted { get; set; }
        /// <summary>
        /// 
        /// </summary>     
        private bool _isDeleted;
        [TableColumnAttribute("IsDeleted")]
        public Boolean IsDeleted
        {
            get { return _isDeleted; }
            set
            {
                if (_isDeleted != value)
                {
                    _isDeleted = value;
                    OnPropertyChanged("IsDeleted");
                }
            }
        }
		#endregion

		#region public DateTime Updated { get; set; }

		[TableColumnAttribute("Updated")]
		public DateTime Updated { get; set; }

		#endregion

		#region public Int32 ItemId { get; set; }
		/// <summary>
		/// Идентификатор записи
		/// </summary>
		private int _itemId;
        [TableColumnAttribute("ItemId",ColumnAccessType.ReadOnly)]
        public Int32 ItemId
        {
            get { return _itemId; }
            set
            {
                if (_itemId != value)
                {
                    _itemId = value;
                    OnPropertyChanged("ItemId");
                }
            }
        }

        public static PropertyInfo ItemIdProperty
        {
            get { return GetCurrentType().GetProperty("ItemId"); }
        }
		#endregion

		#region public int CorrectorId { get; set; }

		[ListViewData("Signer")]
		[TableColumn("Corrector")]
        public int CorrectorId { get; set; }

        #endregion

		#region public override int CompareTo(object y)
		public override int CompareTo(object y)
        {
            if (y is BaseEntityObject)
                return ItemId.CompareTo(((BaseEntityObject)y).ItemId);
            return 0;
        }
        #endregion

		//Нужно исключительно для BulkInsert
		public string Guid { get; set; }

        #region public override string ToString()
        public override string ToString()
        {
            return "";
        }
        #endregion

        #region IBaseEntityObject IBaseEntityObject.GetCopyUnsaved()
        /// <summary>
        /// Возвращает полную копию объекта (полностью копирую вложенные элементы и коллекции),
        /// <br/>с ItemId равным -1
        /// </summary>
        /// <returns></returns>
        IBaseEntityObject IBaseEntityObject.GetCopyUnsaved(bool marked = true)
        {
            return GetCopyUnsaved(marked);
        }
        #endregion

        #region public IBaseEntityObject GetCopyUnsaved()
        /// <summary>
        /// Возвращает полную копию объекта (полностью копирую вложенные элементы и коллекции),
        /// <br/>с ItemId равным -1
        /// </summary>
        /// <returns></returns>
        public virtual BaseEntityObject GetCopyUnsaved(bool marked = true)
        {
			var clone = (BaseEntityObject)MemberwiseClone();
			clone.ItemId = -1;
			clone.UnSetEvents();

			return clone;
        }
        #endregion

        #endregion

        public BaseEntityObject()
        {
            SmartCoreObjectType = SmartCoreType.Unknown;
            ItemId = -1;
        }

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(BaseEntityObject));
        }
        #endregion

        #region Implement of IEquatable

        #region public bool Equals(IBaseEntityObject other)
        public bool Equals(IBaseEntityObject other)
        {
            //Без переопределения метода GetHashCode данный метод не работает
            //Почему? - ХЗ

            //Check whether the compared object is null.
            if (ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data.
            if (ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal.
            return SmartCoreObjectType.ItemId == other.SmartCoreObjectType.ItemId && ItemId == other.ItemId;
        }
        #endregion

        #region public override int GetHashCode()
        public override int GetHashCode()
        {
            int itemTypeHash = SmartCoreObjectType?.ItemId.GetHashCode() ?? -1;
            int itemIdHash = ItemId.GetHashCode();

            return itemTypeHash ^ itemIdHash;
        }
        #endregion

        #endregion

        #region IEqualityComparer<IBaseEntityObject>

        #region public bool Equals(IBaseEntityObject x, IBaseEntityObject y)
        public bool Equals(IBaseEntityObject x, IBaseEntityObject y)
        {
            //Без переопределения метода GetHashCode(BaseEntityObject) данный метод не работает
            //Почему? - ХЗ

            //Check whether the compared object references the same data.
            if (ReferenceEquals(x, y)) return true;

            //Check whether the compared object is null.
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;

            //Check whether the products' properties are equal.
            return x.SmartCoreObjectType.ItemId == y.SmartCoreObjectType.ItemId && x.ItemId == y.ItemId;
        }
        #endregion

        #region public int GetHashCode(IBaseEntityObject lifelength)
        public int GetHashCode(IBaseEntityObject lifelength)
        {
            if (ReferenceEquals(lifelength, null) == true)
                return 0;
            int itemTypeHash = SmartCoreObjectType.ItemId.GetHashCode();
            int itemIdHash = ItemId.GetHashCode();

            return itemTypeHash ^ itemIdHash;
        }
		#endregion

		#endregion

		#region public override bool Equals(object obj)

		public override bool Equals(object obj)
	    {
		    if (ReferenceEquals(obj, null)) return false;

		    //Check whether the compared object references the same data.
		    if (ReferenceEquals(this, obj)) return true;

		    var g = obj as BaseEntityObject;
		    if (g == null) return false;

		    return ItemId == g.ItemId && SmartCoreObjectType?.ItemId == g.SmartCoreObjectType?.ItemId;
	    }

	    #endregion

	}
}
