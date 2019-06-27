using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("kitSuppliersRelation")]
	public class KitSuppliersRelationController : BaseController<KitSuppliersRelationDTO>
	{
		public KitSuppliersRelationController(DataContext context, ILogger<BaseController<KitSuppliersRelationDTO>> logger) : base(context, logger)
		{

		}
	}
}
