using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using Microsoft.SqlServer.Management.Smo;
using SmartCore.Management;
using SmartCore.Queries;

namespace SmartCore.Contract
{
	[ServiceContract]
	public interface IExecutor
	{
		[OperationContract(Name = "SQL")]
		DataSet Execute(string sql);

		[OperationContract(Name = "DBSQL")]
		DataSet Execute(Database database, String query);

		[OperationContract(Name = "DbQuery")]
		DataSet Execute(IEnumerable<DbQuery> dbQueries, out List<ExecutionResultArgs> results);

		[OperationContract(Name = "SQLParam")]
		DataSet Execute(String query, List<SerializedSqlParam> parameters);

		[OperationContract(Name = "CheckType")]
		bool CheckType(string typeName);

	}
}