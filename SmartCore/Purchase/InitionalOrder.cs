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
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Personnel;
using SmartCore.Files;
using SmartCore.Packages;

namespace SmartCore.Purchase
{

    /// <summary>
    /// Класс описывает котировочный акт
    /// </summary>
    [Table("InitialOrders", "dbo", "ItemId")]
    [Dto(typeof(InitialOrderDTO))]
	[Condition("IsDeleted", "0")]
    public class InitialOrder : AbstractPackage<InitialOrderRecord>, IComparable<InitialOrder>, IFileContainer
	{
		/*
		*  Свойства
		*/
        /// <summary>
        /// Запрашиваемые комплектующие
        /// </summary>
        public List<Product> Products { get; set; }

        #region public override CommonCollection<InitionalOrderRecord> PackageRecords

        private CommonCollection<InitialOrderRecord> _packageRecords;
        /// <summary>
        /// Содержит массив элементов для привязки директив к рабочему пакету
        /// </summary>
        [Child(RelationType.OneToMany, "ParentPackageId")]
        public override CommonCollection<InitialOrderRecord> PackageRecords
        {
            get { return _packageRecords ?? (_packageRecords = new CommonCollection<InitialOrderRecord>()); }
            internal set
            {
                if (_packageRecords == value) 
                    return;
                if (_packageRecords != null)
                    _packageRecords.Clear();
                if (value != null)
                    _packageRecords = value;

                OnPropertyChanged("PackageRecords");
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
				return _attachedFile ?? (Files.GetFileByFileLinkType(FileLinkType.InitialOrderAttachedFile));
			}
			set
			{
				_attachedFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.InitialOrderAttachedFile);
			}
		}

		#endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;
		private TypeOfOperation _typeOfOperation;
		private ShipBy _shipBy;
		private IncoTerm _incoTerm;
		private Citizenship _stationFromId;
		private Supplier _supplier;
		private Specialist _approvedBy;
		private Specialist _publishedBy;
		private Specialist _closedBy;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1560)]
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

		#region public InitialOrder()
		/// <summary>
		/// Создает начальный акт без дополнительной информации
		/// </summary>
		public InitialOrder()
        {
            ItemId = -1;
			SmartCoreObjectType = SmartCoreType.InitialOrder;
            Remarks = "";
            Status = WorkPackageStatus.Opened;
            OpeningDate = DateTime.Today;
            PublishingDate = DateTimeExtend.GetCASMinDateTime();
            ClosingDate = DateTimeExtend.GetCASMinDateTime();
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

        #region public int CompareTo(InitialOrder y)

        public int CompareTo(InitialOrder y)
        {
            return ItemId.CompareTo(y.ItemId);
        }

		#endregion

	}

}
