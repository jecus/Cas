using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class DirectiveRecordMap : BaseMap<DirectiveRecordDTO>
	{
		public DirectiveRecordMap() : base()
		{
			HasMany(i => i.Files).WithRequired(i => i.DirectiveRecord).HasForeignKey(i => i.ParentId);
			HasMany(i => i.FilesForMaintenanceCheckRecord).WithRequired(i => i.MaintenanceCheckRecord).HasForeignKey(i => i.ParentId);
		}
	}
}