using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SmartCore.Tests.DataAccess
{
	public class NonRoutineJobMap : EntityTypeConfiguration<NonRoutineJob>
	{
		public NonRoutineJobMap()
		{
			ToTable("NonRoutineJobs", "Dictionaries");
			// Primary Key
			HasKey(t => new { t.ItemId });

			// Properties
			Property(t => t.ItemId).HasColumnName("ItemId");

			Property(t => t.IsDeleted)
					 .IsRequired()
					 .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
					 .HasColumnName("IsDeleted");

			Property(t => t.ATAChapterId)
					 .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
					 .HasColumnName("ATAChapterId");

			Property(t => t.Title)
					.HasMaxLength(50)
					.HasColumnName("Title");

			Property(t => t.Description)
					 .HasColumnName("Description");

			Property(t => t.ManHours).HasColumnName("ManHours");

			Property(t => t.Cost).HasColumnName("Cost");

			Property(t => t.KitRequired)
				.HasMaxLength(50)
				.HasColumnName("KitRequired");

			Property(t => t.FileId)
					.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
					.HasColumnName("FileId");


			HasMany(c => c.ItemFileLinks)
				.WithRequired(a => a.NonRoutineJob)
				.HasForeignKey(a => a.ParentId);

		}
	}
}