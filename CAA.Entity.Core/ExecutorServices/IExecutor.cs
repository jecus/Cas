using System;
using System.Data;
using System.Data.SqlClient;

namespace CAA.Entity.Core.ExecutorServices
{
	public interface IExecutor
	{
		DataSet Execute(string sql);
		DataSet Execute(string query, SqlParameter[] parameters);

	}
}