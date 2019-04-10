using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class SpecialistMap : BaseMap<SpecialistDTO>
	{
		public SpecialistMap() : base()
		{
			ToTable("dbo.Specialists");

			Property(i => i.FirstName)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FirstName");

			Property(i => i.ShortName)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ShortName");

			Property(i => i.SpecializationID)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("SpecializationID");

			Property(i => i.LastName)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LastName");

			Property(i => i.Gender)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Gender");

			Property(i => i.AGWCategoryId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("AGWCategory");

			Property(i => i.DateOfBirth)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DateOfBirth");

			Property(i => i.Nationality)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Nationality");

			Property(i => i.Address)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Address");

			Property(i => i.Photo)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Photo");

			Property(i => i.PhoneMobile)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PhoneMobile");

			Property(i => i.Phone)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Phone");

			Property(i => i.Email)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Email");

			Property(i => i.Skype)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Skype");

			Property(i => i.Information)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Information");

			Property(i => i.Education)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Education");

			Property(i => i.Location)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Location");

			Property(i => i.Status)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Status");

			Property(i => i.Position)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Position");

			Property(i => i.Sign)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Sign");

			Property(i => i.FamilyStatus)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FamilyStatus");

			Property(i => i.Citizenship)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Citizenship");

			Property(i => i.PersonnelCategoryId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("PersonnelCategoryId");

			Property(i => i.ClassNumber)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ClassNumber");

			Property(i => i.ClassIssueDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ClassIssueDate");

			Property(i => i.GradeNumber)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("GradeNumber");

			Property(i => i.GradeIssueDate)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("GradeIssueDate");

			Property(i => i.Additional)
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Additional");

			Property(i => i.Combination)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Combination");

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