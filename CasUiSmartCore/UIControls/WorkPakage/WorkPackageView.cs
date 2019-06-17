using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using EFCore.DTO.Dictionaries;
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
	        AddColumn("Type", (int)(radGridView1.Width * 0.1f));
			AddColumn("ATA", (int)(radGridView1.Width * 0.20f));
			AddColumn("Title", (int)(radGridView1.Width * 0.32f));
			AddColumn("Description", (int)(radGridView1.Width * 0.16f));
			AddColumn("Kit Required", (int)(radGridView1.Width * 0.16f));
			AddColumn("Performance", (int)(radGridView1.Width * 0.16f));
			AddColumn("Rpt. Intv.", (int)(radGridView1.Width * 0.16f));
			AddColumn("Overdue/Remain", (int)(radGridView1.Width * 0.16f));
			AddColumn("Work Type", (int)(radGridView1.Width * 0.16f));
			AddColumn("NDT", (int)(radGridView1.Width * 0.16f));
			AddColumn("Calculation Perf. Date", (int)(radGridView1.Width * 0.16f));
			AddColumn("Perf. Date", (int)(radGridView1.Width * 0.16f));
			AddColumn("MH", (int)(radGridView1.Width * 0.12f));
			AddColumn("K*MH", (int)(radGridView1.Width * 0.12f));
			AddColumn("Cost", (int)(radGridView1.Width * 0.12f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
        }
		#endregion

		#region protected override SetGroupsToItems(int columnIndex)

		protected override void GroupingItems()
		{
			Grouping("Type");
		}
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
	        var temp = ListViewGroupHelper.GetGroupString(item);
			var subItems = new List<CustomCell>()
            {
				CreateRow(temp, temp)
            };
            var author = "";
			if (item is NextPerformance)
            {
                var np = (NextPerformance) item;
                var manHours = np.Parent is IEngineeringDirective ? ((IEngineeringDirective)np.Parent).ManHours : 0;
                var KmanHours = manHours*_currentWorkPackage.KMH;
                var cost = np.Parent is IEngineeringDirective ? ((IEngineeringDirective)np.Parent).Cost : 0;
                subItems.Add(CreateRow(np.ATAChapter.ToString(), np.ATAChapter));
                if (np.Parent is ComponentDirective)
                {
	                var cd = np.Parent as ComponentDirective;
	                author = GlobalObjects.CasEnvironment.GetCorrector(cd.CorrectorId);
					subItems.Add(CreateRow($"{cd.MaintenanceDirective?.TaskCardNumber} {np.Title}", np.Title ));
				}
                else if (np.Parent is MaintenanceDirective)
                {
	                var md = np.Parent as MaintenanceDirective;
	                author = GlobalObjects.CasEnvironment.GetCorrector(md.CorrectorId);
					subItems.Add(CreateRow($"{md.TaskCardNumber} {md.TaskNumberCheck} {md.Description}", np.Title ));
				}
				else if (np.Parent is Directive)
                {
	                var directive = np.Parent as Directive;
	                var title = "";
	                if (!string.IsNullOrEmpty(directive.EngineeringOrders))
		                title += $"EO:{directive.EngineeringOrders} ";
	                if (!string.IsNullOrEmpty(directive.Title))
		                title += $"AD:{directive.Title} ";
	                author = GlobalObjects.CasEnvironment.GetCorrector(directive.CorrectorId);
					subItems.Add(CreateRow(title, directive.Title));
				}
                else subItems.Add(CreateRow(np.Title, np.Title ));

                
                subItems.Add(CreateRow(np.Description, Tag = np.Description ));
                subItems.Add(CreateRow(np.KitsToString, Tag = np.Kits.Count ));
                subItems.Add(CreateRow(np.PerformanceSource.ToString(), np.PerformanceSource));


	            if (np.Parent is MaintenanceDirective)
	            {
		            var d = np.Parent as MaintenanceDirective;
		            subItems.Add(CreateRow(d.PhaseRepeat?.ToString(), d.PhaseRepeat));
	            }
	            else subItems.Add(CreateRow(np.Parent.Threshold.RepeatInterval.ToString(), np.Parent.Threshold.RepeatInterval));

                subItems.Add(CreateRow(np.Remains.ToString(), np.Remains ));
                subItems.Add(CreateRow(np.WorkType, np.WorkType ));
				subItems.Add(CreateRow(np.NDTString, np.NDTString ));
				subItems.Add(CreateRow(np.PerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)np.PerformanceDate), np.PerformanceDate));
				subItems.Add(CreateRow(_currentWorkPackage.PerformDate, _currentWorkPackage.PerformDate));
                subItems.Add(CreateRow(manHours.ToString(), manHours));
                subItems.Add(CreateRow(KmanHours.ToString("F"), KmanHours));
                subItems.Add(CreateRow(cost.ToString(), cost ));
                subItems.Add(CreateRow(author, author));
			}
            else if (item is AbstractPerformanceRecord)
            {
                //DirectiveRecord directiveRecord = (DirectiveRecord)item;
                var apr = (AbstractPerformanceRecord)item;
                author = GlobalObjects.CasEnvironment.GetCorrector(apr.CorrectorId);
				var manHours = apr.Parent is IEngineeringDirective ? ((IEngineeringDirective)apr.Parent).ManHours : 0;
				var KmanHours = manHours*_currentWorkPackage.KMH;
                var cost = apr.Parent is IEngineeringDirective ? ((IEngineeringDirective)apr.Parent).Cost : 0;
                var remains = Lifelength.Null;
                subItems.Add(CreateRow(apr.ATAChapter.ToString(), apr.ATAChapter));
                subItems.Add(CreateRow(apr.Title, apr.Title ));
                subItems.Add(CreateRow(apr.Description, apr.Description));
                subItems.Add(CreateRow(apr.KitsToString, apr.Kits.Count));
                subItems.Add(CreateRow(apr.OnLifelength.ToString(), apr.OnLifelength));
                subItems.Add(CreateRow(apr.Parent.Threshold.RepeatInterval.ToString(), apr.Parent.Threshold.RepeatInterval));
                subItems.Add(CreateRow(remains.ToString(), remains));
                subItems.Add(CreateRow(apr.WorkType, apr.WorkType));
				subItems.Add(CreateRow(apr.NDTString, apr.NDTString));
				subItems.Add(CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(apr.RecordDate), apr.RecordDate));
				subItems.Add(CreateRow(_currentWorkPackage.PerformDate, _currentWorkPackage.PerformDate));
				subItems.Add(CreateRow(manHours.ToString(), manHours));
                subItems.Add(CreateRow(KmanHours.ToString("F"), KmanHours));
                subItems.Add(CreateRow(cost.ToString(), cost));
                subItems.Add(CreateRow(author, Tag = author));
			}
            else if (item is Directive)
            {
                var directive = (Directive)item;

                var ata = directive.ATAChapter;
                author = GlobalObjects.CasEnvironment.GetCorrector(directive.CorrectorId);
                var KManHours = directive.ManHours * _currentWorkPackage.KMH;
				subItems.Add(CreateRow(ata.ToString(), ata));
                subItems.Add(CreateRow($"{directive.EngineeringOrders} {directive.Title}", directive.Title));
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

                subItems.Add(CreateRow(directive.WorkType.ToString(), Tag = directive.WorkType));
				#endregion

				subItems.Add(CreateRow(directive.NDTType.ShortName, directive.NDTType.ShortName));

				#region Определение текста для колонки "Следующее выполнение"
				subItems.Add(CreateRow(directive.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)directive.NextPerformanceDate),
                    directive.NextPerformanceDate
                ));
				#endregion

				#region Определение текста для колонки "Человек/Часы"
				subItems.Add(CreateRow(_currentWorkPackage.PerformDate, _currentWorkPackage.PerformDate ));
				subItems.Add(CreateRow(directive.ManHours.ToString(), directive.ManHours ));
                subItems.Add(CreateRow(KManHours.ToString(), KManHours ));
                #endregion

                #region Определение текста для колонки "Стоимость"

                subItems.Add(CreateRow(directive.Cost.ToString(), directive.Cost));
				#endregion

				subItems.Add(CreateRow(author, author ));

			}
            else if (item is BaseComponent)
            {
                var bd = (BaseComponent)item;
                var ata = bd.ATAChapter;
                author = GlobalObjects.CasEnvironment.GetCorrector(bd.CorrectorId);
                var KManHours = bd.ManHours * _currentWorkPackage.KMH;
				subItems.Add(CreateRow(ata.ToString(), ata));
                subItems.Add(CreateRow(bd.PartNumber, bd.PartNumber));
                subItems.Add(CreateRow(bd.Description, bd.Description));
                subItems.Add(CreateRow(bd.Kits.Count > 0 ? bd.Kits.Count + " kits" : "", bd.Kits.Count));
                subItems.Add(CreateRow(bd.LifeLimit.ToString(), bd.LifeLimit));
                subItems.Add(CreateRow( "", Lifelength.Null));
                subItems.Add(CreateRow(bd.Remains.ToString(), bd.Remains));
                subItems.Add(CreateRow(ComponentRecordType.Remove.ToString(), ComponentRecordType.Remove));
				subItems.Add(CreateRow( "", "" ));
				subItems.Add(CreateRow(bd.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)bd.NextPerformanceDate), bd.NextPerformanceDate));
				subItems.Add(CreateRow(_currentWorkPackage.PerformDate, _currentWorkPackage.PerformDate));
				subItems.Add(CreateRow(bd.ManHours.ToString(), bd.ManHours));
                subItems.Add(CreateRow(KManHours.ToString("F"), KManHours));
                subItems.Add(CreateRow(bd.Cost.ToString(), bd.Cost));
                subItems.Add(CreateRow(author, author));
			}
            else if (item is Component)
            {
                var d = (Component)item;
                var ata = d.ATAChapter;
                author = GlobalObjects.CasEnvironment.GetCorrector(d.CorrectorId);
                var KManHours = d.ManHours * _currentWorkPackage.KMH;
				subItems.Add(CreateRow(ata.ToString(), ata));
                subItems.Add(CreateRow(d.PartNumber, d.PartNumber));
                subItems.Add(CreateRow(d.Description, d.Description));
                subItems.Add(CreateRow(d.Kits.Count > 0 ? d.Kits.Count + " kits" : "", d.Kits.Count));
                subItems.Add(CreateRow(d.LifeLimit != null ? d.LifeLimit.ToString() : "", d.LifeLimit));
                subItems.Add(CreateRow("", Lifelength.Null));
                subItems.Add(CreateRow(d.Remains != null ? d.Remains.ToString() : "", d.Remains));
                subItems.Add(CreateRow(ComponentRecordType.Remove.ToString(), ComponentRecordType.Remove));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow(d.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)d.NextPerformanceDate), d.NextPerformanceDate));
				subItems.Add(CreateRow(_currentWorkPackage.PerformDate, _currentWorkPackage.PerformDate));
				subItems.Add(CreateRow(d.ManHours.ToString(), d.ManHours));
                subItems.Add(CreateRow(KManHours.ToString("F"), KManHours));
                subItems.Add(CreateRow(d.Cost.ToString(), d.Cost));
                subItems.Add(CreateRow(author, author));
			}
            else if (item is ComponentDirective)
            {
                var dd = (ComponentDirective)item;
                var ata = dd.ParentComponent.ATAChapter;
                author = GlobalObjects.CasEnvironment.GetCorrector(dd.CorrectorId);
                var KManHours = dd.ManHours * _currentWorkPackage.KMH;
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
                subItems.Add(CreateRow(dd.Remains.ToString(), dd.Remains));
                subItems.Add(CreateRow(dd.DirectiveType.ToString(), dd.DirectiveType));
				subItems.Add(CreateRow(dd.NDTType.ShortName, dd.NDTType.ShortName));
				subItems.Add(CreateRow(dd.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)dd.NextPerformanceDate), dd.NextPerformanceDate));
				subItems.Add(CreateRow(_currentWorkPackage.PerformDate, _currentWorkPackage.PerformDate));
				subItems.Add(CreateRow(dd.ManHours.ToString(), dd.ManHours));
                subItems.Add(CreateRow(KManHours.ToString("F"), KManHours));
                subItems.Add(CreateRow(dd.Cost.ToString(), dd.Cost));
                subItems.Add(CreateRow(author, author));
			}
            else if (item is MaintenanceCheck)
            {
                var mc = (MaintenanceCheck)item;
                author = GlobalObjects.CasEnvironment.GetCorrector(mc.CorrectorId);
                var KManHours = mc.ManHours * _currentWorkPackage.KMH;
				subItems.Add(CreateRow("", null));
                subItems.Add(CreateRow("", ""));
                subItems.Add(CreateRow(mc.Name + (mc.Schedule ? " Shedule" : " Unshedule"), mc.Name));
                subItems.Add(CreateRow(mc.Kits.Count > 0 ? mc.Kits.Count + " kits" : "", mc.Kits.Count));
                subItems.Add(CreateRow(mc.Interval.ToString(), mc.Interval));
                subItems.Add(CreateRow( "", Lifelength.Null));
                subItems.Add(CreateRow(mc.Remains.ToString(), mc.Remains));
                subItems.Add(CreateRow( "", "" ));
				subItems.Add(CreateRow( "", "" ));
				subItems.Add(CreateRow(mc.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)mc.NextPerformanceDate), mc.NextPerformanceDate));
				subItems.Add(CreateRow(_currentWorkPackage.PerformDate, _currentWorkPackage.PerformDate));
				subItems.Add(CreateRow(mc.ManHours.ToString(), mc.ManHours));
                subItems.Add(CreateRow(KManHours.ToString("F"), KManHours));
                subItems.Add(CreateRow(mc.Cost.ToString(), mc.Cost));
                subItems.Add(CreateRow(author, author));
			}
            else if (item is MaintenanceDirective)
            {
                var md = (MaintenanceDirective)item;
                var ata = md.ATAChapter;
                author = GlobalObjects.CasEnvironment.GetCorrector(md.CorrectorId);
                var KManHours = md.ManHours * _currentWorkPackage.KMH;
				subItems.Add(CreateRow(ata != null ? ata.ToString() : "", ata));
                subItems.Add(CreateRow($"{md.TaskCardNumber} {md.TaskNumberCheck} {md.Description}", md.ToString()));
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
				subItems.Add(CreateRow(md.NDTType.ShortName, Tag = md.NDTType.ShortName));
				subItems.Add(CreateRow(md.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)md.NextPerformanceDate), md.NextPerformanceDate));
				subItems.Add(CreateRow(_currentWorkPackage.PerformDate, _currentWorkPackage.PerformDate));
				subItems.Add(CreateRow(md.ManHours.ToString(), md.ManHours));
                subItems.Add(CreateRow(KManHours.ToString("F"), KManHours));
                subItems.Add(CreateRow(md.Cost.ToString(), md.Cost));
                subItems.Add(CreateRow(author, author));
			}
            else if (item is NonRoutineJob)
            {
                var job = (NonRoutineJob)item;
                var ata = job.ATAChapter;
                author = GlobalObjects.CasEnvironment.GetCorrector(job.CorrectorId);
                var KManHours = job.ManHours * _currentWorkPackage.KMH;
				subItems.Add(CreateRow(ata != null ? ata.ToString() : "", ata));
                subItems.Add(CreateRow(job.Title, job.Title));
                subItems.Add(CreateRow(job.Description, job.Description));
                subItems.Add(CreateRow(job.Kits.Count > 0 ? job.Kits.Count + " kits" : "", job.Kits.Count));
                subItems.Add(CreateRow("", Lifelength.Null));
                subItems.Add(CreateRow("", Lifelength.Null));
                subItems.Add(CreateRow("", Lifelength.Null));
                subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow("", "" ));
				subItems.Add(CreateRow("", DateTimeExtend.GetCASMinDateTime()));
				subItems.Add(CreateRow(_currentWorkPackage.PerformDate, _currentWorkPackage.PerformDate));
				subItems.Add(CreateRow(job.ManHours.ToString(), job.ManHours));
                subItems.Add(CreateRow(KManHours.ToString("F"), KManHours ));
                subItems.Add(CreateRow(job.Cost.ToString(), job.Cost ));
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

        #endregion
    }
}
