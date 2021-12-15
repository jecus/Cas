using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("supplierdocument")]
	public class SupplierDocumentController : BaseController<SupplierDocumentDTO>
	{
		public SupplierDocumentController(DataContext context, ILogger<BaseController<SupplierDocumentDTO>> logger) : base(context, logger)
		{

		}
	}
}

