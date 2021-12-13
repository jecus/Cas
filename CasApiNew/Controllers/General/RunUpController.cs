using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("runup")]
	public class RunUpController : BaseController<RunUpDTO>
	{
		public RunUpController(DataContext context, ILogger<BaseController<RunUpDTO>> logger) : base(context, logger)
		{

		}
	}
}
