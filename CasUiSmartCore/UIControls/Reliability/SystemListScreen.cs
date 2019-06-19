using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using AvControls;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.ComponentChangeReport;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;

namespace CAS.UI.UIControls.Reliability
{
	public partial class SystemListScreen : ScreenControl
	{
		#region Fields

		private ComponentChangeListView _directivesViewer;
		private TransferRecordCollection _initialDirectiveArray = new TransferRecordCollection();

		#endregion

		#region Constructor

		#region public SystemListScreen()

		public SystemListScreen()
		{
			InitializeComponent();
		}

		#endregion

		#region public ComponentChangeReport(Aircraft aircraft) : this()

		public SystemListScreen(Operator @operator) : this()
		{
			if (@operator == null)
				throw new ArgumentNullException("@operator", "Cannot display null-@operator");

			CurrentOperator = @operator;

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

			_initialDirectiveArray.AddRange(GlobalObjects.TransferRecordCore.GetTransferRecord());


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
				labelTitle.Text = "";
				labelTitle.Status = Statuses.NotActive;

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
