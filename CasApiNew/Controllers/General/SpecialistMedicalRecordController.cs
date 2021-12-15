using CAS.Entity.Core;
using CAS.Entity.Models.DTO.General;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CAS.API.Controllers.General
{
	[Route("specialistmedicalrecord")]
	public class SpecialistMedicalRecordController : BaseController<SpecialistMedicalRecordDTO>
	{
		public SpecialistMedicalRecordController(DataContext context, ILogger<BaseController<SpecialistMedicalRecordDTO>> logger) : base(context, logger)
		{

		}
	}
}

