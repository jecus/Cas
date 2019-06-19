using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AvControls;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using Convert = SmartCore.Auxiliary.Convert;

namespace CAS.UI.UIControls.ComponentChangeReport
{
	public partial class ComponentChangeReport : ScreenControl
	{
		#region Fields

		private ComponentChangeListView _directivesViewer;
		private TransferRecordCollection _initialDirectiveArray = new TransferRecordCollection();

		#endregion

		#region Constructor

		#region public ComponentChangeReport()

		public ComponentChangeReport()
		{
			InitializeComponent();
		}

		#endregion

		#region public ComponentChangeReport(Aircraft aircraft) : this()

		public ComponentChangeReport(Aircraft aircraft) : this()
		{
			if (aircraft == null)
				throw new ArgumentNullException("aircraft", "Cannot display null-aircraft");

			CurrentAircraft = aircraft;

			InitListView();
			UpdateInformation();
		}

		#endregion

		#endregion

		#region Methods

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)

		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initialDirectiveArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load Transfer records");

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

			_initialDirectiveArray.AddRange(GlobalObjects.TransferRecordCore.GetTransferRecord(CurrentAircraft.ItemId));


			AnimatedThreadWorker.ReportProgress(100, "Complete");

		}

		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Cancelled)
				return;
			_directivesViewer.SetItemsArray(_initialDirectiveArray.ToArray());
			_directivesViewer.Focus();
		}
		#endregion

		#region private void InitListView()

		private void InitListView()
		{
			_directivesViewer = new ComponentChangeListView();
			_directivesViewer.TabIndex = 2;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			Controls.Add(_directivesViewer);
			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void UpdateInformation()
		/// <summary>
		/// Происзодит обновление отображения элементов
		/// </summary>
		private void UpdateInformation()
		{
			if (CurrentAircraft != null)
			{
				labelTitle.Text = "Date as of: " +
				                  Convert.GetDateFormat(DateTime.Today) + " Aircraft TSN/CSN: " +
				                  GlobalObjects.CasEnvironment.Calculator.GetCurrentFlightLifelength(CurrentAircraft);
			}
			else
			{
				labelTitle.Text = "";
				labelTitle.Status = Statuses.NotActive;
			}

			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.RunWorkerAsync();
		}

#endregion

		#endregion
	}
}
