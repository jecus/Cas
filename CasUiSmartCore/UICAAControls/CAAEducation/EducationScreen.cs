using System;
using System.ComponentModel;
using CAS.UI.UIControls.Auxiliary;
using SmartCore.Entities.General;

namespace CAS.UI.UICAAControls.CAAEducation
{
    ///<summary>
    ///</summary>
    public partial class EducationScreen : ScreenControl
    {
        private readonly CAAEducationManagment _educationManagment;

        ///<summary>
        ///</summary>
        public EducationScreen(Operator currentOperator, CAAEducationManagment educationManagment)
        {
            _educationManagment = educationManagment;
            InitializeComponent();
            
            aircraftHeaderControl1.Operator = currentOperator;
            statusControl.ShowStatus = false;
        }




        #region public override void DisposeScreen()
        public override void DisposeScreen()
        {
            CancelAsync();

            if (AnimatedThreadWorker.IsBusy)
                AnimatedThreadWorker.CancelAsync();
            AnimatedThreadWorker.Dispose();

            Dispose(true);
        }

        #endregion

        #region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            extendableRichContainerSummary.LabelCaption.Text = "Summary " + ""
                                                           + " Status: " + "";
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            AnimatedThreadWorker.ReportProgress(0, "load directives");
            AnimatedThreadWorker.ReportProgress(40, "calculation of directives");
            AnimatedThreadWorker.ReportProgress(100, "Complete");
        }

        #region protected override void CancelAsync()
        /// <summary>
        /// Проверяет, выполняет ли AnimatedThreadWorker задачу, и производит отмену выполнения
        /// </summary>
        protected override void CancelAsync()
        {
            if (AnimatedThreadWorker.IsBusy)
                AnimatedThreadWorker.CancelAsync();
            
        }
        #endregion

        #region public override void OnInitCompletion(object sender)
        /// <summary>
        /// Метод, вызывается после добавления содежимого на отображатель(вкладку)
        /// </summary>
        /// <returns></returns>
        public override void OnInitCompletion(object sender)
        {
            AnimatedThreadWorker.RunWorkerAsync();

            base.OnInitCompletion(sender);
        }
        #endregion
        
        
        #region private void HeaderControl1ReloadRised(object sender, EventArgs e)

        private void HeaderControl1ReloadRised(object sender, EventArgs e)
        {
            CancelAsync();
            AnimatedThreadWorker.RunWorkerAsync();
        }
        #endregion

        #region private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)

        private void ExtendableRichContainerSummaryExtending(object sender, EventArgs e)
        {
            //_directiveSummary.Visible = !_directiveSummary.Visible;
        }
        #endregion

        #region private void ExtendableRichContainerGeneralExtending(object sender, EventArgs e)

        private void ExtendableRichContainerGeneralExtending(object sender, EventArgs e)
        {
            //_directiveGeneralInformation.Visible = !_directiveGeneralInformation.Visible;
        }
        #endregion

        #region private void ExtendableRichContainerPerformanceExtending(object sender, EventArgs e)

        private void ExtendableRichContainerPerformanceExtending(object sender, EventArgs e)
        {
            _educationPerformanceControl.Visible = !_educationPerformanceControl.Visible;
        }
        #endregion
        
        

        #endregion

        private void HeaderControlButtonSaveClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void extendableRichContainerComplianceExtending(object sender, EventArgs e)
        {
            //_performanceControl.Visible = !_performanceControl.Visible;
        }
    }
}
