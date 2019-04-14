using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class SpecialistLicenseRemarkMap : BaseMap<SpecialistLicenseRemarkDTO>
	{
		public SpecialistLicenseRemarkMap() : base()
		{
			ToTable("dbo.SpecialistsLicenseRemark");

			Property(i => i.IssueDate)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IssueDate");

			Property(i => i.RightsId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RightsId");

			Property(i => i.RestrictionId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RestrictionId");

			Property(i => i.SpecialistLicenseId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SpecialistLicenseId");

			Property(i => i.SpecialistId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SpecialistId");

			HasRequired(i => i.Rights)
				.WithMany(i => i.LicenseRemarkDtos)
				.HasForeignKey(i => i.RightsId);

			HasRequired(i => i.LicenseRestriction)
				.WithMany(i => i.LicenseRemarkDtos)
				.HasForeignKey(i => i.RestrictionId);
		}
	}
}