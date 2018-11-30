using System;
using SmartCore.Calculations;
using SmartCore.Entities.Collections;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General.Interfaces;

namespace SmartCore.Relation
{
	public interface IBindedItem : IBaseEntityObject
	{
		CommonCollection<ItemsRelation> ItemRelations { get; set; }
		WorkItemsRelationType WorkItemsRelationType { get; set; }
		bool? IsFirst { get; }
		NextPerformance BindedItemNextPerformance { get; set; }
		ConditionState BindedItemCondition { get; set; }
		Lifelength BindedItemNextPerformanceSource { get; set; }
		Lifelength BindedItemRemains { get; set; }
		DateTime? BindedItemNextPerformanceDate { get; set; }

		void NormalizeItemRelations();
	}
}