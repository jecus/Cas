using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("specialistcaa")]
	public class SpecialistCAAController : BaseController<SpecialistCAADTO>
	{
		public SpecialistCAAController(DataContext context, ILogger<BaseController<SpecialistCAADTO>> logger) : base(context, logger)
		{

		}
	}
}

