using System;
using System.Collections.Generic;
using EntityCore.DTO.General;
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
    public class InitialOrder : AbstractPackage<InitialOrderRecord>, IComparable<InitialOrder>, IFileContainer, ILogistic
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
		private Citizenship _stationFromId;
		private Supplier _supplier;
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
