using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Abstractions;
using Entity.Abstractions.Filters;

namespace CAA.Entity.Core.Repository
{

	public interface IRepository<T> where T : BaseEntity
	{
		#region Async


		Task<T> GetObjectByIdAsync(int id, bool loadChild = false);

		Task<T> GetObjectAsync(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false, bool getAll = false);

		Task<IList<T>> GetObjectListAsync(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false);

		Task<IList<T>> GetObjectListAllAsync(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false);

		Task<int> SaveAsync(T entity);

		Task DeleteAsync(T entity);

		#endregion
	}
}