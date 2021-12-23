using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("supplier")]
	public class SupplierController : BaseController<SupplierDTO>
	{
		public SupplierController(DataContext context, ILogger<BaseController<SupplierDTO>> logger) : base(context, logger)
		{

		}
	}
}
