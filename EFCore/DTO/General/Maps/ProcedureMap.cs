using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ProcedureMap : BaseMap<ProcedureDTO>
	{
		public ProcedureMap() : base()
		{
			HasRequired(i => i.JobCard)
				.WithMany(i => i.Procedure)
				.HasForeignKey(i => i.JobCardId);

			HasMany(i => i.Files).WithRequired(i => i.Procedure).HasForeignKey(i => i.ParentId);
			HasMany(i => i.PerformanceRecords).WithRequired(i => i.Procedure).HasForeignKey(i => i.ParentID);
			HasMany(i => i.DocumentReferences).WithRequired(i => i.ProcedureDto).HasForeignKey(i => i.ProcedureId);
			HasMany(i => i.Kits).WithRequired(i => i.Procedure).HasForeignKey(i => i.ParentId);

		}
	}
}