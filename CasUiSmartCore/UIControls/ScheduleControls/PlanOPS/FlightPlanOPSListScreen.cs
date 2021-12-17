using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CASTerms;
using EntityCore.DTO.General;
using SmartCore.Entities.Collections;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Schedule;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.ScheduleControls.PlanOPS
{
	public partial class FlightPlanOpsListScreen : ScreenControl
	{
		#region Fields

		CommonCollection<FlightPlanOps> _initialFlightOpsArray = new CommonCollection<FlightPlanOps>();

		FlightPlanOpsListView _directivesViewer;

		private RadDropDownMenu _contextMenuStrip;
		private RadMenuItem _toolStripMenuItemCopy;
		private RadMenuItem _toolStripMenuItemOpen;
		private RadMenuItem _toolStripMenuItemOpenWithCalculate;

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

			headerControl.PrintButtonEnabled = _directivesViewer.ItemsCount != 0;
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
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.Dock = DockStyle.Fill;
			_directivesViewer.CustomMenu = _contextMenuStrip;

			_directivesViewer.MenuOpeningAction = () =>
			{
				_toolStripMenuItemCopy.Enabled = _toolStripMenuItemOpen.Enabled =
					_toolStripMenuItemOpenWithCalculate.Enabled = _directivesViewer.SelectedItems.Count == 1;
			};

			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_contextMenuStrip = new RadDropDownMenu();
			_toolStripMenuItemCopy = new RadMenuItem();
			_toolStripMenuItemOpen = new RadMenuItem();
			_toolStripMenuItemOpenWithCalculate = new RadMenuItem();

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
			_contextMenuStrip.Items.AddRange(
				_toolStripMenuItemOpen,
				_toolStripMenuItemOpenWithCalculate,
				new RadMenuSeparatorItem(), 
				_toolStripMenuItemCopy
			);
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
					_directivesViewer.radGridView1.BeginUpdate();

					GlobalObjects.NewKeeper.Delete(_directivesViewer.SelectedItems.OfType<BaseEntityObject>().ToList(), true);

					_directivesViewer.radGridView1.EndUpdate();
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
