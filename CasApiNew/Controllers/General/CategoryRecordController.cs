using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("categoryrecord")]
	public class CategoryRecordController : BaseController<CategoryRecordDTO>
	{
		public CategoryRecordController(DataContext context, ILogger<BaseController<CategoryRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}