using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;
using Newtonsoft.Json;

namespace EntityCore.DTO.General
{
	[Table("InitionalOrderRecords", Schema = "dbo")]
	
	[Condition("IsDeleted", 0)]
	public class InitialOrderRecordDTO : BaseEntity
	{
		
		[Column("InitialReason")]
		public int? InitialReason { get; set; }

		
		[Column("Priority")]
		public int? Priority { get; set; }

		
		[Column("DestinationObjectID")]
		public int? DestinationObjectID { get; set; }

		
		[Column("DestinationObjectType")]
		public int? DestinationObjectType { get; set; }

		
		[Column("Measure")]
		public int? Measure { get; set; }

		
		[Column("Quantity")]
		public double? Quantity { get; set; }

		
		[Column("DefferedCategory")]
		public int? DefferedCategory { get; set; }

		
		[Column("EffectiveDate")]
		public DateTime? EffectiveDate { get; set; }

		
		[Column("LifeLimit"), MaxLength(21)]
		public byte[] LifeLimit { get; set; }

		
		[Column("LifeLimitNotify"), MaxLength(21)]
		public byte[] LifeLimitNotify { get; set; }

		
		[Column("Processed")]
		public bool? Processed { get; set; }

		
		[Column("ParentPackageId")]
		public int? ParentPackageId { get; set; }

		
		[Column("PackageItemId")]
		public int? PackageItemId { get; set; }

		
		[Column("PackageItemTypeId")]
		public int? PackageItemTypeId { get; set; }

		
		[Column("CostCondition")]
		public short? CostCondition { get; set; }

		
		[Column("ProductId")]
		public int? ProductId { get; set; }

		
		[Column("ProductType")]
		public int? ProductType { get; set; }

		
		[Column("PerfNumFromStart")]
		public int? PerfNumFromStart { get; set; }

		
		[Column("PerfNumFromRecord")]
		public int? PerfNumFromRecord { get; set; }

		
		[Column("FromRecordId")]
		public int? FromRecordId { get; set; }

		
		[Column("IsClosed")]
		public bool? IsClosed { get; set; }

		
		[Column("IsSchedule")]
		public bool? IsSchedule { get; set; }

		
		[Column("Remarks")]
		public string Remarks { get; set; }

		
		[Include]
		public DefferedCategorieDTO DeferredCategory { get; set; }

		#region Navigation Property

		[JsonIgnore]
		public InitialOrderDTO InitialOrderDto { get; set; }

		#endregion


	}
}