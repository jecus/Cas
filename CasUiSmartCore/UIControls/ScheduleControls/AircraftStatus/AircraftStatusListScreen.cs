using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Schedule;

namespace CAS.UI.UIControls.ScheduleControls.AircraftStatus
{
	public partial class AircraftStatusListScreen : ScreenControl
	{
		CommonCollection<FlightPlanOpsRecords> _initialFlightsArray = new CommonCollection<FlightPlanOpsRecords>();
		AircraftScreenListView _directivesViewer;

		#region Constructor

		public AircraftStatusListScreen()
		{
			InitializeComponent();
		}

		public AircraftStatusListScreen(Operator currentOperator) : this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			aircraftHeaderControl1.Operator = currentOperator;
			StatusTitle = "Aircraft Status";
			statusControl.ShowStatus = false;

			InitListView();
			UpdateInformation();
		}

		#endregion

		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			_directivesViewer.SetItemsArray(_initialFlightsArray.ToArray());
			_directivesViewer.Focus();

			headerControl.PrintButtonEnabled = _directivesViewer.ItemListView.Items.Count != 0;
		}

		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initialFlightsArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load records");

			try
			{
				_initialFlightsArray.AddRange(GlobalObjects.PlanOpsCalculator.LoadAircraftStatusOps());
			}
			catch (Exception exception)
			{
				Program.Provider.Logger.Log("Error while load records", exception);
			}

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void UpdateInformation()
		/// <summary>
		/// Происзодит обновление отображения элементов
		/// </summary>
		private void UpdateInformation()
		{
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region protected override void InitListView()

		private void InitListView()
		{
			_directivesViewer = new AircraftScreenListView(AnimatedThreadWorker);
			_directivesViewer.TabIndex = 2;
			_directivesViewer.IgnoreAutoResize = true;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.IgnoreAutoResize = true;

			panel1.Controls.Add(_directivesViewer);
		}

		#endregion
	}
}
