using System;
using System.Collections.Generic;
using System.Drawing;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.Quality;
using SmartCore.Entities.General.WorkPackage;
using Telerik.WinControls.UI;

namespace CAS.UI.UIControls.QualityAssuranceControls
{
	///<summary>
	/// список для отображения ордеров запроса
	///</summary>
	public partial class AuditView : BaseGridViewControl<BaseEntityObject>
	{
		#region Fields

		private Audit _currentDirective;

		#endregion

		#region Constructors

		#region private AuditView()
		///<summary>
		///</summary>
		private AuditView()
		{
			InitializeComponent();
		}
		#endregion

		#region public AuditView()
		///<summary>
		///</summary>
		public AuditView(Audit currebtDirective) : this ()
		{
			_currentDirective = currebtDirective;
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
			AddColumn("Type", (int)(radGridView1.Width * 0.20f));
			AddColumn("ATA", (int)(radGridView1.Width * 0.20f));
			AddColumn("Title", (int)(radGridView1.Width * 0.32f));
			AddColumn("Description", (int)(radGridView1.Width * 0.16f));
			AddColumn("Kit Required", (int)(radGridView1.Width * 0.16f));
			AddColumn("Performance", (int)(radGridView1.Width * 0.16f));
			AddColumn("Rpt. Intv.", (int)(radGridView1.Width * 0.16f));
			AddColumn("Overdue/Remain", (int)(radGridView1.Width * 0.16f));
			AddColumn("Work Type", (int)(radGridView1.Width * 0.16f));
			AddColumn("Perf. Date", (int)(radGridView1.Width * 0.16f));
			AddColumn("MH", (int)(radGridView1.Width * 0.16f));
			AddColumn("Cost", (int)(radGridView1.Width * 0.16f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

		#region protected override void GroupingItems()

		protected override void GroupingItems()
		{
			Grouping("Type");
		}

		#endregion

		#region protected override void SetItemColor(ListViewItem listViewItem, BaseSmartCoreObject item)

		protected override void SetItemColor(GridViewRowInfo listViewItem, BaseEntityObject item)
		{
			if (item is NextPerformance)
			{
				NextPerformance nextPerformance = item as NextPerformance;
				if (_currentDirective.Status != WorkPackageStatus.Closed)
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
			else if (item is AbstractPerformanceRecord)
			{
				AbstractPerformanceRecord apr = (AbstractPerformanceRecord)item;
				if (apr.Parent.IsDeleted)
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
		}

		//protected override void SetItemColor(ListViewItem listViewItem, BaseEntityObject item)
		//{
		//    if (item is NextPerformance)
		//    {
		//        NextPerformance nextPerformance = item as NextPerformance;
		//        if(_currentDirective.Status != WorkPackageStatus.Closed)
		//        {
		//            if (nextPerformance.BlockedByPackage != null)
		//            {
		//                listViewItem.ToolTipText = "This performance blocked by work package:" +
		//                   nextPerformance.BlockedByPackage.Title;
		//                listViewItem.BackColor = Color.FromArgb(Highlight.Grey.Color);
		//            }
		//            else if (nextPerformance.Condition == ConditionState.Notify)
		//                listViewItem.BackColor = Color.FromArgb(Highlight.Yellow.Color);
		//            else if (nextPerformance.Condition == ConditionState.Overdue)
		//                listViewItem.BackColor = Color.FromArgb(Highlight.Red.Color);    
		//        }
		//        else
		//        {
		//            //Если это следующее выполнение, но рабочий пакет при этом закрыт
		//            //значит, выполнение для данной задачи в рамках данного рабочего пакета
		//            //не было введено

		//            //пометка этого выполнения краным цветом
		//            listViewItem.BackColor = Color.FromArgb(Highlight.Red.Color);
		//            //подсказка о том, что выполнение не было введено
		//            listViewItem.ToolTipText = "Performance for this directive within this work package is not entered.";
		//            if (nextPerformance.BlockedByPackage != null)
		//            {
		//                //дополнитльная подсказака, если предшествующее выполнение 
		//                //имеется в другом открытом рабочем пакете
		//                listViewItem.ToolTipText += "\nThis performance blocked by work package:" +
		//                   nextPerformance.BlockedByPackage.Title +
		//                   "\nFirst, enter the performance of this directive as part of this work package ";
		//            }    
		//        }

		//        if (nextPerformance.Parent.IsDeleted)
		//        {
		//            //запись так же может быть удаленной

		//            //шрифт серым цветом
		//            listViewItem.ForeColor = Color.Gray;
		//            if (listViewItem.ToolTipText.Trim() != "")
		//                listViewItem.ToolTipText += "\n";
		//            listViewItem.ToolTipText += string.Format("This {0} is deleted",nextPerformance.Parent.SmartCoreObjectType);
		//        }
		//    }
		//    else if (item is AbstractPerformanceRecord)
		//    {
		//        AbstractPerformanceRecord apr = (AbstractPerformanceRecord) item;
		//        if (apr.Parent.IsDeleted)
		//        {
		//            //запись так же может быть удаленной

		//            //шрифт серым цветом
		//            listViewItem.ForeColor = Color.Gray;
		//            if (listViewItem.ToolTipText.Trim() != "")
		//                listViewItem.ToolTipText += "\n";
		//            listViewItem.ToolTipText += string.Format("This {0} is deleted", apr.Parent.SmartCoreObjectType);
		//        }    
		//    }
		//    else
		//    {
		//        if(!(item is NonRoutineJob))
		//        {
		//            //Если это не следующее выполнение, не запись о выполнении, и не рутинная работа
		//            //значит, выполнение для данной задачи расчитать нельзя

		//            //пометка этого выполнения синим цветом
		//            listViewItem.BackColor = Color.FromArgb(Highlight.Blue.Color);
		//            //подсказка о том, что выполнение не возможео расчитать
		//            listViewItem.ToolTipText = "Performance for this directive can not be calculated";  
		//        }

		//        if (item.IsDeleted)
		//        {
		//            //запись так же может быть удаленной

		//            //шрифт серым цветом
		//            listViewItem.ForeColor = Color.Gray;
		//            if (listViewItem.ToolTipText.Trim() != "")
		//                listViewItem.ToolTipText += "\n";
		//            listViewItem.ToolTipText += string.Format("This {0} is deleted", item.SmartCoreObjectType);
		//        }
		//    }
		//}
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(BaseSmartCoreObject item)

		protected override List<CustomCell> GetListViewSubItems(BaseEntityObject item)
		{
			var temp = ListViewGroupHelper.GetGroupString(item);
			var subItems = new List<CustomCell>()
			{
				CreateRow(temp,temp)
			};
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			//if(item.ItemId == 41043)
			//{

			//}
			if (item is NextPerformance)
			{
				NextPerformance np = (NextPerformance) item;

				double manHours = np.Parent is IEngineeringDirective ? ((IEngineeringDirective)np.Parent).ManHours : 0;
				double cost = np.Parent is IEngineeringDirective ? ((IEngineeringDirective)np.Parent).Cost : 0;

				subItems.Add(CreateRow(np.ATAChapter.ToString(), np.ATAChapter));
				subItems.Add(CreateRow(np.Title, np.Title));
				subItems.Add(CreateRow(np.Description, np.Description));
				subItems.Add(CreateRow(np.KitsToString, np.Kits.Count));
				subItems.Add(CreateRow(np.PerformanceSource.ToString(), np.PerformanceSource));
				subItems.Add(CreateRow(np.Parent.Threshold.RepeatInterval.ToString(), np.Parent.Threshold.RepeatInterval));
				subItems.Add(CreateRow(np.Remains.ToString(), np.Remains));
				subItems.Add(CreateRow(np.WorkType, Tag = np.WorkType));
				subItems.Add(CreateRow(np.PerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)np.PerformanceDate), np.PerformanceDate));
				subItems.Add(CreateRow(manHours.ToString(), manHours));
				subItems.Add(CreateRow(cost.ToString(), cost));
				subItems.Add(CreateRow(author, author));
			}
			else if (item is AbstractPerformanceRecord)
			{
				//DirectiveRecord directiveRecord = (DirectiveRecord)item;
				AbstractPerformanceRecord apr = (AbstractPerformanceRecord)item;
				Lifelength remains = Lifelength.Null;
				double manHours = apr.Parent is IEngineeringDirective ? ((IEngineeringDirective)apr.Parent).ManHours : 0;
				double cost = apr.Parent is IEngineeringDirective ? ((IEngineeringDirective)apr.Parent).Cost : 0;

				subItems.Add(CreateRow(apr.ATAChapter.ToString(), apr.ATAChapter));
				subItems.Add(CreateRow(apr.Title, apr.Title));
				subItems.Add(CreateRow(apr.Description, apr.Description));
				subItems.Add(CreateRow(apr.KitsToString, apr.Kits.Count));
				subItems.Add(CreateRow(apr.OnLifelength.ToString(), apr.OnLifelength));
				subItems.Add(CreateRow(apr.Parent.Threshold.RepeatInterval.ToString(), apr.Parent.Threshold.RepeatInterval));
				subItems.Add(CreateRow(remains.ToString(), remains));
				subItems.Add(CreateRow(apr.WorkType, apr.WorkType));
				subItems.Add(CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(apr.RecordDate), apr.RecordDate));
				subItems.Add(CreateRow(manHours.ToString(), manHours));
				subItems.Add(CreateRow(cost.ToString(), cost));
				subItems.Add(CreateRow(author, author));
			}
			else if (item is Directive)
			{
				Directive directive = (Directive)item;

				AtaChapter ata = directive.ATAChapter;
				subItems.Add(CreateRow(ata.ToString(), ata));
				subItems.Add(CreateRow(directive.Title, directive.Title));
				subItems.Add(CreateRow(directive.Description, directive.Description));

				#region Определение текста для колонки "КИТы"
				subItems.Add(CreateRow(directive.Kits.Count > 0 ? directive.Kits.Count + " kits" : "", directive.Kits.Count));
				#endregion

				#region Определение текста для колонки "Первое выполнение"

				var subItem = new CustomCell();
				if (directive.Threshold.FirstPerformanceSinceNew != null && !directive.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
				{
					subItem.Text = "s/n: " + directive.Threshold.FirstPerformanceSinceNew;
					subItem.Tag = directive.Threshold.FirstPerformanceSinceNew;
				}
				if (directive.Threshold.FirstPerformanceSinceEffectiveDate != null &&
					!directive.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
				{
					if (subItem.Text != "") subItem.Text += " or ";
					else
					{
						subItem.Text = "";
						subItem.Tag = directive.Threshold.FirstPerformanceSinceEffectiveDate;
					}
					subItem.Text += "s/e.d: " + directive.Threshold.FirstPerformanceSinceEffectiveDate;
				}

				subItems.Add(subItem);
				#endregion

				#region Определение текста для колонки "повторяющийся интервал"

				subItem = new CustomCell();
				if (!directive.Threshold.RepeatInterval.IsNullOrZero())
				{
					subItem.Text = directive.Threshold.RepeatInterval.ToString();
					subItem.Tag = directive.Threshold.RepeatInterval;
				}
				else
				{
					subItem.Text = "";
					subItem.Tag = Lifelength.Null;
				}
				subItems.Add(subItem);
				#endregion

				#region Определение текста для колонки "Остаток/Просрочено на сегодня"
				subItems.Add(CreateRow(directive.Remains.ToString(), directive.Remains));
				#endregion

				#region Определение текста для колонки "Тип работ"

				subItems.Add(CreateRow(directive.WorkType.ToString(), directive.WorkType));
				#endregion

				#region Определение текста для колонки "Следующее выполнение"
				subItems.Add(CreateRow(directive.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)directive.NextPerformanceDate), directive.NextPerformanceDate));
				#endregion

				#region Определение текста для колонки "Человек/Часы"

				subItems.Add(CreateRow(directive.ManHours.ToString(), directive.ManHours));
				#endregion

				#region Определение текста для колонки "Стоимость"

				subItems.Add(CreateRow(directive.Cost.ToString(), directive.Cost));
				#endregion
				subItems.Add(CreateRow(author, author));
			}
			else if (item is BaseComponent)
			{
				BaseComponent bd = (BaseComponent)item;
				AtaChapter ata = bd.ATAChapter;

				subItems.Add(CreateRow(ata.ToString(), ata));
				subItems.Add(CreateRow(bd.PartNumber, bd.PartNumber));
				subItems.Add(CreateRow(bd.Description, bd.Description));
				subItems.Add(CreateRow(bd.Kits.Count > 0 ? bd.Kits.Count + " kits" : "", bd.Kits.Count));
				subItems.Add(CreateRow(bd.LifeLimit.ToString(), bd.LifeLimit));
				subItems.Add(CreateRow("", Lifelength.Null));
				subItems.Add(CreateRow(bd.Remains.ToString(), bd.Remains));
				subItems.Add(CreateRow(ComponentRecordType.Remove.ToString(), ComponentRecordType.Remove));
				subItems.Add(CreateRow(bd.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)bd.NextPerformanceDate), bd.NextPerformanceDate));
				subItems.Add(CreateRow(bd.ManHours.ToString(), bd.ManHours));
				subItems.Add(CreateRow(bd.Cost.ToString(), bd.Cost));
				subItems.Add(CreateRow(author, author));
			}
			else if (item is Component)
			{
				Component d = (Component)item;
				AtaChapter ata = d.ATAChapter;

				subItems.Add(CreateRow(ata.ToString(), ata));
				subItems.Add(CreateRow(d.PartNumber, d.PartNumber));
				subItems.Add(CreateRow(d.Description, d.Description));
				subItems.Add(CreateRow(d.Kits.Count > 0 ? d.Kits.Count + " kits" : "", d.Kits.Count));
				subItems.Add(CreateRow(d.LifeLimit != null ? d.LifeLimit.ToString() : "", d.LifeLimit));
				subItems.Add(CreateRow("", Lifelength.Null));
				subItems.Add(CreateRow(d.Remains != null ? d.Remains.ToString() : "", d.Remains));
				subItems.Add(CreateRow(ComponentRecordType.Remove.ToString(), ComponentRecordType.Remove));
				subItems.Add(CreateRow(d.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)d.NextPerformanceDate), d.NextPerformanceDate));
				subItems.Add(CreateRow(d.ManHours.ToString(), d.ManHours));
				subItems.Add(CreateRow(d.Cost.ToString(), d.Cost));
				subItems.Add(CreateRow(author, Tag = author));
			}
			else if (item is ComponentDirective)
			{
				ComponentDirective dd = (ComponentDirective)item;
				AtaChapter ata = dd.ParentComponent.ATAChapter;

				subItems.Add(CreateRow(ata != null ? ata.ToString() : "", ata));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow(dd.Remarks, dd.Remarks));
				subItems.Add(CreateRow(dd.Kits.Count > 0 ? dd.Kits.Count + " kits" : "", dd.Kits.Count));
				#region Определение текста для колонки "Первое выполнение"

				var subItem = new CustomCell();
				if (dd.Threshold.FirstPerformanceSinceNew != null && !dd.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
				{
					subItem.Text = "s/n: " + dd.Threshold.FirstPerformanceSinceNew;
					subItem.Tag = dd.Threshold.FirstPerformanceSinceNew;
				}
				subItems.Add(subItem);
				#endregion
				#region Определение текста для колонки "повторяющийся интервал"

				subItem = new CustomCell();
				if (!dd.Threshold.RepeatInterval.IsNullOrZero())
				{
					subItem.Text = dd.Threshold.RepeatInterval.ToString();
					subItem.Tag = dd.Threshold.RepeatInterval;
				}
				else
				{
					subItem.Text = "";
					subItem.Tag = Lifelength.Null;
				}
				subItems.Add(subItem);
				#endregion
				subItems.Add( CreateRow(dd.Remains.ToString(), dd.Remains));
				subItems.Add(CreateRow(dd.DirectiveType.ToString(), dd.DirectiveType));
				subItems.Add(CreateRow(dd.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)dd.NextPerformanceDate), dd.NextPerformanceDate));
				subItems.Add(CreateRow(dd.ManHours.ToString(), dd.ManHours));
				subItems.Add(CreateRow(dd.Cost.ToString(), dd.Cost));
				subItems.Add(CreateRow(author, author));
			}
			else if (item is MaintenanceCheck)
			{
				MaintenanceCheck mc = (MaintenanceCheck)item;
				subItems.Add(CreateRow("", null));
				subItems.Add(CreateRow("", ""));
				subItems.Add(CreateRow(mc.Name + (mc.Schedule ? " Shedule" : " Unshedule"), mc.Name));
				subItems.Add(CreateRow(mc.Kits.Count > 0 ? mc.Kits.Count + " kits" : "", mc.Kits.Count));
				subItems.Add(CreateRow(mc.Interval.ToString(), mc.Interval));
				subItems.Add(CreateRow("", Lifelength.Null));
				subItems.Add(CreateRow(mc.Remains.ToString(), mc.Remains));
				subItems.Add(CreateRow("", ""));
				subItems.Add(CreateRow(mc.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)mc.NextPerformanceDate), mc.NextPerformanceDate));
				subItems.Add(CreateRow(mc.ManHours.ToString(), mc.ManHours));
				subItems.Add(CreateRow(mc.Cost.ToString(), mc.Cost));
				subItems.Add(CreateRow(author, author));
			}
			else if (item is MaintenanceDirective)
			{
				MaintenanceDirective md = (MaintenanceDirective)item;
				AtaChapter ata = md.ATAChapter;

				subItems.Add(CreateRow(ata != null ? ata.ToString() : "", ata));
				subItems.Add(CreateRow(md.ToString(),  md.ToString()));
				subItems.Add(CreateRow(md.Description, md.Description));
				subItems.Add(CreateRow(md.Kits.Count > 0 ? md.Kits.Count + " kits" : "", md.Kits.Count));
				#region Определение текста для колонки "Первое выполнение"

				var subItem = new CustomCell();
				if (md.Threshold.FirstPerformanceSinceNew != null && !md.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
				{
					subItem.Text = "s/n: " + md.Threshold.FirstPerformanceSinceNew;
					subItem.Tag = md.Threshold.FirstPerformanceSinceNew;
				}
				if (md.Threshold.FirstPerformanceSinceEffectiveDate != null &&
					!md.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
				{
					if (subItem.Text != "") subItem.Text += " or ";
					else
					{
						subItem.Text = "";
						subItem.Tag = md.Threshold.FirstPerformanceSinceEffectiveDate;
					}
					subItem.Text += "s/e.d: " + md.Threshold.FirstPerformanceSinceEffectiveDate;
				}

				subItems.Add(subItem);
				#endregion
				#region Определение текста для колонки "повторяющийся интервал"

				subItem = new CustomCell();
				if (!md.Threshold.RepeatInterval.IsNullOrZero())
				{
					subItem.Text = md.Threshold.RepeatInterval.ToString();
					subItem.Tag = md.Threshold.RepeatInterval;
				}
				else
				{
					subItem.Text = "";
					subItem.Tag = Lifelength.Null;
				}
				subItems.Add(subItem);
				#endregion
				subItems.Add(CreateRow(md.Remains.ToString(), md.Remains));
				subItems.Add(CreateRow(md.WorkType.ToString(), md.WorkType));
				subItems.Add(CreateRow(md.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)md.NextPerformanceDate), md.NextPerformanceDate));
				subItems.Add(CreateRow(md.ManHours.ToString(), md.ManHours));
				subItems.Add(CreateRow(md.Cost.ToString(), md.Cost));
				subItems.Add(CreateRow(author, author));
			}
			else if (item is Procedure)
			{
				Procedure md = (Procedure)item;

				subItems.Add(CreateRow("", ""));
				subItems.Add(CreateRow(md.ToString(), md.ToString()));
				subItems.Add(CreateRow(md.Description, md.Description));
				subItems.Add(CreateRow(md.Kits.Count > 0 ? md.Kits.Count + " kits" : "", md.Kits.Count));
				
				#region Определение текста для колонки "Первое выполнение"

				var subItem = new CustomCell();
				if (md.Threshold.FirstPerformanceSinceNew != null && !md.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
				{
					subItem.Text = "s/n: " + md.Threshold.FirstPerformanceSinceNew;
					subItem.Tag = md.Threshold.FirstPerformanceSinceNew;
				}
				if (md.Threshold.FirstPerformanceSinceEffectiveDate != null &&
					!md.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
				{
					if (subItem.Text != "") subItem.Text += " or ";
					else
					{
						subItem.Text = "";
						subItem.Tag = md.Threshold.FirstPerformanceSinceEffectiveDate;
					}
					subItem.Text += "s/e.d: " + md.Threshold.FirstPerformanceSinceEffectiveDate;
				}

				subItems.Add(subItem);
				#endregion
			   
				#region Определение текста для колонки "повторяющийся интервал"

				subItem = new CustomCell();
				if (!md.Threshold.RepeatInterval.IsNullOrZero())
				{
					subItem.Text = md.Threshold.RepeatInterval.ToString();
					subItem.Tag = md.Threshold.RepeatInterval;
				}
				else
				{
					subItem.Text = "";
					subItem.Tag = Lifelength.Null;
				}
				subItems.Add(subItem);
				#endregion
				
				subItems.Add(CreateRow(md.Remains.ToString(), md.Remains));
				subItems.Add(CreateRow(md.ProcedureType.ToString(), md.ProcedureType));
				subItems.Add(CreateRow(md.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)md.NextPerformanceDate), md.NextPerformanceDate));
				subItems.Add(CreateRow(md.ManHours.ToString(), md.ManHours));
				subItems.Add(CreateRow(md.Cost.ToString(),  md.Cost));
				subItems.Add(CreateRow(author, author));
			}
			else if (item is NonRoutineJob)
			{
				NonRoutineJob job = (NonRoutineJob)item;
				AtaChapter ata = job.ATAChapter;
				subItems.Add(CreateRow(ata != null ? ata.ToString() : "", ata));
				subItems.Add(CreateRow(job.Title, job.Title));
				subItems.Add(CreateRow(job.Description, job.Description));
				subItems.Add(CreateRow(job.Kits.Count > 0 ? job.Kits.Count + " kits" : "", job.Kits.Count));
				subItems.Add(CreateRow("", Lifelength.Null));
				subItems.Add(CreateRow("", Lifelength.Null));
				subItems.Add(CreateRow("", Lifelength.Null));
				subItems.Add(CreateRow("", ""));
				subItems.Add(CreateRow("", DateTimeExtend.GetCASMinDateTime()));
				subItems.Add(CreateRow(job.ManHours.ToString(), job.ManHours));
				subItems.Add(CreateRow(job.Cost.ToString(), job.Cost));
				subItems.Add(CreateRow(author, author));
			}
			else throw new ArgumentOutOfRangeException(String.Format("1135: Takes an argument has no known type {0}", item.GetType()));

			return subItems;
		}

		#endregion

		#region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

		protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
		{
			if (SelectedItem == null) return;

			IBaseEntityObject parent;
			if (SelectedItem is NextPerformance)
			{
				parent = ((NextPerformance)SelectedItem).Parent;
			}
			else if (SelectedItem is AbstractPerformanceRecord)
			{
				parent = ((AbstractPerformanceRecord)SelectedItem).Parent;
			}
			else parent = SelectedItem;
			   
			if (parent is Procedure)
			{
				Procedure baseDetail = (Procedure)parent;
				e.DisplayerText = baseDetail.Title;
				e.TypeOfReflection = ReflectionTypes.DisplayInNew;
				e.RequestedEntity = new ProcedureScreen(baseDetail);
			}
			else
			{
				e.Cancel = true;
			}
		}
		#endregion

		#endregion
	}
}
