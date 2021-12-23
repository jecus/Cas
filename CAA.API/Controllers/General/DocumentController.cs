using CAA.API.Controllers;
using CAA.Entity.Core;
using CAA.Entity.Models.DTO;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("document")]
	public class DocumentController : BaseController<CAADocumentDTO>
	{
		public DocumentController(DataContext context, ILogger<BaseController<CAADocumentDTO>> logger) : base(context, logger)
		{

		}
	}
}
