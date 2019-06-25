using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class SpecialistTrainingMap : BaseMap<SpecialistTrainingDTO>
	{
		public SpecialistTrainingMap() : base()
		{
			HasRequired(i => i.AircraftType)
				.WithMany(i => i.SpecialistTrainingDtos)
				.HasForeignKey(i => i.AircraftTypeID);

			HasRequired(i => i.EmployeeSubject)
				.WithMany(i => i.SpecialistTrainingDtos)
				.HasForeignKey(i => i.EmployeeSubjectID);

			HasRequired(i => i.Supplier)
				.WithMany(i => i.SpecialistTrainingDtos)
				.HasForeignKey(i => i.SupplierId);

			HasMany(i => i.Files).WithRequired(i => i.SpecialistTraining).HasForeignKey(i => i.ParentId);
		}
	}
}