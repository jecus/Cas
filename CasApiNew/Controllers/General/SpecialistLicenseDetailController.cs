using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("specialistlicensedetail")]
	public class SpecialistLicenseDetailController : BaseController<SpecialistLicenseDetailDTO>
	{
		public SpecialistLicenseDetailController(DataContext context, ILogger<BaseController<SpecialistLicenseDetailDTO>> logger) : base(context, logger)
		{

		}
	}
}
