using System;
using Entity.Core;
using Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.Dictionaries
{
	[Route("cruiselevel")]
	public class CruiseLevelController : BaseDictionaryController<CruiseLevelDTO>
	{
		private Type _type = typeof(CruiseLevelDTO);

		public CruiseLevelController(DataContext context, ILogger<BaseController<CruiseLevelDTO>> logger) : base(context, logger)
		{
			
		}

	}
}