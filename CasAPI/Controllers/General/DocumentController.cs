using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("document")]
	public class DocumentController : BaseController<DocumentDTO>
	{
		public DocumentController(DataContext context, ILogger<BaseController<DocumentDTO>> logger) : base(context, logger)
		{

		}
	}
}
