using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.UIControls.AnimatedBackgroundWorker;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.DocumentationControls;
using CASTerms;
using EntityCore.DTO.Dictionaries;
using EntityCore.Filter;
using MetroFramework.Forms;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
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
		private List<MaintenanceDirective> _mpdWithInterval = new List<MaintenanceDirective>();

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
			var search = textBoxSearch.Text.ToLower();

			var intervals =
				checkedListBoxItems.CheckedItems.OfType<Lifelength>();
			_mpdWithInterval = new List<MaintenanceDirective>();
			_mpdWithInterval
				.AddRange(_mpdForSelect
					.Where(mpd => intervals.Any(interval => mpd.Threshold.FirstPerformanceSinceNew != null
					                                        && mpd.Threshold.FirstPerformanceSinceNew.Equals(interval)))
					.Where(i => i.TaskNumberCheck.ToLower().Contains(search) || i.TaskCardNumber.ToLower().Contains(search)));
			listViewTasksForSelect.SetItemsArray(_mpdWithInterval.ToArray());
		}
		#endregion

		#region private void listViewTasksForSelect_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)

		private void listViewTasksForSelect_SelectedItemsChanged(object sender, SelectedItemsChangeEventArgs e)
		{
			if (listViewTasksForSelect.SelectedItem == null) return;
			numericUpDownExtension.Value = (decimal)listViewTasksForSelect.SelectedItem.Extension;
		}

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
				var q = new List<BaseEntityObject>();
				foreach (var item in listViewTasksForSelect.radGridView1.ChildRows.Select(i => i.Tag).Cast<MaintenanceDirective>())
				{
					var dir = item;
					dir.Extension = (double)numericUpDownExtension.Value;
					dir.IsExtension = true;
					q.Add(item);
				}
				if (_mpdForSelect.Count > 0)
					GlobalObjects.NewKeeper.BulkUpdate(q);


				Sort();
				numericUpDownExtension.Value = 0;
				textBoxSearch.Text = "";
				//_animatedThreadWorker.RunWorkerAsync();

				MessageBox.Show(@"Tasks saved successful!",
					(string)new GlobalTermsProvider()["SystemName"],
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		#endregion

		#region private void buttonReset_Click(object sender, EventArgs e)

		private void buttonReset_Click(object sender, EventArgs e)
		{
			numericUpDownExtension.Value = 0;
			var list = new List<MaintenanceDirective>();
			foreach (var item in listViewTasksForSelect.radGridView1.ChildRows.Select(i => i.Tag).Cast<MaintenanceDirective>().Where(i => i.Extension > 0 || i.IsExtension))
			{
				var dir = item;
				dir.Extension = (double)numericUpDownExtension.Value;
				dir.IsExtension = false;
				list.Add(item);
			}
			if(list.Count > 0)
				GlobalObjects.NewKeeper.BulkUpdate(list.Cast<BaseEntityObject>().ToList());
			Sort();

			MessageBox.Show(@"Tasks reset successful!",
				(string)new GlobalTermsProvider()["SystemName"],
				MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		#endregion


		#endregion

		private void TextBoxSearch_TextChanged(object sender, System.EventArgs e)
		{
			Sort();
		}

		private void buttonAddDoc_Click(object sender, EventArgs e)
		{
			var _departmentPalanning = GlobalObjects.CasEnvironment.NewLoader.GetObject<DepartmentDTO, Department>(new Filter("FullName", "Planning"));
			var spec = GlobalObjects.CasEnvironment.GetDictionary<Specialization>().GetByFullName("Records and Planning Manager") as Specialization;
			var docSubType = GlobalObjects.CasEnvironment.GetDictionary<DocumentSubType>().GetByFullName("EXEMPTION") as DocumentSubType;
			var newDocument = new Document
			{
				Parent = _currentAircraft,
				ParentId = _currentAircraft.ItemId,
				ParentTypeId = _currentAircraft.SmartCoreObjectType.ItemId,
				DocType = DocumentType.Permission,
				DocumentSubType = docSubType,
				IsClosed = false,
				ContractNumber = $"",
				Description = "",
				ProlongationWay = ProlongationWay.Auto,
				ParentAircraftId = _currentAircraft.ItemId,
				Department = _departmentPalanning,
				ResponsibleOccupation = spec
			};

			var form = new DocumentForm(newDocument, false);
			if (form.ShowDialog() == DialogResult.OK)
				MessageBox.Show("Document created successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

}