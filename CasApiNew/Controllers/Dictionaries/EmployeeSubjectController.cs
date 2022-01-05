using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("employee")]
	public class EmployeeSubjectController : BaseDictionaryController<EmployeeSubjectDTO>
	{
        public EmployeeSubjectController(DataContext context, ILogger<BaseController<EmployeeSubjectDTO>> logger) : base(context, logger)
		{
			
		}
    }
}