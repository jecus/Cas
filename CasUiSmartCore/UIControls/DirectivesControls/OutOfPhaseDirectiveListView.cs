﻿using System;
using System.Collections.Generic;
using System.Drawing;
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
			AddColumn("Title", (int)(radGridView1.Width * 0.24f));
			AddColumn("SB No", (int)(radGridView1.Width * 0.24f));
			AddColumn("EO No", (int)(radGridView1.Width * 0.24f));
			AddColumn("Description", (int)(radGridView1.Width * 0.24f));
			AddColumn("Applicabilty", (int)(radGridView1.Width * 0.24f));
			AddColumn("Work Type", (int)(radGridView1.Width * 0.16f));
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
			AddColumn("Signer", (int)(radGridView1.Width * 0.3f));
		}
		#endregion

		#region protected override ListViewItem.ListViewSubItem[] GetListViewSubItems(Directive item)

		protected override List<CustomCell> GetListViewSubItems(Directive item)
		{
			var subItems = new List<CustomCell>();
			var author = GlobalObjects.CasEnvironment.GetCorrector(item);
			var sbColor = radGridView1.ForeColor;
			var eoColor = radGridView1.ForeColor;

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

			if (!item.HasSdFile)
				sbColor = Color.MediumVioletRed;
			if (!item.HasEoFile)
				eoColor = Color.MediumVioletRed;

			subItems.Add(CreateRow(titleString, titleString));
			subItems.Add(CreateRow(sbString, sbString, sbColor));
			subItems.Add(CreateRow(eoString, eoString, eoColor));
			subItems.Add(CreateRow(descriptionString, descriptionString));
			subItems.Add(CreateRow(applicabilityString, applicabilityString));
			subItems.Add(CreateRow(workType.ToString(), workType));
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
	 //           SortDirection = -1;
	 //       if (SortDirection == 1)
	 //           SortDirection = -1;
	 //       else
	 //           SortDirection = 1;
	 //       itemsListView.Items.Clear();

	 //       List<ListViewItem> resultList = new List<ListViewItem>();

	 //       if (columnIndex <= 4 || columnIndex == 6 || columnIndex >= 16)
	 //       {
	 //           SetGroupsToItems(columnIndex);
	 //           ListViewItemList.Sort(new CPCPDirectiveListViewComparer(columnIndex, SortDirection));
	 //           //добавление остальных подзадач
	 //           foreach (ListViewItem item in ListViewItemList)
	 //           {
	 //               resultList.Add(item);
	 //           }
	 //       }
	 //       else if (columnIndex == 10)
	 //       {
	 //           foreach (ListViewItem item in ListViewItemList)
	 //           {
	 //               resultList.Add(item);
	 //           }

	 //           resultList.Sort(new BaseListViewComparer(columnIndex, SortDirection));

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
	 //           resultList.Sort(new CPCPDirectiveListViewComparer(columnIndex, SortDirection));
	 //       }
	 //       itemsListView.Items.AddRange(resultList.ToArray());
	 //       OldColumnIndex = columnIndex;
	 //   }

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
