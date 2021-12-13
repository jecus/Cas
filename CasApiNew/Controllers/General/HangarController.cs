using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("hangar")]
	public class HangarController : BaseController<HangarDTO>
	{
		public HangarController(DataContext context, ILogger<BaseController<HangarDTO>> logger) : base(context, logger)
		{

		}
	}
}
