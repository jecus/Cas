using System.ServiceModel;

namespace EFCore.Contract
{
	[ServiceContract]
	public interface IConnectionService
	{
		[OperationContract]
		Connection GetConnection();
	}
}