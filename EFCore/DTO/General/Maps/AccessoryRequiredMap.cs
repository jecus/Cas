using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class AccessoryRequiredMap : BaseMap<AccessoryRequiredDTO>
	{
		public AccessoryRequiredMap() : base()
		{
			ToTable("dbo.Kits");

			Property(i => i.ParentId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentId");

			Property(i => i.ParentTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ParentTypeId");

			Property(i => i.IsNonRoutineKit)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsNonRoutineKit");

			Property(i => i.AircraftModelId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AircraftModelId");

			Property(i => i.PartNumber)
				.HasMaxLength(100)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PartNumber");

			Property(i => i.Description)
				.HasMaxLength(200)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Description");

			Property(i => i.Manufacturer)
				.HasMaxLength(100)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Manufacturer");

			Property(i => i.Measure)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Measure");

			Property(i => i.Quantity)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Quantity");

			Property(i => i.CostNew)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CostNew");

			Property(i => i.CostServiceable)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CostServiceable");

			Property(i => i.CostOverhaul)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("CostOverhaul");

			Property(i => i.Remarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.AccessoryDescriptionId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AccessoryDescriptionId");

			Property(i => i.GoodStandartId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("GoodStandartId");


			HasRequired(i => i.Product)
				.WithMany(i => i.AccessoryRequiredDtos)
				.HasForeignKey(i => i.AccessoryDescriptionId);

			HasRequired(i => i.Standart)
				.WithMany(i => i.AccessoryRequiredDtos)
				.HasForeignKey(i => i.GoodStandartId);

		}
	}
}