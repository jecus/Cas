using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class UserMap : BaseMap<UserDTO>
	{
		public UserMap() : base()
		{
			ToTable("dbo.Users");

			Property(i => i.Name)
				.HasMaxLength(100)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Name");

			Property(i => i.Surname)
				.HasMaxLength(100)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Surname");


			Property(i => i.Password)
				.HasMaxLength(100)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Password");

			Property(i => i.Login)
				.HasMaxLength(100)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Login");

			Property(i => i.UserType)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("UserType");
		}
	}
}