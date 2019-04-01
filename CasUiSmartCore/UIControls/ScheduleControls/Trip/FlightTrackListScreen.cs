using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.FiltersControls;
using CASTerms;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.Schedule;
using SmartCore.Filters;

namespace CAS.UI.UIControls.ScheduleControls.Trip
{
	public partial class FlightTrackListScreen : ScreenControl
	{
		private readonly FlightNumberScreenType _screenType;

		#region Fields

		private CommonCollection<FlightTrack> _initialTrackArray = new CommonCollection<FlightTrack>();
		private CommonCollection<FlightTrackRecord> _initialTrackRecordArray = new CommonCollection<FlightTrackRecord>();
		private CommonCollection<FlightTrackRecord> _resultTrackRecordArray = new CommonCollection<FlightTrackRecord>();

		private FlightTrackListView _directivesViewer;
		private CommonFilterCollection _filter;

		private ContextMenuStrip _contextMenuStrip;
		private ToolStripMenuItem _toolStripMenuItemCopyTrip;

		#endregion

		#region Constructor

		public FlightTrackListScreen()
		{
			InitializeComponent();
		}

		public FlightTrackListScreen(Operator currentOperator, FlightNumberScreenType screenType) : this()
		{
			_screenType = screenType;

			if (currentOperator == null)
				throw new ArgumentNullException("currentOperator");

			aircraftHeaderControl1.Operator = currentOperator;
			StatusTitle = "Flights";
			_filter = new CommonFilterCollection(typeof(ITripFilterParams));

			UpdateInformation();
			InitToolStripMenuItems();
			InitListView();
		}

		#endregion

		#region protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

		protected override void AnimatedThreadWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			_directivesViewer.SetItemsArray(_resultTrackRecordArray.Where(i => i.FlightNumberPeriod != null).ToArray());
			_directivesViewer.Focus();

			headerControl.PrintButtonEnabled = _directivesViewer.ItemListView.Items.Count != 0;
		}

		#endregion

		#region protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)

		protected override void AnimatedThreadWorkerDoWork(object sender, DoWorkEventArgs e)
		{
			#region Загрузка элементов
			_initialTrackArray.Clear();
			_initialTrackRecordArray.Clear();

			AnimatedThreadWorker.ReportProgress(0, "load records");

			try
			{
				_initialTrackArray.AddRange(GlobalObjects.FlightTrackCore.GetAllFlightTracks(true));
				_initialTrackRecordArray.AddRange(_initialTrackArray.SelectMany(i => i.FlightTripRecord));
			}
			catch (Exception exception)
			{
				Program.Provider.Logger.Log("Error while load records", exception);
			}

			AnimatedThreadWorker.ReportProgress(40, "Calculate records");

			#region Фильтрация директив

			AnimatedThreadWorker.ReportProgress(70, "filter records");

			FilterItems(_initialTrackRecordArray, _resultTrackRecordArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
			#endregion
		}

		#endregion

		#region private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)

		private void AnimatedThreadWorkerDoFilteringWork(object sender, DoWorkEventArgs e)
		{
			_resultTrackRecordArray.Clear();

			#region Фильтрация директив

			AnimatedThreadWorker.ReportProgress(50, "filter directives");

			FilterItems(_initialTrackRecordArray, _resultTrackRecordArray);

			if (AnimatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}
			#endregion

			AnimatedThreadWorker.ReportProgress(100, "Complete");
		}

		#endregion

		#region private void UpdateInformation()
		/// <summary>
		/// Происзодит обновление отображения элементов
		/// </summary>
		public void UpdateInformation()
		{
			AnimatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void InitToolStripMenuItems()

		private void InitToolStripMenuItems()
		{
			_contextMenuStrip = new ContextMenuStrip();
			_toolStripMenuItemCopyTrip = new ToolStripMenuItem();

			// 
			// contextMenuStrip
			// 
			_contextMenuStrip.Name = "_contextMenuStrip";
			_contextMenuStrip.Size = new Size(179, 176);
			// 
			// toolStripMenuItemView
			// 
			_toolStripMenuItemCopyTrip.Text = "Edit Trip";
			_toolStripMenuItemCopyTrip.Click += ToolStripMenuItemCopyTripClick;

			_contextMenuStrip.Items.Clear();
			_contextMenuStrip.Items.AddRange(new ToolStripItem[]
			{
				_toolStripMenuItemCopyTrip
			});
		}

		#endregion

		#region private void ToolStripMenuItemCopyTripClick(object sender, EventArgs e)

		private void ToolStripMenuItemCopyTripClick(object sender, EventArgs e)
		{
			if(_directivesViewer.SelectedItem == null)
				return;

			var form = new TrackForm(_directivesViewer.SelectedItem);
			if (form.ShowDialog() == DialogResult.OK)
				UpdateInformation();
		}

		#endregion

		#region protected override void InitListView(PropertyInfo beginGroup = null)

		private void InitListView()
		{
			_directivesViewer = new FlightTrackListView(_screenType);
			_directivesViewer.TabIndex = 2;
			_directivesViewer.IgnoreAutoResize = true;
			_directivesViewer.Location = new Point(panel1.Left, panel1.Top);
			_directivesViewer.ContextMenuStrip = _contextMenuStrip;
			_directivesViewer.Dock = DockStyle.Fill;

			panel1.Controls.Add(_directivesViewer);
		}

		#endregion

		#region private void HeaderControlButtonReloadClick(object sender, EventArgs e)

		private void HeaderControlButtonReloadClick(object sender, EventArgs e)
		{
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
			AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoWork;
			AnimatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)

		private void ButtonAddDisplayerRequested(object sender, ReferenceEventArgs e)
		{
			var form = new TrackForm(new FlightTrack());
			if (form.ShowDialog() == DialogResult.OK)
			{
				UpdateInformation();
			}
		}

		#endregion

		#region private void ButtonDeleteClick(object sender, EventArgs e)

		private void ButtonDeleteClick(object sender, EventArgs e)
		{
			if (_directivesViewer.SelectedItems == null ||
			    _directivesViewer.SelectedItems.Count == 0) return;


			DialogResult confirmResult =
				MessageBox.Show(_directivesViewer.SelectedItems.Count == 1
						? "Do you really want to delete Trip " + _directivesViewer.SelectedItems[0].FlightTrack.TripName + "?"
						: "Do you really want to delete selected Trips?", "Confirm delete operation",
					MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

			if (confirmResult == DialogResult.Yes)
			{
				_directivesViewer.ItemListView.BeginUpdate();
				foreach (var directive in _directivesViewer.SelectedItems)
				{
					try
					{
						GlobalObjects.CasEnvironment.NewKeeper.Delete(directive.FlightTrack);
						foreach (var record in directive.FlightTrack.FlightTripRecord)
							GlobalObjects.CasEnvironment.NewKeeper.Delete(record);
					}
					catch (Exception ex)
					{
						Program.Provider.Logger.Log("Error while deleting data", ex);
						return;
					}
				}
				_directivesViewer.ItemListView.EndUpdate();
				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void ButtonApplyFilterClick(object sender, EventArgs e)

		private void ButtonApplyFilterClick(object sender, EventArgs e)
		{
			var form = new CommonFilterForm(_filter, _initialTrackRecordArray);

			if (form.ShowDialog(this) == DialogResult.OK)
			{
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoWork;
				AnimatedThreadWorker.DoWork -= AnimatedThreadWorkerDoFilteringWork;
				AnimatedThreadWorker.DoWork += AnimatedThreadWorkerDoFilteringWork;

				AnimatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void FilterItems(IEnumerable<FlightTripRecord> initialCollection, ICommonCollection<FlightTripRecord> resultCollection)

		///<summary>
		///</summary>
		///<param name="initialCollection"></param>
		///<param name="resultCollection"></param>
		private void FilterItems(IEnumerable<FlightTrackRecord> initialCollection, ICommonCollection<FlightTrackRecord> resultCollection)
		{
			if (_filter == null || _filter.Count == 0)
			{
				resultCollection.Clear();
				resultCollection.AddRange(initialCollection);
				return;
			}

			resultCollection.Clear();

			foreach (var pd in initialCollection)
			{
				if (_filter.FilterTypeAnd)
				{
					bool acceptable = true;
					foreach (ICommonFilter filter in _filter)
					{
						acceptable = filter.Acceptable(pd); if (!acceptable) break;
					}
					if (acceptable) resultCollection.Add(pd);
				}
				else
				{
					bool acceptable = true;
					foreach (ICommonFilter filter in _filter)
					{
						if (filter.Values == null || filter.Values.Length == 0)
							continue;
						acceptable = filter.Acceptable(pd); if (acceptable) break;
					}
					if (acceptable) resultCollection.Add(pd);
				}
			}
		}
		#endregion
	}
}
