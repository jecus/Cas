using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("documentsubtype")]
	public class DocumentSubTypeController : BaseController<DocumentSubTypeDTO>
	{
		public DocumentSubTypeController(DataContext context, ILogger<BaseController<DocumentSubTypeDTO>> logger) : base(context, logger)
		{
			
		}
	}
}