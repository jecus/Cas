using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("transferrecord")]
	public class TransferRecordController : BaseController<TransferRecordDTO>
	{
		public TransferRecordController(DataContext context, ILogger<BaseController<TransferRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}

