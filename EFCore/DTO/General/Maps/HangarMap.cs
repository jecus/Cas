using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class HangarMap : BaseMap<HangarDTO>
	{
		public HangarMap() : base()
		{
			ToTable("dbo.Hangars");

			Property(i => i.StoreName)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("StoreName");

			Property(i => i.Location)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Location");

			Property(i => i.OperatorId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OperatorId");

			Property(i => i.Remarks)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");
		}
	}
}