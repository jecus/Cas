using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class WorkPackageMap : BaseMap<WorkPackageDTO>
	{
		public WorkPackageMap() : base()
		{
			HasMany(i => i.Files).WithRequired(i => i.WorkPackage).HasForeignKey(i => i.ParentId);
		} 
	}
}