using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("itemfilelink")]
	public class ItemFileLinkController : BaseController<ItemFileLinkDTO>
	{
		public ItemFileLinkController(DataContext context, ILogger<BaseController<ItemFileLinkDTO>> logger) : base(context, logger)
		{
		}
	}
}
