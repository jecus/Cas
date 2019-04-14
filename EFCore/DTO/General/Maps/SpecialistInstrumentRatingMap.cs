using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class SpecialistInstrumentRatingMap : BaseMap<SpecialistInstrumentRatingDTO>
	{
		public SpecialistInstrumentRatingMap() : base()
		{
			ToTable("dbo.SpecialistsInstrumentRating");

			Property(i => i.IssueDate)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IssueDate");

			Property(i => i.SpecialistLicenseId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SpecialistLicenseId");

			Property(i => i.IcaoId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IcaoId");

			Property(i => i.MC)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MC");

			Property(i => i.MV)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MV");

			Property(i => i.RVR)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RVR");

			Property(i => i.TORVR)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TORVR");
		}
	}
}