using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class NomenclatureMap : BaseMap<NomenclatureDTO>
	{
		public NomenclatureMap() : base()
		{
			ToTable("Dictionaries.Nomenclatures");

			Property(i => i.DepartmentId)
				.IsRequired()
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("DepartmentId");

			Property(i => i.Name)
				.HasMaxLength(50)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("Name");

			Property(i => i.FullName)
				.IsRequired()
				.HasMaxLength(256)
				.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
				.HasColumnName("FullName");

			#region relation

			HasRequired(i => i.Department)
				.WithMany(i => i.NomenclatureDtos)
				.HasForeignKey(i => i.DepartmentId);

			#endregion
		}
	}
}