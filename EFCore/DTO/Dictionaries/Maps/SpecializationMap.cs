using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class SpecializationMap : BaseMap<SpecializationDTO>
	{
		public SpecializationMap() : base()
		{
			
			#region relation

			HasRequired(i => i.Department)
				.WithMany(i => i.SpecializationDtos)
				.HasForeignKey(i => i.DepartmentId);

			#endregion
		}
	}
}