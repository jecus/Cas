using System;
using System.Collections.Generic;
using System.ComponentModel;
using EFCore.DTO;
using EFCore.DTO.General;
using Newtonsoft.Json;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Packages;

namespace SmartCore.Purchase
{

    /// <summary>
    /// Класс описывает запись в котировочном акте
    /// </summary>
    [Table("RequestForQuotationRecords", "dbo", "ItemId")]
    [Dto(typeof(RequestForQuotationRecordDTO))]
	[Condition("IsDeleted", "0")]
    public class RequestForQuotationRecord : BasePackageRecord
	{
        //private static Type _thisType;
        /*
        *  Свойства
        */

        #region public Product Product { get; set; }

        public Product Product
        {
            get { return PackageItem as Product; }
            set { PackageItem = value; }
        }
        #endregion

        #region public String AccessoryPartNumber { get; set; }
        /// <summary>
        /// партийный номер
        /// </summary>
        [ListViewData(0.12f, "Part Number", 1)]
        public String AccessoryPartNumber
        {
            get { return Product != null ? Product.PartNumber : ""; } 
            set
            {
                if (Product != null)
                    Product.PartNumber = value;
            }
        }
        #endregion

        #region public String AccessoryDescription { get; set; }
        /// <summary>
        /// описание
        /// </summary>
        [ListViewData(0.12f, "Description", 2)]
        public String AccessoryDescription
        {
            get { return Product != null ? Product.Description : ""; }
            set
            {
                if (Product != null)
                    Product.Description = value;
            }
        }
        #endregion

        #region public String AccessoryManufacturer { get; set; }
        /// <summary>
        /// производитель
        /// </summary>
        [ListViewData(0.12f, "Manufacturer", 3)]
        public String AccessoryManufacturer
        {
            get { return Product != null ? Product.Manufacturer : ""; }
            set
            {
                if (Product != null)
                    Product.Manufacturer = value;
            }
        }
        #endregion

        #region public double Quantity { get; set; }

        private double _quantity;
        /// <summary>
        /// количество 
        /// </summary>
        [TableColumn("Quantity")]
        [ListViewData(0.08f, "Q-ty")]
        public double Quantity
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

        #region public Measure Measure { get; set; }

        private Measure _measure;
        /// <summary>
        /// единица измерения
        /// </summary>
        [TableColumn("Measure")]
        [ListViewData(0.1f, "Measure")]
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

        #region public Double CostNew { get; set; }

        private double _costNew;
        /// <summary>
        /// Цена новой детали
        /// </summary>
        [TableColumn("CostNew"), MinMaxValue(0, 1000000000)]
        public Double CostNew
        {
            get { return _costNew; }
            set
            {
                if (_costNew != value)
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
        [TableColumn("CostOverhaul"), MinMaxValue(0, 1000000000)]
        public Double CostOverhaul
        {
            get { return _costOvehaul; }
            set
            {
                if (_costOvehaul != value)
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
        [TableColumn("CostServiceable"), MinMaxValue(0, 1000000000)]
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

        #region public String Remarks { get; set; }
        /// <summary>
        /// Замечания по KIT - у 
        /// </summary>
        [ListViewData(0.12f, "Remarks")]
        public String AccessoryRemarks
        {
            get { return Product != null ? Product.Remarks : ""; }
            set
            {
                if (Product != null)
                    Product.Remarks = value;
            }
        }
		#endregion


		[TableColumn("Remarks")]
		public string Remarks { get; set; }

		[TableColumn("SettingJSON")]
		public string SettingJSON
		{
			get => JsonConvert.SerializeObject(SupplierPrice, Formatting.Indented,new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
			set => SupplierPrice = JsonConvert.DeserializeObject<List<SupplierPrice>>(value ?? "", new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
		}

		public List<SupplierPrice> SupplierPrice
		{
			get => _supplierPrice ?? (_supplierPrice = new List<SupplierPrice>());
			set => _supplierPrice = value;
		}


		private Priority _priority;
		[TableColumn("Priority")]
		public Priority Priority
		{
			get { return _priority ?? Priority.UNK; }
			set { _priority = value; }
		}


		[TableColumn("DestinationObjectID")]
		public Int32 DestinationObjectId { get; set; }

		[TableColumn("DestinationObjectType")]
		public SmartCoreType DestinationObjectType { get; set; }

		#region public InitionalReason InitialReason { get; set; }

		private InitialReason _initialReason;
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("InitialReason")]
		public InitialReason InitialReason
		{
			get { return _initialReason ?? (_initialReason = InitialReason.Unknown); }
			set { _initialReason = value; }
		}

		#endregion


		#region public DeferredCategory DeferredCategory { get; set; }

		private DeferredCategory _deferredCategory;
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("DefferedCategory")]
		public DeferredCategory DeferredCategory
		{
			get { return _deferredCategory ?? (_deferredCategory = DeferredCategory.Unknown); }
			set { _deferredCategory = value; }
		}

		#endregion

		#region public SupplierCollection Suppliers  { get; set; }
		/// <summary>
		/// Поставщики данной детали
		/// </summary>
		[ListViewData(0.12f, "Suppliers", 10)]
        public SupplierCollection Suppliers
        {
            get { return Product != null ? Product.Suppliers : null; }
        }
		#endregion

		#region public Supplier ToSupplier  { get; set; }

		private Supplier _toSupplier;
		/// <summary>
		/// Поставщик, к которому делаетя запрос
		/// </summary>
		[TableColumn("ToSupplier")]
		public Supplier ToSupplier
		{
			get { return _toSupplier; }
			set
			{
				if (_toSupplier != value)
				{
					_toSupplier = value;
					OnPropertyChanged("ToSupplier");
				}
			}
		}
		#endregion

		#region public ComponentStatus CostCondition { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("CostCondition")]
        public ComponentStatus CostCondition { get; set; }
        #endregion

		#region public Boolean Processed { get; set; }
		/// <summary>
		/// 
		/// </summary>
        [TableColumn("Processed")]
        public Boolean Processed { get; set; }
		#endregion

		#region public Lifelength LifeLimit { get; set; }
		/// <summary>
		/// Ограничение срока эксплуатации агрегата
		/// </summary>
		[TableColumn("LifeLimit")]
		public Lifelength LifeLimit { get; set; }

		#endregion

		#region public Lifelength LifeLimitNotify { get; set; }
		/// <summary>
		/// Уведомление до ограничения срока эксплуатации агрегата
		/// </summary>
		[TableColumn("LifeLimitNotify")]
		public Lifelength LifeLimitNotify { get; set; }
		#endregion

		#region IThreshold IDirective.Threshold { get; set; }

		private DirectiveThreshold _threshold;
		private List<SupplierPrice> _supplierPrice;

		/// <summary>
		/// порог первого и посделующего выполнений
		/// </summary>
		public IThreshold Threshold
		{
			get { return _threshold = new DirectiveThreshold(); }
			set { _threshold = value as DirectiveThreshold; }
		}
		#endregion

		#region public IDirective Task { get; set; }

		/// <summary>
		/// Задача, с которой связан продукт
		/// </summary>
		public IDirective Task
		{
			get { return PackageItem as IDirective; }
			set { PackageItem = value; }
		}

		#endregion

		/*
		*  Методы 
		*/

		#region public RequestForQuotationRecord()
		/// <summary>
		/// Создает воздушное судно без дополнительной информации
		/// </summary>
		public RequestForQuotationRecord()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.RequestForQuotationRecord;
            ParentPackageId = -1;
            PackageItemId = -1;
            CostCondition = ComponentStatus.New | ComponentStatus.Serviceable | ComponentStatus.Overhaul | ComponentStatus.Repair;
        }
        #endregion

        #region public RequestForQuotationRecord(int rfqId, Product accessory, double quantity):this()
        /// <summary>
        /// Создает запись  без дополнительной информации
        /// </summary>
        public RequestForQuotationRecord(int rfqId, Product accessory, double quantity)
            : this()
        {
            ParentPackageId = rfqId;

            if (accessory != null)
            {
                PackageItemId = accessory.ItemId;
                _costNew = accessory.CostNew;
                _costOvehaul = accessory.CostOverhaul;
                _costServiceable = accessory.CostServiceable;
                _measure = accessory.Measure;
                PackageItemType = accessory.SmartCoreObjectType;
                _quantity = quantity;
            }
            else
            {
                PackageItemId = -1;
                _costNew = 0;
                _costOvehaul = 0;
                _costServiceable = 0;
                _measure = Measure.Unit;
                PackageItemType = SmartCoreType.Unknown;
                _quantity = 0;
            }
        }
        #endregion

        #region public RequestForQuotationRecord(Product accessory, double quantity, Supplier toSupplier):this()
        /// <summary>
        /// Создает запись  без дополнительной информации
        /// </summary>
        public RequestForQuotationRecord(Product accessory, double quantity, Supplier toSupplier)
            : this()
        {
            if (accessory != null)
            {
                PackageItemId = accessory.ItemId;
                _costNew = accessory.CostNew;
                _costOvehaul = accessory.CostOverhaul;
                _costServiceable = accessory.CostServiceable;
                _measure = accessory.Measure;
                PackageItemType = accessory.SmartCoreObjectType;
                _quantity = quantity;
            }
            else
            {
                PackageItemId = -1;
                _costNew = 0;
                _costOvehaul = 0;
                _costServiceable = 0;
                _measure = Measure.Unit;
                PackageItemType = SmartCoreType.Unknown;
                _quantity = 0;
            }
        }
        #endregion

        #region public override string ToString()
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "";
        }
        #endregion   

    }

	[JsonObject]
	public class SupplierPrice : BaseCoreObject
    {
	    [JsonIgnore]
		public Supplier Supplier { get; set; }

		[JsonIgnore]
		public RequestForQuotationRecord Parent { get; set; }

		[JsonIgnore]
		[ListViewData(120, "Supplier",1)]
		public string SupplierName
		{
			get => Supplier?.Name ?? Supplier.Unknown.Name;
		}

		[JsonProperty]
		public int SupplierId { get; set; }

		[ListViewData(80, "Offering", 2)]
		[JsonProperty]
		public decimal Offering { get; set; }

		[ListViewData(80, "Routine", 4)]
		[JsonProperty]
		public decimal Routine { get; set; }

		[ListViewData(80, "K for MH", 5)]
		[JsonProperty]
		public decimal RoutineKMH { get; set; }

		[ListViewData(80, "NDT", 6)]
		[JsonProperty]
		public decimal NDT { get; set; }

		[ListViewData(80, "K for MH", 7)]
		[JsonProperty]
		public decimal NDTKMH { get; set; }

		[ListViewData(80, "AD", 8)]
		[JsonProperty]
		public decimal AD { get; set; }

		[ListViewData(80, "K for MH", 9)]
		[JsonProperty]
		public decimal ADKMH { get; set; }

		[ListViewData(80, "NRC", 10)]
		[JsonProperty]
		public decimal NRC { get; set; }

		[ListViewData(80, "K for MH", 11)]
		[JsonProperty]
		public decimal NRCKMH { get; set; }

		[DefaultValue(-1)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		public int СurrencyOfferingId { get; set; }

		[JsonIgnore]
		[ListViewData(80, "Currency",12)]
		public Сurrency СurrencyOffering
		{
			get => Сurrency.GetItemById(СurrencyOfferingId);
			set => СurrencyOfferingId = value.ItemId;
		}

		
	}

}
