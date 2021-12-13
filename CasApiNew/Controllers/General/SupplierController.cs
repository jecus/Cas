using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("supplier")]
	public class SupplierController : BaseController<SupplierDTO>
	{
		public SupplierController(DataContext context, ILogger<BaseController<SupplierDTO>> logger) : base(context, logger)
		{

		}
	}
}
