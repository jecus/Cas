using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
{
	[Route("nomenclature")]
	public class NomenclatureController : BaseDictionaryController<NomenclatureDTO>
	{

        public NomenclatureController(DataContext context, ILogger<BaseController<NomenclatureDTO>> logger) : base(context, logger)
		{
			
		}
    }
}