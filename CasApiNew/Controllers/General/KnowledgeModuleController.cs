using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("knowledgemodule")]
	public class KnowledgeModuleController : BaseController<KnowledgeModuleDTO>
	{
		public KnowledgeModuleController(DataContext context, ILogger<BaseController<KnowledgeModuleDTO>> logger) : base(context, logger)
		{

		}
	}
}

