using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("maintenanceprogramchangerecord")]
	public class MaintenanceProgramChangeRecordController : BaseController<MaintenanceProgramChangeRecordDTO>
	{
		public MaintenanceProgramChangeRecordController(DataContext context, ILogger<BaseController<MaintenanceProgramChangeRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
