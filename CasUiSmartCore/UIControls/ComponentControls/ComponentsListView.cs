using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Auxiliary;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.StoresControls;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Accessory;
using SmartCore.Entities.General.Interfaces;
using TempUIExtentions;

namespace CAS.UI.UIControls.ComponentControls
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class ComponentsListView : BaseListViewControl<BaseEntityObject>
    {
        #region Fields

        private readonly BaseComponent _parentBaseComponent;
        #endregion

        #region Constructors

        #region private DetailsListView()
        ///<summary>
        ///</summary>
        private ComponentsListView()
        {
            InitializeComponent();
        }
        #endregion

        #region public DetailsListView(BaseDetail parentBaseDetail) : this()
        ///<summary>
        ///</summary>
        public ComponentsListView(BaseComponent parentBaseComponent)
            : this()
        {
            OldColumnIndex = 0;
            _parentBaseComponent = parentBaseComponent;
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
            itemsListView.Columns.Clear();
            ColumnHeaderList.Clear();

            ColumnHeader columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "ATA" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Part. No" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.3f), Text = "Description" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.07f), Text = "Work Type" };
            ColumnHeaderList.Add(columnHeader);
			//3
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Serial No" };
            ColumnHeaderList.Add(columnHeader);
			//4
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "MPD Item" };
			ColumnHeaderList.Add(columnHeader);
			//5
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Pos. No" };
            ColumnHeaderList.Add(columnHeader);
            //6
            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.07f), Text = "M.P." };
            ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.07f), Text = "Zone-Area" };
	        ColumnHeaderList.Add(columnHeader);
	        columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.07f), Text = "Access" };
	        ColumnHeaderList.Add(columnHeader);

			//7
			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Inst. date" };
            ColumnHeaderList.Add(columnHeader);
            //8

            //9
            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Life limit/1st. Perf" };
            ColumnHeaderList.Add(columnHeader);
            //10
            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Rpt. int." };
            ColumnHeaderList.Add(columnHeader);

            //11
            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Next" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Remain/Overdue" };
            ColumnHeaderList.Add(columnHeader);
            //12
            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Last" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Warranty" };
            ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Class" };
			ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Kit" };
            ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "NDT" };
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
            //20
            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Hidden Remarks" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Signer" };
            ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
		#endregion

		#region protected override SetGroupsToItems(int columnIndex)
		protected override void SetGroupsToItems(int columnIndex)
        {
			//TODO:(Evgenii Babak) перенести в ListViewHelper
            itemsListView.Groups.Clear();
            foreach (ListViewItem listViewItem in ListViewItemList.OrderBy(x => x.Text))
            {
				var parent = (IDirective)listViewItem.Tag;

				if (parent is ComponentDirective)
					parent = ((ComponentDirective)parent).ParentComponent;

				string groupName = "";
                if (parent is BaseComponent)
                {
                    if (((BaseComponent)parent).BaseComponentType == BaseComponentType.Engine)
                        groupName = "Engines";
                    else if (((BaseComponent)parent).BaseComponentType == BaseComponentType.Apu)
                        groupName = "APU";
                    else if (((BaseComponent)parent).BaseComponentType == BaseComponentType.LandingGear)
                        groupName = "Landing gears";
                    else if (((BaseComponent)parent).BaseComponentType == BaseComponentType.Propeller)
                        groupName = "Propellers";
					else if (((BaseComponent)parent).BaseComponentType == BaseComponentType.Frame)
						groupName = "Frames";
				}
                else if (parent is Component) 
                {
                    Component component = (Component)parent;
                    if (_parentBaseComponent != null &&
                       _parentBaseComponent.BaseComponentType == BaseComponentType.Engine) groupName = component.LLPMark ? "LLP Disk" : "Component";
                    else
                    {
                        var ata = component.Model != null ? component.Model.ATAChapter : component.ATAChapter;
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
                listViewItem.BackColor = UsefulMethods.GetColor(item);
            }
            if (item is Component)
            {
                listViewItem.ForeColor = Color.Black;
                listViewItem.BackColor = UsefulMethods.GetColor(item);
            }
        }
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(BaseSmartCoreObject item)

        protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(BaseEntityObject item)
        {
			var subItems = new List<ListViewItem.ListViewSubItem>();
			var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);

			DateTime? approx;
            Lifelength remains, next;
            AtaChapter ata;
            MaintenanceControlProcess maintenanceType;
            DateTime transferDate;
            Lifelength firstPerformance = Lifelength.Null, 
                       lastPerformance = Lifelength.Null,
                       warranty, repeatInterval = Lifelength.Null;
            string partNumber,
                   description,
                   serialNumber,
                   position,
				   mpdString= "",
                   lastPerformanceString = "",
				   classString ="",
                   kitRequieredString,
                   remarks,
                   hiddenRemarks,
                   workType = "",
                   zone = "",
                   access = "",
				   ndtString = "";
            double manHours,
                   cost,
                   costServiceable = 0,
                   costOverhaul = 0;
            if (item is Component)
            {
                Component componentItem = (Component)item;
                approx = componentItem.NextPerformanceDate;
                next = componentItem.NextPerformanceSource;
                remains = componentItem.LLPCategories ? componentItem.LLPRemains:componentItem.Remains;
	            ata = componentItem.Model != null ? componentItem.Model.ATAChapter : componentItem.ATAChapter;
                partNumber = componentItem.PartNumber;
                description = componentItem.Model != null ? componentItem.Model.Description : componentItem.Description;
                serialNumber = componentItem.SerialNumber;
                position = componentItem.TransferRecords.GetLast().Position.ToUpper();
                maintenanceType = componentItem.MaintenanceControlProcess;
                transferDate = componentItem.TransferRecords.GetLast().TransferDate;
                firstPerformance = componentItem.LifeLimit;
                warranty = componentItem.Warranty;
	            classString = componentItem.GoodsClass != null ? componentItem.GoodsClass.ToString() : "";
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
                ata = dd.ParentComponent.Model != null ? dd.ParentComponent.Model.ATAChapter : dd.ParentComponent.ATAChapter;
                partNumber = "    " + dd.PartNumber;
	            var desc = dd.ParentComponent.Model != null
		            ? dd.ParentComponent.Model.Description
		            : dd.ParentComponent.Description;

				description = "    " + desc;
                serialNumber = "    " + dd.SerialNumber;
                position = "    " + dd.ParentComponent.TransferRecords.GetLast().Position.ToUpper();
                transferDate = dd.ParentComponent.TransferRecords.GetLast().TransferDate;
                maintenanceType = dd.ParentComponent.MaintenanceControlProcess;
                warranty = dd.Threshold.Warranty;
				classString = dd.ParentComponent.GoodsClass != null ? dd.ParentComponent.GoodsClass.ToString() : "";
				kitRequieredString = dd.Kits.Count + " kits";
                manHours = dd.ManHours;
                cost = dd.Cost;
	            zone = dd.ZoneArea;
	            access = dd.AccessDirective;
                remarks = dd.Remarks;
                hiddenRemarks = dd.HiddenRemarks;
                workType = dd.DirectiveType.ToString();
	            ndtString = dd.NDTType.ShortName;
				if (dd.MaintenanceDirective!=null)
					mpdString = dd.MaintenanceDirective.TaskNumberCheck;
			}

			subItems.Add(new ListViewItem.ListViewSubItem { Text = ata.ToString(), Tag = ata });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = partNumber, Tag = partNumber});
			subItems.Add(new ListViewItem.ListViewSubItem { Text = description, Tag = description });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = workType, Tag = workType });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = serialNumber, Tag = serialNumber });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = mpdString, Tag = mpdString });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = position, Tag = position });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = maintenanceType.ShortName, Tag = maintenanceType });
	        subItems.Add(new ListViewItem.ListViewSubItem { Text = zone, Tag = zone });
	        subItems.Add(new ListViewItem.ListViewSubItem { Text = access, Tag = access });

			subItems.Add(new ListViewItem.ListViewSubItem 
            { 
                Text = transferDate > DateTimeExtend.GetCASMinDateTime()
					? SmartCore.Auxiliary.Convert.GetDateFormat(transferDate) : "",
                Tag = transferDate 
            });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = firstPerformance?.ToString(), Tag = firstPerformance });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = repeatInterval.ToString(), Tag = repeatInterval });
			subItems.Add(new ListViewItem.ListViewSubItem
            {
                Text = approx == null
                    ? ""
                    : SmartCore.Auxiliary.Convert.GetDateFormat((DateTime) approx) + " " + next,
                Tag = approx == null ? DateTimeExtend.GetCASMinDateTime() : (DateTime) approx
            });
			subItems.Add(new ListViewItem.ListViewSubItem 
            { 
                Text = remains != null && !remains.IsNullOrZero()
                                       ? remains.ToString()
                                       : "",
                Tag = remains ?? Lifelength.Null
            });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = lastPerformanceString, Tag = lastPerformance });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = warranty.ToString(), Tag = warranty });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = classString, Tag = classString });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = kitRequieredString, Tag = kitRequieredString });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = ndtString, Tag = ndtString });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = manHours.ToString(), Tag = manHours });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = cost.ToString(), Tag = cost });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = costOverhaul.ToString(), Tag = costOverhaul });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = costServiceable.ToString(), Tag = costServiceable });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = remarks, Tag = remarks });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = hiddenRemarks, Tag = hiddenRemarks });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = author, Tag = author });

			return subItems.ToArray();
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

            List<ListViewItem> resultList = new List<ListViewItem>();

            if (columnIndex <= 6 || columnIndex == 19 || columnIndex == 20)
            {
                SetGroupsToItems(columnIndex);
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
                            .Where(lvi =>lvi.Tag is ComponentDirective && ((ComponentDirective) lvi.Tag).ComponentId == component.ItemId);
                        foreach (ListViewItem listViewItem in items)
                        {
                            listViewItem.Group = item.Group;
                        }
                        resultList.AddRange(items);
                    }
                    else if(item.Tag is ComponentDirective)
                    {
                        ComponentDirective dd = item.Tag as ComponentDirective;
                        Component d = dd.ParentComponent;
                        if(d == null)
                            resultList.Add(item);
                        else
                        {
                            ListViewItem lvi =
                                ListViewItemList.FirstOrDefault(lv => lv.Tag is Component && ((Component) lv.Tag).ItemId == d.ItemId);
                            if(lvi == null)
                                resultList.Add(item);
                        }
                    }
				}
            }
            else if (columnIndex == 10)
            {
                foreach (ListViewItem item in ListViewItemList)
                {
                    if (item.Tag is Component)
                    {
                        resultList.Add(item);

                        Component component = (Component)item.Tag;
                        IEnumerable<ListViewItem> items =
                            ListViewItemList
                            .Where(lvi => lvi.Tag is ComponentDirective && ((ComponentDirective)lvi.Tag).ComponentId == component.ItemId);
                        resultList.AddRange(items);
                    }
                    else if (item.Tag is ComponentDirective)
                    {
                        ComponentDirective dd = item.Tag as ComponentDirective;
                        Component d = dd.ParentComponent;
                        if (d == null)
                            resultList.Add(item);
                        else
                        {
                            ListViewItem lvi =
                                ListViewItemList.FirstOrDefault(lv => lv.Tag is Component && ((Component)lv.Tag).ItemId == d.ItemId);
                            if (lvi == null)
                                resultList.Add(item);
                        }
                    }
                }

                resultList.Sort(new BaseListViewComparer(columnIndex, SortMultiplier));

                itemsListView.Groups.Clear();
                foreach (var item in resultList)
                {
					var temp = ListViewGroupHelper.GetGroupStringByPerformanceDate(item.Tag);
					itemsListView.Groups.Add(temp, temp);
                    item.Group = itemsListView.Groups[temp];
                }
            }
            else
            {
                SetGroupsToItems(columnIndex);
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
                    else if (item.Tag is ComponentDirective)
                    {
                        ComponentDirective dd = item.Tag as ComponentDirective;
                        Component d = dd.ParentComponent;
                        if (d == null)
                            resultList.Add(item);
                        else
                        {
                            ListViewItem lvi =
                                ListViewItemList.FirstOrDefault(lv => lv.Tag is Component && ((Component)lv.Tag).ItemId == d.ItemId);
                            if (lvi == null)
                                resultList.Add(item);
                        }
                    }
                }
                resultList.Sort(new BaseListViewComparer(columnIndex, SortMultiplier));
            }
            itemsListView.Items.AddRange(resultList.Distinct().ToArray());
			OldColumnIndex = columnIndex;
        }

        #endregion

        #region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

        protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
            if (SelectedItem != null)
            {
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                if (SelectedItem is Component)
                {
                    Component d = (Component) SelectedItem;
                    if (d.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.MaintenanceMaterials) ||
                        d.GoodsClass.IsNodeOrSubNodeOf(GoodsClass.Tools))
                    {
                        e.Cancel = true;
                        ConsumablePartAndKitForm form = new ConsumablePartAndKitForm(d);
                        form.ShowDialog();
                    }
                    else
                    {
                        var location = d.ParentAircraftId > 0
                            ? $"{d.GetParentAircraftRegNumber()}."
							: d.ParentOperator != null ? $"{d.ParentOperator.Name}." : ""; //TODO:(Evgenii Babak) заменить на использование OperatorCore 
						e.DisplayerText = location + " Component PN " + d.PartNumber;
                        e.RequestedEntity = new ComponentScreenNew(d);
                    }
                }
                else
                {
                    var d = ((ComponentDirective)SelectedItem).ParentComponent;
					var location = d.ParentAircraftId > 0
                            ? $"{d.GetParentAircraftRegNumber()}."
							: d.ParentOperator != null ? $"{d.ParentOperator.Name}." : "";//TODO:(Evgenii Babak) заменить на использование OperatorCore 
					e.DisplayerText = location + " Component PN " + d.PartNumber;
                    e.RequestedEntity = new ComponentScreenNew(d);
                } 
            }
        }
        #endregion

        #endregion
    }
}
