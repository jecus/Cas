using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.General;

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

	    
	    [Column("Level"), Required]
		public int Level { get; set; }

	    
	    [Column("KeyPersonel"), Required]
		public bool KeyPersonel { get; set; }


	    
		[Include]
	    public DepartmentDTO Department { get; set; }


		#region Navigation Property

	    
		public ICollection<DocumentDTO> DocumentDtos { get; set; }
	    
		public ICollection<FlightCrewRecordDTO> FlightCrewRecordDtos { get; set; }
	    
		public ICollection<FlightNumberCrewRecordDTO> FlightNumberCrewRecordDtos { get; set; }
	    
		public ICollection<SpecialistDTO> SpecialistDtos { get; set; }

		#endregion
	}
}
