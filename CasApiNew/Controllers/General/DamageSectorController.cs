using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("damagesector")]
	public class DamageSectorController : BaseController<DamageSectorDTO>
	{
		public DamageSectorController(DataContext context, ILogger<BaseController<DamageSectorDTO>> logger) : base(context, logger)
		{

		}
	}
}

