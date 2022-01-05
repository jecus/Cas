using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("documentsubtype")]
	public class DocumentSubTypeController : BaseDictionaryController<DocumentSubTypeDTO>
	{
        public DocumentSubTypeController(DataContext context, ILogger<BaseController<DocumentSubTypeDTO>> logger) : base(context, logger)
		{
			
		}
    }
}