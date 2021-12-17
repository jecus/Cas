using System;
using System.Collections.Generic;
using System.Reflection;
using CAS.Entity.Models.DTO.Dictionaries;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Packages;

namespace SmartCore.Entities.General.WorkPackage
{

	/// <summary>
	/// ���������� �������� (���������)
	/// </summary>
	[Table("NonRoutineJobs", "Dictionaries", "ItemId")]
	[Condition("IsDeleted","0")]
	[Dto(typeof(NonRoutineJobDTO))]
	[Serializable]
	public class NonRoutineJob : BaseEntityObject, IKitRequired, IEngineeringDirective, IWorkPackageItemFilterParams
	{
		private static Type _thisType;
		/*
		*  ��������
		*/

		#region public AtaChapter ATAChapter { get; set; }

		/// <summary>
		/// ����� ���������� �����, ��� ��������� �������� ������
		/// </summary>
		[ListViewData(0.22f, "Ata Chapter"), TableColumnAttribute("AtaChapterId")]
		public AtaChapter ATAChapter { get; set; }

		#endregion

		#region public String Title { get; set; }
		/// <summary>
		/// �������� ������
		/// </summary>
		[ListViewData(0.2f, "Title"), TableColumnAttribute("Title")]
		public String Title { get; set; }
		#endregion

		#region public String Description { get; set; }
		/// <summary>
		/// �������� ������
		/// </summary>
		[ListViewData(0.2f, "Description"), TableColumnAttribute("Description")]
		public String Description { get; set; }
		#endregion

		#region public WorkPackage ParentWorkPackage { get; set; }
		[NonSerialized]
		private WorkPackage _parentWorkPackage;

		//TODO:(Evgenii Babak) ��������������� ������������� ������� ��������
		[ListViewData(0.2f, "Work Package")]
		public WorkPackage ParentWorkPackage
		{
			get { return _parentWorkPackage; }
			set { _parentWorkPackage = value; }
		}

		#endregion

		#region public WorkPackageRecord WorkPackageRecord { get; internal set; }
		[NonSerialized]
		private WorkPackageRecord _workPackageRecord;
		/// <summary>
		/// ������������ � ������ � NonRoutineJobsStatus
		/// </summary>
		public WorkPackageRecord WorkPackageRecord
		{
			get { return _workPackageRecord; }
			set { _workPackageRecord = value; }
		}

		#endregion

		#region public String KitRequired { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[ListViewData(0.1f, "Kit Required"), TableColumnAttribute("KitRequired")]
		public String KitRequired { get; set; }
		#endregion

		//TODO: ���������� �� ������������� ������ fileCore
		#region public AttachedFile AttachedFile
		[NonSerialized]
		private AttachedFile _attachedFile;
		/// <summary>
		/// ���� ����� ������
		/// </summary>
		[TableColumnAttribute("FileId")]
		[Child]
		public AttachedFile AttachedFile
		{
			get { return _attachedFile; }
			set { _attachedFile = value; }
		}

		#endregion

		#region public IDirectivePackage BlockedByPackage { get; set; }
		/// <summary>
		/// ������� �����, � ������� ������������� ������ ����������
		/// </summary>
		public IDirectivePackage BlockedByPackage { get; set; }
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
				return $"N-Rout. job:{ATAChapter} {Title}";
			}
		}
		#endregion

		#region public ICommonCollection<KitRequired> Kits

		private CommonCollection<AccessoryRequired> _kits;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 4, "ParentObject")]
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

		#region  Implement of IEngineeringDirective
		//�������� ���������� IMathData, ��� �������� ���������� ��� �������� ��� ��������
		//� ���� ��������, ������� ����� � �.�. ����� ��������� �� ������� ��������
		// ���� ����. ���������� � ��������� �� ������� ��� ���������� ����������

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
			get { return MaintenanceDirectiveProgramType.Unknown; }
		}
		#endregion

		#region public StaticDictionary WorkType { get; }
		/// <summary>
		/// ���/��� �����
		/// </summary>
		public StaticDictionary WorkType { get { return DirectiveWorkType.Unknown; } }
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
		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 4, "Parent")]
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
			get { return null; }
		}
		#endregion

		#region IThreshold IDirective.Threshold { get; set; }
		/// <summary>
		/// ����� ������� � ������������ ����������
		/// </summary>
		IThreshold IDirective.Threshold { get; set; }
		#endregion

		#region IRecordCollection IDirective.PerformanceRecords { get; }
		/// <summary>
		/// ��������� �������� ��� ������ � ���������� ���������
		/// </summary>
		IRecordCollection IDirective.PerformanceRecords { get { return null; } }
		#endregion

		#region AbstractPerformanceRecord IDirective.LastPerformance { get; }
		/// <summary>
		/// ������ � ��������� ������ � ���������� ������
		/// </summary>
		AbstractPerformanceRecord IDirective.LastPerformance { get { return null; } }
		#endregion

		#region public List<NextPerformance> NextPerformances { get; set; }

		private List<NextPerformance> _nextPerformances;
		/// <summary>
		/// ������ ����������� ���������� ������
		/// </summary>
		public List<NextPerformance> NextPerformances
		{
			get { return _nextPerformances ?? (_nextPerformances = new List<NextPerformance>()); }
			set { _nextPerformances = value; }
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
				return null;
			}
		}
		#endregion

		#region public ConditionState Condition { get; set; }

		private ConditionState _conditionState;
		/// <summary>
		/// ������� ���������
		/// </summary>
		public ConditionState Condition
		{
			get { return _conditionState ?? (_conditionState = ConditionState.Satisfactory); }
			set
			{
				if (_conditionState != value)
				{
					_conditionState = value;
					OnPropertyChanged("Condition");
				}
			}
		}
		#endregion

		#region public DirectiveStatus Status { get; }
		/// <summary>
		/// ������ ���������
		/// </summary>
		[Filter("Status:", Order = 8)]
		public DirectiveStatus Status
		{
			get
			{
				if (IsClosed) return DirectiveStatus.Closed; //��������� ������������� ������� �������������
				return DirectiveStatus.Open;
			}
		}
		#endregion

		#region public Lifelength NextCompliance { get; set; }
		/// <summary>
		/// ���������, ��� ������� ���������� ��������� ����������
		/// </summary>
		public Lifelength NextPerformanceSource { get; set; }
		#endregion

		#region public Lifelength Remains { get; set; }

		private Lifelength _remains;
		/// <summary>
		/// ������� ������� �� ���������� ����������
		/// </summary>
		public Lifelength Remains
		{
			get { return _remains ?? (_remains = Lifelength.Null); }
			set
			{
				if(_remains != value)
				{
					_remains = value;
					OnPropertyChanged("Remains");
				}
			}
		}
		#endregion

		#region public Lifelength BeforeForecastResourceRemain { get; set; }
		/// <summary>
		/// ������� ������� �� �������� (����������� ������ � ��������)
		/// </summary>
		public Lifelength BeforeForecastResourceRemain { get; set; }
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
		/// ���� ���������� ����������
		/// </summary>
		public DateTime? NextPerformanceDate { get; set; }
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
			get { return 0; }
		}
		#endregion

		#region public Double ManHours { get; set; }
		/// <summary>
		/// ���������� �������� �����, ����������� ��� ���������� ������
		/// </summary>
		[ListViewData(0.1f, "MH"), TableColumnAttribute("ManHours")]
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
		[ListViewData(0.1f, "Cost"), TableColumnAttribute("Cost")]
		public Double Cost { get; set; }
		#endregion

		#region public Boolean IsClosed { get; set; }
		/// <summary>
		/// ���������� ����, ������������, ������� �� ���������
		/// </summary>
		public Boolean IsClosed { get; set; }
		#endregion

		#region public Boolean IsBlocked { get; }
		///
		/// ���������� ����, ������������, ������������� �� ��������� ������� �������
		/// 
		public Boolean NextPerformanceIsBlocked
		{
			get
			{
				return  false;
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

		#region Implement of IWorkPackageItemFilterParams

		#region public SmartCoreType SmartCoreType { get; }

		public SmartCoreType SmartCoreType => SmartCoreObjectType;

		#endregion

		#region public Lifelength RepeatInterval { get; }

		public Lifelength RepeatInterval { get { return Lifelength.Null; } }

		#endregion

		#region public Lifelength FirstPerformanceSinceNew { get;}

		public Lifelength FirstPerformanceSinceNew { get { return Lifelength.Null; } }

		#endregion

		#region public bool HasNDT { get; }

		public bool HasNDT { get; }

		#endregion

		#region public bool HasKits { get; }

		public bool HasKits { get { return Kits.Count > 0; } }

		#endregion

		#endregion

		/*
		*  ������ 
		*/

		#region private static Type GetCurrentType()

		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(NonRoutineJob));
		}

		#endregion

		#region public NonRoutineJob()
		/// <summary>
		/// ������� ���������� ������ ��� �������������� ����������
		/// </summary>
		public NonRoutineJob()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.NonRoutineJob;

			Kits = new CommonCollection<AccessoryRequired>();
			PrintInWorkPackage = true;
		}
		#endregion
	  
		#region public override string ToString()
		/// <summary>
		/// ����������� ��� �������
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return (ATAChapter != null ? "ata: "+ ATAChapter.ShortName + " ": "") +  Title;
		}
		#endregion

		#region public new NonRoutineJob GetCopyUnsaved()

		public override BaseEntityObject GetCopyUnsaved(bool marked = true)
		{
			var nrj = (NonRoutineJob) MemberwiseClone();

			nrj.ItemId = -1;

			if (marked)
				nrj.Title += " Copy";

			nrj.NextPerformanceSource = new Lifelength(NextPerformanceSource);
			nrj.Remains = new Lifelength(Remains);
			nrj.BeforeForecastResourceRemain = new Lifelength(BeforeForecastResourceRemain);
			nrj.ForecastLifelength = new Lifelength(ForecastLifelength);
			nrj.AfterForecastResourceRemain = new Lifelength(AfterForecastResourceRemain);

			nrj._kits = new CommonCollection<AccessoryRequired>();
			foreach (var accessory in Kits)
			{
				var newObject = accessory.GetCopyUnsaved(marked);
				newObject.ParentId = nrj.ItemId;
				nrj._kits.Add(newObject);
			}

			return nrj;
		}

		#endregion

	}

}
