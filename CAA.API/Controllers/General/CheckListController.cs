using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("checklist")]
	public class CheckListController : BaseController<CheckListDTO>
	{
		public CheckListController(DataContext context, ILogger<BaseController<CheckListDTO>> logger) : base(context, logger)
		{
		}
	}
}