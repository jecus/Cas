using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class DamageSectorMap : BaseMap<DamageSectorDTO>
	{
		public DamageSectorMap() : base()
		{
			ToTable("dbo.DamageSectors");

			Property(i => i.DamageChartColumn)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DamageChartColumn");

			Property(i => i.DamageChartRow)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DamageChartRow");

			Property(i => i.Remarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.DamageDocumentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DamageDocumentId");
		}
	}
}