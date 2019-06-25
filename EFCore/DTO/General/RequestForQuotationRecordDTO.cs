using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.General
{
	[Table("RequestForQuotationRecords", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class RequestForQuotationRecordDTO : BaseEntity
	{
		[DataMember]
		[Column("ParentPackageId"),Required]
		public int ParentPackageId { get; set; }

		[DataMember]
		[Column("PackageItemId"), Required]
		public int PackageItemId { get; set; }

		[DataMember]
		[Column("CostCondition"), Required]
		public short CostCondition { get; set; }

		[DataMember]
		[Column("Processed"), Required]
		public bool Processed { get; set; }

		[DataMember]
		[Column("PackageItemTypeId")]
		public int? PackageItemTypeId { get; set; }

		[DataMember]
		[Column("Quantity")]
		public double? Quantity { get; set; }

		[DataMember]
		[Column("Measure")]
		public int? Measure { get; set; }

		[DataMember]
		[Column("CostNew")]
		public double? CostNew { get; set; }

		[DataMember]
		[Column("CostOverhaul")]
		public double? CostOverhaul { get; set; }

		[DataMember]
		[Column("CostServiceable")]
		public double? CostServiceable { get; set; }

		[DataMember]
		[Column("ToSupplier")]
		public int? ToSupplierId { get; set; }

		[DataMember]
		[Column("Priority")]
		public int Priority { get; set; }

		[DataMember]
		[Column("DefferedCategory")]
		public int DefferedCategoryId { get; set; }

		[DataMember]
		[Column("DestinationObjectId")]
		public int DestinationObjectId { get; set; }

		[DataMember]
		[Column("DestinationObjectType")]
		public int DestinationObjectType { get; set; }

		[DataMember]
		[Column("InitialReason")]
		public int InitialReason { get; set; }

		[DataMember]
		[Column("Remarks")]
		public string Remarks { get; set; }

		[DataMember]
		[Column("LifeLimit"), MaxLength(21)]
		public byte[] LifeLimit { get; set; }

		[DataMember]
		[Column("LifeLimitNotify"), MaxLength(21)]
		public byte[] LifeLimitNotify { get; set; }

		[DataMember]
		[Column("SettingJSON")]
		public string SettingJSON { get; set; }

		[DataMember]
		[Include]
		public DefferedCategorieDTO DefferedCategory { get; set; }

		#region Navigation Property

		[DataMember]
		public RequestForQuotationDTO RequestForQuotationDto { get; set; }

		#endregion
	}
}