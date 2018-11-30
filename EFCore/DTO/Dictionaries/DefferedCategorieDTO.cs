using System.Collections.Generic;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	//DefferedCategory
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class DefferedCategorieDTO : BaseEntity
	{
		[DataMember]
		public string CategoryName { get; set; }

		[DataMember]
		public int? AircraftModelId { get; set; }

		[DataMember]
		public byte[] Threshold { get; set; }

		[DataMember]
		[Child]
	    public AccessoryDescriptionDTO AccessoryDescription { get; set; }

		#region Navigation Property

		[DataMember]
		public ICollection<InitialOrderRecordDTO> InitialOrderRecordDto { get; set; }

		[DataMember]
		public ICollection<RequestForQuotationRecordDTO> RequestForQuotationRecordDtos { get; set; }
		[DataMember]
		public ICollection<DirectiveDTO> DirectiveDtos { get; set; }

		#endregion
	}
}
