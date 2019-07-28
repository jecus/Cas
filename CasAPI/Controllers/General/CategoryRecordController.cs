using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("categoryrecord")]
	public class CategoryRecordController : BaseController<CategoryRecordDTO>
	{
		public CategoryRecordController(DataContext context, ILogger<BaseController<CategoryRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}