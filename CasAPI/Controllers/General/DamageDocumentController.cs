using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("damageDocument")]
	public class DamageDocumentController : BaseController<DamageDocumentDTO>
	{
		public DamageDocumentController(DataContext context, ILogger<BaseController<DamageDocumentDTO>> logger) : base(context, logger)
		{

		}
	}
}

