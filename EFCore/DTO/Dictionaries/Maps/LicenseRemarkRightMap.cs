using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class LicenseRemarkRightMap : BaseMap<LicenseRemarkRightDTO>
	{
		public LicenseRemarkRightMap() : base()
		{
			ToTable("Dictionaries.LicenseRemarkRights");

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