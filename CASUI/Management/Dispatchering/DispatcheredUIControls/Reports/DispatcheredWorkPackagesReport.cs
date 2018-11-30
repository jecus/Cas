using System;
using System.Windows.Forms;
using CAS.Core.Types.Directives;
using CAS.UI.Interfaces;
using CASReports.Builders;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports
{
    /// <summary>
    /// Элемент управления дл яотображения отчета по <see cref="ModificationItem"/> ВС
    /// </summary>
    public partial class DispatcheredWorkPackagesReport : UserControl, IDisplayingEntity
    {
        #region Fields

        private readonly WorkPackagesReportBuilder builder;

        #endregion

        #region Constructor

        /// <summary>
        /// Создает элемент управления дл яотображения отчета по <see cref="ModificationItem"/> ВС
        /// </summary>
        /// <param name="builder"></param>
        public DispatcheredWorkPackagesReport(WorkPackagesReportBuilder builder)
        {
            InitializeComponent();
            this.builder = builder;
            crystalReportViewer1.ReportSource = builder.GenerateReport();
            Dock = DockStyle.Fill;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return builder; }
            set {  }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredWorkPackagesReport)) 
                return false;
            return builder.Equals(((DispatcheredWorkPackagesReport)obj).builder);
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

        #endregion

    }
}
