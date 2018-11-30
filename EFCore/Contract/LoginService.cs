using System.Configuration;
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
	}
}