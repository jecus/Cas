using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAA.API.Controllers.General
{
	[Route("pelspecialist")]
	public class PelSpecialistController : BaseController<PelSpecialistDTO>
	{
		public PelSpecialistController(DataContext context, ILogger<BaseController<PelSpecialistDTO>> logger) : base(context, logger)
		{
		}
	}
}