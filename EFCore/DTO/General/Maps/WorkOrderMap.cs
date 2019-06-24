using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class WorkOrderMap : BaseMap<WorkOrderDTO>
	{
		public WorkOrderMap() : base()
		{

			HasRequired(i => i.PreparedBy)
				.WithMany(i => i.PreparedWorkOrderDtos)
				.HasForeignKey(i => i.PreparedById);

			HasRequired(i => i.CheckedBy)
				.WithMany(i => i.CheckedWorkOrderDtos)
				.HasForeignKey(i => i.CheckedById);

			HasRequired(i => i.ApprovedBy)
				.WithMany(i => i.ApprovedWorkOrderDtos)
				.HasForeignKey(i => i.ApprovedById);


			HasMany(i => i.Kits).WithRequired(i => i.WorkOrder).HasForeignKey(i => i.ParentId);

			HasMany(i => i.PackageRecords).WithRequired(i => i.WorkOrder).HasForeignKey(i => i.ParentId);
		}
	}
}