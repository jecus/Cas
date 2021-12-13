using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("procedure")]
	public class ProcedureController : BaseController<ProcedureDTO>
	{
		public ProcedureController(DataContext context, ILogger<BaseController<ProcedureDTO>> logger) : base(context, logger)
		{

		}
	}
}
