using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class MTOPCheckMap : EntityTypeConfiguration<MTOPCheckDTO>
	{
		public MTOPCheckMap()
		{
			ToTable("dbo.MTOPCheck");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

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