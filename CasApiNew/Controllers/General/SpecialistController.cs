using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("specialist")]
	public class SpecialistController : BaseController<SpecialistDTO>
	{
		public SpecialistController(DataContext context, ILogger<BaseController<SpecialistDTO>> logger) : base(context, logger)
		{

		}
	}
}

