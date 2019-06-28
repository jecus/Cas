using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("attachedfile")]
	public class AttachedFileController : BaseController<AttachedFileDTO>
	{
		public AttachedFileController(DataContext context, ILogger<BaseController<AttachedFileDTO>> logger) : base(context, logger)
		{

		}
	}
}
