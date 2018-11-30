using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Directives;
using CAS.UI.UIControls.Auxiliary;
using CASReports.Builders;
using CAS.Core;
using CAS.Core.Core.Interfaces;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.DirectivesControls;
using Controls.AvMultitabControl.Auxiliary;
using Controls.AvMultitabControl;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.DirectiveControls
{
    /// <summary>
    /// Класс, описывающий отображение директив заданного базового агрегата
    /// </summary>
    [ToolboxItem(false)]
    public abstract class DispatcheredDirectivesView : UserControl, IDisplayingEntity
    {
        
        #region Fields

        private readonly DirectiveCollectionFilter additionalFilter;
        private CoreType currentItem;
        DirectiveListScreen screen = null;
        private DispatcheredMultitabControl dispatcheredMultitabControl;

        #endregion

        #region Constructors

        #region protected DispatcheredDirectivesView()

        /// <summary>
        /// Создается элемент - отображение директив
        /// </summary>
        protected DispatcheredDirectivesView()
        {
        }

        #endregion

        #region public DispatcheredDirectivesView(BaseDetail currentItem) : this(currentItem as IDirectiveContainer, null)

        /// <summary>
        /// Создается элемент - отображение директив заданного базового агрегата
        /// </summary>
        public DispatcheredDirectivesView(BaseDetail currentItem) : this(currentItem as IDirectiveContainer, null)
        {
            this.currentItem = currentItem;
        }

        #endregion

        #region public DispatcheredDirectivesView(Aircraft currentItem, DirectiveCollectionFilter additionalFilter) : this(currentItem as IDirectiveContainer, additionalFilter)

        /// <summary>
        /// Создается элемент - отображение директив заданного ВС
        /// </summary>
        /// <param name="currentItem"></param>
        /// <param name="additionalFilter">Дополнительный фильтр</param>
        protected DispatcheredDirectivesView(Aircraft currentItem, DirectiveCollectionFilter additionalFilter) : this(currentItem as IDirectiveContainer, additionalFilter)
        {
            this.currentItem = currentItem;
        }

        #endregion

        #region protected DispatcheredDirectivesView(IDirectiveContainer currentItem, DirectiveCollectionFilter additionalFilter)

        /// <summary>
        /// Создается элемент - отображение директив заданного ВС
        /// </summary>
        /// <param name="currentItem"></param>
        /// <param name="additionalFilter">Дополнительный фильтр</param>
        protected DispatcheredDirectivesView(IDirectiveContainer currentItem, DirectiveCollectionFilter additionalFilter)
        {
            this.additionalFilter = additionalFilter;
            Initialize(currentItem);
            InitComplition += DispatcheredDirectivesView_InitComplition;
        }

        #endregion

        #endregion

        #region Properties

        #region public abstract string ReportTitileText

        /// <summary>
        /// Текст заголовка отчета
        /// </summary>
        public abstract string ReportTitileText
        {
            get;
        }

        #endregion

        #region public abstract SDList<BaseDetailDirective> DirectiveListView

        /// <summary>
        /// SDList для директив
        /// </summary>
        public abstract SDList<BaseDetailDirective> DirectiveListView
        { get;
        }

        #endregion

        #region public abstract DirectiveType DirectiveDefaultType

        /// <summary>
        /// Тип директивы по умолчанию
        /// </summary>
        public abstract DirectiveType DirectiveDefaultType
        { get;
        }

        #endregion
        
        #region public object ContainedData

        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return currentItem; }
            set
            {
                if (value is BaseDetail)
                    currentItem = value as BaseDetail;
                if (value is Aircraft)
                    currentItem = value as Aircraft;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region protected void Initialize(IDirectiveContainer _currentItem)

        protected void Initialize(IDirectiveContainer _currentItem)
        {
            DirectiveCollectionFilter filter = new DirectiveCollectionFilter(_currentItem.ContainedDirectives, GetCollectionFilters());

            if (_currentItem is Aircraft)
            {
                currentItem = (Aircraft)_currentItem;
                screen = new DirectiveListScreen((Aircraft)_currentItem, filter, additionalFilter, DirectiveDefaultType, ReportTitileText, DirectiveListView);
            }
            if (_currentItem is BaseDetail)
            {
                currentItem = (BaseDetail)_currentItem;
                screen = new DirectiveListScreen((BaseDetail)_currentItem, filter, DirectiveDefaultType, ReportTitileText, DirectiveListView);
            }
            screen.CurrentDirectiveType = DirectiveDefaultType;
            if (screen != null)
            {
                screen.ReportBuilder = CreateReportBuilder();
                screen.ReportText = ReportTitileText;
                screen.Dock = DockStyle.Fill;
                Controls.Add(screen);
                Dock = DockStyle.Fill;
            }

            screen.BackgroundWorkStart += control_BackgroundWorkStart;
            screen.BackgroundWorkEnd += control_BackgroundWorkEnd;

        }


        #endregion
        
        #region protected abstract DirectiveListReportBuilder CreateReportBuilder();

        /// <summary>
        /// Создает отчет по директивам
        /// </summary>
        protected abstract DirectiveListReportBuilder CreateReportBuilder();
        #endregion

        #region protected abstract DirectiveFilter[] GetCollectionFilters()

        /// <summary>
        /// Собирается коллекция фильтров для отображения
        /// </summary>
        /// <returns></returns>
        protected abstract DirectiveFilter[] GetCollectionFilters();

        #endregion

        #region public bool ContainedDataEquals(IDisplayingEntity obj)

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            //if (!IsSameType(obj)) return false;
            if (!(obj is DispatcheredDirectivesView)) return false;
            if (obj.ContainedData as CoreType == null) return false;
            if (currentItem == null) return false;
            DispatcheredDirectivesView compared = (DispatcheredDirectivesView) obj;
            return
                ((CoreType) obj.ContainedData).ID == currentItem.ID &&
                screen.AdditionalFilter.Equals(compared.screen.AdditionalFilter)
                && screen.ViewFilter.Equals(compared.screen.ViewFilter);
        }

        #endregion

        #region protected abstract bool IsSameType(IDisplayingEntity obj)

        /// <summary>
        /// Тот же тип у объекта что у данного класса или нет
        /// </summary>
        /// <param name="obj">Проверяемый объект</param>
        /// <returns></returns>
        protected abstract bool IsSameType(IDisplayingEntity obj);

        #endregion

        #region public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)

        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            screen.CloseFilter();
        }

        #endregion

        #region public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)

        /// <summary>
        /// Действия, происходящие при деактивации вкладки, содержащей данную сущность
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
        {
            
        }


        #endregion

        #region public void SetEnabled(bool isEnbaled)

        public void SetEnabled(bool isEnbaled)
        {
            screen.SetPageEnable(isEnbaled);
        }

        #endregion

        #region public void OnInitCompletion(object sender)

        /// <summary>
        /// Method call after add to IDisplayerCollectionProxy
        /// </summary>
        /// <returns></returns>
        public void OnInitCompletion(object sender)
        {
            if (InitComplition != null)
                InitComplition(sender, new EventArgs());

        }

        #endregion

        #region public event EventHandler InitComplition;

        /// <summary>
        /// call after add to IDisplayerCollectionProxy 
        /// </summary>
        public event EventHandler InitComplition;

        #endregion

        #region private void DispatcheredDirectivesView_InitComplition(object sender, EventArgs e)

        private void DispatcheredDirectivesView_InitComplition(object sender, EventArgs e)
        {
            dispatcheredMultitabControl = (DispatcheredMultitabControl)sender;
            ((AvMultitabControl)sender).Selected += DirectiveListControl_Selected;
            ((DispatcheredMultitabControl)sender).Closed += DirectiveListContol_Closed;
        }

        #endregion

        #region private void DirectiveListContol_Closed(object sender, AvMultitabControlEventArgs e)

        private void DirectiveListContol_Closed(object sender, AvMultitabControlEventArgs e)
        {
            if (e.TabPage == Parent as DispatcheredTabPage)
            {
                screen.UnHookDirectives();
                screen.BackgroundWorkStart -= control_BackgroundWorkStart;
                screen.BackgroundWorkEnd -= control_BackgroundWorkEnd;
                if (currentItem is BaseDetail)
                {
                    BaseDetail baseDetail = (BaseDetail) currentItem;
                    screen.UnHookDirectiveCollection(baseDetail);
                    screen.UnHookWorkPackageEvents(baseDetail.ParentAircraft);
                }
                if (currentItem is Aircraft)
                {
                    Aircraft aircraft = (Aircraft) currentItem;
                    screen.UnHookDirectiveCollection(aircraft);
                    screen.UnHookWorkPackageEvents(aircraft);
                }
            }
        }

        #endregion

        #region private void DirectiveListScreen_Selected(object sender, AvMultitabControlEventArgs e)

        private void DirectiveListControl_Selected(object sender, AvMultitabControlEventArgs e)
        {
            screen.ItemsListView.Focus();
        }

        #endregion

        #region private void control_BackgroundWorkStart(object sender, EventArgs e)

        private void control_BackgroundWorkStart(object sender, EventArgs e)
        {
            dispatcheredMultitabControl.SetEnabledToAllEntityes(false);
        }

        #endregion

        #region void control_BackgroundWorkEnd(object sender, EventArgs e)

        void control_BackgroundWorkEnd(object sender, EventArgs e)
        {
            dispatcheredMultitabControl.SetEnabledToAllEntityes(true);
        }

        #endregion

        #endregion

    }
}