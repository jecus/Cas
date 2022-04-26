using System;
using System.ComponentModel;
using System.Windows.Forms;
using CAA.Entity.Models.DTO;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.CAA.CAAEducation;
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
            statusControl.ShowStatus = true;
            statusControl.ShowOperatorAircraft = false;

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
            statusControl.ConditionState = _educationManagment.Record?.Settings?.Condition;

            if (_educationManagment.Record == null)
            {
                extendableRichContainerSummary.LabelCaption.Text = "Open";
            }
            else
            {
                extendableRichContainerSummary.LabelCaption.Text = " Status: " + $"{(_educationManagment.Record.Settings.IsClosed ? "Closed" : "Open")}";
            }
            
            

            _educationPerformanceControl.Object = _educationManagment;
            educationsComplianceControl1.UpdateInformation(_educationManagment, AnimatedThreadWorker);
        }
        #endregion

        #region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            AnimatedThreadWorker.ReportProgress(0, "Load");

            if (_educationManagment.Record != null && _educationManagment.Record.ItemId > 0)
            {
                _educationManagment.Record = GlobalObjects.CaaEnvironment.NewLoader
                    .GetObjectById<EducationRecordsDTO, CAAEducationRecord>(_educationManagment.Record.ItemId);
            }
            else
            {
                _educationManagment.Record = new CAAEducationRecord()
                {
                    EducationId = _educationManagment.Education.ItemId,
                    OccupationId = _educationManagment.Occupation.ItemId,
                    SpecialistId = _educationManagment.Specialist.ItemId,
                    OperatorId = _educationManagment.Specialist.OperatorId,
                    PriorityId = _educationManagment.Education.Priority.ItemId,
                    Settings = new CAAEducationRecordSettings()
                    {
                        IsCombination =_educationManagment.IsCombination,
                    }
                    
                };
            }

            
            AnimatedThreadWorker.ReportProgress(40, "Calculation");
            EducationCalculator.CalculateEducation(_educationManagment.Record);
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
            _educationPerformanceControl.ApplyChanges();
            GlobalObjects.CaaEnvironment.NewKeeper.Save(_educationManagment.Record);
            
            MessageBox.Show("Saving was successful", "Message infomation", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            
            AnimatedThreadWorker.RunWorkerAsync();
        }

        private void extendableRichContainerComplianceExtending(object sender, EventArgs e)
        {
            educationsComplianceControl1.Visible = !educationsComplianceControl1.Visible;
        }
    }
}
