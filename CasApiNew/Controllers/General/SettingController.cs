using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("setting")]
	public class SettingController : BaseController<SettingDTO>
	{
		public SettingController(DataContext context, ILogger<BaseController<SettingDTO>> logger) : base(context, logger)
		{
		}
	}
}