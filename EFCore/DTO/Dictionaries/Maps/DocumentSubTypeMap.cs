using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class DocumentSubTypeMap : BaseMap<DocumentSubTypeDTO>
	{
		public DocumentSubTypeMap() : base()
		{
			ToTable("Dictionaries.DocumentSubType");
			
			Property(i => i.DocumentTypeId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DocumentTypeId");

			Property(i => i.Name)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Name");
		}
	}
}