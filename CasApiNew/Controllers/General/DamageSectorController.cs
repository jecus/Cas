using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("damagesector")]
	public class DamageSectorController : BaseController<DamageSectorDTO>
	{
		public DamageSectorController(DataContext context, ILogger<BaseController<DamageSectorDTO>> logger) : base(context, logger)
		{

		}
	}
}

