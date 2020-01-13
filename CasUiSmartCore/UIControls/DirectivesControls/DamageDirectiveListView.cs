using System;
using System.Collections.Generic;
using CAS.UI.Interfaces;
using CAS.UI.Management.Dispatchering;
using CAS.UI.UIControls.NewGrid;
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
			AddColumn("Damage", (int)(radGridView1.Width * 0.24f));
			AddColumn("SB No", (int)(radGridView1.Width * 0.24f));
			AddColumn("EO No", (int)(radGridView1.Width * 0.24f));
			AddColumn("Description", (int)(radGridView1.Width * 0.24f));
			AddColumn("Corrective Action", (int)(radGridView1.Width * 0.24f));
			AddColumn("Number", (int)(radGridView1.Width * 0.10f));
			AddColumn("Class", (int)(radGridView1.Width * 0.10f));
			AddColumn("Type", (int)(radGridView1.Width * 0.10f));
			AddColumn("Location", (int)(radGridView1.Width * 0.16f));
			AddColumn("Size", (int)(radGridView1.Width * 0.2f));
			AddColumn("Applicabilty", (int)(radGridView1.Width * 0.24f));
			AddColumn("Work Type", (int)(radGridView1.Width * 0.16f));
			AddColumn("Status", (int)(radGridView1.Width * 0.24f));
			AddColumn("Effective date", (int)(radGridView1.Width * 0.24f));

			AddColumn("1st. Perf.", (int)(radGridView1.Width * 0.24f));
			AddColumn("Rpt. Intv.", (int)(radGridView1.Width * 0.24f));
			AddColumn("Next(E)", (int)(radGridView1.Width * 0.15f));
			AddColumn("Next Estimated Data", (int)(radGridView1.Width * 0.2f));
			AddColumn("Remain(E)", (int)(radGridView1.Width * 0.2f));
			AddColumn("Next(L)", (int)(radGridView1.Width * 0.15f));
			AddColumn("Next Limit Data", (int)(radGridView1.Width * 0.2f));
			AddColumn("Remain(L)", (int)(radGridView1.Width * 0.24f));
			AddColumn("Last", (int)(radGridView1.Width * 0.15f));
			AddColumn("Last Data", (int)(radGridView1.Width * 0.2f));

			AddColumn("ATA Chapter", (int)(radGridView1.Width * 0.10f));
			AddColumn("Is Temporary", (int)(radGridView1.Width * 0.16f));
			AddColumn("Kit", (int)(radGridView1.Width * 0.10f));
			AddColumn("NDT", (int)(radGridView1.Width * 0.10f));
			AddColumn("M.H.", (int)(radGridView1.Width * 0.24f));
			AddColumn("Cost", (int)(radGridView1.Width * 0.24f));
			AddColumn("Remarks", (int)(radGridView1.Width * 0.24f));
			AddColumn("Hidden remarks", (int)(radGridView1.Width * 0.24f));
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Directive item)

		protected override List<CustomCell> GetListViewSubItems(Directive item)
		{
			var subItems = new List<CustomCell>();
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
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
			else lastPerformanceString = lastComplianceLifeLength.ToString();

			var lastDate = (lastComplianceDate <= DateTimeExtend.GetCASMinDateTime())
				? ""
				: SmartCore.Auxiliary.Convert.GetDateFormat(lastComplianceDate);

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
			var condition = item.Threshold.FirstPerformanceConditionType ==
			                ThresholdConditionType.WhicheverFirst
				? "WF"
				: "WL";

			subItems.Add(CreateRow(titleString, titleString));
			subItems.Add(CreateRow(sbString, sbString));
			subItems.Add(CreateRow(eoString, eoString));
			subItems.Add(CreateRow(descriptionString, descriptionString));
			subItems.Add(CreateRow(corrective, corrective));
			subItems.Add(CreateRow(numberString, numberString));
			subItems.Add(CreateRow(classString, classString));
			subItems.Add(CreateRow(typeString, typeString));
			subItems.Add(CreateRow(locationString, locationString));
			subItems.Add(CreateRow(sizeString, sizeString));
			subItems.Add(CreateRow(applicabilityString, applicabilityString));
			subItems.Add(CreateRow(workType.ToString(), workType));
			subItems.Add(CreateRow(status.ToString(), status));
			subItems.Add(CreateRow(effDate > DateTimeExtend.GetCASMinDateTime()
				? SmartCore.Auxiliary.Convert.GetDateFormat(effDate) : "", effDate));
			subItems.Add(CreateRow($"{firstPerformanceString} /{condition}", firstPerformanceString));
			subItems.Add(CreateRow(repeatInterval.ToString(), repeatInterval));

			subItems.Add(CreateRow(SmartCore.Auxiliary.Convert.GetDateFormat(item.NextPerformance?.PerformanceDate), item.NextPerformance?.PerformanceDate));
			subItems.Add(CreateRow(item.NextPerformance?.PerformanceSource.ToString(), item.NextPerformance?.PerformanceSource));
			subItems.Add(CreateRow(item.NextPerformance?.Remains.ToString(), item.NextPerformance?.Remains));
			subItems.Add(CreateRow(item.NextPerformance?.NextLimit.Days != null ? SmartCore.Auxiliary.Convert.GetDateFormat(item.NextPerformance?.NextPerformanceDateNew) : "", item.NextPerformance?.NextPerformanceDateNew));
			subItems.Add(CreateRow(item.NextPerformance?.NextLimit.ToString(), item.NextPerformance?.NextLimit.ToString()));
			subItems.Add(CreateRow(item.NextPerformance?.RemainLimit.ToString(), item.NextPerformance?.RemainLimit.ToString()));
			subItems.Add(CreateRow(lastDate, lastComplianceDate));
			subItems.Add(CreateRow(lastPerformanceString, lastComplianceDate));


			subItems.Add(CreateRow(ata.ToString(), ata));
			subItems.Add(CreateRow(temporaryString, temporaryString));
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

		//protected override void SortItems(int columnIndex)
		//{
		//    if (OldColumnIndex != columnIndex)
		//        SortMultiplier = -1;
		//    if (SortMultiplier == 1)
		//        SortMultiplier = -1;
		//    else
		//        SortMultiplier = 1;
		//    itemsListView.Items.Clear();

		//    List<ListViewItem> resultList = new List<ListViewItem>();

		//    if (columnIndex <= 4 || columnIndex == 7 || columnIndex >= 18)
		//    {
		//        SetGroupsToItems(columnIndex);

		//        ListViewItemList.Sort(new CPCPDirectiveListViewComparer(columnIndex, SortMultiplier));
		//        //добавление остальных подзадач
		//        foreach (ListViewItem item in ListViewItemList)
		//        {
		//            resultList.Add(item);
		//        }
		//    }
		//    else if (columnIndex == 10)
		//    {
		//        foreach (ListViewItem item in ListViewItemList)
		//        {
		//            resultList.Add(item);
		//        }

		//        resultList.Sort(new BaseListViewComparer(columnIndex, SortMultiplier));

		//        itemsListView.Groups.Clear();
		//        foreach (var item in resultList)
		//        {
		//            var temp = ListViewGroupHelper.GetGroupStringByPerformanceDate(item.Tag);
		//            itemsListView.Groups.Add(temp, temp);
		//            item.Group = itemsListView.Groups[temp];
		//        }
		//    }
		//    else
		//    {
		//        SetGroupsToItems(columnIndex);
		//        //добавление остальных подзадач
		//        foreach (ListViewItem item in ListViewItemList)
		//        {
		//            resultList.Add(item);
		//        }
		//        resultList.Sort(new CPCPDirectiveListViewComparer(columnIndex, SortMultiplier));
		//    }
		//    itemsListView.Items.AddRange(resultList.ToArray());
		//    OldColumnIndex = columnIndex;
		//}

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
