using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("purchaserequestrecord")]
	public class PurchaseRequestRecordController : BaseController<PurchaseRequestRecordDTO>
	{
		public PurchaseRequestRecordController(DataContext context, ILogger<BaseController<PurchaseRequestRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
