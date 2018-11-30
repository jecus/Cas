using System;

namespace SmartCore.Entities.General.Attributes
{
    #region public class ChildAttribute : Attribute
    /// <summary>
    /// помечает своиство как дочерний элемент того класса, в котором определено это своиство
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ChildAttribute : Attribute
    {
        private RelationType _relationType;
        private Type _type;
        private string _foreignKeyColumn;
        private string _parentProperty;
        private string _foreignKeyTypeColumn;
        private string _foreignKeyColumn2;
        private int[] _foreignKeyTypeValue;
        private bool _loadChild;
	    private ColumnAccessType _columnAccessType;

		#region Properties

		public RelationType RelationType
        {
            get { return _relationType; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ForeignKeyColumn
        {
            get { return _foreignKeyColumn; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ForeignKeyColumn2
        {
            get { return _foreignKeyColumn2; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Type Type
        {
            get { return _type; }
        }

        public string ParentProperty
        {
            get { return _parentProperty; }
        }

        public string ForeignKeyTypeColumn
        {
            get { return _foreignKeyTypeColumn; }
        }

        public int[] ForeignKeyTypeValues
        {
            get { return _foreignKeyTypeValue; }
        }

        public bool LoadChild
        {
            get { return _loadChild; }
        }

	    public ColumnAccessType ColumnAccessType
	    {
			get { return _columnAccessType; }
	    }

		#endregion

		#region Constructors

		#region public ChildAttribute()
		/// <summary>
		/// Создает объект с соотношением 1 к 1
		/// </summary>
		public ChildAttribute()
        {
            _relationType = RelationType.OneToOne;
        }
		#endregion

		#region public ChildAttribute(ColumnAccessType columnAccessType)

		public ChildAttribute(RelationType relationType, ColumnAccessType columnAccessType)
		{
			_relationType = relationType;
		    _columnAccessType = columnAccessType;
	    }

	    #endregion

        #region public ChildAttribute(bool loadChild = true) : this()
        /// <summary>
        /// Создает объект с соотношением 1 к 1
        /// </summary>
        /// <param name="loadChild">Будет ли дочернее свойство загружать свои дочерние элементы</param>
        public ChildAttribute(bool loadChild = true) : this()
        {
            _loadChild = loadChild;
        }
        #endregion

        #region public ChildAttribute(RelationType relationType, string foreignKeyColumn, bool loadChild = true)

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="relationType">Тип отношения объектов</param>
        /// <param name="foreignKeyColumn">Колонка, являющяся внешним ключем</param>
        /// <param name="loadChild">Будет ли дочернее свойство загружать свои дочерние элементы</param>
        public ChildAttribute(RelationType relationType, string foreignKeyColumn, bool loadChild = true)
        {
            _relationType = relationType;
            _foreignKeyColumn = foreignKeyColumn;
            _loadChild = loadChild;
        }
        #endregion

        #region public ChildAttribute(RelationType relationType, string foreignKeyColumn, string parentProperty, bool loadChild = true)

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="relationType">Тип отношения объектов</param>
        /// <param name="foreignKeyColumn">Колонка, являющяся внешним ключем</param>
        /// <param name="parentProperty">Своиство в дочернем типе, содержащее ссылку на родителя</param>
        /// <param name="loadChild">Будет ли дочернее свойство загружать свои дочерние элементы</param>
        public ChildAttribute(RelationType relationType, string foreignKeyColumn, string parentProperty, bool loadChild = true)
        {
            _relationType = relationType;
            _foreignKeyColumn = foreignKeyColumn;
            _parentProperty = parentProperty;
            _loadChild = loadChild;
        }
        #endregion

        #region public ChildAttribute(RelationType relationType, string foreignKeyColumn, string foreignKeyTypeColumn, int foreignKeyTypePropertyValue, bool loadChild = true) : this(relationType, foreignKeyColumn, loadChild)
        /// <param name="relationType">Тип отношения объектов</param>
        /// <param name="foreignKeyColumn">Колонка, являющяся внешним ключем</param>
        /// <param name="foreignKeyTypeColumn">Колонка, содержащая значение типа объекта внешнего ключа(директива, чек и т.д.)</param>
        /// <param name="foreignKeyTypePropertyValue">Значение типа объекта внешнего ключа</param>
        /// <param name="loadChild">Будет ли дочернее свойство загружать свои дочерние элементы</param>
        public ChildAttribute(RelationType relationType, 
                              string foreignKeyColumn, 
                              string foreignKeyTypeColumn, 
                              int foreignKeyTypePropertyValue,
                              bool loadChild = true)
            : this(relationType, foreignKeyColumn, loadChild)
        {
            _foreignKeyTypeColumn = foreignKeyTypeColumn;
            _foreignKeyTypeValue = new[]{ foreignKeyTypePropertyValue };
        }
		#endregion

		#region public ChildAttribute(RelationType relationType, string foreignKeyColumn, string foreignKeyTypeColumn, int foreignKeyTypePropertyValue, ColumnAccessType accessType, bool loadChild = true) : this(relationType, foreignKeyColumn, loadChild)

		public ChildAttribute(RelationType relationType,
							  string foreignKeyColumn,
							  string foreignKeyTypeColumn,
							  int foreignKeyTypePropertyValue,
							  ColumnAccessType accessType,
							  bool loadChild = true)
		    : this(relationType, foreignKeyColumn, loadChild)
	    {
		    _foreignKeyTypeColumn = foreignKeyTypeColumn;
		    _foreignKeyTypeValue = new[] {foreignKeyTypePropertyValue};
		    _columnAccessType = accessType;
	    }

	    #endregion

		#region public ChildAttribute(RelationType relationType, string foreignKeyColumn, string foreignKeyTypeColumn, int foreignKeyTypePropertyValue, string parentProperty, bool loadChild = true) : this(relationType, foreignKeyColumn, parentProperty, loadChild)
		/// <param name="relationType">Тип отношения объектов</param>
		/// <param name="foreignKeyColumn">Колонка, являющяся внешним ключем</param>
		/// <param name="foreignKeyTypeColumn">Колонка, содержащая значение типа объекта внешнего ключа(директива, чек и т.д.)</param>
		/// <param name="foreignKeyTypePropertyValue">Значение типа объекта внешнего ключа</param>
		/// <param name="parentProperty">Своиство в дочернем типе, содержащее ссылку на родителя</param>
		/// <param name="loadChild">Будет ли дочернее свойство загружать свои дочерние элементы</param>
		public ChildAttribute(RelationType relationType,
                              string foreignKeyColumn,
                              string foreignKeyTypeColumn,
                              int foreignKeyTypePropertyValue,
                              string parentProperty,
                              bool loadChild = true)
            : this(relationType, foreignKeyColumn, parentProperty, loadChild)
        {
            _foreignKeyTypeColumn = foreignKeyTypeColumn;
            _foreignKeyTypeValue = new[]{ foreignKeyTypePropertyValue };
        }
        #endregion

        #region public ChildAttribute(RelationType relationType, string foreignKeyColumn, string foreignKeyTypeColumn, int foreignKeyTypePropertyValue, bool loadChild = true) : this(relationType, foreignKeyColumn, loadChild)
        /// <param name="relationType">Тип отношения объектов</param>
        /// <param name="foreignKeyColumn">Колонка, являющяся внешним ключем</param>
        /// <param name="foreignKeyTypeColumn">Колонка, содержащая значение типа объекта внешнего ключа(директива, чек и т.д.)</param>
        /// <param name="foreignKeyTypePropertyValues">Значения типа объекта внешнего ключа</param>
        /// <param name="parentProperty">Своиство в дочернем типе, содержащее ссылку на родителя</param>
        /// <param name="loadChild">Будет ли дочернее свойство загружать свои дочерние элементы</param>
        public ChildAttribute(RelationType relationType,
                              string foreignKeyColumn,
                              string foreignKeyTypeColumn,
                              int[] foreignKeyTypePropertyValues,
                              string parentProperty,
                              bool loadChild = true)
            : this(relationType, foreignKeyColumn, parentProperty, loadChild)
        {
            _foreignKeyTypeColumn = foreignKeyTypeColumn;
            _foreignKeyTypeValue = foreignKeyTypePropertyValues;
        }
        #endregion

        #region public ChildAttribute(Type type, string foreignKeyColumn, string foreignKeyTypeColumn, int foreignKeyTypePropertyValue, string parentProperty, bool loadChild = true) : this(relationType, foreignKeyColumn, parentProperty, loadChild)
        /// <summary>
        /// Создает объект для отношения "многие ко многим". (Н. отношения комплектующих и их поставщиков)
        /// </summary>
        /// <param name="type">Тип, в котором содержаться данные об отношении (Н. отношении комплектующих и поставщиков)</param>
        /// <param name="foreignKeyColumn1">Колонка, являющяся внешним ключем (комплектующее)</param>
        /// <param name="foreignKeyTypeColumn">Колонка, содержащая значение типа объекта внешнего ключа(директива, чек и т.д.)</param>
        /// <param name="foreignKeyTypePropertyValue">Значение типа объекта внешнего ключа</param>
        /// <param name="foreignKeyColumn2">Колонка, являющяся внешним ключем (поставщик)</param>
        /// <param name="loadChild">Будет ли дочернее свойство загружать свои дочерние элементы</param>
        public ChildAttribute(Type type,
                              string foreignKeyColumn1,
                              string foreignKeyTypeColumn,
                              int foreignKeyTypePropertyValue,
                              string foreignKeyColumn2,
                              bool loadChild = true)
        {
            _relationType = RelationType.ManyToMany;
            _type = type;
            _foreignKeyColumn = foreignKeyColumn1;
            _foreignKeyTypeColumn = foreignKeyTypeColumn;
            _foreignKeyTypeValue = new[]{ foreignKeyTypePropertyValue };
            _foreignKeyColumn2 = foreignKeyColumn2;
            _loadChild = loadChild;
        }
        #endregion

        #region public ChildAttribute(Type type, string foreignKeyColumn, string foreignKeyTypeColumn, int foreignKeyTypePropertyValue, string parentProperty, bool loadChild = true) : this(relationType, foreignKeyColumn, parentProperty, loadChild)
        /// <summary>
        /// Создает объект для отношения "многие ко многим". (Н. отношения комплектующих и их поставщиков)
        /// </summary>
        /// <param name="type">Тип, в котором содержаться данные об отношении (Н. отношении комплектующих и поставщиков)</param>
        /// <param name="foreignKeyColumn1">Колонка, являющяся внешним ключем (комплектующее)</param>
        /// <param name="foreignKeyTypeColumn">Колонка, содержащая значение типа объекта внешнего ключа(директива, чек и т.д.)</param>
        /// <param name="foreignKeyTypePropertyValues">Значения типа объекта внешнего ключа</param>
        /// <param name="foreignKeyColumn2">Колонка, являющяся внешним ключем (поставщик)</param>
        /// <param name="loadChild">Будет ли дочернее свойство загружать свои дочерние элементы</param>
        public ChildAttribute(Type type,
                              string foreignKeyColumn1,
                              string foreignKeyTypeColumn,
                              int[] foreignKeyTypePropertyValues,
                              string foreignKeyColumn2,
                              bool loadChild = true)
        {
            _relationType = RelationType.ManyToMany;
            _type = type;
            _foreignKeyColumn = foreignKeyColumn1;
            _foreignKeyTypeColumn = foreignKeyTypeColumn;
            _foreignKeyTypeValue = foreignKeyTypePropertyValues ;
            _foreignKeyColumn2 = foreignKeyColumn2;
            _loadChild = loadChild;
        }
        #endregion

        #region public ChildAttribute(Type type, string foreignKeyColumn, string foreignKeyTypeColumn, int foreignKeyTypePropertyValue, string parentProperty, bool loadChild = true) : this(relationType, foreignKeyColumn, parentProperty, loadChild)
        /// <summary>
        /// Создает объект для отношения "многие ко многим". (Н. отношения комплектующих и их поставщиков)
        /// </summary>
        /// <param name="type">Тип, в котором содержаться данные об отношении (Н. отношении комплектующих и поставщиков)</param>
        /// <param name="foreignKeyColumn1">Колонка, являющяся внешним ключем (комплектующее)</param>
        /// <param name="foreignKeyTypeColumn">Колонка, содержащая значение типа объекта внешнего ключа(директива, чек и т.д.)</param>
        /// <param name="foreignKeyTypePropertyValue">Значение типа объекта внешнего ключа</param>
        /// <param name="foreignKeyColumn2">Колонка, являющяся внешним ключем (поставщик)</param>
        /// <param name="parentProperty">Своиство в дочернем типе, содержащее ссылку на родителя</param>
        /// <param name="loadChild">Будет ли дочернее свойство загружать свои дочерние элементы</param>
        public ChildAttribute(Type type,
                              string foreignKeyColumn1,
                              string foreignKeyTypeColumn,
                              int foreignKeyTypePropertyValue,
                              string foreignKeyColumn2,
                              string parentProperty,
                              bool loadChild = true)
        {
            _relationType = RelationType.ManyToMany;
            _type = type;
            _foreignKeyColumn = foreignKeyColumn1;
            _foreignKeyTypeColumn = foreignKeyTypeColumn;
            _foreignKeyTypeValue = new[] { foreignKeyTypePropertyValue };
            _foreignKeyColumn2 = foreignKeyColumn2;
            _parentProperty = parentProperty;
            _loadChild = loadChild;
        }
        #endregion

        #region public ChildAttribute(Type type, string foreignKeyColumn, string foreignKeyTypeColumn, int foreignKeyTypePropertyValue, string parentProperty, bool loadChild = true) : this(relationType, foreignKeyColumn, parentProperty, loadChild)

        /// <summary>
        /// Создает объект для отношения "многие ко многим". (Н. отношения комплектующих и их поставщиков)
        /// </summary>
        /// <param name="type">Тип, в котором содержаться данные об отношении (Н. отношении комплектующих и поставщиков)</param>
        /// <param name="foreignKeyColumn1">Колонка, являющяся внешним ключем (комплектующее)</param>
        /// <param name="foreignKeyTypeColumn">Колонка, содержащая значение типа объекта внешнего ключа(директива, чек и т.д.)</param>
        /// <param name="foreignKeyTypePropertyValues">Значения типа объекта внешнего ключа</param>
        /// <param name="foreignKeyColumn2">Колонка, являющяся внешним ключем (поставщик)</param>
        /// <param name="parentProperty">Своиство в дочернем типе, содержащее ссылку на родителя</param>
        /// <param name="loadChild">Будет ли дочернее свойство загружать свои дочерние элементы</param>
        public ChildAttribute(Type type,
                              string foreignKeyColumn1,
                              string foreignKeyTypeColumn,
                              int[] foreignKeyTypePropertyValues,
                              string foreignKeyColumn2,
                              string parentProperty,
                              bool loadChild = true)
        {
            _relationType = RelationType.ManyToMany;
            _type = type;
            _foreignKeyColumn = foreignKeyColumn1;
            _foreignKeyTypeColumn = foreignKeyTypeColumn;
            _foreignKeyTypeValue = foreignKeyTypePropertyValues;
            _foreignKeyColumn2 = foreignKeyColumn2;
            _parentProperty = parentProperty;
            _loadChild = loadChild;
        }
		#endregion

		#endregion
	}
    #endregion

    #region  public class MinMaxValueAttribute : Attribute
    /// <summary>
    /// задает минимальное и максимальное значение для своиства
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class MinMaxValueAttribute : Attribute
    {
        private double _min;
        private double _max;
       
        public MinMaxValueAttribute(double min, double max)
        {
            _min = min;
            _max = max;
        }

        public double Min
        {
            get { return _min; }
        }

        public double Max
        {
            get { return _max; }
        }
    }
    #endregion

    #region  public class NotNullAttribute : Attribute
    /// <summary>
    /// помечает своиство в котором недопустимы null или пустые("") значения
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NotNullAttribute : Attribute
    {
    }
    #endregion

    #region public class ParentAttribute : Attribute
    /// <summary>
    /// помечает своиство как родительский элемент класса в котором оно определено
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ParentAttribute : Attribute
    {
    }
    #endregion


    /// <summary>
    /// Тип отношения объектов
    /// </summary>
    public enum RelationType : short
    {
        /// <summary>
        /// Один к одному
        /// </summary>
        OneToOne = 1,
        /// <summary>
        /// Один ко многим
        /// </summary>
        OneToMany = 2,
        /// <summary>
        /// Много ко многим
        /// </summary>
        ManyToMany = 4
    }
}
