using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.DetailsControls;
using CAS.UI.UIControls.DirectivesControls;
using CAS.UI.UIControls.StoresControls;
using CAS.UI.UIControls.WorkPakage;
using CASTerms;
using EFCore.DTO.Dictionaries;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Directives;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;
using SmartCore.Entities.General.WorkPackage;
using Convert = System.Convert;

namespace CAS.UI.UIControls.MaintananceProgram
{
    ///<summary>
    /// список для отображения событий системы безопасности полетов
    ///</summary>
    public partial class MaintenanceCheckBindTaskListView : CommonListViewControl
    {
        #region public MaintenanceCheckBindTaskListView()
        ///<summary>
        ///</summary>
        public MaintenanceCheckBindTaskListView()
        {
            InitializeComponent();
        }
        #endregion

        #region public new List<BaseEntityObject> SelectedItems
        /// <summary>
        /// Возвращает выбранные элементы
        /// </summary>
        public new List<BaseEntityObject> SelectedItems
        {
            get
            {
                return base.SelectedItems.OfType<BaseEntityObject>().ToList();
            }
        }
        #endregion

        #region Methods

        #region public void SetItemsArray(ICommonCollection itemsArray)

        public override void SetItemsArray(IEnumerable<BaseEntityObject> itemsArray)
        {
            if (_selectedItemsList == null)
                _selectedItemsList = new CommonCollection<BaseEntityObject>();
            base.SetItemsArray(itemsArray);
        }
        #endregion

        #region public override void SetItemsArray(ICommonCollection itemsArray)

        public override void SetItemsArray(ICommonCollection itemsArray)
        {
            if(_selectedItemsList == null)
                _selectedItemsList = new CommonCollection<BaseEntityObject>();
            base.SetItemsArray(itemsArray);
        }
        #endregion

        #region protected override void SetHeaders()
        /// <summary>
        /// Устанавливает заголовки
        /// </summary>
        protected override void SetHeaders()
        {
            ColumnHeaderList.Clear();

            ColumnHeader columnHeader = new ColumnHeader { Width = 102, Text = "ATA" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 160, Text = "Title" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 80, Text = "Description" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 80, Text = "Type" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 80, Text = "Kit Required" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 80, Text = "Fst.Perf" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 80, Text = "Rpt. Intv." };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 80, Text = "Overdue/Remain" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 80, Text = "Work Type" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 80, Text = "Next Perf. Date" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 80, Text = "MH" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = 80, Text = "Cost" };
            ColumnHeaderList.Add(columnHeader);

            itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
        #endregion

        #region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnDisplayerRequested();
        }
        #endregion

        #region protected override SetGroupsToItems()
        /// <summary>
        /// Выполняет группировку элементов
        /// </summary>
        protected override void SetGroupsToItems()
        {
            itemsListView.Groups.Clear();

            if(OldColumnIndex != 9)
            {
                foreach (var item in ListViewItemList)
                {
					var temp = ListViewGroupHelper.GetGroupString(item.Tag);

					itemsListView.Groups.Add(temp, temp);
					item.Group = itemsListView.Groups[temp];
				}
            }
            else
            {
                //Группировка элементов по датам выполнения
                var groupedItems = ListViewItemList.Where(lvi => lvi.Tag != null && 
																 lvi.Tag is NextPerformance)
												   .GroupBy(lvi => Convert.ToDateTime(((NextPerformance)lvi.Tag).PerformanceDate).Date);
                foreach (var groupedItem in groupedItems)
                {
                    //Собрание всех выполнений на данную дату в одну коллекцию
                    var performances = groupedItem.Select(lvi => lvi.Tag as NextPerformance).ToList();

	                var temp = ListViewGroupHelper.GetGroupStringByPerformanceDate(performances, groupedItem.Key.Date);

                    itemsListView.Groups.Add(temp, temp);
                    foreach (var item in groupedItem)
                        item.Group = itemsListView.Groups[temp];     
                }
            }
        }
        #endregion

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
            OldColumnIndex = columnIndex;

            //List<ListViewItem> resultList = new List<ListViewItem>();

            if (columnIndex != 8)
            {
                SetGroupsToItems();

                ListViewItemList.Sort(new BaseListViewComparer(columnIndex, SortMultiplier));
                //добавление остальных подзадач
                //foreach (ListViewItem item in ListViewItemList)
                //{
                    //resultList.Add(item);
                    //NextPerformance np = (NextPerformance)item.Tag;
                    //if (np.Parent is MaintenanceCheck && ((MaintenanceCheck)np.Parent).Grouping)
                    //{
                    //    MaintenanceCheck mc = (MaintenanceCheck)np.Parent;
                    //    List<MaintenanceNextPerformance> performances = mc.GetPergormanceGroupWhereCheckIsSenior();
                    //    if (performances == null || performances.Count == 1) continue;
                    //    for (int i = 1; i < performances.Count; i++)
                    //    {
                    //        ListViewItem temp = new ListViewItem(GetListViewSubItems(performances[i]), null)
                    //        {
                    //            Tag = performances[i],
                    //            Group = item.Group
                    //        };
                    //        resultList.Add(temp);
                    //    }
                    //}
                    //else
                    //{
                    //    //первая подзадача описывает саму родитескую задачу, повторно ее добавлять ненадо
                    //    if (np.Parent.NextPerformances == null || np.Parent.NextPerformances.Count <= 1) continue;
                    //    for (int i = 1; i < np.Parent.NextPerformances.Count; i++)
                    //    {
                    //        ListViewItem temp = new ListViewItem(GetListViewSubItems(np.Parent.NextPerformances[i]), null)
                    //        {
                    //            Tag = np.Parent.NextPerformances[i],
                    //            Group = item.Group
                    //        };
                    //        resultList.Add(temp);
                    //    }
                    //}
                //}
            }
            else
            {
                //foreach (ListViewItem item in ListViewItemList)
                //{
                //    resultList.Add(item);
                    //NextPerformance np = (NextPerformance)item.Tag;
                    //if (np.Parent is MaintenanceCheck && ((MaintenanceCheck)np.Parent).Grouping)
                    //{
                    //    MaintenanceCheck mc = (MaintenanceCheck)np.Parent;
                    //    List<MaintenanceNextPerformance> performances = mc.GetPergormanceGroupWhereCheckIsSenior();
                    //    if (performances == null || performances.Count == 1) continue;
                    //    for (int i = 1; i < performances.Count; i++)
                    //    {
                    //        ListViewItem temp = new ListViewItem(GetListViewSubItems(performances[i]), null)
                    //        {
                    //            Tag = performances[i],
                    //            Group = item.Group
                    //        };
                    //        resultList.Add(temp);
                    //    }
                    //}
                    //else
                    //{
                    //    //первая подзадача описывает саму родитескую задачу, повторно ее добавлять ненадо
                    //    if (np.Parent.NextPerformances == null || np.Parent.NextPerformances.Count <= 1) continue;
                    //    for (int i = 1; i < np.Parent.NextPerformances.Count; i++)
                    //    {
                    //        ListViewItem temp = new ListViewItem(GetListViewSubItems(np.Parent.NextPerformances[i]), null)
                    //        {
                    //            Tag = np.Parent.NextPerformances[i],
                    //        };
                    //        resultList.Add(temp);
                    //    }
                    //}
                //}

                ListViewItemList.Sort(new DirectiveListViewComparer(columnIndex, SortMultiplier));
                //itemsListView.Groups.Clear();
                //foreach (ListViewItem item in resultList)
                //{
                //    DateTime date = new DateTime(1950, 1, 1);
                //    if (item.Tag is NextPerformance)
                //    {
                //        NextPerformance np = (NextPerformance)item.Tag;
                //        if (np.PerformanceDate != null)
                //            date = np.PerformanceDate.Value.Date;
                //    }

                //    string temp = date.Date > new DateTime(1950, 1, 1).Date ? SmartCore.Auxiliary.Convert.GetDateFormat(date.Date) : "";
                //    itemsListView.Groups.Add(temp, temp);
                //    item.Group = itemsListView.Groups[temp];
                //}

                SetGroupsToItems();

            }
            itemsListView.Items.AddRange(ListViewItemList.ToArray());
        }

        #endregion

        #region protected override void SetItemColor(ListViewItem listViewItem, BaseSmartCoreObject item)
        protected override void SetItemColor(ListViewItem listViewItem, BaseEntityObject item)
        {
            if (item is NextPerformance)
            {
                NextPerformance nextPerformance = item as NextPerformance;
                if (nextPerformance.BlockedByPackage != null)
                {
                    listViewItem.ToolTipText = "This performance blocked by work package:" +
                       nextPerformance.BlockedByPackage.Title;
                    listViewItem.BackColor = Color.FromArgb(Highlight.Grey.Color);
                }
                else if (nextPerformance.Condition == ConditionState.Notify)
                    listViewItem.BackColor = Color.FromArgb(Highlight.Yellow.Color);
                else if (nextPerformance.Condition == ConditionState.Overdue)
                    listViewItem.BackColor = Color.FromArgb(Highlight.Red.Color);

                if (nextPerformance.Parent.IsDeleted)
                {
                    //запись так же может быть удаленной

                    //шрифт серым цветом
                    listViewItem.ForeColor = Color.Gray;
                    if (listViewItem.ToolTipText.Trim() != "")
                        listViewItem.ToolTipText += "\n";
                    listViewItem.ToolTipText += string.Format("This {0} is deleted", nextPerformance.Parent.SmartCoreObjectType);
                }
            }
            else if (item is AbstractPerformanceRecord)
            {
                AbstractPerformanceRecord apr = (AbstractPerformanceRecord)item;
                if (apr.Parent.IsDeleted)
                {
                    //запись так же может быть удаленной

                    //шрифт серым цветом
                    listViewItem.ForeColor = Color.Gray;
                    if (listViewItem.ToolTipText.Trim() != "")
                        listViewItem.ToolTipText += "\n";
                    listViewItem.ToolTipText += string.Format("This {0} is deleted", apr.Parent.SmartCoreObjectType);
                }
            }
            else
            {
                if (!(item is NonRoutineJob) && !(item is IDirective))
                {
                    //Если это не следующее выполнение, не запись о выполнении, и не рутинная работа
                    //значит, выполнение для данной задачи расчитать нельзя

                    //пометка этого выполнения синим цветом
                    listViewItem.BackColor = Color.FromArgb(Highlight.Blue.Color);
                    //подсказка о том, что выполнение не возможео расчитать
                    listViewItem.ToolTipText = "Performance for this directive can not be calculated";
                }
                else
                {
                    base.SetItemColor(listViewItem, item);
                }

                if (item.IsDeleted)
                {
                    //запись так же может быть удаленной

                    //шрифт серым цветом
                    listViewItem.ForeColor = Color.Gray;
                    if (listViewItem.ToolTipText.Trim() != "")
                        listViewItem.ToolTipText += "\n";
                    listViewItem.ToolTipText += string.Format("This {0} is deleted", item.SmartCoreObjectType);
                }
            }
        }
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(BaseSmartCoreObject item)

        protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(BaseEntityObject item)
        {
            List<ListViewItem.ListViewSubItem> subItems = new List<ListViewItem.ListViewSubItem>();

            //if(item.ItemId == 41043)
            //{

            //}
            if (item is NextPerformance)
            {
                NextPerformance np = (NextPerformance)item;

                double manHours = np.Parent is IEngineeringDirective ? ((IEngineeringDirective)np.Parent).ManHours : 0;
                double cost = np.Parent is IEngineeringDirective ? ((IEngineeringDirective)np.Parent).Cost : 0;

                subItems.Add(new ListViewItem.ListViewSubItem { Text = np.ATAChapter.ToString(), Tag = np.ATAChapter });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = np.Title, Tag = np.Title });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = np.Description, Tag = np.Description });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = np.Type, Tag = np.Type });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = np.KitsToString, Tag = np.Kits.Count });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = np.PerformanceSource.ToString(), Tag = np.PerformanceSource });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = np.Parent.Threshold.RepeatInterval.ToString(), Tag = np.Parent.Threshold.RepeatInterval });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = np.Remains.ToString(), Tag = np.Remains });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = np.WorkType, Tag = np.WorkType });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = np.PerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)np.PerformanceDate), Tag = np.PerformanceDate });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = manHours.ToString(), Tag = manHours });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = cost.ToString(), Tag = cost });

            }
            else if (item is AbstractPerformanceRecord)
            {
                AbstractPerformanceRecord apr = (AbstractPerformanceRecord)item;
                Lifelength remains = Lifelength.Null;

                double manHours = apr.Parent is IEngineeringDirective ? ((IEngineeringDirective)apr.Parent).ManHours : 0;
                double cost = apr.Parent is IEngineeringDirective ? ((IEngineeringDirective)apr.Parent).Cost : 0;

                subItems.Add(new ListViewItem.ListViewSubItem { Text = apr.ATAChapter.ToString(), Tag = apr.ATAChapter });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = apr.Title, Tag = apr.Title });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = apr.Description, Tag = apr.Description });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = apr.KitsToString, Tag = apr.Kits.Count });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = apr.OnLifelength.ToString(), Tag = apr.OnLifelength });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = apr.Parent.Threshold.RepeatInterval.ToString(), Tag = apr.Parent.Threshold.RepeatInterval });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = remains.ToString(), Tag = remains });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = apr.WorkType, Tag = apr.WorkType });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = SmartCore.Auxiliary.Convert.GetDateFormat(apr.RecordDate), Tag = apr.RecordDate });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = manHours.ToString(), Tag = manHours });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = cost.ToString(), Tag = cost });

            }
            else if (item is Directive)
            {
                Directive directive = (Directive)item;
                AtaChapter ata = directive.ATAChapter;
                DirectiveType pdType = directive.DirectiveType;
                subItems.Add(new ListViewItem.ListViewSubItem { Text = ata.ToString(), Tag = ata });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = directive.Title, Tag = directive.Title });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = directive.Description, Tag = directive.Description });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = pdType.ShortName, Tag = pdType.ShortName });

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
                subItems.Add(new ListViewItem.ListViewSubItem { Text = bd.MaintenanceControlProcess.ShortName, Tag = bd.MaintenanceControlProcess.ShortName });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = bd.Kits.Count > 0 ? bd.Kits.Count + " kits" : "", Tag = bd.Kits.Count });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = bd.LifeLimit.ToString(), Tag = bd.LifeLimit });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = Lifelength.Null });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = bd.Remains.ToString(), Tag = bd.Remains });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = ComponentRecordType.Remove.ToString(), Tag = ComponentRecordType.Remove });
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
                subItems.Add(new ListViewItem.ListViewSubItem { Text = d.MaintenanceControlProcess.ShortName, Tag = d.MaintenanceControlProcess.ShortName });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = d.Kits.Count > 0 ? d.Kits.Count + " kits" : "", Tag = d.Kits.Count });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = d.LifeLimit != null ? d.LifeLimit.ToString() : "", Tag = d.LifeLimit });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = Lifelength.Null });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = d.Remains != null ? d.Remains.ToString() : "", Tag = d.Remains });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = ComponentRecordType.Remove.ToString(), Tag = ComponentRecordType.Remove });
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
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
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
                subItems.Add(new ListViewItem.ListViewSubItem { Text = mc.Name, Tag = mc.Name });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = mc.Kits.Count > 0 ? mc.Kits.Count + " kits" : "", Tag = mc.Kits.Count });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = mc.Interval.ToString(), Tag = mc.Interval });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = Lifelength.Null });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = mc.Remains.ToString(), Tag = mc.Remains });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = mc.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)mc.NextPerformanceDate), Tag = mc.NextPerformanceDate });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = mc.ManHours.ToString(), Tag = mc.ManHours });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = mc.Cost.ToString(), Tag = mc.Cost });
            }
            else if (item is MaintenanceDirective)
            {
                MaintenanceDirective md = (MaintenanceDirective)item;
                AtaChapter ata = md.ATAChapter;
                string type = md.MaintenanceCheck != null ? md.MaintenanceCheck.Name : "MPD";

                subItems.Add(new ListViewItem.ListViewSubItem { Text = ata != null ? ata.ToString() : "", Tag = ata });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = md.TaskNumberCheck, Tag = md.TaskNumberCheck });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = md.Description, Tag = md.Description, });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = type, Tag = type, });
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
                subItems.Add(new ListViewItem.ListViewSubItem { Text = md.NextPerformanceDate == null ? "N/A" : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)md.NextPerformanceDate), Tag = md.NextPerformanceDate });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = md.ManHours.ToString(), Tag = md.ManHours });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = md.Cost.ToString(), Tag = md.Cost });
            }
            else if (item is NonRoutineJob)
            {
                NonRoutineJob job = (NonRoutineJob)item;
                AtaChapter ata = job.ATAChapter;
                subItems.Add(new ListViewItem.ListViewSubItem { Text = ata != null ? ata.ToString() : "", Tag = ata });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = "" });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = job.Description, Tag = job.Description });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "NRC", Tag = "NRC" });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = job.Kits.Count > 0 ? job.Kits.Count + " kits" : "", Tag = job.Kits.Count });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = Lifelength.Null });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = Lifelength.Null });
                subItems.Add(new ListViewItem.ListViewSubItem { Text = "", Tag = Lifelength.Null });
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
            if (SelectedItem == null)
            {
                e.Cancel = true;
                return;
            }

			var dp = ScreenAndFormManager.GetEditScreenOrForm(SelectedItem);
			if (dp.DisplayerType == DisplayerType.Screen)
				e.SetParameters(dp);
			else
			{
				if (dp.Form.ShowDialog() == DialogResult.OK)
				{
					if (dp.Form is NonRoutineJobForm)
					{
						var changedJob = GlobalObjects.CasEnvironment.NewLoader.GetObjectById<NonRoutineJobDTO, NonRoutineJob>(((NonRoutineJobForm)dp.Form).CurrentJob.ItemId, true);
						itemsListView.SelectedItems[0].Tag = changedJob;

						ListViewItem.ListViewSubItem[] subs = GetListViewSubItems(SelectedItem);
						for (int i = 0; i < subs.Length; i++)
							itemsListView.SelectedItems[0].SubItems[i].Text = subs[i].Text;
					}
					e.Cancel = true;
				}
			}
		}
        #endregion

        #region private void MaintenanceCheckBindTaskListViewLoad(object sender, EventArgs e)
        private void MaintenanceCheckBindTaskListViewLoad(object sender, EventArgs e)
        {
            SetHeaders();
        }
        #endregion

        #endregion
    }
}
