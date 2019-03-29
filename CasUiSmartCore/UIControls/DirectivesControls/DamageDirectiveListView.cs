using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary.Comparers;
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
    public partial class DamageDirectiveListView : PrimeDirectiveListView
    {
        #region Constructors

        #region public DamageDirectiveListView()
        ///<summary>
        ///</summary>
        public DamageDirectiveListView()
        {
            CurrentPrimatyDirectiveType = DirectiveType.DamagesRequiring;
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
                new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Damage" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "SB No" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "EO No" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Description" };
            ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.12f), Text = "Corrective Action" };
	        ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.05f), Text = "Number" };
            ColumnHeaderList.Add(columnHeader);

	        columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.05f), Text = "Class" };
	        ColumnHeaderList.Add(columnHeader);

			columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.05f), Text = "Type" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Location" };
            ColumnHeaderList.Add(columnHeader);

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.1f), Text = "Size" };
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

            columnHeader = new ColumnHeader { Width = (int)(itemsListView.Width * 0.08f), Text = "Is Temporary" };
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
            var subItems = new List<ListViewItem.ListViewSubItem>();

            //////////////////////////////////////////////////////////////////////////////////////
            //         Определение последнего выполнения директивы и KitRequiered               //
            //////////////////////////////////////////////////////////////////////////////////////
            var lastComplianceDate = DateTimeExtend.GetCASMinDateTime();
            var nextComplianceDate = DateTimeExtend.GetCASMinDateTime();
            var lastComplianceLifeLength = Lifelength.Zero;
            var nextComplianceRemain = Lifelength.Null;

            string lastPerformanceString, firstPerformanceString = "N/A";

            DirectiveStatus status = item.Status;
            //Последнее выполнение
            if (item.LastPerformance != null &&
                item.LastPerformance.RecordDate > lastComplianceDate)
            {
                lastComplianceDate = item.LastPerformance.RecordDate;
                lastComplianceLifeLength = item.LastPerformance.OnLifelength;
            }
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
            var remarksString = item.Remarks;
            var hiddenRemarksString = item.HiddenRemarks;

            if (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
                lastPerformanceString = "N/A";
            else
                lastPerformanceString = SmartCore.Auxiliary.Convert.GetDateFormat(lastComplianceDate) + " " +
                                        lastComplianceLifeLength;

            string nextComplianceString = ((nextComplianceDate <= DateTimeExtend.GetCASMinDateTime())
                                               ? ""
                                               : SmartCore.Auxiliary.Convert.GetDateFormat(nextComplianceDate)) + " " +
                                          nextComplianceLifeLength;
            string nextRemainString = nextComplianceRemain != null && !nextComplianceRemain.IsNullOrZero()
                                          ? nextComplianceRemain.ToString()
                                          : "N/A";
            var titleString = item.Title != "" ? item.Title : "N/A";
            var sbString = item.ServiceBulletinNo != "" ? item.ServiceBulletinNo : "N/A";
            var eoString = item.EngineeringOrders != "" ? item.EngineeringOrders : "N/A";
            var descriptionString = item.Description;
            var applicabilityString = item.Applicability;
            var numberString = item is DamageItem ? ((DamageItem) item).Number : "";
            var typeString = item is DamageItem ? ((DamageItem)item).DamageType.ToString() : "";
            var classString = item is DamageItem ? ((DamageItem)item).DamageClass.ToString() : "";
            var locationString = item is DamageItem ? ((DamageItem)item).Location : "";
            var sizeString = item is DamageItem ? ((DamageItem)item).Size : "";
            var corrective = item is DamageItem ? ((DamageItem)item).CorrectiveAction : "";
            var temporaryString = item is DamageItem ? (((DamageItem)item).IsTemporary ? "Yes" : "No") : "";
            var ata = item.ATAChapter;

            subItems.Add(new ListViewItem.ListViewSubItem { Text = titleString, Tag = titleString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = sbString, Tag = sbString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = eoString, Tag = eoString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = descriptionString, Tag = descriptionString });
	        subItems.Add(new ListViewItem.ListViewSubItem { Text = corrective, Tag = corrective });
			subItems.Add(new ListViewItem.ListViewSubItem { Text = numberString, Tag = numberString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = classString, Tag = classString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = typeString, Tag = typeString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = locationString, Tag = locationString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = sizeString, Tag = sizeString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = applicabilityString, Tag = applicabilityString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = workType.ToString(), Tag = workType });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = status.ToString(), Tag = status });
            subItems.Add(new ListViewItem.ListViewSubItem
            {
                Text = effDate > DateTimeExtend.GetCASMinDateTime()
					? SmartCore.Auxiliary.Convert.GetDateFormat(effDate) : "",
                Tag = effDate
            });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = firstPerformanceString, Tag = firstPerformanceString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = repeatInterval.ToString(), Tag = repeatInterval });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = nextComplianceString, Tag = nextComplianceDate });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = nextRemainString, Tag = nextRemainString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = lastPerformanceString, Tag = lastComplianceDate });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = ata.ToString(), Tag = ata });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = temporaryString, Tag = temporaryString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = kitRequieredString, Tag = kitRequieredString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = ndtString, Tag = ndtString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = manHours == -1 ? "" : manHours.ToString(), Tag = manHours });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = cost == -1 ? "" : cost.ToString(), Tag = cost });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = remarksString, Tag = remarksString });
            subItems.Add(new ListViewItem.ListViewSubItem { Text = hiddenRemarksString, Tag = hiddenRemarksString });

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

            if (columnIndex <= 4 || columnIndex == 7 || columnIndex >= 18)
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
            if (SelectedItem != null)
            {
                string regNumber = "";

                if (SelectedItem.ParentBaseComponent.BaseComponentType.ItemId == 4)
                    regNumber = SelectedItem.ParentBaseComponent.ToString();
                else
                {
                    if (SelectedItem.ParentBaseComponent.ParentAircraftId > 0)
                        regNumber = SelectedItem.ParentBaseComponent.GetParentAircraftRegNumber() + ". " +
                                    SelectedItem.ParentBaseComponent;
                }
                e.DisplayerText = regNumber + ". Damage. " + SelectedItem.Title;
                DamageDirectiveScreen damageScreen = new DamageDirectiveScreen((DamageItem)SelectedItem);
                e.TypeOfReflection = ReflectionTypes.DisplayInNew;
                e.RequestedEntity = damageScreen;
            }
        }
        #endregion

        #endregion
    }
}
