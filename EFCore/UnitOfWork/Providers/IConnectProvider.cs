using EFCore.DTO;
using EFCore.Repository;

namespace EFCore.UnitOfWork.Providers
{
	public interface IConnectProvider
	{
		IRepository<T> GetRepository<T>() where T : BaseEntity;
	}
}