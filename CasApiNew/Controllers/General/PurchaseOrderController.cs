using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("purchaseorder")]
	public class PurchaseOrderController : BaseController<PurchaseOrderDTO>
	{
		public PurchaseOrderController(DataContext context, ILogger<BaseController<PurchaseOrderDTO>> logger) : base(context, logger)
		{

		}
	}
}
