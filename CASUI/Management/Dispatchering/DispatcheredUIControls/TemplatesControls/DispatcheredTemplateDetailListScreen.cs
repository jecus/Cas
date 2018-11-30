using System;
using System.Windows.Forms;
using CAS.Core.Core.Interfaces;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts.Templates;
using CAS.Core.Types.ReportFilters.Templates;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.TemplatesControls;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.TemplatesControls
{
    /// <summary>
    /// Элемент управления для отображения списка шаблонных агрегатов
    /// </summary>
    public class DispatcheredTemplateDetailListScreen : TemplateDetailListScreen, IDisplayingEntity
    {
        private readonly ITemplateDetailContainer detailContainer;
        private readonly TemplateDetailCollectionFilter initialFilter;

        /// <summary>
        /// Создается отображение Component Ststus - списка шаблонных агрегатов для ВС
        /// </summary>
        /// <param name="currentAircraft"></param>
        public DispatcheredTemplateDetailListScreen(TemplateAircraft currentAircraft) : this(currentAircraft, new TemplateDetailCollectionFilter(new TemplateDetailFilter[1] { new TemplateAllDetailFilter() }))
        {
            
        }

        /// <summary>
        /// Создается отображение Component Ststus - списка шаблонных агрегатов для ВС
        /// </summary>
        /// <param name="currentAircraft"></param>
        /// <param name="initialFilter"></param>
        public DispatcheredTemplateDetailListScreen(TemplateAircraft currentAircraft, TemplateDetailCollectionFilter initialFilter) : base(currentAircraft, initialFilter)
        {
            detailContainer = currentAircraft;
            this.initialFilter = initialFilter;
            Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Создается отображение Component Ststus - списка шаблонных агрегатов для ВС
        /// </summary>
        /// <param name="currentAircraft"></param>
        /// <param name="initialFilter"></param>
        /// <param name="additionalFilter"></param>
        public DispatcheredTemplateDetailListScreen(TemplateAircraft currentAircraft, TemplateDetailCollectionFilter initialFilter, TemplateDetailCollectionFilter additionalFilter) : base(currentAircraft, initialFilter, additionalFilter)
        {
            detailContainer = currentAircraft;
            this.initialFilter = initialFilter;
            Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Создается отображение Component Ststus - списка шаблонных агрегатов для ВС
        /// </summary>
        /// <param name="currentBaseDetail"></param>
        /// <param name="initialFilter"></param>
        public DispatcheredTemplateDetailListScreen(TemplateBaseDetail currentBaseDetail, TemplateDetailCollectionFilter initialFilter) : base(currentBaseDetail, initialFilter)
        {
            detailContainer = currentBaseDetail;
            this.initialFilter = initialFilter;
            Dock = DockStyle.Fill;
        }


        #region IDisplayingEntity Members

        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return detailContainer; }
            set {  }
        }

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredTemplateDetailListScreen)) return false;
            if (!(obj.ContainedData is TemplateAircraft)) return false;
            DispatcheredTemplateDetailListScreen dispatcheredTemplateDetailListScreen = obj as DispatcheredTemplateDetailListScreen;

            return detailContainer == dispatcheredTemplateDetailListScreen.detailContainer
                   //&& initialFilter.Equals(dispatcheredTemplateDetailListScreen.initialFilter)
                   && AdditionalFilter.Equals(dispatcheredTemplateDetailListScreen.AdditionalFilter);
            
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

        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            CloseFilter();
        }

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
    }
}
