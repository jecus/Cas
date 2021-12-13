using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("specialistcaa")]
	public class SpecialistCAAController : BaseController<SpecialistCAADTO>
	{
		public SpecialistCAAController(DataContext context, ILogger<BaseController<SpecialistCAADTO>> logger) : base(context, logger)
		{

		}
	}
}

