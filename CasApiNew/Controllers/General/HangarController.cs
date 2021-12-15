using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("hangar")]
	public class HangarController : BaseController<HangarDTO>
	{
		public HangarController(DataContext context, ILogger<BaseController<HangarDTO>> logger) : base(context, logger)
		{

		}
	}
}
