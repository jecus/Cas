using System;
using System.Data;
using System.Data.SqlClient;

namespace CAS.Entity.Core.ExecutorServices
{
	public interface IExecutor
	{
		DataSet Execute(string sql);
		DataSet Execute(String query, SqlParameter[] parameters);

	}
}