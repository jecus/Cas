using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("actualStateRecord")]
	public class ActualStateRecordController : BaseController<ActualStateRecordDTO>
	{
		public ActualStateRecordController(DataContext context, ILogger<BaseController<ActualStateRecordDTO>> logger) : base(context, logger)
		{
			
		}
	}
}