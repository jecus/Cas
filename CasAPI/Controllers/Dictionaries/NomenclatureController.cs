using EntityCore.DTO;
using EntityCore.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasAPI.Controllers.Dictionaries
{
	[Route("nomenclature")]
	public class NomenclatureController : BaseController<NomenclatureDTO>
	{
		public NomenclatureController(DataContext context, ILogger<BaseController<NomenclatureDTO>> logger) : base(context, logger)
		{
			
		}
	}
}