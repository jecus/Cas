using EFCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;

namespace SmartCore.Entities
{
	public class User : BaseEntityObject
	{
		public string Name { get; set; }

		public string Surname { get; set; }

		public string Login { get; set; }

		public string Password { get; set; }

		public UsetType UserType { get; set; }

		public User(IIdentityUser user)
		{
			ItemId = user.ItemId;
			SmartCoreObjectType = SmartCoreType.User;
			Name = user.Name;
			Surname = user.Surname;
			Login = user.Login;
			Password = user.Password;
			UserType = user.UserType;
		}

		public User()
		{
			
		}
	}
}