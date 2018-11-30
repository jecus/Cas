using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Core.Interfaces;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.DetailsControls;
using CASReports.Builders;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.DetailsControl
{
    /// <summary>
    /// Отображение Component Ststus - списка агрегатов
    /// </summary>
    [ToolboxItem(false)]
    public class DispatcheredComponentStatusScreen : DetailListScreen, IDisplayingEntity
    {

        #region Fields

        private readonly IDetailContainer detailContainer;
        private readonly DetailCollectionFilter initialFilter;

        #endregion

        #region Constructors

        #region public DispatcheredComponentStatusScreen()

        /// <summary>
        /// Отображение Component Ststus - списка агрегатов
        /// </summary>
        public DispatcheredComponentStatusScreen()
        {
        }

        #endregion

        #region public DispatcheredComponentStatusScreen(Aircraft currentAircraft) : this(currentAircraft, new DetailCollectionFilter(new DetailFilter[1] { new AllDetailFilter() }), new DetailCollectionFilter(new DetailFilter[1] { new AllDetailFilter() }), new DetailListReportBuilder())

        /// <summary>
        /// Создается отображение Component Ststus - списка агрегатов для ВС
        /// </summary>
        /// <param name="currentAircraft"></param>
        public DispatcheredComponentStatusScreen(Aircraft currentAircraft) : this(currentAircraft, new DetailCollectionFilter(new DetailFilter[1] { new AllDetailFilter() }), new DetailCollectionFilter(new DetailFilter[1] { new AllDetailFilter() }), new DetailListReportBuilder())
        {
        }

        #endregion

/*        #region public DispatcheredComponentStatusScreen(Aircraft currentAircraft, DetailCollectionFilter additionlaFilter) : this(currentAircraft, new DetailCollectionFilter(new DetailFilter[1] { new AllDetailFilter() }), additionlaFilter, new DetailListReportBuilder())

        /// <summary>
        /// Создается отображение Component Ststus - списка агрегатов для ВС
        /// </summary>
        /// <param name="currentAircraft"></param>
        /// <param name="additionlaFilter"></param>
        public DispatcheredComponentStatusScreen(Aircraft currentAircraft, DetailCollectionFilter additionlaFilter) : this(currentAircraft, new DetailCollectionFilter(new DetailFilter[1] { new AllDetailFilter() }), additionlaFilter, new DetailListReportBuilder())
        {
        }

        #endregion*/

        #region public DispatcheredComponentStatusScreen(Aircraft currentAircraft, DetailCollectionFilter additionlaFilter) : this(currentAircraft, new DetailCollectionFilter(new DetailFilter[1] { new AllDetailFilter() }), additionlaFilter, new DetailListReportBuilder())

        /// <summary>
        /// Создается отображение Component Ststus - списка агрегатов для ВС
        /// </summary>
        /// <param name="currentAircraft"></param>
        /// <param name="additionlaFilter"></param>
        public DispatcheredComponentStatusScreen(Aircraft currentAircraft, DetailCollectionFilter additionlaFilter, DetailListReportBuilder builder) : this(currentAircraft, new DetailCollectionFilter(new DetailFilter[1] { new AllDetailFilter() }), additionlaFilter, builder)
        {
        }

        #endregion

        #region public DispatcheredComponentStatusScreen(Aircraft currentAircraft, DetailCollectionFilter initialFilter, DetailCollectionFilter additionlaFilter) : base(currentAircraft, initialFilter, additionlaFilter)

        /// <summary>
        /// Создается отображение Component Ststus - списка агрегатов для ВС
        /// </summary>
        /// <param name="currentAircraft"></param>
        /// <param name="initialFilter"></param>
        /// <param name="additionlaFilter"></param>
        /// <param name="builder"></param>
        public DispatcheredComponentStatusScreen(Aircraft currentAircraft, DetailCollectionFilter initialFilter, DetailCollectionFilter additionlaFilter, DetailListReportBuilder builder) : base(currentAircraft, initialFilter, additionlaFilter)
        {
            detailContainer = currentAircraft;
            this.initialFilter = initialFilter;
            ReportBuilder = builder;
            Dock = DockStyle.Fill;

        }

        #endregion

        #region public DispatcheredComponentStatusScreen(BaseDetail currentBaseDetail, DetailCollectionFilter initialFilter, DetailListReportBuilder reportBuilder) : base(currentBaseDetail, initialFilter)

        /// <summary>
        /// Создается отображение Component Ststus - списка агрегатов для ВС
        /// </summary>
        /// <param name="currentBaseDetail"></param>
        /// <param name="initialFilter"></param>
        /// <param name="reportBuilder"></param>
        public DispatcheredComponentStatusScreen(BaseDetail currentBaseDetail, DetailCollectionFilter initialFilter, DetailListReportBuilder reportBuilder) : base(currentBaseDetail, initialFilter)
        {
            detailContainer = currentBaseDetail;
            this.initialFilter = initialFilter;
            ReportBuilder = reportBuilder;
            
            Dock = DockStyle.Fill;
        }

        #endregion

        /// <summary>
        /// Method call after add to IDisplayerCollectionProxy
        /// </summary>

        /// <returns></returns>
        public void OnInitCompletion(object sender)
        {
            if (InitComplition != null)
                InitComplition(sender, new EventArgs());

        }

        #region public void SetEnabled(bool isEnbaled)

        public void SetEnabled(bool isEnbaled)
        {
            SetPageEnable(isEnbaled);
        }

        #endregion

        /// <summary>
        /// call after add to IDisplayerCollectionProxy 
        /// </summary>
        public event EventHandler InitComplition;

        #endregion

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
            if (!(obj is DispatcheredComponentStatusScreen)) return false;
            if (!(obj.ContainedData is Aircraft)) return false;
            DispatcheredComponentStatusScreen dispatcheredComponentStatusScreen = obj as DispatcheredComponentStatusScreen;

            return detailContainer == dispatcheredComponentStatusScreen.detailContainer
                   && initialFilter.Equals(dispatcheredComponentStatusScreen.initialFilter)
                   && AdditionalFilter.Equals(dispatcheredComponentStatusScreen.AdditionalFilter);
            
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

        #endregion
    }
}
