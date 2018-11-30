using System;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CASReports.Builders;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports
{
    public partial class DispatcheredEngineeringOrdersReport : UserControl, IDisplayingEntity

    {
        private readonly EngineeringOrdersReportBuilder builder;
        public DispatcheredEngineeringOrdersReport(EngineeringOrdersReportBuilder builder)
        {
            InitializeComponent();
            this.builder = builder;
            crystalReportViewer1.ReportSource = builder.GenerateReport();
            Dock = DockStyle.Fill;
        }


        public object ContainedData
        {
            get { return builder; }
            set {  }
        }

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredEngineeringOrdersReport)) return false;
            return builder.Equals(((DispatcheredEngineeringOrdersReport)obj).builder);
        }

        /// <summary>
        /// Method call after add to IDisplayerCollectionProxy
        /// </summary>
        public void OnInitCompletion(object sender)
        {
            if (InitComplition!= null)
                InitComplition(sender,new EventArgs());
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
        /// Метод меняюший состояние конторола [:|||:]
        /// </summary>
        /// <param name="isEnbaled">состояние</param>
        public void SetEnabled(bool isEnbaled)
        {
            
        }

        /// <summary>
        /// call after add to IDisplayerCollectionProxy 
        /// </summary>
        public event EventHandler InitComplition;
    }
}
