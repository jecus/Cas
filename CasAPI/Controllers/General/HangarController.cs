using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("hangar")]
	public class HangarController : BaseController<HangarDTO>
	{
		public HangarController(DataContext context, ILogger<BaseController<HangarDTO>> logger) : base(context, logger)
		{

		}
	}
}
