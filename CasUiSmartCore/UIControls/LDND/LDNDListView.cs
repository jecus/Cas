﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using Telerik.WinControls.UI;
using Convert = System.Convert;


namespace CAS.UI.UIControls.LDND
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class LDNDListView : BaseGridViewControl<NextPerformance>
	{
		#region public ForecastListView()
		///<summary>
		///</summary>
		public LDNDListView()
		{
			InitializeComponent();
			DisableContectMenu();
			EnableCustomSorting = false;
		}
		#endregion

		#region Methods

		#region protected override void SetHeaders()
		/// <summary>
		/// Устанавливает заголовки
		/// </summary>
		protected override void SetHeaders()
		{
			AddColumn("Item №", (int)(radGridView1.Width * 0.14f));
			AddColumn("Task Card №", (int)(radGridView1.Width * 0.14f));
			AddColumn("Description", (int)(radGridView1.Width * 0.2f));
			AddColumn("Work Type", (int)(radGridView1.Width * 0.2f));
			AddColumn("Thresh", (int)(radGridView1.Width * 0.24f));
			AddColumn("Rpt. Intv.", (int)(radGridView1.Width * 0.20f));
			AddColumn("Next(E)", (int)(radGridView1.Width * 0.15f));
			AddColumn("Next Estimated Data", (int)(radGridView1.Width * 0.2f));
			AddColumn("Remain(E)", (int)(radGridView1.Width * 0.2f));
			AddColumn("Next(L)", (int)(radGridView1.Width * 0.15f));
			AddColumn("Next Limit Data", (int)(radGridView1.Width * 0.2f));
			AddColumn("Remain(L)", (int)(radGridView1.Width * 0.18f));
			AddColumn("Last", (int)(radGridView1.Width * 0.15f));
			AddColumn("Last Data", (int)(radGridView1.Width * 0.2f));	
			AddColumn("Kit", (int)(radGridView1.Width * 0.08f));
			AddColumn("MH", (int)(radGridView1.Width * 0.08f));
			AddColumn("Zone", (int)(radGridView1.Width * 0.16f));
			AddColumn("Work Area", (int)(radGridView1.Width * 0.16f));
			AddColumn("Access", (int)(radGridView1.Width * 0.16f));
			AddColumn("Type", (int)(radGridView1.Width * 0.07f));
			AddColumn("ATA", (int)(radGridView1.Width * 0.10f));
			AddColumn("Check", (int)(radGridView1.Width * 0.2f));
			AddColumn("Extension", (int)(radGridView1.Width * 0.16f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

		#region protected override SetGroupsToItems(int columnIndex)

		protected override void GroupingItems()
		{
			//Grouping("Check");
		}

		#endregion

		#region protected override void SetItemColor(ListViewItem listViewItem, NextPerformance item)
		protected override void SetItemColor(GridViewRowInfo listViewItem, NextPerformance item)
		{
			Color itemForeColor = Color.Black;

			if (item is MaintenanceNextPerformance)
			{
				MaintenanceNextPerformance mnp = item as MaintenanceNextPerformance;
				foreach (GridViewCellInfo cell in listViewItem.Cells)
				{
					cell.Style.CustomizeFill = true;
					cell.Style.ForeColor = mnp == ((MaintenanceCheck)item.Parent).GetPergormanceGroupWhereCheckIsSenior()[0]
						? Color.Black
						: Color.Gray;
				}

				if (mnp.CalcForHight)
				{
					foreach (GridViewCellInfo cell in listViewItem.Cells)
					{
						cell.Style.CustomizeFill = true;
						cell.Style.BackColor = Color.FromArgb(Highlight.PurpleLight.Color);
						if (cell.Style.ForeColor != Color.MediumVioletRed)
							cell.Style.ForeColor = itemForeColor;
					}
				}
			}
			else
			{
				IDirective imd = item.Parent;
				foreach (GridViewCellInfo cell in listViewItem.Cells)
				{
					cell.Style.CustomizeFill = true;
					cell.Style.BackColor = Color.White;
					if (imd.Condition == ConditionState.Notify)
						cell.Style.BackColor = Color.FromArgb(Highlight.Yellow.Color);
					if (imd.Condition == ConditionState.Overdue)
						cell.Style.BackColor = Color.FromArgb(Highlight.Red.Color);
					if (imd.Percents != null && imd.Percents > 0)
						cell.Style.BackColor = Color.FromArgb(Highlight.Green.Color);
					if (cell.Style.ForeColor != Color.MediumVioletRed)
						cell.Style.ForeColor = imd.NextPerformances.IndexOf(item) == 0
						? Color.Black
						: Color.Gray; ;
				}
			}

			
			var itemBacBlackolor = listViewItem.Cells[0].Style.BackColor;
			if (item.Parent is MaintenanceDirective)
			{
				var mpd = item.Parent as MaintenanceDirective;
				if (mpd.IsExtension)
				{
					itemBacBlackolor = Color.DodgerBlue;
					foreach (GridViewCellInfo cell in listViewItem.Cells)
					{
						cell.Style.CustomizeFill = true;
						cell.Style.BackColor = itemBacBlackolor;
					}
				}
			}

			if (item.BlockedByPackage != null)
			{
				foreach (GridViewCellInfo cell in listViewItem.Cells)
				{
					cell.Style.CustomizeFill = true;
					cell.Style.BackColor = Color.FromArgb(Highlight.Grey.Color);
					if (cell.Style.ForeColor != Color.MediumVioletRed)
						cell.Style.ForeColor = itemForeColor;
				}
			}
		}
		#endregion

		#region protected override List<CustomCell> GetListViewSubItems(NextPerformance item)

		protected override List<CustomCell> GetListViewSubItems(NextPerformance item)
		{
			var subItems = new List<CustomCell>();
			var tcnColor = radGridView1.ForeColor;
			var lastComplianceDate = DateTimeExtend.GetCASMinDateTime();
			var lastComplianceLifeLength = Lifelength.Zero;
			string lastPerformanceString, firstPerformanceString = "N/A";
			double manHours = item.Parent is IEngineeringDirective ? ((IEngineeringDirective)item.Parent).ManHours : 0;
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			var title = item.Title;
			var card = "";
			var access = "";
			var workArea = "";
			var zone = "";
			double extension = 0;
			var description = item.Description;
			if (item.Parent is Directive directive)
			{
                title = directive.Title;
				card = directive.EngineeringOrders;
				if (!directive.HasEoFile)
					tcnColor = Color.MediumVioletRed;

				access = directive.DirectiveAccess;
				workArea = directive.Workarea;
				zone = directive.DirectiveZone;
				extension = directive.Extension;
			}
			else if (item.Parent is MaintenanceDirective d)
			{
				if (!d.HasTaskCardFile)
					tcnColor = Color.MediumVioletRed;
				card = d.TaskCardNumber;
				access = d.Access;
				workArea = d.Workarea;
				zone = d.Zone;
				extension = d.Extension;
			}
			else if (item.Parent is ComponentDirective c)
			{
				if (!(bool) c.MaintenanceDirective?.HasTaskCardFile)
					tcnColor = Color.MediumVioletRed;
				description = item.Title;
				title = c.MaintenanceDirective?.TaskNumberCheck ?? "";
				card = c.MaintenanceDirective?.TaskCardNumber ?? "";
				
				access = c.Access;
				workArea = "";
				zone = c.Zone;
				extension = c.Extension;
			}
			//Последнее выполнение
			if (item.Parent.LastPerformance != null &&
			    item.Parent.LastPerformance.RecordDate > lastComplianceDate)
			{
				lastComplianceDate = item.Parent.LastPerformance.RecordDate;
				if (item.Parent is ComponentDirective)
					lastComplianceLifeLength = item.Parent.NextPerformance.LastDataC;
				else lastComplianceLifeLength = item.Parent.LastPerformance.OnLifelength;
			}

			//Следующее выполнение
			if (item.Parent.Threshold.FirstPerformanceSinceNew != null && !item.Parent.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
			{
				firstPerformanceString = "s/n: " + item.Parent.Threshold.FirstPerformanceSinceNew;
			}
			if (item.Parent.Threshold.FirstPerformanceSinceEffectiveDate != null &&
			    !item.Parent.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
			{
				if (firstPerformanceString != "N/A") firstPerformanceString += " or ";
				else firstPerformanceString = "";
				firstPerformanceString += "s/e.d: " + item.Parent.Threshold.FirstPerformanceSinceEffectiveDate;
			}
			var repeatInterval = item.Parent.Threshold.RepeatInterval.ToString();

			if (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
				lastPerformanceString = "N/A";
			else lastPerformanceString = lastComplianceLifeLength.ToString();

			var lastDate = (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
				? ""
				: SmartCore.Auxiliary.Convert.GetDateFormat(lastComplianceDate);

			var condition = !string.IsNullOrEmpty(firstPerformanceString) ? (item.Parent.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst
				? "/WF"
				: "/WL") : "";
			var conditionRepeat = !item.Parent.Threshold.RepeatInterval.IsNullOrZero() ? (item.Parent.Threshold.RepeatPerformanceConditionType == ThresholdConditionType.WhicheverFirst
				? "/WF"
				: "/WL") : "";


			var type = item.Parent.SmartCoreObjectType;
			if (item.Parent is ComponentDirective cd)
			{
				if(cd.FromBaseComponent)
					type = SmartCoreType.BaseComponent;
			}
			else if (item.Parent is MaintenanceDirective md)
			{
				if (md.APUCalc)
				{
					firstPerformanceString = firstPerformanceString.Replace("FH", "AH");
					repeatInterval = repeatInterval.Replace("FH", "AH");
				}
			}

			subItems.Add(CreateRow(title, title));
			subItems.Add(CreateRow(card, card, tcnColor));
			subItems.Add(CreateRow(description, description));
			subItems.Add(CreateRow(item.WorkType, item.WorkType));
			subItems.Add(CreateRow($"{firstPerformanceString} {condition}", firstPerformanceString));
			subItems.Add(CreateRow($"{repeatInterval} {conditionRepeat}", repeatInterval));
			subItems.Add(CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(item.PerformanceDate), item.PerformanceDate));
			subItems.Add(CreateRow(item.PerformanceSource.ToString(), item.PerformanceSource));
			subItems.Add(CreateRow(item.Remains.ToString(), item.Remains));
			subItems.Add(CreateRow(item.NextLimit.Days != null ? SmartCore.Auxiliary.Convert.GetDateFormat(item.NextPerformanceDateNew) : "", item.NextPerformanceDateNew));
			subItems.Add(CreateRow(item.NextLimit.ToString(), item.NextLimit.ToString()));
			subItems.Add(CreateRow(item.RemainLimit.ToString(), item.RemainLimit.ToString()));
			subItems.Add(CreateRow(lastDate, lastComplianceDate));
			subItems.Add(CreateRow(lastPerformanceString, lastComplianceLifeLength));
			subItems.Add(CreateRow(item.KitsToString, item.Kits?.Count));
			subItems.Add(CreateRow(manHours.ToString(), manHours));
			subItems.Add(CreateRow(zone, zone));
			subItems.Add(CreateRow(workArea, workArea));
			subItems.Add(CreateRow(access, access));
			subItems.Add(CreateRow(type.ToString(), type.SmartCoreObjectType));
			subItems.Add(CreateRow(item.ATAChapter?.ToString(), item.ATAChapter));
			subItems.Add(CreateRow(item.MaintenanceCheck != null ? item.MaintenanceCheck.ToString() : "", item.MaintenanceCheck));
			subItems.Add(CreateRow(extension.ToString("F0"), extension));
			subItems.Add(CreateRow(author, author));

			return subItems;
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem == null) return;

			var dp = ScreenAndFormManager.GetEditScreenOrForm(SelectedItem);
			if (dp.DisplayerType == DisplayerType.Screen)
				e.SetParameters(dp);
			else
				dp.Form.ShowDialog();
		}
		#endregion

		protected override void CustomSort(int ColumnIndex)
		{
			if (OldColumnIndex != ColumnIndex)
				SortDirection = SortDirection.Asc;
			if (SortDirection == SortDirection.Desc)
				SortDirection = SortDirection.Asc;
			else
				SortDirection = SortDirection.Desc;

			OldColumnIndex = ColumnIndex;
			var resultList = new List<NextPerformance>();
			var list = radGridView1.Rows.Select(i => i).ToList();
			list.Sort(new GridViewDataRowInfoComparer(ColumnIndex, Convert.ToInt32(SortDirection)));

			resultList.AddRange(list.Select(i => i.Tag as NextPerformance));

			SetItemsArray(resultList.ToArray());
		}

		#endregion
	}

}
