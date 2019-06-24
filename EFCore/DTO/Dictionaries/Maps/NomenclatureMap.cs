using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class NomenclatureMap : BaseMap<NomenclatureDTO>
	{
		public NomenclatureMap() : base()
		{
			#region relation

			HasRequired(i => i.Department)
				.WithMany(i => i.NomenclatureDtos)
				.HasForeignKey(i => i.DepartmentId);

			#endregion
		}
	}
}