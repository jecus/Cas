using System.Collections.Generic;
using System.Linq;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Calculations;
using SmartCore.Calculations.MTOP;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.MTOP;

namespace CAS.UI.UIControls.MTOP
{
	public partial class MTOPDirectiveListView : BaseGridViewControl<IMtopCalc>
	{
		private Dictionary<int, Lifelength> _groupLifelengths;
		private readonly List<MTOPCheck> _maintenanceChecks;
		private bool _isZeroPhase;
		private int _start;

		#region Constructor

		public MTOPDirectiveListView(Dictionary<int, Lifelength> groupLifelengths, List<MTOPCheck> maintenanceChecks)
		{
			InitializeComponent();
			DisableContectMenu();

			_groupLifelengths = groupLifelengths;
			_maintenanceChecks = maintenanceChecks;
			_isZeroPhase = maintenanceChecks.All(i => i.IsZeroPhase);
			SortDirection = SortDirection.Asc;

			foreach (var check in _maintenanceChecks)
			{
				var last = check.PerformanceRecords.OrderByDescending(i => i.RecordDate).FirstOrDefault();
				if (last == null) continue;

				if (_start < last.GroupName)
					_start = last.GroupName;

			}
			SetHeaders();
		}

		#endregion

		#region protected override SetGroupsToItems(int columnIndex)

		protected override void GroupingItems()
		{
			Grouping("Type");
		}

		#endregion

		#region protected override void SetHeaders()

		protected override void SetHeaders()
		{
			if (_groupLifelengths == null)
				return;
			AddColumn("Type", (int)(radGridView1.Width * 0.10f));
			AddColumn("Item №", (int)(radGridView1.Width * 0.16f));
			AddColumn("Task Card №", (int)(radGridView1.Width * 0.16f));
			AddColumn("Description", (int)(radGridView1.Width * 0.16f));
			AddColumn("Thresh", (int)(radGridView1.Width * 0.16f));
			AddColumn("Repeat", (int)(radGridView1.Width * 0.16f));
			AddColumn("Phase", (int)(radGridView1.Width * 0.10f));


			foreach (var lifelength in _groupLifelengths)
			{
				if (lifelength.Key <= _start)
					continue;

				if (lifelength.Key >= _start + 50)
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
				var text = _isZeroPhase ? $"0{lifelength.Key}" : lifelength.Key.ToString();

				AddColumn(text, width);
			}
			AddColumn("Signer", (int)(radGridView1.Width * 0.03f));
			radGridView1.Columns.AddRange(ColumnHeaderList.ToArray());
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(MTOPCheck item)

		protected override List<CustomCell> GetListViewSubItems(IMtopCalc item)
		{
			var subItems = new List<CustomCell>();

			var phaseString = "";
			if (item.MTOPPhase != null)
				phaseString = item.MTOPPhase.ToString();
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);

			var title = "";
			var card = "";
			var description = "";
			if (item is MaintenanceDirective mpd)
			{
				title = mpd.Title;
				card = mpd.TaskCardNumber;
				description = mpd.Description;
			}
			else if (item is Directive d)
			{
				if (d.DirectiveType == DirectiveType.AirworthenessDirectives)
					title = d.Title;
				else if (d.DirectiveType == DirectiveType.SB)
					title = d.ServiceBulletinNo;
				else if (d.DirectiveType == DirectiveType.EngineeringOrders)
					title = d.EngineeringOrders;
				card = d.EngineeringOrders;
				description = d.Description;
			}
			else if(item is ComponentDirective c)
			{
				description = c.ParentComponent.ToString();
				title = c.MaintenanceDirective?.TaskNumberCheck ?? "";
				card = c.MaintenanceDirective?.TaskCardNumber ?? "";
			}



			subItems.Add(CreateRow(item.SmartCoreObjectType.ToString(), item.SmartCoreObjectType));
			subItems.Add(CreateRow(title, title));
			subItems.Add(CreateRow(card, card));
			subItems.Add(CreateRow(description, description));
			var thresh = !item.Threshold.FirstPerformanceSinceNew.IsNullOrZero()
				? item.Threshold.FirstPerformanceSinceNew
				: item.Threshold.FirstPerformanceSinceEffectiveDate;
			subItems.Add(CreateRow(thresh.ToRepeatIntervalsFormat(), thresh));

			//subItem = new ListViewItem.ListViewSubItem { Text = item.PhaseThresh.ToRepeatIntervalsFormat(), Tag = item.PhaseThresh };
			//subItems.Add(subItem);
			
			subItems.Add(CreateRow(item.Threshold.RepeatInterval.ToRepeatIntervalsFormat(), item.Threshold.RepeatInterval));
			subItems.Add(CreateRow(phaseString, item.MTOPPhase));

			var temp = 0;

			foreach (var lifelength in _groupLifelengths)
			{
				if (lifelength.Key <= _start)
					continue;

				if (lifelength.Key >= _start + 50)
					continue;

				if (item.MTOPPhase != null)
				{
					if (item.MTOPPhase.Difference > 0 && lifelength.Key % item.MTOPPhase.Difference == 0)
						subItems.Add(CreateRow("x", ""));
					else subItems.Add(CreateRow("", ""));
				}
				else subItems.Add(CreateRow("", ""));
			}

			subItems.Add(CreateRow(author, author));

			return subItems;
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem != null)
			{
				if (SelectedItem is MaintenanceDirective)
				{
					var dp = ScreenAndFormManager.GetMaintenanceDirectiveScreen(SelectedItem as MaintenanceDirective);
					e.SetParameters(dp);
				}
				else if (SelectedItem is Directive)
				{
					var dp = ScreenAndFormManager.GetDirectiveScreen(SelectedItem as Directive);
					e.SetParameters(dp);
				}
				else if (SelectedItem is ComponentDirective c)
				{
					if (c.MaintenanceDirective != null)
					{
						var dp = ScreenAndFormManager.GetComponentDirectiveScreen(SelectedItem as ComponentDirective);
						e.SetParameters(dp);
					}
					else
					{
						var dp = ScreenAndFormManager.GetMaintenanceDirectiveScreen(c.MaintenanceDirective);
						e.SetParameters(dp);
					}
				}
				else e.Cancel = true;
			}
		}

		#endregion
	}
}
