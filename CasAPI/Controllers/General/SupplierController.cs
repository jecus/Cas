using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("supplier")]
	public class SupplierController : BaseController<SupplierDTO>
	{
		public SupplierController(DataContext context, ILogger<BaseController<SupplierDTO>> logger) : base(context, logger)
		{

		}
	}
}
