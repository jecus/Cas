using CAA.API.Controllers;
using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("specialistcaa")]
	public class SpecialistCAAController : BaseController<CAASpecialistCAADTO>
	{
		public SpecialistCAAController(DataContext context, ILogger<BaseController<CAASpecialistCAADTO>> logger) : base(context, logger)
		{

		}
	}
}

