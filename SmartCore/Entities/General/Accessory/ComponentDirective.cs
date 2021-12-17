using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CAS.Entity.Models.DTO.General;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Calculations.MTOP;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.MTOP;
using SmartCore.Entities.General.Templates;
using SmartCore.Files;
using SmartCore.Purchase;
using SmartCore.Relation;

namespace SmartCore.Entities.General.Accessory
{

	/// <summary>
	/// �����, ��������� ������ ��� ����������
	/// </summary>
	[Serializable]
	[Table("ComponentDirectives", "dbo", "ItemId")]
	[Dto(typeof(ComponentDirectiveDTO))]
	[Condition("IsDeleted", "0")]
	public class ComponentDirective: BaseEntityObject, IKitRequired, IEngineeringDirective, IComponentFilterParams, IStoreFilterParam, 
		IComparable<ComponentDirective>, IFileContainer, IBindedItem, IWorkPackageItemFilterParams, IAtaSorted, IMtopCalc, IMtopFilterParams
	{

		private static Type _thisType;
		/*
		*  �������� �� ���� ������
		*/

		#region public int ComponentId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("ComponentId")]
		public int ComponentId { get; set; }

		public static PropertyInfo ComponentIdProperty
		{
			get { return GetCurrentType().GetProperty("ComponentId"); }
		}
		#endregion

		#region public Int32 DirectiveTypeId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		//[TableColumnAttribute("DirectiveTypeId")]
		public Int32 DirectiveTypeId { get; set; }
		#endregion

		#region public String Remarks { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("Remarks")]
		public String Remarks { get; set; }
		#endregion

		#region public String HiddenRemarks { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("HiddenRemarks")]
		public String HiddenRemarks { get; set; }

		#endregion

		#region public string ZoneArea { get; set; }

		[TableColumn("ZoneArea")]
		public string ZoneArea { get; set; }

		#endregion

		#region public string AccessDirective { get; set; }

		[TableColumn("AccessDirective")]
		public string AccessDirective { get; set; }

		#endregion

		#region public string AAM { get; set; }

		[TableColumn("AAM")]
		public string AAM { get; set; }

		#endregion

		#region public string CMM { get; set; }

		[TableColumn("CMM")]
		public string CMM { get; set; }

		#endregion

		#region public Highlight Highlight { get; set; }

		/// <summary>
		/// ���������
		/// </summary>
		public Highlight Highlight { get; set; }

		#endregion

		#region public String KitRequired { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("KitRequired")]
		public String KitRequired { get; set; }
		#endregion

		#region public Int32 FaaFormFileId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Int32 FaaFormFileId { get; set; }
		#endregion

		#region public Attachement FaaFormFile { get; set; }
		[NonSerialized]
		private AttachedFile _faaFormFile;
		/// <summary>
		/// 
		/// </summary>
		public AttachedFile FaaFormFile
		{
			get
			{
				return _faaFormFile ?? (Files.GetFileByFileLinkType(FileLinkType.FaaFormFile));
			}
			set
			{
				_faaFormFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.FaaFormFile);
			}
		}

		#endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 2)]
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
		 * �������������� ��������
		 */

		#region public NDTType NDTType { get; set; }

		/// <summary>
		/// ��� ������������� Non-Destructive-Test
		/// </summary>
		[TableColumn("NDTType")]
		public NDTType NDTType { get; set; }

		#endregion

		#region public ComponentDirectiveThreshold Threshold { get; set; }

		private ComponentDirectiveThreshold _threshold;
		/// <summary>
		/// ������� ���������� ���������
		/// </summary>
		[TableColumnAttribute("Threshold")]
		public ComponentDirectiveThreshold Threshold
		{
			get { return _threshold ?? (_threshold = new ComponentDirectiveThreshold()); }
			set { _threshold = value; }
		}
		#endregion

		[TableColumnAttribute("ExpiryRemainNotify")]
		public Lifelength ExpiryRemainNotify { get; set; }

		#region public Component ParentComponent { get; internal set; }
		/// <summary>
		/// �������, ��� �������� ������ ������ ������ - ����� �������� ��� �������� ParentComponent � ParentBaseComponent - ���� �� ��� ����� null
		/// </summary>
		public Component ParentComponent { get;  set; }
		#endregion

		//TODO:(Evgenii Babak) ������� ��������
		#region public MaintenanceDirective MaintenanceDirective { get; set; }
		/// <summary>
		/// ��������� ��������� ������������, � ������� ������� ������ ������ �� ����������
		/// </summary>
		public MaintenanceDirective MaintenanceDirective { get; set; }
		#endregion

		#region public MaintenanceDirectiveTaskType MPDTaskType { get; set; }

		private MaintenanceDirectiveTaskType _mpdTaskType;
		/// <summary>
		/// ��� ���������
		/// </summary>
		[TableColumnAttribute("MPDTaskTypeId")]
		public MaintenanceDirectiveTaskType MPDTaskType
		{
			get { return _mpdTaskType ?? (_mpdTaskType = MaintenanceDirectiveTaskType.Unknown); }
			set { _mpdTaskType = value; }
		}
		#endregion

		#region public ComponentRecordType DirectiveType  { get; set; }
		/// <summary>
		/// ��� ���������
		/// </summary>
		[TableColumnAttribute("DirectiveType")]
		public ComponentRecordType DirectiveType  
		{
			get { return ComponentRecordType.GetItemById(DirectiveTypeId); }
			set
			{
				DirectiveTypeId = value != null ? value.ItemId : -1;
			}
		}
		#endregion

		#region public DirectiveRecordsCollection PerformanceRecords { get; internal set; }
		private BaseRecordCollection<DirectiveRecord> _performanceRecords;
		/// <summary>
		/// ��������� �������� ��� ������ � ���������� ���������
		/// </summary>
		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 2, "Parent")]
		public BaseRecordCollection<DirectiveRecord> PerformanceRecords
		{
			get { return _performanceRecords ?? ( _performanceRecords = new BaseRecordCollection<DirectiveRecord>() ); }
			internal set { _performanceRecords = value; }
		}
		#endregion

		#region public DirectiveRecord LastPerformance { get; }
		/// <summary>
		/// ��������� ���������� ���������
		/// </summary>
		public DirectiveRecord LastPerformance { get { return PerformanceRecords.GetLast(); } }
		#endregion

		#region public DirectiveStatus Status { get; }
		/// <summary>
		/// ������ ���������
		/// </summary>
		public DirectiveStatus Status
		{
			get
			{
				if (IsClosed) return DirectiveStatus.Closed; //��������� ������������� ������� �������������
				if (LastPerformance == null)
				{
					if (!_threshold.FirstPerformanceSinceNew.IsNullOrZero() || 
						!_threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
						return DirectiveStatus.Open;

					return DirectiveStatus.NotApplicable;
				}

				if (_threshold.RepeatInterval.IsNullOrZero()) return DirectiveStatus.Closed;

				return DirectiveStatus.Repetative;
			}
		}
		#endregion

		#region Implement of IEngineeringDirective
		//�������� ���������� IMathData, ��� �������� ���������� ��� �������� ��� ��������
		//� ���� ��������, ������� ����� � �.�. ����� ��������� �� ������� ��������
		// ���� ����. ���������� � ��������� �� ������� ��� ���������� ����������

		#region String Title { get; }

		/// <summary>
		/// �������� ���������
		/// </summary>
		public String Title
		{
			get { return PartNumber; }
		}
		#endregion

		#region String Zone { get; }
		/// <summary>
		/// ����
		/// </summary>
		public String Zone { get; set; }
		#endregion

		#region String Access { get; }
		/// <summary>
		/// ������
		/// </summary>
		public String Access { get; set; }
		#endregion

		#region public MaintenanceDirectiveProgramType Program { get; }

		/// <summary>
		/// ��������� ������������
		/// </summary>
		public MaintenanceDirectiveProgramType Program
		{
			get { return MaintenanceDirective != null ? MaintenanceDirective.Program : MaintenanceDirectiveProgramType.Unknown; }
		}
		#endregion

		#region public StaticDictionary WorkType { get; }
		/// <summary>
		/// ���/��� �����
		/// </summary>
		StaticDictionary IEngineeringDirective.WorkType { get { return DirectiveType; } }
		#endregion

		#region public String Phase { get; }
		/// <summary>
		/// ����
		/// </summary>
		public String Phase { get; set; }
		#endregion

		#region public CommonCollection<CategoryRecord> CategoriesRecords

		private CommonCollection<CategoryRecord> _aircraftWorkerCategories;
		/// <summary>
		/// 
		/// </summary>
		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 2, "Parent")]
		public CommonCollection<CategoryRecord> CategoriesRecords
		{
			get { return _aircraftWorkerCategories ?? (_aircraftWorkerCategories = new CommonCollection<CategoryRecord>()); }
			internal set
			{
				if (_aircraftWorkerCategories != value)
				{
					if (_aircraftWorkerCategories != null)
						_aircraftWorkerCategories.Clear();
					if (value != null)
						_aircraftWorkerCategories = value;
				}
			}
		}
		#endregion

		#region BaseSmartCoreObject LifeLenghtParent { get; }
		/// <summary>
		/// ���������� ������, ��� �������� ����� ��������� ������� ���������. ������ Aircraft, BaseComponent ��� Component
		/// </summary>
		public BaseEntityObject LifeLengthParent
		{
			get { return ParentComponent; }
		}
		#endregion

		#region IThreshold IDirective.Threshold { get; set; }
		/// <summary>
		/// ����� ������� � ������������ ����������
		/// </summary>
		IThreshold IDirective.Threshold
		{
			get { return _threshold; }
			set { _threshold = value as ComponentDirectiveThreshold; }
		}
		#endregion

		#region IRecordCollection IDirective.PerformanceRecords { get; set; }
		/// <summary>
		/// ��������� �������� ��� ������ � ���������� ���������
		/// </summary>
		IRecordCollection IDirective.PerformanceRecords
		{
			get { return _performanceRecords; }
		}
		#endregion

		#region AbstractPerformanceRecord IDirective.LastPerformance { get; }
		/// <summary>
		/// ������ � ��������� ������ � ���������� ������
		/// </summary>
		AbstractPerformanceRecord IDirective.LastPerformance { get { return PerformanceRecords.GetLast(); } }
		#endregion
		
		#region public List<NextPerformance> NextPerformances { get; set; }
		
		private List<NextPerformance> _nextPerformances;
		/// <summary>
		/// ������ ����������� ���������� ������
		/// </summary>
		public List<NextPerformance> NextPerformances
		{
			get { return _nextPerformances ?? (_nextPerformances = new List<NextPerformance>()); }
		}
		#endregion

		#region  public NextPerformance NextPerformance { get; }
		/// <summary>
		/// ����. ���������� ������
		/// </summary>
		public NextPerformance NextPerformance
		{
			get
			{
				if (_nextPerformances == null || _nextPerformances.Count == 0)
					return null;
				return _nextPerformances[0];
			}
		}
		#endregion

		#region public ConditionState Condition { get; set; }
		/// <summary>
		/// ���������� ��������� ���������� ���������� ������ (���� ��� ���������) ��� ConditionState.NotEstimated
		/// </summary>
		public ConditionState Condition
		{
			get
			{
				if (_nextPerformances == null || _nextPerformances.Count == 0) return ConditionState.NotEstimated;
				return _nextPerformances[0].Condition;
			}
		}
		#endregion

		#region public Lifelength NextCompliance { get; }

		/// <summary>
		/// ���������� ������ ���������� ���������� ������ (���� ��� ���������) ��� Lifelength.Null
		/// </summary>
		public Lifelength NextPerformanceSource
		{
			get
			{
				if (_nextPerformances == null || _nextPerformances.Count == 0) return Lifelength.Null;
				return _nextPerformances[0].PerformanceSource;
			}
		}
		#endregion

		#region public Lifelength Remains { get; set; }
		/// <summary>
		/// ���������� ������� ������� �� ���������� ���������� ������ (���� ��� ���������) ��� Lifelength.Null
		/// </summary>
		public Lifelength Remains
		{
			get
			{
				if (_nextPerformances == null || _nextPerformances.Count == 0) return Lifelength.Null;
				return _nextPerformances[0].Remains;
			}
		}
		#endregion

		#region public Lifelength BeforeForecastResourceRemain { get; set; }
		/// <summary>
		/// ������� ������� �� �������� (����������� ������ � ��������)
		/// </summary>
		public Lifelength BeforeForecastResourceRemain
		{
			get
			{
				if (_nextPerformances == null || _nextPerformances.Count == 0) return Lifelength.Null;
				return _nextPerformances[0].BeforeForecastResourceRemain;
			}
		}
		#endregion

		#region public Lifelength ForecastLifelength { get; set; }
		//������ ��������
		public Lifelength ForecastLifelength { get; set; }
		#endregion

		#region public Lifelength AfterForecastResourceRemain { get; set; }
		/// <summary>
		/// ������� ������� ����� �������� (����������� ������ � ��������)
		/// </summary>
		public Lifelength AfterForecastResourceRemain { get; set; }
		#endregion

		#region public DateTime? NextComplianceDate{ get; set; }
		/// <summary>
		/// ���������� �������������� ���� ���������� ���������� ������ (���� ��� ���������) ��� null
		/// </summary>
		public DateTime? NextPerformanceDate
		{
			get
			{
				if (_nextPerformances == null || _nextPerformances.Count == 0) return null;
				return _nextPerformances[0].PerformanceDate;
			}
		}
		#endregion

		#region public double? Percents { get; set; }
		/// <summary>
		/// ��������� ��������� NextCompliance ����������� ����� ��������
		/// </summary>
		public double? Percents { get; set; }
		#endregion

		#region public string TimesToString { get; }
		/// <summary>
		/// ���������� ��������� ������������� ���������� "����. ����������"
		/// </summary>
		public string TimesToString
		{
			get { return Times <= 1 ? "" : Times + " times"; }
		}
		#endregion

		#region public Int32 Times { get;}
		/// <summary>
		/// ������� ��� ���������� ��������� (����������� ������ � ���������)
		/// </summary>
		public Int32 Times
		{
			get { return _nextPerformances.Count > 1 ? _nextPerformances.Count : -1; }
		}
		#endregion

		#region public Double ManHours { get; set; }
		/// <summary>
		/// �������� �����������
		/// </summary>
		[TableColumnAttribute("ManHours")]
		public Double ManHours { get; set; }

		public static PropertyInfo ManHoursProperty
		{
			get { return GetCurrentType().GetProperty("ManHours"); }
		}
		#endregion

		#region Double Elapsed { get; set; }
		/// <summary>
		/// �������� ������ ����������� 
		/// </summary>
		public Double Elapsed { get; set; }
		#endregion

		#region public int Mans { get; set; }
		/// <summary>
		/// ���������� ����������� ��� ���������� ������
		/// </summary>
		public int Mans { get; set; }
		#endregion

		#region public Double Cost { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumnAttribute("Cost")]
		public Double Cost { get; set; }
		#endregion

		#region public Boolean IsClosed { get; set; }
		/// <summary>
		/// ���������� ����, ������������, ������� �� ���������
		/// </summary>
		[TableColumnAttribute("IsClosed")]
		public Boolean IsClosed { get; set; }
		#endregion

		#region public DateTime ExpiryDate { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[TableColumn("ExpiryDate")]
		public DateTime? ExpiryDate { get; set; }
		#endregion

		#region public Boolean IsExpiry { get; set; }
		
		[TableColumnAttribute("IsExpiry")]
		public Boolean IsExpiry { get; set; }

		#endregion

		public string Reference => ParentComponent?.Reference;
		public string IsEffectivity => ParentComponent?.IsEffectivity;
		public string ALTPartNumber => ParentComponent?.ALTPartNumber;
		public string Name => ParentComponent?.Name;
		public GoodStandart Standart => ParentComponent?.Standart;

		#region public Boolean NextPerformanceIsBlocked { get; }
		/// <summary>
		/// ���������� ����, ������������, ������������� �� ����. ����������� ��������� ������� �������
		/// </summary>
		public Boolean NextPerformanceIsBlocked
		{
			get
			{
				if (_nextPerformances == null || _nextPerformances.Count == 0) return false;
				return _nextPerformances[0].BlockedByPackage != null;
			}
		}

		#endregion

		#region public void ResetMathData()
		public void ResetMathData()
		{
			AfterForecastResourceRemain = null;
			NextPerformances.Clear();
		}
		#endregion

		#endregion

		#region Implement of IKitRequired

		#region public string KitParentString { get; }
		/// <summary>
		/// ���������� ������ ��� �������� �������� ����
		/// </summary>
		public string KitParentString
		{
			get
			{
				if (ParentComponent != null)
				{
					return $"Compnt. dir.:{ParentComponent} {ParentComponent.Description}:{DirectiveType}";
				}
				return $"Compnt. dir.:{DirectiveType}";
			}
		}
		#endregion

		#region  public CommonCollection<AccessoryRequired> Kits
		
		private CommonCollection<AccessoryRequired> _kits;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 2, "ParentObject")]
		public CommonCollection<AccessoryRequired> Kits
		{
			get { return _kits ?? (_kits = new CommonCollection<AccessoryRequired>()); }
			internal set
			{
				if (_kits != value)
				{
					if (_kits != null)
						_kits.Clear();
					if (value != null)
						_kits = value;
				}
			}
		}
		#endregion

		#endregion

		#region Implement of IComponentFilterParams

		#region public string PartNumber { get; }
		/// <summary>
		/// �������� ����� ������������� ��������
		/// </summary>
		public string PartNumber
		{
			get { return ParentComponent != null ? ParentComponent.PartNumber : ""; }
		}
		#endregion

		#region public string SerialNumber { get; }
		/// <summary>
		/// �������� ����� ������������� ���������
		/// </summary>
		public string SerialNumber
		{
			get { return ParentComponent != null ? ParentComponent.SerialNumber : ""; }
		}
		#endregion

		#region public string Description { get; }
		/// <summary>
		/// �������� ������������� ��������
		/// </summary>
		public string Description
		{
			get { return ParentComponent != null ? ParentComponent.Description : ""; }
		}
		#endregion

		#region public string Manufacturer { get; }
		/// <summary>
		/// ������������� ������������� ��������
		/// </summary>
		public string Manufacturer
		{
			get { return ParentComponent != null ? ParentComponent.Manufacturer : ""; }
		}
		#endregion

		#region public SupplierCollection Suppliers { get; }
		/// <summary>
		/// ���������� ������������� ����������
		/// </summary>
		public SupplierCollection Suppliers
		{
			get { return ParentComponent != null ? ParentComponent.Suppliers : null; }
		}

		#endregion

		#region public AtaChapter ATAChapter { get; }
		/// <summary>
		/// ������� ���� �� ������������� ������ �� ���������� �����������
		/// </summary>
		public AtaChapter ATAChapter 
		{
			get { return ParentComponent != null ? ParentComponent.ATAChapter : null; }
		}
		#endregion

		#region #region public AtaChapter ATAChapter { get; }

		public GoodsClass GoodsClass
		{
			get { return ParentComponent != null ? ParentComponent.GoodsClass : null; }
		}

		#endregion

		#region public MaintenanceType MaintenanceType { get; }
		/// <summary>
		/// ������������� ������ � ����� ������������ ������������
		/// </summary>
		public MaintenanceControlProcess MaintenanceControlProcess
		{ 
			get { return ParentComponent != null ? ParentComponent.MaintenanceControlProcess : MaintenanceControlProcess.UNK; } 
		}
		#endregion

		#region public BaseComponent ParentBaseComponent { get; }
		//todo ��� ������� ���� ��� ������������ ��������� ���������
		[NonSerialized]
		private BaseComponent _parentBaseComponent;

		/// <summary>
		/// �������� ������� �������, �� ������� ���������� ������������ �������
		/// </summary>
		public BaseComponent ParentBaseComponent
		{
			get { return ParentComponent != null ? ParentComponent.ParentBaseComponent : null; }//TODO:(Evgenii Babak) �������� �� ������������� ComponentCore 
		}
		#endregion

		#region Lifelength FirstPerformanceSinceNew { get; }

		/// <summary>
		/// ���������� ����� ������� ���������� ������
		/// </summary>
		public Lifelength FirstPerformanceSinceNew => _threshold != null ? _threshold.FirstPerformanceSinceNew : Lifelength.Null;

		#endregion

		#region public Lifelength Interval { get; }

		/// <summary>
		/// ���������� �������� ���������� ���������� ������ ��� Lifelength.Null
		/// </summary>
		public Lifelength Interval => _threshold != null ? _threshold.RepeatInterval : Lifelength.Null;

		public Supplier FromSupplier { get { return ParentComponent != null ? ParentComponent.FromSupplier : Supplier.Unknown; } }

		#endregion

		public string BatchNumber { get { return ParentComponent != null ? ParentComponent.BatchNumber : ""; } }
		public string Code { get { return ParentComponent != null ? ParentComponent.Code : ""; } }
		public string IdNumber { get { return ParentComponent != null ? ParentComponent.IdNumber : ""; } }
		public Lifelength Warranty { get { return ParentComponent != null ? ParentComponent.Warranty : Lifelength.Null; } }
		public bool IsPOOL { get { return ParentComponent != null ? ParentComponent.IsPOOL : false; } }
		public bool IsDangerous { get { return ParentComponent != null ? ParentComponent.IsDangerous : false; } }
		public Locations Location { get { return ParentComponent != null ? ParentComponent.Location : Locations.Unknown; } }
		public LocationsType Facility { get { return ParentComponent != null ? ParentComponent.Location.LocationsType : LocationsType.Unknown ; } }

		public ComponentStorePosition State
		{
			get { return ParentComponent != null ? ParentComponent.State : ComponentStorePosition.UNK; }
		}
		public ComponentStatus ComponentStatus { get { return ParentComponent != null ? ParentComponent.ComponentStatus : ComponentStatus.Unknown; } }
		#endregion

		#region Implement IPrintSettings

		#region public bool PrintInWorkPackage { get; set; }
		/// <summary>
		/// ���������� ��� ������ ��������, ����������� ��������� ������ �������� � ������� ������
		/// </summary>
		public bool PrintInWorkPackage { get; set; }
		#endregion

		#region public bool WorkPackageACCPrintTitle { get; set; }
		/// <summary>
		/// ���������� ��� ������ ��������, ����������� ������ �������� ������ � AccountabilitySheet �������� ������
		/// </summary>
		public bool WorkPackageACCPrintTitle { get; set; }
		#endregion

		#region public bool WorkPackageACCPrintTaskCard { get; set; }
		/// <summary>
		/// ���������� ��� ������ ��������, ����������� ������ ������� ����� ������ � AccountabilitySheet �������� ������
		/// </summary>
		public bool WorkPackageACCPrintTaskCard { get; set; }
		#endregion

		#endregion

		#region Implement of IBindedItem

		#region public CommonCollection<ItemsRelation> ItemRelations { get; set; }

		private CommonCollection<ItemsRelation> _itemRelations;
		[Child(RelationType.OneToMany, ColumnAccessType.WriteOnly)]
		public CommonCollection<ItemsRelation> ItemRelations
		{
			get { return _itemRelations ?? (_itemRelations = new CommonCollection<ItemsRelation>()); }
			set
			{
				if (_itemRelations != value)
				{
					if (_itemRelations != null)
						_itemRelations.Clear();
					if (value != null)
						_itemRelations = value;
				}
			}
		}

		#endregion

		#region public WorkItemsRelationType WorkItemsRelationType
		public WorkItemsRelationType WorkItemsRelationType
		{
			get
			{
				var relationTypesIds = ItemRelations.Select(i => i.RelationTypeId).Distinct().ToList();

				if (relationTypesIds.Count > 1)
					return WorkItemsRelationType.Incorrect;
				if (relationTypesIds.Count == 1)
					return relationTypesIds[0];

				return WorkItemsRelationType.None;
			}
			set
			{
				foreach (var itemRelation in ItemRelations)
					itemRelation.RelationTypeId = value;
			}
		}

		#endregion

		#region public bool? IsFirst

		public bool? IsFirst
		{
			get
			{
				if (ItemRelations.Count == 0)
					return true;

				var isFirst = false;
				var isSecond = false;

				foreach (var itemRelation in ItemRelations)
				{
					if (itemRelation.FirstItemId == ItemId && itemRelation.FirtsItemTypeId == SmartCoreObjectType.ItemId)
						isFirst = true;
					if (itemRelation.SecondItemId == ItemId && itemRelation.SecondItemTypeId == SmartCoreObjectType.ItemId)
						isSecond = true;

					if (isFirst && isSecond)
						return null;
				}

				return isFirst;
			}
		}

		#endregion

		#region public NextPerformance BindedItemNextPerformance { get; set; }

		public NextPerformance BindedItemNextPerformance { get; set; }

		#endregion

		#region public ConditionState BindedItemCondition { get; set; }

		public ConditionState BindedItemCondition { get; set; }

		#endregion

		#region public Lifelength BindedItemNextPerformanceSource { get; set; }

		public Lifelength BindedItemNextPerformanceSource { get; set; }

		#endregion

		#region public Lifelength BindedItemRemains { get; set; }

		public Lifelength BindedItemRemains { get; set; }

		#endregion

		#region public DateTime? BindedItemNextPerformanceDate { get; set; }

		public DateTime? BindedItemNextPerformanceDate { get; set; }

		#endregion

		#endregion

		#region Implement of IWorkPackageItemFilterParams

		#region public SmartCoreType SmartCoreType { get; }

		public SmartCoreType SmartCoreType => SmartCoreObjectType;

		#endregion

		#region public Lifelength RepeatInterval { get; }

		public Lifelength RepeatInterval { get { return _threshold.RepeatInterval ?? Lifelength.Null; } }

		#endregion

		#region public bool HasNDT { get; }

		public bool HasNDT { get { return NDTType != NDTType.UNK; } }

		#endregion

		#region public bool HasKits { get; }

		public bool HasKits { get { return Kits.Count > 0; } }

		#endregion

		#endregion

		public Document Document { get; set; }

		/*
		*  ������ 
		*/

		#region public ComponentDirective()
		/// <summary>
		/// ������� ��������� ����� ��� �������������� ����������
		/// </summary>
		public ComponentDirective()
		{
			SmartCoreObjectType = SmartCoreType.ComponentDirective;
			FaaFormFileId = -1;
			ItemId = -1;
			NDTType = NDTType.UNK;
			_performanceRecords = new BaseRecordCollection<DirectiveRecord>();
			_nextPerformances = new List<NextPerformance>();
			Kits = new CommonCollection<AccessoryRequired>();
			PrintInWorkPackage = true;
		}
		#endregion

		#region public ComponentDirective(Component component)

		public ComponentDirective(Component component)
		{
			SmartCoreObjectType = SmartCoreType.ComponentDirective;
			FaaFormFileId = -1;
			ItemId = -1;
			NDTType = NDTType.UNK;
			_performanceRecords = new BaseRecordCollection<DirectiveRecord>();
			_nextPerformances = new List<NextPerformance>();
			Kits = new CommonCollection<AccessoryRequired>();
			PrintInWorkPackage = true;
			ParentComponent = component;
		}

		#endregion

		#region public ComponentDirective(TemplateComponentDirective templateComponentDirective) : this()
		/// <summary>
		/// ������� ��������� ����� ��� �������������� ����������
		/// </summary>
		public ComponentDirective(TemplateComponentDirective templateComponentDirective)
			: this()
		{
			ManHours = templateComponentDirective.ManHours;
			Cost = templateComponentDirective.Cost;
			DirectiveType = templateComponentDirective.DirectiveType;
			_threshold = templateComponentDirective.Threshold;
			Highlight = Highlight.White;
			NDTType = templateComponentDirective.NDTType;
		}
		#endregion

		#region public ComponentDirective(TemplateComponentDirective templateComponentDirective, Component parentComponent): this(templateComponentDirective)
		/// <summary>
		/// ������� ��������� ����� ��� �������������� ����������
		/// </summary>
		public ComponentDirective(TemplateComponentDirective templateComponentDirective, Component parentComponent)
			: this(templateComponentDirective)
		{
			ParentComponent = parentComponent;
		}
		#endregion

		#region public ComponentDirective(ComponentDirective toCopy) : this ()
		/// <summary>
		/// ������� ��������� ����� ��� �������������� ����������
		/// </summary>
		public ComponentDirective(ComponentDirective toCopy) : this ()
		{
			if(toCopy == null) return;

			Cost = toCopy.Cost;
			ComponentId = toCopy.ComponentId;
			DirectiveTypeId = toCopy.DirectiveTypeId;
			FaaFormFileId = toCopy.FaaFormFileId;
			HiddenRemarks = toCopy.HiddenRemarks;
			Highlight = toCopy.Highlight;
			IsClosed = toCopy.IsClosed;
			KitRequired = toCopy.KitRequired;
			ManHours = toCopy.ManHours;
			MPDTaskType = toCopy.MPDTaskType;
			ParentComponent = toCopy.ParentComponent;
			Remarks = toCopy.Remarks;
			_threshold = toCopy.Threshold;

			FaaFormFile = toCopy.FaaFormFile;

			if (_performanceRecords == null)
				_performanceRecords = new BaseRecordCollection<DirectiveRecord>();
			_performanceRecords.Clear();
			foreach (DirectiveRecord directiveRecord in toCopy.PerformanceRecords)
			{
				_performanceRecords.Add(new DirectiveRecord(directiveRecord){Parent = this, ParentId = ItemId});
			}

			if (Kits == null)
				Kits = new CommonCollection<AccessoryRequired>();
			Kits.Clear();
			foreach (AccessoryRequired kit in toCopy.Kits)
			{
				Kits.Add(new AccessoryRequired(kit){ParentObject = this, ParentId = ItemId});
			}
		}
		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(ComponentDirective));
		}
		#endregion

		#region public override string ToString()
		/// <summary>
		/// ����������� ��� �������
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return DirectiveType.ToString();
		}
		#endregion

		#region public int CompareTo(ComponentDirective y)

		public int CompareTo(ComponentDirective y)
		{
			return ItemId.CompareTo(y.ItemId);
		}

		#endregion

		#region public new ComponentDirective GetCopyUnsaved()

		public new ComponentDirective GetCopyUnsaved(bool marked = true)
		{
			var componentDirective = (ComponentDirective) MemberwiseClone();
			componentDirective.ItemId = -1;
			componentDirective.UnSetEvents();

			componentDirective.Threshold = new ComponentDirectiveThreshold(Threshold);
			componentDirective.ForecastLifelength = new Lifelength(ForecastLifelength);
			componentDirective.AfterForecastResourceRemain = new Lifelength(AfterForecastResourceRemain);

			componentDirective._performanceRecords = new BaseRecordCollection<DirectiveRecord>();
			foreach (var directiveRecord in PerformanceRecords)
			{
				var newObject = directiveRecord.GetCopyUnsaved(marked);
				newObject.Parent = componentDirective;
				newObject.ParentId = componentDirective.ItemId;
				componentDirective._performanceRecords.Add(newObject);
			}

			componentDirective._kits = new CommonCollection<AccessoryRequired>();
			foreach (var accessoryRequired in Kits)
			{
				var newObject = accessoryRequired.GetCopyUnsaved(marked);
				newObject.ParentId = componentDirective.ItemId;
				componentDirective._kits.Add(newObject);
			}

			componentDirective._aircraftWorkerCategories = new CommonCollection<CategoryRecord>();
			foreach (var categoryRecord in CategoriesRecords)
			{
				var newObject = categoryRecord.GetCopyUnsaved(marked);
				newObject.Parent = componentDirective;
				componentDirective._aircraftWorkerCategories.Add(newObject);
			}

			componentDirective._files = new CommonCollection<ItemFileLink>();
			foreach (var file in Files)
			{
				var newObject = file.GetCopyUnsaved(marked);
				componentDirective._files.Add(newObject);
			}


			return componentDirective;
		}

		#endregion

		#region public void NormalizeItemRelations()

		public void NormalizeItemRelations()
		{
			if (ItemRelations.Count == 0 || IsFirst != null)
				return;

			foreach (var itemRelation in ItemRelations.Where(i => i.FirstItemId != ItemId && i.FirtsItemTypeId != SmartCoreObjectType.ItemId))
			{
				itemRelation.SecondItemId = itemRelation.FirstItemId;
				itemRelation.SecondItemTypeId = itemRelation.FirtsItemTypeId;

				itemRelation.FirstItemId = ItemId;
				itemRelation.FirtsItemTypeId = SmartCoreObjectType.ItemId;

				if (itemRelation.RelationTypeId == WorkItemsRelationType.CalculationAffect)
					itemRelation.RelationTypeId = WorkItemsRelationType.CalculationDepend;
				else if (itemRelation.RelationTypeId == WorkItemsRelationType.CalculationDepend)
					itemRelation.RelationTypeId = WorkItemsRelationType.CalculationAffect;
			}
		}

		#endregion

		#region Implementation of IAtaSorted

		public AtaChapter AtaSorted
		{
			get => ParentComponent.Model != null ? ParentComponent.Model.ATAChapter : ParentComponent.ATAChapter;
		}

		#endregion

		#region Implementation of IMtopCalc

		public Lifelength PhaseThresh { get; set; }
		public Lifelength PhaseRepeat { get; set; }
		public Phase MTOPPhase { get; set; }
		public bool RecalculateTenPercent { get; set; }
		public bool APUCalc { get; set; }

		public bool IsExtension { get; set; }
		public double Extension { get; set; }

		public int ParentAircraftId => ParentComponent?.ParentAircraftId ?? (ParentBaseComponent?.ParentAircraftId ?? -1);
		public List<NextPerformance> MtopNextPerformances { get; set; }


		#endregion

		public bool FromBaseComponent { get; set; }
		public string LinkAd { get; set; }
	}

}
