using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CAS.UI.Helpers;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.Auxiliary.Comparers;
using CAS.UI.UIControls.DirectivesControls;
using CAS.UI.UIControls.NewGrid;
using CASTerms;
using SmartCore.Auxiliary;
using SmartCore.Calculations;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Directives;
using TempUIExtentions;

namespace CAS.UI.UIControls.Reliability
{
    ///<summary>
    /// список для отображения ордеров запроса
    ///</summary>
    public partial class DefferedListView : PrimeDirectiveListView
    {
        #region Constructors

        #region public DefferedDirectiveListView()
        ///<summary>
        ///</summary>
        public DefferedListView()
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
			AddColumn("Aircraft", (int)(radGridView1.Width * 0.24f));
			AddColumn("Deffered", (int)(radGridView1.Width * 0.24f));
			AddColumn("SB No", (int)(radGridView1.Width * 0.24f));
			AddColumn("EO No", (int)(radGridView1.Width * 0.24f));
			AddColumn("Description", (int)(radGridView1.Width * 0.24f));
			AddColumn("Applicabilty", (int)(radGridView1.Width * 0.24f));
			AddColumn("Work Type", (int)(radGridView1.Width * 0.16f));
			AddColumn("Category", (int)(radGridView1.Width * 0.10f));
			AddColumn("Status", (int)(radGridView1.Width * 0.24f));
			AddColumn("Effective date", (int)(radGridView1.Width * 0.24f));
			AddColumn("1st. Perf.", (int)(radGridView1.Width * 0.24f));
			AddColumn("Rpt. Intv.", (int)(radGridView1.Width * 0.24f));
			AddColumn("Next", (int)(radGridView1.Width * 0.24f));
			AddColumn("Remain/Overdue", (int)(radGridView1.Width * 0.24f));
			AddColumn("Last", (int)(radGridView1.Width * 0.10f));
			AddColumn("ATA Chapter", (int)(radGridView1.Width * 0.10f));
			AddColumn("Kit", (int)(radGridView1.Width * 0.10f));
			AddColumn("NDT", (int)(radGridView1.Width * 0.10f));
			AddColumn("M.H.", (int)(radGridView1.Width * 0.24f));
			AddColumn("Cost", (int)(radGridView1.Width * 0.24f));
			AddColumn("Remarks", (int)(radGridView1.Width * 0.24f));
			AddColumn("Hidden remarks", (int)(radGridView1.Width * 0.24f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.2f));
        }
		#endregion

		#region Overrides of BaseGridViewControl<InitialOrderRecord>

		protected override void GroupingItems()
		{
			Grouping("Aircraft");
		}

		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Directive item)

		protected override List<CustomCell> GetListViewSubItems(Directive item)
        {
            var subItems = new List<CustomCell>();
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

            var groupName = "";
            if (item is DeferredItem)
			{
				var aircraft = GlobalObjects.AircraftsCore.GetAircraftById(item.ParentBaseComponent.ParentAircraftId);

				groupName = $"{aircraft}";
			}


			subItems.Add(CreateRow(groupName, groupName));
            subItems.Add(CreateRow(titleString, titleString));
            subItems.Add(CreateRow(sbString, sbString));
            subItems.Add(CreateRow(eoString, eoString));
            subItems.Add(CreateRow(descriptionString, descriptionString));
            subItems.Add(CreateRow(applicabilityString, applicabilityString));
            subItems.Add(CreateRow(workType.ToString(), workType));
            subItems.Add(CreateRow(cat.ToString(), cat));
            subItems.Add(CreateRow(status.ToString(), status));
            subItems.Add(CreateRow(effDate > DateTimeExtend.GetCASMinDateTime()
	            ? SmartCore.Auxiliary.Convert.GetDateFormat(effDate) : "", effDate));
            subItems.Add(CreateRow(firstPerformanceString, firstPerformanceString));
            subItems.Add(CreateRow(repeatInterval.ToString(), repeatInterval));
            subItems.Add(CreateRow(nextComplianceString, nextComplianceDate));
            subItems.Add(CreateRow(nextRemainString, nextRemainString));
            subItems.Add(CreateRow(lastPerformanceString, lastComplianceDate));
            subItems.Add(CreateRow(ata.ToString(), ata));
            subItems.Add(CreateRow(kitRequieredString, kitRequieredString));
            subItems.Add(CreateRow(ndtString, ndtString));
            subItems.Add(CreateRow(manHours == -1 ? "" : manHours.ToString(), manHours));
            subItems.Add(CreateRow(cost == -1 ? "" : cost.ToString(), cost));
            subItems.Add(CreateRow(remarksString, remarksString));
            subItems.Add(CreateRow(hiddenRemarksString, hiddenRemarksString));
            subItems.Add(CreateRow(author, author));
			
			return subItems;
        }

        #endregion

        #region protected override void SortItems(int columnIndex)

     //   protected override void SortItems(int columnIndex)
     //   {
     //       if (OldColumnIndex != columnIndex)
     //           SortMultiplier = -1;
     //       if (SortMultiplier == 1)
     //           SortMultiplier = -1;
     //       else
     //           SortMultiplier = 1;
     //       itemsListView.Items.Clear();

     //       List<ListViewItem> resultList = new List<ListViewItem>();

     //       if (columnIndex <= 4 || (columnIndex >= 5 && columnIndex <= 8) || columnIndex >= 19)
     //       {
     //           SetGroupsToItems(columnIndex);

     //           ListViewItemList.Sort(new CPCPDirectiveListViewComparer(columnIndex, SortMultiplier));
     //           //добавление остальных подзадач
     //           foreach (ListViewItem item in ListViewItemList)
     //           {
     //               resultList.Add(item);
     //           }
     //       }
     //       else if (columnIndex == 11)
     //       {
     //           foreach (ListViewItem item in ListViewItemList)
     //           {
     //               resultList.Add(item);
     //           }

     //           resultList.Sort(new BaseListViewComparer(columnIndex, SortMultiplier));

     //           itemsListView.Groups.Clear();
     //           foreach (var item in resultList)
     //           {
					//var temp = ListViewGroupHelper.GetGroupStringByPerformanceDate(item.Tag);
					//itemsListView.Groups.Add(temp, temp);
     //               item.Group = itemsListView.Groups[temp];
     //           }
     //       }
     //       else
     //       {
     //           SetGroupsToItems(columnIndex);

     //           //добавление остальных подзадач
     //           foreach (ListViewItem item in ListViewItemList)
     //           {
     //               resultList.Add(item);
     //           }
     //           resultList.Sort(new CPCPDirectiveListViewComparer(columnIndex, SortMultiplier));
     //       }
     //       itemsListView.Items.AddRange(resultList.ToArray());
     //       OldColumnIndex = columnIndex;
     //   }

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
