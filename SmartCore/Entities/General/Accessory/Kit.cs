using System;
using System.Collections.Generic;
using System.Reflection;
using SmartCore.DataAccesses.Kits;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace SmartCore.Entities.General.Accessory
{
    /// <summary>
    /// Класс для описания комплектующего, необходимого для выполнения задачи
    /// </summary>
    [Table("Kits", "dbo", "ItemId")]
    [Dto(typeof(KitDTO))]
	[Condition("IsDeleted", "0")]
    [Serializable]
    public class AccessoryRequired : AbstractAccessory, IEqualityComparer<AccessoryRequired>
    {
        private static Type _thisType;

		#region Implement IAccessory

		#region public override Product Product { get; set; }

		private Product _product;
        /// <summary>
        /// Описание агрегата
        /// </summary>
        [TableColumn("AccessoryDescriptionId")]
        [Child(true)]
        public override Product Product
        {
            get { return _product; }
            set
            {
                if (_product != value)
                {
                    _product = value;
                    OnPropertyChanged("Product");
                }
            }
        }
        #endregion

        #region public override GoodStandart Standart { get; set; }

        private GoodStandart _standart;
        /// <summary>
        /// Чертёжный номер агрегата
        /// </summary>
        [ListViewData(0.1f, "Standart", 1)]
        [Filter("Standart:", Order = 7)]
        [TableColumn("GoodStandartId")]
        [Child(false)]
        public override GoodStandart Standart
        {
            get { return _product != null ? _product.Standart : _standart; }
            set
            {
                //if (_product != null)
                //{
                //    if (_product.Standart != value)
                //    {
                //        _product.Standart = value;
                //        OnPropertyChanged("Standart");    
                //    }
                //}
                //else 
                if (_product == null && _standart != value)
                {
                    _standart = value;
                    OnPropertyChanged("Standart");  
                }
            }
        }
        #endregion

        #region public override String PartNumber { get; set; }

        //private string _partNumber;
        /// <summary>
        /// Чертёжный номер агрегата
        /// </summary>
        //[TableColumn("PartNumber")]
        [ListViewData(0.1f, "Part Number", 2)]
        [Filter("Part. No.:", Order = 2)]
        public override String PartNumber
        {
            get { return _product != null ? _product.PartNumber : ""; }
            set 
            { 
                if(_product != null && _product.PartNumber != value)
                {
                    _product.PartNumber = value;
                    OnPropertyChanged("PartNumber");
                } 
            }
        }
        #endregion

        #region public override String SerialNumber { get; set; }

        //private string _serialNumber;
        /// <summary>
        /// Серийный номер агреагата
        /// </summary>
        public override String SerialNumber
        {
            get { return _product != null ? _product.SerialNumber : ""; } 
            set
            {
                if (_product != null && _product.SerialNumber != value)
                {
                    _product.SerialNumber = value;
                    OnPropertyChanged("SerialNumber");
                } 
            }
        }
        #endregion

        #region public override GoodsClass GoodsClass { get; set; }

        //private DetailClass _detailClass;
        /// <summary>
        /// Класс
        /// </summary>
        //[TableColumn("DetailClass")]
        [FormControl(250, "Class")]
        [ListViewData(0.08f, "Class")]
        [Filter("Class:", Order = 8)]
        [NotNull]
        public override GoodsClass GoodsClass
        {
            get { return _product != null ? _product.GoodsClass : GoodsClass.KIT; }
            set
            {
                if (_product != null && _product.GoodsClass != value)
                {
                    _product.GoodsClass = value;
                    OnPropertyChanged("GoodsClass");
                } 
            }
        }

        #endregion

        #region public override String BatchNumber { get; set; }

        //private string _batchNumber;
        /// <summary>
        /// Пакетный номер агреагата
        /// </summary>
        public override String BatchNumber
        {
            get { return _product != null ? _product.BatchNumber : ""; }
            set
            {
                if (_product != null && _product.BatchNumber != value)
                {
                    _product.BatchNumber = value;
                    OnPropertyChanged("BatchNumber");
                }
            }
        }
        #endregion

        #region public override String Description { get; set; }

        //private string _description;
        /// <summary>
        /// Описание агрегата
        /// </summary>
        //[TableColumn("Description")]
        [ListViewData(0.12f, "Product", 3)]
        [Filter("Product:", Order = 3)]
        public override String Description
        {
            get { return _product != null ? _product.Description : ""; }
            set
            {
                if (_product != null && _product.Description != value)
                {
                    _product.Description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        #endregion

        #region public override String Manufacturer { get; set; }

        //private string _manufacturer;
        /// <summary>
        /// Производитель
        /// </summary>
        //[TableColumn("Manufacturer")]
        [ListViewData(0.12f, "Manufacturer", 4)]
        [Filter("Manufacturer:", Order = 4)]
        public override String Manufacturer
        {
            get { return _product != null ? _product.Manufacturer : ""; }
            set
            {
                if (_product != null && _product.Manufacturer != value)
                {
                    _product.Manufacturer = value;
                    OnPropertyChanged("Manufacturer");
                }
            }
        }
        #endregion

        #region public override SupplierCollection Suppliers  { get; set; }

        private SupplierCollection _suppliers;
        /// <summary>
        /// Поставщики данной детали
        /// </summary>
        [ListViewData(0.12f, "Suppliers", 5)]
        [Filter("Suppliers:")]
        public override SupplierCollection Suppliers
        {
            get
            {
                if(_product != null)
                {
                    return _product.Suppliers;
                }
                return _suppliers ?? (_suppliers = new SupplierCollection());
            }
            set
            {
                if (_product != null)
                {
                    if (_product.Suppliers != value)
                    {
                        _product.Suppliers = value;
                        OnPropertyChanged("Suppliers");
                    }
                }
                else
                {
                    if (_suppliers != value)
                    {
                        if (_suppliers != null)
                            _suppliers.Clear();
                        if (value != null)
                            _suppliers = value;
                    }
                }
            }
        }
        #endregion

        #region public override Double CostNew { get; set; }

        //private double _costNew;
        /// <summary>
        /// Цена новой детали
        /// </summary>
        //[TableColumn("CostNew")]
        [MinMaxValueAttribute(0, 1000000000), ListViewData(0.05f, "Cost new", 8)]
        public override Double CostNew
        {
            get { return _product != null ? _product.CostNew : 0; }
            set
            {
                if (_product != null && _product.CostNew != value)
                {
                    _product.CostNew = value;
                    OnPropertyChanged("CostNew");
                }
            }
        }
        #endregion

        #region public override Double CostOverhaul { get; set; }

        //private double _costOvehaul;
        /// <summary>
        /// 
        /// </summary>
        //[TableColumn("CostOverhaul")]
        [MinMaxValueAttribute(0, 1000000000), ListViewData(0.05f, "Cost OH", 9)]
        public override Double CostOverhaul
        {
            get { return _product != null ? _product.CostOverhaul : 0; }
            set
            {
                if (_product != null && _product.CostOverhaul != value)
                {
                    _product.CostOverhaul = value;
                    OnPropertyChanged("CostOverhaul");
                }
            }
        }
        #endregion

        #region public override Double CostServiceable { get; set; }

        //private double _costServiceable;
        /// <summary>
        /// Стоимость после обслуживания
        /// </summary>
        //[TableColumn("CostServiceable")]
        [MinMaxValueAttribute(0, 1000000000), ListViewData(0.05f, "Cost Serv.", 10)]
        public override Double CostServiceable
        {
            get { return _product != null ? _product.CostServiceable : 0; }
            set
            {
                if (_product != null && _product.CostServiceable != value)
                {
                    _product.CostServiceable = value;
                    OnPropertyChanged("CostServiceable");
                }
            }
        }
        #endregion

        #region public override double Quantity { get; set; }

        private double _quantity;
        /// <summary>
        /// Необходимое кол-во комплектующего для выполнения задачи
        /// </summary>
        [TableColumn("Quantity"), MinMaxValueAttribute(0, 1000000000), ListViewData(0.05f, "Q-ty.", 11)]
        public override double Quantity
        {
            get { return _quantity; } 
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged("Quantity");
                }
            }
        }
        #endregion

        #region public override Measure Measure

        //private Measure _measure;
        /// <summary>
        /// Единица измерения
        /// </summary>
        //[TableColumn("Measure")]
        public override Measure Measure
        {
            get { return _product != null ? _product.Measure : Measure.Unit; }
            set
            {
                if (_product != null && _product.Measure != value)
                {
                    _product.Measure = value;
                    OnPropertyChanged("Measure");
                }
            }
        }
        #endregion

        #region public override String Remarks { get; set; }

        private string _remarks;
        /// <summary>
        /// Дополнительные заметки
        /// </summary>
        [TableColumn("Remarks"), ListViewData(0.08f, "Remarks")]
        [Filter("Remarks:", Order = 6)]
        public override String Remarks
        {
            get { return _remarks; } 
            set { _remarks = value; }
        }
        #endregion

        #region public override CommonCollection<KitSuppliersRelation> SupplierRelations { get; set; }

        private CommonCollection<KitSuppliersRelation> _supplierRelations;
        /// <summary>
        /// связи с поставщиками данного KIT-а
        /// </summary>
        public override CommonCollection<KitSuppliersRelation> SupplierRelations
        {
            get
            {
                if(_product != null)
                {
                    return _product.SupplierRelations;
                }
                return _supplierRelations ?? (_supplierRelations = new CommonCollection<KitSuppliersRelation>());
            }
            set
            {
                if (_product != null)
                {
                    if(_product.SupplierRelations != value)
                    {
                        _product.SupplierRelations = value;
                        OnPropertyChanged("SupplierRelations");
                    }
                }
                else
                {
                    if (_supplierRelations != value)
                    {
                        if (_supplierRelations != null)
                            _supplierRelations.Clear();
                        if (value != null)
                            _supplierRelations = value;
                    }
                }
            }
        }
        #endregion

        #endregion

        #region public double TaskQuantity{ get; }
        /// <summary>
        /// Необходимое кол-во комплектующего для расчитанных выполнений задачи
        /// </summary>
        [ListViewData(0.08f, "Task Q-ty.", 12)]
        public double TaskQuantity
        {
            get
            {
                int taskTimes = _parent is IDirective
                                    ? ((IDirective) _parent).NextPerformances.Count
                                    : 0;
                return _quantity * taskTimes;
            }
        }
        #endregion

        #region public SmartCoreType SmartCoreType { get; set; }

        private SmartCoreType _smartCoreType;
        /// <summary>
        /// Тип родительской задачи
        /// </summary>
        [Filter("Task type:", Order = 10)]
        public SmartCoreType SmartCoreType
        {
            get { return _smartCoreType; }
        }
        #endregion

        #region public MaintenanceCheck MaintenanceCheck { get; }
        [NonSerialized]
        private MaintenanceCheck _check;
        /// <summary>
        /// Чек программы обслуживания, к которому привязана задача
        /// </summary>
        [ListViewData(80, "Check", 6)]
        [Filter("Check:", Order = 11)]
        public MaintenanceCheck MaintenanceCheck
        {
            get { return _check; }
        }
        #endregion

        #region public MaintenanceCheckType _maintenanceCheckType { get; set; }

        private MaintenanceCheckType _maintenanceCheckType = MaintenanceCheckType.Unknown;
        /// <summary>
        /// Возвращает тип чека, если родительской задачей является Чек программы обслуживания или MaintenanceCheckType.Unknown
        /// </summary>
        [Filter("Check type:", Order = 12)]
        public MaintenanceCheckType MaintenanceCheckType
        {
            get { return _maintenanceCheckType; }
        }
        #endregion

        #region public Int32 ParentId { get; set; }
        /// <summary>
        /// Id родительского элемента 
        /// </summary>
        [TableColumnAttribute("ParentId")]
        public Int32 ParentId { get; set; }

        public static PropertyInfo ParentIdProperty
        {
            get { return GetCurrentType().GetProperty("ParentId"); }
        }

        #endregion

        #region public Int32 ParentTypeId { get; set; }
        /// <summary>
        /// Тип родительского элемента 
        /// </summary>
        [TableColumnAttribute("ParentTypeId")]
        public Int32 ParentTypeId { get; set; }

        public static PropertyInfo ParentTypeIdProperty
        {
            get { return GetCurrentType().GetProperty("ParentTypeId"); }
        }

		#endregion

		#region public int AircraftModelId { get; set; }

		[TableColumn("AircraftModelId")]
	    public int AircraftModelId { get; set; }

		public static PropertyInfo AircraftModelIdProperty
		{
			get { return GetCurrentType().GetProperty("AircraftModelId"); }
		}

		#endregion

		[Filter("Reference:", Order = 1)]
		public string Reference => Product?.Reference;

		#region public IKitRequired ParentObject  { get; set; }

		private IKitRequired _parent;
        /// <summary>
        /// родительский объект данного KIT-а (директива, деталь и т.д.)
        /// </summary>
        public IKitRequired ParentObject 
        {
            get { return _parent; }
            set
            {
                _parent = value;
                if (_parent != null)
                {
                    _smartCoreType = _parent.SmartCoreObjectType;
                    ParentTypeId = _parent.SmartCoreObjectType.ItemId;
                    
                    if(_parent is MaintenanceDirective)
                    {
                        MaintenanceDirective md = _parent as MaintenanceDirective;
                        _check = md.MaintenanceCheck;
                        if (_check != null)
                            _maintenanceCheckType = _check.CheckType;
                    }
                }
                else
                {
                    ParentTypeId = SmartCoreType.Unknown.ItemId;
                    _check = null;
                }
            }
        }
        #endregion

        #region public override string ParentString { get; }
        /// <summary>
        /// Строковое описание родителя
        /// </summary>
        [ListViewData(0.12f, "Task", 7)]
        [Filter("Task:", Order = 5)]
        public override string ParentString
        {
            get { return _parent != null ? _parent.KitParentString : ""; }
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Переводит тип директивы в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return PartNumber + " " + Description;
        }
        #endregion

        #region public int CompareTo(object y)
        public override int CompareTo(object y)
        {
            if(y is AccessoryRequired)return PartNumber.CompareTo(((AccessoryRequired)y).PartNumber);
            return 0;
        }
        #endregion

        #region public AccessoryRequired()
        /// <summary>
        /// Конструктор создает объект с параметрами по умолчанию
        /// </summary>
        public AccessoryRequired()
        {
            ItemId = -1;
            ParentId = -1;
            _remarks = "";
            
            SmartCoreObjectType = SmartCoreType.AccessoryRequired;
        }
        #endregion

        #region public Kit(IKitRequired parent)
        /// <summary>
        /// Конструктор создает объект с привязкой родительского объекта
        /// </summary>
        public AccessoryRequired(IKitRequired parent)
            : this()
        {
            if(parent != null)ParentId = parent.ItemId;
            ParentObject = parent;
        }
        #endregion

        #region public KitRequired(KitRequired toCopy) : this()
        /// <summary>
        /// Конструктор создает объект с привязкой родительского объекта
        /// </summary>
        public AccessoryRequired(AccessoryRequired toCopy)
            : this()
        {
            if (toCopy == null) 
                return;
            _product = toCopy.Product;
            _parent = toCopy.ParentObject;
            ParentId = toCopy.ParentId;
            ParentTypeId = toCopy.ParentTypeId;
            _quantity = toCopy.Quantity;
            _remarks = toCopy.Remarks;
        }
        #endregion

        #region public new AccessoryRequired GetCopyUnsaved()
        /// <summary>
        /// Возвращает полную копию объекта (полностью копирую вложенные элементы и коллекции),
        /// <br/>с ItemId равным -1
        /// </summary>
        /// <returns></returns>
        public new AccessoryRequired GetCopyUnsaved()
        {
            AccessoryRequired accessoryRequired = (AccessoryRequired)MemberwiseClone();
            accessoryRequired.ItemId = -1;
            accessoryRequired.UnSetEvents();

            return accessoryRequired;
        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(AccessoryRequired));
        }
        #endregion

        #region IEqualityComparer<AccessoryRequired>

        #region public bool Equals(AccessoryRequired x, AccessoryRequired y)
        public bool Equals(AccessoryRequired x, AccessoryRequired y)
        {
            //Без переопределения метода GetHashCode(AccessoryRequired) данный метод не работает
            //Почему? - ХЗ

            //Check whether the compared object references the same data.
            if (ReferenceEquals(x, y)) return true;

            //Check whether the compared object is null.
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;

            //Check whether the products' properties are equal.
            return x.Standart == y.Standart && x.PartNumber == y.PartNumber && x.Description == y.Description;
        }
        #endregion

        #region public int GetHashCode(AccessoryRequired other)
        public int GetHashCode(AccessoryRequired other)
        {
            if (ReferenceEquals(other, null) == true)
                return 0;
            int standartHash = Standart != null ? Standart.GetHashCode() : -1.GetHashCode();
            int partNumberHash = PartNumber.GetHashCode();
            int descriptionHash = Description.GetHashCode();

            return standartHash ^ partNumberHash ^ descriptionHash;
        }
        #endregion

        #endregion
    }
}
