using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("specialist")]
	public class SpecialistController : BaseController<SpecialistDTO>
	{
		public SpecialistController(DataContext context, ILogger<BaseController<SpecialistDTO>> logger) : base(context, logger)
		{

		}
	}
}

