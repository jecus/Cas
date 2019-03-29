using EFCore.Repository;
using EFCore.UnitOfWork.Providers;
using BaseEntity = EFCore.DTO.BaseEntity;

namespace EFCore.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly IConnectProvider _connectProvider;

		public UnitOfWork(IConnectProvider connectProvider)
		{
			_connectProvider = connectProvider;
		}

		public IRepository<T> GetRepository<T>() where T : BaseEntity
		{
			return _connectProvider.GetRepository<T>();
		}
	}
}