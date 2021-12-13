using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("modulerecord")]
	public class ModuleRecordController : BaseController<ModuleRecordDTO>
	{
		public ModuleRecordController(DataContext context, ILogger<BaseController<ModuleRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}
