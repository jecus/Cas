using System;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class InitialOrderRecordDTO : BaseEntity
	{
		[DataMember]
		public int? InitialReason { get; set; }

		[DataMember]
		public int Priority { get; set; }

		[DataMember]
		public int? DestinationObjectID { get; set; }

		[DataMember]
		public int? DestinationObjectType { get; set; }

		[DataMember]
		public int? Measure { get; set; }

		[DataMember]
		public double? Quantity { get; set; }

		[DataMember]
		public int? DefferedCategory { get; set; }

		[DataMember]
		public DateTime? EffectiveDate { get; set; }

		[DataMember]
		public byte[] LifeLimit { get; set; }

		[DataMember]
		public byte[] LifeLimitNotify { get; set; }

		[DataMember]
		public bool? Processed { get; set; }

		[DataMember]
		public int? ParentPackageId { get; set; }

		[DataMember]
		public int? PackageItemId { get; set; }

		[DataMember]
		public int? PackageItemTypeId { get; set; }

		[DataMember]
		public short? CostCondition { get; set; }

		[DataMember]
		public int? ProductId { get; set; }

		[DataMember]
		public int? ProductType { get; set; }

		[DataMember]
		public int? PerfNumFromStart { get; set; }

		[DataMember]
		public int? PerfNumFromRecord { get; set; }

		[DataMember]
		public int? FromRecordId { get; set; }

		[DataMember]
		public bool? IsClosed { get; set; }

		[DataMember]
		public bool? IsSchedule { get; set; }

		[DataMember]
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