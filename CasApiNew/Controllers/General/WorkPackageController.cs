﻿using Entity.Core;
using Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CasApiNew.Controllers.General
{
	[Route("workpackage")]
	public class WorkPackageController : BaseController<WorkPackageDTO>
	{
		public WorkPackageController(DataContext context, ILogger<BaseController<WorkPackageDTO>> logger) : base(context, logger)
		{

		}
	}
}
