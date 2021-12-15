using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("transferrecord")]
	public class TransferRecordController : BaseController<TransferRecordDTO>
	{
		public TransferRecordController(DataContext context, ILogger<BaseController<TransferRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}

