using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("airport")]
	public class AirportController : BaseDictionaryController<AirportDTO>
	{

        public AirportController(DataContext context, ILogger<BaseController<AirportDTO>> logger) : base(context, logger)
		{
			
		}
    }
}