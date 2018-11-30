using System;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CASReports.Builders;

namespace CAS.UI.UIControls.Auxiliary
{
    ///<summary>
    ///</summary>
    public partial class ReportScreen : UserControl, IDisplayingEntity
    {
        private AbstractReportBuilder _reportBuilder;

        #region Constructors
        ///<summary>
        ///</summary>
        private ReportScreen()
        {
            InitializeComponent();
        }

        ///<summary>
        ///</summary>
        public ReportScreen(AbstractReportBuilder reportBuilder) : this()
        {
            if(reportBuilder == null)return;
           
            _reportBuilder = reportBuilder;

            UpdateInformation();
        }

        #endregion

        #region private void UpdateInformation()
        private void UpdateInformation()
        {
            Dock = DockStyle.Fill;
            reportViewer.ReportSource = _reportBuilder.GenerateReport();
        }
        #endregion

        #region IDisplayingEntity Members

        #region public void DisposeScreen()

        public void DisposeScreen()
        {
            Dispose(true);
        }

        #endregion

        /// <summary>
        /// Represents data being displayed
        /// </summary>
        public object ContainedData
        {
            get { return _reportBuilder; }
            set { }
        }

        /// <summary>
        /// Checks whether represented data equals to corresponding data of object
        /// </summary>
        /// <param name="obj">Compared object</param>
        /// <returns></returns>
        public bool ContainedDataEquals(IDisplayingEntity obj)
        {
            if (!(obj is ReportScreen))
                return false;
            return ((obj as ReportScreen)._reportBuilder == _reportBuilder);

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

        #region  public event EventHandler<EntityCancelEventArgs> EntityRemoving
        /// <summary>
        /// Событие, оповещающее об удаленни содержимого (вкладку)
        /// </summary>
        public event EventHandler<EntityCancelEventArgs> EntityRemoving;

        #endregion

        #region public event EventHandler DisplayerRemoved
        /// <summary>
        /// Возникает после удаления содержимого
        /// </summary>
        public event EventHandler EntityRemoved;

        #endregion

        /// <summary>
        /// Вызывается событие удаления отображаемого объекта
        /// </summary>
        /// <param name="arguments"></param>
        public void OnDisplayerRemoving(DisplayerCancelEventArgs arguments)
        {
            if (EntityRemoving != null)
            {
                EntityCancelEventArgs eventArgs = new EntityCancelEventArgs(this);

                EntityRemoving(this, eventArgs);

                if (eventArgs.Cancel)
                    return;
            }

            if (!IsDisposed)
            {
                try
                {
                    DisposeScreen();
                }
                catch (Exception ex)
                {
                    Program.Provider.Logger.Log("Error in removed screen " + GetType(), ex);
                }
            }
        }

        #region public void OnDisplayerRemoved()
        /// <summary>
        /// Возбуждает событие после удаления отображаемого объекта
        /// </summary>
        public void OnDisplayerRemoved()
        {

        }

        #endregion

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
