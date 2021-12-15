using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("kitsuppliersrelation")]
	public class KitSuppliersRelationController : BaseController<KitSuppliersRelationDTO>
	{
		public KitSuppliersRelationController(DataContext context, ILogger<BaseController<KitSuppliersRelationDTO>> logger) : base(context, logger)
		{

		}
	}
}
