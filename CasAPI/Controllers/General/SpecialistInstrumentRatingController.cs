using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("specialistInstrumentRating")]
	public class SpecialistInstrumentRatingController : BaseController<SpecialistInstrumentRatingDTO>
	{
		public SpecialistInstrumentRatingController(DataContext context, ILogger<BaseController<SpecialistInstrumentRatingDTO>> logger) : base(context, logger)
		{

		}
	}
}
