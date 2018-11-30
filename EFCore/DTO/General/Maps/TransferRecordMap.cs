using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFCore.DTO.General.Maps
{
	public class TransferRecordMap : EntityTypeConfiguration<TransferRecordDTO>
	{
		public TransferRecordMap()
		{
			ToTable("dbo.TransferRecords");

			HasKey(i => i.ItemId);
			Property(i => i.ItemId)
				.HasColumnName("ItemId");

			Property(i => i.IsDeleted)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDeleted");

			Property(i => i.ParentID)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentID");

			Property(i => i.ParentType)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentType");

			Property(i => i.FromAircraftID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FromAircraftID");

			Property(i => i.FromStoreID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FromStoreID");

			Property(i => i.DestinationObjectID)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DestinationObjectID");

			Property(i => i.DestinationObjectType)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DestinationObjectType");

			Property(i => i.ConsumableId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ConsumableId");

			Property(i => i.TransferDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TransferDate");

			Property(i => i.DestConfirmTransferDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DestConfirmTransferDate");

			Property(i => i.WorkPackageID)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("WorkPackageID");

			Property(i => i.PerformanceNum)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PerformanceNum");

			Property(i => i.Remarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.Reference)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Reference");

			Property(i => i.PODR)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PODR");

			Property(i => i.PreConfirmTransfer)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PreConfirmTransfer");

			Property(i => i.DODR)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DODR");

			Property(i => i.Position)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Position");

			Property(i => i.FromBaseComponentID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FromBaseComponentID");

			Property(i => i.Description)
				.HasMaxLength(250)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Description");

			Property(i => i.ReasonId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ReasonId");

			Property(i => i.State)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("State");

			Property(i => i.ReplaceComponentId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ReplaceComponentId");

			Property(i => i.IsReplaceComponentRemoved)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsReplaceComponentRemoved");

			Property(i => i.ReceivedSpecialistId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ReceivedSpecialistId");

			Property(i => i.ReleasedSpecialistId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ReleasedSpecialistId");

			Property(i => i.FromSupplierId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FromSupplierId");

			Property(i => i.SupplierReceiptDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SupplierReceiptDate");

			Property(i => i.SupplierNotify)
				.HasMaxLength(21)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SupplierNotify");

			Property(i => i.FromSpecialistId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FromSpecialistId");

			HasRequired(i => i.ReceivedSpecialist)
				.WithMany(i => i.RecivedSpecialist)
				.HasForeignKey(i => i.ReceivedSpecialistId);

			HasRequired(i => i.ReleasedSpecialist)
				.WithMany(i => i.ReleasedSpecialist)
				.HasForeignKey(i => i.ReleasedSpecialistId);


			HasMany(i => i.Files).WithRequired(i => i.TransferRecord).HasForeignKey(i => i.ParentId);
		}
	}
}