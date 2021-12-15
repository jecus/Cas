using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("purchaserequestrecord")]
	public class PurchaseRequestRecordController : BaseController<PurchaseRequestRecordDTO>
	{
		public PurchaseRequestRecordController(DataContext context, ILogger<BaseController<PurchaseRequestRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
