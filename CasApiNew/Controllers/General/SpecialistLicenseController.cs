using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("specialistlicense")]
	public class SpecialistLicenseController : BaseController<SpecialistLicenseDTO>
	{
		public SpecialistLicenseController(DataContext context, ILogger<BaseController<SpecialistLicenseDTO>> logger) : base(context, logger)
		{

		}
	}
}
