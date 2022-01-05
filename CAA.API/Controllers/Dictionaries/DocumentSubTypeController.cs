using CAA.Entity.Core;
using CAA.Entity.Models.Dictionary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.Dictionaries
{
	[Route("documentsubtype")]
	public class DocumentSubTypeController : BaseDictionaryController<CAADocumentSubTypeDTO>
	{
        public DocumentSubTypeController(DataContext context, ILogger<BaseController<CAADocumentSubTypeDTO>> logger) : base(context, logger)
		{
			
		}
    }
}