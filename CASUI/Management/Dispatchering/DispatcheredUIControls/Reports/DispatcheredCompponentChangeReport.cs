using System.Windows.Forms;
using CAS.UI.Interfaces;
using CASReports.Builders;
using CASReports.ReportTemplates;

namespace CAS.UI.Management.Dispatchering.DispatcheredUIControls.Reports
{
    /// <summary>
    /// Элемент управления для отображения отчета для агрегатов
    /// </summary>
    public partial class DispatcheredComponentChangeReport : UserControl ,IDisplayingEntity
    {
        #region Fields

        ComponentChangeReportBuilder reportBuilder;

        #endregion
        
        #region Constructors

        /// <summary>
        /// Создается элемент управления для отображения отчета для агрегатов
        /// </summary>
        protected DispatcheredComponentChangeReport()
        {
            InitializeComponent();
            Dock = DockStyle.Fill;
        }

        #region public DispatcheredBaseDetailLogBookReport(LifelengthIncrement[] lifelengthIncrements, BaseDetailLogBookReportBuilder builder) : this()

        /// <summary>
        /// Создается отчет по ВС
        /// </summary>
        /// <param name="builder"></param>
        public DispatcheredComponentChangeReport(ComponentChangeReportBuilder builder)
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
        public ComponentChangeReportBuilder ReportBuilder
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
            if (!(obj is DispatcheredDetailListReport))
                return false;
            return ((obj as DispatcheredComponentChangeReport).reportBuilder == reportBuilder);
                
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
