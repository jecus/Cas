using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("specialisttraining")]
	public class SpecialistTrainingController : BaseController<SpecialistTrainingDTO>
	{
		public SpecialistTrainingController(DataContext context, ILogger<BaseController<SpecialistTrainingDTO>> logger) : base(context, logger)
		{

		}
	}
}
