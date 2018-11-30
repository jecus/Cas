using System;
using System.Text;

namespace SmartCore.Queries
{
    /// <summary>
    /// Описывает запрос к БД
    /// </summary>
    public class DbQuery
    {
        #region public String Branch

        private string _branch;
        /// <summary>
        /// ветвь запроса
        /// </summary>
        public String Branch
        {
            get { return _branch; }
        }
        #endregion

        #region public String QueryString

        private string _queryString;
        /// <summary>
        /// Возвращает строку запроса
        /// </summary>
        public String QueryString
        {
            get { return _queryString; }
            internal set { _queryString = value; }
        }
        #endregion

        #region public Type ElementType

        private Type _elementType;
        /// <summary>
        /// Возвращает Тип объектов, чьи элементы должны быть получены в результате запроса
        /// </summary>
        public Type ElementType
        {
            get { return _elementType; }
        }
        #endregion

        #region private DbQuery()

        private DbQuery()
        {
            _elementType = null;
            _queryString = "";
        }
        #endregion

        #region public DbQuery(Type elementType, string queryString, string branch)

        public DbQuery(Type elementType, string queryString, string branch) : this()
        {
            _elementType = elementType;
            _queryString = queryString;
            _branch = branch;
        }

        #endregion

        #region public override string ToString()
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("Branch: " + _branch + " ");
            sb.AppendLine("Query: " + _queryString + " ");
            sb.AppendLine("Element type: " + _elementType);

            return sb.ToString();
        }
        #endregion
    }
}
