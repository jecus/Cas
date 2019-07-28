using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("damagesector")]
	public class DamageSectorController : BaseController<DamageSectorDTO>
	{
		public DamageSectorController(DataContext context, ILogger<BaseController<DamageSectorDTO>> logger) : base(context, logger)
		{

		}
	}
}

