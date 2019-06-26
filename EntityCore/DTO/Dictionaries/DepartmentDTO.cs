using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("Departments", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class DepartmentDTO : BaseEntity
	{
		[DataMember]
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

	    [DataMember]
	    [Column("FullName"), MaxLength(256), Required]
		public string FullName { get; set; }


		#region Navigation Property

	    [DataMember]
		public ICollection<DocumentDTO> DocumentDtos { get; set; }
	    [DataMember]
		public ICollection<SpecializationDTO> SpecializationDtos { get; set; }
	    [DataMember]
		public ICollection<NomenclatureDTO> NomenclatureDtos { get; set; }

		[DataMember]
		public ICollection<LocationsTypeDTO> LocationsTypeDtos { get; set; }
		#endregion
	}
}
