using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using SmartCore.Auxiliary;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Filters;
using SmartCore.Queries;

namespace SmartCore.Management
{
	public interface IDatabaseManager
	{
		/// <summary>
		/// Свойства
		/// </summary>
		ServerConnection ServerConnection { get; }
		Server Server { get; }
		Database Database { get; set; }
		Logger Logger { get; }
		bool TransactionOpen { get; }


		// Подключение к серверу 
		void Connect(string serverName, string userName, string pass);
		void Connect(string serverName, string dataBaseName, string userName, string pass);
		void Disconnect();

		// Выполнение запросов
		DataSet Execute(String query);
		DataSet Execute(Database database, String query);
		DataSet Execute(IEnumerable<DbQuery> dbQueries, out List<ExecutionResultArgs> results);
		DataSet Execute(String query, SqlParameter[] parameters);
		DataSet Execute(Database database, String query, SqlParameter[] parameters);


		//База данных CAS
		bool CheckType<T>() where T : BaseEntityObject, new();
		void CheckTableFor(Type type);
		void CreateTableFor(Type type);


	}
}
