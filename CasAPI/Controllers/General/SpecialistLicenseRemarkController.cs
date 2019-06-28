using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("specialistlicenseremark")]
	public class SpecialistLicenseRemarkController : BaseController<SpecialistLicenseRemarkDTO>
	{
		public SpecialistLicenseRemarkController(DataContext context, ILogger<BaseController<SpecialistLicenseRemarkDTO>> logger) : base(context, logger)
		{

		}
	}
}

