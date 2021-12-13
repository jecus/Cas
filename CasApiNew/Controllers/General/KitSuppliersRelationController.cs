using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("kitsuppliersrelation")]
	public class KitSuppliersRelationController : BaseController<KitSuppliersRelationDTO>
	{
		public KitSuppliersRelationController(DataContext context, ILogger<BaseController<KitSuppliersRelationDTO>> logger) : base(context, logger)
		{

		}
	}
}
