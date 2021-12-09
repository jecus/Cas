using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entity.Models.Attributte;
using EntityCore.DTO;
using Newtonsoft.Json;
using DirectiveDTO = Entity.Models.DTO.General.DirectiveDTO;
using InitialOrderRecordDTO = Entity.Models.DTO.General.InitialOrderRecordDTO;
using RequestForQuotationRecordDTO = Entity.Models.DTO.General.RequestForQuotationRecordDTO;

namespace Entity.Models.DTO.Dictionaries
{
	[Table("DefferedCategories", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class DefferedCategorieDTO : BaseEntity, IBaseDictionary
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

		[JsonIgnore]
		public ICollection<InitialOrderRecordDTO> InitialOrderRecordDto { get; set; }
		[JsonIgnore]
		public ICollection<RequestForQuotationRecordDTO> RequestForQuotationRecordDtos { get; set; }
		[JsonIgnore]
		public ICollection<DirectiveDTO> DirectiveDtos { get; set; }

		#endregion
	}
}
