using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("supplierdocument")]
	public class SupplierDocumentController : BaseController<SupplierDocumentDTO>
	{
		public SupplierDocumentController(DataContext context, ILogger<BaseController<SupplierDocumentDTO>> logger) : base(context, logger)
		{

		}
	}
}

