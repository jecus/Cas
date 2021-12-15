using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("specialistlicenserating")]
	public class SpecialistLicenseRatingController : BaseController<SpecialistLicenseRatingDTO>
	{
		public SpecialistLicenseRatingController(DataContext context, ILogger<BaseController<SpecialistLicenseRatingDTO>> logger) : base(context, logger)
		{

		}
	}
}

