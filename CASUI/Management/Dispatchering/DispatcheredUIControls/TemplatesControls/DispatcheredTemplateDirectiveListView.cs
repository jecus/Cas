using System;
using System.ComponentModel;
using System.Windows.Forms;
using Controls.AvMultitabControl;
using Controls.AvMultitabControl.Auxiliary;
using CAS.Core;
using CAS.Core.Core.Interfaces;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.Core.Types.Dictionaries;
using CAS.Core.Types.ReportFilters.Templates;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.TemplatesControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.TemplatesControls
{
    /// <summary>
    /// Класс, описывающий отображение шаблонных директив заданного базового агрегата
    /// </summary>
    [ToolboxItem(false)]
    public abstract class DispatcheredTemplateDirectiveListView : UserControl, IDisplayingEntity
    {

        #region Fields

        private CoreType currentItem;
        TemplateDirectiveListScreen control = null;

        #endregion

        #region Constructors

        #region protected DispatcheredTemplateDirectiveListView()

        /// <summary>
        /// Создается элемент - отображение шаблонных директив
        /// </summary>
        protected DispatcheredTemplateDirectiveListView()
        {
        }

        #endregion

        #region public DispatcheredTemplateDirectiveListView(TemplateBaseDetail currentItem) : this(currentItem as ITemplateDirectiveContainer)

        /// <summary>
        /// Создается элемент - отображение шаблонных директив заданного базового агрегата
        /// </summary>
        public DispatcheredTemplateDirectiveListView(TemplateBaseDetail currentItem) : this(currentItem as ITemplateDirectiveContainer)
        {
            this.currentItem = currentItem;
        }

        #endregion

        #region public DispatcheredTemplateDirectiveListView(TemplateAircraft currentItem) : this(currentItem as ITemplateDirectiveContainer)

        /// <summary>
        /// Создается элемент - отображение шаблонных директив заданного ВС
        /// </summary>
        /// <param name="currentItem"></param>
        public DispatcheredTemplateDirectiveListView(TemplateAircraft currentItem) : this(currentItem as ITemplateDirectiveContainer)
        {
            this.currentItem = currentItem;
        }

        #endregion

        #region protected DispatcheredTemplateDirectiveListView(ITemplateDirectiveContainer currentItem)

        /// <summary>
        /// Создается элемент - отображение шаблонных директив заданного ВС
        /// </summary>
        /// <param name="currentItem"></param>
        protected DispatcheredTemplateDirectiveListView(ITemplateDirectiveContainer currentItem)
        {
            Initialize(currentItem);
            this.InitComplition += DispatcheredDirectivesView_InitComplition; 
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
                if (value is TemplateBaseDetail)
                    currentItem = value as TemplateBaseDetail;
                if (value is TemplateAircraft)
                    currentItem = value as TemplateAircraft;
            }
        }

        #endregion

        #endregion

        #region Methods

        #region protected void Initialize(IDirectiveContainer currentItem)

        protected void Initialize(ITemplateDirectiveContainer currentItem)
        {
            TemplateDirectiveCollectionFilter filter = new TemplateDirectiveCollectionFilter(currentItem.ContainedDirectives, GetCollectionFilters());

            if (currentItem is TemplateAircraft)
            {
                this.currentItem = (TemplateAircraft)currentItem;
                control = new TemplateDirectiveListScreen((TemplateAircraft)currentItem, filter, ReportTitileText);
            }
            if (currentItem is TemplateBaseDetail)
            {
                this.currentItem = (TemplateBaseDetail)currentItem;
                control = new TemplateDirectiveListScreen((TemplateBaseDetail)currentItem, filter, ReportTitileText);
            }
            control.CurrentDirectiveType = DirectiveDefaultType;
            if (control != null)
            {
                control.ReportText = ReportTitileText;
                control.Dock = DockStyle.Fill;
                Controls.Add(control);
                Dock = DockStyle.Fill;
            }
        }

        #endregion
        
        #region protected abstract TemplateDirectiveFilter[] GetCollectionFilters();

        /// <summary>
        /// Собирается коллекция фильтров для отображения
        /// </summary>
        /// <returns></returns>
        protected abstract TemplateDirectiveFilter[] GetCollectionFilters();

        #endregion

        #region public bool ContainedDataEquals(IDisplayingEntity obj)

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredTemplateDirectiveListView)) return false;
            if (obj.ContainedData as CoreType == null) return false;
            if (currentItem == null) return false;
            DispatcheredTemplateDirectiveListView compared = (DispatcheredTemplateDirectiveListView)obj;
            return
                ((CoreType) obj.ContainedData).ID == currentItem.ID &&
                control.AdditionalFilter.Equals(compared.control.AdditionalFilter)
                && control.ViewFilter.Equals(compared.control.ViewFilter);
        }

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
            control.CloseFilter();
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

        public void SetEnabled(bool isEnbaled)
        {
            
        }

        /// <summary>
        /// call after add to IDisplayerCollectionProxy 
        /// </summary>
        public event EventHandler InitComplition;
        #endregion

        #region private void DispatcheredDirectivesView_InitComplition(object sender, EventArgs e)

        private void DispatcheredDirectivesView_InitComplition(object sender, EventArgs e)
        {
            ((AvMultitabControl)sender).Selected += DirectiveListControl_Selected;
            ((DispatcheredMultitabControl)sender).Closed += DispatcheredTemplateDirectiveListView_Closed;
        }

        #endregion

        #region private void DirectiveListControl_Selected(object sender, AvMultitabControlEventArgs e)

        private void DirectiveListControl_Selected(object sender, AvMultitabControlEventArgs e)
        {
            control.ItemsListView.Focus();
        }

        #endregion

        #region private void DispatcheredTemplateDirectiveListView_Closed(object sender, AvMultitabControlEventArgs e)

        private void DispatcheredTemplateDirectiveListView_Closed(object sender, AvMultitabControlEventArgs e)
        {
            if (e.TabPage == Parent as DispatcheredTabPage)
            {
                control.PerformEvents(false);
                //control.BackgroundWorkStart -= control_BackgroundWorkStart;
                //control.BackgroundWorkEnd -= control_BackgroundWorkEnd;
            }
        }

        #endregion

        #endregion
    }
}