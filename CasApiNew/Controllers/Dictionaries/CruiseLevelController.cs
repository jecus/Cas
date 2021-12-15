using System;
using CAS.Entity.Core;
using CAS.Entity.Models.DTO.Dictionaries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.Dictionaries
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