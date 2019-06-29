using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityCore.Attributte;
using EntityCore.DTO.General;
using Newtonsoft.Json;

namespace EntityCore.DTO.Dictionaries
{
	[Table("Specializations", Schema = "Dictionaries")]
	
	[Condition("IsDeleted", 0)]
	public class SpecializationDTO : BaseEntity
	{
		
		[Column("FullName"), MaxLength(128)]
		public string FullName { get; set; }

	    
	    [Column("ShortName"), MaxLength(128)]
		public string ShortName { get; set; }

	    
	    [Column("DepartmentId")]
		public int? DepartmentId { get; set; }

	    
	    [Column("Level")]
		public int Level { get; set; }

	    
	    [Column("KeyPersonel")]
		public bool KeyPersonel { get; set; }


	    
		[Include]
	    public DepartmentDTO Department { get; set; }


		#region Navigation Property

		[JsonIgnore]
		public ICollection<DocumentDTO> DocumentDtos { get; set; }
		[JsonIgnore]
		public ICollection<FlightCrewRecordDTO> FlightCrewRecordDtos { get; set; }
		[JsonIgnore]
		public ICollection<FlightNumberCrewRecordDTO> FlightNumberCrewRecordDtos { get; set; }
		[JsonIgnore]
		public ICollection<SpecialistDTO> SpecialistDtos { get; set; }

		#endregion
	}
}
