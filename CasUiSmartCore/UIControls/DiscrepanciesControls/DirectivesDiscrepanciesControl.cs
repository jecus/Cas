using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Directives;
using CAS.Core.Core.Interfaces;
using CAS.Core.Types.ReportFilters;
using CAS.UI.UIControls.DirectivesControls;

namespace CAS.UI.UIControls.DiscrepanciesControls
{
    /// <summary>
    /// Элемент управления - отображения коллекции отклонений по директивам
    /// </summary>
    public partial class DirectivesDiscrepanciesControl : UserControl
    {
        #region Fields

        private int count = 0;
        /// <summary>
        /// Фильтр выборки директив
        /// </summary>
        private DirectiveFilter directiveSelectionFilter = new AllDirectiveFilter();
        /// <summary>
        /// Дополнительный фильтр
        /// </summary>
        private DirectiveCollectionFilter additionalFilter;
        /// <summary>
        /// Фильтр выборки для отклонений
        /// </summary>
        private DirectiveFilter discrepanciesFilter = new DiscrepanciesFilter();
        /// <summary>
        /// Источник директив для отображения отклонений
        /// </summary>
        private IDirectiveContainer directiveContainer;

        private DirectiveListView directiveListViewer;
        /// <summary>
        /// Отображается ли заголовок в списке директив
        /// </summary>
        private bool showHeader = true;

        private string caption = "";
        #endregion

        #region Constructors

        /// <summary>
        /// Создается элемент управления - отображения коллекции отклонений по директивам
        /// </summary>
        public DirectivesDiscrepanciesControl()
        {
            InitializeComponent();
            ShowDirectives();
            Margin = new Padding(10, 20, 10, 10);
            
        }

        /// <summary>
        /// Создается элемент управления - отображения коллекции отклонений по директивам
        /// </summary>
        /// <param name="directiveSelectionFilter"></param>
        /// <param name="directiveContainer"></param>
        public DirectivesDiscrepanciesControl(DirectiveCollectionFilter directiveSelectionFilter, IDirectiveContainer directiveContainer)
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
        public DirectivesDiscrepanciesControl(DirectiveCollectionFilter directiveSelectionFilter, DirectiveCollectionFilter discrepanciesFilter, IDirectiveContainer directiveContainer):this()
        {
            this.directiveSelectionFilter = directiveSelectionFilter;
            this.discrepanciesFilter = discrepanciesFilter;
            this.directiveContainer = directiveContainer;
        }

        #endregion

        #region Properties

        #region public int Count

        /// <summary>
        /// Количество отображаемых элементов
        /// </summary>
        public int Count
        {
            get
            {
                return count;
            }
        }

        #endregion

        #region public string Caption

        /// <summary>
        /// Заголовок
        /// </summary>
        public string Caption
        {
            get { return caption; }
            set
            {
                caption = value;
                SetCaption();
            }
        }

        #endregion

        #region public DirectiveCollectionFilter DirectiveSelectionFilter

        /// <summary>
        /// Фильтр выборки директив
        /// </summary>
        public DirectiveFilter DirectiveSelectionFilter
        {
            get { return directiveSelectionFilter; }
            set 
            {
                directiveSelectionFilter = value;
                ShowDirectives();
            }
        }

        #endregion

        #region public DirectiveCollectionFilter AdditionalFilter

        /// <summary>
        /// Дополнительный фильтр
        /// </summary>
        public DirectiveCollectionFilter AdditionalFilter
        {
            get { return additionalFilter; }
            set
            {
                additionalFilter = value;
                ShowDirectives();
            }
        }

        #endregion

        #region public DirectiveCollectionFilter DiscrepanciesFilter

        /// <summary>
        /// Фильтр выборки для отклонений
        /// </summary>
        public DirectiveFilter DiscrepanciesFilter
        {
            get { return discrepanciesFilter; }
            set
            {
                discrepanciesFilter = value;
                ShowDirectives();
            }
        }

        #endregion

        #region public IDirectiveContainer DirectiveContainer

        /// <summary>
        /// Источник директив для отображения отклонений
        /// </summary>
        public IDirectiveContainer DirectiveContainer
        {
            get { return directiveContainer; }
            set
            {
                 directiveContainer = value;
                ShowDirectives();
            }
        }

        #endregion

        #region public bool ShowHeader

        /// <summary>
        /// Отображается ли заголовок в списке директив
        /// </summary>
        public bool ShowHeader
        {
            get { return showHeader; }
            set { showHeader = value; }
        }

        #endregion

        #endregion

        #region Methods

        #region public void ShowDirectives()

        /// <summary>
        /// Отображение списка директив
        /// </summary>
        public void ShowDirectives()
        {
            BaseDetailDirective[] directiveArray = GatherDirectives();
            int count = directiveArray.Length;
            BaseDetailDirective[] baseDetailDirectiveArray = new BaseDetailDirective[count];
            for (int i = 0; i < count; i++)
            {
                baseDetailDirectiveArray[i] = directiveArray[i] as BaseDetailDirective;
            }
            if (directiveListViewer == null)
            {
                Panel panel = new Panel();
                panel.Dock = DockStyle.Top;
                panel.Location = new Point(0, 0);

                directiveListViewer = new DirectiveListView();
                //directiveListViewer.AutoSize = true;
                //directiveListViewer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                directiveListViewer.Scrollable = false;
                directiveListViewer.Dock = DockStyle.Top;
                directiveListViewer.Location = new Point(0,0);

                panel.Controls.Add(directiveListViewer);

                extendableRichContainer1.MainControl = panel;
            }
            directiveListViewer.SetItemsArray(baseDetailDirectiveArray);
            SetCaption();
        }

        #endregion

        #region void SetCaption()

        void SetCaption()
        {
            extendableRichContainer1.Caption = caption + " (" + (count == 0 ? "No items" : count.ToString()) + ")";
            //extendableRichContainer1.Extended = count > 0;
            this.Visible = count > 0;
        }

        #endregion

        #region public BaseDetailDirective[] GatherDirectives()

        /// <summary>
        /// Выборка всех подходящих директив
        /// </summary>
        /// <returns></returns>
        public BaseDetailDirective[] GatherDirectives()
        {
            List <DirectiveFilter> filters = new List<DirectiveFilter>();
            filters.Add(directiveSelectionFilter);
            filters.Add(discrepanciesFilter);
            if (additionalFilter != null) filters.AddRange(additionalFilter.Filters);
            if (directiveContainer != null)
            {
                DirectiveCollectionFilter filter = new DirectiveCollectionFilter(directiveContainer.AllDirectives, filters.ToArray());
                BaseDetailDirective[] directives = filter.GatherDirectives();
                count = directives.Length;
                return directives;
            }
            count = 0;
            return new BaseDetailDirective[0];
        }

        #endregion

        #region public override void Refresh()
        /*
        ///<summary>
        ///Forces the control to invalidate its client area and immediately redraw itself and any child controls.
        ///</summary>
        ///<filterpriority>1</filterpriority><PermissionSet><IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence" /><IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true" /></PermissionSet>
        public override void Refresh()
        {
            base.Refresh();
            ShowDirectives();
        }
        */
        #endregion

        #endregion

    }
}
