using CAA.API.Controllers;
using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("specialistinstrumentrating")]
	public class SpecialistInstrumentRatingController : BaseController<CAASpecialistInstrumentRatingDTO>
	{
		public SpecialistInstrumentRatingController(DataContext context, ILogger<BaseController<CAASpecialistInstrumentRatingDTO>> logger) : base(context, logger)
		{

		}
	}
}
