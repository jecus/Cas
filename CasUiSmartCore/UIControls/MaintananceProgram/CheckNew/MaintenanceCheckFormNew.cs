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
	/// ����� ��� �������� ������� �� � ������� ���� ������
	/// </summary>
	public partial class MaintenanceCheckFormNew : MetroForm
	{

		#region Fields

		private List<MaintenanceDirective> _mpdForSelect;
		private IEnumerable<MaintenanceDirective> _allDirectives;
		private Aircraft _currentAircraft;
		private List<Lifelength> _maintenanceDirectivesIntervals = new List<Lifelength>();

		private AnimatedThreadWorker _animatedThreadWorker = new AnimatedThreadWorker();
		private List<MaintenanceCheck> _checks;
		private List<MaintenanceDirective> _mpdWithInterval = new List<MaintenanceDirective>();

		#endregion

		#region Constructors

		#region private LDNDCheckFormNew()

		/// <summary>
		/// ������� ����� ��� �������� ������� ����� ����� ������ ��������� ������������ � �������� ��������� ������������
		/// </summary>
		private MaintenanceCheckFormNew()
		{
			InitializeComponent();
		}

		#endregion

		#region public LDNDCheckFormNew(MaintenanceCheck maintenanceCheck) : this()

		/// <summary>
		/// ������� ����� ��� �������� ����� � ���������� ���� ��������� ������������
		/// </summary>
		public MaintenanceCheckFormNew(Aircraft aircraft,IEnumerable<MaintenanceDirective> allDirectives)
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

			comboBox1.Items.Clear();
			comboBox1.Items.AddRange(_checks.ToArray());

			GetMaintenanceDirectivesIntervals();
			ComboBox1_SelectedIndexChanged(null, null);
			checkedListBoxItems.SelectedIndexChanged += CheckedListBoxItemsSelectedIndexChanged;

			listViewTasksForSelect.SetItemsArray(_mpdForSelect.ToArray());
			_mpdWithInterval.AddRange(_mpdForSelect);
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
			//���������, ���������� ������ ����
			var intervalsGroupHours =
				tempIntervals.Where(i => i.Hours != null
									  && i.Cycles == null
									  && i.Days == null);
			//���������, ���������� ������ �����
			var intervalsGroupCycles =
				tempIntervals.Where(i => i.Hours == null
									  && i.Cycles != null
									  && i.Days == null);
			//���������, ���������� ������ ���
			var intervalsGroupDays =
				tempIntervals.Where(i => i.Hours == null
									  && i.Cycles == null
									  && i.Days != null);
			//���������, ���������� ����/�����
			var intervalsGroupHoursCycles =
				tempIntervals.Where(i => i.Hours != null
									  && i.Cycles != null
									  && i.Days == null);
			//���������, ���������� ����/���
			var intervalsGroupHoursDays =
				tempIntervals.Where(i => i.Hours != null
									  && i.Cycles == null
									  && i.Days != null);
			//���������, ���������� ������ �����/���
			var intervalsGroupCyclesDays =
				tempIntervals.Where(i => i.Hours == null
									  && i.Cycles != null
									  && i.Days != null);
			//���������, ���������� ����/�����/���
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
			if (comboBox1.SelectedItem == null)
			{
				MessageBox.Show(@"Please select check!",
					(string) new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				var check = comboBox1.SelectedItem as MaintenanceCheck;

				foreach (var item in _mpdWithInterval)
				{
					var dir = item;
					dir.MaintenanceCheck = check;
				}

				if(_mpdForSelect.Count > 0)
					GlobalObjects.NewKeeper.BulkUpdate(_mpdWithInterval.Cast<BaseEntityObject>().ToList());
				Sort();

				//_animatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion

		#region private void ComboBox1_SelectedIndexChanged(object sender, System.EventArgs e)

		private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBox1.SelectedItem != null)
			{
				buttonApply.Enabled = true;
				deleteButton.Enabled = true;
				editButton.Enabled = true;
			}
			else
			{
				buttonApply.Enabled = false;
				deleteButton.Enabled = false;
				editButton.Enabled = false;
			}
			//buttonApply.Enabled = 
			//	deleteButton.Enabled = 
			//		//addButton.Enabled = 
			//			editButton.Enabled = comboBox1.SelectedItem != null;
		}

		#endregion

		#region private void EditButton_Click(object sender, System.EventArgs e)

		private void EditButton_Click(object sender, EventArgs e)
		{
			var form = new MaintenanceCheckEditNew(comboBox1.SelectedItem as MaintenanceCheck);
			if (form.ShowDialog() == DialogResult.OK)
				_animatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void AddButton_Click(object sender, System.EventArgs e)

		private void AddButton_Click(object sender, EventArgs e)
		{
			var form = new MaintenanceCheckEditNew(new MaintenanceCheck(){ParentAircraft = _currentAircraft, ParentAircraftId = _currentAircraft.ItemId});
			if(form.ShowDialog() == DialogResult.OK)
				_animatedThreadWorker.RunWorkerAsync();
		}

		#endregion

		#region private void DeleteButton_Click(object sender, System.EventArgs e)

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			var res = MessageBox.Show($@"Do you really wand delete {(comboBox1.SelectedItem as MaintenanceCheck)} check?",
				(string)new GlobalTermsProvider()["SystemName"],
				MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (res == DialogResult.Yes)
			{
				GlobalObjects.NewKeeper.Delete(comboBox1.SelectedItem as MaintenanceCheck);
				_animatedThreadWorker.RunWorkerAsync();
			}
		}

		#endregion
	}

}