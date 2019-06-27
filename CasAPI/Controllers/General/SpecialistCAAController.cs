using EntityCore.DTO;
using EntityCore.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.General
{
	[Route("specialistCAA")]
	public class SpecialistCAAController : BaseController<SpecialistCAADTO>
	{
		public SpecialistCAAController(DataContext context, ILogger<BaseController<SpecialistCAADTO>> logger) : base(context, logger)
		{

		}
	}
}

