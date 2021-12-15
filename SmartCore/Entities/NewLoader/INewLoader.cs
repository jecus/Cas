using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EntityCore.DTO;
using EntityCore.Filter;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Deprecated;
using SmartCore.Management;
using SmartCore.Queries;

namespace SmartCore.Entities.NewLoader
{
	public interface INewLoader
	{
		DataSet Execute(string sql);
		DataSet Execute(IEnumerable<DbQuery> dbQueries, out List<ExecutionResultArgs> results);
		DataSet Execute(string query, SqlParameter[] parameters);

		IList<int> GetSelectColumnOnly<T>(IEnumerable<Filter> filters, string selectProperty)
			where T : BaseEntity;

		TOut GetObjectById<T, TOut>(int id, bool loadChild = false) where T : BaseEntity, new() 
			where TOut : BaseEntityObject, new();

		TOut GetObject<T, TOut>(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false, bool getAll = false)
			where T : BaseEntity, new() where TOut : BaseEntityObject, new();

		TOut GetObject<T, TOut>(Filter filter, bool loadChild = false, bool getDeleted = false, bool getAll = false)
			where T : BaseEntity, new() where TOut : BaseEntityObject, new();

		IList<TOut> GetObjectList<T, TOut>(IEnumerable<Filter> filters = null, bool loadChild = false,
			bool getDeleted = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new();

		IList<TOut> GetObjectList<T, TOut>(Filter filter, bool loadChild = false,
			bool getDeleted = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new();

		IList GetObjectList(Type dtoType, Type blType, bool loadChild = false, bool getDeleted = false);

		IList<TOut> GetObjectListAll<T, TOut>(IEnumerable<Filter> filters = null, bool loadChild = false,
			bool getDeleted = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new();

		IList<TOut> GetObjectListAll<T, TOut>(Filter filter, bool loadChild = false,
			bool getDeleted = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new();

	}
}