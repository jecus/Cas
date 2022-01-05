using CAA.Entity.Core;
using CAA.Entity.Models.Dictionary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.Dictionaries
{
	[Route("department")]
	public class DepartmentController : BaseDictionaryController<CAADepartmentDTO>
	{
        public DepartmentController(DataContext context, ILogger<BaseController<CAADepartmentDTO>> logger) : base(context, logger)
		{
			
		}
    }
}