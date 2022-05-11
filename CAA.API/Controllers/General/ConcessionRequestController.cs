using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("concessionrequest")]
	public class ConcessionRequestController : BaseController<ConcessionRequestDTO>
	{
		public ConcessionRequestController(DataContext context, ILogger<BaseController<ConcessionRequestDTO>> logger) : base(context, logger)
		{
		}
	}
}