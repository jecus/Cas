using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("coursepackage")]
	public class CoursePackageController : BaseController<CoursePackageDTO>
	{
		public CoursePackageController(DataContext context, ILogger<BaseController<CoursePackageDTO>> logger) : base(context, logger)
		{
		}
	}
}