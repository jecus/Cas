using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("specialistLicense")]
	public class SpecialistLicenseController : BaseController<SpecialistLicenseDTO>
	{
		public SpecialistLicenseController(DataContext context, ILogger<BaseController<SpecialistLicenseDTO>> logger) : base(context, logger)
		{

		}
	}
}
