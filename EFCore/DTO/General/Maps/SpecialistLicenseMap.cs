using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class SpecialistLicenseMap : BaseMap<SpecialistLicenseDTO>
	{
		public SpecialistLicenseMap() : base()
		{
			ToTable("dbo.SpecialistsLicense");

			Property(i => i.Confirmation)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Confirmation");

			Property(i => i.LicenseTypeID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LicenseTypeID");

			Property(i => i.AircraftTypeID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AircraftTypeID");

			Property(i => i.SpecialistId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SpecialistId");

			Property(i => i.Notify)
				.HasMaxLength(21)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Notify");

			Property(i => i.IssueDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IssueDate");

			Property(i => i.ValidToDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ValidToDate");

			HasRequired(i => i.AircraftType)
				.WithMany(i => i.SpecialistLicenseDtos)
				.HasForeignKey(i => i.AircraftTypeID);

			HasMany(i => i.CaaLicense).WithRequired(i => i.SpecialistLicense).HasForeignKey(i => i.SpecialistLicenseId);

			HasMany(i => i.LicenseDetails).WithRequired(i => i.SpecialistLicense).HasForeignKey(i => i.SpecialistLicenseId);

			HasMany(i => i.LicenseRatings).WithRequired(i => i.SpecialistLicense).HasForeignKey(i => i.SpecialistLicenseId);

			HasMany(i => i.SpecialistInstrumentRatings).WithRequired(i => i.SpecialistLicense).HasForeignKey(i => i.SpecialistLicenseId);

			HasMany(i => i.LicenseRemark).WithRequired(i => i.SpecialistLicense).HasForeignKey(i => i.SpecialistLicenseId);
		}
	}
}