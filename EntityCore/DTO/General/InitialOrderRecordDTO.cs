using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.Dictionaries;

namespace EntityCore.DTO.General
{
	[Table("InitionalOrderRecords", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class InitialOrderRecordDTO : BaseEntity
	{
		[DataMember]
		[Column("InitialReason")]
		public int? InitialReason { get; set; }

		[DataMember]
		[Column("Priority")]
		public int? Priority { get; set; }

		[DataMember]
		[Column("DestinationObjectID")]
		public int? DestinationObjectID { get; set; }

		[DataMember]
		[Column("DestinationObjectType")]
		public int? DestinationObjectType { get; set; }

		[DataMember]
		[Column("Measure")]
		public int? Measure { get; set; }

		[DataMember]
		[Column("Quantity")]
		public double? Quantity { get; set; }

		[DataMember]
		[Column("DefferedCategory")]
		public int? DefferedCategory { get; set; }

		[DataMember]
		[Column("EffectiveDate")]
		public DateTime? EffectiveDate { get; set; }

		[DataMember]
		[Column("LifeLimit"), MaxLength(21)]
		public byte[] LifeLimit { get; set; }

		[DataMember]
		[Column("LifeLimitNotify"), MaxLength(21)]
		public byte[] LifeLimitNotify { get; set; }

		[DataMember]
		[Column("Processed")]
		public bool? Processed { get; set; }

		[DataMember]
		[Column("ParentPackageId")]
		public int? ParentPackageId { get; set; }

		[DataMember]
		[Column("PackageItemId")]
		public int? PackageItemId { get; set; }

		[DataMember]
		[Column("PackageItemTypeId")]
		public int? PackageItemTypeId { get; set; }

		[DataMember]
		[Column("CostCondition")]
		public short? CostCondition { get; set; }

		[DataMember]
		[Column("ProductId")]
		public int? ProductId { get; set; }

		[DataMember]
		[Column("ProductType")]
		public int? ProductType { get; set; }

		[DataMember]
		[Column("PerfNumFromStart")]
		public int? PerfNumFromStart { get; set; }

		[DataMember]
		[Column("PerfNumFromRecord")]
		public int? PerfNumFromRecord { get; set; }

		[DataMember]
		[Column("FromRecordId")]
		public int? FromRecordId { get; set; }

		[DataMember]
		[Column("IsClosed")]
		public bool? IsClosed { get; set; }

		[DataMember]
		[Column("IsSchedule")]
		public bool? IsSchedule { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Include]
		public DefferedCategorieDTO DeferredCategory { get; set; }

		#region Navigation Property

		[DataMember]
		public InitialOrderDTO InitialOrderDto { get; set; }

		#endregion


	}
}