using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("runup")]
	public class RunUpController : BaseController<RunUpDTO>
	{
		public RunUpController(DataContext context, ILogger<BaseController<RunUpDTO>> logger) : base(context, logger)
		{

		}
	}
}
