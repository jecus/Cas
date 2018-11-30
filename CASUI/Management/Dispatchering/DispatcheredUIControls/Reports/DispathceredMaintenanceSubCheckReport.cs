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
    /// <summary>
    /// Класс, описывающий отображение отчетов Maintenance Status
    /// </summary>
    public partial class DispatcheredMaintenanceSubCheckReport : UserControl, IDisplayingEntity
    {
        private readonly MaintenanceSubCheckReportBuilder builder;

        /// <summary>
        /// Создается отображение отчетов Maintenance Status
        /// </summary>
        protected DispatcheredMaintenanceSubCheckReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Создается отображение отчетов Maintenance Status
        /// </summary>
        public DispatcheredMaintenanceSubCheckReport(MaintenanceSubCheckReportBuilder builder)
            : this()
        {
            this.builder = builder;
            crystalReportViewer1.ReportSource = builder.GenerateReport();
            Dock = DockStyle.Fill;
        }

        #region IDisplayingEntity Members

        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return builder; }
            set { }
        }

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredMaintenanceSubCheckReport))
            {
                return false;
            }
            return (obj as DispatcheredMaintenanceSubCheckReport).builder.SubCheck ==  builder.SubCheck;
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
        /// Method call after add to IDisplayerCollectionProxy
        /// </summary>

        /// <returns></returns>
        public void OnInitCompletion(object sender)
        {
            if (InitComplition != null)
                InitComplition(sender, new EventArgs());

        }

        /// <summary>
        /// call after add to IDisplayerCollectionProxy 
        /// </summary>
        public event EventHandler InitComplition;

        #endregion
    }
}
