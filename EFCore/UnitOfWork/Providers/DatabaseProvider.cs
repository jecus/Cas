using EFCore.DTO;
using EFCore.Repository;

namespace EFCore.UnitOfWork.Providers
{
	public class DatabaseProvider : IConnectProvider
	{
		public IRepository<T> GetRepository<T>() where T : BaseEntity
		{
			return new Repository<T>(new DataContext());
		}
	}
}