using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("setting")]
	public class SettingController : BaseController<SettingDTO>
	{
		public SettingController(DataContext context, ILogger<BaseController<SettingDTO>> logger) : base(context, logger)
		{
		}
	}
}