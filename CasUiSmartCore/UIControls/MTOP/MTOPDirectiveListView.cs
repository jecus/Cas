using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.MTOP;

namespace CAS.UI.UIControls.MTOP
{
	public partial class MTOPDirectiveListView : BaseListViewControl<MaintenanceDirective>
	{
		private Dictionary<int, Lifelength> _groupLifelengths;
		private readonly List<MTOPCheck> _maintenanceChecks;
		private bool _isZeroPhase;
		private int _start;

		#region Constructor

		public MTOPDirectiveListView()
		{
			InitializeComponent();
		}

		public MTOPDirectiveListView(Dictionary<int, Lifelength> groupLifelengths, List<MTOPCheck> maintenanceChecks) : this()
		{
			_groupLifelengths = groupLifelengths;
			_maintenanceChecks = maintenanceChecks;
			_isZeroPhase = maintenanceChecks.All(i => i.IsZeroPhase);
			SortMultiplier = 0;

			foreach (var check in _maintenanceChecks)
			{
				var last = check.PerformanceRecords.OrderByDescending(i => i.RecordDate).FirstOrDefault();
				if(last == null)continue;

				if (_start < last.GroupName)
					_start = last.GroupName;

			}

		}

		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			ColumnHeaderList.Clear();
			itemsListView.Columns.Clear();

			var columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Task Card №" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Thresh" };
			ColumnHeaderList.Add(columnHeader);

			//columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "PhaseThresh" };
			//ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Repeat" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.05f), Text = "Phase" };
			ColumnHeaderList.Add(columnHeader);

			foreach (var lifelength in _groupLifelengths)
			{
				if (lifelength.Key <= _start)
					continue;

				if(lifelength.Key >= _start + 50)
					continue;

				var length = lifelength.Key.ToString().Length;
				int width;

				if (_isZeroPhase)
				{
					if (length == 1)
						width = (int)(itemsListView.Width * 0.025f);
					else width = (int)(itemsListView.Width * 0.04f);
				}
				else
				{
					if (length == 2)
						width = (int)(itemsListView.Width * 0.04f);
					else width = (int)(itemsListView.Width * 0.025f);

				}
				var text = _isZeroPhase ? $"0{lifelength.Key}" :lifelength.Key.ToString();

				columnHeader = new ColumnHeader { Width = width, Text = text };
				ColumnHeaderList.Add(columnHeader);
			}

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Author" };
			ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(MTOPCheck item)

		protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(MaintenanceDirective item)
		{
			var subItems = new List<ListViewItem.ListViewSubItem>();

			var phaseString = "";
			if (item.MTOPPhase != null)
				phaseString = item.MTOPPhase.ToString();
			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

			var subItem = new ListViewItem.ListViewSubItem { Text = item.TaskCardNumber, Tag = item.TaskCardNumber };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Threshold.FirstPerformanceSinceNew.ToRepeatIntervalsFormat(), Tag = item.Threshold.FirstPerformanceSinceNew };
			subItems.Add(subItem);

			//subItem = new ListViewItem.ListViewSubItem { Text = item.PhaseThresh.ToRepeatIntervalsFormat(), Tag = item.PhaseThresh };
			//subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = item.Threshold.RepeatInterval.ToRepeatIntervalsFormat(), Tag = item.Threshold.RepeatInterval };
			subItems.Add(subItem);

			subItem = new ListViewItem.ListViewSubItem { Text = phaseString, Tag = item.MTOPPhase };
			subItems.Add(subItem);

			var temp = 0;

			foreach (var lifelength in _groupLifelengths)
			{
				if (lifelength.Key <= _start)
					continue;

				if (lifelength.Key >= _start + 50)
					continue;

				if (item.MTOPPhase != null)
				{
					//if (lifelength.Key == item.MTOPPhase.FirstPhase)
					//	subItem = new ListViewItem.ListViewSubItem {Text = "x", Tag = ""};
					//else if (lifelength.Key == item.MTOPPhase.SecondPhase)
					//{
					//	temp = item.MTOPPhase.SecondPhase + item.MTOPPhase.Difference;
					//	subItem = new ListViewItem.ListViewSubItem { Text = "x", Tag = "" };
					//}
					//else if (lifelength.Key == temp)
					//{
					//	temp += item.MTOPPhase.Difference;
					//	subItem = new ListViewItem.ListViewSubItem { Text = "x", Tag = "" };
					//}
					if (item.MTOPPhase.Difference > 0 && lifelength.Key % item.MTOPPhase.Difference == 0)
						subItem = new ListViewItem.ListViewSubItem {Text = "x", Tag = ""};
					else subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };
				}
				else subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };


				subItems.Add(subItem);
			}

			subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });

			return subItems.ToArray();
		}

		#endregion

		protected override void SetGroupsToItems(int columnIndex)
		{
			itemsListView.Groups.Clear();

			if (columnIndex == 3)
			{
				foreach (ListViewItem item in ListViewItemList.OrderBy(i => ((MaintenanceDirective)i.Tag).MTOPPhase?.FirstPhase ?? int.MaxValue))
				{
					string temp;

					if (item.Tag is MaintenanceDirective)
					{
						var directive = item.Tag as MaintenanceDirective;

						temp = directive.MTOPPhase?.ToString() ?? "1-0-0";
						itemsListView.Groups.Add(temp, temp);
						item.Group = itemsListView.Groups[temp];
					}
				}
			}
		}

		#region protected override void SortItems(int columnIndex)

		protected override void SortItems(int columnIndex)
		{
			if (OldColumnIndex != columnIndex)
				SortMultiplier = -1;
			if (SortMultiplier == 1)
				SortMultiplier = -1;
			else
				SortMultiplier = 1;
			itemsListView.Items.Clear();
			SetGroupsToItems(columnIndex);

			var resultList = new List<ListViewItem>();

			//добавление остальных подзадач
			resultList.AddRange(ListViewItemList.Where(item => item.Tag is MaintenanceDirective));
			resultList.Sort(new DirectiveListViewComparer(columnIndex, SortMultiplier));

			itemsListView.Items.AddRange(resultList.ToArray());
			OldColumnIndex = columnIndex;
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem != null)
			{
				var dp = ScreenAndFormManager.GetMaintenanceDirectiveScreen(SelectedItem);
				e.SetParameters(dp);
			}
		}

		#endregion
	}
}
