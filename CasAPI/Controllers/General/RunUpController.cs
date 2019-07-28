using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("runup")]
	public class RunUpController : BaseController<RunUpDTO>
	{
		public RunUpController(DataContext context, ILogger<BaseController<RunUpDTO>> logger) : base(context, logger)
		{

		}
	}
}
