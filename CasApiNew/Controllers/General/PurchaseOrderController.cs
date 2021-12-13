using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("purchaseorder")]
	public class PurchaseOrderController : BaseController<PurchaseOrderDTO>
	{
		public PurchaseOrderController(DataContext context, ILogger<BaseController<PurchaseOrderDTO>> logger) : base(context, logger)
		{

		}
	}
}
