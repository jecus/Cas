using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class WorkPackageSpecialistsDTO : BaseEntity
	{
		[DataMember]
		public int WorkPackageId { get; set; }

		[DataMember]
		public int SpecialistId { get; set; }
	}
}