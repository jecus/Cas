using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("setting")]
	public class SettingController : BaseController<SettingDTO>
	{
		public SettingController(DataContext context, ILogger<BaseController<SettingDTO>> logger) : base(context, logger)
		{
		}
	}
}