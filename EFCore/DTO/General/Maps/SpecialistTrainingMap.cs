using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class SpecialistTrainingMap : BaseMap<SpecialistTrainingDTO>
	{
		public SpecialistTrainingMap() : base()
		{
			ToTable("dbo.SpecialistsTraining");

			Property(i => i.SpecialistId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SpecialistId");

			Property(i => i.TrainingId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("TrainingId");

			Property(i => i.SupplierId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SupplierId");

			Property(i => i.ManHours)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ManHours");

			Property(i => i.Cost)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Cost");

			Property(i => i.Remarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");

			Property(i => i.HiddenRemark)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("HiddenRemark");

			Property(i => i.Description)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Description");


			Property(i => i.Threshold)
				.HasMaxLength(200)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Threshold");

			Property(i => i.IsClosed)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IsClosed");

			Property(i => i.AircraftTypeID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AircraftTypeID");

			Property(i => i.EmployeeSubjectID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("EmployeeSubjectID");


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