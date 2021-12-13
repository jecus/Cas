
using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("categoryrecord")]
	public class CategoryRecordController : BaseController<CategoryRecordDTO>
	{
		public CategoryRecordController(DataContext context, ILogger<BaseController<CategoryRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}