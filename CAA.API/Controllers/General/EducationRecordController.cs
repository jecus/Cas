using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("educationrecords")]
	public class EducationRecordController : BaseController<EducationRecordsDTO>
	{

        public EducationRecordController(DataContext context, ILogger<BaseController<EducationRecordsDTO>> logger) : base(context, logger)
		{
			
		}
    }
}