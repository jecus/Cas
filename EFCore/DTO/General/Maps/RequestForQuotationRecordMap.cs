using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.DTO.General.Maps
{
	public class RequestForQuotationRecordMap : BaseMap<RequestForQuotationRecordDTO>
	{
		public RequestForQuotationRecordMap() : base()
		{
			 HasRequired(i => i.DefferedCategory)
				.WithMany(i => i.RequestForQuotationRecordDtos)
				.HasForeignKey(i => i.DefferedCategoryId);
		}
	}
}