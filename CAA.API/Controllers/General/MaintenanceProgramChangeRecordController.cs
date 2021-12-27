using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("maintenanceprogramchangerecord")]
	public class MaintenanceProgramChangeRecordController : BaseController<CAAMaintenanceProgramChangeRecordDTO>
	{
		public MaintenanceProgramChangeRecordController(DataContext context, ILogger<BaseController<CAAMaintenanceProgramChangeRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
