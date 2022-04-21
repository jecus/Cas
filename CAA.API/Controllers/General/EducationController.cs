using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("education")]
	public class EducationController : BaseController<EducationDTO>
	{

        public EducationController(DataContext context, ILogger<BaseController<EducationDTO>> logger) : base(context, logger)
		{
			
		}
    }
}