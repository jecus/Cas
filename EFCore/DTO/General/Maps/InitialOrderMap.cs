using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class InitialOrderMap : BaseMap<InitialOrderDTO>
	{
		public InitialOrderMap() : base()
		{
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