using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("categoryRecord")]
	public class CategoryRecordController : BaseController<CategoryRecordDTO>
	{
		public CategoryRecordController(DataContext context, ILogger<BaseController<CategoryRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}