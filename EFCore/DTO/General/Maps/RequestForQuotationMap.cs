using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class RequestForQuotationMap : BaseMap<RequestForQuotationDTO>
	{
		public RequestForQuotationMap() : base()
		{
			HasMany(i => i.Files).WithRequired(i => i.RequestForQuotation).HasForeignKey(i => i.ParentId);
			HasMany(i => i.PackageRecords).WithRequired(i => i.RequestForQuotationDto).HasForeignKey(i => i.ParentPackageId);

		}
	}
}