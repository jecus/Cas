using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("department")]
	public class DepartmentController : BaseDictionaryController<DepartmentDTO>
	{
        public DepartmentController(DataContext context, ILogger<BaseController<DepartmentDTO>> logger) : base(context, logger)
		{
			
		}
    }
}