using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("itemfilelink")]
	public class ItemFileLinkController : BaseController<CAAItemFileLinkDTO>
	{
		public ItemFileLinkController(DataContext context, ILogger<BaseController<CAAItemFileLinkDTO>> logger) : base(context, logger)
		{
		}
	}
}
