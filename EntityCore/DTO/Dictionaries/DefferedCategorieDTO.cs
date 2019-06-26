using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("DefferedCategories", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class DefferedCategorieDTO : BaseEntity
	{
		
		[Column("CategoryName"), MaxLength(50)]
		public string CategoryName { get; set; }

		
		[Column("AircraftModelId")]
		public int? AircraftModelId { get; set; }

		
		[Column("Threshold")]
		public byte[] Threshold { get; set; }

		
		[Child]
	    public AccessoryDescriptionDTO AccessoryDescription { get; set; }

		#region Navigation Property

		
		public ICollection<InitialOrderRecordDTO> InitialOrderRecordDto { get; set; }

		
		public ICollection<RequestForQuotationRecordDTO> RequestForQuotationRecordDtos { get; set; }
		
		public ICollection<DirectiveDTO> DirectiveDtos { get; set; }

		#endregion
	}
}
