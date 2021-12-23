using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("specialistlicense")]
	public class SpecialistLicenseController : BaseController<SpecialistLicenseDTO>
	{
		public SpecialistLicenseController(DataContext context, ILogger<BaseController<SpecialistLicenseDTO>> logger) : base(context, logger)
		{

		}
	}
}
