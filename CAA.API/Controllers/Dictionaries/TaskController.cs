using CAA.Entity.Core;
using CAA.Entity.Models.Dictionary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.Dictionaries
{
	[Route("task")]
	public class TaskController : BaseDictionaryController<TaskDTO>
	{

        public TaskController(DataContext context, ILogger<BaseController<TaskDTO>> logger) : base(context, logger)
		{
			
		}
    }
}