using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("productcost")]
	public class ProductCostController : BaseController<ProductCostDTO>
	{
		public ProductCostController(DataContext context, ILogger<BaseController<ProductCostDTO>> logger) : base(context, logger)
		{

		}
	}
}
