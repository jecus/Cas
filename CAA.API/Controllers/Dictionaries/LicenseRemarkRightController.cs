using CAA.Entity.Core;
using CAA.Entity.Models.Dictionary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.Dictionaries
{
	[Route("licenseremarkright")]
	public class LicenseRemarkRightController : BaseDictionaryController<CAALicenseRemarkRightDTO>
	{

		public LicenseRemarkRightController(DataContext context, ILogger<BaseController<CAALicenseRemarkRightDTO>> logger) : base(context, logger)
		{
			
		}
    }
}