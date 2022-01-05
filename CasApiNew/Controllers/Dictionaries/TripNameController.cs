using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("tripname")]
	public class TripNameController : BaseDictionaryController<TripNameDTO>
	{
        public TripNameController(DataContext context, ILogger<BaseController<TripNameDTO>> logger) : base(context, logger)
		{
			
		}
    }
}