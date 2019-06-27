using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using EntityCore.Interfaces.ExecutorServices;
using EntityCore.Interfaces.ExecutorServices.Arcitecture;
using Microsoft.Extensions.Configuration;
using Microsoft.SqlServer.Management.Smo;

namespace EntityCore.Interfaces
{
	public class Executor : IExecutor
	{
		private DatabaseManager _manager;

		public Executor(IConfiguration configuration)
		{
			var password = configuration.GetConnectionString("Password");
			var serverName = configuration.GetConnectionString("ServerName");
			var userName = configuration.GetConnectionString("UserName");
			var databaseName = configuration.GetConnectionString("DatabaseName");

			_manager = new DatabaseManager();
			_manager.Connect(serverName, databaseName, userName, password);
		}

		public DataSet Execute(string sql)
		{
			return _manager.Execute(sql);
		}


		public DataSet Execute(IEnumerable<DbQuery> dbQueries, out List<ExecutionResultArgs> results)
		{
			return _manager.Execute(dbQueries, out results);
		}

		public DataSet Execute(string query, List<SerializedSqlParam> parameters)
		{
			var p = new List<SqlParameter>();
			foreach (var parameter in parameters)
				p.Add(parameter.GetSqlParameter());

			return _manager.Execute(query, p.ToArray());
		}
	}
}