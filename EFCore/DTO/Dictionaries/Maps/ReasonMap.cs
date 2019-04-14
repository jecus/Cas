using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class ReasonMap : BaseMap<ReasonDTO>
	{
		public ReasonMap() : base()
		{
			ToTable("Dictionaries.Reasons");

			Property(i => i.Name)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Name");

			Property(i => i.Category)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Category");
		}
	}
}