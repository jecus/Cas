using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("checklisttransfer")]
	public class CheckListTransferController : BaseController<CheckListTransferDTO>
	{
		public CheckListTransferController(DataContext context, ILogger<BaseController<CheckListTransferDTO>> logger) : base(context, logger)
		{
		}
	}
}