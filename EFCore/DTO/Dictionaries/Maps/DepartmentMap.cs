using System.ComponentModel.DataAnnotations.Schema;
using EFCore.DTO.Dictionaries;

namespace EFCore.DTO.Maps
{
	public class DepartmentMap : BaseMap<DepartmentDTO>
	{
		public DepartmentMap() : base()
		{
			
		}
	}
}