using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("initialorderrecord")]
	public class InitialOrderRecordController : BaseController<InitialOrderRecordDTO>
	{
		public InitialOrderRecordController(DataContext context, ILogger<BaseController<InitialOrderRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
