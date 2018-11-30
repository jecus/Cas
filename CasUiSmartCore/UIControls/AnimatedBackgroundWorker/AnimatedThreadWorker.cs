using System.ComponentModel;
using System.Windows.Forms;

namespace CAS.UI.UIControls.AnimatedBackgroundWorker
{
    /// <summary>
    /// Класс для запуска метода в другом потоке
    /// </summary>
    public class AnimatedThreadWorker
    {
        #region Fields 

        private WaitForm _waitForm;
        private WaitCancelForm _waitCancelForm;
        private BackgroundWorker _backgroundWorker;

        #endregion

        #region Constructors

        #region public AnimatedThreadWorker()
        ///<summary>
        /// Создает объект с параметрами по умолчанию
        ///</summary>
        public AnimatedThreadWorker()
        {
            _waitForm = StaticWaitFormProvider.WaitForm;
            
            _backgroundWorker = new BackgroundWorker();
            _backgroundWorker.WorkerSupportsCancellation = true;
            _backgroundWorker.WorkerReportsProgress = true;
            _backgroundWorker.DoWork += BackgroundWorkerDoWork;
            _backgroundWorker.ProgressChanged += BackgroundWorkerProgressChanged;
            _backgroundWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerCompleted;
        }
        #endregion
       
        #endregion

        #region Properties

        //public string State
        //{
        //    get { return _waitForm.State; }
        //    set { _waitForm.State = value; }
        //}
        #region public bool IsBusy
        /// <summary>
        /// Возвращает значение, показывающие, выполняет ли объект AnimatedThreadWorker асинхронную задачу
        /// </summary>
        public bool IsBusy
        {
            get { return _backgroundWorker.IsBusy; }
        }
        #endregion

        #region public bool CancellationPending
        /// <summary>
        /// Возвращает значение, показывающие, запросило ли приложение отмену асинхронной операции
        /// </summary>
        public bool CancellationPending
        {
            get { return _backgroundWorker.CancellationPending; }
        }
        #endregion

        #endregion

        #region Methods

        #region private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            if (DoWork != null)
                DoWork(this, e);
        }
        #endregion

        #region private void BackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        private void BackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _waitForm.State = e.ProgressPercentage + "% " + (string)e.UserState;
        }
        #endregion

        #region private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _waitForm.Hide();
            StaticWaitFormProvider.IsActive = false;
            
            if (RunWorkerCompleted != null)
                RunWorkerCompleted(this, e);
        }
        #endregion

        #region public void CancelAsync()
        ///<summary>
        /// запрашивает отмену асинхронной операции
        ///</summary>
        public void CancelAsync()
        {
            _waitForm.Hide();
            StaticWaitFormProvider.IsActive = false;

            if(_backgroundWorker.IsBusy)
            {
                _backgroundWorker.CancelAsync();
                _waitCancelForm = new WaitCancelForm(_backgroundWorker)
                                      {
                                          StartPosition = FormStartPosition.CenterScreen
                                      };
                _waitCancelForm.ShowDialog();

                //while (_backgroundWorker.IsBusy)
                //{
                //    Application.DoEvents();
                //    //Thread.Sleep(500);
                //}
            }
        }
        #endregion

        #region public void Dispose()
        ///<summary>
        /// освобождает ресурсы занимаемые компонентом
        ///</summary>
        public void Dispose()
        {
            if(_backgroundWorker.IsBusy)
                CancelAsync();

            DoWork = null;
            RunWorkerCompleted = null;

            _backgroundWorker.DoWork -= BackgroundWorkerDoWork;
            _backgroundWorker.ProgressChanged -= BackgroundWorkerProgressChanged;
            _backgroundWorker.RunWorkerCompleted -= BackgroundWorkerRunWorkerCompleted;
            _backgroundWorker.Dispose();
        }
        #endregion

        #region public void RunWorkerAsync()
        ///<summary>
        /// запускает задачу, прикрепленную к событию DoWork в другом потоке
        /// 
        ///</summary>
        public void RunWorkerAsync()
        {
            if(_backgroundWorker.IsBusy)
                return;
            _waitForm.Visible = true;
            _waitForm.Show();
            StaticWaitFormProvider.IsActive = true;

            _backgroundWorker.RunWorkerAsync();
        }
        #endregion

        #region public void ReportProgress(int percentProgress, object userState)
        ///<summary>
        ///</summary>
        ///<param name="percentProgress"></param>
        ///<param name="userState"></param>
        public void ReportProgress(int percentProgress, object userState)
        {
            _backgroundWorker.ReportProgress(percentProgress, userState);    
        }
        #endregion
        
        #endregion

        #region Events

        ///<summary>
        /// Событие, возникающее при завершении работы фонового потока
        ///</summary>
        public event RunWorkerCompletedEventHandler RunWorkerCompleted;

        ///<summary>
        /// Событие, возникающее при начале заботы фонового потока
        ///</summary>
        public event DoWorkEventHandler DoWork;

        #endregion
    }
}