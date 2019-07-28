using System.Collections.Generic;
using System.Threading.Tasks;
using EntityCore.DTO;

namespace EntityCore.Repository
{

	public interface IRepository<T> where T : BaseEntity
	{
		#region Async


		Task<T> GetObjectByIdAsync(int id, bool loadChild = false);

		Task<T> GetObjectAsync(IEnumerable<Filter.Filter> filters = null, bool loadChild = false, bool getDeleted = false, bool getAll = false);

		Task<IList<T>> GetObjectListAsync(IEnumerable<Filter.Filter> filters = null, bool loadChild = false, bool getDeleted = false);

		Task<IList<T>> GetObjectListAllAsync(IEnumerable<Filter.Filter> filters = null, bool loadChild = false, bool getDeleted = false);

		Task<int> SaveAsync(T entity);

		Task DeleteAsync(T entity);

		#endregion
	}
}