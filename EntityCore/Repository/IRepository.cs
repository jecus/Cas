using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EntityCore.DTO;

namespace EntityCore.Repository
{

	public interface IRepository<T> where T : BaseEntity
	{
		IList<TType> GetSelectColumnOnly<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select) where TType : new();

		IList<int> GetSelectColumnOnly(IEnumerable<Filter.Filter> filters, string selectProperty);

		T GetObjectById(int id, bool loadChild = false);

		T GetObject(IEnumerable<Filter.Filter> filters = null, bool loadChild = false, bool getDeleted = false, bool getAll = false);

		IList<T> GetObjectList(IEnumerable<Filter.Filter> filters = null, bool loadChild = false, bool getDeleted = false);

		IList<T> GetObjectListAll(IEnumerable<Filter.Filter> filters = null, bool loadChild = false, bool getDeleted = false);

		int Save(T entity);

		void BulkInsert(IEnumerable<T> entity, int? batchSize = null);

		void BulkUpdate(IEnumerable<T> entity, int? batchSize = null);

		void BulkDelete(IEnumerable<T> entity, int? batchSize = null);

		void Delete(T entity);


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