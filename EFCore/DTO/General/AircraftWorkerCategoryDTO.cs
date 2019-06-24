using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[Table("AircraftWorkerCategories", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class AircraftWorkerCategoryDTO : BaseEntity
	{
		[DataMember]
		[Column("Category"), MaxLength(128)]
		public string Category { get; set; }

		#region Navigation Property

		[DataMember]
		public ICollection<ModuleRecordDTO> ModuleRecordDtos { get; set; }
		[DataMember]
		public ICollection<CategoryRecordDTO> CategoryRecordDtos { get; set; }
		[DataMember]
		public ICollection<JobCardDTO> JobCardDtos { get; set; }

		#endregion
	}
}