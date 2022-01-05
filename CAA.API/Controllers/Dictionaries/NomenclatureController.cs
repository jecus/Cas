using CAA.Entity.Core;
using CAA.Entity.Models.Dictionary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.Dictionaries
{
	[Route("nomenclature")]
	public class NomenclatureController : BaseDictionaryController<CAANomenclatureDTO>
	{
        public NomenclatureController(DataContext context, ILogger<BaseController<CAANomenclatureDTO>> logger) : base(context, logger)
		{
			
		}
    }
}