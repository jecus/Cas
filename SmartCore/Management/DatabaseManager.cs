using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Data.SqlClient;
using System.Threading;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Data;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Queries;

namespace SmartCore.Management
{


    // Счетчики: 
    // Объем переданных данных на сервер
    // Объем полученных данных от сервера
    // Количество выполненных запросов 

    /// <summary>
    /// Реализует рутины взаимодействия с базой данных
    /// </summary>
    public class DatabaseManager : IDatabaseManager
	{

        private Int32 _queries;

        private const bool Debug = true;

        private bool _transactionOpen;

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

        #region public Database Database { get; set; }
        /// <summary>
        /// База данных, которая будет использована по умолчанию при выполнении запросов
        /// </summary>
        public Database Database { get; set; }
        #endregion

        #region public Logger Logger { get; }
        /// <summary>
        /// Логирование запросов к базе данных
        /// </summary>
        private Logger _logger;
        /// <summary>
        /// Логирование запросов к базе данных
        /// </summary>
        public Logger Logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = new Logger("casdblog.txt");
                    _logger.Clear();
                    _logger.Write(DateTime.Today.ToShortDateString() + " " + DateTime.Now.ToShortTimeString());
                }
                //
                return _logger;
            }
        }
        #endregion

        #region public bool TransactionOpen
        /// <summary>
        /// имеется ли открытая транзакция
        /// </summary>
        public bool TransactionOpen
        {
            get { return _transactionOpen; }
        }
        #endregion
        //

        #region public DatabaseManager()
        /// <summary>
        /// Реализует взаимодействие с базой данных CAS
        /// </summary>
        public DatabaseManager()
        {
        }
        #endregion

        // Подключение к серверу 

        #region public void Connect(string serverName, string userName, string pass)
        /// <summary>
        /// Подключается к серверу используя учетную запись и пароль
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="userName"></param>
        /// <param name="pass"></param>
        public void Connect(string serverName, string userName, string pass)
        {
            string connectionString = GetConnectionString(serverName, "", userName, pass);
            ConnectPrivate(connectionString);
        }
		#endregion

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

        #region public void Disconnect()
        /// <summary>
        /// Отключается от сервера
        /// </summary>
        public void Disconnect()
        {
            if(_serverConnection == null)return;

            if(_serverConnection.IsOpen)
                _serverConnection.Disconnect();
        }
        #endregion
        
        // Выполнение запросов

        #region public DataSet Execute(String query)
        /// <summary> 
        /// Выполняет необходимый запрос 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public DataSet Execute(String query)
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
                if (Debug)
                {
                    _queries++;
                    Logger.Write(_queries + "\r\n" + query);
                }
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
                            Thread.Sleep(500*i);
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
                if (Debug)
                    Logger.Write("Results: " + (ds.Tables.Count > 0 ? ds.Tables[0].Rows.Count.ToString() : "no results") +
                                 " rows\r\n\r\n");
                return ds;
            }

        }
        #endregion

        #region public DataSet Execute(IEnumerable<DbQuery> dbQueries, out List<ExecutionResultArgs> results)
        /// <summary> 
        /// Выполняет запрос в указанной базе данных
        /// </summary>
        /// <param name="dbQueries"></param>
        /// <param name="results"></param>
        /// <returns></returns>
        public DataSet Execute(IEnumerable<DbQuery> dbQueries, out List<ExecutionResultArgs> results)
        {
            lock (Database)
            {
                results = new List<ExecutionResultArgs>();
                DataSet ds = new DataSet();

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
                            Thread.Sleep(500*i);
                        }
                    }

                    if (ServerConnection.SqlConnectionObject.State == ConnectionState.Closed)
                    {
                        //ExecutionResultArgs result = new ExecutionResultArgs
                        //{
                        //    Result = ExecutionResult.Exception,
                        //    Exception = new Exception(""),
                        //    Query = ""
                        //};
                        //results.Add(result);
                        return ds;
                    }
                }

                try
                {
                    foreach (DbQuery query in dbQueries)
                    {
                        if (Debug)
                        {
                            _queries++;
                            Logger.Write(_queries + "\r\n" + query.QueryString);
                        }
                        try
                        {
                            //CasDataTable dt = new CasDataTable(query.ElementType, query.Branch, query.Branch);
							var dt = new DataTable();
                            query.QueryString = String.Format("USE [{0}];\r\n{1}", Database.Name, query.QueryString);
                         //   SqlCommand com = new SqlCommand(query.QueryString, ServerConnection.SqlConnectionObject);
	                        //com.CommandTimeout = 60;
                         //   SqlDataAdapter sda = new SqlDataAdapter(com);
                         //   //Заполнение таблицы данными
                         //   sda.Fill(dt);
                            //Включение таблицы в набор данных

	                        dt = Database.ExecuteWithResults(query.QueryString).Tables[0].Copy();

                            ds.Tables.Add(dt);
                        }
                        catch (Exception ex)
                        {
                            ExecutionResultArgs result = new ExecutionResultArgs
                            {
                                Result = ExecutionResult.Exception,
                                Exception = ex,
                                Query = query.QueryString
                            };
                            results.Add(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ExecutionResultArgs result = new ExecutionResultArgs
                    {
                        Result = ExecutionResult.Exception,
                        Exception = ex,
                    };
                    results.Add(result);
                    return ds;
                }
                // Возвращаем результат
                if (Debug)
                {
                    string rows = ds.Tables.Cast<DataTable>().Aggregate("", (current, dataTable) => current + (dataTable.TableName + ": " + dataTable.Rows.Count + " rows" + "\n"));
                    Logger.Write("Results: " + (ds.Tables.Count > 0 ? rows : "no results") + "\r\n\r\n");
                }
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
                if (Debug)
                {
                    _queries++;
                    Logger.Write(_queries + "\r\n" + query);
                }

                // формируем команду и выполняем ее
                query = String.Format("USE [{0}];\r\n{1}", database.Name, query);
                SqlCommand com = new SqlCommand(query, _serverConnection.SqlConnectionObject);
                com.Parameters.AddRange(parameters);
                SqlDataAdapter sda = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                sda.Fill(ds);

                // Возвращаем результат
                if (Debug)
                    Logger.Write(String.Format("Results: {0} \r\n\r\n",
                                               ds.Tables.Count > 0 ? ds.Tables[0].Rows.Count + " rows" : ""));
                return ds;
            }
        }
        #endregion

        /*
         * Управление транзакциями
         */
        /*
         * База данных CAS
         */

        #region private DataType GetDataType(PropertyInfo propertyInfo, TableColumnAttribute attr)

        /// <summary>
        /// Определяет какой тип значения нужен для сохранения переданного своиства в БД
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="attr"></param>
        /// <returns></returns>
        private DataType GetDataType(PropertyInfo propertyInfo, TableColumnAttribute attr)
        {
            //Проверка на то, является ли тип своиства потомком BaseSmartCoreObject
            if (propertyInfo.PropertyType.IsSubclassOf(typeof(BaseEntityObject))) return DataType.Int;
            if (propertyInfo.PropertyType.GetInterface(typeof(IBaseEntityObject).Name) != null) return DataType.Int;
            if (propertyInfo.PropertyType.IsEnum) return DataType.SmallInt;
            string typeName = propertyInfo.PropertyType.Name.ToLower();
            switch (typeName)
            {
                case "byte[]":
                    return DataType.VarBinary(-1);
                case "string":
                    return DataType.NVarChar(attr != null && (attr.Size < 0 || attr.Size > 256) ? attr.Size : 256);
                case "int32":
                    return DataType.Int;
                case "int16":
                    return DataType.SmallInt;
                case "datetime":
                    return DataType.DateTime;
                case "bool":
                case "boolean":
                    return  DataType.Bit;
                case "double":
                    return DataType.Float;

                case "detectionphase":
                case "flightregime":
                case "kitcostcondition":
                case "powerloss":
                case "runupcondition":
                case "runuptype":
                case "shutdowntype":
                case "thrustlever":
                case "weathercondition":
                    return DataType.SmallInt;
                case "highlight":
                case "timespan":
                case "workpackagestatus":
                    return DataType.Int;
                case "directivethreshold":
                    return DataType.VarBinary(DirectiveThreshold.SerializedDataLength);
                case "componentdirectivethreshold":
                    return DataType.VarBinary(ComponentDirectiveThreshold.SerializedDataLength);
                case "maintenancedirectivethreshold":
                    return DataType.VarBinary(MaintenanceDirectiveThreshold.SerializedDataLength);
				case "trainingthreshold":
					return DataType.VarBinary(TrainingThreshold.SerializedDataLength);
				case "lifelength":
                    return DataType.VarBinary(Lifelength.SerializedDataLength);
                default:
                    return null;
            }   
        }
        #endregion

        #region public bool CheckType(string tableName)
        /// <summary>
        /// Проверяет наличие и корректность таблицы в БД для сохранения/загрузки объектов переданного типа
        /// </summary>
        /// <returns></returns>
        public bool CheckType<T>() where T : BaseEntityObject, new()
        {
            //определение типа
            Type type = typeof(T);
            //Определение атрибута сохраняемой таблицы
            TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();

            if (dbTable == null || dbTable.TableName == "")
            {
                //Если отсутствует атрибут таблицы, в которую сохраняются 
                //экземпляры данного типа или имя таблицы не задано, то 
                //кидается исключение
                throw new DbTableAttributeNullException(new T());
            }

            lock (Database)
            {
                if (!Database.Tables.Contains(dbTable.TableName, dbTable.TableScheme))
                {
                    //Если отстствует таблица, предназначенная для сохранения объектов 
                    //переданного типа то кидается исключение
                    throw new DbTableAttributeException(type, dbTable);
                }
            }

            return true;   
        }
        #endregion

        #region public void CheckTableFor(Type type)
        /// <summary>
        /// Проверяет наличие и корректность таблицы в БД для сохранения/загрузки объектов переданного типа
        /// </summary>
        /// <returns></returns>
        public void CheckTableFor(Type type)
        {
            //Определение атрибута сохраняемой таблицы
            TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();

            if (!Database.Tables.Contains(dbTable.TableName, dbTable.TableScheme))
            {
                //Если отстствует таблица, предназначенная для сохранения объектов 
                //переданного типа то кидается исключение
                throw new DbTableAttributeException(type, dbTable);
            }

            //Получение таблицы
            Table table = Database.Tables[dbTable.TableName, dbTable.TableScheme];
            //определение своиств типа
            List<PropertyInfo> preProrerty = new List<PropertyInfo>(type.GetProperties());
            //определение своиств, имеющих атрибут "сохраняемое"
            List<PropertyInfo> properties =
                preProrerty.Where(p => p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0).ToList();

            //Проверка таблицы на наличие соответствующх колонок, их имен и типа хранимого значения
            //List<ColumnError> errors = new  List<ColumnError>();
            string checkResult = "";
            foreach (PropertyInfo p in properties)
            {
                TableColumnAttribute tca =
                    (TableColumnAttribute) p.GetCustomAttributes(typeof (TableColumnAttribute), false).FirstOrDefault();
                //Для начала определяется, можно ли сохранить тип в БД
                DataType storedType = GetDataType(p, tca);
                if (storedType == null) throw new Exception("для типа " + p.PropertyType.Name + " не удается определить хранимый тип в БД");

                //Проверка наличия колонки с заданным именем в таблице
                if(!table.Columns.Contains(tca.ColumnName))
                {
                    //Если колонки с заданным именем нет в таблице
                    //то инф-я об этом добавлется в результат проверки
                    //errors.Add(new ColumnError(tca.ColumnName, ColumnErrorType.NoFind));
                    if (checkResult != "") checkResult += ",\n";
                    checkResult += "Колонка с именем " + tca.ColumnName + " отсутствует в таблице";

                    continue;
                }

                //Проверка типа хранимого значения колонки
                Column col = table.Columns[tca.ColumnName];
                if(col.DataType.Name != storedType.Name)
                {
                    //Если тип колонки в таблице не соответствует типу для хранения
                    //то инф-я об этом добавлется в результат проверки
                    //errors.Add(new ColumnError(tca.ColumnName, ColumnErrorType.InvalidType));
                    if (checkResult != "") checkResult += ",\n";
                    checkResult += "Тип колонки " + tca.ColumnName + " не соответствует типу хранения для " 
                                                  + p.Name + "(" + p.PropertyType.Name + ")";

                    continue;
                }
                if (col.DataType.MaximumLength != storedType.MaximumLength && storedType.MaximumLength != 0)
                {
                    //Если размер типа данных колонки в таблице не соответствует размеру для хранения
                    //то инф-я об этом добавлется в результат проверки
                    //errors.Add(new ColumnError(tca.ColumnName, ColumnErrorType.InvalidSize));
                    if (checkResult != "") checkResult += ",\n";
                    checkResult += "Размер колонки " + tca.ColumnName + "(" + col.DataType.MaximumLength + ")"
                                    + " не соответствует размеру хранения для " + p.Name + "(" + storedType.MaximumLength + ")";

                    continue;
                }
                //if (tca.ColumnName.ToLower() == "isdeleted")
                //{
                //    // Определение своиств ключа
                //    DefaultConstraint dc =  col.DefaultConstraint;
                //    //newColumn.AddDefaultConstraint( =) "((0))");
                //}
            }
            //if(errors.Count > 0) throw new DbTableColumnsAttributeException(type,errors.ToArray());
            if (checkResult != "") throw new DbTableColumnsAttributeException(type,checkResult);
        }
        #endregion

        #region public void CreateTableFor(Type type)
        /// <summary>
        /// Создает таблицы в БД для сохранения/загрузки объектов переданного типа
        /// </summary>
        /// <returns></returns>
        public void CreateTableFor(Type type)
        {
            //Определение атрибута сохраняемой таблицы
            TableAttribute dbTable = (TableAttribute)type.GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault();

            if (!Database.Tables.Contains(dbTable.TableName, dbTable.TableScheme))
            {
                if (!Database.Schemas.Contains(dbTable.TableScheme))
                {
                    //Если схемы нет в БД, то производится ее создание
                    Schema newSchema = new Schema(Database, dbTable.TableScheme);
                    newSchema.Owner = "dbo";

                    //Create the schema on the instance of SQL Server. 
                    newSchema.Create();

                    //Define an ObjectPermissionSet that contains the Update and Select object permissions. 
                    ObjectPermissionSet obperset = new ObjectPermissionSet();
                    obperset.Add(ObjectPermission.Select);
                    obperset.Add(ObjectPermission.Update);
                    obperset.Add(ObjectPermission.Insert);
                    obperset.Add(ObjectPermission.Delete);

                    //Grant the set of permissions on the schema to the guest account. 
                    newSchema.Grant(obperset, "sa");
                }

                Table newTable = new Table(Database, dbTable.TableName, dbTable.TableScheme);
                //определение своиств типа
                List<PropertyInfo> preProrerty = new List<PropertyInfo>(type.GetProperties());
                //определение своиств, имеющих атрибут "сохраняемое"
                List<PropertyInfo> properties =
                    preProrerty.Where(p => p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0).ToList();

                foreach (PropertyInfo t in properties)
                {
                    TableColumnAttribute tca =
                        (TableColumnAttribute)t.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();

                    Column newColumn = new Column(newTable, tca.ColumnName);

                    DataType storedType = GetDataType(t, tca);
                    if (storedType != null) newColumn.DataType = storedType;
                    else throw new Exception("для типа " + t.PropertyType.Name + " не удается определить хранимый тип в БД");

                    newColumn.Nullable = true;

                    if (tca.ColumnName == dbTable.PrimaryKey)
                    {
                        // Определение своиств ключа
                        newColumn.Nullable = false;
                        newColumn.Identity = true;
                        newColumn.IdentitySeed = 1;
                        newColumn.IdentityIncrement = 1;
                    }
                    newTable.Columns.Add(newColumn);
                }
                // Create a PK Index for the table
                Index index = new Index(newTable, "PK_" + dbTable.TableName) { IndexKeyType = IndexKeyType.DriPrimaryKey };
                // The PK index will consist of 1 column, "ID"
                index.IndexedColumns.Add(new IndexedColumn(index, dbTable.PrimaryKey));
                // Add the new index to the table.
                newTable.Indexes.Add(index);
                // Physically create the table in the database
                newTable.Create();

                //Database.Tables.Add(newTable);

                if (newTable.Columns.Contains("IsDeleted"))
                {
                    // Определение своиств ключа
                    Column col = newTable.Columns["IsDeleted"];
                    
                    string defName = dbTable.TableName + "_" + col.Name;
                    
                    DefaultConstraint dc = col.AddDefaultConstraint(defName);
                    dc.Text = "((0))";
                    dc.Create();
                    
                    
                    col.Nullable = false;
                    col.Alter();

                    //Default def = new Default(Database, defName, dbTable.TableScheme)
                    //{
                    //    TextHeader = "CREATE DEFAULT " + dbTable.TableScheme + ".[" + defName + "] AS",
                    //    TextBody = "((0))"
                    //};
                    ////Create the default on the instance of SQL Server. 
                    //def.Create();

                    ////Bind the default to a column in a table in AdventureWorks2012
                    //def.BindToColumn(dbTable.TableName, col.Name, dbTable.TableScheme);
                }
            }
            else
            {
                //Получение таблицы
                Table table = Database.Tables[dbTable.TableName, dbTable.TableScheme];
                //определение своиств типа
                List<PropertyInfo> preProrerty = new List<PropertyInfo>(type.GetProperties());
                //определение своиств, имеющих атрибут "сохраняемое"
                List<PropertyInfo> properties =
                    preProrerty.Where(p => p.GetCustomAttributes(typeof(TableColumnAttribute), false).Length != 0).ToList();

                //Проверка таблицы на наличие соответствующх колонок, их имен и типа хранимого значения
                foreach (PropertyInfo p in properties)
                {
                    TableColumnAttribute tca =
                        (TableColumnAttribute)p.GetCustomAttributes(typeof(TableColumnAttribute), false).FirstOrDefault();
                    //Для начала определяется, можно ли сохранить тип в БД
                    DataType storedType = GetDataType(p, tca);
                    if (storedType == null) throw new Exception("для типа " + p.PropertyType.Name + " не удается определить хранимый тип в БД");

                    //Проверка наличия колонки с заданным именем в таблице
                    if (!table.Columns.Contains(tca.ColumnName))
                    {
                        //Если колонки с заданным именем нет в таблице
                        //то производится ее создание

                        Column newColumn = new Column(table, tca.ColumnName);
                        newColumn.DataType = storedType;
                        newColumn.Nullable = true;

                        if (tca.ColumnName == dbTable.PrimaryKey)
                        {
                            // Определение своиств ключа
                            newColumn.Nullable = false;
                            newColumn.Identity = true;
                            newColumn.IdentitySeed = 1;
                            newColumn.IdentityIncrement = 1;

                            newColumn.Create();
                            //table.Columns.Add(newColumn);
                            // Create a PK Index for the table
                            Index index = new Index(table, "PK_" + dbTable.TableName) { IndexKeyType = IndexKeyType.DriPrimaryKey };
                            // The PK index will consist of 1 column, "ID"
                            index.IndexedColumns.Add(new IndexedColumn(index, dbTable.PrimaryKey));
                            // Add the new index to the table.
                            table.Indexes.Add(index);

                            continue;
                        }
                        newColumn.Create();

                        continue;
                    }

                    //Проверка типа хранимого значения колонки
                    Column col = table.Columns[tca.ColumnName];
                    if (col.DataType.Name != storedType.Name)
                    {
                        //Если тип колонки в таблице не соответствует типу для хранения
                        //то производится смена типа
                        col.DataType = storedType;
                        col.Alter();

                        continue;
                    }
                    if (col.DataType.MaximumLength != storedType.MaximumLength && storedType.MaximumLength != 0)
                    {
                        //Если размер типа данных колонки в таблице не соответствует размеру для хранения
                        //то производится изменение размера
                        col.DataType.MaximumLength = storedType.MaximumLength;
                        col.Alter();

                        continue;
                    }
                }
            }
        }
		#endregion

		#region private void SelectDatabase(DatabaseManager databaseManager, String database)
		/// <summary>
		/// Выбираем базу данных 
		/// </summary>
		/// <param name="databaseManager"></param>
		/// <param name="database"></param>
		public void SelectDatabase(DatabaseManager databaseManager, string database)
		{
			for (int i = 0; i < databaseManager.Server.Databases.Count; i++)
				if (databaseManager.Server.Databases[i].Name.ToLower() == database.ToLower())
				{
					Database = databaseManager.Server.Databases[i];
					return;
				}
			//
			throw new Exception($"Database {databaseManager.Server.Name} was not found on server");
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
            string cn = "SERVER = " +serverName + ";" +
                        "UID=" + userName + ";" +
                        "PWD=" + userPass + "; ";
            if (databaseName != "") cn += "DATABASE=" + databaseName + "; ";
            cn += "Pooling=false;";

            return cn;
        }
        #endregion

        #region private string GetTrustedConnectionString(string serverName, string databaseName)
        /// <summary>
        /// Возвращает строку подключения используя доверенное подключение (аутентификацию Windows) (можно указать пустую базу данных)
        /// </summary>
        /// <param name="serverName"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        private string GetTrustedConnectionString(string serverName, string databaseName)
        {
            return string.Format("Server={0};{1}Trusted_Connection=True;", serverName, databaseName == "" ? "" : "Database=" + databaseName + ";");
            //return string.Format("Data Source={0};{1}Integrated Security=SSPI;", serverName, databaseName == "" ? "" : "Initial Catalog=" + databaseName + ";");
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
         *  Загрузка объектов
         */

    }


    #region public enum ExecutionResult
    /// <summary>
    /// Результат выполнения скрипта
    /// </summary>
    public enum ExecutionResult
    {

        /// <summary>
        /// Успешное выполнение скрипта
        /// </summary>
        Successfull,

        /// <summary>
        /// Во время скрипта возникла исключительная ситуация
        /// </summary>
        Exception,

    }
    #endregion

    #region public class ExecutionResultArgs
    /// <summary>
    /// Класс содержит результат выполнения скрипта
    /// </summary>
    public class ExecutionResultArgs
    {
        /// <summary>
        /// Результат выполнения скриптов
        /// </summary>
        public ExecutionResult Result = ExecutionResult.Successfull;

        /// <summary>
        /// Исключительная ситуация, которая возникла во время выполнения скрипта
        /// </summary>
        public Exception Exception = null;

        /// <summary>
        /// Информация о запросе, который вызвал ошибку
        /// </summary>
        public String Query = null;
    }
    #endregion

}
