﻿using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("componentllpcategorychangerecord")]
	public class ComponentLLPCategoryChangeRecordController : BaseController<ComponentLLPCategoryChangeRecordDTO>
	{
		public ComponentLLPCategoryChangeRecordController(DataContext context, ILogger<BaseController<ComponentLLPCategoryChangeRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}

