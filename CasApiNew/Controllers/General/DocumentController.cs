using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("document")]
	public class DocumentController : BaseController<DocumentDTO>
	{
		public DocumentController(DataContext context, ILogger<BaseController<DocumentDTO>> logger) : base(context, logger)
		{

		}
	}
}
