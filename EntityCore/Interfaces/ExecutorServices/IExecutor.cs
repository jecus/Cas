using System;
using System.Data;
using System.Data.SqlClient;

namespace EntityCore.Interfaces.ExecutorServices
{
	public interface IExecutor
	{
		DataSet Execute(string sql);
		DataSet Execute(String query, SqlParameter[] parameters);

	}
}