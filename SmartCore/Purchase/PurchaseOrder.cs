using System;
using System.Collections.Generic;
using System.ComponentModel;
using EntityCore.DTO.General;
using Newtonsoft.Json;
using SmartCore.Auxiliary;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Files;
using SmartCore.Packages;

namespace SmartCore.Purchase
{

	/// <summary>
	/// Класс описывает закупочный ордер
	/// </summary>
	[Table("PurchaseOrders", "dbo", "ItemId")]
	[Dto(typeof(PurchaseOrderDTO))]
	[Condition("IsDeleted", "0")]
	public class PurchaseOrder : AbstractPackage<PurchaseRequestRecord>, IComparable<PurchaseOrder>, IFileContainer, ILogistic
	{

		/*
		*  Свойства
		*/
		[TableColumn("PublishedById")]
		public int PublishedById { get; set; }

		[TableColumn("ClosedById")]
		public int ClosedById { get; set; }

		[TableColumn("PublishedByUser")]
		public string PublishedByUser { get; set; }

		[TableColumn("CloseByUser")]
		public string CloseByUser { get; set; }

		[TableColumn("Number")]
		public string Number { get; set; }

		[TableColumn("DesignationId")]
		public Designation Designation { get; set; }

		[TableColumn("PayTermId")]
		public PayTerm PayTerm { get; set; }

		[TableColumn("IncoTermId")]
		public IncoTerm IncoTerm { get; set; }

		[TableColumn("ShipCompanyId")]
		public int ShipCompanyId { get; set; }

		[TableColumn("CargoVolume")]
		public string CargoVolume { get; set; }

		[TableColumn("BruttoWeight")]
		public string BruttoWeight { get; set; }

		[TableColumn("NettoWeight")]
		public string NettoWeight { get; set; }

		[TableColumn("ShipToId")]
		public int ShipToId { get; set; }

		[TableColumn("Net")]
		public double Net { get; set; }

		[TableColumn("IncoTermRef")]
		public string IncoTermRef { get; set; }

		[TableColumn("StationId")]
		public int StationId { get; set; }

		[TableColumn("TrackingNo")]
		public string TrackingNo { get; set; }

		[TableColumn("AdditionalInformationJSON")]
		public string AdditionalInformationJSON
		{
			get => JsonConvert.SerializeObject(AdditionalInformation, Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
			set => AdditionalInformation = JsonConvert.DeserializeObject<PurchaseSettings>(value ?? "", new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
		}

		private PurchaseSettings _additionalInformation;
		public PurchaseSettings AdditionalInformation
		{
			get => _additionalInformation ?? (_additionalInformation = new PurchaseSettings());
			set => _additionalInformation = value;
		}

		/// <summary>
		/// 
		/// </summary>
		public PorProcessType Processed { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public String PorNo { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("ParentQuotationId")]
		public Int32 ParentQuotationId { get; set; }
		/// <summary>
		/// Запрашиваемые комплектующие
		/// </summary>
		public List<Product> Products { get; set; }

		#region public override CommonCollection<PurchaseRequestRecord> PackageRecords

		private CommonCollection<PurchaseRequestRecord> _packageRecords;
		/// <summary>
		/// Содержит массив элементов для привязки директив к рабочему пакету
		/// </summary>
		[Child(RelationType.OneToMany, "ParentPackageId")]
		public override CommonCollection<PurchaseRequestRecord> PackageRecords
		{
			get { return _packageRecords ?? (_packageRecords = new CommonCollection<PurchaseRequestRecord>()); }
			internal set
			{
				if (_packageRecords != value)
				{
					if (_packageRecords != null)
						_packageRecords.Clear();
					if (value != null)
						_packageRecords = value;

					OnPropertyChanged("PackageRecords");
				}
			}
		}
		#endregion

		public RequestForQuotation ParentRequest { get; internal set; }

		#region public Supplier Supplier { get; set; }

		[ListViewData(0.2f, "Supplier")]
		[TableColumn("SupplierId")]
		[Child(false)]
		public Supplier Supplier { get; set; }
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
				return _attachedFile ?? (Files.GetFileByFileLinkType(FileLinkType.PurchaseOrderAttachedFile));
			}
			set
			{
				_attachedFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.PurchaseOrderAttachedFile);
			}
		}

		#endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1855)]
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

		public Supplier ShipCompany { get; set; }
		public Supplier ShipTo{ get; set; }

		#endregion


		/*
		*  Методы 
		*/

		#region public PurchaseOrder()
		/// <summary>
		/// Создает закупочный ордер без дополнительной информации
		/// </summary>
		public PurchaseOrder()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.PurchaseOrder;
			Remarks = "";
			Description = "";
			Status = WorkPackageStatus.Opened;
			Products = new List<Product>();
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

		#region public int CompareTo(PurchaseOrder y)

		public int CompareTo(PurchaseOrder y)
		{
			return ItemId.CompareTo(y.ItemId);
		}

		#endregion

		public new PurchaseOrder GetCopyUnsaved()
		{
			var clone = (PurchaseOrder)MemberwiseClone();
			clone.ItemId = -1;
			clone.UnSetEvents();

			return clone;
		}
	}

	[JsonObject]
	public class PurchaseSettings
	{
		private DateTime _arrivalDate;
		private DateTime _receiptDate;
		private DateTime _receiptTime;
		private DateTime _arrivalTime;
		private List<PurchaseShipper> _purchaseShippers;

		public string QualificationNumber { get; set; }

		public string PickupLocation { get; set; }

		public DateTime ArrivalDate
		{
			get => _arrivalDate < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : _arrivalDate;
			set => _arrivalDate = value;
		}

		public DateTime ArrivalTime
		{
			get => _arrivalTime < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : _arrivalTime;
			set => _arrivalTime = value;
		}

		public DateTime ReceiptDate
		{
			get => _receiptDate < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : _receiptDate;
			set => _receiptDate = value;
		}

		public DateTime ReceiptTime
		{
			get => _receiptTime < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : _receiptTime;
			set => _receiptTime = value;
		}

		public double FreightPrice { get; set; }

		[DefaultValue(-1)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		public int StatusOfDeliveryId { get; set; }

		[JsonIgnore]
		public StatusOfDelivery StatusOfDelivery
		{
			get => StatusOfDelivery.GetItemById(StatusOfDeliveryId);
			set => StatusOfDeliveryId = value.ItemId;
		}

		[DefaultValue(-1)]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		public int СurrencyFreightId { get; set; }

		[JsonIgnore]
		public Сurrency СurrencyFreight
		{
			get => Сurrency.GetItemById(СurrencyFreightId);
			set => СurrencyFreightId = value.ItemId;
		}

		public List<PurchaseShipper> PurchaseShippers
		{
			get => _purchaseShippers ?? (_purchaseShippers = new List<PurchaseShipper>());
			set => _purchaseShippers = value;
		}
	}

	[JsonObject]
	[Serializable]
	public class PurchaseShipper : BaseEntityObject
	{
		public int ShipperId { get; set; }
		public double Cost { get; set; }
		public int CurrencyId { get; set; }
		public string Remark { get; set; }

		[JsonIgnore]
		public Supplier Shipper { get; set; }
		[JsonIgnore]
		public Сurrency Currency
		{
			get => Сurrency.GetItemById(CurrencyId);
			set => CurrencyId = value.ItemId;
		}
		[JsonIgnore]
		public string PONumber { get; set; }
	}

}
