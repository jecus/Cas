using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class RestrictionMap : BaseMap<RestrictionDTO>
	{
		public RestrictionMap() : base()
		{
			ToTable("Dictionaries.Restriction");

			Property(i => i.Name)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Name");

			Property(i => i.FullName)
				.IsRequired()
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FullName");
		}
	}
}