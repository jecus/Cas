using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class DocumentMap : EntityTypeConfiguration<DocumentDTO>
	{
		public DocumentMap()
		{
			ToTable("dbo.Documents");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

			Property(i => i.ParentID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentID");

			Property(i => i.ParentTypeId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentTypeId");

			Property(i => i.DocTypeId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DocTypeId");

			Property(i => i.SubTypeId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SubTypeId");

			Property(i => i.Description)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Description");

			Property(i => i.IssueDateValidFrom)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IssueDateValidFrom");

			Property(i => i.IssueValidTo)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IssueValidTo");

			Property(i => i.IssueDateValidTo)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IssueDateValidTo");

			Property(i => i.IssueNotify)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IssueNotify");

			Property(i => i.ContractNumber)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ContractNumber");

			Property(i => i.Revision)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Revision");

			Property(i => i.RevNumber)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RevNumber");

			Property(i => i.RevisionDateFrom)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RevisionDateFrom");

			Property(i => i.IsClosed)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsClosed");

			Property(i => i.DepartmentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DepartmentId");

			Property(i => i.RevisionValidTo)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RevisionValidTo");

			Property(i => i.RevisionDateValidTo)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RevisionDateValidTo");

			Property(i => i.RevisionNotify)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("RevisionNotify");

			Property(i => i.Aboard)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Aboard");

			Property(i => i.Privy)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Privy");

			Property(i => i.IssueNumber)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IssueNumber");

			Property(i => i.NomenсlatureId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("NomenсlatureId");

			Property(i => i.ProlongationWayId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ProlongationWayId");

			Property(i => i.ServiceTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ServiceTypeId");

			Property(i => i.ResponsibleOccupationId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ResponsibleOccupationId");

			Property(i => i.Remarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.LocationId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LocationId");

			Property(i => i.SupplierId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SupplierId");

			Property(i => i.ParentAircraftId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentAircraftId");

            Property(i => i.IdNumber)
                .HasMaxLength(128)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnName("IdNumber");

            HasRequired(i => i.DocumentSubType)
				.WithMany(i => i.DocumentDtos)
				.HasForeignKey(i => i.SubTypeId);

			HasRequired(i => i.Supplier)
				.WithMany(i => i.DocumentDtos)
				.HasForeignKey(i => i.SupplierId);

			HasRequired(i => i.ResponsibleOccupation)
				.WithMany(i => i.DocumentDtos)
				.HasForeignKey(i => i.ResponsibleOccupationId);

			HasRequired(i => i.Nomenсlature)
				.WithMany(i => i.DocumentDtos)
				.HasForeignKey(i => i.NomenсlatureId);

			HasRequired(i => i.ServiceType)
				.WithMany(i => i.DocumentDtos)
				.HasForeignKey(i => i.ServiceTypeId);

			HasRequired(i => i.Department)
				.WithMany(i => i.DocumentDtos)
				.HasForeignKey(i => i.DepartmentId);

			HasRequired(i => i.Location)
				.WithMany(i => i.DocumentDtos)
				.HasForeignKey(i => i.LocationId);

		}
	}
}