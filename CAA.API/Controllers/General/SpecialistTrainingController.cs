using CAA.API.Controllers;
using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("specialisttraining")]
	public class SpecialistTrainingController : BaseController<CAASpecialistTrainingDTO>
	{
		public SpecialistTrainingController(DataContext context, ILogger<BaseController<CAASpecialistTrainingDTO>> logger) : base(context, logger)
		{

		}
	}
}
