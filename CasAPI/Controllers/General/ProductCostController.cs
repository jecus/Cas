using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("productCost")]
	public class ProductCostController : BaseController<ProductCostDTO>
	{
		public ProductCostController(DataContext context, ILogger<BaseController<ProductCostDTO>> logger) : base(context, logger)
		{

		}
	}
}
