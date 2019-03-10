using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.UIControls.Auxiliary;
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

namespace CAS.UI.UIControls.WorkPakage
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class WorkPackageView : BaseListViewControl<BaseEntityObject>
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
            ColumnHeaderList.Clear();

            ColumnHeader columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.10f), Text = "ATA" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.16f), Text = "Title" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Description" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Kit Required" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Performance" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Rpt. Intv." };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Overdue/Remain" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Work Type" };
            ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "NDT" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Perf. Date" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "MH" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Cost" };
            ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
		#endregion

		#region protected override SetGroupsToItems(int columnIndex)
		/// <summary>
		/// Выполняет группировку элементов
		/// </summary>
		protected override void SetGroupsToItems(int columnIndex)
        {
            itemsListView.Groups.Clear();
            foreach (var item in ListViewItemList)
            {
				var temp = ListViewGroupHelper.GetGroupString(item.Tag);

				itemsListView.Groups.Add(temp, temp);
				item.Group = itemsListView.Groups[temp];

			}
        }
        #endregion

        #region protected override void SetItemColor(ListViewItem listViewItem, BaseSmartCoreObject item)
        protected override void SetItemColor(ListViewItem listViewItem, BaseEntityObject item)
        {
			listViewItem.ToolTipText = GetToolTipString(item);

			if (item is NextPerformance)
            {
                var nextPerformance = item as NextPerformance;

	            var file = GetItemFile(nextPerformance.Parent); 

	            if (file != null)
	            {
					if (_currentWorkPackage.Status != WorkPackageStatus.Closed)
					{
						if (nextPerformance.BlockedByPackage != null)
							listViewItem.BackColor = Color.FromArgb(Highlight.Grey.Color);
						else if (nextPerformance.Condition == ConditionState.Notify)
							listViewItem.BackColor = Color.FromArgb(Highlight.Yellow.Color);
						else if (nextPerformance.Condition == ConditionState.Overdue)
							listViewItem.BackColor = Color.FromArgb(Highlight.Red.Color);
					}
					else
					{
						//Если это следующее выполнение, но рабочий пакет при этом закрыт
						//значит, выполнение для данной задачи в рамках данного рабочего пакета
						//не было введено
						//пометка этого выполнения краным цветом
						listViewItem.BackColor = Color.FromArgb(Highlight.Red.Color);
					}
					if (nextPerformance.Parent.IsDeleted)
					{
						//запись так же может быть удаленной
						//шрифт серым цветом
						listViewItem.ForeColor = Color.Gray;
					}
				}
	            else
	            {
					listViewItem.UseItemStyleForSubItems = false;
		            for (int i = 0; i < listViewItem.SubItems.Count; i++)
		            {
						if (_currentWorkPackage.Status != WorkPackageStatus.Closed)
						{
							if (nextPerformance.BlockedByPackage != null)
								listViewItem.SubItems[i].BackColor = Color.FromArgb(Highlight.Grey.Color);
							else if (nextPerformance.Condition == ConditionState.Notify)
								listViewItem.SubItems[i].BackColor = Color.FromArgb(Highlight.Yellow.Color);
							else if (nextPerformance.Condition == ConditionState.Overdue)
								listViewItem.SubItems[i].BackColor = Color.FromArgb(Highlight.Red.Color);
						}
						else
							listViewItem.SubItems[i].BackColor = Color.FromArgb(Highlight.Red.Color);

						if (nextPerformance.Parent.IsDeleted)
							listViewItem.SubItems[i].ForeColor = Color.Gray;

						if (i == 1)
							listViewItem.SubItems[i].ForeColor = Color.MediumVioletRed;
					}
				}  
            }
            else if (item is AbstractPerformanceRecord)
            {
                var apr = (AbstractPerformanceRecord) item;

				var file = GetItemFile(apr.Parent);

	            if (file != null)
	            {
					if (apr.Parent.IsDeleted)
						listViewItem.ForeColor = Color.Gray;
				}
	            else
	            {
					listViewItem.UseItemStyleForSubItems = false;
		            for (int i = 0; i < listViewItem.SubItems.Count; i++)
		            {
						if (apr.Parent.IsDeleted)
							listViewItem.SubItems[i].ForeColor = Color.Gray;

						if (i == 1)
							listViewItem.SubItems[i].ForeColor = Color.MediumVioletRed;
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
						listViewItem.BackColor = Color.FromArgb(Highlight.Blue.Color);
					}
					if (item.IsDeleted)
						listViewItem.ForeColor = Color.Gray;
				}
	            else
	            {
					listViewItem.UseItemStyleForSubItems = false;
		            for (int i = 0; i < listViewItem.SubItems.Count; i++)
		            {
						if (!(item is NonRoutineJob))
						{
							//Если это не следующее выполнение, не запись о выполнении, и не рутинная работа
							//значит, выполнение для данной задачи расчитать нельзя

							//пометка этого выполнения синим цветом
							listViewItem.SubItems[i].BackColor = Color.FromArgb(Highlight.Blue.Color);
						}

						if (item.IsDeleted)
							listViewItem.SubItems[i].ForeColor = Color.Gray;

						if (i == 1)
							listViewItem.SubItems[i].ForeColor = Color.MediumVioletRed;
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

		    protected override
		    ListViewItem.ListViewSubItem[] GetListViewSubItems(BaseEntityObject item)
        {
            List<ListViewItem.ListViewSubItem> subItems = new List<ListViewItem.ListViewSubItem>();

            if(item is NextPerformance)
            {
                NextPerformance np = (NextPerformance) item;

                double manHours = np.Parent is IEngineeringDirective ? ((IEngineeringDirective)np.Parent).ManHours : 0;
                double cost = np.Parent is IEngineeringDirective ? ((IEngineeringDirective)np.Parent).Cost : 0;
                subItems.Add(new ListViewItem.ListViewSubItem { Text = np.ATAChapter.ToString(), Tag = np.ATAChapter });
                if (np.Parent is ComponentDirective)
                {
	                var cd = np.Parent as ComponentDirective;


	                subItems.Add(new ListViewItem.ListViewSubItem { Text = $"{cd.MaintenanceDirective?.TaskCardNumber} {np.Title}", Tag = np.Title });
				}
				else if (np.Parent is Directive)
                {
	                var directive = np.Parent as Directive;
	                var title = "";
	                if (!string.IsNullOrEmpty(directive.EngineeringOrders))
		                title += $"EO:{directive.EngineeringOrders} ";
	                if (!string.IsNullOrEmpty(directive.Title))
		                title += $"AD:{directive.Title} ";

					subItems.Add(new ListViewItem.ListViewSubItem { Text = title, Tag = directive.Title });
				}
                else subItems.Add(new ListViewItem.ListViewSubItem { Text = np.Title, Tag = np.Title });

                
                subItems.Add(new ListViewItem.ListViewSubItem { Text = np.Description, Tag = np.Description });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = np.KitsToString, Tag = np.Kits.Count });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = np.PerformanceSource.ToString(), Tag = np.PerformanceSource });


	            if (np.Parent is MaintenanceDirective)
	            {
		            var d = np.Parent as MaintenanceDirective;
		            subItems.Add(new ListViewItem.ListViewSubItem { Text = d.PhaseRepeat?.ToString(), Tag = d.PhaseRepeat });
	            }
	            else subItems.Add(new ListViewItem.ListViewSubItem { Text = np.Parent.Threshold.RepeatInterval.ToString(), Tag = np.Parent.Threshold.RepeatInterval });

                subItems.Add(new ListViewItem.ListViewSubItem { Text = np.Remains.ToString(), Tag = np.Remains });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = np.WorkType, Tag = np.WorkType });
				subItems.Add(new ListViewItem.ListViewSubItem { Text = np.NDTString, Tag = np.NDTString });
				subItems.Add(new ListViewItem.ListViewSubItem { Text = np.PerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)np.PerformanceDate), Tag = np.PerformanceDate });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = manHours.ToString(), Tag = manHours });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = cost.ToString(), Tag = cost });

			}
            else if (item is AbstractPerformanceRecord)
            {
                //DirectiveRecord directiveRecord = (DirectiveRecord)item;
                AbstractPerformanceRecord apr = (AbstractPerformanceRecord)item;
                double manHours = apr.Parent is IEngineeringDirective ? ((IEngineeringDirective)apr.Parent).ManHours : 0;
                double cost = apr.Parent is IEngineeringDirective ? ((IEngineeringDirective)apr.Parent).Cost : 0;
                Lifelength remains = Lifelength.Null;
                subItems.Add(new ListViewItem.ListViewSubItem { Text = apr.ATAChapter.ToString(), Tag = apr.ATAChapter });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = apr.Title, Tag = apr.Title });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = apr.Description, Tag = apr.Description });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = apr.KitsToString, Tag = apr.Kits.Count });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = apr.OnLifelength.ToString(), Tag = apr.OnLifelength });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = apr.Parent.Threshold.RepeatInterval.ToString(), Tag = apr.Parent.Threshold.RepeatInterval });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = remains.ToString(), Tag = remains });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = apr.WorkType, Tag = apr.WorkType });
				subItems.Add(new ListViewItem.ListViewSubItem { Text = apr.NDTString, Tag = apr.NDTString });
				subItems.Add(new ListViewItem.ListViewSubItem { Text = SmartCore.Auxiliary.Convert.GetDateFormat(apr.RecordDate), Tag = apr.RecordDate });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = manHours.ToString(), Tag = manHours });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = cost.ToString(), Tag = cost });

			}
            else if (item is Directive)
            {
                Directive directive = (Directive)item;

                AtaChapter ata = directive.ATAChapter;
                subItems.Add(new ListViewItem.ListViewSubItem { Text = ata.ToString(), Tag = ata });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = $"{directive.EngineeringOrders} {directive.Title}", Tag = directive.Title });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = directive.Description, Tag = directive.Description });

                #region Определение текста для колонки "КИТы"
                subItems.Add(new ListViewItem.ListViewSubItem
                {
                    Text = directive.Kits.Count > 0 ? directive.Kits.Count + " kits" : "",
                    Tag = directive.Kits.Count
                });
                #endregion

                #region Определение текста для колонки "Первое выполнение"

                ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();
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

                subItem = new ListViewItem.ListViewSubItem();
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
                subItems.Add(new ListViewItem.ListViewSubItem
                {
                    Text = directive.Remains.ToString(),
                    Tag = directive.Remains
                });
                #endregion

                #region Определение текста для колонки "Тип работ"

                subItems.Add(new ListViewItem.ListViewSubItem { Text = directive.WorkType.ToString(), Tag = directive.WorkType });
				#endregion

				subItems.Add(new ListViewItem.ListViewSubItem { Text = directive.NDTType.ShortName, Tag = directive.NDTType.ShortName });

				#region Определение текста для колонки "Следующее выполнение"
				subItems.Add(new ListViewItem.ListViewSubItem
                {
                    Text = directive.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)directive.NextPerformanceDate),
                    Tag = directive.NextPerformanceDate
                });
                #endregion

                #region Определение текста для колонки "Человек/Часы"

                subItems.Add(new ListViewItem.ListViewSubItem { Text = directive.ManHours.ToString(), Tag = directive.ManHours });
                #endregion

                #region Определение текста для колонки "Стоимость"

                subItems.Add(new ListViewItem.ListViewSubItem { Text = directive.Cost.ToString(), Tag = directive.Cost });
				#endregion


			}
            else if (item is BaseComponent)
            {
                BaseComponent bd = (BaseComponent)item;
                AtaChapter ata = bd.ATAChapter;

                subItems.Add(new ListViewItem.ListViewSubItem { Text = ata.ToString(), Tag = ata });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = bd.PartNumber, Tag = bd.PartNumber });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = bd.Description, Tag = bd.Description });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = bd.Kits.Count > 0 ? bd.Kits.Count + " kits" : "", Tag = bd.Kits.Count });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = bd.LifeLimit.ToString(), Tag = bd.LifeLimit });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = Lifelength.Null });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = bd.Remains.ToString(), Tag = bd.Remains });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = ComponentRecordType.Remove.ToString(), Tag = ComponentRecordType.Remove });
				subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
				subItems.Add(new ListViewItem.ListViewSubItem { Text = bd.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)bd.NextPerformanceDate), Tag = bd.NextPerformanceDate });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = bd.ManHours.ToString(), Tag = bd.ManHours });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = bd.Cost.ToString(), Tag = bd.Cost });
			}
            else if (item is Component)
            {
                Component d = (Component)item;
                AtaChapter ata = d.ATAChapter;

                subItems.Add(new ListViewItem.ListViewSubItem { Text = ata.ToString(), Tag = ata });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = d.PartNumber, Tag = d.PartNumber });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = d.Description, Tag = d.Description });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = d.Kits.Count > 0 ? d.Kits.Count + " kits" : "", Tag = d.Kits.Count });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = d.LifeLimit != null ? d.LifeLimit.ToString() : "", Tag = d.LifeLimit });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = Lifelength.Null });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = d.Remains != null ? d.Remains.ToString() : "", Tag = d.Remains });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = ComponentRecordType.Remove.ToString(), Tag = ComponentRecordType.Remove });
				subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
				subItems.Add(new ListViewItem.ListViewSubItem { Text = d.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)d.NextPerformanceDate), Tag = d.NextPerformanceDate });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = d.ManHours.ToString(), Tag = d.ManHours });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = d.Cost.ToString(), Tag = d.Cost });
			}
            else if (item is ComponentDirective)
            {
                ComponentDirective dd = (ComponentDirective)item;
                AtaChapter ata = dd.ParentComponent.ATAChapter;

                subItems.Add(new ListViewItem.ListViewSubItem { Text = ata != null ? ata.ToString() : "", Tag = ata });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = dd.Remarks, Tag = dd.Remarks });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = dd.Kits.Count > 0 ? dd.Kits.Count + " kits" : "", Tag = dd.Kits.Count });
                #region Определение текста для колонки "Первое выполнение"

                ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();
                if (dd.Threshold.FirstPerformanceSinceNew != null && !dd.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
                {
                    subItem.Text = "s/n: " + dd.Threshold.FirstPerformanceSinceNew;
                    subItem.Tag = dd.Threshold.FirstPerformanceSinceNew;
                }
                subItems.Add(subItem);
                #endregion
                #region Определение текста для колонки "повторяющийся интервал"

                subItem = new ListViewItem.ListViewSubItem();
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
                subItems.Add(new ListViewItem.ListViewSubItem { Text = dd.Remains.ToString(), Tag = dd.Remains });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = dd.DirectiveType.ToString(), Tag = dd.DirectiveType });
				subItems.Add(new ListViewItem.ListViewSubItem { Text = dd.NDTType.ShortName, Tag = dd.NDTType.ShortName });
				subItems.Add(new ListViewItem.ListViewSubItem { Text = dd.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)dd.NextPerformanceDate), Tag = dd.NextPerformanceDate });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = dd.ManHours.ToString(), Tag = dd.ManHours });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = dd.Cost.ToString(), Tag = dd.Cost });
			}
            else if (item is MaintenanceCheck)
            {
                MaintenanceCheck mc = (MaintenanceCheck)item;
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = null });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = mc.Name + (mc.Schedule ? " Shedule" : " Unshedule"), Tag = mc.Name });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = mc.Kits.Count > 0 ? mc.Kits.Count + " kits" : "", Tag = mc.Kits.Count });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = mc.Interval.ToString(), Tag = mc.Interval });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = Lifelength.Null });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = mc.Remains.ToString(), Tag = mc.Remains });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
				subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
				subItems.Add(new ListViewItem.ListViewSubItem { Text = mc.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)mc.NextPerformanceDate), Tag = mc.NextPerformanceDate });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = mc.ManHours.ToString(), Tag = mc.ManHours });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = mc.Cost.ToString(), Tag = mc.Cost });
			}
            else if (item is MaintenanceDirective)
            {
                MaintenanceDirective md = (MaintenanceDirective)item;
                AtaChapter ata = md.ATAChapter;

                subItems.Add(new ListViewItem.ListViewSubItem { Text = ata != null ? ata.ToString() : "", Tag = ata });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = md.ToString(), Tag = md.ToString() });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = md.Description, Tag = md.Description, });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = md.Kits.Count > 0 ? md.Kits.Count + " kits" : "", Tag = md.Kits.Count });
                #region Определение текста для колонки "Первое выполнение"

                ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();
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

                subItem = new ListViewItem.ListViewSubItem();
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
                subItems.Add(new ListViewItem.ListViewSubItem { Text = md.Remains.ToString(), Tag = md.Remains });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = md.WorkType.ToString(), Tag = md.WorkType });
				subItems.Add(new ListViewItem.ListViewSubItem { Text = md.NDTType.ShortName, Tag = md.NDTType.ShortName });
				subItems.Add(new ListViewItem.ListViewSubItem { Text = md.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)md.NextPerformanceDate), Tag = md.NextPerformanceDate });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = md.ManHours.ToString(), Tag = md.ManHours });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = md.Cost.ToString(), Tag = md.Cost });
			}
            else if (item is NonRoutineJob)
            {
                NonRoutineJob job = (NonRoutineJob)item;
                AtaChapter ata = job.ATAChapter;
                subItems.Add(new ListViewItem.ListViewSubItem { Text = ata != null ? ata.ToString() : "", Tag = ata });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = job.Title, Tag = job.Title });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = job.Description, Tag = job.Description });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = job.Kits.Count > 0 ? job.Kits.Count + " kits" : "", Tag = job.Kits.Count });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = Lifelength.Null });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = Lifelength.Null });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = Lifelength.Null });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
				subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
				subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = DateTimeExtend.GetCASMinDateTime() });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = job.ManHours.ToString(), Tag = job.ManHours });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = job.Cost.ToString(), Tag = job.Cost });
			}
            else throw new ArgumentOutOfRangeException(String.Format("1135: Takes an argument has no known type {0}", item.GetType()));

            return subItems.ToArray();
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
						itemsListView.SelectedItems[0].Tag = changedJob;

						ListViewItem.ListViewSubItem[] subs = GetListViewSubItems(SelectedItem);
						for (int i = 0; i < subs.Length; i++)
							itemsListView.SelectedItems[0].SubItems[i].Text = subs[i].Text;
					}
				}
				e.Cancel = true;
			}
        }
        #endregion

        #endregion
    }
}
