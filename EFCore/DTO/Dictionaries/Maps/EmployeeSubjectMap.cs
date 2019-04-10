using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class EmployeeSubjectMap : BaseMap<EmployeeSubjectDTO>
	{
		public EmployeeSubjectMap() : base()
		{
			ToTable("Dictionaries.EmployeeSubjects");

			Property(i => i.Name)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Name");

			Property(i => i.FullName)
				.IsRequired()
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FullName");

			Property(i => i.LicenceTypeId)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("LicenceTypeId");
		}
	}
}