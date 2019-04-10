using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ATLBMap : BaseMap<ATLBDTO>
	{
		public ATLBMap() : base()
		{
			ToTable("dbo.ATLBs");

			Property(i => i.AircraftID)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AircraftID");

			Property(i => i.ATLBNo)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ATLBNo");

			Property(i => i.StartPageNo)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("StartPageNo");

			Property(i => i.OpeningDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OpeningDate");

			Property(i => i.Remarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.Revision)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Revision");

			Property(i => i.PageFlightCount)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PageFlightCount");

			Property(i => i.AtlbStatus)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AtlbStatus");


			HasMany(i => i.Files).WithRequired(i => i.Atlb).HasForeignKey(i => i.ParentId);
		}
	}
}