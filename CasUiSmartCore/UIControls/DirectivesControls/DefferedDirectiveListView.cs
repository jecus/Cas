using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Directives;
using TempUIExtentions;

namespace CAS.UI.UIControls.DirectivesControls
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class DefferedDirectiveListView : PrimeDirectiveListView
    {
        #region Constructors

        #region public DefferedDirectiveListView()
        ///<summary>
        ///</summary>
        public DefferedDirectiveListView()
        {
            CurrentPrimatyDirectiveType = DirectiveType.DeferredItems;
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
           
            ColumnHeader columnHeader =
                new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Deffered:" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "SB No" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "EO No" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Description" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Applicabilty" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Work Type" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.05f), Text = "Category" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Status" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Effective date" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "1st. Perf." };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Rpt. Intv." };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Next" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Remain/Overdue" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.05f), Text = "Last" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.05f), Text = "ATA Chapter" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.05f), Text = "Kit" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.05f), Text = "NDT" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "M.H." };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Cost" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Remarks" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Hidden remarks" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Signer" };
            ColumnHeaderList.Add(columnHeader);

			itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
		#endregion

		#region protected override SetGroupsToItems(int columnIndex)
		protected override void SetGroupsToItems(int columnIndex)
        {
			//TODO:(Evgenii Babak) вынести в ListViewGroupHelper 
            itemsListView.Groups.Clear();
            foreach (ListViewItem t in ListViewItemList)
            {
                string groupName;
                if (t.Tag is DeferredItem)
                {
                    groupName = ((DeferredItem)t.Tag).DeferredCategory.ToString();
                }
                else continue;

                itemsListView.Groups.Add(groupName, groupName);
                t.Group = itemsListView.Groups[groupName];
            }
        }
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Directive item)

        protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Directive item)
        {
            var subItems = new ListViewItem.ListViewSubItem[22];
            var author = GlobalObjects.CasEnvironment.GetCorrector(item.CorrectorId);
			//////////////////////////////////////////////////////////////////////////////////////
			//         Определение последнего выполнения директивы и KitRequiered               //
			//////////////////////////////////////////////////////////////////////////////////////
			var lastComplianceDate = DateTimeExtend.GetCASMinDateTime();
            var nextComplianceDate = DateTimeExtend.GetCASMinDateTime();
            var lastComplianceLifeLength = Lifelength.Zero;
            var nextComplianceRemain = Lifelength.Null;

            string lastPerformanceString, firstPerformanceString = "N/A";

            DeferredItem pd = (DeferredItem)item;
            DirectiveStatus status = pd.Status;
            DeferredCategory cat = pd.DeferredCategory;
            //////////////////////////////////////////////////////////////////////////////////////
            //         Определение последнего выполнения директивы и KitRequiered               //
            //////////////////////////////////////////////////////////////////////////////////////

            var par = "  §: " + item.Paragraph;
            //Последнее выполнение
            if (item.LastPerformance != null &&
                item.LastPerformance.RecordDate > lastComplianceDate)
            {
                lastComplianceDate = item.LastPerformance.RecordDate;
				lastComplianceLifeLength = item.LastPerformance.OnLifelength;
			}

            //Следующее выполнение
            //GlobalObjects.CasEnvironment.Calculator.GetNextPerformance(pd.DirectiveCollection[0]);
            var nextComplianceLifeLength = item.NextPerformanceSource;
            if (item.NextPerformanceDate != null) nextComplianceDate = (DateTime)item.NextPerformanceDate;
            if (item.Remains != null) nextComplianceRemain = item.Remains;
            if (item.Threshold.FirstPerformanceSinceNew != null && !item.Threshold.FirstPerformanceSinceNew.IsNullOrZero())
            {
                firstPerformanceString = "s/n: " + item.Threshold.FirstPerformanceSinceNew;
            }
            if (item.Threshold.FirstPerformanceSinceEffectiveDate != null &&
                !item.Threshold.FirstPerformanceSinceEffectiveDate.IsNullOrZero())
            {
                if (firstPerformanceString != "N/A") firstPerformanceString += " or ";
                else firstPerformanceString = "";
                firstPerformanceString += "s/e.d: " + item.Threshold.FirstPerformanceSinceEffectiveDate;
            }
            var repeatInterval = item.Threshold.RepeatInterval;
            var kitRequieredString = item.Kits.Count + " kits";
            var ndtString = item.NDTType.ShortName;
            var workType = item.WorkType;
            var effDate = item.Threshold.EffectiveDate;
            var manHours = item.ManHours;
            var cost = item.Cost;

            var remarksString = pd.Remarks;
            var hiddenRemarksString = pd.HiddenRemarks;

            if (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
                lastPerformanceString = "N/A";
            else
                lastPerformanceString = SmartCore.Auxiliary.Convert.GetDateFormat(lastComplianceDate) + " " +
                                        lastComplianceLifeLength;

            var nextComplianceString = ((nextComplianceDate <= DateTimeExtend.GetCASMinDateTime())
                                               ? ""
                                               : SmartCore.Auxiliary.Convert.GetDateFormat(nextComplianceDate)) + " " +
                                          nextComplianceLifeLength;
            var nextRemainString = nextComplianceRemain != null && !nextComplianceRemain.IsNullOrZero()
                                          ? nextComplianceRemain.ToString()
                                          : "N/A";
            var titleString = pd.Title != "" ? pd.Title + par : "N/A";
            var sbString = pd.ServiceBulletinNo != "" ? pd.ServiceBulletinNo : "N/A";
            var eoString = pd.EngineeringOrders != "" ? pd.EngineeringOrders : "N/A";
            var descriptionString = pd.Description;
            var applicabilityString = pd.Applicability;
            var ata = pd.ATAChapter;

            subItems[0] = new ListViewItem.ListViewSubItem { Text = titleString, Tag = titleString };
            subItems[1] = new ListViewItem.ListViewSubItem { Text = sbString, Tag = sbString };
            subItems[2] = new ListViewItem.ListViewSubItem { Text = eoString, Tag = eoString };
            subItems[3] = new ListViewItem.ListViewSubItem { Text = descriptionString, Tag = descriptionString };
            subItems[4] = new ListViewItem.ListViewSubItem { Text = applicabilityString, Tag = applicabilityString };
            subItems[5] = new ListViewItem.ListViewSubItem { Text = workType.ToString(), Tag = workType };
            subItems[6] = new ListViewItem.ListViewSubItem { Text = cat.ToString(), Tag = cat };
            subItems[7] = new ListViewItem.ListViewSubItem { Text = status.ToString(), Tag = status };
            subItems[8] = new ListViewItem.ListViewSubItem
            {
                Text = effDate > DateTimeExtend.GetCASMinDateTime()
					? SmartCore.Auxiliary.Convert.GetDateFormat(effDate) : "",
                Tag = effDate
            };
            subItems[9] = new ListViewItem.ListViewSubItem { Text = firstPerformanceString, Tag = firstPerformanceString };
            subItems[10] = new ListViewItem.ListViewSubItem { Text = repeatInterval.ToString(), Tag = repeatInterval };
            subItems[11] = new ListViewItem.ListViewSubItem { Text = nextComplianceString, Tag = nextComplianceDate };
            subItems[12] = new ListViewItem.ListViewSubItem { Text = nextRemainString, Tag = nextRemainString };
            subItems[13] = new ListViewItem.ListViewSubItem { Text = lastPerformanceString, Tag = lastComplianceDate };
            subItems[14] = new ListViewItem.ListViewSubItem { Text = ata.ToString(), Tag = ata };
            subItems[15] = new ListViewItem.ListViewSubItem { Text = kitRequieredString, Tag = kitRequieredString };
            subItems[16] = new ListViewItem.ListViewSubItem { Text = ndtString, Tag = ndtString };
            subItems[17] = new ListViewItem.ListViewSubItem { Text = manHours == -1 ? "" : manHours.ToString(), Tag = manHours };
            subItems[18] = new ListViewItem.ListViewSubItem { Text = cost == -1 ? "" : cost.ToString(), Tag = cost };
            subItems[19] = new ListViewItem.ListViewSubItem { Text = remarksString, Tag = remarksString };
            subItems[20] = new ListViewItem.ListViewSubItem { Text = hiddenRemarksString, Tag = hiddenRemarksString };
            subItems[21] = new ListViewItem.ListViewSubItem { Text = author, Tag = author };

			return subItems;
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

            if (columnIndex <= 4 || (columnIndex >= 5 && columnIndex <= 8) || columnIndex >= 19)
            {
                SetGroupsToItems(columnIndex);

                ListViewItemList.Sort(new CPCPDirectiveListViewComparer(columnIndex, SortMultiplier));
                //добавление остальных подзадач
                foreach (ListViewItem item in ListViewItemList)
                {
                    resultList.Add(item);
                }
            }
            else if (columnIndex == 11)
            {
                foreach (ListViewItem item in ListViewItemList)
                {
                    resultList.Add(item);
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
                    resultList.Add(item);
                }
                resultList.Sort(new CPCPDirectiveListViewComparer(columnIndex, SortMultiplier));
            }
            itemsListView.Items.AddRange(resultList.ToArray());
            OldColumnIndex = columnIndex;
        }

        #endregion

        #region protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)

        protected override void FillDisplayerRequestedParams(ReferenceEventArgs e)
        {
            if (SelectedItem != null)
            {
                string regNumber = "";

                if (SelectedItem.ParentBaseComponent.BaseComponentType.ItemId == 4)
                    regNumber = SelectedItem.ParentBaseComponent.ToString();
                else
                {
                    if (SelectedItem.ParentBaseComponent.ParentAircraftId > 0)
                        regNumber = $"{SelectedItem.ParentBaseComponent.GetParentAircraftRegNumber()}. {SelectedItem.ParentBaseComponent}";
                }
                e.DisplayerText = regNumber + ". Deffered. " + SelectedItem.Title;
                DeferredScreen damageScreen = new DeferredScreen((DeferredItem)SelectedItem);
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.RequestedEntity = damageScreen;
            }
        }
        #endregion

        #endregion
    }
}
