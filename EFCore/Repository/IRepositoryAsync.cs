using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Threading.Tasks;
using EFCore.DTO;

namespace EFCore.Repository
{
	[ServiceContract]
	public interface IRepositoryAsync<T> where T : BaseEntity
	{
		Task<IList<TType>> GetSelectColumnOnlyAsync<TType>(Expression<Func<T, bool>> where, Expression<Func<T, TType>> select, bool readOnly = true) where TType : new();

		[OperationContract]
		IList<int> GetSelectColumnOnlyAsync(IEnumerable<Filter.Filter> filters, string selectProperty);

		[OperationContract]
		List<T> GetAllAsync();

		[OperationContract]
		T GetObjectByIdAsync(int id, bool loadChild = false);

		[OperationContract]
		T GetObjectAsync(IEnumerable<Filter.Filter> filters = null, bool loadChild = false, bool getDeleted = false, bool getAll = false);

		[OperationContract]
		IList<T> GetObjectListAsync(IEnumerable<Filter.Filter> filters = null, bool readOnly = true, bool loadChild = false, bool getDeleted = false);

		[OperationContract]
		IList<T> GetObjectListAllAsync(IEnumerable<Filter.Filter> filters = null, bool readOnly = true, bool loadChild = false, bool getDeleted = false);

		[OperationContract]
		IQueryable<T> GetObjectQueryableAllAsync(IEnumerable<Filter.Filter> filters = null, bool readOnly = true, bool loadChild = false, bool getDeleted = false);

		[OperationContract]
		int SaveAsync(T entity);

		[OperationContract]
		void DeleteAsync(T entity);
	}
}