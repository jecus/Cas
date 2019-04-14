using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class AttachedFileMap : BaseMap<AttachedFileDTO>
	{
		public AttachedFileMap() : base()
		{
			ToTable("dbo.Files");

			Property(i => i.FileName)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FileName");

			Property(i => i.FileData)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FileData");

			Property(i => i.FileSize)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
				.HasColumnName("FileSize");

			Property(i => i.StoreInDatabase)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("StoreInDatabase");

			Property(i => i.FilePath)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FilePath");
		}
	}
}