using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;

namespace CAS.Entity.Core.ExecutorServices.Arcitecture
{
	public interface IDatabaseManager
	{

		void Connect(string serverName, string dataBaseName, string userName, string pass);
		DataSet Execute(string query);

		DataSet Execute(Database database, String query);

		DataSet Execute(String query, SqlParameter[] parameters);

		DataSet Execute(Database database, String query, SqlParameter[] parameters);
	}
}