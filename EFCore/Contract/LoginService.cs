using System.Collections.Generic;
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
			return context.UserDtos.FirstOrDefault(i => i.Login.Equals(login) && i.Password.Equals(password));
		}

		public void UpdatePassword(int id, string password)
		{
			var connection = Helper.Helper.GetConnectionString();
			var context = new DataContext(connection);
			var user = context.UserDtos.FirstOrDefault(i => i.ItemId == id);
			user.Password = password;
			context.SaveChanges();
		}

		public void CreateUser(IIdentityUser user)
		{
			var connection = Helper.Helper.GetConnectionString();
			var context = new DataContext(connection);
			context.UserDtos.Add((UserDTO) user);
			context.SaveChanges();
		}

		public List<UserDTO> GetAllList()
		{
			var connection = Helper.Helper.GetConnectionString();
			var context = new DataContext(connection);
			return context.UserDtos.Where(i => !i.IsDeleted).ToList();
		}

		public void DeleteUser(int id)
		{
			var connection = Helper.Helper.GetConnectionString();
			var context = new DataContext(connection);
			var user = context.UserDtos.FirstOrDefault(i => i.ItemId == id);
			if (user != null)
			{
				user.IsDeleted = true;
				context.SaveChanges();
			}
		}

		public void AddOrUpdateUser(UserDTO user)
		{
			var connection = Helper.Helper.GetConnectionString();
			var context = new DataContext(connection);

			if (user.ItemId > 0)
			{
				var updateUser = context.UserDtos.FirstOrDefault(i => i.ItemId == user.ItemId);
				updateUser.Login = user.Login;
				updateUser.Password = user.Password;
				updateUser.Name = user.Name;
				updateUser.Password = user.Password;
				updateUser.UserType = user.UserType;
			}
			else
			{
				var newUser = new UserDTO();
				newUser.Login = user.Login;
				newUser.Password = user.Password;
				newUser.Name = user.Name;
				newUser.Surname = user.Surname;
				newUser.UserType = user.UserType;

				context.UserDtos.Add(newUser);

			}

			context.SaveChanges();

		}

	}
}