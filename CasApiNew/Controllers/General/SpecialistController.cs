using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("specialist")]
	public class SpecialistController : BaseController<SpecialistDTO>
	{
		public SpecialistController(DataContext context, ILogger<BaseController<SpecialistDTO>> logger) : base(context, logger)
		{

		}
	}
}

