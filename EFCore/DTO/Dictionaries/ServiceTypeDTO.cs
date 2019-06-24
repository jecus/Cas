using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;
using EFCore.DTO.General;

namespace EFCore.DTO.Dictionaries
{
	[Table("ServiceTypes", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class ServiceTypeDTO : BaseEntity
    {

	    [DataMember]
		[Column("Name"), MaxLength(50), Required]
		public string Name { get; set; }

	    [DataMember]
		[Column("FullName"), MaxLength(256)]
		public string FullName { get; set; }

		#region Navigation Property

	    [DataMember]
		public ICollection<DocumentDTO> DocumentDtos { get; set; }

	    #endregion
	}
}
