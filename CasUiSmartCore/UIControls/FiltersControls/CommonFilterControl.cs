using CAS.UI.Interfaces;

namespace CAS.UI.UIControls.FiltersControls
{
    ///<summary>
    /// Класс, описывающий элемент отображения фильтра состояния
    ///</summary>
    public partial class CommonFilterControl : EditObjectControl
    {

        #region Constructors
        /// <summary>
        /// Создается элемент отображения фильтра состояния
        /// </summary>
        protected CommonFilterControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Properties

        #endregion

        #region Methods

        #region public virtual void ClearFilter()
        /// <summary>
        ///  Происходит отчистка фильтра
        /// </summary>
        public virtual void ClearFilter()
        {
        }
        #endregion

        #endregion
    }
}