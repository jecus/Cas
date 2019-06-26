using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("LocationsType", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class LocationsTypeDTO : BaseEntity
	{
		[DataMember]
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

	    [DataMember]
	    [Column("FullName"), MaxLength(256), Required]
		public string FullName { get; set; }

		[DataMember]
		[Column("DepartmentId")]
		public int? DepartmentId { get; set; }

		[DataMember]
		[Include]
		public DepartmentDTO Department { get; set; }

		#region Navigation Property

		[DataMember]
		public ICollection<LocationDTO> LocationDtos { get; set; }
		[DataMember]
		public ICollection<SpecialistDTO> SpecialistDtos { get; set; }

		#endregion
	}
}
