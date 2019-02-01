using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Threading.Tasks;
using EFCore.DTO;
using EFCore.Filter;

namespace EFCore.Repository
{
	[ServiceContract]
	public interface IRepository<T> where T : BaseEntity
	{
		IList<TType> GetSelectColumnOnly<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select) where TType : new();

		[OperationContract]
		IList<int> GetSelectColumnOnly(IEnumerable<Filter.Filter> filters, string selectProperty);

		[OperationContract]
		T GetObjectById(int id, bool loadChild = false);

		[OperationContract]
		T GetObject(IEnumerable<Filter.Filter> filters = null, bool loadChild = false, bool getDeleted = false, bool getAll = false);

		[OperationContract]
		IList<T> GetObjectList(IEnumerable<Filter.Filter> filters = null, bool loadChild = false, bool getDeleted = false);

		[OperationContract]
		IList<T> GetObjectListAll(IEnumerable<Filter.Filter> filters = null, bool loadChild = false, bool getDeleted = false);

		[OperationContract]
		IQueryable<T> GetObjectQueryableAll(IEnumerable<Filter.Filter> filters = null, bool loadChild = false, bool getDeleted = false);

		[OperationContract]
		int Save(T entity);

		[OperationContract]
		void Delete(T entity);


		#region Async

		[OperationContract]
		Task<T> GetObjectByIdAsync(int id, bool loadChild = false);

		[OperationContract]
		Task<T> GetObjectAsync(IEnumerable<Filter.Filter> filters = null, bool loadChild = false, bool getDeleted = false, bool getAll = false);

		[OperationContract]
		Task<IList<T>> GetObjectListAsync(IEnumerable<Filter.Filter> filters = null, bool loadChild = false, bool getDeleted = false);

		[OperationContract]
		Task<IList<T>> GetObjectListAllAsync(IEnumerable<Filter.Filter> filters = null, bool loadChild = false, bool getDeleted = false);

		[OperationContract]
		Task<int> SaveAsync(T entity);

		[OperationContract]
		Task DeleteAsync(T entity);

		#endregion
	}
}