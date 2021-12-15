using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("damagedocument")]
	public class DamageDocumentController : BaseController<DamageDocumentDTO>
	{
		public DamageDocumentController(DataContext context, ILogger<BaseController<DamageDocumentDTO>> logger) : base(context, logger)
		{

		}
	}
}

