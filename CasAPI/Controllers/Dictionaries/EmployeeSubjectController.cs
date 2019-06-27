using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("employee")]
	public class EmployeeSubjectController : BaseController<EmployeeSubjectDTO>
	{
		public EmployeeSubjectController(DataContext context, ILogger<BaseController<EmployeeSubjectDTO>> logger) : base(context, logger)
		{
			
		}
	}
}