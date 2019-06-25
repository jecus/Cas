using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class SpecialistLicenseMap : BaseMap<SpecialistLicenseDTO>
	{
		public SpecialistLicenseMap() : base()
		{
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