using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using CrystalDecisions.Windows.Forms;
using EFCore.DTO.General;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Schedule;

namespace CAS.UI.UIControls.ScheduleControls.PlanOPS
{
	public partial class FlightPlanOpsListScreen : ScreenControl
	{
		#region Fields

		CommonCollection<FlightPlanOps> _initialFlightOpsArray = new CommonCollection<FlightPlanOps>();

		FlightPlanOpsListView _directivesViewer;

		private ContextMenuStrip _contextMenuStrip;
		private ToolStripMenuItem _toolStripMenuItemCopy;
		private ToolStripMenuItem _toolStripMenuItemOpen;
		private ToolStripMenuItem _toolStripMenuItemOpenWithCalculate;

		#endregion

		#region Constructor

		public FlightPlanOpsListScreen()
		{
			InitializeComponent();
		}

		public FlightPlanOpsListScreen(Operator currentOperator) : this()
		{
			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");
			aircraftHeaderControl1.Operator = currentOperator;
			StatusTitle = "Flights";
			statusControl.ShowStatus = false;

			InitToolStripMenuItems();
			InitListView();
			UpdateInformation();
		}

		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			_directivesViewer.SetItemsArray(_initialFlightOpsArray.ToArray());
			_directivesViewer.Focus();

			headerControl.PrintButtonEnabled = _directivesViewer.ItemListView.Items.Count != 0;
		}

		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)

		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			_initialFlightOpsArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load records");

			try
			{
				_initialFlightOpsArray.AddRange(GlobalObjects.CasEnvironment.NewLoader.GetObjectListAll<FlightPlanOpsDTO,FlightPlanOps>());
			}
			catch (Exception exception)
			{
				Program.Provider.Logger.Log("Error while load records", exception);
			}

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}

		#endregion

		#region protected override void InitListView()

		private void InitListView()
		{
			_directivesViewer = new FlightPlanOpsListView();
			_directivesViewer.TabIndex = 2;
			_directivesViewer.IgnoreAutoResize = true;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.ContextMenuStrip = _contextMenuStrip;
			_directivesViewer.IgnoreAutoResize = true;


			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_contextMenuStrip = new ContextMenuStrip();
			_toolStripMenuItemCopy = new ToolStripMenuItem();
			_toolStripMenuItemOpen = new ToolStripMenuItem();
			_toolStripMenuItemOpenWithCalculate = new ToolStripMenuItem();

			// 
			// contextMenuStrip
			// 
			_contextMenuStrip.Name = "_contextMenuStrip";
			_contextMenuStrip.Size = new Size(179, 176);
			// 
			// _toolStripMenuItemOpen
			// 
			_toolStripMenuItemOpen.Text = "Open";
			_toolStripMenuItemOpen.Click += OpenItemClick;
			// 
			// toolStripMenuItemCopy
			// 
			_toolStripMenuItemOpenWithCalculate.Text = "Open with Calculate";
			_toolStripMenuItemOpenWithCalculate.Click += OpenCalItemClick;
			// 
			// toolStripMenuItemCopy
			// 
			_toolStripMenuItemCopy.Text = "Copy";
			_toolStripMenuItemCopy.Click += CopyItemsClick;

			_contextMenuStrip.Items.Clear();
			_contextMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				_toolStripMenuItemOpen,
				_toolStripMenuItemOpenWithCalculate,
				new ToolStripSeparator(), 
				_toolStripMenuItemCopy
			});

			_contextMenuStrip.Opening += _contextMenuStrip_Opening;
		}

		private void OpenCalItemClick(object sender, EventArgs e)
		{
			var refE = new ReferenceEventArgs();
			var selectedItem = _directivesViewer.SelectedItem;

			var period = $"{selectedItem.From:dd-MMMM-yyyy} - {selectedItem.To:dd-MMMM-yyyy} Calculated";

			var dp = DisplayerParams.CreateScreenParams(ReflectionTypes.DisplayInNew, period, new FlightPlanOpsRecordListScreen(GlobalObjects.CasEnvironment.Operators[0], selectedItem, true));
			refE.SetParameters(dp);

			InvokeDisplayerRequested(refE);
		}

		private void OpenItemClick(object sender, EventArgs e)
		{
			var refE = new ReferenceEventArgs();
			var selectedItem = _directivesViewer.SelectedItem;

			var period = $"{selectedItem.From:dd-MMMM-yyyy} - {selectedItem.To:dd-MMMM-yyyy}";

			var dp = DisplayerParams.CreateScreenParams(ReflectionTypes.DisplayInNew, period, new FlightPlanOpsRecordListScreen(GlobalObjects.CasEnvironment.Operators[0], selectedItem));
			refE.SetParameters(dp);

			InvokeDisplayerRequested(refE);
		}

		private void _contextMenuStrip_Opening(object sender, CancelEventArgs e)
		{
			_toolStripMenuItemCopy.Enabled = _toolStripMenuItemOpen.Enabled = _toolStripMenuItemOpenWithCalculate.Enabled = _directivesViewer.SelectedItems.Count == 1;
		}

		private void CopyItemsClick(object sender, EventArgs e)
		{
			if(_directivesViewer.SelectedItem == null)
				return;

			var form = new PlanOpsForm(_directivesViewer.SelectedItem, _initialFlightOpsArray.Select(i => i.From).ToList());
			if (form.ShowDialog() == DialogResult.OK)
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

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

		private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			var form = new PlanOpsForm(new FlightPlanOps(), _initialFlightOpsArray.Select(i => i.From).ToList());
			if (form.ShowDialog() == DialogResult.OK)
				AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)

		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null)
				return;
			var confirmResult = MessageBox.Show(
				"Do you really want to delete FlightPlanOps ?" , "Confirm delete operation",
				MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
			if (confirmResult == DialogResult.Yes)
			{
				try
				{
					_directivesViewer.ItemListView.BeginUpdate();

					foreach (var item in _directivesViewer.SelectedItems)
					{
						GlobalObjects.CasEnvironment.Execute($"delete from FlightPlanOpsRecords where FlightPlanOpsId = {item.ItemId}");
						GlobalObjects.CasEnvironment.NewKeeper.Delete(item);
					}

					_directivesViewer.ItemListView.EndUpdate();
				}
				catch (Exception ex)
				{
					Program.Provider.Logger.Log("Error while deleting data", ex);
					return;
				}
				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion
	}
}
