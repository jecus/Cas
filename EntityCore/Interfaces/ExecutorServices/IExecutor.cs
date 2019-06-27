using System;
using System.Collections.Generic;
using System.Data;
using EntityCore.Interfaces.ExecutorServices.Arcitecture;
using Microsoft.SqlServer.Management.Smo;

namespace EntityCore.Interfaces.ExecutorServices
{
	public interface IExecutor
	{
		DataSet Execute(string sql);

		DataSet Execute(IEnumerable<DbQuery> dbQueries, out List<ExecutionResultArgs> results);

		DataSet Execute(String query, List<SerializedSqlParam> parameters);

	}
}