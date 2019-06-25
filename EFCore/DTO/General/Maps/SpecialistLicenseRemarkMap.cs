using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class SpecialistLicenseRemarkMap : BaseMap<SpecialistLicenseRemarkDTO>
	{
		public SpecialistLicenseRemarkMap() : base()
		{
			HasRequired(i => i.Rights)
				.WithMany(i => i.LicenseRemarkDtos)
				.HasForeignKey(i => i.RightsId);

			HasRequired(i => i.LicenseRestriction)
				.WithMany(i => i.LicenseRemarkDtos)
				.HasForeignKey(i => i.RestrictionId);
		}
	}
}