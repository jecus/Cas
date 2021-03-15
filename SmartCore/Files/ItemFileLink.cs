using System;
using System.Reflection;
using EntityCore.DTO.General;
using SmartCore.Entities.Dictionaries;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.Files
{
	[Table("ItemsFilesLinks", "dbo", "ItemId")]
	[Dto(typeof(ItemFileLinkDTO))]
	[Serializable]
	public class ItemFileLink : BaseEntityObject
	{
		#region Fields

		private static Type _thisType;

		#endregion

		#region Properties

		#region public int ParentId { get; set; }

		/// <summary>
		/// Идентификатор родительской задачи
		/// </summary>
		[TableColumn("ParentId")]
		public int ParentId { get; set; }

		public static PropertyInfo ParentIdProperty
		{
			get { return GetCurrentType().GetProperty("ParentId"); }
		}
		#endregion

		#region public int ParentTypeId { get; set; }

		/// <summary>
		/// Идентификатор типа родительской задачи
		/// </summary>
		[TableColumn("ParentTypeId")]
		public int ParentTypeId { get; set; }

		public static PropertyInfo ParentTypeIdProperty
		{
			get { return GetCurrentType().GetProperty("ParentTypeId"); }
		}
		#endregion

		#region public short LinkType { get; set; }

		/// <summary>
		/// Тип связи между элементом и файлом
		/// </summary>
		[TableColumn("LinkType")]
		public short LinkType { get; set; }

		#endregion

		#region public AttachedFile File { get; set; }

		/// <summary>
		/// Привязанный файл
		/// </summary>
		[TableColumn("FileId")]
		[Child]
		public AttachedFile File { get; set; }
		public static PropertyInfo FileIdProperty
		{
			get { return GetCurrentType().GetProperty("File"); }
		}
		#endregion

		#endregion

		#region Methods

		#region private static Type GetCurrentType()

		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof (ItemFileLink));
		}

		#endregion

		#region public new ItemFileLink GetCopyUnsaved()

		public new ItemFileLink GetCopyUnsaved(bool marked = true)
		{
			var itemFileLink = (ItemFileLink) MemberwiseClone();
			itemFileLink.ItemId = -1;
			itemFileLink.ParentId = -1;
			itemFileLink.UnSetEvents();

			return itemFileLink;
		}

		#endregion

        public ItemFileLink()
        {
            ItemId = -1;
            SmartCoreObjectType = SmartCoreType.ItemFileLink;
        }

		#endregion

		}
}