using System;
using EFCore.DTO.General;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Entities.General.MTOP
{
	[Table("MTOPCheckRecords", "dbo", "ItemId")]
	[Dto(typeof(MTOPCheckRecordDTO))]
	[Condition("IsDeleted", "0")]
	[Serializable]
	public class MTOPCheckRecord : BaseEntityObject
	{
		#region public AverageUtilization AverageUtilization { get; set; }
		[TableColumn("AverageUtilization")]
		public AverageUtilization AverageUtilization { get; set; }
		#endregion

		#region public Lifelength CalculatedPerformanceSource { get; set; }

		[TableColumn("CalculatedPerformanceSource")]
		public Lifelength CalculatedPerformanceSource { get; set; }

		#endregion

		#region public bool IsControlPoint { get; set; }

		[TableColumn("IsControlPoint")]
		public bool IsControlPoint { get; set; }

		#endregion

		#region public DateTime RecordDate { get; set; }

		[TableColumn("RecordDate")]
		public DateTime RecordDate { get; set; }

		#endregion

		#region public string CheckName { get; set; }

		[TableColumn("CheckName")]
		public string CheckName { get; set; }

		#endregion

		#region public int Group { get; set; }

		[TableColumn("GroupName")]
		public int GroupName { get; set; }

		#endregion

		#region public int ParentId { get; set; }

		[TableColumn("ParentId")]
		public int ParentId { get; set; }

		public MTOPCheck Parent { get; set; }

		#endregion

		#region public string Remarks { get; set; }

		[TableColumn("Remarks")]
		public string Remarks { get; set; }

		#endregion

		#region public MTOPCheckRecord()

		public MTOPCheckRecord()
		{
			ItemId = -1;
			SmartCoreObjectType = SmartCoreType.MTOPCheckRecord;
		}

		#endregion
	}
}