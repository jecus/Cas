using System.Runtime.Serialization;
using EFCore.Attributte;

namespace EFCore.DTO.General
{
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class UserDTO : BaseEntity
	{
		[DataMember]
		public string Name { get; set; }

		[DataMember]
		public string Surname { get; set; }

		[DataMember]
		public string Login { get; set; }

		[DataMember]
		public string Password { get; set; }

		public override string ToString()
		{
			return Name.Equals(Surname) ? Name : $"{Surname} {Name}";
		}
	}
}