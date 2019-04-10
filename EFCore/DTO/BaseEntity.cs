using System.Runtime.Serialization;
using EFCore.Interfaces;

namespace EFCore.DTO
{
	[DataContract(IsReference = true)]
	public class BaseEntity : IBaseEntity
	{
		[DataMember]
		public bool IsDeleted { get; set; }

		[DataMember]
		public int ItemId { get; set; }

		[DataMember]
		public int CorrectorId { get; set; }
	}
}