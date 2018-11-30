using System.Windows.Forms;
using CAS.Core.Types.Aircrafts;
using CAS.Core.Types.Directives;
using CASReports.Builders;
using CAS.Core.Types.Aircrafts.Parts;
using CAS.UI.Interfaces;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DispatcheredDirectiveListReport : UserControl, IDisplayingEntity
    {
        private DirectiveListReportBuilder reportBuilder;
        private BaseDetailDirective[] directives;

        /// <summary>
        /// 
        /// </summary>
        protected DispatcheredDirectiveListReport()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Создается представление отчета для заданных директив
        /// </summary>
        /// <param name="directives"></param>
        /// <param name="builder"></param>
        public DispatcheredDirectiveListReport(BaseDetailDirective[] directives, DirectiveListReportBuilder builder):this()
        {
            this.directives = directives;
            reportBuilder = builder;
            reportBuilder.AddDirectives(directives);
            crystalReportViewer1.ReportSource = reportBuilder.GenerateReport();
        }

        /// <summary>
        /// Строитель отчетов директив
        /// </summary>
        public DirectiveListReportBuilder ReportBuilder
        {
            get { return reportBuilder; }
            set { reportBuilder = value; }
        }

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
            if (!(obj is DispatcheredDirectiveListReport))
                return false;
            //return ((DispatcheredDirectiveListReport)obj).reportBuilder == reportBuilder;
            return ((DispatcheredDirectiveListReport)obj).directives == directives;
                
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

        #endregion
    }
}
