using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("AircraftOtherParameters", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
    public class AircraftOtherParameterDTO : BaseEntity
	{
		[DataMember]
		[Column("Name"), MaxLength(50), Required]
		public string Name { get; set; }

	    [DataMember]
	    [Column("FullName"), MaxLength(256)]
		public string FullName { get; set; }


		#region Navigation Property

		[DataMember]
		public ICollection<AircraftEquipmentDTO> AircraftEquipmentDtos { get; set; }

	    #endregion
    }
}
