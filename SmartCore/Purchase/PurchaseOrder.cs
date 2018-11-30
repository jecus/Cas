using System;
using System.Collections.Generic;
using System.Linq;
using EFCore.DTO.General;
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
    /// Класс описывает закупочный ордер
    /// </summary>
    [Table("PurchaseOrders", "dbo", "ItemId")]
    [Dto(typeof(PurchaseOrderDTO))]
	[Condition("IsDeleted", "0")]
    public class PurchaseOrder : AbstractPackage<PurchaseRequestRecord>, IComparable<PurchaseOrder>, IFileContainer
	{

		/*
		*  Свойства
		*/

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
	}
}
