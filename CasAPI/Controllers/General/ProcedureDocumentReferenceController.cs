using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("proceduredocumentreference")]
	public class ProcedureDocumentReferenceController : BaseController<ProcedureDocumentReferenceDTO>
	{
		public ProcedureDocumentReferenceController(DataContext context, ILogger<BaseController<ProcedureDocumentReferenceDTO>> logger) : base(context, logger)
		{

		}
	}
}

