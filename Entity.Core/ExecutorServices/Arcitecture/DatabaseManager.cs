using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace CAS.Entity.Core.ExecutorServices.Arcitecture
{
	public class DatabaseManager : IDatabaseManager
	{
		#region public Database Database { get; set; }
		/// <summary>
		/// База данных, которая будет использована по умолчанию при выполнении запросов
		/// </summary>
		public Database Database { get; set; }
		#endregion

		#region public ServerConnection ServerConnection { get; }
		/// <summary>
		/// Активное подключение к серверу
		/// </summary>
		private ServerConnection _serverConnection;
		/// <summary>
		/// Возвращает активное подключение к серверу
		/// </summary>
		public ServerConnection ServerConnection { get { return _serverConnection; } }
		#endregion

		#region public Server Server { get; }
		/// <summary>
		/// Подключенный сервер
		/// </summary>
		private Server _server;
		/// <summary>
		/// Подключенный сервер
		/// </summary>
		public Server Server { get { return _server; } }
		#endregion

		public DatabaseManager()
		{
			
		}

		#region public void Connect(string serverName, string dataBaseName, string userName, string pass)
		/// <summary>
		/// Подключается к серверу используя учетную запись и пароль
		/// </summary>
		/// <param name="serverName"></param>
		/// <param name="dataBaseName"></param>
		/// <param name="userName"></param>
		/// <param name="pass"></param>
		public void Connect(string serverName, string dataBaseName, string userName, string pass)
		{
			string connectionString = GetConnectionString(serverName, dataBaseName, userName, pass);
			ConnectPrivate(connectionString);

			for (int i = 0; i < Server.Databases.Count; i++)
				if (Server.Databases[i].Name.ToLower() == dataBaseName.ToLower())
				{
					Database = Server.Databases[i];
					return;
				}

			throw new Exception($"Database {Server.Name} was not found on server");
		}
		#endregion

		// Выполнение запросов

		#region public DataSet Execute(String query)
		/// <summary> 
		/// Выполняет необходимый запрос 
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		public DataSet Execute(string query)
		{
			return Execute(Database, query);
		}
		#endregion

		#region public DataSet Execute(Database database, String query)
		/// <summary> 
		/// Выполняет запрос в указанной базе данных
		/// </summary>
		/// <param name="database"></param>
		/// <param name="query"></param>
		/// <returns></returns>
		public DataSet Execute(Database database, String query)
		{
			lock (database)
			{
				// формируем команду и выполняем ее
				//query = String.Format("USE [{0}];\r\n{1}", database.Name, query);
				//SqlCommand com = new SqlCommand(query, ServerConnection.SqlConnectionObject);
				//SqlDataAdapter sda = new SqlDataAdapter(com);
				//DataSet ds = new DataSet();
				//sda.Fill(ds);

				if (ServerConnection.SqlConnectionObject.State == ConnectionState.Closed)
				{
					for (int i = 0; i < 3; i++)
					{
						try
						{
							//Попытка повторно открыть соединение
							ServerConnection.SqlConnectionObject.Open();
							//Если попытка удалась, выход из цикла
							if (ServerConnection.SqlConnectionObject.State == ConnectionState.Open)
								break;
						}
						catch (Exception)
						{
							//В противном случае повторение попытки
							Thread.Sleep(500 * i);
						}
					}

					if (ServerConnection.SqlConnectionObject.State == ConnectionState.Closed)
						return null;
				}

				DataSet ds;
				try
				{
					ds = database.ExecuteWithResults(query);
				}
				catch (Exception ex)
				{
					throw ex;
				}

				// Возвращаем результат
				return ds;
			}

		}
		#endregion

		#region public DataSet Execute(String query, SqlParameter[] parameters)
		/// <summary>
		/// Выполняет запрос с параметрами
		/// </summary>
		/// <param name="query"></param>
		/// <param name="parameters"></param>
		/// <returns></returns>
		public DataSet Execute(String query, SqlParameter[] parameters)
		{
			return Execute(Database, query, parameters);
		}
		#endregion

		#region public DataSet Execute(Database database, String query, SqlParameter[] parameters)
		/// <summary>
		/// Выполняет запрос с параметрами в указанной базе данных
		/// </summary>
		/// <param name="database"></param>
		/// <param name="query"></param>
		/// <param name="parameters"></param>
		public DataSet Execute(Database database, String query, SqlParameter[] parameters)
		{
			lock (database)
			{
				// формируем команду и выполняем ее
				query = $"USE [{database.Name}];\r\n{query}";
				SqlCommand com = new SqlCommand(query, _serverConnection.SqlConnectionObject);
				com.Parameters.AddRange(parameters);
				SqlDataAdapter sda = new SqlDataAdapter(com);
				DataSet ds = new DataSet();
				sda.Fill(ds);

				// Возвращаем результат
				return ds;
			}
		}
		#endregion


		#region private void ConnectPrivate(string connectionString)
		/// <summary>
		/// Подклчается к серверу используя указанную строку подключения
		/// </summary>
		/// <param name="connectionString"></param>
		private void ConnectPrivate(string connectionString)
		{
			_serverConnection = new ServerConnection();
			_serverConnection.ConnectionString = connectionString;
			_serverConnection.Connect();
			_server = new Server(_serverConnection);
		}
		#endregion

		/*
         * Реализация
         */

		#region private string GetConnectionString(string serverName, string databaseName, string userName, string userPass)
		/// <summary>
		/// Возвращает строку подключения к указанному серверу используя указанную учетную запись, имя базы данных можно не указывать
		/// </summary>
		/// <param name="serverName"></param>
		/// <param name="databaseName"></param>
		/// <param name="userName"></param>
		/// <param name="userPass"></param>
		/// <returns></returns>
		private string GetConnectionString(string serverName, string databaseName, string userName, string userPass)
		{
			string cn = "SERVER = " + serverName + ";" +
			            "UID=" + userName + ";" +
			            "PWD=" + userPass + "; ";
			if (databaseName != "") cn += "DATABASE=" + databaseName + "; ";
			cn += "Pooling=false;";

			return cn;
		}
		#endregion
	}
}