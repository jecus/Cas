using System.Data;
using System.Data.SqlClient;
using CAA.Entity.Core.ExecutorServices.Arcitecture;
using Microsoft.Extensions.Configuration;


namespace CAA.Entity.Core.ExecutorServices
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


		public DataSet Execute(string query, SqlParameter[] parameters)
		{
			return _manager.Execute(query, parameters);
		}
	}
}