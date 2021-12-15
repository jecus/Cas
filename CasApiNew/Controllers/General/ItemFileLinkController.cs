using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("itemfilelink")]
	public class ItemFileLinkController : BaseController<ItemFileLinkDTO>
	{
		public ItemFileLinkController(DataContext context, ILogger<BaseController<ItemFileLinkDTO>> logger) : base(context, logger)
		{
		}
	}
}
