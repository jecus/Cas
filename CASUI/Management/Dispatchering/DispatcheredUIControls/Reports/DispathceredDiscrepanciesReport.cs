using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.Core.Types.Directives;
using CASReports.Builders;
using CAS.Core.Core.Interfaces;
using CAS.Core.ProjectTerms;
using CAS.UI.Interfaces;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DispathceredDiscrepanciesReport : UserControl, IDisplayingEntity
    {
        DiscrepanciesReportBuilder reportBuilder;
        /// <summary>
        /// 
        /// </summary>
        protected DispathceredDiscrepanciesReport()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        /// <summary>
        /// 
        /// </summary>
        public DispathceredDiscrepanciesReport(string reportName, DateTime dateAsOf, string operatorName, Image logoTypeWhite, string monthlyUtilizationTSN, string monthlyUtilizationCSN, IMaintainable[] itemArray):this()
        {
            reportBuilder = new DiscrepanciesReportBuilder(reportName, dateAsOf.ToString(new TermsProvider()["DateFormat"].ToString()), operatorName, logoTypeWhite, monthlyUtilizationTSN, monthlyUtilizationCSN, itemArray);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="discrepancies"></param>
        public void AddComponentDiscrepancies(string caption, Detail[] discrepancies)
        {
            //reportBuilder.DetailDiscrepancies.AddRange(discrepancies);
            //reportBuilder.DetailDiscrepanciesTitle = caption;
            //reportBuilder.DisplayDetailDiscrepancies = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="directives"></param>
        public void AddDirectiveDiscrepancies(string caption, BaseDetailDirective[] directives)
        {
            //reportBuilder.DisplayDirectiveDiscrepancies.Add(true);
            //reportBuilder.ContainerTitles.Add(caption);
            //reportBuilder.DirectiveDiscrepancies.Add(directives);
        }

        /// <summary>
        /// Отобразить отчет
        /// </summary>
        public void DisplayReport()
        {
            crystalReportViewer1.ReportSource = reportBuilder.CreateReport();
        }

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
            if (!(obj is DispathceredDiscrepanciesReport))
                return false;
            return (((DispathceredDiscrepanciesReport) obj).reportBuilder.Equals(reportBuilder));
            
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

        public void SetEnabled(bool isEnbaled)
        {
            
        }

        /// <summary>
        /// call after add to IDisplayerCollectionProxy 
        /// </summary>
        public event EventHandler InitComplition;

        public DiscrepanciesReportBuilder ReportBuilder
        {
            get { return reportBuilder; }
        }
    }
}
