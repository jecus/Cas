using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.ReportFilters;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CASReports.Builders;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports
{
    /// <summary>
    /// Элемент управления для создания отчета по ВС
    /// </summary>
    public partial class DispatcheredAircraftGeneralDataReport : UserControl, IDisplayingEntity
    {

        #region Fields

        private AircraftGeneralDataReportBuilder reportBuilder;

        #endregion
        
        #region Constructors

        #region protected DispatcheredAircraftGeneralDataReport()

        /// <summary>
        /// Создается элемент управления для отображения отчета по ВС
        /// </summary>
        protected DispatcheredAircraftGeneralDataReport()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        #endregion
        
        #region public DispatcheredAircraftGeneralDataReport(LifelengthIncrement[] lifelengthIncrements, BaseDetailLogBookReportBuilder builder) : this()

        /// <summary>
        /// Создается элемент управления для отображения отчета по ВС
        /// </summary>
        public DispatcheredAircraftGeneralDataReport(Aircraft aircraft, AircraftGeneralDataReportBuilder builder, DateTime dateAsOf) : this()
        {
            Aircraft clonedAircraft;
            object objectClone = aircraft.CloneAsDateOf(dateAsOf);
            clonedAircraft = (Aircraft)objectClone;

            List<Engine> engines = new List<Engine>(clonedAircraft.Engines);
            engines.Sort(new EnginePositionSerialNumberComparerDesc());
            List<GearAssembly> gearAssemblies = new List<GearAssembly>(clonedAircraft.LandingGears);
            gearAssemblies.Sort(new LandingGearPositionSerialNumberComparer());

            reportBuilder = builder;
            reportBuilder.Aircraft = clonedAircraft;
            reportBuilder.SortedEngines = engines.ToArray();
            reportBuilder.SortedGearAssemblies = gearAssemblies.ToArray();
            crystalReportViewer1.ReportSource = reportBuilder.GenerateReport();
        }

        #endregion

        #endregion

        #region Properties

        #region public BaseDetailLogBookReportBuilder ReportBuilder

        /// <summary>
        /// Возвращает построитель отчета по ВС
        /// </summary>
        public AircraftGeneralDataReportBuilder ReportBuilder
        {
            get
            {
                return reportBuilder;
            }
            set
            {
                reportBuilder = value;
            }
        }

        #endregion

        #endregion
        
        #region IDisplayingEntity Members

        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return reportBuilder; }
            set {  }
        }

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            DispatcheredAircraftGeneralDataReport report = obj as DispatcheredAircraftGeneralDataReport;
            if (report == null)
                return false;
            if ((report.reportBuilder.Aircraft.SerialNumber == reportBuilder.Aircraft.SerialNumber) && (report.reportBuilder.DateAsOf == reportBuilder.DateAsOf))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            
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
