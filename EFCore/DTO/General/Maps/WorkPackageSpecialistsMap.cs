using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class WorkPackageSpecialistsMap : BaseMap<WorkPackageSpecialistsDTO>
	{
		public WorkPackageSpecialistsMap() : base()
		{
			ToTable("dbo.WorkPackageSpecialists");

			Property(i => i.WorkPackageId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("WorkPackageId");

			Property(i => i.SpecialistId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SpecialistId");
		}
	}
}