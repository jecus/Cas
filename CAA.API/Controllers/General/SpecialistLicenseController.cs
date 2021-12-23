using CAA.API.Controllers;
using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("specialistlicense")]
	public class SpecialistLicenseController : BaseController<CAASpecialistLicenseDTO>
	{
		public SpecialistLicenseController(DataContext context, ILogger<BaseController<CAASpecialistLicenseDTO>> logger) : base(context, logger)
		{

		}
	}
}
