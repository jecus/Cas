using CAA.API.Controllers;
using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("specialistlicenserating")]
	public class SpecialistLicenseRatingController : BaseController<CAASpecialistLicenseRatingDTO>
	{
		public SpecialistLicenseRatingController(DataContext context, ILogger<BaseController<CAASpecialistLicenseRatingDTO>> logger) : base(context, logger)
		{

		}
	}
}

