using CAA.API.Controllers;
using CAA.Entity.Core;
using CAA.Entity.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("specialistmedicalrecord")]
	public class SpecialistMedicalRecordController : BaseController<CAASpecialistMedicalRecordDTO>
	{
		public SpecialistMedicalRecordController(DataContext context, ILogger<BaseController<CAASpecialistMedicalRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}

