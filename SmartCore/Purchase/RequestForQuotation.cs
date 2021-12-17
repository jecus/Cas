using System;
using System.Collections.Generic;
using CAS.Entity.Models.DTO.General;
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
	/// ����� ��������� ������������ ���
	/// </summary>
	[Table("RequestsForQuotation", "dbo", "ItemId")]
	[Dto(typeof(RequestForQuotationDTO))]
	[Condition("IsDeleted", "0")]
	public class RequestForQuotation : AbstractPackage<RequestForQuotationRecord>, IComparable<RequestForQuotation>, IFileContainer, ILogistic
	{

		/*
		*  ��������
		*/
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

		#region public List<Product> Products { get; set; }
		/// <summary>
		/// ������������� �������������
		/// </summary>
		public List<Product> Products { get; set; }
		#endregion

		#region public override CommonCollection<RequestForQuotationRecord> PackageRecords

		private CommonCollection<RequestForQuotationRecord> _packageRecords;
		/// <summary>
		/// �������� ������ ��������� ��� �������� �������� � �������� ������
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

		[TableColumn("AdditionalInformationJSON")]
		public string AdditionalInformationJSON
		{
			get => JsonConvert.SerializeObject(AdditionalInformation, Formatting.Indented, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
			set => AdditionalInformation = JsonConvert.DeserializeObject<QuatationSettings>(value ?? "", new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
		}

		private QuatationSettings _additionalInformation;
		public QuatationSettings AdditionalInformation
		{
			get => _additionalInformation ?? (_additionalInformation = new QuatationSettings());
			set => _additionalInformation = value;
		}


		/*
		*  ������ 
		*/

		#region public RequestForQuotation()
		/// <summary>
		/// ������� ��������� ����� ��� �������������� ����������
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
		/// ����������� ��� �������
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

	[JsonObject]
	public class QuatationSettings
	{
		private Dictionary<int, string> _qualificationNumbers;

		public Dictionary<int, string> QualificationNumbers
		{
			get => _qualificationNumbers ?? (_qualificationNumbers = new Dictionary<int, string>());
			set => _qualificationNumbers = value;
		}
	}
}
