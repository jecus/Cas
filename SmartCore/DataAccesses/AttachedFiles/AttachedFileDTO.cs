using SmartCore.Entities.General;
using SmartCore.Entities.General.Attributes;

namespace SmartCore.DataAccesses.AttachedFiles
{
	[Table("Files", "dbo", "ItemId")]
	[Dto(typeof(AttachedFileDTO))]
	public class AttachedFileDTO : BaseEntityObject
	{
		/*
        *  Свойства
        */
		[TableColumn("FileName")]
		public string FileName { get; set; }

		[TableColumn("FileData", forced: true)]
		public byte[] FileData { get; set; }

		[TableColumn("FileSize", ColumnAccessType.ReadOnly)]
		public int? FileSize { get; set; }

		/*
		*  Методы 
		*/

		/// <summary>
		/// Создает прикрепляемый без дополнительной информации
		/// </summary>
		public AttachedFileDTO()
		{
			ItemId = -1;
			IsDeleted = false;
		}
	}
}
