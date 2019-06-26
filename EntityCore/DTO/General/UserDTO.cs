using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using EntityCore.Attributte;
using EntityCore.Interfaces;

namespace EntityCore.DTO.General
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
	
	[Condition("IsDeleted", 0)]
	public class UserDTO : BaseEntity, IIdentityUser
	{
		
		[Column("Name"), MaxLength(100)]
		public string Name { get; set; }

		
		[Column("Surname"), MaxLength(100)]
		public string Surname { get; set; }

		
		[Column("Login"), MaxLength(100)]
		public string Login { get; set; }

		
		[Column("Password"), MaxLength(100)]
		public string Password { get; set; }

		
		[Column("UserType")]
		public UsetType UserType { get; set; }

		
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