using EFCore.DTO;
using EFCore.Repository;

namespace EFCore.UnitOfWork.Providers
{
	public class DatabaseProvider : IConnectProvider
	{
		public IRepository<T> GetRepository<T>() where T : BaseEntity
		{
			//if (!repositories.Contains(typeof(T)))
			//	repositories.Add(typeof(T), new Repository<T>(_context));

			//return (IRepository<T>)repositories[typeof(T)];
			return new Repository<T>(new DataContext());
		}
	}
}