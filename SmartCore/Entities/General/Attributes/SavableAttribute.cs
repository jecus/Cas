using System;

namespace SmartCore.Entities.General.Attributes
{
	#region public class DtoAttribute : Attribute

	[AttributeUsage(AttributeTargets.Class)]
	public class DtoAttribute : Attribute
	{
		private readonly Type _type;

		public Type Type
		{
			get { return _type; }
		}

		public DtoAttribute(Type type)
		{
			_type = type;
		}
	}

	#endregion

    #region public class SubQueryAttribute : Attribute
    /// <summary>
    /// Помечает своиство как запрос в БД
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class SubQueryAttribute : Attribute
    {
        private string _columnName;
        private string _condition = "";

        public SubQueryAttribute(string columnName, string condition)
        {
            _columnName = columnName;
            _condition = condition;
        }

        public string ColumnName
        {
            get { return _columnName; }
        }

        public string Condition
        {
            get { return _condition; }
        }
    }
    #endregion

    #region public class TableColumnAttribute : Attribute
    /// <summary>
    /// Помечает своиство как поле в таблице БД
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class TableColumnAttribute : Attribute
    {
        private string _columnName;
        private int _size;
        private string _typeBy;
        private bool _forced;
        private ColumnAccessType _accessType;

        #region public TableColumnAttribute(string tableColumnName, int size, ColumnAccessType accessType = ColumnAccessType.ReadWrite, bool forced = false)

        /// <summary>
        /// Создает объект с дополнительными параметрами
        /// </summary>
        /// <param name="tableColumnName">Название колонки</param>
        /// <param name="size">Размер поля (только для string)</param>
        /// <param name="accessType">тип доступа к колонке</param>
        /// <param name="forced">Принудительная загрузка/сохранение</param>
        public TableColumnAttribute(string tableColumnName, 
                                    ColumnAccessType accessType = ColumnAccessType.ReadWrite,
                                    int size = 0,
                                    bool forced = false)
        {
            _columnName = tableColumnName;
            _accessType = accessType;
            _size = size;
            _forced = forced;
        }
        #endregion

        #region public TableColumnAttribute(string tableColumnName, int size, ColumnAccessType accessType = ColumnAccessType.ReadWrite, bool forced = false)

        /// <summary>
        /// Создает объект с дополнительными параметрами
        /// </summary>
        /// <param name="tableColumnName">Название колонки</param>
        /// <param name="size">Размер поля (только для string)</param>
        /// <param name="forced">Принудительная загрузка/сохранение</param>
        public TableColumnAttribute(string tableColumnName,
                                    int size,
                                    bool forced = false) : this (tableColumnName, ColumnAccessType.ReadWrite, size, forced)
        {
        }
        #endregion

        #region public TableColumnAttribute(string tableColumnName, string typeBy, ColumnAccessType accessType = ColumnAccessType.ReadWrite, bool forced = false)

        /// <summary>
        /// Создает объект с дополнительными параметрами
        /// </summary>
        /// <param name="tableColumnName">Название колонки</param>
        /// <param name="typeBy">Имя своиства, определяющее тип значения
        /// <br/>Свойство, определяющее тип значения, должно находится перед данным свойством
        /// <br/>Свойство, определяющее тип значения, должно иметь тип SmartCoreType
        /// <br/>и SmartCoreType.ObjectType должно быть статическим или динамическим словарем, или перечислением</param>
        /// <param name="accessType">тип доступа к колонке</param>
        /// <param name="size">Размер поля (только для string)</param>
        /// <param name="forced">Принудительная загрузка/сохранение</param>
        public TableColumnAttribute(string tableColumnName,
                                    string typeBy,
                                    int size = 0,
                                    ColumnAccessType accessType = ColumnAccessType.ReadWrite,
                                    bool forced = false)
        {
            _columnName = tableColumnName;
            _typeBy = typeBy;
            _accessType = accessType;
            _size = size;
            _forced = forced;
        }
        #endregion

        public string ColumnName
        {
            get { return _columnName; }
        }

        public string TypeBy
        {
            get { return _typeBy; }
        }

        public ColumnAccessType AccessType
        {
            get { return _accessType; }
        }

        public int Size
        {
            get { return _size; }
        }

        /// <summary>
        /// Выполняется ли принудительно загрузка данных помеченного атрибутом своиства 
        /// </summary>
        public bool Forced
        {
            get { return _forced; }
        }
    }
    #endregion

    #region public class TableAttribute : Attribute
    /// <summary>
    /// Помечает в какую таблицу БД сохранять экземпляры данного класса
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        private string _tableName;
        private string _tableScheme;
        private string _primaryKey;

        public TableAttribute(string tableName, string tableScheme, string primaryKey)
        {
            _tableName = tableName;
            _tableScheme = tableScheme;
            _primaryKey = primaryKey;
        }

        public string TableName
        {
            get { return _tableName; }
        }

        public string TableScheme
        {
            get { return _tableScheme; }
        }

        public string PrimaryKey
        {
            get { return _primaryKey; }
        }
    }
    #endregion

    #region public class ConditionAttribute : Attribute
    /// <summary>
    /// Задает определенные условия фильтрации полей в БД
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ConditionAttribute : Attribute
    {
        private string _columnName;
        private string _condition;

        public ConditionAttribute(string tableColumnName, string condition)
        {
            _columnName = tableColumnName;
            _condition = condition;
        }

        public string ColumnName
        {
            get { return _columnName; }
        }

        public string Condition
        {
            get { return _condition; }
        }
    }
    #endregion

    #region public class DbTableAttributeNullException
    /// <summary>
    /// Вызывается если у типа нет атрибута TableAttribute или в нем не задано имя таблицы
    /// </summary>
    public class DbTableAttributeNullException : Exception
    {
        private BaseEntityObject _object;
        
        public DbTableAttributeNullException(BaseEntityObject coreObject)
        {
            _object = coreObject;
        }

        public override string Message
        {
            get
            {
                return "у типа " + _object.GetType() + @" отсутвует атрибут TableAttribute в описании класса 
                        или в этом атрибуте не задано имя таблицы в БД";
            }
        }
    }
    #endregion

    #region public class DbTableAttributeNullException
    /// <summary>
    /// Вызывается если таблица, заданная в TableAttribute отсутствует в БД
    /// </summary>
    public class DbTableAttributeException : Exception
    {
        private TableAttribute _ta;
        private Type _object;

        public DbTableAttributeException(Type obj, TableAttribute tableAttribute)
        {
            _ta = tableAttribute;
            _object = obj;
        }

        public override string Message
        {
            get
            {
                return "таблица " + _ta.TableName + " определенная для типа " +_object.Name + @" отсутвует в БД";
            }
        }
    }
    #endregion

    #region public class DbTableColumnsAttributeException
    /// <summary>
    /// Вызывается если колонки в таблице не соответствуют полям, предназначенной для хранения типа
    /// </summary>
    public class DbTableColumnsAttributeException : Exception
    {
        private string _message;
        private Type _object;
        private ColumnError[] _columnErrors;

        public DbTableColumnsAttributeException(Type obj, string message)
        {
            _message = message;
            _object = obj;
        }

        public DbTableColumnsAttributeException(Type obj, ColumnError[] errors)
        {
            _columnErrors = errors;
            _object = obj;
        }

        public override string Message
        {
            get
            {
                if(_columnErrors != null && _columnErrors.Length > 0)
                {
                    string res = "";
                    for(int i = 0; i<_columnErrors.Length; i++)
                    {
                        if (res != "") res += ",\n";
                        res += _columnErrors[i].ToString();
                    }
                }
                return _message;
            }
        }

        public ColumnError[] Errors
        {
            get { return _columnErrors; }
        }
    }
    #endregion

    public class ColumnError
    {
        private String _columnName;
        private ColumnErrorType _columnErrorType;

        public ColumnError(String columnName, ColumnErrorType cet)
        {
            _columnName = columnName;
            _columnErrorType = cet;
        }
    }

    /// <summary>
    /// Принцип работы своиства с колонкой таблицы БД
    /// </summary>
    public enum ColumnAccessType : short
    {
        /// <summary>
        /// Только для чтения
        /// </summary>
        ReadOnly = 1,
        /// <summary>
        /// только для записи (из объекта в БД)
        /// </summary>
        WriteOnly = 2,
        /// <summary>
        /// Чтение и запись
        /// </summary>
        ReadWrite = 4
    }

    public enum ColumnErrorType : short
    {
        Unknown = 0,

        InvalidType = 1,

        InvalidSize = 2,

        NoFind = 4
    }
}
