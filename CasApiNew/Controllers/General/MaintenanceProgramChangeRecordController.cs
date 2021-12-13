using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("maintenanceprogramchangerecord")]
	public class MaintenanceProgramChangeRecordController : BaseController<MaintenanceProgramChangeRecordDTO>
	{
		public MaintenanceProgramChangeRecordController(DataContext context, ILogger<BaseController<MaintenanceProgramChangeRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
