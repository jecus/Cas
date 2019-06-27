using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("knowledgeModule")]
	public class KnowledgeModuleController : BaseController<KnowledgeModuleDTO>
	{
		public KnowledgeModuleController(DataContext context, ILogger<BaseController<KnowledgeModuleDTO>> logger) : base(context, logger)
		{

		}
	}
}

