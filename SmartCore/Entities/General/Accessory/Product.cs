using System;
using System.Collections.Generic;
using System.Reflection;
using EFCore.DTO.Dictionaries;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Files;
using SmartCore.Purchase;

namespace SmartCore.Entities.General.Accessory
{
    public enum ProductType
    {
        ComponentModel, EquipmentandMaterial
    }

    
    /// <summary>
    /// Описание комплектующего
    /// </summary>
    [Table("AccessoryDescriptions", "Dictionaries", "ItemId")]
	[Dto(typeof(AccessoryDescriptionDTO))]
    [Condition("IsDeleted", "0")]
    [Condition("ModelingObjectTypeId", "-1")]
    [Serializable]
    public class Product : BaseEntityObject, ISupplied, IEquatable<Product>, IFileContainer, IAllProductsFilterParams
    {
	    public Document Document { get; set; }
		public ProductType ProductType { get; set; } 

        private static Type _thisType;

        #region public GoodsClass GoodsClass { get; set; }

        private GoodsClass _goodsClass;
        /// <summary>
        /// Класс
        /// </summary>
        [TableColumn("ComponentClass")]
        [FormControl(250, "Class:", "Standart", "GoodsClass", false,
            TreeDictRootNodes = new[]
            {
				"OfficeEquipment", "MaintenanceMaterials", "ProductionAuxiliaryEquipment", "Tools", "Protection"
			}, Order = 10)]
        [ListViewData(0.15f, "Class")]
        [NotNull]
        [Filter("Class:", Order = 11)]

        public GoodsClass GoodsClass
        {
            get { return _goodsClass; }
            set
            {
                if (_goodsClass != value)
                {
                    _goodsClass = value;
                    OnPropertyChanged("GoodsClass");
                }
            }
        }

		#endregion

		#region public AtaChapter ATAChapter { get; set; }

		[TableColumn("AtaChapter")]
		[ListViewData(0.12f, "ATA")]
		[Filter("ATA:", Order = 12)]
		public AtaChapter ATAChapter { get; set; }

		#endregion

		[TableColumn("DescRus")]
		[ListViewData(0.12f, "Description Rus", 20)]
		[Filter("Description Rus:", Order = 7)]
		public string DescRus { get; set; }

		[TableColumn("HTS")]
		public string HTS { get; set; }

		#region public GoodStandart Standart { get; set; }

		private GoodStandart _standart;
        /// <summary>
        /// Стандарт(ГОСТ)
        /// </summary>
        [TableColumn("Standart"), ListViewData(0.12f, "Standard", 11)]
        [FormControl(200, "Standard:", Order = 3)]
        [Filter("Standard:",Order = 13)]
        [Child(false)]
        public GoodStandart Standart
        {
            get { return _standart; }
            set { _standart = value; }
        }

        #endregion

        #region public String Name { get; set; }

        protected string _name;
        /// <summary>
        /// Название агрегата
        /// </summary>
        [TableColumn("Model"), ListViewData(0.15f, "Name", 1)]
        [FormControl(250, "Name:", "Standart", "Name", true, Order = 1)]
        [Filter("Name:", Order = 4)]
        [NotNull]
        public String Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

		public static PropertyInfo NameProperty
		{
			get { return GetCurrentType().GetProperty("Name"); }
		}
		#endregion

		#region public String PartNumber { get; set; }

		private string _partNumber;
        /// <summary>
        /// Чертёжный номер агрегата
        /// </summary>
        [TableColumn("PartNumber"), ListViewData(0.12f, "Part Number", 13)]
        [FormControl(250, "Part Number:", "Standart", "PartNumber", true, Order = 13)]
        [Filter("Part Number:", Order = 1)]
        public String PartNumber
        {
            get { return _partNumber; }
            set { _partNumber = value; }
        }

		public static PropertyInfo PartNumberProperty
		{
			get { return GetCurrentType().GetProperty("PartNumber"); }
		}
		#endregion

		[TableColumn("AltPartNumber")]
		[ListViewData(0.12f, "Alt Part Number", 14)]
		[Filter("Alt Part Number:", Order = 2)]
		public string AltPartNumber { get; set; }

		

		#region public String SerialNumber { get; set; }

		private string _serialNumber;
        /// <summary>
        /// Серийный номер агреагата
        /// </summary>
        public String SerialNumber
        {
            get { return _serialNumber; } 
            set
            {
                if(_serialNumber != value)
                {
                    _serialNumber = value;
                    OnPropertyChanged("SerialNumber");
                }
            }
        }
        #endregion

        #region public String BatchNumber { get; set; }

        private string _batchNumber;
        /// <summary>
        /// Пакетный номер агреагата
        /// </summary>
        public String BatchNumber
        {
            get { return _batchNumber; } 
            set
            {
                if(_batchNumber != value)
                {
                    _batchNumber = value;
                    OnPropertyChanged("BatchNumber");
                }
            }
        }
        #endregion

        #region public String Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("Code"), ListViewData(0.12f, "Code", 19)]
        [FormControl(200, "Product Code:", Order = 4)]
        public String Code { get; set; }

        #endregion

        #region public String Description { get; set; }

        private string _description;
        /// <summary>
        /// Описание агрегата
        /// </summary>
        [TableColumn("Description"), ListViewData(0.3f, "Description", 16)]
        [FormControl(250, "Description:", 8, "Standart", "Description", true, Order = 19)]
        [Filter("Description:", Order = 3)]
        public String Description
        {
            get { return _standart != null ? _standart.Description : _description; }
            set
            {
                if(_description != value)
                {
	                if (_standart != null)
		                _standart.Description = value;
                    else _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }

		public static PropertyInfo DescriptionProperty
		{
			get { return GetCurrentType().GetProperty("Description"); }
		}

		#endregion

		#region public String Manufacturer { get; set; }

		protected string _manufacturer;
        /// <summary>
        /// Производитель
        /// </summary>
        [TableColumn("Manufacturer"), ListViewData(0.12f, "Manufacturer", 17)]
        [FormControl(250, "Manufacturer", Order = 8)]
        [Filter("Manufacturer:", Order = 5)]
        [NotNull]
        public String Manufacturer
        {
            get { return _manufacturer; }
            set
            {
                if(_manufacturer != value)
                {
                    _manufacturer = value;
                    OnPropertyChanged("Manufacturer");
                }
            }
        }
        #endregion

        #region public Double CostNew { get; set; }

        private double _costNew;
        /// <summary>
        /// Цена новой детали
        /// </summary>
        [TableColumn("CostNew"), MinMaxValue(0, 1000000000), ListViewData(0.08f, "Cost new")]
        //[FormControl(250, "Cost New:", Order = 15)]
        public Double CostNew
        {
            get { return _costNew; } 
            set
            {
                if(_costNew != value)
                {
                    _costNew = value;
                    OnPropertyChanged("CostNew");
                }
            }
        }
        #endregion

        #region public Double CostOverhaul { get; set; }

        private double _costOvehaul;
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("CostOverhaul"), MinMaxValue(0, 1000000000), ListViewData(0.08f, "Cost OH")]
        //[FormControl(250, "Cost OH:", Order = 16)]
        public Double CostOverhaul
        {
            get { return _costOvehaul; } 
            set
            {
                if(_costOvehaul != value)
                {
                    _costOvehaul = value;
                    OnPropertyChanged("CostOverhaul");
                }
            }
        }
        #endregion

        #region public Double CostServiceable { get; set; }

        private double _costServiceable;
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("CostServiceable"), MinMaxValue(0, 1000000000), ListViewData(0.08f, "Cost Serv.")]
        //[FormControl(250, "Cost Serviceable:", Order = 17)]
        public Double CostServiceable
        {
            get { return _costServiceable; } 
            set
            {
                if (_costServiceable != value)
                {
                    _costServiceable = value;
                    OnPropertyChanged("CostServiceable");
                }
            }
        }
        #endregion

        #region public Measure Measure

        private Measure _measure;
        /// <summary>
        /// Единица измерения
        /// </summary>
        [TableColumn("Measure")]
        //[FormControl(250, "Measure:", Order = 18)]
        public Measure Measure
        {
            get { return _measure; }
            set
            {
                if (_measure != value)
                {
                    _measure = value;
                    OnPropertyChanged("Measure");
                }
            }
        }
        #endregion

        #region public String Remarks { get; set; }

        private string _remarks;
        /// <summary>
        /// Дополнительные заметки
        /// </summary>
        [TableColumn("Remarks"), ListViewData(0.25f, "Remarks")]
        [FormControl(250, "Remarks:", 8, Order = 20)]
        public String Remarks
        {
            get { return _remarks; } 
            set { _remarks = value; }
        }
		#endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;
		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1005)]
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

		#region public AttachedFile ImageFile { get; set; }

		[NonSerialized]
		private AttachedFile _imageFile;
		/// <summary>
		/// 
		/// </summary>
		[FormControl(250, "Image:", 8, Order = 26)]
		public AttachedFile ImageFile
		{
			get
			{
				return _imageFile ?? Files.GetFileByFileLinkType(FileLinkType.ComponentImageFile);
			}
			set
			{
				_imageFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.ComponentImageFile);
			}
		}
		#endregion

		[TableColumn("IsEffectivity")]
		[ListViewData(0.12f, "Effectivity")]
		[Filter("Effectivity:", Order = 8)]
		public string IsEffectivity { get; set; }

		#region public bool IsDangerous { get; set; }

		[TableColumn("IsDangerous"), ListViewData(0.12f, "IsDangerous")]
		[FormControl(250, "IsDangerous:", 8, Order = 25)]
		[Filter("IsDangerous:", Order = 9)]
		public bool IsDangerous { get; set; }
		#endregion

		#region public SupplierCollection Suppliers  { get; set; }

		private SupplierCollection _suppliers;
        /// <summary>
        /// Поставщики данной детали
        /// </summary>
        [ListViewData(0.12f, "Suppliers", 18)]
        [Child(typeof(KitSuppliersRelation), "KitId", "ParentTypeId", 1005, "SupplierId")]
        [Filter("Supplier:", Order = 10)]
        public SupplierCollection Suppliers
        {
            get { return _suppliers ?? (_suppliers = new SupplierCollection()); }
            set { _suppliers = value; }
        }
        #endregion

        #region public override CommonCollection<KitSuppliersRelation> SupplierRelations { get; set; }

        private CommonCollection<KitSuppliersRelation> _supplierRelations;
		private List<QuotationCost> _quatationCosts;

		/// <summary>
        /// связи с поставщиками данного KIT-а
        /// </summary>
        [Child(RelationType.OneToMany, "KitId", "ParentTypeId", 1005, "Accessory")]
        [FormControl(500, "Suppliers", 10, new[] { "Supplier", "CostNew", "CostOverhaul", "CostServiceable" }, Order = 27)]
        public CommonCollection<KitSuppliersRelation> SupplierRelations
        {
            get { return _supplierRelations ?? (_supplierRelations = new CommonCollection<KitSuppliersRelation>()); }
            set { _supplierRelations = value; }
        }
        #endregion

        #region public Reference Reference { get; set; }

        [TableColumn("Reference")]
        [ListViewData(0.12f, "Reference", 2)]
        [Filter("Reference:", Order = 6)]
        public string Reference { get; set; }

        #endregion

        #region public AttachedFile AttachedFile { get; set; }

        private AttachedFile _attachedFile;

        public AttachedFile AttachedFile
        {
            get { return _attachedFile ?? (Files.GetFileByFileLinkType(FileLinkType.ProductFile)); }
            set
            {
                _attachedFile = value;
                Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.ProductFile);
            }
        }

        #endregion

        public List<QuotationCost> QuatationCosts
		{
			get { return _quatationCosts ??(_quatationCosts = new List<QuotationCost>()); }
			set { _quatationCosts = value; }
		}

		#region public override string ToString()
		/// <summary>
		/// Переводит тип директивы в строку
		/// </summary>
		/// <returns></returns>
		public override string ToString()
        {
            return (string.IsNullOrEmpty(Name) ? "" : Name + " ") + (Standart == null || string.IsNullOrEmpty(Standart.ToString()) ? "" : Standart + " ") + 
                   (string.IsNullOrEmpty(PartNumber) ? "" : PartNumber + " ") + Description;
        }
        #endregion

        #region public int CompareTo(object y)
        public override int CompareTo(object y)
        {
            if (y is Product) 
                return String.Compare(PartNumber, ((Product)y).PartNumber, StringComparison.Ordinal);
            return 0;
        }
        #endregion

        #region Implement of IEquatable

        #region public bool Equals(Product other)
        public bool Equals(Product other)
        {
            //Без переопределения метода GetHashCode данный метод не работает
            //Почему? - ХЗ

            //Check whether the compared object is null.
            if (ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data.
            if (ReferenceEquals(this, other)) return true;

            if (ItemId > 0 && other.ItemId > 0)
                return ItemId == other.ItemId;
            //Check whether the products' properties are equal.
            return GoodsClass == other.GoodsClass &&
                   Standart == other.Standart &&
                   PartNumber == other.PartNumber &&
                   Description == other.Description;
        }
        #endregion

        #region public override int GetHashCode()
        public override int GetHashCode()
        {
            int detailTypeHash = GoodsClass != null ? GoodsClass.GetHashCode() : -1;
            int standartHash = Standart != null ? Standart.GetHashCode() : -1;
            int partNumberHash = PartNumber.GetHashCode();
            int descriptionHash = Description.GetHashCode();

            return detailTypeHash ^ standartHash ^ partNumberHash ^ descriptionHash;
        }
        #endregion

        #endregion

        #region public Product()
        /// <summary>
        /// Конструктор создает объект с параметрами по умолчанию
        /// </summary>
        public Product()
        {
            ItemId = -1;
            _description = "";
            _partNumber = "";
            _standart = null;
            _remarks = "";
            _manufacturer = "";
            _measure = Measure.Unit;
            
            SmartCoreObjectType = SmartCoreType.Product;
        }
        #endregion

        #region public Product(Product toCopy) : this()
        /// <summary>
        /// Конструктор создает объект с привязкой родительского объекта
        /// </summary>
        public Product(Product toCopy)
            : this()
        {
            if (toCopy == null) 
                return;
            _batchNumber = toCopy.BatchNumber;
            _costNew = toCopy.CostNew;
            _costOvehaul = toCopy.CostOverhaul;
            _costServiceable = toCopy.CostServiceable;
            _description = toCopy.Description;
            _manufacturer = toCopy.Manufacturer;
            _measure = toCopy.Measure;
            _partNumber = toCopy.PartNumber;
            _remarks = toCopy.Remarks;
            _serialNumber = toCopy.SerialNumber;
            _standart = toCopy.Standart;


            if (_suppliers == null)
                _suppliers = new SupplierCollection();
            _suppliers.Clear();
            foreach (Supplier supplier in toCopy.Suppliers)
            {
                _suppliers.Add(supplier);
            }

            if (_supplierRelations == null)
                _supplierRelations = new CommonCollection<KitSuppliersRelation>();
            _supplierRelations.Clear();
            foreach (KitSuppliersRelation ksr in toCopy.SupplierRelations)
            {
                _supplierRelations.Add(new KitSuppliersRelation(ksr) {KitId = ItemId});
            }
        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(Product));
        }
        #endregion

        #region public override BaseEntityObject GetCopyUnsaved

        public new Product GetCopyUnsaved()
        {
            Product product = (Product) MemberwiseClone();
            product.ItemId = -1;
            product.Name += " Copy";
            product.UnSetEvents();

            product.SupplierRelations = new CommonCollection<KitSuppliersRelation>();
            foreach (KitSuppliersRelation kitSuppliers in SupplierRelations)
            {
                KitSuppliersRelation newObject = kitSuppliers.GetCopyUnsaved();
                product.SupplierRelations.Add(newObject);
            }

            return product;
        }

        #endregion

    }
}
