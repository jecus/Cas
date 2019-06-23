using System.Collections.Generic;
using System.Linq;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.MTOP;

namespace CAS.UI.UIControls.MTOP
{
	public partial class MTOPDirectiveListView : BaseGridViewControl<MaintenanceDirective>
	{
		private Dictionary<int, Lifelength> _groupLifelengths;
		private readonly List<MTOPCheck> _maintenanceChecks;
		private bool _isZeroPhase;
		private int _start;

		#region Constructor

		//public MTOPDirectiveListView()
		//{
		//	InitializeComponent();
		//}

		public MTOPDirectiveListView(Dictionary<int, Lifelength> groupLifelengths, List<MTOPCheck> maintenanceChecks)
		{
			InitializeComponent();

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
			SetHeaders();
		}

		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			if (_groupLifelengths == null )
				return;
			AddColumn("Task Card №", (int)(radGridView1.Width * 0.16f));
			AddColumn("Thresh", (int)(radGridView1.Width * 0.16f));
			AddColumn("Repeat", (int)(radGridView1.Width * 0.16f));
			AddColumn("Phase", (int)(radGridView1.Width * 0.10f));
			

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
						width = (int)(radGridView1.Width * 0.05f);
					else width = (int)(radGridView1.Width * 0.08f);
				}
				else
				{
					if (length == 2)
						width = (int)(radGridView1.Width * 0.08f);
					else width = (int)(radGridView1.Width * 0.05f);

				}
				var text = _isZeroPhase ? $"0{lifelength.Key}" :lifelength.Key.ToString();

				AddColumn(text, width);
			}
			AddColumn("Signer", (int)(radGridView1.Width * 0.02f));
			radGridView1.Columns.AddRange(ColumnHeaderList.ToArray());
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(MTOPCheck item)

		protected override List<CustomCell> GetListViewSubItems(MaintenanceDirective item)
		{
			var subItems = new List<CustomCell>();

			var phaseString = "";
			if (item.MTOPPhase != null)
				phaseString = item.MTOPPhase.ToString();
			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

			subItems.Add(CreateRow(item.TaskCardNumber, item.TaskCardNumber));

			subItems.Add(CreateRow(item.Threshold.FirstPerformanceSinceNew.ToRepeatIntervalsFormat(), item.Threshold.FirstPerformanceSinceNew ));
			
			//subItem = new ListViewItem.ListViewSubItem { Text = item.PhaseThresh.ToRepeatIntervalsFormat(), Tag = item.PhaseThresh };
			//subItems.Add(subItem);

			subItems.Add(CreateRow(item.Threshold.RepeatInterval.ToRepeatIntervalsFormat(), item.Threshold.RepeatInterval ));
			subItems.Add(CreateRow(phaseString, item.MTOPPhase ));
			
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
						subItems.Add(CreateRow("x", ""));
					else subItems.Add(CreateRow("", "" ));
				}
				else subItems.Add(CreateRow("", "" ));
			}

			subItems.Add(CreateRow(author, author ));

			return subItems;
		}

		#endregion

		//protected override void SetGroupsToItems(int columnIndex)
		//{
		//	itemsListView.Groups.Clear();

		//	if (columnIndex == 3)
		//	{
		//		foreach (ListViewItem item in ListViewItemList.OrderBy(i => ((MaintenanceDirective)i.Tag).MTOPPhase?.FirstPhase ?? int.MaxValue))
		//		{
		//			string temp;

		//			if (item.Tag is MaintenanceDirective)
		//			{
		//				var directive = item.Tag as MaintenanceDirective;

		//				temp = directive.MTOPPhase?.ToString() ?? "1-0-0";
		//				itemsListView.Groups.Add(temp, temp);
		//				item.Group = itemsListView.Groups[temp];
		//			}
		//		}
		//	}
		//}

		#region protected override void SortItems(int columnIndex)

		//protected override void SortItems(int columnIndex)
		//{
		//	if (OldColumnIndex != columnIndex)
		//		SortMultiplier = -1;
		//	if (SortMultiplier == 1)
		//		SortMultiplier = -1;
		//	else
		//		SortMultiplier = 1;
		//	itemsListView.Items.Clear();
		//	SetGroupsToItems(columnIndex);

		//	var resultList = new List<ListViewItem>();

		//	//добавление остальных подзадач
		//	resultList.AddRange(ListViewItemList.Where(item => item.Tag is MaintenanceDirective));
		//	resultList.Sort(new DirectiveListViewComparer(columnIndex, SortMultiplier));

		//	itemsListView.Items.AddRange(resultList.ToArray());
		//	OldColumnIndex = columnIndex;
		//}

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
