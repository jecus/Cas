using System;
using System.Collections.Generic;
using CAS.Entity.Models.DTO.General;
using Newtonsoft.Json;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Files;
using SmartCore.Packages;

namespace SmartCore.Purchase
{

	/// <summary>
	/// ����� ��������� ��������� �����
	/// </summary>
	[Table("PurchaseRequestsRecords", "dbo", "ItemId")]
	[Dto(typeof(PurchaseRequestRecordDTO))]
	[Condition("IsDeleted", "0")]
	public class PurchaseRequestRecord : BasePackageRecord, IComparable<PurchaseRequestRecord>, IFileContainer
	{

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

		#region public Double Cost { get; set; }

		private double _cost;
		/// <summary>
		/// ���� ����� ������
		/// </summary>
		[TableColumn("Cost"), MinMaxValue(0, 1000000000), ListViewData(0.08f, "Cost")]
		public Double Cost
		{
			get { return _cost; }
			set
			{
				if (_cost != value)
				{
					_cost = value;
					OnPropertyChanged("CostNew");
				}
			}
		}
		#endregion

		#region public �urrency Currency { get; set; }

		[TableColumn("CurrencyId")]
		public �urrency Currency
		{
			get => _currency ?? �urrency.UNK;
			set => _currency = value;
		}

		#endregion

		#region public Supplier Supplier { get; set; }

		[TableColumn("SupplierId")]
		public int SupplierId { get; set; }
		#endregion

		public Supplier Supplier { get; set; }

		#region public KitCostCondition CostCondition { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("CostCondition")]
		public ComponentStatus CostCondition { get; set; }
		#endregion

		#region public KitCostCondition CostCondition { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("CostType")]
		public Exchange Exchange { get; set; }
		#endregion

		#region public Boolean Processed { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("Processed")]
		public Boolean Processed { get; set; }
		#endregion

		#region public string Remarks {get;set;}
		[TableColumn("Remarks")]
		public string Remarks {get;set;}
		#endregion

		#region public AttachedFile AttachedFile { get; set; }

		private AttachedFile _attachedFile;

		/// <summary>
		/// 
		/// </summary>
		public AttachedFile AttachedFile
		{
			get
			{
				return _attachedFile ?? (Files.GetFileByFileLinkType(FileLinkType.PurchaseRequestRecordFile));
			}
			set
			{
				_attachedFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.PurchaseRequestRecordFile);
			}
		}

		#endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;
		private �urrency _currency;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1860)]
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

		public SupplierPrice Price { get; set; }
		public InitialOrderRecord ParentInitialRecord { get; set; }

		#endregion

		#region public string AdditionalInformationJSON

		[TableColumn("AdditionalInformationJSON")]
		public string AdditionalInformationJSON
		{
			get => JsonConvert.SerializeObject(AdditionalInformation, Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
			set => AdditionalInformation = JsonConvert.DeserializeObject<Additional>(value ?? "", new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
		}

		private Additional _additionalInformation;
		public Additional AdditionalInformation
		{
			get => _additionalInformation ?? (_additionalInformation = new Additional());
			set => _additionalInformation = value;
		}

		public double ItemCost { get; set; }
		public double TotalCost { get; set; }

		#endregion

		#region public string TransferInformationJSON

		[TableColumn("TransferInformationJSON")]
		public string TransferInformationJSON
		{
			get => JsonConvert.SerializeObject(TransferInformation, Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
			set => TransferInformation = JsonConvert.DeserializeObject<List<TransferInformation>>(value ?? "", new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
		}

		private List<TransferInformation> _transferInformation;
		public List<TransferInformation> TransferInformation
		{
			get => _transferInformation ?? (_transferInformation = new List<TransferInformation>());
			set => _transferInformation = value;
		}
		
		#endregion

		/*
		*  ������ 
		*/

		#region public RequestForQuotation()
		/// <summary>
		/// ������� ��������� ����� ��� �������������� ����������
		/// </summary>
		public PurchaseRequestRecord()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.PurchaseRequestRecord;
			ParentPackageId = -1;
			Remarks = "";
			AttachedFile = null;
		}
		#endregion

		#region public PurchaseRequestRecord(int rfqId, Supplier supplier, Product accessory, double quantity):this()
		/// <summary>
		/// ������� ������ ��� �������������� ����������
		/// </summary>
		public PurchaseRequestRecord(int rfqId, Product accessory, double quantity)
			: this()
		{
			ParentPackageId = rfqId;

			if(accessory != null)
			{
				PackageItemId = accessory.ItemId;
				_cost = accessory.CostNew;
				_measure = accessory.Measure;
				PackageItemType = accessory.SmartCoreObjectType;
				_quantity = quantity;
			}
			else
			{
				PackageItemId = -1;
				_cost = 0;
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

		#region public int CompareTo(PurchaseRequestrecord y)

		public int CompareTo(PurchaseRequestRecord y)
		{
			return ItemId.CompareTo(y.ItemId);
		}

		#endregion

	}

	[JsonObject]
	public class Additional
	{

	}

	[JsonObject]
	public class TransferInformation : BaseEntityObject
	{
		public byte Number { get; set; }
		public string PartNumber { get; set; }
		public string SerialNumber { get; set; }
		public int ProductId { get; set; }

		[JsonIgnore]
		public Product Product { get; set; }
	}

}
