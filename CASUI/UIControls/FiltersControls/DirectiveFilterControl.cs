using System.Collections.Generic;
using System.Windows.Forms;
using CAS.Core.Types.ReportFilters;

namespace CAS.UI.UIControls.FiltersControls
{
    /// <summary>
    /// Ёлемент управлени€ выбора фильтра коллекции директив
    /// </summary>
    public partial class DirectiveFilterControl : UserControl
    {
        /// <summary>
        /// —оздаетс€ элемент управлени€ выбора фильтра коллекции директив
        /// </summary>
        public DirectiveFilterControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// —оздаетс€ фильтр коллекции директив
        /// </summary>
        /// <returns></returns>
        public DirectiveCollectionFilter GetDirectiveCollectionFilter()
        {
            List<DirectiveFilter> filters = new List<DirectiveFilter>();
            filters.Add(directiveTitleFilterControl1.GetFilter() as DirectiveFilter);
            filters.Add(directiveOpenessFilterControl1.GetFilter() as DirectiveFilter);
            filters.Add(directiveConditionFilterControl1.GetFilter() as DirectiveFilter);
            return new DirectiveCollectionFilter(null, filters.ToArray());
        }
    }
}