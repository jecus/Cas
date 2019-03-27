using System.ServiceModel;
using EFCore.DTO.General;

namespace EFCore.Contract
{
	[ServiceContract]
	public interface ILoginService
	{
		[OperationContract]
		UserDTO GetUser(string login, string password);

		[OperationContract]
		void UpdatePassword(int id, string password);
	}
}