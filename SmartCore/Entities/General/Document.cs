using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CAA.Entity.Models.DTO;
using CAS.Entity.Models.DTO.General;
using SmartCore.Auxiliary;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Personnel;
using SmartCore.Files;
using SmartCore.Purchase;

namespace SmartCore.Entities.General
{
	/// <summary>
	/// Класс описывает простой документ
	/// </summary>
	[Table("Documents", "dbo", "ItemId")]
	[Dto(typeof(DocumentDTO))]
	[CAADto(typeof(CAADocumentDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class Document : BaseEntityObject, IDirective, IComparable<Document>, IEquatable<Document>, IFileContainer
	{
		private static Type _thisType;

		[NonSerialized]
		private BaseEntityObject _parent;

		/*
		*  Свойства
		*/
		#region public string Description { get; set; }
		/// <summary>
		/// Описание документа
		/// </summary>
		[TableColumnAttribute("Description", 1024)]
		[ListViewData(0.18f, "Description", 5)]
		[Filter("Description:", Order = 1)]
		public string Description { get; set; }
		#endregion

		#region public Int32 ParentId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("ParentId")]
		public Int32 ParentId { get; set; }

		public static PropertyInfo ParentIdProperty
		{
			get { return GetCurrentType().GetProperty("ParentId"); }
		}

		#endregion

		#region public int ParentAircraftId { get; set; }

		[TableColumn("ParentAircraftId")]
		public int ParentAircraftId { get; set; }

		public static PropertyInfo ParentAircraftIdProperty
		{
			get { return GetCurrentType().GetProperty("ParentAircraftId"); }
		}

		#endregion

		#region public virtual Int32 ParentTypeId { get; set; }
		/// <summary>
		/// Тип родительского элемента 
		/// </summary>
		[TableColumnAttribute("ParentTypeId")]
		public Int32 ParentTypeId { get; set; }

		public static PropertyInfo ParentTypeIdProperty
		{
			get { return GetCurrentType().GetProperty("ParentTypeId"); }
		}

		#endregion

		#region public Int32 DocTypeId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("DocTypeId")]
		public Int32 DocTypeId{ get; set; }

		public static PropertyInfo DocTypeIdProperty
		{
			get { return GetCurrentType().GetProperty("DocTypeId"); }
		}

		#endregion

		#region public DocumentType DocType { get; set; }
		[ListViewData(0.18f, "Type", 1)]
		[Filter("Doc.Type:", Order = 8)]
		public DocumentType DocType
		{
			get { return DocumentType.GetDocumentTypeById(DocTypeId); }
			set { DocTypeId = value != null ? value.ItemId : -1; }
		}
		#endregion

		#region public DocumentSubType DocumentSubType { get; set; }

		private DocumentSubType _documentSubType;
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("SubTypeId")]
		[ListViewData(0.18f, "Title", 2)]
		[Filter("Title:", Order = 6)]
		public DocumentSubType DocumentSubType
		{
			get { return _documentSubType ?? (_documentSubType = DocumentSubType.Unknown); }
			set { _documentSubType = value; }
		}

		#endregion

		#region public DateTime IssueDateValidFrom { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("IssueDateValidFrom")]
		[ListViewData(0.1f, "Issue", 6)]
		[Filter("Issue:", Order = 16)]
		public DateTime IssueDateValidFrom { get; set; }
		#endregion

		#region public bool IssueValidTo{ get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("IssueValidTo")]
		public bool IssueValidTo { get; set; }
		#endregion

		#region public DateTime IssueDateValidTo { get; set; }
		/// <summary>
		/// 
		/// </summary>
		private DateTime _issueDateValidTo;
		[TableColumnAttribute("IssueDateValidTo")]
		[Filter("ValidTo:", Order = 18)]
		public DateTime IssueDateValidTo
		{
			get { return _issueDateValidTo < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : _issueDateValidTo; }
			set { _issueDateValidTo = value; }
		}
		
		[ListViewData(0.1f, "Valid To", 8)] 
		public DateTime? ListViewDateValidTo
		{
			get
			{
				if (IssueValidTo) return _issueDateValidTo;
				return null;
			}
		}
		#endregion

		#region public string ContractNumber { get; set; }

		[TableColumnAttribute("ContractNumber")]
		[ListViewData(0.12f, "№", 3)]
		[Filter("№:", Order = 2)]
		public string ContractNumber { get; set; }
		#endregion

		#region public int IssueNotify { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("IssueNotify")]
		//[ListViewData(0.1f, "Notify days:")]
		public int IssueNotify { get; set; }
		#endregion


		#region public Supplier Supplier { get; set; }
		private Supplier _supplier;

		[Child]
		[TableColumnAttribute("SupplierId")]
		[ListViewData(0.12f, "Supplier", 18)]
		[Filter("Supplier:", Order = 5)]
		public Supplier Supplier
		{
			get { return _supplier ?? Supplier.Unknown; }
			set { _supplier = value; }
		}

		#endregion

		#region public Specialization ResponsibleOccupation { get; set; }
		private Specialization _responsibleOccupation;

		[TableColumnAttribute("ResponsibleOccupationId")]
		[ListViewData(0.1f, "Responsible", 13)]
		[Filter("Responsible:", Order = 14)]
		public Specialization ResponsibleOccupation
		{
			get { return _responsibleOccupation ?? (_responsibleOccupation = Specialization.Unknown); }
			set { _responsibleOccupation = value; }
		}

		#endregion

		#region public bool Revision { get; set; }
		/// <summary>
		/// Включает ли документ ревизию
		/// </summary>
		[TableColumnAttribute("Revision")]
		public bool Revision { get; set; }
		#endregion

		#region public string RevisionNumder { get; set; }
		/// <summary>
		/// номер ревизии документа
		/// </summary>
		[TableColumnAttribute("RevNumber")]
		[ListViewData(0.1f, "Rev.№", 11)]
		public string RevisionNumder { get; set; }
		#endregion

		#region public DateTime RevisionDateFrom { get; set; }

		/// <summary>
		/// Дата ревизии
		/// </summary>
		private DateTime _revisionDate = DateTime.Today;
		[TableColumnAttribute("RevisionDateFrom")]
		[Filter("Revision:", Order = 17)]
		public DateTime RevisionDateFrom
		{
			get
			{
				DateTime check = DateTimeExtend.GetCASMinDateTime();
				if (_revisionDate < check) _revisionDate = check;
				return _revisionDate;
			}
			set { _revisionDate = value; }
		}

		[ListViewData(0.1f, "Rev. Date", 10)]
		public DateTime? ListViewRevisionDate
		{
			get
			{
				if (Revision) return _revisionDate;
				return null;
			}
		}
		#endregion

		#region public BaseSmartCoreObject Parent { get; set; }
		/// <summary>
		/// родительский объект данного KIT-а (директива, деталь и т.д.)
		/// </summary>
		[Filter("Parent:", Order = 15)]
		public BaseEntityObject Parent
		{
			get { return _parent; }
			set
			{
				_parent = value;
				ParentTypeId = value == null ? SmartCoreType.Unknown.ItemId : value.SmartCoreObjectType.ItemId;
			}
		}
		#endregion

        public int FileId => Files.FirstOrDefault(i => i.LinkType == (int)FileLinkType.DocumentAttachedFile)?.FileId ?? -1;

		#region public AttachedFile AttachedFile { get; set; }

		private AttachedFile _attachedFile;

		public AttachedFile AttachedFile
		{
			get { return _attachedFile ?? (Files.GetFileByFileLinkType(FileLinkType.DocumentAttachedFile)); }
			set
			{
				_attachedFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.DocumentAttachedFile);
			}
		}

		#endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

		//[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1275)]
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

		#region public ProlongationWay ProlongationWay { get; set; }

		[TableColumn("ProlongationWayId")]
		[ListViewData(0.12f, "Prolongation", 17)]
		[Filter("Prolongation:", Order = 9)]
		public ProlongationWay ProlongationWay { get; set; }

		#endregion

		#region public Nomenclatures Nomenсlature { get; set; }

		private Nomenclatures _nomenсlature;

		[TableColumn("NomenсlatureId")]
		[ListViewData(0.1f, "Location", 16)]
		[Filter("Nomenсlature:", Order = 7)]
		[Child]
		public Nomenclatures Nomenсlature
		{
			get { return _nomenсlature ?? (_nomenсlature = Nomenclatures.Unknown); }
			set { _nomenсlature = value; }
		}

		#endregion

		#region public ServiceType ServiceType { get; set; }

		private ServiceType _serviceType;

		[TableColumn("ServiceTypeId")]
		[ListViewData(0.12f, "Service Type", 14)]
		[Filter("Service Type:", Order = 10)]
		[Child]
		public ServiceType ServiceType
		{
			get { return _serviceType ?? (_serviceType = ServiceType.Unknown); }
			set { _serviceType = value; }
		}

		#endregion

		#region public Department Department { get; set; }

		private Department _department;

		[TableColumn("DepartmentId")]
		[ListViewData(0.1f, "Department", 12)]
		[Filter("Department:", Order = 12)]
		[Child]
		public Department Department
		{
			get { return _department ?? (_department = Department.Unknown); }
			set { _department = value; }
		}

		#endregion

		#region public bool RevisionValidTo { get; set; }

		[TableColumn("RevisionValidTo")]
		public bool RevisionValidTo { get; set; }

		#endregion

		#region public DateTime RevisionDateValidTo { get; set; }

		private DateTime _revisionDateValidTo;

		[TableColumn("RevisionDateValidTo")]
		[ListViewData(0.10f, "ValidTo", 21)]
		[Filter("ValidTo:", Order = 19)]
		public DateTime RevisionDateValidTo
		{
			get { return _revisionDateValidTo < DateTimeExtend.GetCASMinDateTime() ? DateTimeExtend.GetCASMinDateTime() : _revisionDateValidTo; }
			set { _revisionDateValidTo = value; }
		}

		#endregion

		#region public int RevisionNotify { get; set; }

		[TableColumn("RevisionNotify")]
		public int RevisionNotify { get; set; }

		#endregion

		#region public bool Aboard { get; set; }

		[TableColumn("Aboard")]
		[ListViewData(0.1f, "Aboard", 15)]
		[Filter("Aboard:", Order = 23)]
		public bool Aboard { get; set; }

		#endregion

		[TableColumn("Privy")]
		public bool Privy { get; set; }


		#region public int IssueNumber { get; set; }

		[TableColumn("IssueNumber")]
		[ListViewData(0.1f, "Issue №", 7)]
		public string IssueNumber { get; set; }

		#endregion

		#region public int Remarks { get; set; }

		[TableColumn("Remarks")]
		[ListViewData(0.1f, "Remarks", 20)]
		[Filter("Remarks:", Order = 3)]
		public string Remarks { get; set; }

		#endregion

		#region public Lifelength RemainsRevision { get; set; }

		private Lifelength _revisionRemains;

		[ListViewData(0.10f, "RevisionRemains", 22)]
		[Filter("ValidTo:", Order = 21)]
		public Lifelength RevisionRemains
		{
			get { return _revisionRemains; }
			set { _revisionRemains = value; }
		}

		#endregion

		#region public Specialist Specialist { get; set; }

		[Filter("Specialist:", Order = 24)]
		public Specialist Specialist { get; set; }

		#endregion

		#region public Locations Location { get; set; }

		private Locations _location;

		/// <summary>
		/// 
		/// </summary>
		[TableColumn("LocationId")]
		public Locations Location
		{
			get { return _location ?? Locations.Unknown; }
			set { _location = value; }
		}

		#endregion

		public bool HaveFile => Files?.Any() ?? false;

		#region public string IDNumber { get; set; }
		[Filter("ID №:", Order = 4)]
		[TableColumnAttribute("IdNumber")]
		public string IdNumber { get; set; }
		#endregion


        public int? Author { get; set; }

		#region Implement of IMathData
		//Своиства интерфеися IMathData, они содержат вычисления мат аппарата для объектов
		//у всех директив, деталей чеков и т.д. можно вычислить их текущее сотояние
		// дату след. выполнения и наработку на которой это выполнение произоидет

		#region BaseSmartCoreObject LifeLenghtParent { get; }
		/// <summary>
		/// Возвращает объект, для которого можно расчитать текущую наработку. Обычно Aircraft, BaseComponent или Component
		/// </summary>
		public BaseEntityObject LifeLengthParent
		{
			get { return null; }
		}
		#endregion

		#region IThreshold IDirective.Threshold { get; set; }
		/// <summary>
		/// порог первого и посделующего выполнений
		/// </summary>
		IThreshold IDirective.Threshold { get; set; }
		#endregion

		#region IRecordCollection IDirective.PerformanceRecords { get; }
		/// <summary>
		/// Коллекция содержит все записи о выполнении директивы
		/// </summary>
		IRecordCollection IDirective.PerformanceRecords{ get { return null; } }
		#endregion

		#region AbstractPerformanceRecord IDirective.LastPerformance { get; }
		/// <summary>
		/// Доступ к последней записи о выполнении задачи
		/// </summary>
		AbstractPerformanceRecord IDirective.LastPerformance { get { return null; } }
		#endregion

		#region public List<NextPerformance> NextPerformances { get; set; }
		/// <summary>
		/// Список последующих выполнений задачи
		/// </summary>
		public List<NextPerformance> NextPerformances { get; set; }
		#endregion

		#region  public NextPerformance NextPerformance { get; }
		/// <summary>
		/// След. выполнение задачи
		/// </summary>
		public NextPerformance NextPerformance
		{
			get
			{
				return null;
			}
		}
		#endregion

		#region public ConditionState Condition { get; set; }
		/// <summary>
		/// Текущее состояние
		/// </summary>
		[Filter("Condition:", Order = 13)]
		public ConditionState Condition { get; set; }
		#endregion

		#region public DirectiveStatus Status { get; }
		/// <summary>
		/// Статус директивы
		/// </summary>       
		[ListViewData(0.1f, "Status", 19)]
		[Filter("Status:", Order = 11)]
		public DirectiveStatus Status
		{
			get
			{
				if (IsClosed) return DirectiveStatus.Closed; //директива принудительно закрыта пользователем
				return DirectiveStatus.Open;
			}
		}
		#endregion

		#region public Lifelength NextCompliance { get; set; }
		/// <summary>
		/// Наработка, при которой произоидет следующее выполнение
		/// </summary>
		public Lifelength NextPerformanceSource { get; set; }
		#endregion

		#region public Lifelength Remains { get; set; }

		/// <summary>
		/// Остаток ресурса до следующего выполнения
		/// </summary>
		private Lifelength _remains;

		[ListViewData(0.10f, "Remain", 9)]
		[Filter("Remains:", Order = 20)]
		public Lifelength Remains
		{
			get { return _remains; }
			set { _remains = value; }
		}
		#endregion

		#region public Lifelength BeforeForecastResourceRemain { get; set; }
		/// <summary>
		/// Остаток ресурса до прогноза (вычисляется только в прогнозе)
		/// </summary>
		public Lifelength BeforeForecastResourceRemain { get; set; }
		#endregion

		#region public Lifelength ForecastLifelength { get; set; }
		//ресурс прогноза
		public Lifelength ForecastLifelength { get; set; }
		#endregion

		#region public Lifelength AfterForecastResourceRemain { get; set; }
		/// <summary>
		/// Остаток ресурса после прогноза (вычисляется только в прогнозе)
		/// </summary>
		public Lifelength AfterForecastResourceRemain { get; set; }
		#endregion

		#region public DateTime? NextComplianceDate{ get; set; }
		/// <summary>
		/// Дата следующего выполнения
		/// </summary>
		public DateTime? NextPerformanceDate { get; set; }
		#endregion

		#region public double? Percents { get; set; }
		/// <summary>
		/// Насколько процентов NextCompliance превосходит точку прогноза
		/// </summary>
		public double? Percents { get; set; }
		#endregion

		#region public string TimesToString { get; }
		/// <summary>
		/// Возвращает строковое представление количества "след. выполнений"
		/// </summary>
		public string TimesToString
		{
			get { return Times <= 1 ? "" : Times + " times"; }
		}
		#endregion

		#region public Int32 Times { get;}
		/// <summary>
		/// Сколько раз выполнится директива (применяетмя только в прогнозах)
		/// </summary>
		public Int32 Times
		{
			get { return 0; }
		}
		#endregion

		#region public Boolean IsClosed { get; set; }
		/// <summary>
		/// Логический флаг, показывающий, закрыта ли директива
		/// </summary>
		[TableColumn("IsClosed")]
		public Boolean IsClosed { get; set; }
		#endregion

		#region public Boolean NextPerformanceIsBlocked { get; }
		///
		/// Логический флаг, показывающий, заблокирована ли директивы рабочим пакетом
		/// 
		public Boolean NextPerformanceIsBlocked
		{
			get
			{
				return false;
			}
		}

		#endregion

		#region public void ResetMathData()
		public void ResetMathData()
		{
			Condition = ConditionState.NotEstimated;
			NextPerformanceSource = null;
			Remains = null;
			BeforeForecastResourceRemain = null;
			AfterForecastResourceRemain = null;
			NextPerformanceDate = null;
		}
		#endregion

		#endregion

		#region Implement IPrintSettings

		#region public bool PrintInWorkPackage { get; set; }
		/// <summary>
		/// Возвращает или задает значение, показвающее настройку печати элемента в Рабочем пакете
		/// </summary>
		public bool PrintInWorkPackage { get; set; }
		#endregion

		#region public bool WorkPackageACCPrintTitle { get; set; }
		/// <summary>
		/// Возвращает или задает значение, показвающее печать НАЗВАНИЯ задачи в AccountabilitySheet рабочего пакета
		/// </summary>
		public bool WorkPackageACCPrintTitle { get; set; }
		#endregion

		#region public bool WorkPackageACCPrintTaskCard { get; set; }
		/// <summary>
		/// Возвращает или задает значение, показвающее печать РАБОЧЕЙ КАРТЫ задачи в AccountabilitySheet рабочего пакета
		/// </summary>
		public bool WorkPackageACCPrintTaskCard { get; set; }

		#endregion

		#endregion

		/*
		*  Методы 
		*/
		
		#region public Document()
		/// <summary>
		/// Создает простой документ без дополнительной информации
		/// </summary>
		public Document()
		{
			ItemId = -1;
			ParentId = -1;
			DocType = DocumentType.Other;
			SmartCoreObjectType = SmartCoreType.Document;

			_parent = new BaseEntityObject();
		}
		#endregion

		#region public override string ToString()
		/// <summary>
		/// Перегружаем для отладки
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			string res = "";
			if (DocType != null) res += DocType + " ";
			if (DocumentSubType != null) res += DocumentSubType + " ";
			res += Description;

			return res;
		}
		#endregion   

		#region public void SetProperties(Document doc)
		public void SetProperties(Document doc)
		{
			DocType = doc.DocType;
			DocumentSubType = doc.DocumentSubType;
			Description = doc.Description;
			Department = doc.Department;
			Nomenсlature = doc.Nomenсlature;
			IssueDateValidFrom = doc.IssueDateValidFrom;
			IssueValidTo = doc.IssueValidTo;
			IssueDateValidTo = doc.IssueDateValidTo;
			IssueNotify = doc.IssueNotify;
			IssueNumber = doc.IssueNumber;
			Revision = doc.Revision;
			RevisionDateFrom = doc.RevisionDateFrom;
			RevisionNumder = doc.RevisionNumder;
			ContractNumber = doc.ContractNumber;
			Supplier = doc.Supplier;
			ProlongationWay = doc.ProlongationWay;
			ServiceType = doc.ServiceType;
			Remarks = doc.Remarks;
			ResponsibleOccupation = doc.ResponsibleOccupation;
		}
		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(Document));
		}
		#endregion

		#region public int CompareTo(Document y)

		public int CompareTo(Document y)
		{
			return ItemId.CompareTo(y.ItemId);
		}

		#endregion

		#region public override int CompareTo(object y)
		public override int CompareTo(object y)
		{
			if (y is Document) return ItemId.CompareTo(((Document)y).ItemId);
			return 0;
		}
		#endregion

		#region public bool Equals(Document other)
		public bool Equals(Document other)
		{

			//Check whether the compared object is null.
			if (ReferenceEquals(other, null)) return false;

			//Check whether the compared object references the same data.
			if (ReferenceEquals(this, other)) return true;

			//Check whether the products' properties are equal.
			return ItemId == other.ItemId;
		}
		#endregion

		#region public override int GetHashCode()
		public override int GetHashCode()
		{
			return ItemId.GetHashCode();
		}
		#endregion

		#region public new Document GetCopyUnsaved()

		public new Document GetCopyUnsaved(bool marked = true)
		{
			var document = (Document) MemberwiseClone();
			document.ItemId = -1;
			document.UnSetEvents();

			if(marked)
				document.ContractNumber += " Copy";

			document._files = new CommonCollection<ItemFileLink>();
			foreach (var file in Files)
			{
				var newObject = file.GetCopyUnsaved(marked);
				document._files.Add(newObject);
			}

			return document;
		}

		#endregion

	}
}
