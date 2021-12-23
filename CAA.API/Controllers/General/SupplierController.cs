using CAA.API.Controllers;
using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("supplier")]
	public class SupplierController : BaseController<CAASupplierDTO>
	{
		public SupplierController(DataContext context, ILogger<BaseController<CAASupplierDTO>> logger) : base(context, logger)
		{

		}
	}
}
