using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CASReports.Builders;
using CrystalDecisions.Windows.Forms;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports
{
    /// <summary>
    /// Элемент управления для отображения отчета по Should be on stock
    /// </summary>
    public partial class DispatcheredShouldBeOnStockReport : UserControl, IDisplayingEntity
    {

        #region Fields

        private ShouldBeOnStockBuilder reportBuilder;

        #endregion

        #region Constructors

        #region public DispatcheredShouldBeOnStockReport()

        /// <summary>
        /// Создается элемент управления для отображения отчета по Should be on stock
        /// </summary>
        public DispatcheredShouldBeOnStockReport()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        #endregion

        #region public DispatcheredShouldBeOnStockReport(ShouldBeOnStockBuilder builder): this()

        /// <summary>
        /// Создается элемент управления для отображения отчета по Should be on stock
        /// </summary>
        /// <param name="builder"></param>
        public DispatcheredShouldBeOnStockReport(ShouldBeOnStockBuilder builder) : this()
        {
            reportBuilder = builder;
            crystalReportViewer2.ReportSource = reportBuilder.GenerateReport();
        }

        #endregion

        #endregion

        #region Properties

        #region public ShouldBeOnStockBuilder ReportBuilder

        /// <summary>
        /// Построитель отчета по Should Be On Stock
        /// </summary>
        public ShouldBeOnStockBuilder ReportBuilder
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
            if (!(obj is DispatcheredShouldBeOnStockReport))
                return false;
            return ((obj as DispatcheredShouldBeOnStockReport).reportBuilder == reportBuilder);
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