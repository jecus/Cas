using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("specialization")]
	public class SpecializationController : BaseController<SpecializationDTO>
	{
		public SpecializationController(DataContext context, ILogger<BaseController<SpecializationDTO>> logger) : base(context, logger)
		{
			
		}
	}
}