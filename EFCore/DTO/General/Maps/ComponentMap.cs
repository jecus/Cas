using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ComponentMap : BaseMap<ComponentDTO>
	{
		public ComponentMap() : base()
		{
			ToTable("dbo.Components");

			Property(i => i.ATAChapterId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ATAChapter");

			Property(i => i.PartNumber)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PartNumber");

			Property(i => i.Description)
				.HasMaxLength(250)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Description");

			Property(i => i.SerialNumber)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SerialNumber");

			Property(i => i.BatchNumber)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("BatchNumber");

			Property(i => i.IdNumber)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IdNumber");

			Property(i => i.MaintenanceType)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MaintenanceType");

			Property(i => i.Remarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.ModelId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Model");

			Property(i => i.Manufacturer)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Manufacturer");

			Property(i => i.ManufactureDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ManufactureDate");

			Property(i => i.DeliveryDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DeliveryDate");

			Property(i => i.Lifelength)
				.HasMaxLength(21)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Lifelength");

			Property(i => i.LLPMark)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LLPMark");

			Property(i => i.LLPCategories)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LLPCategories");

			Property(i => i.LandingGear)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LandingGear");

			Property(i => i.AvionicsInventory)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AvionicsInventory");

			Property(i => i.ALTPN)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ALTPN");

			Property(i => i.MTOGW)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MTOGW");

			Property(i => i.HushKit)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("HushKit");

			Property(i => i.Cost)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Cost");

			Property(i => i.CostServiceable)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CostServiceable");

			Property(i => i.CostOverhaul)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CostOverhaul");

			Property(i => i.Measure)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Measure");

			Property(i => i.Quantity)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Quantity");

			Property(i => i.ManHours)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ManHours");

			Property(i => i.FaaFormFileID)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FaaFormFileID");

			Property(i => i.Warranty)
				.HasMaxLength(21)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Warranty");

			Property(i => i.WarrantyNotify)
				.HasMaxLength(21)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("WarrantyNotify");

			Property(i => i.Serviceable)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Serviceable");

			Property(i => i.Type)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Type");

			Property(i => i.ShelfLife)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ShelfLife");

			Property(i => i.ExpirationDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ExpirationDate");

			Property(i => i.NotificationDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("NotificationDate");

			Property(i => i.Highlight)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Highlight");

			Property(i => i.MPDItem)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("MPDItem");

			Property(i => i.HiddenRemarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("HiddenRemarks");

			Property(i => i.Supplier)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Supplier");

			Property(i => i.LifeLimit)
				.HasMaxLength(21)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LifeLimit");

			Property(i => i.LifeLimitNotify)
				.HasMaxLength(21)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LifeLimitNotify");

			Property(i => i.KitRequired)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("KitRequired");

			Property(i => i.StartLifelength)
				.HasMaxLength(21)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("StartLifelength");

			Property(i => i.StartDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("StartDate");

			Property(i => i.Code)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Code");

			Property(i => i.Status)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Status");

			Property(i => i.IsBaseComponent)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsBaseComponent");

			Property(i => i.LocationId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LocationId");

			Property(i => i.Incoming)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Incoming");

			Property(i => i.Discrepancy)
				.HasMaxLength(250)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Discrepancy");

			Property(i => i.IsPool)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsPool");

			Property(i => i.IsDangerous)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsDangerous");

			Property(i => i.QuantityInput)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("QuantityInput");

			Property(i => i.FromSupplierId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FromSupplierId");

			Property(i => i.Received)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Received");

			Property(i => i.FromSupplierReciveDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FromSupplierReciveDate");

			Property(i => i.ComponentCount)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ComponentCount");

			Property(i => i.AverageUtilization)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AverageUtilization");

			Property(i => i.Acceleration)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Acceleration");

			Property(i => i.AccelerationAir)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AccelerationAir");

			Property(i => i.JobCardsID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("JobCardsID");


			Property(i => i.EOFileId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EOFileId");

			Property(i => i.OldId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("OldId");

			Property(i => i.Thrust)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Thrust");


			Property(i => i.BaseComponentTypeId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("BaseComponentTypeId");


			Property(i => i.ComponentType)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ComponentType");

			Property(i => i.ComponentLabel)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ComponentLabel");

			Property(i => i.QuantityIn)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("QuantityIn");



			HasRequired(i => i.ATAChapter)
				.WithMany(i => i.ComponentDtos)
				.HasForeignKey(i => i.ATAChapterId);

			HasRequired(i => i.Model)
				.WithMany(i => i.ComponentDtos)
				.HasForeignKey(i => i.ModelId);

			HasRequired(i => i.Location)
				.WithMany(i => i.ComponentDtos)
				.HasForeignKey(i => i.LocationId);

			HasRequired(i => i.FromSupplier)
				.WithMany(i => i.ComponentDtos)
				.HasForeignKey(i => i.FromSupplierId);

			HasMany(i => i.SupplierRelations).WithRequired(i => i.Component).HasForeignKey(i => i.KitId);

			HasMany(i => i.Files).WithRequired(i => i.Component).HasForeignKey(i => i.ParentId);

			HasMany(i => i.LLPData).WithRequired(i => i.Component).HasForeignKey(i => i.ComponentId);

			HasMany(i => i.CategoriesRecords).WithRequired(i => i.Component).HasForeignKey(i => i.ParentId);

			HasMany(i => i.Kits).WithRequired(i => i.Component).HasForeignKey(i => i.ParentId);

			HasMany(i => i.ActualStateRecords).WithRequired(i => i.Component).HasForeignKey(i => i.ComponentId);

			HasMany(i => i.TransferRecords).WithRequired(i => i.Component).HasForeignKey(i => i.ParentID);

			HasMany(i => i.ComponentDirectives).WithRequired(i => i.Component).HasForeignKey(i => i.ComponentId);

			HasMany(i => i.ChangeLLPCategoryRecords).WithRequired(i => i.Component).HasForeignKey(i => i.ParentId);
		}
	}
}