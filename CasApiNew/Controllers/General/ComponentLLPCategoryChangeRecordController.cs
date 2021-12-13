
using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("componentllpcategorychangerecord")]
	public class ComponentLLPCategoryChangeRecordController : BaseController<ComponentLLPCategoryChangeRecordDTO>
	{
		public ComponentLLPCategoryChangeRecordController(DataContext context, ILogger<BaseController<ComponentLLPCategoryChangeRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}

