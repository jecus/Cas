using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class SpecialistLicenseDetailMap : BaseMap<SpecialistLicenseDetailDTO>
	{
		public SpecialistLicenseDetailMap() : base()
		{
			ToTable("dbo.SpecialistsLicenseDetail");
			
			Property(i => i.Description)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Description");

			Property(i => i.IssueDate)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IssueDate");

			Property(i => i.SpecialistLicenseId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SpecialistLicenseId");

			Property(i => i.SpecialistId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SpecialistId");
		}
	}
}