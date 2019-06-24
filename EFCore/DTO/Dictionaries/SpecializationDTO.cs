using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	[Table("Specializations", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class SpecializationDTO : BaseEntity
	{
		[DataMember]
		[Column("FullName"), MaxLength(128)]
		public string FullName { get; set; }

	    [DataMember]
	    [Column("ShortName"), MaxLength(128)]
		public string ShortName { get; set; }

	    [DataMember]
	    [Column("DepartmentId"), Required]
		public int DepartmentId { get; set; }

	    [DataMember]
	    [Column("Level"), Required]
		public int Level { get; set; }

	    [DataMember]
	    [Column("KeyPersonel"), Required]
		public bool KeyPersonel { get; set; }


	    [DataMember]
		[Include]
	    public DepartmentDTO Department { get; set; }


		#region Navigation Property

	    [DataMember]
		public ICollection<DocumentDTO> DocumentDtos { get; set; }
	    [DataMember]
		public ICollection<FlightCrewRecordDTO> FlightCrewRecordDtos { get; set; }
	    [DataMember]
		public ICollection<FlightNumberCrewRecordDTO> FlightNumberCrewRecordDtos { get; set; }
	    [DataMember]
		public ICollection<SpecialistDTO> SpecialistDtos { get; set; }

		#endregion
	}
}
