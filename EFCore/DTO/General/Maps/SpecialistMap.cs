using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class SpecialistMap : BaseMap<SpecialistDTO>
	{
		public SpecialistMap() : base()
		{
			HasRequired(i => i.AGWCategory)
				.WithMany(i => i.SpecialistDtos)
				.HasForeignKey(i => i.AGWCategoryId);

			HasRequired(i => i.Facility)
				.WithMany(i => i.SpecialistDtos)
				.HasForeignKey(i => i.Location);

			HasRequired(i => i.Specialization)
				.WithMany(i => i.SpecialistDtos)
				.HasForeignKey(i => i.SpecializationID);


			HasMany(i => i.Licenses).WithRequired(i => i.SpecialistDto).HasForeignKey(i => i.SpecialistId);
			HasMany(i => i.SpecialistTrainings).WithRequired(i => i.SpecialistDto).HasForeignKey(i => i.SpecialistId);
			HasMany(i => i.LicenseDetails).WithRequired(i => i.SpecialistDto).HasForeignKey(i => i.SpecialistId);
			HasMany(i => i.LicenseRemark).WithRequired(i => i.SpecialistDto).HasForeignKey(i => i.SpecialistId);
			HasMany(i => i.EmployeeDocuments).WithRequired(i => i.SpecialistDto).HasForeignKey(i => i.ParentID);
			HasMany(i => i.CategoriesRecords).WithRequired(i => i.SpecialistDto).HasForeignKey(i => i.ParentId);
			HasMany(i => i.Files).WithRequired(i => i.SpecialistDto).HasForeignKey(i => i.ParentId);
		}
	}
}