using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class MTOPCheckMap : BaseMap<MTOPCheckDTO>
	{
		public MTOPCheckMap() : base()
		{
			ToTable("dbo.MTOPCheck");

			Property(i => i.Name)
				.HasMaxLength(150)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Name");

			Property(i => i.ParentAircraftId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentAircraftId");

			Property(i => i.CheckTypeId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CheckTypeId");

			Property(i => i.Thresh)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Thresh");

			Property(i => i.Repeat)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Repeat");

			Property(i => i.Notify)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Notify");

			Property(i => i.IsZeroPhase)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsZeroPhase");


			HasRequired(i => i.CheckType)
				.WithMany(i => i.MtopCheckDtos)
				.HasForeignKey(i => i.CheckTypeId);

			HasMany(i => i.PerformanceRecords).WithRequired(i => i.MtopCheckDto).HasForeignKey(i => i.ParentId);

		}
	}
}