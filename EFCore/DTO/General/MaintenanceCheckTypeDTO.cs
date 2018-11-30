using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	public class MaintenanceCheckTypeDTO : BaseEntity
	{
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public int? Priority { get; set; }

		[DataMember]
		public string ShortName { get; set; }

		#region Navigation Property

		[DataMember]
		public ICollection<MTOPCheckDTO> MtopCheckDtos { get; set; }
		[DataMember]
		public ICollection<MaintenanceCheckDTO> MaintenanceCheckDtos { get; set; }

		#endregion
	}
}