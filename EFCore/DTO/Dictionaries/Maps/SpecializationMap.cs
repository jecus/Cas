using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class SpecializationMap : BaseMap<SpecializationDTO>
	{
		public SpecializationMap() : base()
		{
			ToTable("Dictionaries.Specializations");

			Property(i => i.FullName)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FullName");

			Property(i => i.ShortName)
				.HasMaxLength(128)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("ShortName");

			Property(i => i.DepartmentId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DepartmentId");

			Property(i => i.Level)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Level");

			Property(i => i.KeyPersonel)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("KeyPersonel");


			#region relation

			HasRequired(i => i.Department)
				.WithMany(i => i.SpecializationDtos)
				.HasForeignKey(i => i.DepartmentId);

			#endregion
		}
	}
}