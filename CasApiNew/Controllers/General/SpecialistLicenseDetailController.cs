using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("specialistlicensedetail")]
	public class SpecialistLicenseDetailController : BaseController<SpecialistLicenseDetailDTO>
	{
		public SpecialistLicenseDetailController(DataContext context, ILogger<BaseController<SpecialistLicenseDetailDTO>> logger) : base(context, logger)
		{

		}
	}
}
