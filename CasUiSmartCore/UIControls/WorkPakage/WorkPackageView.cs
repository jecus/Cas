using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using EntityCore.DTO.Dictionaries;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using Telerik.WinControls.UI;
using Component = SmartCore.Entities.General.Accessory.Component;
using Convert = System.Convert;

namespace CAS.UI.UIControls.WorkPakage
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class WorkPackageView : BaseGridViewControl<BaseEntityObject>
	{
		#region Fields

		private WorkPackage _currentWorkPackage;

		#endregion

		#region Constructors

		#region private WorkPackageView()
		///<summary>
		///</summary>
		private WorkPackageView()
		{
			InitializeComponent();
		}
		#endregion

		#region public WorkPackageView()
		///<summary>
		///</summary>
		public WorkPackageView(WorkPackage currentWorkPackage) : this ()
		{
			_currentWorkPackage = currentWorkPackage;
			EnableCustomSorting = true;
			SortDirection = SortDirection.Asc;
			OldColumnIndex = 6;
		}
		#endregion

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
			AddColumn("MH", (int)(radGridView1.Width * 0.12f));
			AddColumn("K*MH", (int)(radGridView1.Width * 0.12f));
			AddColumn("Cost", (int)(radGridView1.Width * 0.12f));
			AddColumn("Zone", (int)(radGridView1.Width * 0.16f));
			AddColumn("Work Area", (int)(radGridView1.Width * 0.16f));
			AddColumn("Access", (int)(radGridView1.Width * 0.16f));
			AddColumn("Type", (int)(radGridView1.Width * 0.07f));
			AddColumn("ATA", (int)(radGridView1.Width * 0.10f));
			AddColumn("Check", (int)(radGridView1.Width * 0.2f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

		#region protected override SetGroupsToItems(int columnIndex)

		//protected override void GroupingItems()
		//{
		//	Grouping("Type");
		//}
		#endregion

		#region protected override void SetItemColor(ListViewItem listViewItem, BaseSmartCoreObject item)
		protected override void SetItemColor(GridViewRowInfo listViewItem, BaseEntityObject item)
		{
			//listViewItem.ToolTipText = GetToolTipString(item);

			if (item is NextPerformance)
			{
				var nextPerformance = item as NextPerformance;

				var file = GetItemFile(nextPerformance.Parent);

				if (file != null)
				{
					if (_currentWorkPackage.Status != WorkPackageStatus.Closed)
					{
						var color = radGridView1.BackColor;
						if (nextPerformance.BlockedByPackage != null)
							color = Color.FromArgb(Highlight.Grey.Color);
						else if (nextPerformance.Condition == ConditionState.Notify)
							color = Color.FromArgb(Highlight.Yellow.Color);
						else if (nextPerformance.Condition == ConditionState.Overdue)
							color = Color.FromArgb(Highlight.Red.Color);

						foreach (GridViewCellInfo cell in listViewItem.Cells)
						{
							cell.Style.CustomizeFill = true;
							cell.Style.BackColor = color;
						}
					}
					else
					{
						//Если это следующее выполнение, но рабочий пакет при этом закрыт
						//значит, выполнение для данной задачи в рамках данного рабочего пакета
						//не было введено
						//пометка этого выполнения краным цветом
						foreach (GridViewCellInfo cell in listViewItem.Cells)
						{
							cell.Style.CustomizeFill = true;
							cell.Style.BackColor = Color.FromArgb(Highlight.Red.Color);
						}
					}
					if (nextPerformance.Parent.IsDeleted)
					{
						//запись так же может быть удаленной
						//шрифт серым цветом
						foreach (GridViewCellInfo cell in listViewItem.Cells)
						{
							cell.Style.CustomizeFill = true;
							cell.Style.ForeColor = Color.Gray;
						}
					}
				}
				else
				{
					for (int i = 0; i < listViewItem.Cells.Count; i++)
					{
						listViewItem.Cells[i].Style.CustomizeFill = true;
						if (_currentWorkPackage.Status != WorkPackageStatus.Closed)
						{
							if (nextPerformance.BlockedByPackage != null)
								listViewItem.Cells[i].Style.BackColor = Color.FromArgb(Highlight.Grey.Color);
							else if (nextPerformance.Condition == ConditionState.Notify)
								listViewItem.Cells[i].Style.BackColor = Color.FromArgb(Highlight.Yellow.Color);
							else if (nextPerformance.Condition == ConditionState.Overdue)
								listViewItem.Cells[i].Style.BackColor = Color.FromArgb(Highlight.Red.Color);
						}
						else
							listViewItem.Cells[i].Style.BackColor = Color.FromArgb(Highlight.Red.Color);

						if (nextPerformance.Parent.IsDeleted)
							listViewItem.Cells[i].Style.ForeColor = Color.Gray;

						if (i == 2)
							listViewItem.Cells[i].Style.ForeColor = Color.MediumVioletRed;
					}
				}
			}
			else if (item is AbstractPerformanceRecord)
			{
				var apr = (AbstractPerformanceRecord)item;

				var file = GetItemFile(apr.Parent);

				if (file != null)
				{
					if (apr.Parent.IsDeleted)
					{
						foreach (GridViewCellInfo cell in listViewItem.Cells)
						{
							cell.Style.CustomizeFill = true;
							cell.Style.ForeColor = Color.Gray;
						}
					}
				}
				else
				{
					for (int i = 0; i < listViewItem.Cells.Count; i++)
					{
						listViewItem.Cells[i].Style.CustomizeFill = true;
						if (apr.Parent.IsDeleted)
							listViewItem.Cells[i].Style.ForeColor = Color.Gray;

						if (i == 2)
							listViewItem.Cells[i].Style.ForeColor = Color.MediumVioletRed;
					}
				}
			}
			else
			{
				var file = GetItemFile(item);

				if (file != null)
				{
					if (!(item is NonRoutineJob))
					{
						//Если это не следующее выполнение, не запись о выполнении, и не рутинная работа
						//значит, выполнение для данной задачи расчитать нельзя
						//пометка этого выполнения синим цветом
						foreach (GridViewCellInfo cell in listViewItem.Cells)
						{
							cell.Style.CustomizeFill = true;
							cell.Style.BackColor = Color.FromArgb(Highlight.Blue.Color);
						}
					}

					if (item.IsDeleted)
					{
						foreach (GridViewCellInfo cell in listViewItem.Cells)
						{
							cell.Style.CustomizeFill = true;
							cell.Style.ForeColor = Color.Gray;
						}
					}
				}
				else
				{
					for (int i = 0; i < listViewItem.Cells.Count; i++)
					{
						listViewItem.Cells[i].Style.CustomizeFill = true;
						if (!(item is NonRoutineJob))
						{
							//Если это не следующее выполнение, не запись о выполнении, и не рутинная работа
							//значит, выполнение для данной задачи расчитать нельзя

							//пометка этого выполнения синим цветом
							listViewItem.Cells[i].Style.BackColor = Color.FromArgb(Highlight.Blue.Color);
						}

						if (item.IsDeleted)
							listViewItem.Cells[i].Style.ForeColor = Color.Gray;

						if (i == 2)
							listViewItem.Cells[i].Style.ForeColor = Color.MediumVioletRed;
					}
				}
			}
		}
		#endregion

		#region private AttachedFile GetItemFile(IBaseEntityObject obj)

		private AttachedFile GetItemFile(IBaseEntityObject obj)
		{
			if (obj is Directive)
				return ((Directive)obj).EngineeringOrderFile;
			if (obj is MaintenanceDirective)
				return ((MaintenanceDirective)obj).TaskCardNumberFile;
			if (obj is NonRoutineJob)
				return ((NonRoutineJob)obj).AttachedFile;
			if (obj is ComponentDirective)
				return ((ComponentDirective)obj).MaintenanceDirective?.TaskCardNumberFile;

			return null;
		}

		#endregion

		#region private string GetToolTipString(IBaseEntityObject obj)

		private string GetToolTipString(IBaseEntityObject obj)
		{
			var toolTip = "";
			IBaseEntityObject parent = null;
			if (obj is NextPerformance)
			{
				var nextPerformance = obj as NextPerformance;
				parent = nextPerformance.Parent;
				if (_currentWorkPackage.Status != WorkPackageStatus.Closed)
				{
					if (nextPerformance.BlockedByPackage != null)
						toolTip = $"This performance blocked by work package: {nextPerformance.BlockedByPackage.Title}";
				}
				else
				{
					toolTip = "Performance for this directive within this work package is not entered.";
					if (nextPerformance.BlockedByPackage != null)
					{
						toolTip += "\nThis performance blocked by work package:" +
								   nextPerformance.BlockedByPackage.Title +
								   "\nFirst, enter the performance of this directive as part of this work package ";
					}
				}
			}
			else if (obj is AbstractPerformanceRecord)
			{
				parent = ((AbstractPerformanceRecord)obj).Parent;
			}
			else
			{
				parent = obj;
				if (!(obj is NonRoutineJob))
					toolTip = "Performance for this directive can not be calculated";
			}

			if (parent.IsDeleted)
			{
				if (toolTip.Trim() != "")
					toolTip += "\n";
				toolTip += $"This {parent.SmartCoreObjectType} is deleted";
			}

			return toolTip;
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(BaseSmartCoreObject item)

		protected override List<CustomCell> GetListViewSubItems(BaseEntityObject item)
		{
			var subItems = new List<CustomCell>();
			var author = "";
			if (item is NextPerformance)
			{
				var np = (NextPerformance) item;
				var manHours = np.Parent is IEngineeringDirective ? ((IEngineeringDirective)np.Parent).ManHours : 0;
				var KmanHours = manHours*_currentWorkPackage.KMH;
				var cost = np.Parent is IEngineeringDirective ? ((IEngineeringDirective)np.Parent).Cost : 0;
				var lastComplianceDate = DateTimeExtend.GetCASMinDateTime();
				var lastComplianceLifeLength = Lifelength.Zero;
				string lastPerformanceString, firstPerformanceString = "N/A";
				author = GlobalObjects.CasEnvironment.GetCorrector(np);
				var title = np.Title;
				var card = "";
				var access = "";
				var workArea = "";
				var zone = "";
				var description = np.Description;

				if (np.Parent is Directive directive)
				{
					title = directive.EngineeringOrders;
					access = directive.DirectiveAccess;
					workArea = directive.Workarea;
					zone = directive.DirectiveZone;
				}
				else if (np.Parent is MaintenanceDirective d)
				{
					card = d.TaskCardNumber;
					access = d.Access;
					workArea = d.Workarea;
					zone = d.Zone;
				}
				else if (np.Parent is ComponentDirective c)
				{
					description = np.Title;
					title = c.MaintenanceDirective?.TaskNumberCheck ?? "";
					card = c.MaintenanceDirective?.TaskCardNumber ?? "";
					access = c.Access;
					workArea = "";
					zone = c.Zone;
				}

				//Последнее выполнение
				if (np.Parent.LastPerformance != null &&
				    np.Parent.LastPerformance.RecordDate > lastComplianceDate)
				{
					lastComplianceDate = np.Parent.LastPerformance.RecordDate;
					lastComplianceLifeLength = np.Parent.LastPerformance.OnLifelength;
				}

				//Следующее выполнение
				if (np.Parent.Threshold.FirstPerformanceSinceNew != null && !np.Parent.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
				{
					firstPerformanceString = "s/n: " + np.Parent.Threshold.FirstPerformanceSinceNew;
				}
				if (np.Parent.Threshold.FirstPerformanceSinceEffectiveDate != null &&
					!np.Parent.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
				{
					if (firstPerformanceString != "N/A") firstPerformanceString += " or ";
					else firstPerformanceString = "";
					firstPerformanceString += "s/e.d: " + np.Parent.Threshold.FirstPerformanceSinceEffectiveDate;
				}
				var repeatInterval = np.Parent.Threshold.RepeatInterval;

				if (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
					lastPerformanceString = "N/A";
				else lastPerformanceString = lastComplianceLifeLength.ToString();

				var lastDate = (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
					? ""
					: SmartCore.Auxiliary.Convert.GetDateFormat(lastComplianceDate);

				var condition = !string.IsNullOrEmpty(firstPerformanceString) ? (np.Parent.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst
					? "/WF"
					: "/WL") : "";
				var conditionRepeat = !np.Parent.Threshold.RepeatInterval.IsNullOrZero() ? (np.Parent.Threshold.RepeatPerformanceConditionType == ThresholdConditionType.WhicheverFirst
					? "/WF"
					: "/WL") : "";

				subItems.Add(CreateRow(title, title));
				subItems.Add(CreateRow(card, card));
				subItems.Add(CreateRow(description, description));
				subItems.Add(CreateRow(np.WorkType, np.WorkType));
				subItems.Add(CreateRow($"{firstPerformanceString} {condition}", firstPerformanceString));
				subItems.Add(CreateRow($"{repeatInterval} {conditionRepeat}", repeatInterval));
				subItems.Add(CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(np.PerformanceDate), np.PerformanceDate));
				subItems.Add(CreateRow(np.PerformanceSource.ToString(), np.PerformanceSource));
				subItems.Add(CreateRow(np.Remains.ToString(), np.Remains));
				subItems.Add(CreateRow(np.NextLimit.Days != null ? SmartCore.Auxiliary.Convert.GetDateFormat(np.NextPerformanceDateNew) : "", np.NextPerformanceDateNew));
				subItems.Add(CreateRow(np.NextLimit.ToString(), np.NextLimit.ToString()));
				subItems.Add(CreateRow(np.RemainLimit.ToString(), np.RemainLimit.ToString()));
				subItems.Add(CreateRow(lastDate, lastComplianceDate));
				subItems.Add(CreateRow(lastPerformanceString, lastComplianceLifeLength));
				subItems.Add(CreateRow(np.KitsToString, np.Kits?.Count));
				subItems.Add(CreateRow(manHours.ToString(), manHours));
				subItems.Add(CreateRow(KmanHours.ToString("F"), KmanHours));
				subItems.Add(CreateRow(cost.ToString(), cost));
				subItems.Add(CreateRow(zone, zone));
				subItems.Add(CreateRow(workArea, workArea));
				subItems.Add(CreateRow(access, access));
				subItems.Add(CreateRow(np.Parent.SmartCoreObjectType.ToString(), np.Parent.SmartCoreObjectType));
				subItems.Add(CreateRow(np.ATAChapter?.ToString(), np.ATAChapter));
				subItems.Add(CreateRow(np.MaintenanceCheck != null ? np.MaintenanceCheck.ToString() : "", np.MaintenanceCheck));
				subItems.Add(CreateRow(author, author));
			}

			else if (item is AbstractPerformanceRecord)
			{
				var apr = (AbstractPerformanceRecord)item;
				var manHours = apr.Parent is IEngineeringDirective ? ((IEngineeringDirective)apr.Parent).ManHours : 0;
				var KmanHours = manHours * _currentWorkPackage.KMH;
				var cost = apr.Parent is IEngineeringDirective ? ((IEngineeringDirective)apr.Parent).Cost : 0;
				var lastComplianceDate = DateTimeExtend.GetCASMinDateTime();
				var lastComplianceLifeLength = Lifelength.Zero;
				string lastPerformanceString, firstPerformanceString = "N/A";
				author = GlobalObjects.CasEnvironment.GetCorrector(apr);
				var title = apr.Title;
				var card = "";
				var access = "";
				var workArea = "";
				var zone = "";
				var description = apr.Description;
				
				//Последнее выполнение
				if (apr.Parent.LastPerformance != null &&
				    apr.Parent.LastPerformance.RecordDate > lastComplianceDate)
				{
					lastComplianceDate = apr.Parent.LastPerformance.RecordDate;
					lastComplianceLifeLength = apr.Parent.LastPerformance.OnLifelength;
				}

				//Следующее выполнение
				if (apr.Parent.Threshold.FirstPerformanceSinceNew != null && !apr.Parent.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
				{
					firstPerformanceString = "s/n: " + apr.Parent.Threshold.FirstPerformanceSinceNew;
				}
				if (apr.Parent.Threshold.FirstPerformanceSinceEffectiveDate != null &&
					!apr.Parent.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
				{
					if (firstPerformanceString != "N/A") firstPerformanceString += " or ";
					else firstPerformanceString = "";
					firstPerformanceString += "s/e.d: " + apr.Parent.Threshold.FirstPerformanceSinceEffectiveDate;
				}
				var repeatInterval = apr.Parent.Threshold.RepeatInterval;

				if (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
					lastPerformanceString = "N/A";
				else lastPerformanceString = lastComplianceLifeLength.ToString();

				var lastDate = (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
					? ""
					: SmartCore.Auxiliary.Convert.GetDateFormat(lastComplianceDate);

				var condition = !string.IsNullOrEmpty(firstPerformanceString) ? (apr.Parent.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst
					? "/WF"
					: "/WL") : "";
				var conditionRepeat = !apr.Parent.Threshold.RepeatInterval.IsNullOrZero() ? (apr.Parent.Threshold.RepeatPerformanceConditionType == ThresholdConditionType.WhicheverFirst
					? "/WF"
					: "/WL") : "";

				subItems.Add(CreateRow(title, title));
				subItems.Add(CreateRow(card, card));
				subItems.Add(CreateRow(description, description));
				subItems.Add(CreateRow(apr.WorkType, apr.WorkType));
				subItems.Add(CreateRow($"{firstPerformanceString} {condition}", firstPerformanceString));
				subItems.Add(CreateRow($"{repeatInterval} {conditionRepeat}", repeatInterval));
				subItems.Add(CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(apr.Parent?.NextPerformance?.PerformanceDate), apr.Parent?.NextPerformance?.PerformanceDate));
				subItems.Add(CreateRow(apr.Parent?.NextPerformance?.PerformanceSource.ToString(), apr.Parent?.NextPerformance?.PerformanceSource));
				subItems.Add(CreateRow(apr.Parent?.Remains.ToString(), apr.Parent.Remains));
				subItems.Add(CreateRow(apr.Parent?.NextPerformance?.NextLimit.Days != null ? SmartCore.Auxiliary.Convert.GetDateFormat(apr.Parent?.NextPerformance?.NextPerformanceDateNew) : "", apr.Parent?.NextPerformance?.NextPerformanceDateNew));
				subItems.Add(CreateRow(apr.Parent?.NextPerformance?.NextLimit.ToString(), apr.Parent?.NextPerformance?.NextLimit.ToString()));
				subItems.Add(CreateRow(apr.Parent?.NextPerformance?.RemainLimit.ToString(), apr.Parent?.NextPerformance?.RemainLimit.ToString()));
				subItems.Add(CreateRow(lastDate, lastComplianceDate));
				subItems.Add(CreateRow(lastPerformanceString, lastComplianceLifeLength));
				subItems.Add(CreateRow(apr.Kits.Count > 0 ? apr.Kits.Count + " kits" : "", apr.Kits.Count));
				subItems.Add(CreateRow(manHours.ToString(), manHours));
				subItems.Add(CreateRow(KmanHours.ToString("F"), KmanHours));
				subItems.Add(CreateRow(cost.ToString(), cost));
				subItems.Add(CreateRow(zone, zone));
				subItems.Add(CreateRow(workArea, workArea));
				subItems.Add(CreateRow(access, access));
				subItems.Add(CreateRow(apr.SmartCoreObjectType.ToString(), apr.SmartCoreObjectType));
				subItems.Add(CreateRow(apr.ATAChapter?.ToString(), apr.ATAChapter));
				subItems.Add(CreateRow(apr.Parent?.NextPerformance?.MaintenanceCheck != null ? apr.Parent?.NextPerformance?.MaintenanceCheck.ToString() : "", apr.Parent?.NextPerformance?.MaintenanceCheck));
				subItems.Add(CreateRow(author, author));
			}

			else if (item is Directive)
			{
				var dir = (Directive)item;
				var manHours = dir.ManHours;
				var KmanHours = manHours * _currentWorkPackage.KMH;
				var cost = dir.Cost;
				var lastComplianceDate = DateTimeExtend.GetCASMinDateTime();
				var lastComplianceLifeLength = Lifelength.Zero;
				string lastPerformanceString, firstPerformanceString = "N/A";
				author = GlobalObjects.CasEnvironment.GetCorrector(dir);
				var card = dir.EngineeringOrders;
				var description = dir.Description;
				var title = dir.Title;
				var	access = dir.DirectiveAccess;
				var	workArea = dir.Workarea;
				var	zone = dir.DirectiveZone;
				
				//Последнее выполнение
				if (dir.LastPerformance != null &&
				    dir.LastPerformance.RecordDate > lastComplianceDate)
				{
					lastComplianceDate = dir.LastPerformance.RecordDate;
					lastComplianceLifeLength = dir.LastPerformance.OnLifelength;
				}

				//Следующее выполнение
				if (dir.Threshold.FirstPerformanceSinceNew != null && ! dir.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
				{
					firstPerformanceString = "s/n: " + dir.Threshold.FirstPerformanceSinceNew;
				}
				if (dir.Threshold.FirstPerformanceSinceEffectiveDate != null &&
					!dir.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
				{
					if (firstPerformanceString != "N/A") firstPerformanceString += " or ";
					else firstPerformanceString = "";
					firstPerformanceString += "s/e.d: " + dir.Threshold.FirstPerformanceSinceEffectiveDate;
				}
				var repeatInterval = dir.Threshold.RepeatInterval;

				if (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
					lastPerformanceString = "N/A";
				else lastPerformanceString = lastComplianceLifeLength.ToString();

				var lastDate = (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
					? ""
					: SmartCore.Auxiliary.Convert.GetDateFormat(lastComplianceDate);

				var condition = !string.IsNullOrEmpty(firstPerformanceString) ? (dir.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst
					? "/WF"
					: "/WL") : "";
				var conditionRepeat = !dir.Threshold.RepeatInterval.IsNullOrZero() ? (dir.Threshold.RepeatPerformanceConditionType == ThresholdConditionType.WhicheverFirst
					? "/WF"
					: "/WL") : "";

				subItems.Add(CreateRow(title, title));
				subItems.Add(CreateRow(card, card));
				subItems.Add(CreateRow(description, description));
				subItems.Add(CreateRow(dir.WorkType.ToString(), dir.WorkType));
				subItems.Add(CreateRow($"{firstPerformanceString} {condition}", firstPerformanceString));
				subItems.Add(CreateRow($"{repeatInterval} {conditionRepeat}", repeatInterval));
				subItems.Add(CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(dir.NextPerformance?.PerformanceDate), dir.NextPerformance?.PerformanceDate));
				subItems.Add(CreateRow(dir.NextPerformance?.PerformanceSource?.ToString(), dir.NextPerformance?.PerformanceSource));
				subItems.Add(CreateRow(dir.Remains.ToString(), dir.Remains));
				subItems.Add(CreateRow(dir.NextPerformance?.NextLimit?.Days != null ? SmartCore.Auxiliary.Convert.GetDateFormat(dir.NextPerformance?.NextPerformanceDateNew) : "", dir.NextPerformance?.NextPerformanceDateNew));
				subItems.Add(CreateRow(dir.NextPerformance?.NextLimit?.ToString(), dir.NextPerformance?.NextLimit?.ToString()));
				subItems.Add(CreateRow(dir.NextPerformance?.RemainLimit?.ToString(), dir.NextPerformance?.RemainLimit?.ToString()));
				subItems.Add(CreateRow(lastDate, lastComplianceDate));
				subItems.Add(CreateRow(lastPerformanceString, lastComplianceLifeLength));
				subItems.Add(CreateRow(dir.Kits.Count > 0 ? dir.Kits.Count + " kits" : "", dir.Kits.Count));
				subItems.Add(CreateRow(manHours.ToString(), manHours));
				subItems.Add(CreateRow(KmanHours.ToString("F"), KmanHours));
				subItems.Add(CreateRow(cost.ToString(), cost));
				subItems.Add(CreateRow(zone, zone));
				subItems.Add(CreateRow(workArea, workArea));
				subItems.Add(CreateRow(access, access));
				subItems.Add(CreateRow(dir.SmartCoreObjectType.ToString(), dir.SmartCoreObjectType));
				subItems.Add(CreateRow(dir.ATAChapter?.ToString(), dir.ATAChapter));
				subItems.Add(CreateRow(dir.NextPerformance?.MaintenanceCheck != null ? dir.NextPerformance?.MaintenanceCheck?.ToString() : "", dir.NextPerformance?.MaintenanceCheck));
				subItems.Add(CreateRow(author, author));
			}

			else if (item is BaseComponent)
			{
				var bd = (BaseComponent)item;
				var manHours = bd.ManHours;
				var KmanHours = manHours * _currentWorkPackage.KMH;
				var cost = bd.Cost;
				var lastComplianceDate = DateTimeExtend.GetCASMinDateTime();
				var lastComplianceLifeLength = Lifelength.Zero;
				string lastPerformanceString, firstPerformanceString = "N/A";
				author = GlobalObjects.CasEnvironment.GetCorrector(bd);
				var title = bd.Title;
				var card = "";
				var access = bd.Access;
				var workArea = "";
				var zone = bd.Zone;
				var description = bd.Description;

				//Последнее выполнение
				if (bd.NextPerformance.Parent.LastPerformance != null &&
				    bd.NextPerformance.Parent.LastPerformance.RecordDate > lastComplianceDate)
				{
					lastComplianceDate = bd.NextPerformance.Parent.LastPerformance.RecordDate;
					lastComplianceLifeLength = bd.NextPerformance.Parent.LastPerformance.OnLifelength;
				}

				//Следующее выполнение
				if (bd.Threshold.FirstPerformanceSinceNew != null && !bd.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
				{
					firstPerformanceString = "s/n: " + bd.Threshold.FirstPerformanceSinceNew;
				}
				if (bd.Threshold.FirstPerformanceSinceEffectiveDate != null &&
					!bd.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
				{
					if (firstPerformanceString != "N/A") firstPerformanceString += " or ";
					else firstPerformanceString = "";
					firstPerformanceString += "s/e.d: " + bd.Threshold.FirstPerformanceSinceEffectiveDate;
				}
				var repeatInterval = bd.Threshold.RepeatInterval;

				if (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
					lastPerformanceString = "N/A";
				else lastPerformanceString = lastComplianceLifeLength.ToString();

				var lastDate = (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
					? ""
					: SmartCore.Auxiliary.Convert.GetDateFormat(lastComplianceDate);

				var condition = !string.IsNullOrEmpty(firstPerformanceString) ? (bd.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst
					? "/WF"
					: "/WL") : "";
				var conditionRepeat = !bd.Threshold.RepeatInterval.IsNullOrZero() ? (bd.Threshold.RepeatPerformanceConditionType == ThresholdConditionType.WhicheverFirst
					? "/WF"
					: "/WL") : "";

				subItems.Add(CreateRow(title, title));
				subItems.Add(CreateRow(card, card));
				subItems.Add(CreateRow(description, description));
				subItems.Add(CreateRow(bd.WorkType.ToString(), bd.WorkType));
				subItems.Add(CreateRow($"{firstPerformanceString} {condition}", firstPerformanceString));
				subItems.Add(CreateRow($"{repeatInterval} {conditionRepeat}", repeatInterval));
				subItems.Add(CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(bd.NextPerformance?.PerformanceDate), bd.NextPerformance?.PerformanceDate));
				subItems.Add(CreateRow(bd.NextPerformance?.PerformanceSource?.ToString(), bd.NextPerformance?.PerformanceSource));
				subItems.Add(CreateRow(bd.Remains.ToString(), bd.Remains));
				subItems.Add(CreateRow(bd.NextPerformance?.NextLimit?.Days != null ? SmartCore.Auxiliary.Convert.GetDateFormat(bd.NextPerformance?.NextPerformanceDateNew) : "", bd.NextPerformance?.NextPerformanceDateNew));
				subItems.Add(CreateRow(bd.NextPerformance?.NextLimit?.ToString(), bd.NextPerformance?.NextLimit?.ToString()));
				subItems.Add(CreateRow(bd.NextPerformance?.RemainLimit?.ToString(), bd.NextPerformance?.RemainLimit?.ToString()));
				subItems.Add(CreateRow(lastDate, lastComplianceDate));
				subItems.Add(CreateRow(lastPerformanceString, lastComplianceLifeLength));
				subItems.Add(CreateRow(bd.Kits.Count > 0 ? bd.Kits.Count + " kits" : "", bd.Kits.Count));
				subItems.Add(CreateRow(manHours.ToString(), manHours));
				subItems.Add(CreateRow(KmanHours.ToString("F"), KmanHours));
				subItems.Add(CreateRow(cost.ToString(), cost));
				subItems.Add(CreateRow(zone, zone));
				subItems.Add(CreateRow(workArea, workArea));
				subItems.Add(CreateRow(access, access));
				subItems.Add(CreateRow(bd.SmartCoreObjectType.ToString(), bd.SmartCoreObjectType));
				subItems.Add(CreateRow(bd.ATAChapter?.ToString(), bd.ATAChapter));
				subItems.Add(CreateRow(bd.NextPerformance?.MaintenanceCheck != null ? bd.NextPerformance?.MaintenanceCheck?.ToString() : "", bd.NextPerformance?.MaintenanceCheck));
				subItems.Add(CreateRow(author, author));
			}

			else if (item is Component)
			{
				var d = (Component)item;
				var manHours = d.ManHours;
				var KmanHours = manHours * _currentWorkPackage.KMH;
				var cost = d.Cost;
				var lastComplianceDate = DateTimeExtend.GetCASMinDateTime();
				var lastComplianceLifeLength = Lifelength.Zero;
				string lastPerformanceString, firstPerformanceString = "N/A";
				author = GlobalObjects.CasEnvironment.GetCorrector(d);
				var title = d.Title;
				var card = "";
				var access = d.Access;
				var workArea = "";
				var zone = d.Zone;
				var description = d.Description;

				//Последнее выполнение
				if (d.NextPerformance.Parent.LastPerformance != null &&
				    d.NextPerformance.Parent.LastPerformance.RecordDate > lastComplianceDate)
				{
					lastComplianceDate = d.NextPerformance.Parent.LastPerformance.RecordDate;
					lastComplianceLifeLength = d.NextPerformance.Parent.LastPerformance.OnLifelength;
				}

				//Следующее выполнение
				if (d.Threshold.FirstPerformanceSinceNew != null && !d.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
				{
					firstPerformanceString = "s/n: " + d.Threshold.FirstPerformanceSinceNew;
				}
				if (d.Threshold.FirstPerformanceSinceEffectiveDate != null &&
					!d.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
				{
					if (firstPerformanceString != "N/A") firstPerformanceString += " or ";
					else firstPerformanceString = "";
					firstPerformanceString += "s/e.d: " + d.Threshold.FirstPerformanceSinceEffectiveDate;
				}
				var repeatInterval = d.Threshold.RepeatInterval;

				if (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
					lastPerformanceString = "N/A";
				else lastPerformanceString = lastComplianceLifeLength.ToString();

				var lastDate = (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
					? ""
					: SmartCore.Auxiliary.Convert.GetDateFormat(lastComplianceDate);

				var condition = !string.IsNullOrEmpty(firstPerformanceString) ? (d.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst
					? "/WF"
					: "/WL") : "";
				var conditionRepeat = !d.Threshold.RepeatInterval.IsNullOrZero() ? (d.Threshold.RepeatPerformanceConditionType == ThresholdConditionType.WhicheverFirst
					? "/WF"
					: "/WL") : "";

				subItems.Add(CreateRow(title, title));
				subItems.Add(CreateRow(card, card));
				subItems.Add(CreateRow(description, description));
				subItems.Add(CreateRow(d.WorkType.ToString(), d.WorkType));
				subItems.Add(CreateRow($"{firstPerformanceString} {condition}", firstPerformanceString));
				subItems.Add(CreateRow($"{repeatInterval} {conditionRepeat}", repeatInterval));
				subItems.Add(CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(d.NextPerformance?.PerformanceDate), d.NextPerformance?.PerformanceDate));
				subItems.Add(CreateRow(d.NextPerformance?.PerformanceSource?.ToString(), d.NextPerformance?.PerformanceSource));
				subItems.Add(CreateRow(d.Remains.ToString(), d.Remains));
				subItems.Add(CreateRow(d.NextPerformance?.NextLimit?.Days != null ? SmartCore.Auxiliary.Convert.GetDateFormat(d.NextPerformance?.NextPerformanceDateNew) : "", d.NextPerformance?.NextPerformanceDateNew));
				subItems.Add(CreateRow(d.NextPerformance?.NextLimit?.ToString(), d.NextPerformance?.NextLimit?.ToString()));
				subItems.Add(CreateRow(d.NextPerformance?.RemainLimit?.ToString(), d.NextPerformance?.RemainLimit?.ToString()));
				subItems.Add(CreateRow(lastDate, lastComplianceDate));
				subItems.Add(CreateRow(lastPerformanceString, lastComplianceLifeLength));
				subItems.Add(CreateRow(d.Kits.Count > 0 ? d.Kits.Count + " kits" : "", d.Kits.Count));
				subItems.Add(CreateRow(manHours.ToString(), manHours));
				subItems.Add(CreateRow(KmanHours.ToString("F"), KmanHours));
				subItems.Add(CreateRow(cost.ToString(), cost));
				subItems.Add(CreateRow(zone, zone));
				subItems.Add(CreateRow(workArea, workArea));
				subItems.Add(CreateRow(access, access));
				subItems.Add(CreateRow(d.SmartCoreObjectType.ToString(), d.SmartCoreObjectType));
				subItems.Add(CreateRow(d.ATAChapter?.ToString(), d.ATAChapter));
				subItems.Add(CreateRow(d.NextPerformance?.MaintenanceCheck != null ? d.NextPerformance?.MaintenanceCheck?.ToString() : "", d.NextPerformance?.MaintenanceCheck));
				subItems.Add(CreateRow(author, author));
			}

			else if (item is ComponentDirective)
			{
				var dd = (ComponentDirective)item;
				var manHours = dd.ManHours;
				var KmanHours = manHours * _currentWorkPackage.KMH;
				var cost = dd.Cost;
				var lastComplianceDate = DateTimeExtend.GetCASMinDateTime();
				var lastComplianceLifeLength = Lifelength.Zero;
				string lastPerformanceString, firstPerformanceString = "N/A";
				author = GlobalObjects.CasEnvironment.GetCorrector(dd);
				var title = dd.MaintenanceDirective?.TaskNumberCheck ?? "";
				var card = dd.MaintenanceDirective?.TaskCardNumber ?? "";
				var access = dd.Access;
				var workArea = "";
				var zone = dd.Zone;
				var description = dd.Title;

				//Последнее выполнение
				if (dd.LastPerformance != null &&
				    dd.LastPerformance.RecordDate > lastComplianceDate)
				{
					lastComplianceDate = dd.LastPerformance.RecordDate;
					lastComplianceLifeLength = dd.LastPerformance.OnLifelength;
				}

				//Следующее выполнение
				if (dd.Threshold.FirstPerformanceSinceNew != null && !dd.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
				{
					firstPerformanceString = "s/n: " + dd.Threshold.FirstPerformanceSinceNew;
				}
				if (dd.Threshold.FirstPerformanceSinceEffectiveDate != null &&
					!dd.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
				{
					if (firstPerformanceString != "N/A") firstPerformanceString += " or ";
					else firstPerformanceString = "";
					firstPerformanceString += "s/e.d: " + dd.Threshold.FirstPerformanceSinceEffectiveDate;
				}
				var repeatInterval = dd.Threshold.RepeatInterval;

				if (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
					lastPerformanceString = "N/A";
				else lastPerformanceString = lastComplianceLifeLength.ToString();

				var lastDate = (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
					? ""
					: SmartCore.Auxiliary.Convert.GetDateFormat(lastComplianceDate);

				var condition = !string.IsNullOrEmpty(firstPerformanceString) ? (dd.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst
					? "/WF"
					: "/WL") : "";
				var conditionRepeat = !dd.Threshold.RepeatInterval.IsNullOrZero() ? (dd.Threshold.RepeatPerformanceConditionType == ThresholdConditionType.WhicheverFirst
					? "/WF"
					: "/WL") : "";

				subItems.Add(CreateRow(title, title));
				subItems.Add(CreateRow(card, card));
				subItems.Add(CreateRow(description, description));
				subItems.Add(CreateRow(dd.ParentComponent.WorkType.ToString(), dd.ParentComponent.WorkType));
				subItems.Add(CreateRow($"{firstPerformanceString} {condition}", firstPerformanceString));
				subItems.Add(CreateRow($"{repeatInterval} {conditionRepeat}", repeatInterval));
				subItems.Add(CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(dd.ParentComponent?.NextPerformance?.PerformanceDate), dd.ParentComponent?.NextPerformance?.PerformanceDate));
				subItems.Add(CreateRow(dd.ParentComponent?.NextPerformance?.PerformanceSource?.ToString(), dd.ParentComponent?.NextPerformance?.PerformanceSource));
				subItems.Add(CreateRow(dd.Remains.ToString(), dd.Remains));
				subItems.Add(CreateRow(dd.ParentComponent?.NextPerformance?.NextLimit?.Days != null ? SmartCore.Auxiliary.Convert.GetDateFormat(dd.ParentComponent?.NextPerformance?.NextPerformanceDateNew) : "", dd.ParentComponent?.NextPerformance?.NextPerformanceDateNew));
				subItems.Add(CreateRow(dd.ParentComponent?.NextPerformance?.NextLimit?.ToString(), dd.ParentComponent?.NextPerformance?.NextLimit?.ToString()));
				subItems.Add(CreateRow(dd.ParentComponent?.NextPerformance?.RemainLimit?.ToString(), dd.ParentComponent?.NextPerformance?.RemainLimit?.ToString()));
				subItems.Add(CreateRow(lastDate, lastComplianceDate));
				subItems.Add(CreateRow(lastPerformanceString, lastComplianceLifeLength));
				subItems.Add(CreateRow(dd.Kits.Count > 0 ? dd.Kits.Count + " kits" : "", dd.Kits.Count));
				subItems.Add(CreateRow(manHours.ToString(), manHours));
				subItems.Add(CreateRow(KmanHours.ToString("F"), KmanHours));
				subItems.Add(CreateRow(cost.ToString(), cost));
				subItems.Add(CreateRow(zone, zone));
				subItems.Add(CreateRow(workArea, workArea));
				subItems.Add(CreateRow(access, access));
				subItems.Add(CreateRow(dd.SmartCoreObjectType.ToString(), dd.SmartCoreObjectType));
				subItems.Add(CreateRow(dd.ATAChapter?.ToString(), dd.ATAChapter));
				subItems.Add(CreateRow(dd.ParentComponent?.NextPerformance?.MaintenanceCheck != null ? dd.ParentComponent?.NextPerformance?.MaintenanceCheck?.ToString() : "", dd.ParentComponent?.NextPerformance?.MaintenanceCheck));
				subItems.Add(CreateRow(author, author));
			}

			else if (item is MaintenanceCheck)
			{
				var mcc = (MaintenanceCheck)item;
				var manHours = mcc.ManHours;
				var KmanHours = manHours * _currentWorkPackage.KMH;
				var cost = mcc.Cost;
				var lastComplianceDate = DateTimeExtend.GetCASMinDateTime();
				var lastComplianceLifeLength = Lifelength.Zero;
				string lastPerformanceString, firstPerformanceString = "N/A";
				author = GlobalObjects.CasEnvironment.GetCorrector(mcc);
				var title = mcc.Title;
				var card = "";
				var access = mcc.Access;
				var workArea = "";
				var zone = mcc.Zone;
				var description = mcc.Description;

				//Последнее выполнение
				if (mcc.LastPerformance != null &&
				    mcc.LastPerformance.RecordDate > lastComplianceDate)
				{
					lastComplianceDate = mcc.LastPerformance.RecordDate;
					lastComplianceLifeLength = mcc.LastPerformance.OnLifelength;
				}

				//Следующее выполнение
				if (mcc.Threshold.FirstPerformanceSinceNew != null && !mcc.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
				{
					firstPerformanceString = "s/n: " + mcc.Threshold.FirstPerformanceSinceNew;
				}
				if (mcc.Threshold.FirstPerformanceSinceEffectiveDate != null &&
					!mcc.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
				{
					if (firstPerformanceString != "N/A") firstPerformanceString += " or ";
					else firstPerformanceString = "";
					firstPerformanceString += "s/e.d: " + mcc.Threshold.FirstPerformanceSinceEffectiveDate;
				}
				var repeatInterval = mcc.Threshold.RepeatInterval;

				if (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
					lastPerformanceString = "N/A";
				else lastPerformanceString = lastComplianceLifeLength.ToString();

				var lastDate = (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
					? ""
					: SmartCore.Auxiliary.Convert.GetDateFormat(lastComplianceDate);

				var condition = !string.IsNullOrEmpty(firstPerformanceString) ? (mcc.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst
					? "/WF"
					: "/WL") : "";
				var conditionRepeat = !mcc.Threshold.RepeatInterval.IsNullOrZero() ? (mcc.Threshold.RepeatPerformanceConditionType == ThresholdConditionType.WhicheverFirst
					? "/WF"
					: "/WL") : "";

				subItems.Add(CreateRow(title, title));
				subItems.Add(CreateRow(card, card));
				subItems.Add(CreateRow(description, description));
				subItems.Add(CreateRow(mcc.WorkType.ToString(), mcc.WorkType));
				subItems.Add(CreateRow($"{firstPerformanceString} {condition}", firstPerformanceString));
				subItems.Add(CreateRow($"{repeatInterval} {conditionRepeat}", repeatInterval));
				subItems.Add(CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(mcc.NextPerformance?.PerformanceDate), mcc.NextPerformance?.PerformanceDate));
				subItems.Add(CreateRow(mcc.NextPerformance?.PerformanceSource?.ToString(), mcc.NextPerformance?.PerformanceSource));
				subItems.Add(CreateRow(mcc.Remains.ToString(), mcc.Remains));
				subItems.Add(CreateRow(mcc.NextPerformance?.NextLimit?.Days != null ? SmartCore.Auxiliary.Convert.GetDateFormat(mcc.NextPerformance?.NextPerformanceDateNew) : "", mcc.NextPerformance?.NextPerformanceDateNew));
				subItems.Add(CreateRow(mcc.NextPerformance?.NextLimit?.ToString(), mcc.NextPerformance?.NextLimit?.ToString()));
				subItems.Add(CreateRow(mcc.NextPerformance?.RemainLimit?.ToString(), mcc.NextPerformance?.RemainLimit?.ToString()));
				subItems.Add(CreateRow(lastDate, lastComplianceDate));
				subItems.Add(CreateRow(lastPerformanceString, lastComplianceLifeLength));
				subItems.Add(CreateRow(mcc.Kits.Count > 0 ? mcc.Kits.Count + " kits" : "", mcc.Kits.Count));
				subItems.Add(CreateRow(manHours.ToString(), manHours));
				subItems.Add(CreateRow(KmanHours.ToString("F"), KmanHours));
				subItems.Add(CreateRow(cost.ToString(), cost));
				subItems.Add(CreateRow(zone, zone));
				subItems.Add(CreateRow(workArea, workArea));
				subItems.Add(CreateRow(access, access));
				subItems.Add(CreateRow(mcc.SmartCoreObjectType.ToString(), mcc.SmartCoreObjectType));
				subItems.Add(CreateRow(mcc.ATAChapter?.ToString(), mcc.ATAChapter));
				subItems.Add(CreateRow(mcc.NextPerformance?.MaintenanceCheck != null ? mcc.NextPerformance?.MaintenanceCheck?.ToString() : "", mcc.NextPerformance?.MaintenanceCheck));
				subItems.Add(CreateRow(author, author));
			}

			else if (item is MaintenanceDirective)
			{
				var md = (MaintenanceDirective)item;
				var manHours = md.ManHours;
				var KmanHours = manHours * _currentWorkPackage.KMH;
				var cost = md.Cost;
				var lastComplianceDate = DateTimeExtend.GetCASMinDateTime();
				var lastComplianceLifeLength = Lifelength.Zero;
				string lastPerformanceString, firstPerformanceString = "N/A";
				author = GlobalObjects.CasEnvironment.GetCorrector(md);
				var title = md.Title;
				var card = md.TaskCardNumber;
				var access = md.Access;
				var workArea = md.Workarea;
				var zone = md.Zone;
				var description = md.Description;

				//Последнее выполнение
				if (md.LastPerformance != null &&
				    md.LastPerformance.RecordDate > lastComplianceDate)
				{
					lastComplianceDate = md.LastPerformance.RecordDate;
					lastComplianceLifeLength = md.LastPerformance.OnLifelength;
				}

				//Следующее выполнение
				if (md.Threshold.FirstPerformanceSinceNew != null && !md.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
				{
					firstPerformanceString = "s/n: " + md.Threshold.FirstPerformanceSinceNew;
				}
				if (md.Threshold.FirstPerformanceSinceEffectiveDate != null &&
					!md.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
				{
					if (firstPerformanceString != "N/A") firstPerformanceString += " or ";
					else firstPerformanceString = "";
					firstPerformanceString += "s/e.d: " + md.Threshold.FirstPerformanceSinceEffectiveDate;
				}
				var repeatInterval = md.Threshold.RepeatInterval;

				if (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
					lastPerformanceString = "N/A";
				else lastPerformanceString = lastComplianceLifeLength.ToString();

				var lastDate = (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
					? ""
					: SmartCore.Auxiliary.Convert.GetDateFormat(lastComplianceDate);

				var condition = !string.IsNullOrEmpty(firstPerformanceString) ? (md.Threshold.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst
					? "/WF"
					: "/WL") : "";
				var conditionRepeat = !md.Threshold.RepeatInterval.IsNullOrZero() ? (md.Threshold.RepeatPerformanceConditionType == ThresholdConditionType.WhicheverFirst
					? "/WF"
					: "/WL") : "";

				subItems.Add(CreateRow(title, title));
				subItems.Add(CreateRow(card, card));
				subItems.Add(CreateRow(description, description));
				subItems.Add(CreateRow(md.WorkType.ToString(), md.WorkType));
				subItems.Add(CreateRow($"{firstPerformanceString} {condition}", firstPerformanceString));
				subItems.Add(CreateRow($"{repeatInterval} {conditionRepeat}", repeatInterval));
				subItems.Add(CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(md.NextPerformance?.PerformanceDate), md.NextPerformance?.PerformanceDate));
				subItems.Add(CreateRow(md.NextPerformance?.PerformanceSource?.ToString(), md.NextPerformance?.PerformanceSource));
				subItems.Add(CreateRow(md.Remains.ToString(), md.Remains));
				subItems.Add(CreateRow(md.NextPerformance?.NextLimit?.Days != null ? SmartCore.Auxiliary.Convert.GetDateFormat(md.NextPerformance?.NextPerformanceDateNew) : "", md.NextPerformance?.NextPerformanceDateNew));
				subItems.Add(CreateRow(md.NextPerformance?.NextLimit?.ToString(), md.NextPerformance?.NextLimit?.ToString()));
				subItems.Add(CreateRow(md.NextPerformance?.RemainLimit?.ToString(), md.NextPerformance?.RemainLimit?.ToString()));
				subItems.Add(CreateRow(lastDate, lastComplianceDate));
				subItems.Add(CreateRow(lastPerformanceString, lastComplianceLifeLength));
				subItems.Add(CreateRow(md.Kits.Count > 0 ? md.Kits.Count + " kits" : "", md.Kits.Count));
				subItems.Add(CreateRow(manHours.ToString(), manHours));
				subItems.Add(CreateRow(KmanHours.ToString("F"), KmanHours));
				subItems.Add(CreateRow(cost.ToString(), cost));
				subItems.Add(CreateRow(zone, zone));
				subItems.Add(CreateRow(workArea, workArea));
				subItems.Add(CreateRow(access, access));
				subItems.Add(CreateRow(md.SmartCoreObjectType.ToString(), md.SmartCoreObjectType));
				subItems.Add(CreateRow(md.ATAChapter?.ToString(), md.ATAChapter));
				subItems.Add(CreateRow(md.MaintenanceCheck != null ? md.MaintenanceCheck.ToString() : "", md.MaintenanceCheck));
				subItems.Add(CreateRow(author, author));
			}

			else if (item is NonRoutineJob)
			{
				var job = (NonRoutineJob)item;
				var manHours = job.ManHours;
				var KmanHours = manHours * _currentWorkPackage.KMH;
				var cost = job.Cost;
				var lastComplianceDate = DateTimeExtend.GetCASMinDateTime();
				var lastComplianceLifeLength = Lifelength.Zero;
				string lastPerformanceString, firstPerformanceString = "N/A";
				author = GlobalObjects.CasEnvironment.GetCorrector(job);
				var title = job.Title;
				var card = "";
				var access = job.Access;
				var workArea = "";
				var zone = job.Zone;
				var description = job.Description;

				//Последнее выполнение
				if (job.NextPerformance?.Parent?.LastPerformance != null &&
					job.NextPerformance?.Parent?.LastPerformance?.RecordDate > lastComplianceDate)
				{
					lastComplianceDate = (DateTime) job.NextPerformance?.Parent?.LastPerformance?.RecordDate;
					lastComplianceLifeLength = job.NextPerformance?.Parent?.LastPerformance?.OnLifelength;
				}

				//Следующее выполнение
				if (job.NextPerformance?.Parent?.Threshold?.FirstPerformanceSinceNew != null && (bool) !job.NextPerformance?.Parent?.Threshold?.FirstPerformanceSinceNew.IsNullOrZero())
				{
					firstPerformanceString = "s/n: " + job.NextPerformance?.Parent?.Threshold?.FirstPerformanceSinceNew;
				}
				if (job.NextPerformance?.Parent?.Threshold?.FirstPerformanceSinceEffectiveDate != null &&
					(bool) !job.NextPerformance?.Parent?.Threshold?.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
				{
					if (firstPerformanceString != "N/A") firstPerformanceString += " or ";
					else firstPerformanceString = "";
					firstPerformanceString += "s/e.d: " + job.NextPerformance?.Parent?.Threshold?.FirstPerformanceSinceEffectiveDate;
				}
				
				if (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
					lastPerformanceString = "N/A";
				else lastPerformanceString = lastComplianceLifeLength.ToString();

				var lastDate = (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
					? ""
					: SmartCore.Auxiliary.Convert.GetDateFormat(lastComplianceDate);

				var condition = !string.IsNullOrEmpty(firstPerformanceString) ? (job.NextPerformance?.Parent?.Threshold?.FirstPerformanceConditionType == ThresholdConditionType.WhicheverFirst
					? "/WF"
					: "/WL") : "";
				
				subItems.Add(CreateRow(title, title));
				subItems.Add(CreateRow(card, card));
				subItems.Add(CreateRow(description, description));
				subItems.Add(CreateRow(job.WorkType?.ToString(), job.WorkType));
				subItems.Add(CreateRow($"{firstPerformanceString} {condition}", firstPerformanceString));
				subItems.Add(CreateRow("", ""));
				subItems.Add(CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(job.NextPerformance?.PerformanceDate), job.NextPerformance?.PerformanceDate));
				subItems.Add(CreateRow(job.NextPerformance?.PerformanceSource?.ToString(), job.NextPerformance?.PerformanceSource));
				subItems.Add(CreateRow(job.Remains.ToString(), job.Remains));
				subItems.Add(CreateRow(job.NextPerformance?.NextLimit?.Days != null ? SmartCore.Auxiliary.Convert.GetDateFormat(job.NextPerformance?.NextPerformanceDateNew) : "", job.NextPerformance?.NextPerformanceDateNew));
				subItems.Add(CreateRow(job.NextPerformance?.NextLimit?.ToString(), job.NextPerformance?.NextLimit?.ToString()));
				subItems.Add(CreateRow(job.NextPerformance?.RemainLimit?.ToString(), job.NextPerformance?.RemainLimit?.ToString()));
				subItems.Add(CreateRow(lastDate, lastComplianceDate));
				subItems.Add(CreateRow(lastPerformanceString, lastComplianceLifeLength));
				subItems.Add(CreateRow(job.Kits.Count > 0 ? job.Kits.Count + " kits" : "", job.Kits.Count));
				subItems.Add(CreateRow(manHours.ToString(), manHours));
				subItems.Add(CreateRow(KmanHours.ToString("F"), KmanHours));
				subItems.Add(CreateRow(cost.ToString(), cost));
				subItems.Add(CreateRow(zone, zone));
				subItems.Add(CreateRow(workArea, workArea));
				subItems.Add(CreateRow(access, access));
				subItems.Add(CreateRow(job.SmartCoreObjectType.ToString(), job.SmartCoreObjectType));
				subItems.Add(CreateRow(job.ATAChapter?.ToString(), job.ATAChapter));
				subItems.Add(CreateRow(job.NextPerformance?.MaintenanceCheck != null ? job.NextPerformance?.MaintenanceCheck?.ToString() : "", job.NextPerformance?.MaintenanceCheck));
				subItems.Add(CreateRow(author, author));
			}

			else throw new ArgumentOutOfRangeException($"1135: Takes an argument has no known type {item.GetType()}");

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
			{
				if (dp.Form.ShowDialog() == DialogResult.OK)
				{
					if (dp.Form is NonRoutineJobForm)
					{
						var changedJob =GlobalObjects.CasEnvironment.NewLoader.GetObjectById<NonRoutineJobDTO,NonRoutineJob>(((NonRoutineJobForm)dp.Form).CurrentJob.ItemId, true);
						radGridView1.SelectedRows[0].Tag = changedJob;

						var subs = GetListViewSubItems(SelectedItem);
						for (var i = 0; i < subs.Capacity; i++)
							radGridView1.SelectedRows[0].Cells[i].Value = subs[i].Text;
					}
				}
				e.Cancel = true;
			}
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
