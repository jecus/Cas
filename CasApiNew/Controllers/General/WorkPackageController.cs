﻿using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("workpackage")]
	public class WorkPackageController : BaseController<WorkPackageDTO>
	{
		public WorkPackageController(DataContext context, ILogger<BaseController<WorkPackageDTO>> logger) : base(context, logger)
		{

		}
	}
}
