using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("specialistinstrumentrating")]
	public class SpecialistInstrumentRatingController : BaseController<SpecialistInstrumentRatingDTO>
	{
		public SpecialistInstrumentRatingController(DataContext context, ILogger<BaseController<SpecialistInstrumentRatingDTO>> logger) : base(context, logger)
		{

		}
	}
}
