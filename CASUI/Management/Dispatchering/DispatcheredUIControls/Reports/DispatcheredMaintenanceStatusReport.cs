using System.Windows.Forms;
using CASReports.Builders;
using CASReports.ReportTemplates;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports
{
    /// <summary>
    /// Класс, описывающий отображение отчетов Maintenance Status
    /// </summary>
    public partial class DispatcheredMaintenanceStatusReport : UserControl, IDisplayingEntity
    {
        private MaintenanceStatusReport report;
        private MaintenanceStatusReportBuilder builder;

        /// <summary>
        /// Создается отображение отчетов Maintenance Status
        /// </summary>
        protected DispatcheredMaintenanceStatusReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Создается отображение отчетов Maintenance Status
        /// </summary>
        /// <param name="report"></param>
        /// <param name="builder"></param>
        public DispatcheredMaintenanceStatusReport(MaintenanceStatusReport report, MaintenanceStatusReportBuilder builder):this()
        {
            this.report = report;
            this.builder = builder;
            crystalReportViewer1.ReportSource = report;
            Dock = DockStyle.Fill;
        }

        #region IDisplayingEntity Members

        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return report; }
            set { }
        }

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredMaintenanceStatusReport))
            {
                return false;
            }
            DispatcheredMaintenanceStatusReport objReport = (DispatcheredMaintenanceStatusReport)obj;
            return builder.Equals(objReport.builder);
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