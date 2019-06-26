using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("DefferedCategories", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class DefferedCategorieDTO : BaseEntity
	{
		[DataMember]
		[Column("CategoryName"), MaxLength(50)]
		public string CategoryName { get; set; }

		[DataMember]
		[Column("AircraftModelId")]
		public int? AircraftModelId { get; set; }

		[DataMember]
		[Column("Threshold")]
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
