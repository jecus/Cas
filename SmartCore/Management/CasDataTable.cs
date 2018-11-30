using System;
using System.Data;
using System.Runtime.Serialization;

namespace SmartCore.Management
{
	/// <summary>
	/// Описывает таблицу данных программы CAS, получаемую в результате выполения запроса
	/// </summary>
	[DataContract(IsReference = true)]
	public class CasDataTable : DataTable
    {
        #region public String Branch

        private string _branch;
		/// <summary>
		/// ветвь запроса
		/// </summary>
		[DataMember]
		public String Branch
        {
            get { return _branch; }
        }
        #endregion

        #region public Type ElementType

        private Type _elementType;
		/// <summary>
		/// Возвращает Тип объектов, чьи элементы находятся в таблице
		/// </summary>
		[DataMember]
		public Type ElementType
        {
            get { return _elementType; }
        }
        #endregion

        #region private CasDataTable()

        private CasDataTable()
        {
            _elementType = null;
            _branch = "";
        }
        #endregion

        #region public CasDataTable(Type elementType, string branch)

        public CasDataTable(Type elementType, string branch)
        {
            _elementType = elementType;
            _branch = branch;
        }

        #endregion

        #region public CasDataTable(Type elementType, string branch, string tableName) : base (tableName)

        public CasDataTable(Type elementType, string branch, string tableName) : base (tableName)
        {
            _elementType = elementType;
            _branch = branch;
        }

        #endregion

        #region public CasDataTable(Type elementType, string branch, string tableName, string tableNameSpace) : base(tableName, tableNameSpace)

        public CasDataTable(Type elementType, string branch, string tableName, string tableNameSpace)
            : base(tableName, tableNameSpace)
        {
            _elementType = elementType;
            _branch = branch;
        }

        #endregion
    }
}
