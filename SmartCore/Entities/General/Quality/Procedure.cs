using System;
using System.Collections.Generic;
using System.Reflection;
using CAS.Entity.Models.DTO.General;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Deprecated;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Files;

namespace SmartCore.Entities.General.Quality
{

	/// <summary>
	/// ����� ��������� ���������
	/// </summary>
	[Table("Procedures", "dbo", "ItemId")]
	[Dto(typeof(ProcedureDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class Procedure : BaseEntityObject, IDirective, IKitRequired, IComparable<Procedure>, IEquatable<Procedure>, IFileContainer
	{
		private static Type _thisType;
		/*
		*  ��������
		*/

		#region public String Title { get; set; }
		/// <summary>
		/// ����� ���� ������
		/// </summary>
		[TableColumn("Title"), ListViewData("Title")]
		[Filter("Title:", Order = 1)]
		public String Title { get; set; }
		#endregion

		#region public ProcedureType ProcedureType { get; set; }
		/// <summary>
		/// ��� ���������
		/// </summary>
		[TableColumn("ProcedureTypeId"), ListViewData("Procedure Type")]
		[Filter("Procedure Type:", Order = 7)]
		public ProcedureType ProcedureType { get; set; }
		#endregion

		#region public ProcedureRating ProcedureRating { get; set; }
		/// <summary>
		/// ��� ���������
		/// </summary>
		[TableColumn("ProcedureRatingId"), ListViewData("Procedure Rating")]
		[Filter("Procedure Rating:", Order = 4)]
		public ProcedureRating ProcedureRating { get; set; }
		#endregion

		#region public String Applicability { get; set; }
		/// <summary>
		/// ������������
		/// </summary>
		[TableColumn("Applicability"), ListViewData("Applicability")]
		public String Applicability { get; set; }
		#endregion

		#region public Operator ParentOperator { get; set; }
		/// <summary>
		/// �������� ������ �� ���������
		/// </summary>
		[TableColumn("OperatorId")]
		public Operator ParentOperator { get; set; }

		public static PropertyInfo ParentOperatorProperty
		{
			get { return GetCurrentType().GetProperty("ParentOperator"); }
		}
		#endregion

		#region public String AuditedObject { get; set; }
		/// <summary>
		/// ����� ������ MPD
		/// </summary>
		[TableColumnAttribute("AuditedObject"), ListViewData("AuditedObject")]
		public String AuditedObject { get; set; }
		#endregion

		#region public int AuditedObjectId { get; set; }
		/// <summary>
		/// �� ��������, ��� �������� ������������� ���������
		/// <br/>(������ �������� ����� �� ��������� ������������� �������� ��������) 
		/// </summary>
		[TableColumn("AuditedObjectId")]
		public int AuditedObjectId { get; set; }

		public static PropertyInfo AuditedObjectIdProperty
		{
			get { return GetCurrentType().GetProperty("AuditedObjectId"); }
		}
		#endregion

		#region public SmartCoreType AuditedObjectType { get; set; }
		/// <summary>
		/// �������� ������ �� ���������
		/// </summary>
		[TableColumn("AuditedObjectTypeId")]
		public SmartCoreType AuditedObjectType { get; set; }

		public static PropertyInfo AuditedObjectTypeProperty
		{
			get { return GetCurrentType().GetProperty("AuditedObjectType"); }
		}
		#endregion

		#region public String Description { get; set; }
		/// <summary>
		/// �������� ���������
		/// </summary>
		[TableColumn("Description", 3072), ListViewData("Description")]
		public String Description { get; set; }
		#endregion

		#region public String CheckList { get; set; }
		/// <summary>
		/// �������� Engineering orders
		/// </summary>
		[TableColumn("CheckList"), ListViewData("Check List")]
		public String CheckList { get; set; }
		#endregion

		#region public AttachedFile CheckListFile { get; set; }

		private AttachedFile _checkListFile;
		/// <summary>
		/// ����� � ������ �������� ����������� ������
		/// </summary>
		[ListViewData("Check List File")]
		public AttachedFile CheckListFile
		{
			get
			{
				return _checkListFile ?? (Files.GetFileByFileLinkType(FileLinkType.ProcedureCheckListFile));
			}
			set
			{
				_checkListFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.ProcedureCheckListFile);
			}
		}

		#endregion

		#region  public AttachedFile ProcedureFile { get; set; }

		private AttachedFile _procedureFile;

		/// <summary>
		/// ����� � ������ �������� ��������� ������ ��������
		/// </summary>
		[ListViewData("Procedure File")]
		public AttachedFile ProcedureFile
		{
			get
			{
				return _procedureFile ?? (Files.GetFileByFileLinkType(FileLinkType.ProcedureFile));
			}
			set
			{
				_procedureFile = value;
				Files.SetFileByFileLinkType(SmartCoreObjectType.ItemId, value, FileLinkType.ProcedureFile);
			}
		}

		#endregion

		#region public CommonCollection<ItemFileLink> Files { get; set; }

		private CommonCollection<ItemFileLink> _files;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1840)]
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

		#region public JobCard JobCard { get; set; }

		private JobCard _jobCard;

		/// <summary>
		/// ������� ����� ������ ���������
		/// </summary>
		[TableColumn("JobCard"), ListViewData("Job Card")]
		[Child(false)]
		//[Filter("Check:", Order = 13)]
		public JobCard JobCard
		{
			get { return _jobCard; }
			set
			{
				_jobCard = value;
				if (_jobCard != null)
				{
					_jobCard.Parent = this;
				}
			}
		}

		public static PropertyInfo JobCardProperty
		{
			get { return GetCurrentType().GetProperty("JobCard"); }
		}

		#endregion

		#region public int Level { get; set; }

		private int _level;

		/// <summary>
		/// </summary>
		[TableColumn("Level")]
		public int Level
		{
			get { return (_level < 1 || _level > 4) ? 4 : _level; }
			set { _level = value; }
		}

		public static PropertyInfo LevelProperty
		{
			get { return GetCurrentType().GetProperty("Level"); }
		}
		#endregion

		/*
		 * �������������� ��������
		 */

		#region public Highlight Highlight { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Highlight Highlight { get; set; }
		#endregion

		#region public MaintenanceDirectiveThreshold Threshold { get; set; }

		private MaintenanceDirectiveThreshold _threshold;
		/// <summary>
		/// ������� ���������� ���������
		/// </summary>
		[TableColumn("Threshold"), ListViewData("Threshold")]
		public MaintenanceDirectiveThreshold Threshold
		{
			get { return _threshold; }
			set { _threshold = value; }
		}
		#endregion

		#region public Lifelength FirstPerformanceSinceNew { get; }

		/// <summary>
		/// ������� ������� ���������� � ������� ������������ ������/��
		/// </summary>
		[Filter("1st. Perf:")]
		public Lifelength FirstPerformanceSinceNew
		{
			get { return _threshold != null ? _threshold.FirstPerformanceSinceNew : Lifelength.Null; }
		}
		#endregion

		#region public Lifelength RepeatInterval{ get; }

		/// <summary>
		/// �������� ���������� ���������
		/// </summary>
		[Filter("Rpt. Int:")]
		public Lifelength RepeatInterval
		{
			get { return _threshold != null ? _threshold.RepeatInterval : Lifelength.Null; }
		}
		#endregion

		#region public String Remarks { get; set; }
		/// <summary>
		/// ������� �� ���������
		/// </summary>
		[TableColumn("Remarks", 512), ListViewData("Remarks")]
		[Filter("Remarks:", Order = 5)]
		public String Remarks { get; set; }
		#endregion

		#region public String HiddenRemarks { get; set; }
		/// <summary>
		/// ������� �������
		/// </summary>
		[TableColumn("HiddenRemarks", 512), ListViewData("HiddenRemarks")]
		[Filter("Hidden Remarks:", Order = 6)]
		public String HiddenRemarks { get; set; }
		#endregion

		#region public DirectiveRecord LastPerformance { get; }
		/// <summary>
		/// ��������� ���������� 
		/// </summary>
		public DirectiveRecord LastPerformance { get { return PerformanceRecords.GetLast(); } }
		#endregion

		#region public BaseRecordCollection<DirectiveRecord> PerformanceRecords

		private BaseRecordCollection<DirectiveRecord> _performanceRecords;
		/// <summary>
		/// 
		/// </summary>
		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1840, "Parent")]
		public BaseRecordCollection<DirectiveRecord> PerformanceRecords
		{
			get { return _performanceRecords ?? (_performanceRecords = new BaseRecordCollection<DirectiveRecord>()); }
			internal set
			{
				if(_performanceRecords != value)
				{
					if (_performanceRecords != null)
						_performanceRecords.Clear();
					if (value != null)
						_performanceRecords = value;
				}
			}
		}
		#endregion

		#region public DirectiveStatus Status { get; }
		/// <summary>
		/// ������ ���������
		/// </summary>
		[Filter("Status:", Order = 9)]
		public DirectiveStatus Status
		{
			get
			{
				if (IsClosed) return DirectiveStatus.Closed; //��������� ������������� ������� �������������
				if (LastPerformance == null)
				{
					if (!_threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero() ||
					   !_threshold.FirstPerformanceSinceNew.IsNullOrZero())
						return DirectiveStatus.Open;

					return DirectiveStatus.NotApplicable;
				}

				if (_threshold.RepeatInterval.IsNullOrZero()) return DirectiveStatus.Closed;

				return DirectiveStatus.Repetative;
			}
		}
		#endregion

		#region public CommonCollection<ProcedureDocumentReference> DocumentReferences

		private CommonCollection<ProcedureDocumentReference> _documentReferences;
		/// <summary>
		/// 
		/// </summary>
		[Child(RelationType.OneToMany, "ProcedureId", "Procedure")]
		public CommonCollection<ProcedureDocumentReference> DocumentReferences
		{
			get { return _documentReferences ?? (_documentReferences = new CommonCollection<ProcedureDocumentReference>()); }
			internal set
			{
				if (_documentReferences != value)
				{
					if (_documentReferences != null)
						_documentReferences.Clear();
					if (value != null)
						_documentReferences = value;
				}
			}
		}
		#endregion

		#region Implement of IMathData
		//�������� ���������� IMathData, ��� �������� ���������� ��� �������� ��� ��������
		//� ���� ��������, ������� ����� � �.�. ����� ��������� �� ������� ��������
		// ���� ����. ���������� � ��������� �� ������� ��� ���������� ����������

		#region BaseSmartCoreObject LifeLenghtParent { get; }
		/// <summary>
		/// ���������� ������, ��� �������� ����� ��������� ������� ���������. ������ Aircraft, BaseComponent ��� Component
		/// </summary>
		public BaseEntityObject LifeLengthParent
		{
			get
			{
				return ParentOperator;
			}
		}
		#endregion

		#region IThreshold IDirective.Threshold { get; set; }
		/// <summary>
		/// ����� ������� � ������������ ����������
		/// </summary>
		IThreshold IDirective.Threshold
		{
			get { return _threshold; }
			set { _threshold = value as MaintenanceDirectiveThreshold; }
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
		AbstractPerformanceRecord IDirective.LastPerformance
		{
			get
			{
				return PerformanceRecords.GetLast();
			}
		}
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

		#region public NextPerformance NextPerformance { get; }
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
		[Filter("Condition:", Order = 10)]
		public ConditionState Condition
		{
			get
			{
				if (_nextPerformances == null || _nextPerformances.Count == 0) return ConditionState.NotEstimated;
				return _nextPerformances[0].Condition;
			}
		}
		#endregion

		#region public Lifelength NextPerformanceSource { get; }

		/// <summary>
		/// ���������� ������ ���������� ���������� ������ (���� ��� ���������) ��� Lifelength.Null
		/// </summary>
		public Lifelength NextPerformanceSource
		{
			get
			{
				if (_nextPerformances == null || _nextPerformances.Count == 0) 
					return Lifelength.Null;
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
		/// (AfterForecast / (AfterForecast + beforeForecast)) * 100
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

		#region public Boolean IsClosed { get; set; }
		/// <summary>
		/// ���������� ����, ������������, ������� �� ���������
		/// </summary>
		[TableColumn("IsClosed")]
		public Boolean IsClosed { get; set; }
		#endregion

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

		#region public Double ManHours { get; set; }
		/// <summary>
		/// �������� ������ �����������
		/// </summary>
		[TableColumn("ManHours"), ListViewData("Man Hours"), MinMaxValue(0, 100000)]
		public Double ManHours { get; set; }
		#endregion

		#region public Double Elapsed { get; set; }
		/// <summary>
		/// �������� ������ ����������� 
		/// </summary>
		[TableColumn("Elapsed"), ListViewData("Elapsed"), MinMaxValue(0, 100000)]
		public Double Elapsed { get; set; }
		#endregion

		#region public Double Cost { get; set; }
		/// <summary>
		/// ��������� ���������
		/// </summary>
		[TableColumn("Cost"), ListViewData("Cost"), MinMaxValue(0, 1000000000)]
		public Double Cost { get; set; }
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
				return $"MPD.:{Title}:{Description}";
			}
		}
		#endregion

		#region public ICommonCollection<KitRequired> Kits

		private CommonCollection<AccessoryRequired> _kits;

		[Child(RelationType.OneToMany, "ParentId", "ParentTypeId", 1840, "ParentObject")]
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

		#region public int CountForPrint { get; set; }
		/// <summary>
		/// ���������� ����� ����� ������ ������ ��� ������ ��� ������� ������� ����� �� �����������
		/// <br/> ������������ � ������� �������
		/// </summary>
		public int CountForPrint { get; set; }
		#endregion

		#region Implement IPrintSettings

		#region public bool PrintInWorkPackage { get; set; }
		/// <summary>
		/// ���������� ��� ������ ��������, ����������� ��������� ������ �������� � ������� ������
		/// </summary>
		[TableColumn("PrintInWP")]
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

		/*
		*  ������ 
		*/


		#region public Procedure()
		/// <summary>
		/// ������� ��������� ����� ��� �������������� ����������
		/// </summary>
		public Procedure()
		{
			SmartCoreObjectType = SmartCoreType.Procedure;
			//������ ��� ID � -1
			ItemId = -1;

			// Ad ���������
			ProcedureType = ProcedureType.Unknown;
			ProcedureRating = ProcedureRating.Unknown;
			// ������ ��� String
			Title = Remarks = Description = HiddenRemarks = "";

			AuditedObjectId = -1;
			_performanceRecords = new BaseRecordCollection<DirectiveRecord>();
			_threshold = new MaintenanceDirectiveThreshold();

			PrintInWorkPackage = true;
			Level = 4;
		}
		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(Procedure));
		}
		#endregion

		#region public override string ToString()
		/// <summary>
		/// ����������� ��� �������
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return Title + " " + Description;
		}
		#endregion

		#region public int CompareTo(Procedure y)

		public int CompareTo(Procedure y)
		{
			return ItemId.CompareTo(y.ItemId);
		}

		#endregion

		#region public override int CompareTo(object y)
		public override int CompareTo(object y)
		{
			if (y is Procedure) return ItemId.CompareTo(((Procedure)y).ItemId);
			return 0;
		}
		#endregion

		#region public bool Equals(Procedure other)
		public bool Equals(Procedure other)
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
	}
}
