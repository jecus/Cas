using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("procedure")]
	public class ProcedureController : BaseController<ProcedureDTO>
	{
		public ProcedureController(DataContext context, ILogger<BaseController<ProcedureDTO>> logger) : base(context, logger)
		{

		}
	}
}
