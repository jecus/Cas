using System.Windows.Forms;
using LTR.Core;
using LTR.Core.Types.Aircrafts.Parts;
using LTR.UI.Interfaces;
using LTRReports;

namespace LTR.UI.Management.Dispatchering.DispatcheredUIControls.Reports
{
    public partial class DispatcheredComponentStatusReport : UserControl ,IDisplayingEntity
    {
        #region Fields

        ComponentStatusReportBuilder reportBuilder;

        #endregion
        
        #region Constructors

        /// <summary>
        /// Создается элемент управления для отображения отчета для агрегатов
        /// </summary>
        protected DispatcheredComponentStatusReport()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        #region public DispatcheredBaseDetailLogBookReport(LifelengthIncrement[] lifelengthIncrements, BaseDetailLogBookReportBuilder builder) : this()

        /// <summary>
        /// Создается отчет по ВС
        /// </summary>
        /// <param name="builder"></param>
        public DispatcheredComponentStatusReport(ComponentStatusReportBuilder builder)
            : this()
        {
            reportBuilder = builder;
            crystalReportViewer1.ReportSource = reportBuilder.GenerateReport();
        }

        #endregion


        #endregion

        #region Properties

        #region public BaseDetailLogBookReportBuilder ReportBuilder

        /// <summary>
        /// Построитель отчетов для компонентов возудшного судна
        /// </summary>
        public ComponentStatusReportBuilder ReportBuilder
        {
            get
            {
                return reportBuilder;
            }
            set
            {
                reportBuilder = value;
            }
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
            set {  }
        }

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is DispatcheredComponentStatusReport))
                return false;
            return ((obj as DispatcheredComponentStatusReport).reportBuilder == reportBuilder);
                
        }

        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            
        }

        #endregion
    }
}
