using CAA.API.Controllers;
using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("specialist")]
	public class SpecialistController : BaseController<CAASpecialistDTO>
	{
		public SpecialistController(DataContext context, ILogger<BaseController<CAASpecialistDTO>> logger) : base(context, logger)
		{

		}
	}
}

