using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;

namespace EntityCore.DTO.General
{
	[Table("QuotationCost", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class QuotationCostDTO : BaseEntity
	{
		[DataMember]
		[Column("CostNew")]
		public double CostNew { get; set; }

		[DataMember]
		[Column("ProductId")]
		public int ProductId { get; set; }

		[DataMember]
		[Column("SupplierId")]
		public int SupplierId { get; set; }

		[DataMember]
		[Column("QuotationId")]
		public int QuotationId { get; set; }

		[DataMember]
		[Column("CostServisible")]
		public double CostServisible { get; set; }

		[DataMember]
		[Column("CostOverhaul")]
		public double CostOverhaul { get; set; }

		[DataMember]
		[Column("CurrencyId")]
		public int CurrencyId { get; set; }

	}
}