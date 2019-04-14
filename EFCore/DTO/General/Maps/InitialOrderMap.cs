using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class InitialOrderMap : BaseMap<InitialOrderDTO>
	{
		public InitialOrderMap() : base()
		{
			ToTable("dbo.InitialOrders");

			Property(i => i.Title)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Title");

			Property(i => i.Description)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Description");

			Property(i => i.Author)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Author");

			Property(i => i.ParentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentId");

			Property(i => i.PublishedById)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PublishedById");

			Property(i => i.ClosedById)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ClosedById");

			Property(i => i.ParentTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentTypeId");

			Property(i => i.Status)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Status");

			Property(i => i.OpeningDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OpeningDate");

			Property(i => i.PublishingDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PublishingDate");

			Property(i => i.ClosingDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ClosingDate");

			Property(i => i.Remarks)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.PublishedByUser)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PublishedByUser ");

			Property(i => i.CloseByUser)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CloseByUser");

			Property(i => i.Number)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Number");

			//HasRequired(i => i.PublishedBy)
			//	.WithMany(i => i.PublishedDtos)
			//	.HasForeignKey(i => i.PublishedById);

			//HasRequired(i => i.ClosedBy)
			//	.WithMany(i => i.ClosedDtos)
			//	.HasForeignKey(i => i.ClosedById);


			HasMany(i => i.Files).WithRequired(i => i.InitialOrderDto).HasForeignKey(i => i.ParentId);
			HasMany(i => i.PackageRecords).WithRequired(i => i.InitialOrderDto).HasForeignKey(i => i.ParentPackageId);
		}
	}
}