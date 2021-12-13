using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("itemfilelink")]
	public class ItemFileLinkController : BaseController<ItemFileLinkDTO>
	{
		public ItemFileLinkController(DataContext context, ILogger<BaseController<ItemFileLinkDTO>> logger) : base(context, logger)
		{
		}
	}
}
