using System;
using System.Reflection;
using EntityCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Purchase;

namespace SmartCore.Entities.General.Accessory
{
    /// <summary>
    /// Класс для связи определенного комплектующего с поставщиком
    /// </summary>
    [Table("KitSuppliers", "dbo", "ItemId")]
    [Dto(typeof(KitSuppliersRelationDTO))]
	[Condition("IsDeleted", "0")]
    [Serializable]
    public class KitSuppliersRelation : BaseEntityObject
    {
        private BaseEntityObject _abstractAccessory;

        private static Type _thisType;

		#region public Int32 KitId { get; set; }
		/// <summary>
		/// ID Kit-а
		/// </summary>
        [TableColumnAttribute("KitId")]
		public Int32 KitId { get; set; }

        public static PropertyInfo KitIdProperty
        {
            get { return GetCurrentType().GetProperty("KitId"); }
        }

		#endregion

        #region public Int32 ParentType { get; set; }
        /// <summary>
        /// Тип родителя
        /// </summary>
        [TableColumnAttribute("ParentTypeId")]
        public int ParentTypeId { get; set; }

        public static PropertyInfo ParentTypeIdProperty
        {
            get { return GetCurrentType().GetProperty("ParentTypeId"); }
        }

        #endregion

        #region Int32 SupplierId { get; set; }
        /// <summary>
        /// ID поставщика
        /// </summary>
        public Int32 SupplierId
        {
            get { return Supplier != null ? Supplier.ItemId : -1; }
        }

	    public Int32 SupplierID { get; set; }

		#endregion

		#region public Supplier Supplier { get; set; }
		/// <summary>
		/// ID поставщика
		/// </summary>
		[TableColumnAttribute("SupplierId")]
        [ListViewData(370, "Supplier", 1)]
        [Child(false)]
        [NotNull]
        public Supplier Supplier { get; set; }

        public static PropertyInfo SupplierProperty
        {
            get { return GetCurrentType().GetProperty("Supplier"); }
        }

        #endregion

        #region public override Double CostNew { get; set; }

        private double _costNew;
        /// <summary>
        /// Цена новой детали
        /// </summary>
        [TableColumn("CostNew")]
        [MinMaxValueAttribute(0, 1000000000), ListViewData(100, "Cost new", 18)]
        public Double CostNew
        {
            get { return _costNew; }
            set
            {
                if (Math.Abs(_costNew - value) > 0.0)
                {
                    _costNew = value;
                    OnPropertyChanged("CostNew");
                }
            }
        }

        public static PropertyInfo CostNewProperty
        {
            get { return GetCurrentType().GetProperty("CostNew"); }
        }

        #endregion

        #region public override Double CostOverhaul { get; set; }

        private double _costOvehaul;
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("CostOverhaul")]
        [MinMaxValueAttribute(0, 1000000000), ListViewData(100, "Cost OH", 19)]
        public Double CostOverhaul
        {
            get { return _costOvehaul; }
            set
            {
                if (Math.Abs(_costOvehaul - value) > 0.0)
                {
                    _costOvehaul = value;
                    OnPropertyChanged("CostOverhaul");
                }
            }
        }

        public static PropertyInfo CostOverhaulProperty
        {
            get { return GetCurrentType().GetProperty("CostOverhaul"); }
        }
        #endregion

        #region public override Double CostServiceable { get; set; }

        private double _costServiceable;
        /// <summary>
        /// Стоимость после обслуживания
        /// </summary>
        [TableColumn("CostServiceable")]
        [MinMaxValueAttribute(0, 1000000000), ListViewData(100, "Cost Serv.", 20)]
        public Double CostServiceable
        {
            get { return _costServiceable; }
            set
            {
                if (Math.Abs(_costServiceable - value) > 0.0)
                {
                    _costServiceable = value;
                    OnPropertyChanged("CostOverhaul");
                }
            }
        }

        public static PropertyInfo CostServiceableProperty
        {
            get { return GetCurrentType().GetProperty("CostServiceable"); }
        }
        #endregion

        #region public BaseEntityObject Accessory
        public BaseEntityObject Accessory 
        { 
            get { return _abstractAccessory; } 
            set { _abstractAccessory = value; } 
        }
		#endregion

		#region public string ComponentClassTypeString { get; set; }

		[ListViewData(0.15f, "Class", 17, true)]
        public string ComponentClassTypeString
        {
            get
            {
                if (_abstractAccessory == null)
                    return "";
                if (_abstractAccessory is AbstractAccessory)
                {
                    AbstractAccessory aa = _abstractAccessory as AbstractAccessory;
                    return aa.GoodsClass.ToString();
                }
                if (_abstractAccessory is Product)
                {
                    Product aa = _abstractAccessory as Product;
                    return aa.GoodsClass.ToString();
                }
                return "";
            }
        }

        public static PropertyInfo ComponentClassTypeStringProperty
        {
            get { return GetCurrentType().GetProperty("ComponentClassTypeString"); }
        }
        #endregion

        #region public GoodStandart Standart { get; set; }
        /// <summary>
        /// Стандарт(ГОСТ)
        /// </summary>
        [ListViewData(0.12f, "Standart", 11, true)]
        [Filter("Standart:")]
        public GoodStandart Standart
        {
            get
            {
                if (_abstractAccessory == null)
                    return null;
                if (_abstractAccessory is AbstractAccessory)
                {
                    AbstractAccessory aa = _abstractAccessory as AbstractAccessory;
                    return aa.Standart;
                }
                if (_abstractAccessory is Product)
                {
                    Product aa = _abstractAccessory as Product;
                    return aa.Standart;
                }
                return null;
            }
        }

        public static PropertyInfo StandartProperty
        {
            get { return GetCurrentType().GetProperty("Standart"); }
        }

        #endregion

        #region public String PartNumber { get; set; }
        /// <summary>
        /// Чертёжный номер агрегата
        /// </summary>
        [ListViewData(0.12f, "Part Number",12, true)]
        [Filter("Part Number:")]
        public String PartNumber
        {
            get
            {
                if (_abstractAccessory == null)
                    return "";
                if (_abstractAccessory is AbstractAccessory)
                {
                    AbstractAccessory aa = _abstractAccessory as AbstractAccessory;
                    return aa.PartNumber;
                }
                if (_abstractAccessory is Product)
                {
                    Product aa = _abstractAccessory as Product;
                    return aa.PartNumber;
                }

                return "";
            }
        }

        public static PropertyInfo PartNumberProperty
        {
            get { return GetCurrentType().GetProperty("PartNumber"); }
        }
        #endregion

        #region public String SerialNumber { get; set; }

        /// <summary>
        /// Серийный номер агреагата
        /// </summary>
        public String SerialNumber
        {
            get
            {
                if (_abstractAccessory == null)
                    return "";
                if (_abstractAccessory is AbstractAccessory)
                {
                    AbstractAccessory aa = _abstractAccessory as AbstractAccessory;
                    return aa.SerialNumber;
                }
                if (_abstractAccessory is Product)
                {
                    Product aa = _abstractAccessory as Product;
                    return aa.SerialNumber;
                }
                return "";
            }
        }
        #endregion

        #region public String BatchNumber { get; set; }
        /// <summary>
        /// Пакетный номер агреагата
        /// </summary>
        public String BatchNumber
        {
            get
            {
                if (_abstractAccessory == null)
                    return "";
                if (_abstractAccessory is AbstractAccessory)
                {
                    AbstractAccessory aa = _abstractAccessory as AbstractAccessory;
                    return aa.BatchNumber;
                }
                if (_abstractAccessory is Product)
                {
                    Product aa = _abstractAccessory as Product;
                    return aa.BatchNumber;
                }
                return "";
            }
        }
        #endregion

        #region public String Description { get; set; }
        /// <summary>
        /// Описание агрегата
        /// </summary>
        [ListViewData(0.12f, "Description", 13, true)]
        public String Description
        {
            get
            {
                if (_abstractAccessory == null)
                    return "";
                if (_abstractAccessory is AbstractAccessory)
                {
                    AbstractAccessory aa = _abstractAccessory as AbstractAccessory;
                    return aa.Description;
                }
                if (_abstractAccessory is Product)
                {
                    Product aa = _abstractAccessory as Product;
                    return aa.Description;
                }
                return "";
            }
        }

        public static PropertyInfo DescriptionProperty
        {
            get { return GetCurrentType().GetProperty("Description"); }
        }
        #endregion

        #region public String Manufacturer { get; set; }
        /// <summary>
        /// Производитель
        /// </summary>
        [ListViewData(0.12f, "Manufacturer", 15, true)]
        [Filter("Manufacturer:")]
        public String Manufacturer
        {
            get
            {
                if (_abstractAccessory == null)
                    return "";
                if (_abstractAccessory is AbstractAccessory)
                {
                    AbstractAccessory aa = _abstractAccessory as AbstractAccessory;
                    return aa.Manufacturer;
                }
                if (_abstractAccessory is Product)
                {
                    Product aa = _abstractAccessory as Product;
                    return aa.Manufacturer;
                }
                return "";
            }
        }

        public static PropertyInfo ManufacturerProperty
        {
            get { return GetCurrentType().GetProperty("Manufacturer"); }
        }
        #endregion

        #region public Measure Measure
        /// <summary>
        /// Единица измерения
        /// </summary>
        public Measure Measure
        {
            get
            {
                if (_abstractAccessory == null)
                    return Measure.Unknown;
                if (_abstractAccessory is AbstractAccessory)
                {
                    AbstractAccessory aa = _abstractAccessory as AbstractAccessory;
                    return aa.Measure;
                }
                if (_abstractAccessory is Product)
                {
                    Product aa = _abstractAccessory as Product;
                    return aa.Measure;
                }
                return Measure.Unknown;
            }
        }
        #endregion

        #region public string SupplierRelations { get; set; }
        /// <summary>
        /// связи с поставщиками данного KIT-а
        /// </summary>
        [ListViewData(0.12f, "Suppliers", 16, true)]
        public string SupplierRelations
        {
            get
            {
                if (_abstractAccessory == null)
                    return "";
                if (_abstractAccessory is AbstractAccessory)
                {
                    AbstractAccessory aa = _abstractAccessory as AbstractAccessory;
                    return aa.Suppliers.ToString();
                }
                if (_abstractAccessory is Product)
                {
                    Product aa = _abstractAccessory as Product;
                    return aa.Suppliers.ToString();
                }
                return "";
            }
        }

        public static PropertyInfo SupplierRelationsProperty
        {
            get { return GetCurrentType().GetProperty("SupplierRelations"); }
        }
        #endregion

        #region public String Remarks { get; set; }
        /// <summary>
        /// Дополнительные заметки
        /// </summary>
        [ListViewData(0.25f, "Remarks", true)]
        public String Remarks
        {
            get
            {
                if (_abstractAccessory == null)
                    return "";
                if (_abstractAccessory is AbstractAccessory)
                {
                    AbstractAccessory aa = _abstractAccessory as AbstractAccessory;
                    return aa.Remarks;
                }
                if (_abstractAccessory is Product)
                {
                    Product aa = _abstractAccessory as Product;
                    return aa.Remarks;
                }
                return "";
            }
        }

        public static PropertyInfo RemarksProperty
        {
            get { return GetCurrentType().GetProperty("Remarks"); }
        }
        #endregion
       /*
		*  Методы 
		*/
		
		#region public KitSuppliersRelation()
        /// <summary>
        /// Создает связь без параметров
        /// </summary>
        public KitSuppliersRelation()
        {
            ItemId = -1;
            KitId = -1;
            SmartCoreObjectType = SmartCoreType.KitSuppliersRelation;
        }
        #endregion

        #region public KitSuppliersRelation(int kitId):this()
        /// <summary>
        /// Создает воздушное судно без дополнительной информации
        /// </summary>
        public KitSuppliersRelation(ISupplied accessory)
            : this()
        {
            if(accessory == null)
                throw new ArgumentNullException("accessory","must be not null");
            
            KitId = accessory.ItemId;
            ParentTypeId = accessory.SmartCoreObjectType.ItemId;
        }
        #endregion

        #region public KitSuppliersRelation(KitSuppliersRelation toCopy):this()
        /// <summary>
        /// Создает воздушное судно без дополнительной информации
        /// </summary>
        public KitSuppliersRelation(KitSuppliersRelation toCopy)
            : this()
        {
            if (toCopy == null)return;

            KitId = toCopy.ItemId;
            ParentTypeId = toCopy.SmartCoreObjectType.ItemId;
            Supplier = toCopy.Supplier;
        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(KitSuppliersRelation));
        }
        #endregion

        public new KitSuppliersRelation GetCopyUnsaved()
        {
            KitSuppliersRelation kitSuppliers = (KitSuppliersRelation)MemberwiseClone();
            kitSuppliers.ItemId = -1;
            kitSuppliers.UnSetEvents();

            return kitSuppliers;
        }
    }
}
