using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("quotationcost")]
	public class QuotationCostController : BaseController<QuotationCostDTO>
	{
		public QuotationCostController(DataContext context, ILogger<BaseController<QuotationCostDTO>> logger) : base(context, logger)
		{

		}
	}
}

