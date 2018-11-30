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
    public partial class DispatcheredComponentStatusControl : ComponentStatusControl, IDisplayingEntity
    {

        #region Fields

        private readonly IDetailContainer detailContainer;
        private readonly DetailCollectionFilter initialFilter;

        #endregion

        #region Constructors

        #region public DispatcheredComponentStatusControl()

        /// <summary>
        /// Отображение Component Ststus - списка агрегатов
        /// </summary>
        public DispatcheredComponentStatusControl()
        {
        }

        #endregion

        #region public DispatcheredComponentStatusControl(Aircraft currentAircraft) : this(currentAircraft, new DetailCollectionFilter(new DetailFilter[1] { new AllDetailFilter() }),new DetailListReportBuilder())

        /// <summary>
        /// Создается отображение Component Ststus - списка агрегатов для ВС
        /// </summary>
        /// <param name="currentAircraft"></param>
        public DispatcheredComponentStatusControl(Aircraft currentAircraft) : this(currentAircraft, new DetailCollectionFilter(new DetailFilter[1] { new AllDetailFilter() }),new DetailListReportBuilder())
        {
        }

        #endregion

        #region public DispatcheredComponentStatusControl(Aircraft currentAircraft, DetailCollectionFilter initialFilter, DetailListReportBuilder reportBuilder) : base(currentAircraft, initialFilter)

        /// <summary>
        /// Создается отображение Component Ststus - списка агрегатов для ВС
        /// </summary>
        /// <param name="currentAircraft"></param>
        /// <param name="initialFilter"></param>
        /// <param name="reportBuilder"></param>
        public DispatcheredComponentStatusControl(Aircraft currentAircraft, DetailCollectionFilter initialFilter, DetailListReportBuilder reportBuilder) : base(currentAircraft, initialFilter)
        {
            detailContainer = currentAircraft;
            this.initialFilter = initialFilter;
            ReportBuilder = reportBuilder;
            Dock = DockStyle.Fill;
         
        }

        #endregion

        #region public DispatcheredComponentStatusControl(BaseDetail currentBaseDetail, DetailCollectionFilter initialFilter, DetailListReportBuilder reportBuilder) : base(currentBaseDetail, initialFilter)

        /// <summary>
        /// Создается отображение Component Ststus - списка агрегатов для ВС
        /// </summary>
        /// <param name="currentBaseDetail"></param>
        /// <param name="initialFilter"></param>
        /// <param name="reportBuilder"></param>
        public DispatcheredComponentStatusControl(BaseDetail currentBaseDetail, DetailCollectionFilter initialFilter, DetailListReportBuilder reportBuilder) : base(currentBaseDetail, initialFilter)
        {
            detailContainer = currentBaseDetail;
            this.initialFilter = initialFilter;
            ReportBuilder = reportBuilder;
            Dock = DockStyle.Fill;
        }

        #endregion

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
            if (!(obj is DispatcheredComponentStatusControl)) return false;
            if (!(obj.ContainedData is Aircraft)) return false;
            DispatcheredComponentStatusControl dispatcheredComponentStatusControl = obj as DispatcheredComponentStatusControl;

            return detailContainer == dispatcheredComponentStatusControl.detailContainer
                   && initialFilter.Equals(dispatcheredComponentStatusControl.initialFilter)
                   && AdditionalFilter.Equals(dispatcheredComponentStatusControl.AdditionalFilter);
            
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
