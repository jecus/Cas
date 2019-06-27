using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("ATLB")]
	public class ATLBController : BaseController<ATLBDTO>
	{
		public ATLBController(DataContext context, ILogger<BaseController<ATLBDTO>> logger) : base(context, logger)
		{
			
		}
	}
}