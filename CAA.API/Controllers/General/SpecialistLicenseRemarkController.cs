using CAA.API.Controllers;
using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("specialistlicenseremark")]
	public class SpecialistLicenseRemarkController : BaseController<CAASpecialistLicenseRemarkDTO>
	{
		public SpecialistLicenseRemarkController(DataContext context, ILogger<BaseController<CAASpecialistLicenseRemarkDTO>> logger) : base(context, logger)
		{

		}
	}
}

