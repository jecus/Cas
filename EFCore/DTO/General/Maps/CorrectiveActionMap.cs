using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class CorrectiveActionMap : BaseMap<CorrectiveActionDTO>
	{
		public CorrectiveActionMap() : base()
		{
			ToTable("dbo.CorrectiveActions");

			Property(i => i.DiscrepancyID)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DiscrepancyID");

			Property(i => i.Description)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Description");

			Property(i => i.ShortDescription)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ShortDescription");

			Property(i => i.ADDNo)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ADDNo");

			Property(i => i.IsClosed)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsClosed");

			Property(i => i.PartNumberOff)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PartNumberOff");

			Property(i => i.SerialNumberOff)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SerialNumberOff");

			Property(i => i.PartNumberOn)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PartNumberOn");

			Property(i => i.SerialNumberOn)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SerialNumberOn");

			Property(i => i.CRSID)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CRSID");
		}
	}
}