using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("airportcode")]
	public class AirportCodeController : BaseDictionaryController<AirportCodeDTO>
	{

        public AirportCodeController(DataContext context, ILogger<BaseController<AirportCodeDTO>> logger) : base(context, logger)
		{
			
		}
    }
}