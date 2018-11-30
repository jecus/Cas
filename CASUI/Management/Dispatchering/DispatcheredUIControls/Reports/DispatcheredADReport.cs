using System;
using System.Windows.Forms;
using CAS.Core.Types.Directives;
using CASReports.Builders;
using CAS.UI.Interfaces;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports
{
    /// <summary>
    /// 
    /// </summary>
    public partial class DispatcheredADReport : UserControl, IDisplayingEntity
    {
        DirectiveListReportBuilder reportBuilder = new DirectiveListReportBuilder();

        /// <summary>
        /// 
        /// </summary>
        public DispatcheredADReport()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directives"></param>
        public DispatcheredADReport(BaseDetailDirective[] directives):this()
        {
            reportBuilder.AddDirectives(directives);
            crystalReportViewer1.ReportSource = reportBuilder.GenerateReport();
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
            if (!(obj is DispatcheredADReport))
                return false;
            return ((obj as DispatcheredADReport).reportBuilder == reportBuilder);
                
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
        #endregion
    }
}
