using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class QuotationCostDTO : BaseEntity
	{
		[DataMember]
		public double CostNew { get; set; }

		[DataMember]
		public int ProductId { get; set; }

		[DataMember]
		public int SupplierId { get; set; }

		[DataMember]
		public int QuotationId { get; set; }

		[DataMember]
		public double CostServisible { get; set; }

		[DataMember]
		public double CostOverhaul { get; set; }

		[DataMember]
		public int CurrencyId { get; set; }

	}
}