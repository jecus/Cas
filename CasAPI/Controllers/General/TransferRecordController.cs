using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("transferrecord")]
	public class TransferRecordController : BaseController<TransferRecordDTO>
	{
		public TransferRecordController(DataContext context, ILogger<BaseController<TransferRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}

