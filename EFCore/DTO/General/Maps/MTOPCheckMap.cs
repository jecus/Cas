using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class MTOPCheckMap : BaseMap<MTOPCheckDTO>
	{
		public MTOPCheckMap() : base()
		{
			HasRequired(i => i.CheckType)
				.WithMany(i => i.MtopCheckDtos)
				.HasForeignKey(i => i.CheckTypeId);

			HasMany(i => i.PerformanceRecords).WithRequired(i => i.MtopCheckDto).HasForeignKey(i => i.ParentId);

		}
	}
}