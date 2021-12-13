using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("specialistlicenserating")]
	public class SpecialistLicenseRatingController : BaseController<SpecialistLicenseRatingDTO>
	{
		public SpecialistLicenseRatingController(DataContext context, ILogger<BaseController<SpecialistLicenseRatingDTO>> logger) : base(context, logger)
		{

		}
	}
}

