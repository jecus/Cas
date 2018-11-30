using System;

namespace SmartCore.Entities.General.Attributes
{
    #region  public class FilterAttribute : Attribute
    /// <summary>
    /// помечает своиство как имеющее фильтр
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class FilterAttribute : Attribute
    {
        private string _title;
        private int _order;

        /// <summary>
        /// Порядковый номер контрола для данного свойства в форме фильтрации 
        /// </summary>
        public int Order
        {
            get { return _order; }
            set { _order = value; }
        }

        public string Title
        {
            get { return _title; }
        }

        #region private FilterAttribute()
        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        private FilterAttribute()
        {
        }
        #endregion

        #region public FilterAttribute(string title, int order = -1)

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="title"></param>
        public FilterAttribute(string title)
        {
            _title = title;
        }
        #endregion
    }
    #endregion
}
