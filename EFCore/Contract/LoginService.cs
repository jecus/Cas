using System.Linq;
using EFCore.DTO;
using EFCore.DTO.General;

namespace EFCore.Contract
{
	public class LoginService : ILoginService
	{
		public UserDTO GetUser(string login, string password)
		{
			var connection = Helper.Helper.GetConnectionString();
			var context = new DataContext(connection);
			var dbset = context.Set<UserDTO>();
			return dbset.FirstOrDefault(i => i.Login.Equals(login) && i.Password.Equals(password));
		}

		public void UpdatePassword(int id, string password)
		{
			var connection = Helper.Helper.GetConnectionString();
			var context = new DataContext(connection);
			var dbset = context.Set<UserDTO>();
			var user = dbset.FirstOrDefault(i => i.ItemId == id);
			user.Password = password;
			context.SaveChanges();
		}

		public void CreateUser(IIdentityUser user)
		{
			var connection = Helper.Helper.GetConnectionString();
			var context = new DataContext(connection);
			var dbset = context.Set<UserDTO>();
			dbset.Add((UserDTO) user);
			context.SaveChanges();
		}
	}
}