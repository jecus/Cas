using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("department")]
	public class DepartmentController : BaseController<DepartmentDTO>
	{
		public DepartmentController(DataContext context, ILogger<BaseController<DepartmentDTO>> logger) : base(context, logger)
		{
			
		}
	}
}