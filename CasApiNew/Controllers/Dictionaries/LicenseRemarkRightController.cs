using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("licenseremarkright")]
	public class LicenseRemarkRightController : BaseDictionaryController<LicenseRemarkRightDTO>
	{

        public LicenseRemarkRightController(DataContext context, ILogger<BaseController<LicenseRemarkRightDTO>> logger) : base(context, logger)
		{
			
		}
    }
}