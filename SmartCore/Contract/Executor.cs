using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.Attributes;
using SmartCore.Files;
using SmartCore.Management;
using SmartCore.Queries;

namespace SmartCore.Contract
{
	public class Executor : IExecutor
	{
		private DatabaseManager _manager;

		public Executor()
		{
			var section = ConfigurationManager.GetSection("connectionSettings") as NameValueCollection;
			var password = section["Password"];
			var serverName = section["ServerName"];
			var userName = section["UserName"];
			var databaseName = section["DatabaseName"];

			_manager = new DatabaseManager();
			_manager.Connect(serverName, databaseName, userName, password);
		}

		public DataSet Execute(string sql)
		{
			return _manager.Execute(sql);
		}

		public DataSet Execute(Database database, string query)
		{
			return _manager.Execute(database, query);
		}

		public DataSet Execute(IEnumerable<DbQuery> dbQueries, out List<ExecutionResultArgs> results)
		{
			return  _manager.Execute(dbQueries, out results);
		}

		public DataSet Execute(string query, List<SerializedSqlParam> parameters)
		{
			var p = new List<SqlParameter>();
			foreach (var parameter in parameters)
				p.Add(parameter.GetSqlParameter());

			return _manager.Execute(query, p.ToArray());
		}

		public bool CheckType(string typeName)
		{
			var assembly = Assembly.GetAssembly(typeof(BaseEntityObject));
			var type = assembly.GetTypes()
				.FirstOrDefault(t => t.Namespace != null && t.IsClass && t.Name.Equals(typeName));
			var method = typeof(IDatabaseManager).GetMethods().FirstOrDefault(i => i.Name == "CheckType")?.MakeGenericMethod(type);
			return (bool)method.Invoke(_manager, null);
		}
	}
}