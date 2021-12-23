using CAA.API.Controllers;
using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("specialistlicensedetail")]
	public class SpecialistLicenseDetailController : BaseController<CAASpecialistLicenseDetailDTO>
	{
		public SpecialistLicenseDetailController(DataContext context, ILogger<BaseController<CAASpecialistLicenseDetailDTO>> logger) : base(context, logger)
		{

		}
	}
}
