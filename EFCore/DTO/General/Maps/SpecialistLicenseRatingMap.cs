using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class SpecialistLicenseRatingMap : BaseMap<SpecialistLicenseRatingDTO>
	{
		public SpecialistLicenseRatingMap() : base()
		{
			ToTable("dbo.SpecialistsLicenseRating");

			Property(i => i.IssueDate)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IssueDate");

			Property(i => i.SpecialistLicenseId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SpecialistLicenseId");

			Property(i => i.RightsId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RightsId");

			Property(i => i.FunctionId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FunctionId");
		}
	}
}