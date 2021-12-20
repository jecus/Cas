using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Entity.Abstractions.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("attachedfile")]
	public class AttachedFileController : BaseController<AttachedFileDTO>
	{
		public AttachedFileController(DataContext context, ILogger<BaseController<AttachedFileDTO>> logger) : base(context, logger)
		{

		}
	}
}
