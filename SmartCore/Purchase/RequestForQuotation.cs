using System;
using System.Collections.Generic;
using System.Linq;
using EFCore.DTO.General;
using SmartCore.Auxiliary;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Entities;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Personnel;
using SmartCore.Files;
using SmartCore.Packages;

namespace SmartCore.Purchase
{

    /// <summary>
    /// Класс описывает котировочный акт
    /// </summary>
    [Table("RequestsForQuotation", "dbo", "ItemId")]
    [Dto(typeof(RequestForQuotationDTO))]
	[Condition("IsDeleted", "0")]
    public class RequestForQuotation : AbstractPackage<RequestForQuotationRecord>, IComparable<RequestForQuotation>, IFileContainer
	{

		/*
		*  Свойства
		*/

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

        #region public List<Product> Products { get; set; }
        /// <summary>
        /// Запрашиваемые комплектующие
        /// </summary>
        public List<Product> Products { get; set; }
        #endregion

        #region public override CommonCollection<RequestForQuotationRecord> PackageRecords

        private CommonCollection<RequestForQuotationRecord> _packageRecords;
        /// <summary>
        /// Содержит массив элементов для привязки директив к рабочему пакету
        /// </summary>
        [Child(RelationType.OneToMany, "ParentPackageId")]
        public override CommonCollection<RequestForQuotationRecord> PackageRecords
        {
            get { return _packageRecords ?? (_packageRecords = new CommonCollection<RequestForQuotationRecord>()); }
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

		#region public AttachedFile AttachedFile { get; set; }

		private AttachedFile _attachedFile;

		/// <summary>
		/// 
		/// </summary>
		public AttachedFile AttachedFile
		{
			get
			{
				return _attachedFile ?? (Files.GetFileByFileLinkType(FileLinkType.RequestForQuotationAttachedFile));
			}
			set
			{
				_attachedFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.RequestForQuotationAttachedFile);
			}
		}

		#endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1900)]
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

		private TypeOfOperation _typeOfOperation;
		private ShipBy _shipBy;
		private IncoTerm _incoTerm;
		private Citizenship _stationFromId;
		private Supplier _supplier;
		private Specialist _approvedBy;
		private Specialist _publishedBy;
		private Specialist _closedBy;

		[TableColumn("TypeOfOperation")]
		public TypeOfOperation TypeOfOperation
		{
			get { return _typeOfOperation ?? TypeOfOperation.UNK; }
			set { _typeOfOperation = value; }
		}

		[TableColumn("ShipBy")]
		public ShipBy ShipBy
		{
			get { return _shipBy ?? ShipBy.UNK; }
			set { _shipBy = value; }
		}

		[TableColumn("IncoTerm")]
		public IncoTerm IncoTerm
		{
			get { return _incoTerm ?? IncoTerm.UNK; }
			set { _incoTerm = value; }
		}

		[TableColumn("CountryId")]
		public Citizenship Country
		{
			get { return _stationFromId ?? Citizenship.UNK; }
			set { _stationFromId = value; }
		}

		[TableColumn("CarrierId")]
		public Supplier Supplier
		{
			get { return _supplier ?? Supplier.Unknown; }
			set { _supplier = value; }
		}

		[TableColumn("RFQ")]
		public string RFQ { get; set; }

		[TableColumn("QR")]
		public string QR { get; set; }

		[TableColumn("PO")]
		public string PO { get; set; }

		[TableColumn("Invoice")]
		public string Invoice { get; set; }

		[TableColumn("Weight")]
		public string Weight { get; set; }

		[TableColumn("DIMS")]
		public string DIMS { get; set; }

		[TableColumn("ShipTo")]
		public string ShipTo { get; set; }

		[TableColumn("PickUp")]
		public string PickUp { get; set; }

		[TableColumn("ApprovedById")]
		public Specialist ApprovedBy
		{
			get { return _approvedBy ?? Specialist.Unknown; }
			set { _approvedBy = value; }
		}

		[TableColumn("PublishedById")]
		public Specialist PublishedBy
		{
			get { return _publishedBy ?? Specialist.Unknown; }
			set { _publishedBy = value; }
		}

		[TableColumn("ClosedById")]
		public Specialist ClosedBy
		{
			get { return _closedBy ?? Specialist.Unknown; }
			set { _closedBy = value; }
		}


		/*
		*  Методы 
		*/

		#region public RequestForQuotation()
		/// <summary>
		/// Создает воздушное судно без дополнительной информации
		/// </summary>
		public RequestForQuotation()
        {
            ItemId = -1;
			SmartCoreObjectType = SmartCoreType.RequestForQuotation;
            Remarks = "";
            Status = WorkPackageStatus.Opened;
            OpeningDate = DateTime.Today;
            PublishingDate = DateTimeExtend.GetCASMinDateTime();
            ClosingDate = DateTimeExtend.GetCASMinDateTime();
            Products = new List<Product>();
        }
        #endregion
      
        /// <summary>
        /// Перегружаем для отладки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "";
        }

        public int CompareTo(RequestForQuotation y)
        {
            return ItemId.CompareTo(y.ItemId);
        }

	}
}
