using System.Windows.Forms;
using CASReports.Builders;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports
{
    /// <summary>
    /// Класс, описывающий отображение отчета по рабочему пакету
    /// </summary>
    public partial class DispatcheredWorkPackageReport : UserControl, IDisplayingEntity
    {
        private readonly WorkPackageBuilder builder;

        /// <summary>
        /// Создается отображение отчета по рабочему пакету
        /// </summary>
        protected DispatcheredWorkPackageReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Создается отображение отчета по рабочему пакету
        /// </summary>
        public DispatcheredWorkPackageReport(WorkPackageBuilder builder)
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
            if (!(obj is DispatcheredWorkPackageReport))
            {
                return false;
            }
            return ((obj as DispatcheredWorkPackageReport).builder.WorkPackage == builder.WorkPackage);
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