using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class ATLBMap : BaseMap<ATLBDTO>
	{
		public ATLBMap() : base()
		{
			
			HasMany(i => i.Files).WithRequired(i => i.Atlb).HasForeignKey(i => i.ParentId);
		}
	}
}