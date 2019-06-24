using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Security.Principal;
using EFCore.Attributte;
using EFCore.Interfaces;

namespace EFCore.DTO.General
{
	public enum UsetType
	{
		Admin,
		SuperUser,
		ReadOnly,
		SaveOnly
	}

	public enum UiType
	{
		All
	}

	[Table("Users", Schema = "dbo")]
	[DataContract(IsReference = true)]
	[Condition("IsDeleted", 0)]
	public class UserDTO : BaseEntity, IIdentityUser
	{
		[DataMember]
		[Column("Name"), MaxLength(100)]
		public string Name { get; set; }

		[DataMember]
		[Column("Surname"), MaxLength(100)]
		public string Surname { get; set; }

		[DataMember]
		[Column("Login"), MaxLength(100)]
		public string Login { get; set; }

		[DataMember]
		[Column("Password"), MaxLength(100)]
		public string Password { get; set; }

		[DataMember]
		[Column("UserType")]
		public UsetType UserType { get; set; }

		[DataMember]
		[Column("UiType")]
		public UiType UiType { get; set; }

		public override string ToString()
		{
			return Name.Equals(Surname) ? Name : $"{Surname} {Name}";
		}
	}

	public interface IIdentityUser : IBaseEntity
	{
		string Name { get; set; }
		string Surname { get; set; }
		string Login { get; set; }
		string Password { get; set; }
		UsetType UserType { get; set; }
		UiType UiType { get; set; }

	}
}