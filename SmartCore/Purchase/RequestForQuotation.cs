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
	public class RequestForQuotation : AbstractPackage<RequestForQuotationRecord>, IComparable<RequestForQuotation>, IFileContainer, ILogistic
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

		[TableColumn("AdditionalInformation")]
		public string AdditionalInformation { get; set; }


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
