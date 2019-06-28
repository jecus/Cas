using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("quotationcost")]
	public class QuotationCostController : BaseController<QuotationCostDTO>
	{
		public QuotationCostController(DataContext context, ILogger<BaseController<QuotationCostDTO>> logger) : base(context, logger)
		{

		}
	}
}

