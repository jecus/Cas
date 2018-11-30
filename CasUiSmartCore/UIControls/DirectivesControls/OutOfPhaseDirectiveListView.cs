using System;
using System.Collections.Generic;
using System.Drawing;
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
    public partial class OutOfPhaseDirectiveListView : PrimeDirectiveListView
    {
        #region Constructors

        #region public OutOfPhaseDirectiveListView()
        ///<summary>
        ///</summary>
        public OutOfPhaseDirectiveListView()
        {
            CurrentPrimatyDirectiveType = DirectiveType.OutOfPhase;
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
                new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Title" };
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

            itemsListView.Columns.AddRange(ColumnHeaderList.ToArray());
        }
		#endregion

		#region protected override SetGroupsToItems(int columnIndex)
		protected override void SetGroupsToItems(int columnIndex)
        {
            //группировать данные эдементы не нужно
            itemsListView.Groups.Clear();
        }
        #endregion

        #region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Directive item)

        protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Directive item)
        {
            var subItems = new ListViewItem.ListViewSubItem[20];

			var sbColor = itemsListView.ForeColor;
			var eoColor = itemsListView.ForeColor;

			//////////////////////////////////////////////////////////////////////////////////////
			//         Определение последнего выполнения директивы и KitRequiered               //
			//////////////////////////////////////////////////////////////////////////////////////
			var lastComplianceDate = DateTimeExtend.GetCASMinDateTime();
            var nextComplianceDate = DateTimeExtend.GetCASMinDateTime();
            var lastComplianceLifeLength = Lifelength.Zero;
            var nextComplianceRemain = Lifelength.Null;

            string lastPerformanceString, firstPerformanceString = "N/A";

            var status = item.Status;
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
            //GlobalObjects.CasEnvironment.Calculator.GetNextPerformance(item);
            var nextComplianceLifeLength = item.NextPerformanceSource;
            if (item.NextPerformanceDate != null)
                nextComplianceDate = (DateTime)item.NextPerformanceDate;
            if (item.Remains != null)
                nextComplianceRemain = item.Remains;
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

            var remarksString = item.Remarks;
            var hiddenRemarksString = item.HiddenRemarks;

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
            var titleString = item.Title != "" ? item.Title + par : "N/A";
            var sbString = item.ServiceBulletinNo != "" ? item.ServiceBulletinNo : "N/A";
            var eoString = item.EngineeringOrders != "" ? item.EngineeringOrders : "N/A";
            var descriptionString = item.Description;
            var applicabilityString = item.Applicability;
            var ata = item.ATAChapter;

			if (item.ServiceBulletinFile == null)
				sbColor = Color.MediumVioletRed;
			if (item.EngineeringOrderFile == null)
				eoColor = Color.MediumVioletRed;

			subItems[0] = new ListViewItem.ListViewSubItem { Text = titleString, Tag = titleString };
            subItems[1] = new ListViewItem.ListViewSubItem { ForeColor = sbColor, Text = sbString, Tag = sbString };
            subItems[2] = new ListViewItem.ListViewSubItem { ForeColor = eoColor, Text = eoString, Tag = eoString };
            subItems[3] = new ListViewItem.ListViewSubItem { Text = descriptionString, Tag = descriptionString };
            subItems[4] = new ListViewItem.ListViewSubItem { Text = applicabilityString, Tag = applicabilityString };
            subItems[5] = new ListViewItem.ListViewSubItem { Text = workType.ToString(), Tag = workType };
            subItems[6] = new ListViewItem.ListViewSubItem { Text = status.ToString(), Tag = status };
            subItems[7] = new ListViewItem.ListViewSubItem
            {
                Text = effDate > DateTimeExtend.GetCASMinDateTime()
					? SmartCore.Auxiliary.Convert.GetDateFormat(effDate) : "",
                Tag = effDate
            };
            subItems[8] = new ListViewItem.ListViewSubItem { Text = firstPerformanceString, Tag = firstPerformanceString };
            subItems[9] = new ListViewItem.ListViewSubItem { Text = repeatInterval.ToString(), Tag = repeatInterval };
            subItems[10] = new ListViewItem.ListViewSubItem { Text = nextComplianceString, Tag = nextComplianceDate };
            subItems[11] = new ListViewItem.ListViewSubItem { Text = nextRemainString, Tag = nextRemainString };
            subItems[12] = new ListViewItem.ListViewSubItem { Text = lastPerformanceString, Tag = lastComplianceDate };
            subItems[13] = new ListViewItem.ListViewSubItem { Text = ata.ToString(), Tag = ata };
            subItems[14] = new ListViewItem.ListViewSubItem { Text = kitRequieredString, Tag = kitRequieredString };
            subItems[15] = new ListViewItem.ListViewSubItem { Text = ndtString, Tag = ndtString };
            subItems[16] = new ListViewItem.ListViewSubItem { Text = manHours == -1 ? "" : manHours.ToString(), Tag = manHours };
            subItems[17] = new ListViewItem.ListViewSubItem { Text = cost == -1 ? "" : cost.ToString(), Tag = cost };
            subItems[18] = new ListViewItem.ListViewSubItem { Text = remarksString, Tag = remarksString };
            subItems[19] = new ListViewItem.ListViewSubItem { Text = hiddenRemarksString, Tag = hiddenRemarksString };
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

            if (columnIndex <= 4 || columnIndex == 6 || columnIndex >= 16)
            {
                SetGroupsToItems(columnIndex);
                ListViewItemList.Sort(new CPCPDirectiveListViewComparer(columnIndex, SortMultiplier));
                //добавление остальных подзадач
                foreach (ListViewItem item in ListViewItemList)
                {
                    resultList.Add(item);
                }
            }
            else if (columnIndex == 10)
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
            if (SelectedItem == null) 
                return;
            
            string regNumber = "";
            if (SelectedItem.ParentBaseComponent.BaseComponentType.ItemId == 4)
                regNumber = SelectedItem.ParentBaseComponent.ToString();
            else
            {
                if (SelectedItem.ParentBaseComponent.ParentAircraftId > 0)
                    regNumber = SelectedItem.ParentBaseComponent.GetParentAircraftRegNumber() + ". " + 
								SelectedItem.ParentBaseComponent;
            }
            e.DisplayerText = regNumber + ". Out of phase. " + SelectedItem.Title;
            OutOfPhaseReferenceScreen directiveScreen = new OutOfPhaseReferenceScreen(SelectedItem);
            e.TypeOfReflection = ReflectionTypes.DisplayInNew;
            e.RequestedEntity = directiveScreen;
        }
        #endregion

        #endregion
    }
}
