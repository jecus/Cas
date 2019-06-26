using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.DTO.General;

namespace EntityCore.DTO.Dictionaries
{
	[Table("DocumentSubType", Schema = "Dictionaries")]
	[DataContract(IsReference = true)]
	public class DocumentSubTypeDTO : BaseEntity
	{
		[DataMember]
		[Column("DocumentTypeId"), Required]
		public int DocumentTypeId { get; set; }

	    [DataMember]
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

		#region Navigation Property

	    [DataMember]
		public ICollection<DocumentDTO> DocumentDtos { get; set; }

	    #endregion
    }
}
