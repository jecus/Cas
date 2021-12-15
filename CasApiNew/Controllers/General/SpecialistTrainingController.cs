using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("specialisttraining")]
	public class SpecialistTrainingController : BaseController<SpecialistTrainingDTO>
	{
		public SpecialistTrainingController(DataContext context, ILogger<BaseController<SpecialistTrainingDTO>> logger) : base(context, logger)
		{

		}
	}
}
