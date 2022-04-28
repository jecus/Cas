using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("courserecord")]
	public class CourseRecordController : BaseController<CourseRecordDTO>
	{
		public CourseRecordController(DataContext context, ILogger<BaseController<CourseRecordDTO>> logger) : base(context, logger)
		{
		}
	}
}