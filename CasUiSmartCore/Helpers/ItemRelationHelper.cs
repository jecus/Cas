
using System;
using System.Windows.Forms;
using CAS.UI.Interfaces;
using CASTerms;
using SmartCore.Entities.Dictionaries;

namespace CAS.UI.Helpers
{
	public static class ItemRelationHelper
	{
		public static WorkItemsRelationType ConvertUIItemRelationToBLItem(WorkItemsRelationTypeUI workItemsRelationTypeUI, bool? isFirst)
		{
			if (!isFirst.HasValue)
				throw new ArgumentException("IsFirst must have value when convert from UI to Bl item");

			WorkItemsRelationType relationType;

			if (isFirst == true)
			{
				relationType = workItemsRelationTypeUI == WorkItemsRelationTypeUI.ThisItemAffectOnAnother 
					? WorkItemsRelationType.CalculationAffect 
					: WorkItemsRelationType.CalculationDepend;
			}
			else
			{
				relationType = workItemsRelationTypeUI == WorkItemsRelationTypeUI.ThisItemAffectOnAnother 
					? WorkItemsRelationType.CalculationDepend 
					: WorkItemsRelationType.CalculationAffect;
			}
			
			return relationType;
			
		}

		public static WorkItemsRelationTypeUI ConvertBLItemRelationToUIITem(WorkItemsRelationType workItemsRelationType, bool isFirst)
		{
			WorkItemsRelationTypeUI relationTypeUI;

			if (isFirst)
			{
				switch (workItemsRelationType)
				{
					case WorkItemsRelationType.CalculationAffect:
						relationTypeUI = WorkItemsRelationTypeUI.ThisItemAffectOnAnother;
						break;
					case WorkItemsRelationType.CalculationDepend:
						relationTypeUI = WorkItemsRelationTypeUI.ThisItemDependsFromAnother;
						break;
					default:
						relationTypeUI = WorkItemsRelationTypeUI.Incorrect;
						break;
				}
			}
			else
			{
				switch (workItemsRelationType)
				{
					case WorkItemsRelationType.CalculationAffect:
						relationTypeUI = WorkItemsRelationTypeUI.ThisItemDependsFromAnother;
						break;
					case WorkItemsRelationType.CalculationDepend:
						relationTypeUI = WorkItemsRelationTypeUI.ThisItemAffectOnAnother;
						break;
					default:
						relationTypeUI = WorkItemsRelationTypeUI.Incorrect;
						break;
				}
			}

			return relationTypeUI;
		}

		public static void ShowDialogIfItemHaveLinkWithAnotherItem(string thisItem, string anotherItem, string bindedItem)
		{
			MessageBox.Show($"{thisItem} have links with {anotherItem} and cannot be linked with {bindedItem}",
				(string)new GlobalTermsProvider()["SystemName"],
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		public static void ShowDialogIfItemLinksCountMoreThanOne(string thisItem, int itemRelationsCount)
		{
			MessageBox.Show(
				$"This {thisItem} have {itemRelationsCount} link's with other Items, but should be only one Linked Item.",
				(string)new GlobalTermsProvider()["SystemName"],
				MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}
}