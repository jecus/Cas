using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("componentllpcategorychangerecord")]
	public class ComponentLLPCategoryChangeRecordController : BaseController<ComponentLLPCategoryChangeRecordDTO>
	{
		public ComponentLLPCategoryChangeRecordController(DataContext context, ILogger<BaseController<ComponentLLPCategoryChangeRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}

