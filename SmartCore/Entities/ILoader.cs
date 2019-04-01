using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Filters;
using SmartCore.Queries;

namespace SmartCore.Entities
{
	public interface ILoader
	{
		#region Loader Methods

		void LoadBaseComponents(Aircraft aircraft);

		T GetObject<T>(int itemId, bool loadChild = false, bool loadForced = false, bool loadDeleted = false)
			where T : BaseEntityObject, new();

		T GetObject<T>(ICommonFilter[] filters, bool loadChild = false, bool loadForced = false, bool loadDeleted = false)
			where T : BaseEntityObject, new();

		T GetObject<T>(ICommonFilter filter, bool loadChild = false, bool loadForced = false, bool loadDeleted = false)
			where T : BaseEntityObject, new();


		List<T> GetObjectList<T>(ICommonFilter[] filters = null, bool loadChild = false, bool getDeleted = false)
			where T : BaseEntityObject, new();

		List<T> GetObjectListAll<T>(ICommonFilter[] filters = null, bool loadChild = false, bool getDeleted = false,
			bool ignoreConditions = false)
			where T : BaseEntityObject, new();

		List<T> GetObjectListAll<T>(ICommonFilter filter, bool loadChild = false, bool getDeleted = false,
			bool ignoreConditions = false)
			where T : BaseEntityObject, new();

		List<T> GetObjectListAll<T>(PropertyInfo filterProperty, int filterPropertyValue, bool loadChild = false,
			bool getDeleted = false)
			where T : BaseEntityObject, new();

		List<T> GetObjectListAll<T>(PropertyInfo filterProperty, int[] filterPropertyValues, bool loadChild = false,
			bool getDeleted = false)
			where T : BaseEntityObject, new();

		List<T> GetObjectListAll<T>(List<DbQuery> qrs, bool loadChild = false, bool getForced = false)
			where T : BaseEntityObject, new();

		List<T> GetObjectListAll<T>(string qr, bool loadChild = false, bool getForced = false)
			where T : BaseEntityObject, new();

		List<T> GetObjectList<T>(ICommonFilter filter, bool loadChild = false, bool getDeleted = false)
			where T : BaseEntityObject, new();

		TV GetObjectCollection<T, TV>(ICommonFilter[] filters = null, bool loadChild = false, bool getDeleted = false)
			where T : BaseEntityObject, new()
			where TV : CommonCollection<T>, new();

		TV GetObjectCollection<T, TV>(ICommonFilter filter, bool loadChild = false, bool getDeleted = false)
			where T : BaseEntityObject, new()
			where TV : CommonCollection<T>, new();

		ICommonCollection GetObjectCollection(Type type, ICommonFilter[] filters = null,
			bool loadChild = false, bool getDeleted = false, bool getForced = false,
			bool ignoreConditions = false);

		ICommonCollection<T> GetObjectCollection<T>(ICommonFilter filter, bool loadChild = false, bool getDeleted = false)
			where T : BaseEntityObject, new();

		ICommonCollection<T> GetObjectCollection<T>(ICommonFilter[] filters = null, bool loadChild = false,
			bool getDeleted = false)
			where T : BaseEntityObject, new();

		#endregion

		//TODO (Evgenii Babak) : Вынести методы в  PerformanceRecordCore
		T GetPerformances<T>(SmartCoreType parentType, int parentId, bool lastOnly = false)
			where T : AbstractPerformanceRecord, new();

		int GetCountPerformanceRecords<T>(SmartCoreType parentType, int parentId) 
			where T : AbstractPerformanceRecord;

		//



		void ReloadDictionary(params Type[] types);

		IList GetObjectList(Type type, ICommonFilter[] filters = null, bool loadChild = false,
			bool getDeleted = false, bool getForced = false, bool ignoreConditions = false);
	}
}
