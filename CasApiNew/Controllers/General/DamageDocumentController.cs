using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("damagedocument")]
	public class DamageDocumentController : BaseController<DamageDocumentDTO>
	{
		public DamageDocumentController(DataContext context, ILogger<BaseController<DamageDocumentDTO>> logger) : base(context, logger)
		{

		}
	}
}

