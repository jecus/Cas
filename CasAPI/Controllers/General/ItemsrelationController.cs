using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("itemsrelation")]
	public class ItemsrelationController : BaseController<ItemsRelationDTO>
	{
		public ItemsrelationController(DataContext context, ILogger<BaseController<ItemsRelationDTO>> logger) : base(context, logger)
		{
		}
	}
}