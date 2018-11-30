using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.General.MTOP;

namespace CAS.UI.UIControls.MTOP
{
	public partial class MTOPSummary : UserControl
	{
		#region Constructor

		public MTOPSummary()
		{
			InitializeComponent();
		}

		#endregion

		public void UpdateControl(List<MTOPCheck> maintenanceChecks,
			Dictionary<int, Lifelength> groupLifelengths,
			Dictionary<int, Lifelength> groupLifelengthsZeroPhase)
		{
			
			UpdateSchedule(maintenanceChecks.Where(i => !i.IsZeroPhase).OrderBy(i => i.PhaseThresh.Hours).ToList(), groupLifelengths);

			var aCheck = maintenanceChecks.Where(i => !i.IsZeroPhase).OrderBy(i => i.PhaseThresh.Hours).FirstOrDefault();

			UpdateScheduleZeroPhase(maintenanceChecks.Where(i => i.IsZeroPhase).OrderBy(i => i.PhaseThresh.Hours).ToList(), groupLifelengthsZeroPhase, aCheck);
			UpdateNotify(maintenanceChecks);
			listViewLastCheck.Items.Clear();
			listViewNextCheck.Items.Clear();

			ListViewItem newItem;
			string[] subs;

			foreach (var check in maintenanceChecks)
			{
				string perfDate = "";
				if (check.NextPerformance?.PerformanceDate != null)
					perfDate = UsefulMethods.NormalizeDate(check.NextPerformance.PerformanceDate.Value);

				var group = "";

				if(check.NextPerformance != null)
					group = check.NextPerformance.ParentCheck.IsZeroPhase ? $"0{check.NextPerformance?.Group}" : check.NextPerformance?.Group.ToString();

				subs = new[]  {
					check.Name,
					group,
					perfDate,
					check.NextPerformance?.PerformanceSource.ToRepeatIntervalsFormat(),
					check.NextPerformance?.Remains.ToString()
				};

				listViewNextCheck.Groups.Add(check.CheckType.FullName, check.CheckType.FullName);

				newItem = new ListViewItem(subs)
				{
					Tag = check,
					Group = listViewNextCheck.Groups[check.CheckType.FullName]
				};
				listViewNextCheck.Items.Add(newItem);


				if (check.PerformanceRecords.Count > 0)
				{
					var lastRecord = check.PerformanceRecords.OrderByDescending(i => i.ItemId).First();

					group = lastRecord.Parent.IsZeroPhase ? $"0{lastRecord.GroupName}" : lastRecord.GroupName.ToString();

					subs = new[]  {
						lastRecord.CheckName,
						group,
						UsefulMethods.NormalizeDate(lastRecord.RecordDate),
						lastRecord.CalculatedPerformanceSource.ToRepeatIntervalsFormat()
					};

					listViewLastCheck.Groups.Add(check.CheckType.FullName, check.CheckType.FullName);

					newItem = new ListViewItem(subs)
					{
						Group = listViewLastCheck.Groups[check.CheckType.FullName],
						Tag = lastRecord
					};

					listViewLastCheck.Items.Add(newItem);
				}
			}
		}

		private void UpdateSchedule(List<MTOPCheck> maintenanceChecks, Dictionary<int, Lifelength> groupLifelengths)
		{
			listViewSchedule.Items.Clear();
			listViewSchedule.Columns.Clear();

			int from;
			int to;
			MTOPCheck firstCheck;
			MTOPCheck secondCheck = null;


			if (maintenanceChecks.Count > 1)
			{
				firstCheck = maintenanceChecks.First();
				secondCheck = maintenanceChecks.Last();

				from = firstCheck.NextPerformance?.Group ?? groupLifelengths.Count;
				to = secondCheck.NextPerformance?.Group ?? groupLifelengths.Count;
			}
			else if (maintenanceChecks.Count == 1)
			{
				firstCheck = maintenanceChecks.First();
				if (firstCheck.PerformanceRecords.Any())
				{
					from = firstCheck.PerformanceRecords.OrderBy(i => i.GroupName).First().GroupName;
					to = firstCheck.NextPerformance?.Group ?? groupLifelengths.Count;
				}
				else
				{
					from = firstCheck.NextPerformance?.Group ?? groupLifelengths.Count;
					to = firstCheck.NextPerformances.Count > 0 ? firstCheck.NextPerformances[1].Group : groupLifelengths.Count;
				}
			}
			else return;


			listViewSchedule.Columns.Add("Group", 60);
			listViewSchedule.Columns.Add("Repeat", 120);

			foreach (var lifelength in groupLifelengths)
			{
				string header;

				if (lifelength.Key < from)
					continue;

				if (lifelength.Key > to)
					continue;

				if (lifelength.Key == from)
					header = $"{firstCheck.Name}({lifelength.Key}) {firstCheck.NextPerformance?.PerformanceSource.Hours}FH";
				else if (secondCheck != null && lifelength.Key == secondCheck.Group)
					header = $"{secondCheck.Name}({lifelength.Key}) {lifelength.Value.Hours}FH";
				else header = $"{firstCheck.Name}({lifelength.Key}) {lifelength.Value.Hours}FH";


				listViewSchedule.Columns.Add(header, 120);
			}

			foreach (var item in maintenanceChecks)
			{
				var subItems = new List<ListViewItem.ListViewSubItem>();

				var startFrom = item.NextPerformance?.Group ?? groupLifelengths.Count;
				var tempHours = groupLifelengths.ContainsKey(startFrom) ? groupLifelengths[startFrom].Days : groupLifelengths[item.Group].Days;

				var subItem = new ListViewItem.ListViewSubItem { Text = item.Name };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = item.Repeat.ToRepeatIntervalsFormat() };
				subItems.Add(subItem);

				foreach (var lifelength in groupLifelengths)
				{
					if (lifelength.Key < from)
						continue;

					if (lifelength.Key > to)
						continue;

					if (tempHours == lifelength.Value.Days)
					{
						if (item.PhaseRepeat != null && !item.PhaseRepeat.IsNullOrZero())
							tempHours += item.PhaseRepeat.Days;
						else tempHours += item.PhaseThresh.Days;

						subItem = new ListViewItem.ListViewSubItem { Text = "x", Tag = "" };

					}
					else subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };

					subItems.Add(subItem);
				}

				listViewSchedule.Groups.Add(item.CheckType.FullName, item.CheckType.FullName);
				var newItem = new ListViewItem(subItems.ToArray(), null)
				{
					Group = listViewSchedule.Groups[item.CheckType.FullName]
				};

				listViewSchedule.Items.Add(newItem);
			}
		}

		private void UpdateScheduleZeroPhase(List<MTOPCheck> maintenanceChecks, Dictionary<int, Lifelength> groupLifelengths,
			MTOPCheck aCheck)
		{
			listViewScheduleZero.Items.Clear();
			listViewScheduleZero.Columns.Clear();

			int from;
			int to = 0;
			MTOPCheck firstCheck;
			MTOPCheck secondCheck = null;

			if (aCheck != null && groupLifelengths.Count > 0 && aCheck.NextPerformance != null)
				to = (int)(aCheck.NextPerformance.PerformanceSource.Days / groupLifelengths[1].Days);

			if (maintenanceChecks.Count > 1)
			{
				firstCheck = maintenanceChecks.First();
				secondCheck = maintenanceChecks.Last();

				from = firstCheck.NextPerformance?.Group ?? groupLifelengths.Count;
				to = to > 0 ? to : secondCheck.NextPerformance?.Group ?? groupLifelengths.Count;
			}
			else if (maintenanceChecks.Count == 1)
			{
				firstCheck = maintenanceChecks.First();
				if (firstCheck.PerformanceRecords.Any())
				{
					from = firstCheck.PerformanceRecords.OrderBy(i => i.GroupName).First().GroupName;
					to = to > 0 ? to : firstCheck.NextPerformance?.Group ?? groupLifelengths.Count;
				}
				else
				{
					from = firstCheck.NextPerformance?.Group ?? groupLifelengths.Count;
					to = to > 0 ? to : firstCheck.NextPerformances?.Count > 0 ? firstCheck.NextPerformances[1].Group : groupLifelengths.Count;
				}
			}
			else return;

			
			listViewScheduleZero.Columns.Add("Group", 60);
			listViewScheduleZero.Columns.Add("Repeat", 120);

			foreach (var lifelength in groupLifelengths)
			{
				string header;

				if (lifelength.Key < from)
					continue;

				if (lifelength.Key > to)
					continue;

				if (lifelength.Key == from)
					header = $"{firstCheck.Name}(0{lifelength.Key}) {firstCheck.NextPerformance?.PerformanceSource.Hours}FH";
				else if (secondCheck != null && lifelength.Key == secondCheck.Group)
					header = $"{secondCheck.Name}(0{lifelength.Key}) {lifelength.Value.Hours}FH";
				else header = $"{firstCheck.Name}(0{lifelength.Key}) {lifelength.Value.Hours}FH";


				listViewScheduleZero.Columns.Add(header, 120);
			}

			foreach (var item in maintenanceChecks)
			{
				var subItems = new List<ListViewItem.ListViewSubItem>();

				var startFrom = item.NextPerformance?.Group ?? groupLifelengths.Count;
				var tempHours = groupLifelengths.ContainsKey(startFrom) ? groupLifelengths[startFrom].Days : groupLifelengths[item.Group].Days;

				var subItem = new ListViewItem.ListViewSubItem { Text = item.Name };
				subItems.Add(subItem);

				subItem = new ListViewItem.ListViewSubItem { Text = item.Repeat.ToRepeatIntervalsFormat() };
				subItems.Add(subItem);

				foreach (var lifelength in groupLifelengths)
				{
					if (lifelength.Key < from)
						continue;

					if (lifelength.Key > to)
						continue;

					if (tempHours == lifelength.Value.Days)
					{
						if (item.PhaseRepeat != null && !item.PhaseRepeat.IsNullOrZero())
							tempHours += item.PhaseRepeat.Days;
						else tempHours += item.PhaseThresh.Days;

						subItem = new ListViewItem.ListViewSubItem { Text = "x", Tag = "" };

					}
					else subItem = new ListViewItem.ListViewSubItem { Text = "", Tag = "" };

					subItems.Add(subItem);
				}

				listViewScheduleZero.Groups.Add(item.CheckType.FullName, item.CheckType.FullName);
				var newItem = new ListViewItem(subItems.ToArray(), null)
				{
					Group = listViewScheduleZero.Groups[item.CheckType.FullName]
				};

				listViewScheduleZero.Items.Add(newItem);
			}
		}

		private void UpdateNotify(List<MTOPCheck> maintenanceChecks)
		{
			listViewNotify.Items.Clear();

			ListViewItem newItem;
			string[] subs;

			foreach (var check in maintenanceChecks)
			{
				var nextPerformance = check.NextPerformance;
				listViewNotify.Groups.Add(check.CheckType.FullName, check.CheckType.FullName);
				
				if (check.PerformanceRecords.Count > 0)
				{
					var lastCompliance = check.PerformanceRecords.OrderByDescending(i => i.ItemId).First();
					var lastGroup = lastCompliance.Parent.IsZeroPhase ? $"0{lastCompliance.GroupName}" : lastCompliance.GroupName.ToString();
					var checkGroup = check.IsZeroPhase ? $"0{check.Group}" : check.Group.ToString();


					subs = new[]  {
						check.Name,
						UsefulMethods.NormalizeDate(lastCompliance.RecordDate),
						lastCompliance.CalculatedPerformanceSource.ToRepeatIntervalsFormat(),
						lastGroup,
						$"{lastGroup}{lastCompliance.CheckName}",
						nextPerformance?.PerformanceDate != null ? UsefulMethods.NormalizeDate(nextPerformance.PerformanceDate.Value) : "",
						nextPerformance?.PerformanceSource.ToRepeatIntervalsFormat(),
						checkGroup,
						$"{checkGroup}{check.Name}",
						check.NextPerformance?.Remains.ToString()
					};

					newItem = new ListViewItem(subs)
					{
						Tag = check,
						Group = listViewNotify.Groups[check.CheckType.FullName]
					};
					listViewNotify.Items.Add(newItem);

				}
				else
				{
					string perfDate = "";
					if (nextPerformance?.PerformanceDate != null)
						perfDate = UsefulMethods.NormalizeDate(nextPerformance.PerformanceDate.Value);

					var group = "";
					if (check.NextPerformance != null)
						group = check.NextPerformance.ParentCheck.IsZeroPhase ? $"0{check.NextPerformance?.Group}" : check.NextPerformance?.Group.ToString();


					subs = new[]  {
						check.Name,
						"",
						"",
						"",
						"",
						perfDate,
						nextPerformance?.PerformanceSource.ToRepeatIntervalsFormat(),
						group,
						$"{group}{check.Name}",
						check.NextPerformance?.Remains.ToString()
					};

					newItem = new ListViewItem(subs)
					{
						Tag = check,
						Group = listViewNotify.Groups[check.CheckType.FullName]
					};
					listViewNotify.Items.Add(newItem);
				}
			}
		}
	}
}
