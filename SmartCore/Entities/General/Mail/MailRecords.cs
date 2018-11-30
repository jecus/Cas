using System;
using System.Reflection;
using SmartCore.Auxiliary;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Personnel;
using SmartCore.Files;
using SmartCore.Purchase;

namespace SmartCore.Entities.General.Mail
{
	[Table("MailRecords", "dbo", "ItemId")]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class MailRecords : BaseEntityObject, IFileContainer
	{
		private static Type _thisType;

		#region public int DocTypeId { get; set; }

		[TableColumn("DocTypeId")]
		public int DocTypeId { get; set; }

		#endregion

		#region public int DocClassId { get; set; }

		[TableColumn("DocClassId")]
		public int DocClassId { get; set; }

		#endregion

		#region public DocumentType DocType { get; set; }
		[Filter("DocType:", Order = 6)]
		public DocumentType DocType
		{
			get { return DocumentType.GetDocumentTypeById(DocTypeId); }
			set { DocTypeId = value?.ItemId ?? -1; }
		}

		#endregion

		#region public DocumentType DocType { get; set; }
		[Filter("DocClass:", Order = 5)]
		public DocumentClass DocClass
		{
			get { return DocumentClass.GetDocumentClassById(DocClassId); }
			set { DocClassId = value?.ItemId ?? -1; }
		}

		#endregion

		#region public Supplier Supplier { get; set; }
		private Supplier _supplier;

		[Child]
		[TableColumn("SupplierId")]
		public Supplier Supplier
		{
			get { return _supplier ?? Supplier.Unknown; }
			set { _supplier = value; }
		}

		#endregion

		#region public string MailNumber { get; set; }

		[TableColumn("MailNumber")]
		[Filter("№:", Order = 2)]
		public string MailNumber { get; set; }

		#endregion

		#region public string ReferenceNumber { get; set; }

		[TableColumn("ReferenceNumber")]
		[Filter("Reference №:", Order = 3)]
		public string ReferenceNumber { get; set; }

		#endregion

		#region public string Title { get; set; }

		[TableColumn("Title")]
		[Filter("Title:", Order = 1)]
		public string Title { get; set; }

		#endregion

		#region public string Remarks { get; set; }

		[TableColumn("Remarks")]
		public string Remarks { get; set; }

		#endregion

		#region public string Description { get; set; }

		[TableColumn("Description")]
		public string Description { get; set; }

		#endregion

		#region public Boolean IsClosed { get; set; }
		[TableColumn("IsClosed")]
		public bool IsClosed { get; set; }
		#endregion

		#region public Boolean PerformeUpTo { get; set; }
		[TableColumn("PerformeUpTo")]
		public bool PerformeUpTo { get; set; }
		#endregion

		#region public Department Department { get; set; }
		private Department _department;

		[Child]
		[TableColumn("DepartmentId")]
		[Filter("Department:", Order = 7)]
		public Department Department
		{
			get { return _department ?? Department.Unknown; }
			set { _department = value; }
		}

		#endregion

		#region public Specialist Specialist { get; set; }
		private Specialist _specialist;

		[Child]
		[TableColumn("ExecutorId")]
		[Filter("Executor:", Order = 9)]
		public Specialist Specialist
		{
			get { return _specialist ?? Specialist.Unknown; }
			set { _specialist = value; }
		}

		#endregion

		#region public Specialization Specialization { get; set; }

		private Specialization _specialization;
		[Child]
		[TableColumn("ResponsibleId")]
		[Filter("Responsible:", Order = 8)]
		public Specialization Specialization
		{
			get { return _specialization ?? Specialization.Unknown; }
			set { _specialization = value; }
		}

		#endregion

		#region public Nomenclatures Nomenclature { get; set; }

		private Nomenclatures _nomenclature;
		[Child]
		[TableColumn("NomenclatureId")]
		[Filter("Nomenclature:", Order = 10)]
		public Nomenclatures Nomenclature
		{
			get { return _nomenclature ?? Nomenclatures.Unknown; }
			set { _nomenclature = value; }
		}

		#endregion

		#region public Locations Location { get; set; }

		private Locations _location;


		[TableColumn("LocationId")]
		[Filter("Nomenclature:", Order = 11)]
		public Locations Location
		{
			get { return _location ?? Locations.Unknown; }
			set { _location = value; }
		}

		#endregion

		#region public AttachedFile AttachedFile { get; set; }

		private AttachedFile _attachedFile;

		public AttachedFile AttachedFile
		{
			get { return _attachedFile ?? (Files.GetFileByFileLinkType(FileLinkType.MailFormFile)); }
			set
			{
				_attachedFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.MailFormFile);
			}
		}

		#endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1670)]
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

		#region public DateTime ReceiveMailDate { get; set; }

		[TableColumn("ReceiveMailDate")]
		[Filter("ReceiveDate:", Order = 13)]
		public DateTime ReceiveMailDate { get; set; }
		#endregion

		#region public DateTime CreateMailRecordDate { get; set; }

		[TableColumn("CreateMailRecordDate")]
		[Filter("CreateDate:", Order = 12)]
		public DateTime CreateMailRecordDate { get; set; }
		#endregion

		#region public DateTime PerformeUpToDate { get; set; }

		[TableColumn("PerformeUpToDate")]
		[Filter("PerformeUpToDate:", Order = 14)]
		public DateTime PerformeUpToDate { get; set; }

		#endregion

		#region public int RevisionNotify { get; set; }

		[TableColumn("RevisionNotify")]
		public int RevisionNotify { get; set; }

		#endregion

		#region public int ParentId { get; set; }

		[TableColumn("ParentId")]
		[Filter("Parent Reference №:", Order = 4)]
		public int ParentId { get; set; }

		#endregion

		#region public int MailChatId { get; set; }

		[TableColumn("MailChatId")]
		public int MailChatId { get; set; }

		public static PropertyInfo MailChatIdProperty
		{
			get { return GetCurrentType().GetProperty("MailChatId"); }
		}

		#endregion

		#region private static Type GetCurrentType()

		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(MailRecords));
		}

		#endregion

		#region public MailStatus Status { get; set; }

		[TableColumn("Status")]
		public MailStatus Status { get; set; }
		#endregion

		#region public DateTime PublishingDate { get; set; }

		[TableColumn("PublishingDate")]
		public DateTime PublishingDate { get; set; }
		#endregion

		#region public DateTime ClosingDate { get; set; }

		[TableColumn("ClosingDate")]
		public DateTime ClosingDate { get; set; }

		#endregion

		public MailRecords()
		{
			ReceiveMailDate = DateTime.Today;
			CreateMailRecordDate = DateTime.Today;
			PerformeUpToDate = DateTime.Today;
			PublishingDate = DateTimeExtend.GetCASMinDateTime();
			ClosingDate = DateTimeExtend.GetCASMinDateTime();
			SmartCoreObjectType = SmartCoreType.MailRecord;
		}

	}
}