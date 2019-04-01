using System;
using System.Collections.Generic;
using System.Reflection;
using EFCore.DTO.General;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.MTOP
{
	[Table("MTOPCheck", "dbo", "ItemId")]
	[Dto(typeof(MTOPCheckDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class MTOPCheck : BaseEntityObject
	{
		private static Type _thisType;

		#region public string Name { get; set; }

		[TableColumn("Name")]
		public string Name { get; set; }

		#endregion

		#region public int ParentAircraftId { get; set; }
		[TableColumn("ParentAircraftId")]
		public int ParentAircraftId { get; set; }

		public static PropertyInfo ParentAircraftIdProperty
		{
			get { return GetCurrentType().GetProperty("ParentAircraftId"); }
		}

		#endregion

		#region public MaintenanceCheckType CheckType { get; set; }

		private MaintenanceCheckType _checkType;

		[TableColumn("CheckTypeId")]
		public MaintenanceCheckType CheckType
		{
			get { return _checkType ?? MaintenanceCheckType.Unknown; }
			set { _checkType = value; }
		}

		#endregion

		#region public Lifelength Thresh { get; set; }

		private Lifelength _thresh;
		
		[TableColumn("Thresh")]
		public Lifelength Thresh
		{
			get { return _thresh ?? Lifelength.Null; }
			set { _thresh = value; }
		}


		#endregion

		#region public Lifelength Repeat { get; set; }

		private Lifelength _repeat;

		[TableColumn("Repeat")]
		public Lifelength Repeat
		{
			get { return _repeat ?? Lifelength.Null; }
			set { _repeat = value; }
		}

		#endregion

		#region public Lifelength Notify { get; set; }

		private Lifelength _notify;

		[TableColumn("Notify")]
		public Lifelength Notify
		{
			get { return _notify ?? Lifelength.Null; }
			set { _notify = value; }
		}


		#endregion

		#region public bool IsZeroPhase { get; set; }

		[TableColumn("IsZeroPhase")]
		public bool IsZeroPhase { get; set; }

		#endregion

		#region public BaseRecordCollection<Cas3MaintenancePerformanceItem> PerformanceRecords

		private CommonCollection<MTOPCheckRecord> _performanceRecords;
		/// <summary>
		/// 
		/// </summary>
		[Child(RelationType.OneToMany, "ParentId")]
		public CommonCollection<MTOPCheckRecord> PerformanceRecords
		{
			get { return _performanceRecords ?? (_performanceRecords = new CommonCollection<MTOPCheckRecord>()); }
			set { _performanceRecords = value; }
		}
		#endregion


		#region CalculatedProperty

		public Lifelength PhaseThresh { get; set; }
		public Lifelength PhaseThreshLimit { get; set; }
		public Lifelength PhaseRepeat { get; set; }
		public Lifelength PhaseRepeatLimit { get; set; }
		public double PhaseInMonth { get; set; }
		public NextPerformance NextPerformance { get; set; }
		public List<NextPerformance> NextPerformances { get; set; }
		public List<NextPerformance> NextPerformancesWithIgnorLast { get; set; }
		public int Group { get; set; }

		public AverageUtilization AverageUtilization { get; set; }

		#endregion


		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(MTOPCheck));
		}
		#endregion

		#region public MTOPCheck()

		public MTOPCheck()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.MTOPCheck;
		}

		#endregion

		public override string ToString()
		{
			return Name;
		}
	}
}