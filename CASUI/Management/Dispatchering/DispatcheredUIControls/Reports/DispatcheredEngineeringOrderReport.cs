using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CASReports.Builders;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports
{
    public partial class DispatcheredEngineeringOrderReport : UserControl, IDisplayingEntity

    {
        private EngineeringOrderReportBuilder builder;
        public DispatcheredEngineeringOrderReport(EngineeringOrderReportBuilder builder)
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
            if (!(obj is DispatcheredEngineeringOrderReport)) return false;
            return builder.Equals(((DispatcheredEngineeringOrderReport) obj).builder);
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
