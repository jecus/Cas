using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class DirectiveRecordDTO : BaseEntity, IFileDtoContainer
	{
		[DataMember]
		public int? NumGroup { get; set; }

		[DataMember]
		public int RecordTypeID { get; set; }

		[DataMember]
		public int ParentID { get; set; }

		[DataMember]
		public int ParentTypeId { get; set; }

		[DataMember]
		public string Remarks { get; set; }

		[DataMember]
		public DateTime RecordDate { get; set; }

		[DataMember]
		public byte[] OnLifelength { get; set; }

		[DataMember]
		public byte[] Unused { get; set; }

		[DataMember]
		public byte[] Overused { get; set; }

		[DataMember]
		public int? WorkPackageID { get; set; }

		[DataMember]
		public DateTime? Dispatched { get; set; }

		[DataMember]
		public bool? Completed { get; set; }

		[DataMember]
		public string Reference { get; set; }

		[DataMember]
		public bool? ODR { get; set; }

		[DataMember]
		public string MaintenanceOrganization { get; set; }

		[DataMember]
		public int? MaintenanceDirectiveRecordId { get; set; }

		[DataMember]
		public int? MaintenanceCheckRecordId { get; set; }

		[DataMember]
		public int? PerformanceNum { get; set; }

		[DataMember]
		public bool IsControlPoint { get; set; }

		[DataMember]
		public byte[] CalculatedPerformanceSource { get; set; }

		[DataMember]
		public string ComplianceCheckName { get; set; }



		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1260)]
		public ICollection<ItemFileLinkDTO> Files { get; set; }

		[DataMember]
		[Child(FilterType.Equal, "ParentTypeId", 1680)]
		public ICollection<ItemFileLinkDTO> FilesForMaintenanceCheckRecord { get; set; }

		#region Navigation Property

		[DataMember]
		public ComponentDirectiveDTO ComponentDirective { get; set; }
		[DataMember]
		public DirectiveDTO Directive { get; set; }
		[DataMember]
		public ProcedureDTO Procedure { get; set; }
		[DataMember]
		public MaintenanceDirectiveDTO MaintenanceDirective { get; set; }
		[DataMember]
		public MaintenanceCheckDTO MaintenanceCheckDto { get; set; }

		#endregion
	}
}