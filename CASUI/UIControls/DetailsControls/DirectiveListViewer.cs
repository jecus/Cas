using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Controls;
using LTR.Core;
using LTR.Core.Core.Interfaces;
using LTR.Core.Types.Aircrafts.Parts;
using LTR.Core.Types.Dictionaries;
using LTR.Core.Types.Directives;
using LTR.Core.Types.ReportFilters;
using LTR.UI.Interfaces;
using LTR.UI.Management.Dispatchering;
using LTR.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl;
using LTR.UI.Management.Dispatchering.DispatcheredUIControls.Reports;
using LTR.UI.UIControls.DirectivesControls;
using LTRReports;

namespace LTR.UI.UIControls.DetailsControls
{
    ///<summary>
    /// Класс, описывающий отображение базового агрегата
    ///</summary>
    [ToolboxItem(false)]
    public partial class DirectiveListViewer : UserControl
    {
        #region Fields

        private Aircraft currentAircraft;

        /// <summary>
        /// Текущий отображаемый базовый агрегат
        /// </summary>
        protected BaseDetail currentBaseDetail;
        private readonly DirectiveCollectionFilter viewFilter;
        private DirectiveCollectionFilter additionalFilter;
        private DirectiveList directivesViewer;
        private readonly DirectiveType directiveType;
        private DirectiveFilterSelectionForm filterSelection = new DirectiveFilterSelectionForm();
        private DirectiveListReportBuilder reportBuilder;
        private string reportText;

        #endregion

        #region Constructors

        #region public DirectiveListViewer() : this(null)

        /// <summary>
        /// Создаёт экземпляр контрола, отображающего воздушное судно
        /// </summary>
        protected DirectiveListViewer()
        {
            InitializeComponent();
        }

        #endregion

        #region public DirectiveListViewer(BaseDetail currentBaseDetail, DirectiveCollectionFilter viewFilter, string reportText) : this(currentBaseDetail, viewFilter, reportText, null)
        ///<summary>
        /// Создается элемент отображения коллекции директив базового агрегата
        ///</summary>
        ///<param name="currentBaseDetail"></param>
        ///<exception cref="ArgumentNullException"></exception>
        ///<param name="viewFilter"></param>
        ///<param name="reportText"></param>
        public DirectiveListViewer(BaseDetail currentBaseDetail, DirectiveCollectionFilter viewFilter, string reportText) : this(currentBaseDetail, viewFilter, reportText, null)
        {
        }
        #endregion

        #region public DirectiveListViewer(BaseDetail currentBaseDetail, DirectiveCollectionFilter viewFilter, string reportText, DirectiveType directiveType)

        ///<summary>
        /// Создается элемент отображения коллекции директив базового агрегата
        ///</summary>
        ///<param name="currentBaseDetail"></param>
        ///<exception cref="ArgumentNullException"></exception>
        ///<param name="viewFilter"></param>
        ///<param name="reportText"></param>
        ///<param name="directiveType"></param>
        public DirectiveListViewer(BaseDetail currentBaseDetail, DirectiveCollectionFilter viewFilter, string reportText, DirectiveType directiveType)
        {
            if (currentBaseDetail == null)
                throw new ArgumentNullException("currentBaseDetail", "Cannot display null-baseDetail");
            this.currentBaseDetail = currentBaseDetail;
            this.viewFilter = viewFilter;
            this.reportText = reportText;
            this.directiveType = directiveType;
            InitializeComponent();
            UpdateElements();
        }
        #endregion

        #region public DirectiveListViewer(Aircraft currentAircraft, DirectiveCollectionFilter viewFilter, string reportText)

        ///<summary>
        /// Создается элемент отображения коллекции директив ВС
        ///</summary>
        ///<param name="currentAircraft"></param>
        ///<exception cref="ArgumentNullException"></exception>
        ///<param name="viewFilter"></param>
        public DirectiveListViewer(Aircraft currentAircraft, DirectiveCollectionFilter viewFilter, string reportText)
        {
            if (currentAircraft == null) throw new ArgumentNullException("currentAircraft");
            this.currentAircraft = currentAircraft;
            this.viewFilter = viewFilter;
            this.reportText = reportText;
            InitializeComponent();
            UpdateElements();
        }

        #endregion

        #endregion

        #region Properties

        #region public BaseDetail CurrentBaseDetail
        /// <summary>
        /// Текущий отображаемый базовый агрегат
        /// </summary>
        public BaseDetail CurrentBaseDetail
        {
            get { return currentBaseDetail; }
            set
            {
                currentBaseDetail = value;
                currentAircraft = null;
                UpdateElements();
            }
        }
        #endregion

        #region public Aircraft CurrentAircraft

        /// <summary>
        /// ВС для которого отображаются элементы( базовый агрегат, или все директивы)
        /// </summary>
        public Aircraft CurrentAircraft
        {
            get
            {
                if (currentBaseDetail != null) return currentBaseDetail.ParentAircraft;
                return currentAircraft;
            }
            set
            {
                currentAircraft = value;
                currentBaseDetail = null;
                UpdateElements();
            }
        }

        #endregion

        #region public IDirectiveContainer DirectiveSource

        /// <summary>
        /// Контайнер директив
        /// </summary>
        public IDirectiveContainer DirectiveSource
        {
            get
            {
                if (CurrentBaseDetail != null) 
                    return CurrentBaseDetail;
                return CurrentAircraft;
            }
        }

        /// <summary>
        /// Создатель отчетов списка директив
        /// </summary>
        public DirectiveListReportBuilder ReportBuilder
        {
            get { return reportBuilder; }
            set { reportBuilder = value; }
        }

        /// <summary>
        /// Название отчета
        /// </summary>
        public string ReportText
        {
            get { return reportText; }
            set { reportText = value; }
        }

        #endregion

        #endregion
        
        #region Methods

        #region private void UpdateHeader()

        private void UpdateHeader()
        {
            aircraftHeaderControl.Aircraft = CurrentAircraft;
            aircraftHeaderControl.OperatorClickable = true;
        }

        #endregion

        #region protected virtual void ReloadElements()

        /// <summary>
        /// Происходит перезагрузка элементов и синхронизация с базой данных
        /// </summary>
        protected virtual void ReloadElements()
        {
            if (DirectiveSource != null) 
                ((CoreType) DirectiveSource).Reload(true, DateTime.Now, true);
            UpdateElements();
        }

        #endregion

        #region public override void UpdateElements()
        /// <summary>
        /// Происзодит обновление отображения элементов
        /// </summary>
        public void UpdateElements()
        {
            if (currentAircraft != null)
            {
                labelTitle.Text = currentAircraft.RegistrationNumber + ". " + reportText;
                labelTitle.Status = (Statuses)currentAircraft.LimitationCondition;
            }
            else if (currentBaseDetail != null)
            {
                labelTitle.Text = currentBaseDetail.SerialNumber + ". " + reportText;
                labelTitle.Status = (Statuses)currentBaseDetail.LimitationCondition;
            }
            else
            {
                labelTitle.Status = Statuses.NotActive;
                labelTitle.Text = reportText;
            }
            UpdateHeader();
            UpdateDirectives();
        }
        #endregion

        #region private void UpdateDirectives()
        private void UpdateDirectives()
        {
            if (directivesViewer == null)
            {
                directivesViewer = new DirectiveList(GatherDirectives());
                directivesViewer.Dock = DockStyle.Top;
                /*directivesViewer.AutoSize = true;
                directivesViewer.AutoSizeMode = AutoSizeMode.GrowAndShrink;*/
                panelDirectiveColletionContainer.Controls.Add(directivesViewer);
            }
            else
            {
                directivesViewer.DisplayDirectives(GatherDirectives());
            }
            labelDateAsOf.Text = "Date as of: " + filterSelection.DateSelected.ToString("MMM dd, yyyy");
        }
        #endregion

        #region private Directive[] GatherDirectives()

        private Directive[] GatherDirectives()
        {
            return GatherDirectives(additionalFilter);
        }

        private Directive[] GatherDirectives(DirectiveCollectionFilter additionalFilter)
        {
            List<DirectiveFilter> filters = new List<DirectiveFilter>(viewFilter.Filters);
            if (additionalFilter != null)
                filters.AddRange(additionalFilter.Filters);
            DirectiveCollectionFilter filter =
                new DirectiveCollectionFilter(DirectiveSource.Directives, filters.ToArray());
            return filter.GatherDirectives();
        }
        #endregion

        #region private Directive[] GatherDirectives()

        private BaseDetailDirective[] GatherBaseDetailDirectives()
        {
            return GatherBaseDetailDirectives(additionalFilter);
        }

        private BaseDetailDirective[] GatherBaseDetailDirectives(DirectiveCollectionFilter additionalFilter)
        {
            Directive[] directives = GatherDirectives(additionalFilter);
            List<BaseDetailDirective> baseDtailDirectives = new List<BaseDetailDirective>(directives.Length);
            for (int i = 0; i < directives.Length; i++)
            {
                if (directives[i] is BaseDetailDirective)
                    baseDtailDirectives.Add((BaseDetailDirective)directives[i]);
            }
            return baseDtailDirectives.ToArray();
        }
        #endregion

        #region private void ButtonReload_ReloadRised(object sender, EventArgs e)

        private void ButtonReload_ReloadRised(object sender, EventArgs e)
        {
            ReloadElements();
        }

        #endregion

        #region private void filterSelection_ReloadForDate(object sender, EventArgs e)

        private void filterSelection_ReloadForDate(object sender, EventArgs e)
        {
            CoreType item = ((CoreType)DirectiveSource).CloneAsDateOf(filterSelection.DateSelected);
            if (item is Aircraft)
                CurrentAircraft = item as Aircraft;
            if (item is BaseDetail)
            {
                CurrentBaseDetail = item as BaseDetail;
                Directive[] directives = GatherDirectives(additionalFilter);
            }
        }

        #endregion

        #region private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void ButtonPrint_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (currentAircraft != null)
                e.DisplayerText = currentAircraft.RegistrationNumber + ". " + ReportText + " Report";
            else if (currentBaseDetail != null)
                e.DisplayerText = currentBaseDetail.ToString() + ". " + ReportText + " Report";
            else
                e.DisplayerText = ReportText + " Report";
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            reportBuilder.Clear();
            if (((CoreType)(DirectiveSource)).LoadCurrentData)
                reportBuilder.DateAsOf = DateTime.Today.ToString("MMM dd, yyyy");
            else
                reportBuilder.DateAsOf = filterSelection.DateSelected.ToString("MMM dd, yyyy");
            BaseDetailDirective[] filteredBaseDetailDirectives = GatherBaseDetailDirectives();
            BaseDetailDirective[] notFilteredDirectives = GatherBaseDetailDirectives(null);
            if (currentAircraft != null)
            {
                if (notFilteredDirectives.Length != filteredBaseDetailDirectives.Length)
                {
                    reportBuilder.Model = currentAircraft.Model + ". Filtered";
                    e.RequestedEntity = new DispatcheredDirectiveListReport(filteredBaseDetailDirectives, reportBuilder);
                }
                else
                {
                    reportBuilder.Model = currentAircraft.Model;
                    e.RequestedEntity = new DispatcheredDirectiveListReport(currentAircraft, reportBuilder);
                }
            }
            else
            {
                if (currentBaseDetail != null)
                {
                    if (notFilteredDirectives.Length != filteredBaseDetailDirectives.Length)
                    {
                        reportBuilder.Model = currentBaseDetail.Model + ". Filtered";
                        e.RequestedEntity = new DispatcheredDirectiveListReport(filteredBaseDetailDirectives, reportBuilder);
                    }
                    else
                    {
                        reportBuilder.Model = currentBaseDetail.Model;
                        e.RequestedEntity = new DispatcheredDirectiveListReport(currentBaseDetail, reportBuilder);
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion

        #region private void buttonApplyFilter_Click(object sender, EventArgs e)

        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {
            filterSelection.Close();
            filterSelection = new DirectiveFilterSelectionForm();
            filterSelection.Show();
            filterSelection.ApplyFilter += filterSelection_ApplyFilter;
            filterSelection.ReloadForDate += filterSelection_ReloadForDate;
        }

        #endregion

        #region private void referenceAvalonButtonAddDirective_DisplayerRequested(object sender, ReferenceEventArgs e)

        private void referenceAvalonButtonAddDirective_DisplayerRequested(object sender, ReferenceEventArgs e)
        {
            if (CurrentBaseDetail != null)
                e.RequestedEntity = new DispatcheredDirectiveAdding(CurrentBaseDetail, directiveType);
            else
                e.RequestedEntity = new DispatcheredDirectiveAdding(CurrentAircraft);
            if (CurrentBaseDetail != null)
                e.DisplayerText = string.Format("Add Directive to {0}", CurrentBaseDetail.SerialNumber);
            else
                e.DisplayerText = string.Format("Add Directive to {0}", CurrentAircraft.SerialNumber);
        }

        #endregion

        #region private void filterSelection_ApplyFilter(object sender, EventArgs e)

        private void filterSelection_ApplyFilter(object sender, EventArgs e)
        {
            additionalFilter = filterSelection.GetDirectiveCollectionFilter();
            UpdateDirectives();
        }

        #endregion

        #endregion
    }
}