using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("itemsrelation")]
	public class ItemsrelationController : BaseController<ItemsRelationDTO>
	{
		public ItemsrelationController(DataContext context, ILogger<BaseController<ItemsRelationDTO>> logger) : base(context, logger)
		{
		}
	}
}