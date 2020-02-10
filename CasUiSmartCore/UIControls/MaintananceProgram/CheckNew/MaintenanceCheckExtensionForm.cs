using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CASTerms;
using MetroFramework.Forms;
using SmartCore.Calculations;
using SmartCore.Entities.General;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace CAS.UI.UIControls.MaintananceProgram.CheckNew
{
	/// <summary>
	/// Форма для переноса шаблона ВС в рабочую базу данных
	/// </summary>
	public partial class MaintenanceCheckExtensionForm : MetroForm
	{

		#region Fields

		private List<MaintenanceDirective> _mpdForSelect;
		private IEnumerable<MaintenanceDirective> _allDirectives;
		private Aircraft _currentAircraft;
		private List<Lifelength> _maintenanceDirectivesIntervals = new List<Lifelength>();

		private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
		private List<MaintenanceCheck> _checks;
		private List<MaintenanceDirective> _mpdWithInterval;

		#endregion

		#region Constructors

		#region private LDNDCheckFormNew()

		/// <summary>
		/// Создает форму для создания жесткой связи между чеками программы обслуживания и задачами программы обслуживания
		/// </summary>
		private MaintenanceCheckExtensionForm()
		{
			InitializeComponent();
		}

		#endregion

		#region public LDNDCheckFormNew(MaintenanceCheck maintenanceCheck) : this()

		/// <summary>
		/// Создает форму для привязки задач к выполнению чека программы обслуживания
		/// </summary>
		public MaintenanceCheckExtensionForm(Aircraft aircraft,IEnumerable<MaintenanceDirective> allDirectives)
			: this()
		{
			if (allDirectives == null)
				throw new ArgumentNullException("allDirectives", "must be not null");

			_currentAircraft = aircraft;
			_allDirectives = allDirectives;

			_animatedThreadWorker.DoWork += AnimatedThreadWorkerDoLoad;
			_animatedThreadWorker.RunWorkerCompleted += BackgroundWorkerRunWorkerLoadCompleted;
		}

		#endregion

		#endregion

		#region Properties

		#endregion

		#region Methods

		#region private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
		private void BackgroundWorkerRunWorkerLoadCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			checkedListBoxItems.SelectedIndexChanged -= CheckedListBoxItemsSelectedIndexChanged;
			checkedListBoxItems.Items.Clear();
			
			GetMaintenanceDirectivesIntervals();

			checkedListBoxItems.SelectedIndexChanged += CheckedListBoxItemsSelectedIndexChanged;

			listViewTasksForSelect.SetItemsArray(_mpdForSelect.ToArray());
			Focus();
		}
		#endregion

		#region private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
		private void AnimatedThreadWorkerDoLoad(object sender, DoWorkEventArgs e)
		{
			if (_currentAircraft == null)
			{
				e.Cancel = true;
				return;
			}
			_checks = new List<MaintenanceCheck>();
			_checks.AddRange(GlobalObjects.MaintenanceCore.GetMaintenanceCheck(_currentAircraft));

			_animatedThreadWorker.ReportProgress(0, "load binded tasks");

			//_mpdForSelect = _allDirectives.Where(mpd => mpd.MaintenanceCheck == null);
			_mpdForSelect = _allDirectives.ToList();

			if (_animatedThreadWorker.CancellationPending)
			{
				e.Cancel = true;
				return;
			}

			_animatedThreadWorker.ReportProgress(100, "binding complete");
		}
		#endregion

		#region private void ButtonCloseClick(object sender, EventArgs e)

		private void ButtonCloseClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		#endregion

		#region private void LDNDCheckFormNewLoad(object sender, EventArgs e)
		private void LDNDCheckFormNewLoad(object sender, EventArgs e)
		{
			_animatedThreadWorker.RunWorkerAsync();
		}
		#endregion

		#region private void GetMaintenanceDirectivesIntervals()
		private void GetMaintenanceDirectivesIntervals()
		{
			if (_mpdForSelect == null)
				return;
			if (_maintenanceDirectivesIntervals != null)
				_maintenanceDirectivesIntervals.Clear();

			IEnumerable<Lifelength> tempIntervals =
				_mpdForSelect
					.Where(mpd => !mpd.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
					.Select(mpd => mpd.Threshold.FirstPerformanceSinceNew)
					.Distinct()
					.OrderBy(l => l)
					.ToList();
			//Интервалы, содержащие только часы
			var intervalsGroupHours =
				tempIntervals.Where(i => i.Hours != null
									  && i.Cycles == null
									  && i.Days == null);
			//Интервалы, содержащие только циклы
			var intervalsGroupCycles =
				tempIntervals.Where(i => i.Hours == null
									  && i.Cycles != null
									  && i.Days == null);
			//Интервалы, содержащие только дни
			var intervalsGroupDays =
				tempIntervals.Where(i => i.Hours == null
									  && i.Cycles == null
									  && i.Days != null);
			//Интервалы, содержащие часы/циклы
			var intervalsGroupHoursCycles =
				tempIntervals.Where(i => i.Hours != null
									  && i.Cycles != null
									  && i.Days == null);
			//Интервалы, содержащие часы/дни
			var intervalsGroupHoursDays =
				tempIntervals.Where(i => i.Hours != null
									  && i.Cycles == null
									  && i.Days != null);
			//Интервалы, содержащие только циклы/дни
			var intervalsGroupCyclesDays =
				tempIntervals.Where(i => i.Hours == null
									  && i.Cycles != null
									  && i.Days != null);
			//Интервалы, содержащие часы/циклы/дни
			var intervalsGroupAll =
				tempIntervals.Where(i => i.Hours != null
									  && i.Cycles != null
									  && i.Days != null);

			_maintenanceDirectivesIntervals = new List<Lifelength> {  Lifelength.Null };
			_maintenanceDirectivesIntervals.AddRange(intervalsGroupHours);
			_maintenanceDirectivesIntervals.AddRange(intervalsGroupCycles);
			_maintenanceDirectivesIntervals.AddRange(intervalsGroupDays);
			_maintenanceDirectivesIntervals.AddRange(intervalsGroupHoursCycles);
			_maintenanceDirectivesIntervals.AddRange(intervalsGroupHoursDays);
			_maintenanceDirectivesIntervals.AddRange(intervalsGroupCyclesDays);
			_maintenanceDirectivesIntervals.AddRange(intervalsGroupAll);

			foreach (var firstPerformance in _maintenanceDirectivesIntervals)
			{
				Action<Lifelength> addLast = s => checkedListBoxItems.Items.Add(s, true);
				if (InvokeRequired)
				{
					Invoke(addLast, firstPerformance);
				}
				else addLast.Invoke(firstPerformance);
			}

		}
		#endregion

		#region private void CheckBoxSelectAllCheckedChanged(object sender, EventArgs e)
		private void CheckBoxSelectAllCheckedChanged(object sender, EventArgs e)
		{
			checkedListBoxItems.SelectedIndexChanged -= CheckedListBoxItemsSelectedIndexChanged;

			for (var i = 0; i < checkedListBoxItems.Items.Count; i++)
			{
				checkedListBoxItems.SetItemChecked(i, checkBoxSelectAll.Checked);
			}

			checkedListBoxItems.SelectedIndexChanged += CheckedListBoxItemsSelectedIndexChanged;

			CheckedListBoxItemsSelectedIndexChanged(null, EventArgs.Empty);
		}
		#endregion

		#region private void CheckedListBoxItemsSelectedIndexChanged(object sender, EventArgs e)
		private void CheckedListBoxItemsSelectedIndexChanged(object sender, EventArgs e)
		{
			Sort();
		}

		private void Sort()
		{
			var intervals =
				checkedListBoxItems.CheckedItems.OfType<Lifelength>();
			_mpdWithInterval = new List<MaintenanceDirective>();
			_mpdWithInterval
				.AddRange(_mpdForSelect
					.Where(mpd => intervals.Any(interval => mpd.Threshold.FirstPerformanceSinceNew != null
					                                        && mpd.Threshold.FirstPerformanceSinceNew.Equals(interval))));
			listViewTasksForSelect.SetItemsArray(_mpdWithInterval.ToArray());
		}
		#endregion

		#endregion

		#region private void buttonApply_Click(object sender, EventArgs e)

		private void buttonApply_Click(object sender, EventArgs e)
		{
			if (numericUpDownExtension.Value == 0)
			{
				MessageBox.Show(@"Please input value greather then 0!",
					(string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				foreach (var item in _mpdWithInterval)
				{
					var dir = item;
					dir.Extension = (double) numericUpDownExtension.Value;
					dir.IsExtension = true;
				}
				GlobalObjects.CasEnvironment.NewKeeper.BulkUpdate(_mpdWithInterval.Cast<BaseEntityObject>().ToList());
				Sort();

				//_animatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion
		
	}

}