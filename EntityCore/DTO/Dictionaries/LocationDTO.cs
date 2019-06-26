using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("Locations", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class LocationDTO : BaseEntity
	{
		[DataMember]
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

	    [DataMember]
	    [Column("FullName"), MaxLength(256), Required]
		public string FullName { get; set; }

	    [DataMember]
	    [Column("LocationsTypeId")]
		public int? LocationsTypeId { get; set; }

	    [DataMember]
		[Child]
	    public LocationsTypeDTO LocationsType { get; set; }


		#region Navigation Property

	    [DataMember]
		public ICollection<ComponentDTO> ComponentDtos { get; set; }
	    [DataMember]
		public ICollection<DocumentDTO> DocumentDtos { get; set; }

	    #endregion

	}
}
