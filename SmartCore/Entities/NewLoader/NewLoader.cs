using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using CAS.UI.Helpers;
using Entity.Abstractions;
using Entity.Abstractions.Filters;
using SmartCore.DtoHelper;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Management;
using SmartCore.Queries;

namespace SmartCore.Entities.NewLoader
{



	public class NewLoader : INewLoader
	{
		#region Fields

		private readonly IBaseEnvironment _casEnvironment;
		private readonly ApiProvider _provider;

		#endregion

		#region Constructor

		public NewLoader(IBaseEnvironment casEnvironment)
		{
			_casEnvironment = casEnvironment;
			_provider = _casEnvironment.ApiProvider;
		}

		#endregion

		#region SQL

		public DataSet Execute(string sql)
		{
			return _provider.Execute(sql);
		}

		public DataSet Execute(IEnumerable<DbQuery> dbQueries, out List<ExecutionResultArgs> results)
		{
			results = new List<ExecutionResultArgs>();

			int counter = 0;

			var dataset = new DataSet();

			foreach (var query in dbQueries)
			{
				var dt = _provider.Execute(query.QueryString).Tables[0];

				var casTable = new CasDataTable(query.ElementType, query.Branch, query.Branch);

				foreach (DataColumn row in dt.Columns)
					casTable.Columns.Add(new DataColumn(row.ColumnName, row.DataType));

				foreach (DataRow row in dt.Rows)
					casTable.ImportRow(row);

				dataset.Tables.Add(casTable);

				counter++;
			}

			return dataset;
		}

		public DataSet Execute(string query, SqlParameter[] parameters)
		{
			return _provider.Execute(query, parameters);
		}

		#endregion


		public IList<int> GetSelectColumnOnly<T>(IEnumerable<Filter> filters, string selectProperty) where T : BaseEntity
		{
			if (!typeof(T).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			return _provider.GetSelectColumnOnly<T>(filters, selectProperty);
		}

		public TOut GetObjectById<T, TOut>(int id, bool loadChild = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			if (!typeof(T).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			if (!typeof(TOut).IsSubclassOf(typeof(BaseEntityObject)))
				throw new ArgumentException("TOut", "не является наследником " + typeof(BaseEntityObject).Name);

			var dto = _provider.GetObjectById<T>(id, loadChild);

			if (dto == null)
				return null;

			var methodName = GetConverterMethodName(typeof(TOut), typeof(T));
			var method = GetMethod(typeof(T), methodName);

			return InvokeConverter<T,TOut>(dto, method);
		}

		public TOut GetObject<T, TOut>(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false, bool getAll = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			if (!typeof(T).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			if (!typeof(TOut).IsSubclassOf(typeof(BaseEntityObject)))
				throw new ArgumentException("TOut", "не является наследником " + typeof(BaseEntityObject).Name);

			var dto = _provider.GetObject<T>(filters, loadChild, getDeleted, getAll);

			if (dto == null)
				return null;

			var methodName = GetConverterMethodName(typeof(TOut), typeof(T));
			var method = GetMethod(typeof(T), methodName);
			return InvokeConverter<T, TOut>(dto, method);
		}

		public TOut GetObject<T, TOut>(Filter filter, bool loadChild = false, bool getDeleted = false, bool getAll = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			return GetObject<T, TOut>(new[] {filter}, loadChild, getDeleted, getAll);
		}

		public IList<TOut> GetObjectList<T, TOut>(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			if (!typeof(T).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			if (!typeof(TOut).IsSubclassOf(typeof(BaseEntityObject)))
				throw new ArgumentException("TOut", "не является наследником " + typeof(BaseEntityObject).Name);

			var res = new List<TOut>();
			var dtos = _provider.GetObjectList<T>(filters, loadChild, getDeleted);

			if (dtos == null)
				return res;

			var methodName = GetConverterMethodName(typeof(TOut), typeof(T));
			var method = GetMethod(typeof(T), methodName);
			res.AddRange(dtos.Select(i => InvokeConverter<T, TOut>(i, method)));

			return res;

		}

		public IList<TOut> GetObjectList<T, TOut>(Filter filter, bool loadChild = false, bool getDeleted = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			return GetObjectList<T, TOut>(new[] {filter}, loadChild, getDeleted);
		}

		public IList GetObjectList(Type dtoType, Type blType, bool loadChild = false, bool getDeleted = false)
		{
			var method = typeof(INewLoader).GetMethods().FirstOrDefault(i => i.Name == "GetObjectList")?.MakeGenericMethod(dtoType, blType);

			if (dtoType.Name == "AccessoryDescriptionDTO" || dtoType.Name == "CAAAccessoryDescriptionDTO")
			{
				var filter = new List<Filter>();
				if(blType.Name == "AircraftModel")
					filter.Add(new Filter("ModelingObjectTypeId", 7));
				else if (blType.Name == "ComponentModel")
					filter.Add(new Filter("ModelingObjectTypeId", 5));
				else if (blType.Name == "Product")
					filter.Add(new Filter("ModelingObjectTypeId", -1));

				return (IList)method.Invoke(this, new object[] { filter, loadChild, getDeleted });
			}

			return (IList)method.Invoke(this, new object[] { null, loadChild, getDeleted });
		}

		public IList<TOut> GetObjectListAll<T, TOut>(IEnumerable<Filter> filters = null, bool loadChild = false, bool getDeleted = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			if (!typeof(T).IsSubclassOf(typeof(BaseEntity)))
				throw new ArgumentException("T", "не является наследником " + typeof(BaseEntity).Name);

			if (!typeof(TOut).IsSubclassOf(typeof(BaseEntityObject)))
				throw new ArgumentException("TOut", "не является наследником " + typeof(BaseEntityObject).Name);

			var res = new List<TOut>();
			var dtos = _provider.GetObjectListAll<T>(filters, loadChild, getDeleted);

			if (dtos == null)
				return res;

			var methodName = GetConverterMethodName(typeof(TOut), typeof(T));
			var method = GetMethod(typeof(T), methodName);
			res.AddRange(dtos.Select(i => InvokeConverter<T, TOut>(i, method)));

			return res;

		}

		public IList<TOut> GetObjectListAll<T, TOut>(Filter filter, bool loadChild = false, bool getDeleted = false) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			return GetObjectListAll<T, TOut>(new[] {filter}, loadChild, getDeleted);
		}


		public void ReloadDictionary(params Type[] types)
        {
            foreach (var type in types)
            {
                var dto = (CAADtoAttribute)type.GetCustomAttributes(typeof(CAADtoAttribute), false).FirstOrDefault();
                var reloadedDict = GetObjectList(dto.Type, type, loadChild: true);

                var dict = _casEnvironment.GetDictionary(type);
                dict.Clear();

                foreach (AbstractDictionary dictionary in reloadedDict)
                    dict.Add(dictionary);
            }
        }


		#region private string GetConverterMethodName(Type TOut)

		private string GetConverterMethodName(Type TOut, Type tIn)
		{
			var methodName = "Convert";
            if (tIn.ToString().StartsWith("CAA"))
            {
                if (TOut.Name.Equals("AircraftModel"))
                    return "ConvertToAircraftModelCAA";
				return methodName += "CAA";
            }


			if (TOut.Name.Equals("AircraftModel"))
				methodName = "ConvertToAircraftModel";
			else if (TOut.Name.Equals("ComponentModel"))
				methodName = "ConvertToComponentModel";
			else if (TOut.Name.Equals("Product"))
				methodName = "ConvertToProduct";
			else if (TOut.Name.Equals("BaseComponent"))
				methodName = "ConvertToBaseComponent";
			else if (TOut.Name.Equals("MaintenanceCheckRecord"))
				methodName = "ConvertToMaintenanceCheckRecord";
			else if (TOut.Name.Equals("DeferredItem"))
				methodName = "ConvertToDeffered";
			else if (TOut.Name.Equals("DamageItem"))
				methodName = "ConvertToDamage";

			return methodName;
		}

		#endregion

		#region private MethodInfo GetMethod(Type t, string methodName)

		private MethodInfo GetMethod(Type t, string methodName)
		{
			var method = typeof(GeneralConverterDto).GetMethod(methodName, BindingFlags.Static | BindingFlags.Public, null, new[] { t }, null);
			if (method == null)
				method = typeof(DictionaryConverterDto).GetMethod(methodName, BindingFlags.Static | BindingFlags.Public, null, new[] { t }, null);
            if (method == null)
				method = typeof(CaaGeneralConverterDTO).GetMethod(methodName, BindingFlags.Static | BindingFlags.Public, null, new[] { t }, null);

            if (method == null)
				throw new ArgumentNullException(methodName, $"В конвертере не содержится метод для {nameof(t)}");

			return method;
		}

		#endregion

		#region private TOut InvokeConverter<T, TOut>(T value)

		private TOut InvokeConverter<T, TOut>(T value, MethodInfo method) where T : BaseEntity, new() where TOut : BaseEntityObject, new()
		{
			var instance = Activator.CreateInstance(typeof(TOut));
			return method.Invoke(instance, new object[] { value }) as TOut;
		}

		#endregion

	}
}