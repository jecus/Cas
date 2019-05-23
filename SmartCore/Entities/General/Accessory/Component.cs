using System;
using System.Collections.Generic;
using System.Reflection;
using EFCore.DTO.General;
using SmartCore.Auxiliary;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.Personnel;
using SmartCore.Entities.General.Store;
using SmartCore.Entities.General.Templates;
using SmartCore.Files;
using SmartCore.Purchase;

namespace SmartCore.Entities.General.Accessory
{
    /// <summary>
    /// Класс описывает компонент
    /// </summary>
    [Serializable]
    [Table("Components", "dbo", "ItemId")]
    [Dto(typeof(ComponentDTO))]
	[Condition("IsBaseComponent", "0")]
    [Condition("IsDeleted", "0")]
    public class Component : AbstractAccessory, IEngineeringDirective, IKitRequired, IStoreFilterParam, IComponentFilterParams, IComparable<Component>, IEquatable<Component>, IFileContainer, IWorkPackageItemFilterParams, IProcessingFilterParams, IComparer<Component>, IAtaSorted
	{
        private static Type _thisType;

        protected DateTime manufactureDate;
        
        private double _costNew;
		
        /*
		*  Свойства
		*/

        #region Implement IAccessory

        #region public override Product Product { get; set; }

        private Product _product;
        /// <summary>
        /// Описание агрегата
        /// </summary>
        //[TableColumn("AccessoryDescriptionId")]
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

        #region public override GoodsClass GoodsClass { get; set; }

        private GoodsClass _goodsClass;
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("Type")]
        [FormControl(250, "Class:", 
                     TreeDictRootNodes = new[]
                     {
                        "ComponentsAndParts", "ProductionAuxiliaryEquipment","OfficeEquipment", "MaintenanceMaterials", "ProductionAuxiliaryEquipment", "Tools", "Protection"
					 })]
        public override GoodsClass GoodsClass
        {
            get { return _product != null ? _product.GoodsClass : _goodsClass ?? (_goodsClass = GoodsClass.Unknown); }
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

        #region public override GoodStandart Standart { get; set; }

        private GoodStandart _standart;
        /// <summary>
        /// Чертёжный номер агрегата
        /// </summary>
        [ListViewData(0.1f, "Standart", 1)]
        [Filter("Standart:", Order = 1)]
        //[TableColumn("GoodStandartId")]
        //[Child(false)]
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

        private string _partNumber;
		/// <summary>
        /// Чертёжный номер агрегата
        /// </summary>
        [TableColumn("PartNumber")]
        [Filter("Part. Number:", Order = 1)]
        public override String PartNumber
        {
            get { return _partNumber; } 
            set { _partNumber = value; }
        }
        #endregion

        #region public override String SerialNumber { get; set; }

        private string _serialNumber;
        /// <summary>
        /// Серийный номер агреагата
        /// </summary>
        [TableColumn("SerialNumber")]
        [Filter("Serial Number:", Order = 2)]
        public override String SerialNumber
        {
            get { return _serialNumber; }
            set { _serialNumber = value; }
        }
        #endregion

        #region public override String BatchNumber { get; set; }

        private string _batchNumber;
        /// <summary>
        /// Пакетный номер
        /// </summary>
        [TableColumn("BatchNumber")]
        public override String BatchNumber
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

        #region public override String Description { get; set; }

        private string _description;
        /// <summary>
        /// Описание агрегата
        /// </summary>
        [TableColumn("Description")]
        [Filter("Description:", Order = 3)]
        public override String Description
        {
            get { return _description; }
            set { _description = value; }
        }
        #endregion

        #region public override String Manufacturer { get; set; }

        private string _manufacturer;
        /// <summary>
        /// Производитель
        /// </summary>
        [TableColumn("Manufacturer")]
        [Filter("Manufacturer:", Order = 4)]
        public override String Manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value; }
        }
        #endregion

        #region public override String Remarks { get; set; }

        private string _remarks;
        /// <summary>
        /// Дополнительные заметки
        /// </summary>
        [TableColumn("Remarks")]
        public override String Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }
		#endregion

		#region public NDTType NDTType { get; set; }

		/// <summary>
		/// Тип производимого Non-Destructive-Test
		/// </summary>
		public  NDTType NDTType { get; set; }
		#endregion

		#region public override Double CostNew { get; set; }
		/// <summary>
		/// Цена новой детали
		/// </summary>
		[TableColumn("Cost"), MinMaxValueAttribute(0, 1000000000)]
        public override Double CostNew { get; set; }
        #endregion

        #region public override Double CostOverhaul { get; set; }

        private double _costOverhaul;
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("CostOverhaul"), MinMaxValueAttribute(0, 1000000000)]
        public override Double CostOverhaul
        {
            get { return _costOverhaul; }
            set { _costOverhaul = value; }
        }
        #endregion

        #region public override Double CostServiceable { get; set; }

        private double _costServiceable;
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("CostServiceable"), MinMaxValueAttribute(0, 1000000000)]
        public override Double CostServiceable
        {
            get { return _costServiceable; }
            set { _costServiceable = value; }
        }
        #endregion

        #region public override double Quantity { get; set; }

        private double _quantity;
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("Quantity"), MinMaxValueAttribute(0, 1000000000)]
        public override double Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        #endregion

        #region public override Measure Measure

        private Measure _measure;
        /// <summary>
        /// Единица измерения
        /// </summary>
        [TableColumn("Measure")]
        public override Measure Measure
        {
            get { return _measure; }
            set
            {
                if(_measure != value)
                {
                    _measure = value;
                    OnPropertyChanged("Measure");
                }
            }
        }
        #endregion

        #region public override string ParentString { get; }
        /// <summary>
        /// Строковое описание родителя
        /// </summary>
        public override string ParentString
        {
            get { return ""; }
        }
        #endregion

        #region public override SupplierCollection Suppliers  { get; set; }

        private SupplierCollection _suppliers;
        /// <summary>
        /// Поставщики данной детали
        /// </summary>
        [Child(typeof(KitSuppliersRelation), "KitId", "ParentTypeId", new[]{5,6}, "SupplierId")]
        [Filter("Suppliers:")]
        public override SupplierCollection Suppliers
        {
            get { return _suppliers ?? (_suppliers = new SupplierCollection()); }
            set
            {
                if (_suppliers != value)
                {
                    if (_suppliers != null)
                        _suppliers.Clear();
                    if (value != null)
                        _suppliers = value;
                    OnPropertyChanged("Suppliers");
                }
            }
        }
        #endregion

        #region public override CommonCollection<KitSuppliersRelation> SupplierRelations { get; set; }

        private CommonCollection<KitSuppliersRelation> _supplierRelations;
        /// <summary>
        /// связи с поставщиками данного KIT-а
        /// </summary>
        [Child(RelationType.OneToMany, "KitId", "ParentTypeId", new[] { 5, 6 }, "Accessory")]
        public override CommonCollection<KitSuppliersRelation> SupplierRelations
        {
            get { return _supplierRelations ?? (_supplierRelations = new CommonCollection<KitSuppliersRelation>()); }
            set { _supplierRelations = value; }
        }
		#endregion

		#region public CommonCollection<ProductCost> ProductCosts { get; set; }

		private CommonCollection<ProductCost> _productCosts;

		public CommonCollection<ProductCost> ProductCosts
		{
			get { return _productCosts ?? (_productCosts = new CommonCollection<ProductCost>()); }
			set { _productCosts = value; }
		}

		#endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 5)]
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

		#endregion

		#region public bool IsPOOL { get; set; }

		[TableColumn("IsPool")]
		public bool IsPOOL { get; set; }
		#endregion

		#region public bool IsDangerous { get; set; }

		[TableColumn("IsDangerous")]
		public bool IsDangerous { get; set; }
			#endregion

		#region public double QuantityIn { get; set; }

		[TableColumn("QuantityInput"), MinMaxValue(0, 1000000000)]
		public double QuantityIn { get; set; }

		#endregion

		#region public bool Incoming { get; set; }

		[TableColumn("Incoming")]
		public bool Incoming { get; set; }
		#endregion

		#region public string Discrepancy { get; set; }

		[TableColumn("Discrepancy")]
		public string Discrepancy { get; set; }
		#endregion

		#region public String IdNumber { get; set; }
		/// <summary>
		/// Идентификационный (инвентарный) номер
		/// </summary>
		[TableColumn("IdNumber")]
        public String IdNumber { get; set; }
        #endregion

        #region public String Code { get; set; }
        /// <summary>
        /// Код продукта
        /// </summary>
        [TableColumn("Code")]
        public String Code { get; set; }
        #endregion

        #region public AtaChapter ATAChapter { get; set; }
        /// <summary>
		/// Внешний ключ на идентификатор записи со справочной информацией
		/// </summary>
		[TableColumn("AtaChapter")]
        [Filter("Ata Chapter:", Order = 5)]
        public AtaChapter ATAChapter { get; set; }
		#endregion

		#region public MaintenanceControlProcess MaintenanceControlProcess { get; set; }
		/// <summary>
		/// Идентификатор записи с типом технического обслуживания
		/// </summary>
		[TableColumn("MaintenanceType")]
        [Filter("Maint. Proc.:", Order = 6)]
        public MaintenanceControlProcess MaintenanceControlProcess { get; set; }
		#endregion

		#region public ComponentModel Model { get; set; }

		private ComponentModel _componentModel;
        /// <summary>
        /// Модель агрегата
        /// </summary>
        [TableColumn("Model")]
        [Child(true)]
        public ComponentModel Model
        {
            get 
            {
                return _componentModel ?? (_componentModel = Product != null 
                    ? ComponentModel.GetInstanceFromProduct(Product)
                    : null); 
            }
            set
            {
                _componentModel = value;
                _product = value;
            }
        }
		#endregion

		#region public DateTime ManufactureDate { get; set; }
        /// <summary>
        /// Дата выпуска
        /// </summary>
        [TableColumn("ManufactureDate")]
        public DateTime ManufactureDate
        {
            get { return manufactureDate; }
            set { manufactureDate = value; }
        }
		#endregion

        #region public DateTime DeliveryDate { get; set; }
        /// <summary>
        /// Дата доставки
        /// </summary>
        [TableColumn("DeliveryDate")]
        public DateTime DeliveryDate { get; set; }
        #endregion

		#region internal Lifelength Lifelength { get; set; }
		/// <summary>
		/// Наработка агрегата (осталась еще от Proxy типов старой системы
		/// </summary>
        [TableColumn("Lifelength")]
        internal Lifelength Lifelength { get; set; }
		#endregion

		#region public Boolean IsBaseComponent { get; set; }
		/// <summary>
		/// Флаг, показывающий, является ли агрегат базовым
		/// </summary>
		[TableColumn("IsBaseComponent")]
        public bool IsBaseComponent { get; set; }

        public static PropertyInfo IsBaseComponentProperty
        {
            get { return GetCurrentType().GetProperty("IsBaseComponent"); }
        }

		#endregion

		#region public Boolean LLPMark { get; set; }
		/// <summary>
		/// Отметка LLP
		/// </summary>
        [TableColumn("LLPMark")]
        public Boolean LLPMark { get; set; }

        public static PropertyInfo LLPMarkProperty
        {
            get { return GetCurrentType().GetProperty("LLPMark"); }
        }

		#endregion

        #region public Boolean LLPCategories { get; set; }
        /// <summary>
        /// Отметка о том, что наработка по LLP ведется согласно LLP категориям
        /// </summary>
        [TableColumn("LLPCategories")]
        public Boolean LLPCategories { get; set; }
        #endregion

        #region public LandingGearMarkType LandingGear { get; set; }
        /// <summary>
		/// Отметка Landing Gear
		/// </summary>
        [TableColumn("LandingGear")]
        public LandingGearMarkType LandingGear { get; set; }
		#endregion

        #region public AvionicsInventoryMarkType AvionicsInventory { get; set; }
        /// <summary>
		/// Отметка Avionics Inventory
		/// </summary>
        [TableColumn("AvionicsInventory")]
        public AvionicsInventoryMarkType AvionicsInventory { get; set; }

        public static PropertyInfo AvionicsInventoryProperty
        {
            get { return GetCurrentType().GetProperty("AvionicsInventory"); }
        }

		#endregion

        #region public String ALTPartNumber { get; set; }
        /// <summary>
		/// Alternative part number
		/// </summary>
        [TableColumn("ALTPN")]
        public String ALTPartNumber { get; set; }
		#endregion

		#region public String MTOGW { get; set; }
		/// <summary>
		/// Максимальный взлетный вес
		/// </summary>
        [TableColumn("MTOGW")]
        public String MTOGW { get; set; }
		#endregion

		#region public String HushKit { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumn("HushKit")]
        public String HushKit { get; set; }
        #endregion

        #region public AttachedFile FaaFormFile { get; set; }
        [NonSerialized]
        private AttachedFile _faaFormFile;
        /// <summary>
        /// 
        /// </summary>
        public AttachedFile FaaFormFile
        {
			get
			{
				return _faaFormFile ?? (Files.GetFileByFileLinkType(FileLinkType.FaaFormFile));
			}
			set
			{
				_faaFormFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.FaaFormFile);
			}
		}

		#endregion

		#region public AttachedFile IncomingFile { get; set; }

		[NonSerialized]
		private AttachedFile _incomingFile;
		/// <summary>
		/// 
		/// </summary>
		public AttachedFile IncomingFile
		{
			get
			{
				return _incomingFile ?? Files.GetFileByFileLinkType(FileLinkType.IncomingFile);
			}
			set
			{
				_incomingFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.IncomingFile);
			}
		}
		#endregion

		#region public Lifelength Warranty { get; set; }
		/// <summary>
		/// Гарантийный срок на деталь 
		/// </summary>
		[TableColumn("Warranty")]
        public Lifelength Warranty
        {
            get { return _threshold.Warranty; }
            set { _threshold.Warranty = value; }
        }
		#endregion

        #region public Lifelength WarrantyNotify { get; set; }
        /// <summary>
        /// Предупреждение об истечении гарантии
        /// </summary>
        [TableColumn("WarrantyNotify")]
        public Lifelength WarrantyNotify
        {
            get { return _threshold.WarrantyNotification; }
            set { _threshold.WarrantyNotification = value; }
        }
        #endregion

		#region public Boolean Serviceable { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumn("Serviceable")]
        public Boolean Serviceable { get; set; }
		#endregion

        /*#region public DetailType Type { get; set; }
        /// <summary>
		/// 
		/// </summary>
		public DetailType Type { get; set; }
		#endregion*/

		#region public String ShelfLife { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumn("ShelfLife")]
        public String ShelfLife { get; set; }
		#endregion

		#region public DateTime? ExpirationDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumn("ExpirationDate")]
        public DateTime? ExpirationDate { get; set; }
		#endregion

		#region public DateTime? NotificationDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumn("NotificationDate")]
        public DateTime? NotificationDate { get; set; }
		#endregion

		#region public String Location { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[TableColumn("LocationId")]
		[Child(true)]
		public Locations Location
		{
			get { return _location ?? Locations.Unknown; }
			set { _location = value; }
		}
		#endregion

        #region public Highlight Highlight { get; set; }
        /// <summary>
        /// Подсветка
        /// </summary>
        [TableColumn("Highlight")]
        public Highlight Highlight { get; set; }

        #endregion

		#region public String MPDItem { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumn("MPDItem")]
        public String MPDItem { get; set; }
		#endregion

        #region public String Position { get; }
        /// <summary>
        /// 
        /// </summary>
        public String Position 
        {
            get { return TransferRecords.GetLast() != null ? TransferRecords.GetLast().Position : ""; }
        }
		#endregion

		#region public ComponentStorePosition ComponentStoreStatus

		public ComponentStorePosition State
		{
			get { return TransferRecords.GetLast() != null ? TransferRecords.GetLast().State : ComponentStorePosition.UNK; }
		}
			#endregion

		#region public String HiddenRemarks { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("HiddenRemarks")]
        public String HiddenRemarks { get; set; }
		#endregion

        #region public Lifelength LifeLimit { get; set; }
        /// <summary>
        /// Ограничение срока эксплуатации агрегата
        /// </summary>
        [TableColumn("LifeLimit")]
        public Lifelength LifeLimit
        {
            get { return _threshold.FirstPerformanceSinceNew; }
            set { _threshold.FirstPerformanceSinceNew = value; }
        }
		#endregion

		#region public Lifelength LifeLimitNotify { get; set; }
        /// <summary>
        /// Уведомление до ограничения срока эксплуатации агрегата
        /// </summary>
        [TableColumn("LifeLimitNotify")]
        public Lifelength LifeLimitNotify
        {
            get { return _threshold.FirstNotification; }
            set { _threshold.FirstNotification = value; }
        }
		#endregion

		#region  public ComponentLLPDataCollection LLPData { get; set; }

		private ComponentLLPDataCollection _componentLLPDataCollection;
        /// <summary>
        /// Данные о наработке и ресурсе агрегата по LLP категориям
        /// </summary>
        [Child(RelationType.OneToMany, "ComponentId")]
        public ComponentLLPDataCollection LLPData
        {
            get { return _componentLLPDataCollection ?? (_componentLLPDataCollection = new ComponentLLPDataCollection()); }
            set
            {
                if (_componentLLPDataCollection != value)
                {
                    if (_componentLLPDataCollection != null)
                        _componentLLPDataCollection.Clear();
                    if (value != null)
                        _componentLLPDataCollection = value;

                    OnPropertyChanged("LLPData");
                }
            }
        }
        #endregion

		#region public String KitRequired { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumn("KitRequired")]
        public String KitRequired { get; set; }
		#endregion

		#region public int ParentAircraftId
		/// <summary>
		/// Воздушное судно, где установлен агрегат - см. также ParentStore - одно из двух свойств ParentAircraft либо ParentStore == null
		/// </summary>

		public int ParentAircraftId { get; set; }

		#endregion

		#region public int ParentSupplierId { get; set; }

		public int ParentSupplierId { get; set; }

		#endregion

		#region public int ParentSpecialistId { get; set; }

		public int ParentSpecialistId { get; set; }

		#endregion

		#region public int ParentStoreId { get; }

		/// <summary>
		/// Склад, где находится агрегат - см. также ParentAircraft - одно из двух свойств ParentAircraft либо ParentStore == null
		/// </summary>
		public int ParentStoreId { get; set; }

	    #endregion

		#region public Operator ParentOperator { get; set; }
		/// <summary>
		/// Оператор, которому пренадлежит агрегат - см. также ParentAircraft и ParentStore - одно из свойств ParentAircraft либо ParentStore либо ParentOperator != null
		/// </summary>
		public Operator ParentOperator { get; set; }
		#endregion

		#region public BaseComponent ParentBaseComponent { get; set; }

		[NonSerialized]
        private BaseComponent _parentBaseComponent;
        /// <summary>
        /// Получает базовый агрегат, на котором установлен агрегат
        /// </summary>
        [Filter("Base Detail:", Order = 7)]//TODO:(Evgenii Babak) Переименовать Detail в Component 
		public BaseComponent ParentBaseComponent
        {
            get { return _parentBaseComponent; }
            set { _parentBaseComponent = value; }
        }
        #endregion

        #region public Lifelength StartLifelength { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("StartLifelength")]
        public Lifelength StartLifelength { get; set; }
        #endregion

        #region public DateTime StartDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [TableColumn("StartDate")]
        public DateTime StartDate { get; set; }
		#endregion

		#region  public ComponentThreshold Threshold

		private ComponentThreshold _threshold;
        /// <summary>
        /// порог первого и посделующего выполнений
        /// </summary>
        public ComponentThreshold Threshold
        {
            get { return _threshold ?? (_threshold = new ComponentThreshold()); }
            set { _threshold = value; }
        }
        #endregion

        #region public double Current { get; set; }
        /// <summary>
        /// Текущее кол-во комплектующего на складе
        /// </summary>
        [ListViewData(0.05f, "Current")]
        public double Current { get; set; }
        #endregion

        #region public double Amount { get; set; }
        /// <summary>
        /// Минимальное кол-во комплектующего на скаде
        /// </summary>
        [ListViewData(0.05f, "Should be on stock")]
        public double ShouldBeOnStock { get; set; }
		#endregion

		#region public int Received { get; set; }

		[TableColumn("Received")]
		public int ReceivedId { get; set; }

		public Specialist Received
		{
			get => _received ?? (_received = Specialist.Unknown);
			set => _received = value;
		}

		#endregion

		#region public string Packing { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Packing"), MinMaxValue(0, 10000)]
		public string Packing { get; set; }
		#endregion

		public string Reference => Product?.Reference;
		public string IsEffectivity => Product?.IsEffectivity;


		//TODO:временное свойство(какое кол-во продукта нужно из раб пакета)
		public double NeedWpQuantity { get; set; }

		#region Implement of IWorkPackageItemFilterParams

		#region public SmartCoreType SmartCoreType { get; }

		public SmartCoreType SmartCoreType => SmartCoreObjectType;

		#endregion

		#region public Lifelength RepeatInterval { get; }

		public Lifelength RepeatInterval { get { return Lifelength.Null; } }

		#endregion

		#region public bool HasKits { get; }

		public bool HasKits { get { return Kits.Count > 0; } }

		#endregion

		#region public bool HasNDT { get; }

		public bool HasNDT { get { return NDTType != NDTType.UNK; } }

		#endregion

		#endregion

		#region Implement of IStoreFilterParam

		AtaChapter IStoreFilterParam.ATAChapter
		{
			get
			{
				if (Product != null)
					return Product.ATAChapter;
				return ATAChapter;
			}
		}

		public LocationsType Facility { get { return Location.LocationsType; } }
		#endregion

		/*
         * 
         */
		public ManufactureRegion ManufactureRegion
        {
            get
            {
                if (Model == null || Model.ManufactureReg == null)
                    return ManufactureRegion.Unknown;
                return Model.ManufactureReg;
            }
        }

		/*
		*  Методы 
		*/

		#region public Component()
		/// <summary>
		/// Создает компонент без дополнительной информации
		/// </summary>
		public Component()
        {
            SmartCoreObjectType = SmartCoreType.Component;
            // Отрицательный индекс свидетельствует о том, что агрегат не сохранен в базе данных
            ItemId = -1;
            
            // Ata Chapter = 21 (Not Applicable)
            ATAChapter = new AtaChapter {ItemId = 21};

            IsBaseComponent = false;
            _componentStatus = ComponentStatus.New;
            // Все ресурсы должны быть заполнеными - иначе исключение при сохранении в базу данных
            _threshold = new ComponentThreshold();
            Lifelength = Lifelength.Null;
            StartLifelength = Lifelength.Null;
            // Все даты тоже должны быть заполнены - иначе исключение при сохранении в базу данных
            DeliveryDate = DateTimeExtend.GetCASMinDateTime();
            manufactureDate = DateTimeExtend.GetCASMinDateTime();
            ExpirationDate = DateTimeExtend.GetCASMinDateTime();
            NotificationDate = DateTimeExtend.GetCASMinDateTime();
            StartDate = DateTimeExtend.GetCASMinDateTime();
            // Задаем Maintenance Type
            MaintenanceControlProcess = MaintenanceControlProcess.OC;
            PrintInWorkPackage = true;

            // String тоже не должны быть равны null
            _partNumber = _description = _serialNumber = _remarks = _manufacturer = ALTPartNumber = MTOGW = HushKit = ShelfLife
                = _batchNumber = IdNumber = MPDItem = HiddenRemarks = KitRequired = "";
            _measure = Measure.Unit;
            // Создаем все коллекции
            ChangeLLPCategoryRecords = new BaseRecordCollection<ComponentLLPCategoryChangeRecord>();
        }
		#endregion

		#region public Component(TemplateComponent templateComponent) : this()
		/// <summary>
		/// Создает воздушное судно без дополнительной информации
		/// </summary>
		public Component(TemplateComponent templateComponent) : this()
        {
            IsBaseComponent = templateComponent.IsBaseComponent;
            ATAChapter = templateComponent.ATAChapter;
            _partNumber = templateComponent.PartNumber;
            _batchNumber = templateComponent.BatchNumber;
            _description = templateComponent.Description;
            _serialNumber = templateComponent.SerialNumber;
            MaintenanceControlProcess = templateComponent.MaintenanceControlProcess;
            _remarks = templateComponent.Remarks;
            Model = templateComponent.Model;
            _manufacturer = templateComponent.Manufacturer;
            LLPMark = templateComponent.LLPMark;
            LLPCategories = templateComponent.LLPCategories;
            LandingGear = templateComponent.LandingGear;
            AvionicsInventory = templateComponent.AvionicsInventory;
            ALTPartNumber = templateComponent.ALTPartNumber;
            MTOGW = templateComponent.MTOGW;
            HushKit = templateComponent.HushKit;
            Cost = templateComponent.Cost;
            _costOverhaul = templateComponent.CostOverhaul;
            _costServiceable = templateComponent.CostServiceable;
            _quantity = templateComponent.Quantity;
            ManHours = templateComponent.ManHours;
            FaaFormFile = templateComponent.FaaFormFile;
            Warranty = templateComponent.Warranty;
            WarrantyNotify = templateComponent.WarrantyNotify;
            Serviceable = templateComponent.Serviceable;
            _goodsClass = templateComponent.GoodsClass;
            ShelfLife = templateComponent.ShelfLife;
            MPDItem = templateComponent.MPDItem;
            _suppliers = templateComponent.Suppliers;
            LifeLimit = templateComponent.LifeLimit;
            LifeLimitNotify = templateComponent.LifeLimitNotify;
            Highlight = Highlight.White;
        }
		#endregion

		#region public Component(Component copyComponent) : this()
		/// <summary>
		/// Создает деталь на основе другой детали
		/// </summary>
		public Component(Component copyComponent) : this()
        {
            ALTPartNumber = copyComponent.ALTPartNumber;
            ATAChapter = copyComponent.ATAChapter;
            AvionicsInventory = copyComponent.AvionicsInventory;
            _batchNumber = copyComponent.BatchNumber;
            _costNew = copyComponent.Cost;
            _costOverhaul = copyComponent.CostOverhaul;
            _costServiceable = copyComponent.CostServiceable;
            Current = copyComponent.Current;
            DeliveryDate = copyComponent.DeliveryDate;
            _description = copyComponent.Description;
            _goodsClass = copyComponent.GoodsClass;
            ExpirationDate = copyComponent.ExpirationDate;
            HiddenRemarks = copyComponent.HiddenRemarks;
            Highlight = copyComponent.Highlight;
            HushKit = copyComponent.HushKit;
            IsBaseComponent = copyComponent.IsBaseComponent;
            IdNumber = copyComponent.IdNumber;
            KitRequired = copyComponent.KitRequired;
            LandingGear = copyComponent.LandingGear;
            Lifelength = new Lifelength(copyComponent.Lifelength);
            LifeLimit = copyComponent.LifeLimit;
            LifeLimitNotify = copyComponent.LifeLimitNotify;
            LLPMark = copyComponent.LLPMark;
            LLPCategories = copyComponent.LLPCategories;
            Location = copyComponent.Location;
            MaintenanceControlProcess = copyComponent.MaintenanceControlProcess;
            ManHours = copyComponent.ManHours;
            manufactureDate = copyComponent.ManufactureDate;
            _manufacturer = copyComponent.Manufacturer;
            _measure = copyComponent.Measure;
            Model = copyComponent.Model;
            MPDItem = copyComponent.MPDItem;
            MTOGW = copyComponent.MTOGW;
            NotificationDate = copyComponent.NotificationDate;
            ParentAircraftId = copyComponent.ParentAircraftId;
            ParentBaseComponent = copyComponent.ParentBaseComponent;//TODO:(Evgenii Babak) заменить на использование ComponentCore 
            _partNumber = copyComponent.PartNumber;
            _quantity = copyComponent.Quantity;
            _remarks = copyComponent.Remarks;
            _serialNumber = copyComponent.SerialNumber;
            Serviceable = copyComponent.Serviceable;
            ShelfLife = copyComponent.ShelfLife;
            ShouldBeOnStock = copyComponent.ShouldBeOnStock;
            StartDate = copyComponent.StartDate;
            StartLifelength = new Lifelength(copyComponent.StartLifelength);
            Warranty = new Lifelength(copyComponent.Warranty);
            WarrantyNotify = new Lifelength(copyComponent.WarrantyNotify);

            FaaFormFile = copyComponent.FaaFormFile;

            if (LLPData == null)
                LLPData = new ComponentLLPDataCollection();
            LLPData.Clear();
            foreach (ComponentLLPCategoryData llpCategoryData in copyComponent.LLPData)
            {
                LLPData.Add(new ComponentLLPCategoryData(llpCategoryData){ ComponentId = ItemId});
            }

            if (_suppliers == null)
                _suppliers = new SupplierCollection();
            _suppliers.Clear();
            foreach (Supplier supplier in copyComponent.Suppliers)
            {
                _suppliers.Add(supplier);
            }

            if (_supplierRelations == null)
                _supplierRelations = new CommonCollection<KitSuppliersRelation>();
            _supplierRelations.Clear();
            foreach (KitSuppliersRelation ksr in copyComponent.SupplierRelations)
            {
                _supplierRelations.Add(new KitSuppliersRelation(ksr) {KitId = ItemId});
            }

            if (Kits == null)
                Kits = new CommonCollection<AccessoryRequired>();
            Kits.Clear();
            foreach (AccessoryRequired kit in copyComponent.Kits)
            {
                Kits.Add(new AccessoryRequired(kit){ParentObject = this, ParentId = ItemId});
            }

            if (ActualStateRecords == null)
                ActualStateRecords = new ActualStateRecordCollection();
            ActualStateRecords.Clear();
            foreach (ActualStateRecord actualStateRecord in copyComponent.ActualStateRecords)
            {
                ActualStateRecords.Add(new ActualStateRecord(actualStateRecord) {ComponentId = ItemId, ParentComponent = this});
            }

            if (_transferRecords == null)
                _transferRecords = new TransferRecordCollection();
            _transferRecords.Clear();
            foreach (TransferRecord transferRecord in copyComponent.TransferRecords)
            {
                _transferRecords.Add(new TransferRecord(transferRecord){ ParentComponent = this, ParentId = ItemId});
            }

            if (ComponentDirectives == null)
                ComponentDirectives = new CommonCollection<ComponentDirective>();
            ComponentDirectives.Clear();
            foreach (ComponentDirective componentDirective in copyComponent.ComponentDirectives)
            {
                ComponentDirectives.Add(new ComponentDirective(componentDirective) {ParentComponent = this, ComponentId = ItemId});
            }

            if (ChangeLLPCategoryRecords == null)
                ChangeLLPCategoryRecords = new BaseRecordCollection<ComponentLLPCategoryChangeRecord>();
            ChangeLLPCategoryRecords.Clear();
            foreach (ComponentLLPCategoryChangeRecord llpCategoryChangeRecord in copyComponent.ChangeLLPCategoryRecords)
            {
                ChangeLLPCategoryRecords.Add(new ComponentLLPCategoryChangeRecord(llpCategoryChangeRecord)
                                                 {
                                                     ParentId = ItemId,
                                                     ParentComponent = this
                                                 });
            }
        }
        #endregion

        #region private static Type GetCurrentType()
        private static Type GetCurrentType()
        {
            return _thisType ?? (_thisType = typeof(Component));
        }
        #endregion

        #region public override int GetHashCode()
        public override int GetHashCode()
        {
            return ItemId.GetHashCode();
        }
        #endregion

        #region public override string ToString()

		public int Compare(Component x, Component y)
		{
			if (x.LLPCategories && y.LLPCategories)
			{
				int i, j;
				if (int.TryParse(x.Position, out i) && int.TryParse(y.Position, out j))
					return 1 * (i - j);

				return string.CompareOrdinal(x.PartNumber, y.PartNumber);
			}
			return string.CompareOrdinal(x.PartNumber, y.PartNumber);
		}

		/// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("P/N:{0} Pos:{1} S/N:{2} {3} {4}",PartNumber, Position, SerialNumber, Description, MaintenanceControlProcess.ShortName) 
                + (IsDeleted ? " is deleted" : "");
        }
		#endregion

		#region public int CompareTo(Component y)

		public int CompareTo(Component y)
        {
            return ItemId.CompareTo(y.ItemId);
        }

        #endregion

        /*
         * Математичесский аппарат
         */
        #region Implement of IEngineeringDirective
        //Своиства интерфеися IMathData, они содержат вычисления мат аппарата для объектов
        //у всех директив, деталей чеков и т.д. можно вычислить их текущее сотояние
        // дату след. выполнения и наработку на которой это выполнение произоидет

        #region String Title { get; }

        /// <summary>
        /// Название директивы
        /// </summary>
        public String Title
        {
            get { return PartNumber; }
        }
        #endregion

        #region String Zone { get; }
        /// <summary>
        /// Зона
        /// </summary>
        public String Zone { get; set; }
        #endregion

        #region String Access { get; }
        /// <summary>
        /// Доступ
        /// </summary>
        public String Access { get; set; }
        #endregion

        #region public MaintenanceDirectiveProgramType Program { get; }

        /// <summary>
        /// Программа обслуживания
        /// </summary>
        public MaintenanceDirectiveProgramType Program
        {
            get { return MaintenanceDirectiveProgramType.Unknown; }
        }
        #endregion

        #region public StaticDictionary WorkType { get; }
        /// <summary>
        /// Тип/Вид Работ
        /// </summary>
        public StaticDictionary WorkType { get { return ComponentRecordType.Remove; }}
        #endregion

        #region public String Phase { get; }
        /// <summary>
        /// Фаза
        /// </summary>
        public String Phase { get; set; }
        #endregion

        #region public CommonCollection<CategoryRecord> CategoriesRecords

        private CommonCollection<CategoryRecord> _employeeAircraftWorkerCategories;
        /// <summary>
        /// 
        /// </summary>
        [Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 5, "Parent")]
        public CommonCollection<CategoryRecord> CategoriesRecords
        {
            get { return _employeeAircraftWorkerCategories ?? (_employeeAircraftWorkerCategories = new CommonCollection<CategoryRecord>()); }
            internal set
            {
                if (_employeeAircraftWorkerCategories != value)
                {
                    if (_employeeAircraftWorkerCategories != null)
                        _employeeAircraftWorkerCategories.Clear();
                    if (value != null)
                        _employeeAircraftWorkerCategories = value;
                }
            }
        }
		#endregion

		#region BaseSmartCoreObject LifeLenghtParent { get; }
		/// <summary>
		/// Возвращает объект, для которого можно расчитать текущую наработку. Обычно Aircraft, BaseComponent или Component
		/// </summary>
		public BaseEntityObject LifeLengthParent
        {
            get { return this; }
        }
        #endregion

        #region IThreshold IDirective.Threshold { get; set; }
        /// <summary>
        /// порог первого и посделующего выполнений
        /// </summary>
        IThreshold IDirective.Threshold
        {
            get { return _threshold ?? (_threshold = new ComponentThreshold()); }
            set { _threshold = value as ComponentThreshold; }
        }
        #endregion

        #region IRecordCollection IDirective.PerformanceRecords { get; }
        /// <summary>
        /// Коллекция содержит все записи о выполнении директивы
        /// <br/>Для детали вернет записи о перемещении или null
        /// </summary>
        IRecordCollection IDirective.PerformanceRecords
        {
            get { return _transferRecords; }
        }
        #endregion

        #region AbstractPerformanceRecord IDirective.LastPerformance { get; }
        /// <summary>
        /// Доступ к последней записи о выполнении задачи, всегда Null
        /// </summary>
        AbstractPerformanceRecord IDirective.LastPerformance { get { return null; } }
        #endregion

        #region public List<NextPerformance> NextPerformances { get; set; }
        [NonSerialized]
        private List<NextPerformance> _nextPerformances;
        /// <summary>
        /// Список последующих выполнений задачи
        /// </summary>
        public List<NextPerformance> NextPerformances
        {
            get { return _nextPerformances ?? (_nextPerformances = new List<NextPerformance>()); }
        }
        #endregion

        #region public NextPerformance NextPerformance { get; }
        /// <summary>
        /// След. выполнение задачи
        /// </summary>
        public NextPerformance NextPerformance
        {
            get
            {
                if (_nextPerformances == null || _nextPerformances.Count == 0)
                    return null;
                return _nextPerformances[0];
            }
        }
        #endregion

        #region public ConditionState Condition { get; }
        /// <summary>
        /// Возвращает состояние ближайшего выполнения задачи (если оно расчитано) или ConditionState.NotEstimated
        /// </summary>
        [Filter("Condition:")]
        public ConditionState Condition
        {
            get
            {
                if (_nextPerformances == null || _nextPerformances.Count == 0) 
                    return ConditionState.NotEstimated;
                return _nextPerformances[0].Condition;
            }
        }
		#endregion

		#region public ComponentStatus ComponentStatus { get; }

		private ComponentStatus _componentStatus;
        /// <summary>
        /// Статус Компоненте (новый, после ТО, после ремонта, после кап.ремонта)
        /// </summary>
        [TableColumn("Status")]
        public ComponentStatus ComponentStatus
        {
            get
            {
                return _componentStatus;
            }
            set
            {
                if (_componentStatus != value)
                {
                    _componentStatus = value;
                    OnPropertyChanged("ComponentStatus");
                }
            }
        }
        #endregion

        #region public DirectiveStatus Status { get; }
        /// <summary>
        /// Статус директивы
        /// </summary>
        public DirectiveStatus Status
        {
            get
            {
                if (IsClosed) return DirectiveStatus.Closed; //директива принудительно закрыта пользователем
                if (LifeLimit.IsNullOrZero()) return DirectiveStatus.Closed;

                return DirectiveStatus.Open;
            }
        }
        #endregion

        #region public Lifelength NextCompliance { get; }

        /// <summary>
        /// Возвращает ресурс ближайшего выполнения задачи (если оно расчитано) или Lifelength.Null
        /// </summary>
        public Lifelength NextPerformanceSource
        {
            get
            {
                if (_nextPerformances == null || _nextPerformances.Count == 0) return Lifelength.Null;
                return _nextPerformances[0].PerformanceSource;
            }
        }
        #endregion

        #region public Lifelength Remains { get; }
        /// <summary>
        /// Возвращает остаток ресурса до ближайшего выполнения задачи (если оно расчитано) или Lifelength.Null
        /// </summary>
        public Lifelength Remains
        {
            get
            {
                if (_nextPerformances == null || _nextPerformances.Count == 0) return Lifelength.Null;
                return _nextPerformances[0].Remains;
            }
        }
        #endregion

        #region public Lifelength BeforeForecastResourceRemain { get; }
        /// <summary>
        /// Остаток ресурса до прогноза (вычисляется только в прогнозе)
        /// </summary>
        public Lifelength BeforeForecastResourceRemain
        {
            get
            {
                if (_nextPerformances == null || _nextPerformances.Count == 0) return Lifelength.Null;
                return _nextPerformances[0].BeforeForecastResourceRemain;
            }
        }
        #endregion

        #region public Lifelength ForecastLifelength { get; set; }
        //ресурс прогноза
        public Lifelength ForecastLifelength { get; set; }
        #endregion

        #region public Lifelength AfterForecastResourceRemain { get; set; }
        /// <summary>
        /// Остаток ресурса после прогноза (вычисляется только в прогнозе)
        /// </summary>
        public Lifelength AfterForecastResourceRemain { get; set; }
        #endregion

        #region public DateTime? NextComplianceDate{ get; set; }
        /// <summary>
        /// Возвращает прблизительную дату ближайшего выполнения задачи (если оно расчитано) или null
        /// </summary>
        public DateTime? NextPerformanceDate
        {
            get
            {
                if (_nextPerformances == null || _nextPerformances.Count == 0) 
                    return null;
                return _nextPerformances[0].PerformanceDate;
            }
        }
        #endregion

        #region public double? Percents { get; set; }
        /// <summary>
        /// Насколько процентов NextCompliance превосходит точку прогноза
        /// </summary>
        public double? Percents { get; set; }
        #endregion

        #region public string TimesToString { get; }
        /// <summary>
        /// Возвращает строковое представление количества "след. выполнений"
        /// </summary>
        public string TimesToString
        {
            get { return Times <= 1 ? "" : Times + " times"; }
        }
        #endregion

        #region public Int32 Times { get;}
        /// <summary>
        /// Сколько раз выполнится директива (применяетмя только в прогнозах)
        /// </summary>
        public Int32 Times
        {
            get { return NextPerformances.Count > 1 ? NextPerformances.Count : -1; }
        }
        #endregion

        #region public Double ManHours { get; set; }
        /// <summary>
        /// Параметр трудозатрат
        /// </summary>
        [TableColumn("ManHours"), MinMaxValueAttribute(0, 1000000)]
        public Double ManHours { get; set; }

		public static PropertyInfo ManHoursProperty
		{
			get { return GetCurrentType().GetProperty("ManHours"); }
		}
		#endregion

		#region Double Elapsed { get; set; }
		/// <summary>
		/// Параметр полных трудозатрат 
		/// </summary>
		public Double Elapsed { get; set; }
        #endregion

        #region public int Mans { get; set; }
        /// <summary>
        /// Количество сотрудников для выполнения задачи
        /// </summary>
        public int Mans { get; set; }
        #endregion

        #region public Double Cost { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MinMaxValueAttribute(0, 1000000000)]
        public Double Cost
        {
            get { return _costNew; }
            set { _costNew = value; }
        }
        #endregion

        #region public Boolean IsClosed { get; set; }
        /// <summary>
        /// Логический флаг, показывающий, закрыта ли директива
        /// </summary>
        public Boolean IsClosed { get; set; }
        #endregion

        #region public Boolean NextPerformanceIsBlocked { get; }
        ///
        /// Логический флаг, показывающий, заблокировано ли след. выполенение директивы рабочим пакетом
        /// 
        public Boolean NextPerformanceIsBlocked
        {
            get
            {
                if (_nextPerformances == null || _nextPerformances.Count == 0) return false;
                return _nextPerformances[0].BlockedByPackage != null;
            }
        }

        #endregion

        #region public void ResetMathData()
        public void ResetMathData()
        {
            AfterForecastResourceRemain = null;
            NextPerformances.Clear();
        }
        #endregion

        #endregion

        #region public Lifelength LLPRemains { get; set; }

        /// <summary>
        /// Возвращает остаток ресурса до ближайшего выполнения задачи (если оно расчитано) или Lifelength.Null
        /// </summary>
        public Lifelength LLPRemains
        {
            get
            {
                ComponentLLPCategoryChangeRecord lastChangeRecord = ChangeLLPCategoryRecords.GetLast();
                if (lastChangeRecord == null)
                    return Remains;

                ComponentLLPCategoryData data = LLPData.GetItemByCatagory(lastChangeRecord.ToCategory);
                if (data == null)
                    return Remains;

                return data.Remain;
            }
        }
        #endregion

        #region public ConditionState LLPCondition { get; set; }

        /// <summary>
        /// Возвращает состояние ближайшего выполнения задачи (если оно расчитано) или ConditionState.NotEstimated
        /// </summary>
        public ConditionState LLPCondition { get; set; }
        #endregion

        #region Implement IEquotable
        public bool Equals(Component other)
        {

            //Check whether the compared object is null.
            if (ReferenceEquals(other, null)) return false;

            //Check whether the compared object references the same data.
            if (ReferenceEquals(this, other)) return true;

            //Check whether the products' properties are equal.
            return ItemId == other.ItemId;
        }
        #endregion

        #region Implement IkitRequired

        #region public string KitParentString { get; }
        /// <summary>
        /// Возвращает строку для описания родителя КИТа
        /// </summary>
        public string KitParentString
        {
            get
            {
                return string.Format("Compnt.:{0} {1}", this, Description);
            }
        }
        #endregion

        #region public ICommonCollection<KitRequired> Kits

        private CommonCollection<AccessoryRequired> _kits;

        [Child(RelationType.OneToMany, "ParentId", "ParentTypeId", new []{ 5,6 }, "ParentObject")]
        public CommonCollection<AccessoryRequired> Kits
        {
            get { return _kits ?? (_kits = new CommonCollection<AccessoryRequired>()); }
            internal set
            {
                if (_kits != value)
                {
                    if (_kits != null)
                        _kits.Clear();
                    if (value != null)
                        _kits = value;
                    OnPropertyChanged("Kits");
                }
            }
        }
        #endregion

        #endregion

        #region Implement of IComponentFilterParams

        #region Lifelength FirstPerformanceSinceNew { get; }

        /// <summary>
        /// Возвращает порог первого выполнения задачи
        /// </summary>
        public Lifelength FirstPerformanceSinceNew
        {
            get { return _threshold != null ? _threshold.FirstPerformanceSinceNew : Lifelength.Null; }
        }
        #endregion

        #region public Lifelength Interval { get; }

        /// <summary>
        /// Возвращает интервал повторного выполнения задачи или Lifelength.Null
        /// </summary>
        public Lifelength Interval { get { return Lifelength.Null; } }

		#endregion

		#region public ComponentRecordType DirectiveType { get; }
		/// <summary>
		/// Тип директивы
		/// </summary>
		public ComponentRecordType DirectiveType
        {
            get { return ComponentRecordType.Discard; }
        }
        #endregion

        #endregion

        #region Implement IPrintSettings

        #region public bool PrintInWorkPackage { get; set; }
        /// <summary>
        /// Возвращает или задает значение, показвающее настройку печати элемента в Рабочем пакете
        /// </summary>
        public bool PrintInWorkPackage { get; set; }

        #region public bool WorkPackageACCPrintTitle { get; set; }
        /// <summary>
        /// Возвращает или задает значение, показвающее печать НАЗВАНИЯ задачи в AccountabilitySheet рабочего пакета
        /// </summary>
        public bool WorkPackageACCPrintTitle { get; set; }
        #endregion

        #region public bool WorkPackageACCPrintTaskCard { get; set; }
        /// <summary>
        /// Возвращает или задает значение, показвающее печать РАБОЧЕЙ КАРТЫ задачи в AccountabilitySheet рабочего пакета
        /// </summary>
        public bool WorkPackageACCPrintTaskCard { get; set; }
        #endregion

        #endregion

        #endregion

        #region public ActualStateRecordCollection ActualStateRecords { get; set; }

        private ActualStateRecordCollection _actualStates;
        /// <summary>
        /// Список актуальных состояний базового агрегата
        /// </summary>
        [Child(RelationType.OneToMany, "ComponentId", "ParentComponent")]
        public ActualStateRecordCollection ActualStateRecords
        {
            get { return _actualStates ?? (_actualStates = new ActualStateRecordCollection()); }
            set
            {
                if (_actualStates != value)
                {
                    if (_actualStates != null)
                        _actualStates.Clear();
                    if (value != null)
                        _actualStates = value;

                    OnPropertyChanged("ActualStateRecords");
                }
            }
        }
        #endregion

        #region public TransferRecordCollection TransferRecords { get; set; }

        private TransferRecordCollection _transferRecords;
        /// <summary>
        /// Список перемещений агрегата, всегда NotNull
        /// </summary>
        [Child(RelationType.OneToMany, "ParentId", "ParentComponent")]
        public TransferRecordCollection TransferRecords
        {
            get { return _transferRecords ?? (_transferRecords  = new TransferRecordCollection()); }
            set
            {
                if (_transferRecords != value)
                {
                    if (_transferRecords != null)
                        _transferRecords.Clear();
                    if (value != null)
                        _transferRecords = value;

                    OnPropertyChanged("TransferRecords");
                }
            }
        }
		#endregion

		#region public ICommonCollection<ComponentDirective> ComponentDirectives { get; set; }

		private CommonCollection<ComponentDirective> _componentDirectives;
        /// <summary>
        /// Список директив базового агрегата
        /// </summary>
        [Child(RelationType.OneToMany, "ComponentId", "ParentComponent")]
        public CommonCollection<ComponentDirective> ComponentDirectives
        {
            get { return _componentDirectives ?? (_componentDirectives = new CommonCollection<ComponentDirective>()); }
            set
            {
                if (_componentDirectives != value)
                {
                    if (_componentDirectives != null)
                        _componentDirectives.Clear();
                    if (value != null)
                        _componentDirectives = value;

                    OnPropertyChanged("ComponentDirectives");
                }
            }
        }
		#endregion

		#region public BaseRecordCollection<ComponentLLPCategoryChangeRecord> ChangeLLPCategoryRecords { get; set; }
		private BaseRecordCollection<ComponentLLPCategoryChangeRecord> _сhangeLLPCategoryRecords;
		private Locations _location;


		/// <summary>
        /// Список записей о переводе агрегата меджу различными LLP категоиями
        /// </summary>
        [Child(RelationType.OneToMany, "ParentId", "Parent")]
        public BaseRecordCollection<ComponentLLPCategoryChangeRecord> ChangeLLPCategoryRecords
        {
            get { return _сhangeLLPCategoryRecords ?? (_сhangeLLPCategoryRecords = new BaseRecordCollection<ComponentLLPCategoryChangeRecord>()); }
            set
            {
                if (_сhangeLLPCategoryRecords != value)
                {
                    if (_сhangeLLPCategoryRecords != null)
                        _сhangeLLPCategoryRecords.Clear();
                    if (value != null)
                        _сhangeLLPCategoryRecords = value;

                    OnPropertyChanged("ChangeLLPCategoryRecords");
                }
            }
        }


		#endregion

		#region public Document Document { get; set; }

		public Document Document { get; set; }

		#endregion

		#region public Document DocumentCRS { get; set; }

		public Document DocumentCRS { get; set; }

		#endregion

		#region public Document DocumentFaa { get; set; }

		public Document DocumentFaa { get; set; }

		#endregion

		#region public Document DocumentShipping { get; set; }

		public Document DocumentShipping { get; set; }

		#endregion

		#region public Supplier FromSupplier { get; set; }

		private Supplier _fromSupplier;
		private Specialist _received;

		[TableColumn("FromSupplierId")]
		[Child]
		public Supplier FromSupplier
		{
			get { return _fromSupplier ?? Supplier.Unknown; }
			set { _fromSupplier = value; }
		}

		#endregion

		#region public DateTime FromSupplierReciveDate { get; set; }

		[TableColumn("FromSupplierReciveDate")]
		public DateTime FromSupplierReciveDate { get; set; }

		#endregion

		#region public new Component GetCopyUnsaved()
		//TODO(Evenii Babak):Выяснить почему new вместо override
		public new Component GetCopyUnsaved()
		{
			return GetCopyUnsaved(-1);
		}

		#endregion

		#region public Component GetCopyUnsaved(int componentId)

		public Component GetCopyUnsaved(int componentId)
		{
			var component = (Component)MemberwiseClone();
			component.ItemId = componentId;
			component.UnSetEvents();

			component.Threshold = new ComponentThreshold(Threshold);

			component.Lifelength = new Lifelength(Lifelength);
			component.StartLifelength = new Lifelength(StartLifelength);
			component.Warranty = new Lifelength(Warranty);
			component.WarrantyNotify = new Lifelength(WarrantyNotify);

			component.ParentBaseComponent = null;

			component._componentLLPDataCollection = new ComponentLLPDataCollection();
			foreach (var componentLLPCategoryData in LLPData)
			{
				var newObject = componentLLPCategoryData.GetCopyUnsaved();
				newObject.ComponentId = componentLLPCategoryData.ItemId;
				component._componentLLPDataCollection.Add(newObject);
			}

			component._supplierRelations = new CommonCollection<KitSuppliersRelation>();
			foreach (var ksr in component.SupplierRelations)
			{
				var newObject = ksr.GetCopyUnsaved();
				newObject.KitId = component.ItemId;
				component._supplierRelations.Add(newObject);
			}

			component._kits = new CommonCollection<AccessoryRequired>();
			foreach (var accessory in Kits)
			{
				var newObject = accessory.GetCopyUnsaved();
				newObject.ParentId = component.ItemId;
				component._kits.Add(newObject);

			}

			component._actualStates = new ActualStateRecordCollection();
			foreach (var ast in ActualStateRecords)
			{
				var newObject = ast.GetCopyUnsaved();
				newObject.ComponentId = component.ItemId;
				newObject.ParentComponent = component;
				component._actualStates.Add(newObject);
			}

			component._transferRecords = new TransferRecordCollection();
			foreach (var transferRecord in TransferRecords)
			{
				var newObject = transferRecord.GetCopyUnsaved();
				newObject.ParentComponent = component;
				component._transferRecords.Add(newObject);
			}

			component._componentDirectives = new CommonCollection<ComponentDirective>();
			foreach (var componentDirective in ComponentDirectives)
			{
				var newObject = componentDirective.GetCopyUnsaved();
				newObject.ComponentId = component.ItemId;
				newObject.ParentComponent = component;
				component._componentDirectives.Add(newObject);
			}

			component._сhangeLLPCategoryRecords = new BaseRecordCollection<ComponentLLPCategoryChangeRecord>();
			foreach (var componentLLPCategoryChangeRecord in ChangeLLPCategoryRecords)
			{
				var newObject = componentLLPCategoryChangeRecord.GetCopyUnsaved();
				newObject.ParentComponent = component;
				newObject.ParentId = component.ItemId;
				component._сhangeLLPCategoryRecords.Add(newObject);
			}


			component._files = new CommonCollection<ItemFileLink>();
			foreach (var file in Files)
			{
				var newObject = file.GetCopyUnsaved();
				component._files.Add(newObject);
			}

			return component;
		}

		#endregion

		#region Implement IProcessingFilterParam

		public BaseEntityObject From
		{
			get
			{
				var tr =  TransferRecords.GetLast();

				if (tr == null) return null;
				if (tr.FromAircraft != null)
					return tr.FromAircraft;
				if (tr.FromStore != null)
					return tr.FromStore;
				if (tr.FromBaseComponent != null)
					return tr.FromBaseComponent;

				return null;
			}
		}
		public BaseEntityObject DestinationObject { get{ return TransferRecords.GetLast()?.DestinationObject; } }
		public SupplierClass SupplierClass { get { return FromSupplier.SupplierClass; } }
		public bool Approved { get { return FromSupplier.Approved; } }
		public DateTime TransferDate { get { return (DateTime) TransferRecords.GetLast()?.TransferDate; } }
		public DateTime SupplierReceiptDate { get { return (DateTime) TransferRecords.GetLast()?.SupplierReceiptDate; } }
		public InitialReason Reason { get { return TransferRecords.GetLast()?.Reason; } }

		#endregion

		#region Implementation of IAtaSorted

		public AtaChapter AtaSorted
		{
			get => Model != null ? Model.ATAChapter : ATAChapter;
		}

		#endregion
	}
}
