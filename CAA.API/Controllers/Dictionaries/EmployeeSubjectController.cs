using CAA.Entity.Core;
using CAA.Entity.Models.Dictionary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.Dictionaries
{
	[Route("employee")]
	public class EmployeeSubjectController : BaseDictionaryController<CAAEmployeeSubjectDTO>
	{
        public EmployeeSubjectController(DataContext context, ILogger<BaseController<CAAEmployeeSubjectDTO>> logger) : base(context, logger)
		{
			
		}

    }
}