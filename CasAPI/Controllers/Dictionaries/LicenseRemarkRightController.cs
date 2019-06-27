using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("licenseRemarkRight")]
	public class LicenseRemarkRightController : BaseController<LicenseRemarkRightDTO>
	{
		public LicenseRemarkRightController(DataContext context, ILogger<BaseController<LicenseRemarkRightDTO>> logger) : base(context, logger)
		{
			
		}
	}
}