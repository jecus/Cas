using System.Collections.Generic;
using System.ServiceModel;
using EFCore.DTO.General;
using SmartCore.Entities;

namespace EFCore.Contract
{
	[ServiceContract]
	public interface ILoginService
	{
		[OperationContract]
		UserDTO GetUser(string login, string password);

		[OperationContract]
		void UpdatePassword(int id, string password);

		[OperationContract]
		void CreateUser(IIdentityUser user);

		[OperationContract]
		List<UserDTO> GetAllList();

		[OperationContract]
		void DeleteUser(int id);

		[OperationContract]
		void AddOrUpdateUser(User user);
	}
}