using System.Windows.Forms;
using LTR.Core.Core.Interfaces;
using LTR.Core.Types.ReportFilters;
using LTR.UI.UIControls.ReferenceControls;

namespace LTR.UI.UIControls.DiscrepanciesControls
{
    /// <summary>
    /// Элемент управления - отображения коллекции отклонений по директивам
    /// </summary>
    public partial class DirectivesDiscrepancies : UserControl
    {
        #region Fields
        /// <summary>
        /// Фильтр выборки директив
        /// </summary>
        private DirectiveCollectionFilter directiveSelectionFilter;
        /// <summary>
        /// Дополнительный фильтр
        /// </summary>
        private DirectiveCollectionFilter additionalFilter;
        /// <summary>
        /// Фильтр выборки для отклонений
        /// </summary>
        private DirectiveCollectionFilter discrepanciesFilter;
        /// <summary>
        /// Источник директив для отображения отклонений
        /// </summary>
        private IDirectiveContainer directiveContainer;
        #endregion

        #region Constructors

        /// <summary>
        /// Создается элемент управления - отображения коллекции отклонений по директивам
        /// </summary>
        protected DirectivesDiscrepancies()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Создается элемент управления - отображения коллекции отклонений по директивам
        /// </summary>
        /// <param name="directiveSelectionFilter"></param>
        /// <param name="directiveContainer"></param>
        public DirectivesDiscrepancies(DirectiveCollectionFilter directiveSelectionFilter, IDirectiveContainer directiveContainer)
        {
            this.directiveSelectionFilter = directiveSelectionFilter;
            this.directiveContainer = directiveContainer;
        }

        /// <summary>
        /// Создается элемент управления - отображения коллекции отклонений по директивам
        /// </summary>
        /// <param name="directiveSelectionFilter"></param>
        /// <param name="discrepanciesFilter"></param>
        /// <param name="directiveContainer"></param>
        public DirectivesDiscrepancies(DirectiveCollectionFilter directiveSelectionFilter, DirectiveCollectionFilter discrepanciesFilter, IDirectiveContainer directiveContainer):this()
        {
            this.directiveSelectionFilter = directiveSelectionFilter;
            this.discrepanciesFilter = discrepanciesFilter;
            this.directiveContainer = directiveContainer;
        }

        #endregion

        #region Properties

        #region public string Caption

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Caption
        {
            get { return extendableRichContainer1.Caption; }
            set { extendableRichContainer1.Caption = value; }
        }

        #endregion

        #region public DirectiveCollectionFilter DirectiveSelectionFilter

        /// <summary>
        /// Фильтр выборки директив
        /// </summary>
        public DirectiveCollectionFilter DirectiveSelectionFilter
        {
            get { return directiveSelectionFilter; }
            set { directiveSelectionFilter = value; }
        }

        #endregion

        #region public DirectiveCollectionFilter AdditionalFilter

        /// <summary>
        /// Дополнительный фильтр
        /// </summary>
        public DirectiveCollectionFilter AdditionalFilter
        {
            get { return additionalFilter; }
            set { additionalFilter = value; }
        }

        #endregion

        #region public DirectiveCollectionFilter DiscrepanciesFilter

        /// <summary>
        /// Фильтр выборки для отклонений
        /// </summary>
        public DirectiveCollectionFilter DiscrepanciesFilter
        {
            get { return discrepanciesFilter; }
            set { discrepanciesFilter = value; }
        }

        #endregion

        #endregion

        #region Methods

        #endregion

    }
}
