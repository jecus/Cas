using System;
using System.Reflection;
using EFCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Entities.General.Interfaces;
using SmartCore.Entities.General.MaintenanceWorkscope;

namespace SmartCore.Relation
{
	[Table("ItemsRelations", "dbo", "ItemId")]
	[Dto(typeof(ItemsRelationDTO))]
	[Serializable]
	public class ItemsRelation : BaseEntityObject
	{
		private static Type _thisType;

		#region public int FirstItemId { get; set; }

		[TableColumn("FirstItemId")]
		public int FirstItemId { get; set; }

		public static PropertyInfo FirstItemIdProperty
		{
			get { return GetCurrentType().GetProperty("FirstItemId"); }
		}

		#endregion

		#region public int FirtsItemTypeId { get; set; }

		[TableColumn("FirtsItemTypeId")]
		public int FirtsItemTypeId { get; set; }

		public static PropertyInfo FirtsItemTypeIdProperty
		{
			get { return GetCurrentType().GetProperty("FirtsItemTypeId"); }
		}

		#endregion

		#region public int SecondItemId { get; set; }

		[TableColumn("SecondItemId")]
		public int SecondItemId { get; set; }

		public static PropertyInfo SecondItemIdProperty
		{
			get { return GetCurrentType().GetProperty("SecondItemId"); }
		}

		#endregion

		#region public int SecondItemTypeId { get; set; }

		[TableColumn("SecondItemTypeId")]
		public int SecondItemTypeId { get; set; }

		public static PropertyInfo SecondItemTypeIdProperty
		{
			get { return GetCurrentType().GetProperty("SecondItemTypeId"); }
		}

		#endregion

		#region public WorkItemsRelationType RelationTypeId { get; set; }

		[TableColumn("RelationTypeId")]
		public WorkItemsRelationType RelationTypeId { get; set; }

		#endregion

		#region public void FillParameters(IBaseEntityObject firstItem, IBaseEntityObject secondItem)

		public void FillParameters(IBaseEntityObject firstItem, IBaseEntityObject secondItem)
		{
			fillParameters(firstItem, secondItem);
		}

		#endregion

		#region public void FillParameters(IBaseEntityObject firstItem, IBaseEntityObject secondItem, WorkItemsRelationType workItemsRelationType)

		public void FillParameters(IBaseEntityObject firstItem, IBaseEntityObject secondItem, WorkItemsRelationType workItemsRelationType)
		{
			fillParameters(firstItem, secondItem);
			RelationTypeId = workItemsRelationType;
		}

		#endregion

		#region private void fillParameters(IBaseEntityObject firstItem, IBaseEntityObject secondItem)

		private void fillParameters(IBaseEntityObject firstItem, IBaseEntityObject secondItem)
		{
			FirstItemId = firstItem.ItemId;
			FirtsItemTypeId = firstItem.SmartCoreObjectType.ItemId;
			SecondItemId = secondItem.ItemId;
			SecondItemTypeId = secondItem.SmartCoreObjectType.ItemId;
		}

		#endregion

		#region private static Type GetCurrentType()
		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(ItemsRelation));
		}
		#endregion

	}
}