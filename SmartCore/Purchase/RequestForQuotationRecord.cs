using System;
using System.Collections.Generic;
using System.ComponentModel;
using CAS.Entity.Models.DTO.General;
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
	/// ����� ��������� ������ � ������������ ����
	/// </summary>
	[Table("RequestForQuotationRecords", "dbo", "ItemId")]
	[Dto(typeof(RequestForQuotationRecordDTO))]
	[Condition("IsDeleted", "0")]
	public class RequestForQuotationRecord : BasePackageRecord
	{
		//private static Type _thisType;
		/*
		*  ��������
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
		/// ��������� �����
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
		/// ��������
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
		/// �������������
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
		/// ���������� 
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
		/// ������� ���������
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
		/// ���� ����� ������
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
		/// ��������� �� KIT - � 
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
		/// ���������� ������ ������
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
		/// ���������, � �������� ������� ������
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
		/// ����������� ����� ������������ ��������
		/// </summary>
		[TableColumn("LifeLimit")]
		public Lifelength LifeLimit { get; set; }

		#endregion

		#region public Lifelength LifeLimitNotify { get; set; }
		/// <summary>
		/// ����������� �� ����������� ����� ������������ ��������
		/// </summary>
		[TableColumn("LifeLimitNotify")]
		public Lifelength LifeLimitNotify { get; set; }
		#endregion

		#region IThreshold IDirective.Threshold { get; set; }

		private DirectiveThreshold _threshold;
		private List<SupplierPrice> _supplierPrice;

		/// <summary>
		/// ����� ������� � ������������ ����������
		/// </summary>
		public IThreshold Threshold
		{
			get { return _threshold = new DirectiveThreshold(); }
			set { _threshold = value as DirectiveThreshold; }
		}
		#endregion

		#region public IDirective Task { get; set; }

		/// <summary>
		/// ������, � ������� ������ �������
		/// </summary>
		public IDirective Task
		{
			get { return PackageItem as IDirective; }
			set { PackageItem = value; }
		}

		public InitialOrderRecord ParentInitialRecord { get; set; }

		#endregion

		/*
		*  ������ 
		*/

		#region public RequestForQuotationRecord()
		/// <summary>
		/// ������� ��������� ����� ��� �������������� ����������
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
		/// ������� ������  ��� �������������� ����������
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
		/// ������� ������  ��� �������������� ����������
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
		/// ����������� ��� �������
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return "";
		}
		#endregion   

	}

	[Serializable]
	[JsonObject]
	public class SupplierPrice : BaseEntityObject
	{
		public SupplierPrice()
		{
			�urrencyNew = �urrency.USD;
			�urrencyTest = �urrency.USD;
			�urrencyInspect = �urrency.USD;
			�urrencyServ = �urrency.USD;
			�urrencyOH = �urrency.USD;
			�urrencyRepair = �urrency.USD;
			�urrencyModification = �urrency.USD;
		}

		
		[ListViewData(200, "Product", 1)]
		public string ProductName => Parent?.Product?.PartNumber;

		[JsonProperty]
		public int SupplierId { get; set; }

		[JsonProperty]
		public decimal CostNew { get; set; }

		[JsonProperty]
		public decimal CostTest { get; set; }

		[JsonProperty]
		public decimal CostInspect { get; set; }

		[JsonProperty]
		public decimal CostServiceable { get; set; }

		[JsonProperty]
		public decimal CostOverhaul { get; set; }

		[JsonProperty]
		public decimal CostRepair { get; set; }

		[JsonProperty]
		public decimal CostModification { get; set; }

		[JsonProperty]
		public decimal CostNewEx { get; set; }

		[JsonProperty]
		public decimal CostTestEx { get; set; }

		[JsonProperty]
		public decimal CostInspectEx { get; set; }

		[JsonProperty]
		public decimal CostServiceableEx { get; set; }

		[JsonProperty]
		public decimal CostOverhaulEx { get; set; }

		[JsonProperty]
		public decimal CostRepairEx { get; set; }

		[JsonProperty]
		public decimal CostModificationEx { get; set; }

		[JsonProperty]
		public decimal CostNewReadiness { get; set; }

		[JsonProperty]
		public decimal CostTestReadiness { get; set; }

		[JsonProperty]
		public decimal CostInspectReadiness { get; set; }

		[JsonProperty]
		public decimal CostServiceableReadiness { get; set; }

		[JsonProperty]
		public decimal CostOverhaulReadiness { get; set; }

		[JsonProperty]
		public decimal CostRepairReadiness { get; set; }

		[JsonProperty]
		public decimal CostModificationReadiness { get; set; }

		[DefaultValue(-1)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		public int �urrencyNewId { get; set; }

		[DefaultValue(-1)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		public int �urrencyTestId { get; set; }

		[DefaultValue(-1)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		public int �urrencyInspectId { get; set; }

		[DefaultValue(-1)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		public int �urrencyServId { get; set; }

		[DefaultValue(-1)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		public int �urrencyOHId { get; set; }

		[DefaultValue(-1)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		public int �urrencyRepairId { get; set; }

		[DefaultValue(-1)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		public int �urrencyModificationId { get; set; }

		#region Ignore

		[JsonIgnore]
		[ListViewData(100, "New", 3)]
		public string CostNewString => GetNewPriceString();

		[JsonIgnore]
		[ListViewData(100, "Test", 7)]
		public string CostTestString => GetTestPriceString();

		[JsonIgnore]
		[ListViewData(100, "Inspect", 9)]
		public string CostInspectString => GetInspectPriceString();

		[JsonIgnore]
		[ListViewData(100, "Serv", 5)]
		public string CostServString => GetServPriceString();

		[JsonIgnore]
		[ListViewData(100, "OH", 11)]
		public string CostOHString => GetOHPriceString();

		[JsonIgnore]
		[ListViewData(100, "Repair", 13)]
		public string CostRepairString => GetRepairPriceString();

		[JsonIgnore]
		[ListViewData(100, "Modification", 15)]
		public string CostModificationString => GetModificationPriceString();

		[JsonIgnore]
		public bool IsLowestCostNew { get; set; }
		[JsonIgnore]
		public bool IsHighestCostNew { get; set; }
		[JsonIgnore]
		public bool IsLowestCostServ { get; set; }
		[JsonIgnore]
		public bool IsHighestCostServ { get; set; }
		[JsonIgnore]
		public bool IsLowestCostOH { get; set; }
		[JsonIgnore]
		public bool IsHighestCostOH { get; set; }
		[JsonIgnore]
		public bool IsLowestCostRepair { get; set; }
		[JsonIgnore]
		public bool IsHighestCostRepair { get; set; }
		[JsonIgnore]
		public bool IsLowestCostTest { get; set; }
		[JsonIgnore]
		public bool IsHighestCostTest { get; set; }
		[JsonIgnore]
		public bool IsLowestCostInspect { get; set; }
		[JsonIgnore]
		public bool IsHighestCostInspect { get; set; }
		[JsonIgnore]
		public bool IsLowestCostMod { get; set; }
		[JsonIgnore]
		public bool IsHighestCostMod { get; set; }

		[JsonIgnore]
		public Supplier Supplier { get; set; }

		[JsonIgnore]
		public RequestForQuotationRecord Parent { get; set; }

		[JsonIgnore]
		[ListViewData(200, "Supplier", 2)]
		public string SupplierName => Supplier?.Name ?? Supplier.Unknown.Name;

		[JsonIgnore]
		public �urrency �urrencyNew
		{
			get => �urrency.GetItemById(�urrencyNewId);
			set => �urrencyNewId = value.ItemId;
		}

		[JsonIgnore]
		public �urrency �urrencyTest
		{
			get => �urrency.GetItemById(�urrencyTestId);
			set => �urrencyTestId = value.ItemId;
		}

		[JsonIgnore]
		public �urrency �urrencyInspect
		{
			get => �urrency.GetItemById(�urrencyInspectId);
			set => �urrencyInspectId = value.ItemId;
		}

		[JsonIgnore]
		public �urrency �urrencyServ
		{
			get => �urrency.GetItemById(�urrencyServId);
			set => �urrencyServId = value.ItemId;
		}

		[JsonIgnore]
		public �urrency �urrencyOH
		{
			get => �urrency.GetItemById(�urrencyOHId);
			set => �urrencyOHId = value.ItemId;
		}

		[JsonIgnore]
		public �urrency �urrencyRepair
		{
			get => �urrency.GetItemById(�urrencyRepairId);
			set => �urrencyRepairId = value.ItemId;
		}

		[JsonIgnore]
		public �urrency �urrencyModification
		{
			get => �urrency.GetItemById(�urrencyModificationId);
			set => �urrencyModificationId = value.ItemId;
		}

		#endregion

		#region Methods

		private string GetNewPriceString()
		{
			return $"{CostNew}/{CostNewEx}/{�urrencyNew}/{CostNewReadiness}";
		}

		private string GetTestPriceString()
		{
			return $"{CostTest}/{CostTestEx}/{�urrencyTest}/{CostTestReadiness}";
		}

		private string GetInspectPriceString()
		{
			return $"{CostInspect}/{CostInspectEx}/{�urrencyInspect}/{CostInspectReadiness}";
		}

		private string GetServPriceString()
		{
			return $"{CostServiceable}/{CostServiceableEx}/{�urrencyServ}/{CostServiceableReadiness}";
		}

		private string GetOHPriceString()
		{
			return $"{CostOverhaul}/{CostOverhaul}/{�urrencyOH}/{CostOverhaulReadiness}";
		}

		private string GetRepairPriceString()
		{
			return $"{CostRepair}/{CostRepairEx}/{�urrencyRepair}/{CostRepairReadiness}";
		}

		private string GetModificationPriceString()
		{
			return $"{CostModification}/{CostModificationEx}/{�urrencyModification}/{CostModificationReadiness}";
		}

		#endregion
	}

}
