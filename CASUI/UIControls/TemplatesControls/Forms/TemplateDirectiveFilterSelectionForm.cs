using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.Properties;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.ReportFilters.Templates;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.TemplatesControls.Forms
{
    /// <summary>
    /// Форма для выбора фильтра коллекции директив
    /// </summary>
    public partial class TemplateDirectiveFilterSelectionForm : Form
    {
        #region Fields
        private string pageTitle;
        private TemplateDirectiveCollectionFilter lastAppliedFilter;
        #endregion

        #region Constructor

        /// <summary>
        /// Создается форма для выбора фильтра коллекции директив
        /// </summary>
        public TemplateDirectiveFilterSelectionForm()
        {
            InitializeComponent();
            Text = "Directives filter";
            Icon = Resources.LTR;
        }


        #endregion

        #region Properties

        #region public string PageTitel
        /// <summary>
        /// Заголовок страницы на котророй испоьзуется фильтр
        /// </summary>
        public string PageTitle
        {
            get { return pageTitle; }
            set
            {
                pageTitle = value;
                label8.Text = value + " Filter";
            }
        }
        #endregion

        #endregion

        #region Methods

        #region void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        protected void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
        }
        #endregion


        #region private void buttonApply_Click(object sender, EventArgs e)

        private void buttonApply_Click(object sender, EventArgs e)
        {
            OnReloadRequested();
        }

        #endregion

        #region private void OnReloadRequested()

        private void OnReloadRequested()
        {

            try
            {
                if (ReloadForDate != null)
                        ReloadForDate(this, new EventArgs());
            }
            catch (Exception ex)
            {
                Program.Provider.Logger.Log("Error while loading data", ex);
                return;
            }

                TemplateDirectiveCollectionFilter newFilter = GetDirectiveCollectionFilter();
            if (!newFilter.Equals(lastAppliedFilter))
            {
                lastAppliedFilter = newFilter;
                if (ApplyFilter != null)
                    ApplyFilter(this, new EventArgs());
            }
        }

        #endregion

        #region private void buttonClose_Click(object sender, EventArgs e)

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        #endregion

        #region public TemplateDirectiveCollectionFilter GetDirectiveCollectionFilter()

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public TemplateDirectiveCollectionFilter GetDirectiveCollectionFilter()
        {
            List<TemplateDirectiveFilter> filters = new List<TemplateDirectiveFilter>();
            if (templateDirectiveTitleFilterControl.FilterAppliance)
                filters.Add((TemplateDirectiveFilter)templateDirectiveTitleFilterControl.GetFilter());
            return new TemplateDirectiveCollectionFilter(filters.ToArray());
        }

        #endregion

        #region private void buttonOK_Click(object sender, EventArgs e)

        private void buttonOK_Click(object sender, EventArgs e)
        {
            OnReloadRequested();
            Hide();
        }

        #endregion

        #region private void buttonClearFilter_Click(object sender, EventArgs e)

        private void buttonClearFilter_Click(object sender, EventArgs e)
        {
            templateDirectiveTitleFilterControl.ClearFilter();
        }

        #endregion

        #region protected override void OnLoad(EventArgs e)

        ///<summary>
        ///Raises the <see cref="E:System.Windows.Forms.Form.Load"></see> event.
        ///</summary>
        ///
        ///<param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data. </param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BackColor = Css.CommonAppearance.Colors.BackColor;
            Css.HeaderText.Adjust(label8);

            Css.OrdinaryText.Adjust(buttonClose);
            buttonClose.FlatStyle = FlatStyle.Flat;
            buttonClose.FlatAppearance.BorderColor = Css.SimpleLink.Colors.ActiveLinkColor;
            buttonClose.FlatAppearance.BorderSize = 1;
            buttonClose.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;

            Css.OrdinaryText.Adjust(buttonClearFilter);
            buttonClearFilter.FlatStyle = FlatStyle.Flat;
            buttonClearFilter.FlatAppearance.BorderColor = Css.SimpleLink.Colors.ActiveLinkColor;
            buttonClearFilter.FlatAppearance.BorderSize = 1;
            buttonClearFilter.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;

            Css.OrdinaryText.Adjust(buttonApply);
            buttonApply.FlatStyle = FlatStyle.Flat;
            buttonApply.FlatAppearance.BorderColor = Css.SimpleLink.Colors.ActiveLinkColor;
            buttonApply.FlatAppearance.BorderSize = 1;
            buttonApply.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;

            Css.OrdinaryText.Adjust(buttonOK);
            buttonOK.FlatStyle = FlatStyle.Flat;
            buttonOK.FlatAppearance.BorderColor = Css.SimpleLink.Colors.ActiveLinkColor;
            buttonOK.FlatAppearance.BorderSize = 1;
            buttonOK.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;

            Css.OrdinaryText.Adjust(templateDirectiveTitleFilterControl);
        }

        #endregion

        #region private void DirectiveFilterSelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        private void DirectiveFilterSelectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }
        #endregion

        #region public void SetFilterParameters(DirectiveCollectionFilter filter)

        /// <summary>
        /// Задаются параеметры фильтрации
        /// </summary>
        /// <param name="filter"></param>
        public void SetFilterParameters(TemplateDirectiveCollectionFilter filter)
        {
            for (int i = 0; i < filter.Filters.Length; i++)
            {
                TemplateDirectiveFilter directiveFilter = filter.Filters[i];
                if (directiveFilter is TemplateDirectiveTitleFilter) templateDirectiveTitleFilterControl.SetFilterParameters(directiveFilter);
            }
        }

        #endregion


        #endregion

        #region Events

        #region public event EventHandler ApplyFilter;

        /// <summary>
        /// Событие запроса применения фильтра
        /// </summary>
        public event EventHandler ApplyFilter;

        #endregion

        #region public event EventHandler ReloadForDate;

        /// <summary>
        /// Загрузка данных на заданный момент
        /// </summary>
        public event EventHandler ReloadForDate;

        #endregion

        #endregion
    }
}