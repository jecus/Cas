using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CASReports.Builders;
using CrystalDecisions.Windows.Forms;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports
{
    public partial class DispatcheredStoreReport : UserControl, IDisplayingEntity
    {

        #region Fields

        private StoreBuilder reportBuilder;

        #endregion

        #region Constructors

        #region public DispatcheredStoreReport()

        /// <summary>
        /// Создается элемент управления для отображения отчета по складу
        /// </summary>
        public DispatcheredStoreReport()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        #endregion

        #region public DispatcheredStoreReport(StoreBuilder builder): this()

        /// <summary>
        /// Создается элемент управления для отображения отчета по складу
        /// </summary>
        /// <param name="builder"></param>
        public DispatcheredStoreReport(StoreBuilder builder) : this()
        {
            reportBuilder = builder;
            crystalReportViewer2.ReportSource = reportBuilder.GenerateReport();
        }

        #endregion

        #endregion

        #region Properties

        #region public StoreBuilder ReportBuilder

        /// <summary>
        /// Построитель отчета по складу
        /// </summary>
        public StoreBuilder ReportBuilder
        {
            get { return reportBuilder; }
            set { reportBuilder = value; }
        }

        #endregion

        #endregion

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
            if (!(obj is DispatcheredStoreReport))
                return false;
            return ((obj as DispatcheredStoreReport).reportBuilder == reportBuilder);
        }

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

        public event EventHandler InitComplition;

       
        #endregion

        
    }
}