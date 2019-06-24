using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class AuditMap : BaseMap<AuditDTO>
	{
		public AuditMap() : base()
		{
			HasMany(i => i.Files).WithRequired(i => i.Audit).HasForeignKey(i => i.ParentId);
			HasMany(i => i.AuditRecords).WithRequired(i => i.Audit).HasForeignKey(i => i.AuditId);
		}
	}
}