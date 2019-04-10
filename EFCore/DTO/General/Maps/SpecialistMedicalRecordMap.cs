using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class SpecialistMedicalRecordMap : BaseMap<SpecialistMedicalRecordDTO>
	{
		public SpecialistMedicalRecordMap() : base()
		{
			ToTable("dbo.EmployeeMedicalRecors");

			Property(i => i.ClassId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ClassId");

			Property(i => i.IssueDate)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("IssueDate");

			Property(i => i.Notify)
				.HasMaxLength(21)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Notify");

			Property(i => i.Repeat)
				.HasMaxLength(21)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Repeat");

			Property(i => i.SpecialistId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SpecialistId");

			Property(i => i.Remarks)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Remarks");
		}
	}
}