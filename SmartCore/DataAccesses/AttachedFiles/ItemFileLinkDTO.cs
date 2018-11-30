using System;
using System.Reflection;
using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;
using SmartCore.Files;

namespace SmartCore.DataAccesses.AttachedFiles
{
	[Table("ItemsFilesLinks", "dbo", "ItemId")]
	[Dto(typeof(AttachedFileDTO))]
	public class ItemFileLinkDTO : BaseEntityObject
	{
		private static Type _thisType;

		/// <summary>
		/// Идентификатор родительской задачи
		/// </summary>
		[TableColumn("ParentId")]
		public int ParentId { get; set; }

		public static PropertyInfo ParentIdProperty
		{
			get { return GetCurrentType().GetProperty("ParentId"); }
		}

		/// <summary>
		/// Идентификатор типа родительской задачи
		/// </summary>
		[TableColumn("ParentTypeId")]
		public int ParentTypeId { get; set; }

		public static PropertyInfo ParentTypeIdProperty
		{
			get { return GetCurrentType().GetProperty("ParentTypeId"); }
		}

		/// <summary>
		/// Тип связи между элементом и файлом
		/// </summary>
		[TableColumn("LinkType")]
		public short LinkType { get; set; }

		/// <summary>
		/// Привязанный файл
		/// </summary>
		[TableColumn("FileId")]
		[Child]
		public AttachedFileDTO File { get; set; }
		public static PropertyInfo FileIdProperty
		{
			get { return GetCurrentType().GetProperty("File"); }
		}

		private static Type GetCurrentType()
		{
			return _thisType ?? (_thisType = typeof(ItemFileLinkDTO));
		}


	}
}