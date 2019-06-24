using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[Table("Cas3MaintenanceCheckType", Schema = "dbo")]
	[DataContract(IsReference = true)]
	public class MaintenanceCheckTypeDTO : BaseEntity
	{
		[DataMember]
		[Column("Name"), MaxLength(50)]
		public string Name { get; set; }

		[DataMember]
		[Column("Priority")]
		public int? Priority { get; set; }

		[DataMember]
		[Column("ShortName"), MaxLength(50)]
		public string ShortName { get; set; }

		#region Navigation Property

		[DataMember]
		public ICollection<MTOPCheckDTO> MtopCheckDtos { get; set; }
		[DataMember]
		public ICollection<MaintenanceCheckDTO> MaintenanceCheckDtos { get; set; }

		#endregion
	}
}