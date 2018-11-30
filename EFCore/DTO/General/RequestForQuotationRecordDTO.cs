using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class RequestForQuotationRecordDTO : BaseEntity
	{
		[DataMember]
		public int ParentPackageId { get; set; }

		[DataMember]
		public int PackageItemId { get; set; }

		[DataMember]
		public short CostCondition { get; set; }

		[DataMember]
		public bool Processed { get; set; }

		[DataMember]
		public int? PackageItemTypeId { get; set; }

		[DataMember]
		public double? Quantity { get; set; }

		[DataMember]
		public int? Measure { get; set; }

		[DataMember]
		public double? CostNew { get; set; }

		[DataMember]
		public double? CostOverhaul { get; set; }

		[DataMember]
		public double? CostServiceable { get; set; }

		[DataMember]
		public int? ToSupplierId { get; set; }

		[DataMember]
		public int Priority { get; set; }

		[DataMember]
		public int DefferedCategoryId { get; set; }

		[DataMember]
		public int DestinationObjectId { get; set; }

		[DataMember]
		public int DestinationObjectType { get; set; }

		[DataMember]
		public int InitialReason { get; set; }

		[DataMember]
		[Include]
		public DefferedCategorieDTO DefferedCategory { get; set; }

		[DataMember]
		[Include]
		public SupplierDTO ToSupplier { get; set; }


		#region Navigation Property

		[DataMember]
		public RequestForQuotationDTO RequestForQuotationDto { get; set; }

		#endregion
	}
}