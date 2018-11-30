using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Interfaces;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using SmartCore.Auxiliary;
using SmartCore.Auxiliary.Extentions;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;

namespace CAS.UI.UIControls.MaintananceProgram
{
    ///<summary>
    /// список для отображения событий системы безопасности полетов
    ///</summary>
    public partial class MaintenanceDirectiveBindComponentListView : CommonListViewControl
    {
        #region public MaintenanceDirectiveBindDetailListView()
        ///<summary>
        ///</summary>
        public MaintenanceDirectiveBindComponentListView()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods

        #region public override void SetItemsArray(ICommonCollection itemsArray)

        public override void SetItemsArray(ICommonCollection itemsArray)
        {
            if (_selectedItemsList == null)
                _selectedItemsList = new CommonCollection<BaseEntityObject>();
            base.SetItemsArray(itemsArray);
        }
        #endregion

        #region public override void SetItemsArray(IEnumerable<BaseEntityObject> itemsArray)

        public override void SetItemsArray(IEnumerable<BaseEntityObject> itemsArray)
        {
            if (_selectedItemsList == null)
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
            itemsListView.Columns.Clear();
            ColumnHeaderList.Clear();

            ColumnHeader columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "ATA" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Part. No" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.3f), Text = "Description" };
            ColumnHeaderList.Add(columnHeader);
            //4
            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Serial No" };
            ColumnHeaderList.Add(columnHeader);
            //5
            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Pos. No" };
            ColumnHeaderList.Add(columnHeader);
            //6
            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.07f), Text = "M.P." };
            ColumnHeaderList.Add(columnHeader);
            //7
            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Inst. date" };
            ColumnHeaderList.Add(columnHeader);
            //6
            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.07f), Text = "Work Type" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Life limit/1st. Perf" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Rpt. int." };
            ColumnHeaderList.Add(columnHeader);

            //9
            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Next" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Remain/Overdue" };
            ColumnHeaderList.Add(columnHeader);
            //11
            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Last" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Warranty" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Kit" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "M.H." };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Cost(new)" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Cost overhaul" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Cost serviceable" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Remarks" };
            ColumnHeaderList.Add(columnHeader);
            //19
            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Hidden Remarks" };
            ColumnHeaderList.Add(columnHeader);

            itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
        #endregion

        #region protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        protected override void ItemsListViewMouseDoubleClick(object sender, MouseEventArgs e)
        {
        
        }
        #endregion

        #region protected override SetGroupsToItems()
        /// <summary>
        /// Выполняет группировку элементов
        /// </summary>
        protected override void SetGroupsToItems()
        {
            itemsListView.Groups.Clear();
            foreach (ListViewItem listViewItem in ListViewItemList)
            {
                string groupName = "";
                if (listViewItem.Tag is BaseComponent)
                {
                    if (((BaseComponent)listViewItem.Tag).BaseComponentType == BaseComponentType.Engine)
                        groupName = "Engines";
                    else if (((BaseComponent)listViewItem.Tag).BaseComponentType == BaseComponentType.Apu)
                        groupName = "APU";
                    else if (((BaseComponent)listViewItem.Tag).BaseComponentType == BaseComponentType.LandingGear)
                        groupName = "Landing gears";
                    else if (((BaseComponent)listViewItem.Tag).BaseComponentType == BaseComponentType.Propeller)
                        groupName = "Propellers";
                }
                else if (listViewItem.Tag is Component)
                {
                    Component component = (Component)listViewItem.Tag;
                    if (component.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.ConsumableParts))
                        groupName = "Consumable Parts";
                    else if (component.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.KIT))
                        groupName = "Kits";
                    else
                    {
                        AtaChapter ata = component.ATAChapter;
                        groupName = ata.ShortName + " " + ata.FullName;
                    }
                }
                itemsListView.Groups.Add(groupName, groupName);
                listViewItem.Group = itemsListView.Groups[groupName];
            }
        }
        #endregion

        #region protected override void SetItemColor(ListViewItem listViewItem, BaseSmartCoreObject item)
        protected override void SetItemColor(ListViewItem listViewItem, BaseEntityObject item)
        {
            if (item is ComponentDirective)
            {
                listViewItem.ForeColor = Color.Gray;
				
                ComponentDirective dd = item as ComponentDirective;
                listViewItem.BackColor = dd.ItemRelations.Count > 0 
                    ? Color.FromArgb(Highlight.Grey.Color) 
                    : UsefulMethods.GetColor(item);
            }
            if (item is Component)
            {
                listViewItem.ForeColor = Color.Black;
                listViewItem.BackColor = UsefulMethods.GetColor(item);
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
            SetGroupsToItems();

            List<ListViewItem> resultList = new List<ListViewItem>();

            if (columnIndex <= 6 || columnIndex == 19 || columnIndex == 20)
            {
                ListViewItemList.Sort(new BaseListViewComparer(columnIndex, SortMultiplier));
                //добавление остальных подзадач
                foreach (ListViewItem item in ListViewItemList)
                {
                    if (item.Tag is Component)
                    {
                        resultList.Add(item);

                        Component component = (Component)item.Tag;
                        IEnumerable<ListViewItem> items =
                            ListViewItemList
                            .Where(lvi => lvi.Tag is ComponentDirective && ((ComponentDirective)lvi.Tag).ComponentId == component.ItemId);
                        foreach (ListViewItem listViewItem in items)
                        {
                            listViewItem.Group = item.Group;
                        }
                        resultList.AddRange(items);
                    }
                }
            }
            else
            {
                //добавление остальных подзадач
                foreach (ListViewItem item in ListViewItemList)
                {
                    if (item.Tag is Component)
                    {
                        resultList.Add(item);

                        Component component = (Component)item.Tag;
                        IEnumerable<ListViewItem> items =
                            ListViewItemList
                            .Where(lvi => lvi.Tag is ComponentDirective && ((ComponentDirective)lvi.Tag).ComponentId == component.ItemId);
                        foreach (ListViewItem listViewItem in items)
                        {
                            listViewItem.Group = item.Group;
                        }
                        resultList.AddRange(items);
                    }
                }
                resultList.Sort(new BaseListViewComparer(columnIndex, SortMultiplier));
            }
            itemsListView.Items.AddRange(resultList.ToArray());
            OldColumnIndex = columnIndex;
        }

        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(BaseSmartCoreObject item)

        protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(BaseEntityObject item)
        {
            ListViewItem.ListViewSubItem[] subItems = new ListViewItem.ListViewSubItem[21];

            DateTime? approx;
            Lifelength remains, next;
            AtaChapter ata;
            MaintenanceControlProcess maintenanceType;
            DateTime transferDate = DateTimeExtend.GetCASMinDateTime();
            Lifelength firstPerformance = Lifelength.Null,
                       lastPerformance = Lifelength.Null,
                       warranty, repeatInterval = Lifelength.Null;
            string partNumber = "",
                   description,
                   serialNumber = "",
                   position = "",
                   lastPerformanceString = "",
                   kitRequieredString,
                   remarks,
                   hiddenRemarks,
                   workType = "";
            double manHours,
                   cost,
                   costServiceable = 0,
                   costOverhaul = 0;
            if (item is Component)
            {
                Component componentItem = (Component)item;
                //if(detailItem is BaseDetail)
                //    GlobalObjects.CasEnvironment.Calculator.GetLifelength((BaseDetail)detailItem, out cond, out remains, out next, out approx);
                //else GlobalObjects.CasEnvironment.Calculator.GetLifelength(detailItem, out cond, out remains, out next, out approx);
                //GlobalObjects.CasEnvironment.Calculator.GetNextPerformance(detailItem);
                approx = componentItem.NextPerformanceDate;
                next = componentItem.NextPerformanceSource;
                remains = componentItem.Remains;
                ata = componentItem.ATAChapter;
                partNumber = componentItem.PartNumber;
                description = componentItem.Description;
                serialNumber = componentItem.SerialNumber;
                position = componentItem.TransferRecords.GetLast().Position.ToUpper();
                maintenanceType = componentItem.MaintenanceControlProcess;
                transferDate = componentItem.TransferRecords.GetLast().TransferDate;
                firstPerformance = componentItem.LifeLimit;
                warranty = componentItem.Warranty;
                kitRequieredString = componentItem.Kits.Count + " kits";
                manHours = componentItem.ManHours;
                cost = componentItem.Cost;
                costOverhaul = componentItem.CostOverhaul;
                costServiceable = componentItem.CostServiceable;
                remarks = componentItem.Remarks;
                hiddenRemarks = componentItem.HiddenRemarks;
            }
            else
            {
                ComponentDirective dd = (ComponentDirective)item;
                if (dd.Threshold.FirstPerformanceSinceNew != null && !dd.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
                {
                    firstPerformance = dd.Threshold.FirstPerformanceSinceNew;
                }
                if (dd.LastPerformance != null)
                {
                    lastPerformanceString =
                        SmartCore.Auxiliary.Convert.GetDateFormat(dd.LastPerformance.RecordDate) + " " +
                        dd.LastPerformance.OnLifelength;
                    lastPerformance = dd.LastPerformance.OnLifelength;
                }
                if (dd.Threshold.RepeatInterval != null && !dd.Threshold.RepeatInterval.IsNullOrZero())
                {
                    repeatInterval = dd.Threshold.RepeatInterval;
                }
                //GlobalObjects.CasEnvironment.Calculator.GetNextPerformance(dd, out next, out remains, out approx, out cond);
                //GlobalObjects.CasEnvironment.Calculator.GetNextPerformance(dd);
                approx = dd.NextPerformanceDate;
                next = dd.NextPerformanceSource;
                remains = dd.Remains;
                ata = dd.ParentComponent.ATAChapter;
                description = "    " + dd.ParentComponent.Description;// +" " + dd.DirectiveType;
                maintenanceType = dd.ParentComponent.MaintenanceControlProcess;
                warranty = dd.Threshold.Warranty;
                kitRequieredString = dd.Kits.Count + " kits";
                manHours = dd.ManHours;
                cost = dd.Cost;
                remarks = dd.Remarks;
                hiddenRemarks = dd.HiddenRemarks;
                workType = dd.DirectiveType.ToString();
            }

            subItems[0] = new ListViewItem.ListViewSubItem { Text = ata.ToString(), Tag = ata };
            subItems[1] = new ListViewItem.ListViewSubItem { Text = partNumber, Tag = partNumber };
            subItems[2] = new ListViewItem.ListViewSubItem { Text = description, Tag = description };
            subItems[3] = new ListViewItem.ListViewSubItem { Text = serialNumber, Tag = serialNumber };
            subItems[4] = new ListViewItem.ListViewSubItem { Text = position, Tag = position };
            subItems[5] = new ListViewItem.ListViewSubItem { Text = maintenanceType.ShortName, Tag = maintenanceType };
            subItems[6] = new ListViewItem.ListViewSubItem
            {
                Text = transferDate > DateTimeExtend.GetCASMinDateTime()
					? SmartCore.Auxiliary.Convert.GetDateFormat(transferDate) : "",
                Tag = transferDate
            };
            subItems[7] = new ListViewItem.ListViewSubItem { Text = workType, Tag = workType };
            subItems[8] = new ListViewItem.ListViewSubItem { Text = firstPerformance.ToString(), Tag = firstPerformance };
            subItems[9] = new ListViewItem.ListViewSubItem { Text = repeatInterval.ToString(), Tag = repeatInterval };
            subItems[10] = new ListViewItem.ListViewSubItem
            {
                Text = approx == null
                    ? ""
                    : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime)approx) + " " + next,
                Tag = approx == null ? DateTimeExtend.GetCASMinDateTime() : (DateTime)approx
            };
            subItems[11] = new ListViewItem.ListViewSubItem
            {
                Text = remains != null && !remains.IsNullOrZero()
                                       ? remains.ToString()
                                       : "",
                Tag = remains ?? Lifelength.Null
            };
            subItems[12] = new ListViewItem.ListViewSubItem { Text = lastPerformanceString, Tag = lastPerformance };
            subItems[13] = new ListViewItem.ListViewSubItem { Text = warranty.ToString(), Tag = warranty };
            subItems[14] = new ListViewItem.ListViewSubItem { Text = kitRequieredString, Tag = kitRequieredString };
            subItems[15] = new ListViewItem.ListViewSubItem { Text = manHours.ToString(), Tag = manHours };
            subItems[16] = new ListViewItem.ListViewSubItem { Text = cost.ToString(), Tag = cost };
            subItems[17] = new ListViewItem.ListViewSubItem { Text = costOverhaul.ToString(), Tag = costOverhaul };
            subItems[18] = new ListViewItem.ListViewSubItem { Text = costServiceable.ToString(), Tag = costServiceable };
            subItems[19] = new ListViewItem.ListViewSubItem { Text = remarks, Tag = remarks };
            subItems[20] = new ListViewItem.ListViewSubItem { Text = hiddenRemarks, Tag = hiddenRemarks };

            return subItems;
        }

        #endregion

        #region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

        protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        #region private void MaintenanceDirectiveBindDetailListViewLoad(object sender, EventArgs e)
        private void MaintenanceDirectiveBindDetailListViewLoad(object sender, EventArgs e)
        {
            SetHeaders();
        }
        #endregion

        #endregion
    }
}
