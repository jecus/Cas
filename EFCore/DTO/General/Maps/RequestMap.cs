using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class RequestMap : BaseMap<RequestDTO>
	{
		public RequestMap() : base()
		{
			HasRequired(i => i.PreparedBy)
				.WithMany(i => i.PreparedByRequestDtos)
				.HasForeignKey(i => i.PreparedById);

			HasRequired(i => i.CheckedBy)
				.WithMany(i => i.CheckedByRequestDtos)
				.HasForeignKey(i => i.CheckedById);

			HasRequired(i => i.ApprovedBy)
				.WithMany(i => i.ApprovedByRequestDtos)
				.HasForeignKey(i => i.ApprovedById);

			HasMany(i => i.Kits).WithRequired(i => i.RequestDto).HasForeignKey(i => i.ParentId);
			HasMany(i => i.PackageRecords).WithRequired(i => i.RequestDto).HasForeignKey(i => i.ParentId);

		}
	}
}