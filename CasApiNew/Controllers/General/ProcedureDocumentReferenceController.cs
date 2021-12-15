using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("proceduredocumentreference")]
	public class ProcedureDocumentReferenceController : BaseController<ProcedureDocumentReferenceDTO>
	{
		public ProcedureDocumentReferenceController(DataContext context, ILogger<BaseController<ProcedureDocumentReferenceDTO>> logger) : base(context, logger)
		{

		}
	}
}

