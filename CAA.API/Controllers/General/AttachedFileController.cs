using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("attachedfile")]
	public class AttachedFileController : BaseController<CAAAttachedFileDTO>
	{
		public AttachedFileController(DataContext context, ILogger<BaseController<CAAAttachedFileDTO>> logger) : base(context, logger)
		{

		}
	}
}
