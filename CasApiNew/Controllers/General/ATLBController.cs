
using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("atlb")]
	public class ATLBController : BaseController<ATLBDTO>
	{
		public ATLBController(DataContext context, ILogger<BaseController<ATLBDTO>> logger) : base(context, logger)
		{
			
		}
	}
}