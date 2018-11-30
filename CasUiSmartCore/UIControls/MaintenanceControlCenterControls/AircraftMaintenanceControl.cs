using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Atlbs;
using SmartCore.Entities.General.WorkPackage;

namespace CAS.UI.UIControls.MaintenanceControlCenterControls
{
    public partial class AircraftMaintenanceControl : EditObjectControl
    {

        private CommonCollection<WorkPackage> _resultDirectiveArray = new CommonCollection<WorkPackage>();

        #region public Aircraft JobCardTask
        /// <summary>
        /// ВС Связанный с контролом
        /// </summary>
        public Aircraft Aircraft
        {
            get { return AttachedObject as Aircraft; }
            set { AttachedObject = value; }
        }
        #endregion

        #region public bool EnableExtendedControl
        ///<summary>
        /// Возвращает или задает значение видна ли панель расширения
        ///</summary>
        public bool EnableExtendedControl
        {
            get { return panelExtendable.Visible; }
            set
            {
                panelExtendable.Visible = value;
                if (value == false)
                {
                    extendableRichContainer.Extended = true;

                    //panelMain.Visible = true;
                    //panelRelease.Visible = true;
                    //panelDeferredInfo.Visible = _showDeferredInfoPanel;
                }
            }
        }
        #endregion

        #region public bool Extended
        ///<summary>
        /// Возвращает или задает значение Показывается ли елемент развернутым
        ///</summary>
        public bool Extended
        {
            get { return splitContainerMain.Visible; }
            set
            {
                extendableRichContainer.Extended = value;
                splitContainerMain.Visible = value;
            }
        }
        #endregion

        public AircraftMaintenanceControl()
        {
            InitializeComponent();
        }

        #region private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        private void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            if (Aircraft == null)
            {
                e.Cancel = true;
                return;
            }

            backgroundWorker.ReportProgress(0, "calculation of Maintenance checks");

            _resultDirectiveArray.Clear();

            _resultDirectiveArray.AddRange(GlobalObjects.WorkPackageCore.GetWorkPackages(Aircraft, WorkPackageStatus.Published).ToArray());

            foreach (WorkPackage workPackage in _resultDirectiveArray)
                GlobalObjects.WorkPackageCore.GetWorkPackageItemsWithCalculate(workPackage);  

            //backgroundWorker.ReportProgress(0, "calculation of Maintenance checks");
            //GlobalObjects.CasEnvironment.Analyst.GetMaintenanceCheck(_currentForecast);
            //directives.AddRange(_currentForecast.MaintenanceChecks.ToArray());

            //if (backgroundWorker.CancellationPending)
            //{
            //    e.Cancel = true;
            //    return;
            //}

            //backgroundWorker.ReportProgress(9, "calculation of Base details");
            //GlobalObjects.CasEnvironment.Analyst.GetBaseDetailsAndDetailDirectives(_currentForecast);
            //directives.AddRange(_currentForecast.BaseDetails.ToArray());
            //directives.AddRange(_currentForecast.BaseDetailDirectives.ToArray());

            //if (backgroundWorker.CancellationPending)
            //{
            //    e.Cancel = true;
            //    return;
            //}

            //backgroundWorker.ReportProgress(18, "calculation of Components");
            //GlobalObjects.CasEnvironment.Analyst.GetComponentsAndDetailDirectives(_currentForecast);
            //directives.AddRange(_currentForecast.Components.ToArray());
            //directives.AddRange(_currentForecast.ComponentDirectives.ToArray());

            //if (backgroundWorker.CancellationPending)
            //{
            //    e.Cancel = true;
            //    return;
            //}

            //backgroundWorker.ReportProgress(27, "calculation of Airworthiness directives");
            //GlobalObjects.CasEnvironment.Analyst.GetDirectives(_currentForecast, DirectiveType.AirworthenessDirectives);
            //directives.AddRange(_currentForecast.AdStatus.ToArray());

            //if (backgroundWorker.CancellationPending)
            //{
            //    e.Cancel = true;
            //    return;
            //}

            //backgroundWorker.ReportProgress(36, "calculation of Damages");
            //GlobalObjects.CasEnvironment.Analyst.GetDirectives(_currentForecast, DirectiveType.DamagesRequiring);
            //directives.AddRange(_currentForecast.Damages.ToArray());

            //if (backgroundWorker.CancellationPending)
            //{
            //    e.Cancel = true;
            //    return;
            //}

            //backgroundWorker.ReportProgress(45, "calculation of Deffereds");
            //GlobalObjects.CasEnvironment.Analyst.GetDirectives(_currentForecast, DirectiveType.DeferredItems);
            //directives.AddRange(_currentForecast.DefferedItems.ToArray());

            //if (backgroundWorker.CancellationPending)
            //{
            //    e.Cancel = true;
            //    return;
            //}

            //backgroundWorker.ReportProgress(54, "calculation of Engineering orders");
            //GlobalObjects.CasEnvironment.Analyst.GetEngineeringOrders(_currentForecast);
            //directives.AddRange(_currentForecast.EngineeringOrders.ToArray());

            //if (backgroundWorker.CancellationPending)
            //{
            //    e.Cancel = true;
            //    return;
            //}

            //backgroundWorker.ReportProgress(63, "calculation of Service bulletins");
            //GlobalObjects.CasEnvironment.Analyst.GetServiceBulletins(_currentForecast);
            //directives.AddRange(_currentForecast.ServiceBulletins.ToArray());

            //if (backgroundWorker.CancellationPending)
            //{
            //    e.Cancel = true;
            //    return;
            //}

            //backgroundWorker.ReportProgress(72, "calculation of Out of phase");
            //GlobalObjects.CasEnvironment.Analyst.GetDirectives(_currentForecast, DirectiveType.OutOfPhase);
            //directives.AddRange(_currentForecast.OutOfPhaseItems.ToArray());

            //if (backgroundWorker.CancellationPending)
            //{
            //    e.Cancel = true;
            //    return;
            //}

            //backgroundWorker.ReportProgress(81, "calculation of Maintenance Directives");
            //GlobalObjects.CasEnvironment.Analyst.GetMaintenanceDirectives(_currentForecast);
            //directives.AddRange(_currentForecast.MaintenanceDirectives.ToArray());

            if (backgroundWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
        }

        #endregion

        private void BackgroundWorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        #region private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        private void BackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ClearControls();
            BuildControls();
        }
        #endregion

        #region public void DoAsyncWork()
        public void DoAsyncWork()
        {
            if (!backgroundWorker.IsBusy)
            {
                backgroundWorker.RunWorkerAsync();
            }
        }
        #endregion

        #region public void CancelAsyncWork()
        ///<summary>
        /// запрашивает отмену асинхронной операции
        ///</summary>
        public void CancelAsyncWork()
        {
            if (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();

                WaitCancelForm wcf = new WaitCancelForm(backgroundWorker)
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                wcf.ShowDialog();

                while (backgroundWorker.IsBusy)
                {
                    Thread.Sleep(500);
                }
            }
        }
        #endregion

        #region private void AvButtonReloadClick(object sender, EventArgs e)
        private void AvButtonReloadClick(object sender, EventArgs e)
        {
            DoAsyncWork();
        }
        #endregion

        public override void FillControls()
        {
            extendableRichContainer.labelCaption.Text = Aircraft.RegistrationNumber;

	        var lastFlight = GlobalObjects.AircraftFlightsCore.GetLastAircraftFlight(Aircraft.ItemId);

            fuelControl1.AttachedObject = lastFlight != null ? lastFlight : new AircraftFlight();
        }

        private void BuildControls()
        {
            extendableRichContainer.labelCaption.Text = Aircraft.RegistrationNumber;       
        }

        private void ClearControls()
        {
            panelDiscrepancies.Controls.Clear();
        }

        private void ExtendableRichContainerExtending(object sender, EventArgs e)
        {
            splitContainerMain.Visible = ! splitContainerMain.Visible;
        }
    }
}
