using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.Directives;
using CAS.UI.Properties;
using CAS.Core.ProjectTerms;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Appearance;

namespace CAS.UI.UIControls.FiltersControls
{
    /// <summary>
    /// Форма для выбора фильтра коллекции директив
    /// </summary>
    public partial class DirectiveFilterSelectionForm : Form
    {

        #region Fields
        private string pageTitle;
        private DirectiveCollectionFilter lastAppliedFilter;
        private DirectiveType directiveType;
        #endregion

        #region Constructor

        /// <summary>
        /// Создается форма для выбора фильтра коллекции директив
        /// </summary>
        public DirectiveFilterSelectionForm(DirectiveType directiveType, DirectiveCollectionFilter filter)
        {
            InitializeComponent();
            Text = directiveType.CommonName + " filter";
            Icon = Resources.LTR;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.MaxDate = DateTime.Now;
            this.directiveType = directiveType;
            if (directiveType == DirectiveTypeCollection.Instance.OutOffPhaseDirectiveType)
            {
                abstractDirectiveDescriptionFilterControl2.Visible = true;
                abstractDirectiveTitleFilterControl1.Visible = false;
            }
            if (directiveType == DirectiveTypeCollection.Instance.ADDirectiveType)
            {
                checkBoxAF.Visible = true;
                checkBoxAP.Visible = true;
                if (filter == null)
                    return;
                DirectiveADTypeFilter adTypeFilter = null;
                for (int i = 0; i < filter.Filters.Length; i++)
                {
                    if (filter.Filters[i] is DirectiveADTypeFilter)
                    {
                        adTypeFilter = (DirectiveADTypeFilter) filter.Filters[i];
                        break;
                    }
                }
                if (adTypeFilter != null)
                {
                    if (adTypeFilter.ADType == ADType.Airframe)
                        checkBoxAP.Checked = false;
                    else
                        checkBoxAF.Checked = false;
                }

            }
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
                label8.Text = value;
            }
        }
        #endregion

        #region public DateTime DateSelected
        /// <summary>
        /// Дата на которую происходит загрузка данных
        /// </summary>
        public DateTime DateSelected
        {
            get { return dateTimePicker1.Value; }
            set { dateTimePicker1.Value = value; }
        }
        #endregion

        #region public bool ReloadAsDateOf

        /// <summary>
        /// Предоставлять ли данные на определенную дату
        /// </summary>
        public bool ReloadAsDateOf
        {
            get
            {
                return checkBoxDateAsOf.Checked;
            }
            set
            {
                checkBoxDateAsOf.Checked = value;
            }
        }

        #endregion

        #endregion

        #region Methods

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

            DirectiveCollectionFilter newFilter = GetDirectiveCollectionFilter();
            if (!newFilter.Equals(lastAppliedFilter))
            {
                lastAppliedFilter = newFilter;
                if (ApplyFilter != null)
                    ApplyFilter(lastAppliedFilter);
            }
        }

        #endregion

        #region private void buttonClose_Click(object sender, EventArgs e)

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        #endregion
        
        #region public DirectiveCollectionFilter GetDirectiveCollectionFilter()

        /// <summary>
        /// Возвращает список применных фильров
        /// </summary>
        /// <returns></returns>
        public DirectiveCollectionFilter GetDirectiveCollectionFilter()
        {
            List<DirectiveFilter> filters = new List<DirectiveFilter>();
            if (directiveType == DirectiveTypeCollection.Instance.OutOffPhaseDirectiveType && abstractDirectiveDescriptionFilterControl2.FilterAppliance)
                filters.Add(abstractDirectiveDescriptionFilterControl2.GetFilter() as DirectiveFilter);
            else if (directiveType != DirectiveTypeCollection.Instance.OutOffPhaseDirectiveType && abstractDirectiveTitleFilterControl1.FilterAppliance)
                filters.Add(abstractDirectiveTitleFilterControl1.GetFilter() as DirectiveFilter);
            if (directiveType == DirectiveTypeCollection.Instance.ADDirectiveType && !checkBoxAF.Checked || !checkBoxAP.Checked)
            {
                if (checkBoxAF.Checked)
                    filters.Add(new DirectiveADTypeFilter(ADType.Airframe));
                if (checkBoxAP.Checked)
                    filters.Add(new DirectiveADTypeFilter(ADType.Appliance));
            }
            if (directiveOpenessFilterControl1.FilterAppliance) 
                filters.Add(directiveOpenessFilterControl1.GetFilter() as DirectiveFilter);
            if (directiveConditionFilterControl1.FilterAppliance) 
                filters.Add(directiveConditionFilterControl1.GetFilter() as DirectiveFilter);
            return new DirectiveCollectionFilter(filters.ToArray());
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
            directiveOpenessFilterControl1.ClearFilter();
            directiveConditionFilterControl1.ClearFilter();
            abstractDirectiveTitleFilterControl1.ClearFilter();
            dateTimePicker1.Value = DateTime.Today;
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

            Css.OrdinaryText.Adjust(checkBoxDateAsOf);
            checkBoxDateAsOf.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
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

            Css.OrdinaryText.Adjust(buttonReloadAsDateOf);
            buttonReloadAsDateOf.FlatStyle = FlatStyle.Flat;
            buttonReloadAsDateOf.FlatAppearance.BorderColor = Css.SimpleLink.Colors.ActiveLinkColor;
            buttonReloadAsDateOf.FlatAppearance.BorderSize = 1;
            buttonReloadAsDateOf.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;

            
            Css.OrdinaryText.Adjust(dateTimePicker1);
            Css.OrdinaryText.Adjust(directiveOpenessFilterControl1);
            Css.OrdinaryText.Adjust(directiveConditionFilterControl1);
            Css.OrdinaryText.Adjust(abstractDirectiveTitleFilterControl1);

            checkBoxAF.FlatStyle = FlatStyle.Flat;
            Css.OrdinaryText.Adjust(checkBoxAF);
            checkBoxAF.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;

            checkBoxAP.FlatStyle = FlatStyle.Flat;
            Css.OrdinaryText.Adjust(checkBoxAP);
            checkBoxAP.ForeColor = Css.SimpleLink.Colors.ActiveLinkColor;
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
        /// Задаются параметры фильтрации
        /// </summary>
        /// <param name="filter"></param>
        public void SetFilterParameters(DirectiveCollectionFilter filter)
        {
            for (int i = 0; i < filter.Filters.Length; i++)
            {
                DirectiveFilter directiveFilter = filter.Filters[i];
                if (directiveFilter is DirectiveTitleFilter) abstractDirectiveTitleFilterControl1.SetFilterParameters(directiveFilter);
                if (directiveFilter is DirectiveOpenessFilter) directiveOpenessFilterControl1.SetFilterParameters(directiveFilter);
                if (directiveFilter is DirectiveConditionFilter) directiveConditionFilterControl1.SetFilterParameters(directiveFilter);
            }
        }

        #endregion

        #region private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value < DateTime.Today)
                checkBoxDateAsOf.Checked = true;
            else
                checkBoxDateAsOf.Checked = false;
        }

        #endregion

        #region private void checkBoxAF_CheckedChanged(object sender, EventArgs e)

        private void checkBoxAF_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAF.Checked)
                checkBoxAP.Checked = true;
        }

        #endregion

        #region private void checkBoxAP_CheckedChanged(object sender, EventArgs e)

        private void checkBoxAP_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxAP.Checked)
                checkBoxAF.Checked = true;
        }

        #endregion
        
        #endregion

        #region Delegates

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        public delegate void FilterApplyEventHandler(DirectiveCollectionFilter filter);

        #endregion

        #region Events

        #region public event EventHandler ApplyFilter;

        /// <summary>
        /// Событие запроса применения фильтра
        /// </summary>
        public event FilterApplyEventHandler ApplyFilter;

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