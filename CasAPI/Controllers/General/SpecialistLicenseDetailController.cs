using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("specialistLicenseDetail")]
	public class SpecialistLicenseDetailController : BaseController<SpecialistLicenseDetailDTO>
	{
		public SpecialistLicenseDetailController(DataContext context, ILogger<BaseController<SpecialistLicenseDetailDTO>> logger) : base(context, logger)
		{

		}
	}
}
