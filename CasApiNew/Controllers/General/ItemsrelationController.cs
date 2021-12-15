using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("itemsrelation")]
	public class ItemsrelationController : BaseController<ItemsRelationDTO>
	{
		public ItemsrelationController(DataContext context, ILogger<BaseController<ItemsRelationDTO>> logger) : base(context, logger)
		{
		}
	}
}