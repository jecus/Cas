using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("specialistlicenseremark")]
	public class SpecialistLicenseRemarkController : BaseController<SpecialistLicenseRemarkDTO>
	{
		public SpecialistLicenseRemarkController(DataContext context, ILogger<BaseController<SpecialistLicenseRemarkDTO>> logger) : base(context, logger)
		{

		}
	}
}

