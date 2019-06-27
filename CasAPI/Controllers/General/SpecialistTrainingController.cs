using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("specialistTraining")]
	public class SpecialistTrainingController : BaseController<SpecialistTrainingDTO>
	{
		public SpecialistTrainingController(DataContext context, ILogger<BaseController<SpecialistTrainingDTO>> logger) : base(context, logger)
		{

		}
	}
}
