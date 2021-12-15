using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("initialorderrecord")]
	public class InitialOrderRecordController : BaseController<InitialOrderRecordDTO>
	{
		public InitialOrderRecordController(DataContext context, ILogger<BaseController<InitialOrderRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
