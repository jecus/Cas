using CAA.API.Controllers;
using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("specialistcustom")]
	public class SpecialistCAAController : BaseController<CAASpecialistCustomDTO>
	{
		public SpecialistCAAController(DataContext context, ILogger<BaseController<CAASpecialistCustomDTO>> logger) : base(context, logger)
		{

		}
	}
}

