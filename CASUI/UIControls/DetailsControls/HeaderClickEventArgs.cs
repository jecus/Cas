using System;

namespace CAS.UI.UIControls.DetailsControls
{
    /// <summary>
    /// Аргументы события HeaderClick
    /// </summary>
    public class HeaderClickEventArgs:EventArgs
    {
        #region Fields
        private readonly string columnName;
        #endregion

        #region Constructors

        /// <summary>
        /// Создается аргументы события HeaderClick
        /// </summary>
        /// <param name="columnName">Имя заголовка</param>
        public HeaderClickEventArgs(string columnName)
        {
            this.columnName = columnName;
        }

        #endregion

        #region Properties

        #region public string ColumnName

        /// <summary>
        /// Имя заголовка
        /// </summary>
        public string ColumnName
        {
            get { return columnName; }
        }

        #endregion

        #endregion

    }
}
