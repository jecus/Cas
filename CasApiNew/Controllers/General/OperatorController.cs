using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("operator")]
	public class OperatorController : BaseController<OperatorDTO>
	{
		public OperatorController(DataContext context, ILogger<BaseController<OperatorDTO>> logger) : base(context, logger)
		{

		}
	}
}
