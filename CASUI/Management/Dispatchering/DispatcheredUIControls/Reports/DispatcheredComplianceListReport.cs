using System;
using System.Windows.Forms;
using CASReports.Builders;
using CAS.UI.Interfaces;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports
{
    /// <summary>
    /// Элемент управления для создания отчета технических записей
    /// </summary>
    public partial class DispatcheredComplianceListReport : UserControl, IDisplayingEntity
    {

        #region Fields

        readonly ComplianceListBuilder reportBuilder;

        #endregion

        #region Constructors

        #region public DispatcheredComplianceListReport()

        /// <summary>
        /// Создает элемент управления для создания отчета технических записей
        /// </summary>
        public DispatcheredComplianceListReport()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        #endregion

        #region public DispatcheredComplianceListReport(string reportName, string dateAsOf, ComplianceListBuilder builder) : this()

        /// <summary>
        /// Создается элемент управления для отображения отчета технических записей
        /// </summary>
        public DispatcheredComplianceListReport(string reportName, string dateAsOf, ComplianceListBuilder builder) : this()
        {
            reportBuilder = builder;
            reportBuilder.ReportName = reportName;
            reportBuilder.DateAsOf = dateAsOf;
            crystalReportViewer1.ReportSource = reportBuilder.GenerateReport();
        }

        #endregion

        #endregion

        #region Methods

        #region IDisplayingEntity Members

        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return reportBuilder; }
            set { }
        }

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            DispatcheredComplianceListReport report = obj as DispatcheredComplianceListReport;
            if (report == null)
                return false;
            if ((report.reportBuilder.ReportName == reportBuilder.ReportName) && (report.reportBuilder.DateAsOf == reportBuilder.DateAsOf))
                return true;
            else
                return false;
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

        }

        /// <summary>
        /// Действия, происходящие при деактивации вкладки, содержащей данную сущность
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerDeselecting(DisplayerCancelEventArgs arguments)
        {
            
        }

        /// <summary>
        /// call after add to IDisplayerCollectionProxy 
        /// </summary>
        public event EventHandler InitComplition;
        #endregion

        #endregion

    }
}
